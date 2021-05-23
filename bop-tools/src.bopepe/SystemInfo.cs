using FcpUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FcpTools
{
    [XmlRoot("ToolConfig")]
    public class ToolConfig {
        public class HMI
        {
            [XmlArrayItem(ElementName = "property")]
            public List<KeyValueType<string, string>> layoutManager = new List<KeyValueType<string, string>>();

            [XmlArrayItem(ElementName = "property")]
            public List<KeyValueType<string, string>> helpPage = new List<KeyValueType<string, string>>();

            [XmlArrayItem(ElementName = "property")]
            public List<KeyValueType<string, string>> dataStore = new List<KeyValueType<string, string>>();

            [XmlArrayItem(ElementName = "property")]
            public List<KeyValueType<string, string>> logViews = new List<KeyValueType<string, string>>();
        }

        [XmlElement(ElementName = "hmi")]
        public HMI hmi = new HMI();

        internal List<KeyValueType<string, string>> LogViews {get => hmi.logViews;}
        internal Dictionary<string, string> Properties = new Dictionary<string, string>();

        internal ToolConfig()
        {
            Console.WriteLine("ToolConfig counstrutor is called ...");
        }

        internal void LoadDictionary()
        {
            // TODO dicitonary가 Serializing이 되지 않아서 List로 읽어온 후 Dictionary로 변환함. 개선 필요
            try
            {
                Properties.Clear();
                if (hmi.layoutManager.Count > 0)
                {
                    foreach (KeyValueType<string, string> kv in hmi.layoutManager)
                    {
                        Properties.Add("Layout." + kv.Key, kv.Value);
                    }
                }
                if (hmi.helpPage.Count > 0)
                {
                    foreach (KeyValueType<string, string> kv in hmi.helpPage)
                    {
                        Properties.Add("Help." + kv.Key, kv.Value);
                    }
                }
                if (hmi.dataStore.Count > 0)
                {
                    foreach (KeyValueType<string, string> kv in hmi.dataStore)
                    {
                        Properties.Add("DataStore." + kv.Key, kv.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Fail to convert list to dictionary, " + ex.Message);
            }
        }

        internal void SetDefaultInfo()
        {
            hmi.logViews.Add(new KeyValueType<string, string>("Console", "console.log"));
            //InfoHMI.logViews.Add(new KeyValueType<string, string>("Device", "device.log"));
            //InfoHMI.logViews.Add(new KeyValueType<string, string>("Network", "network.log"));
            //InfoHMI.dataStore.Add(new KeyValueType<string, string>("InitialTags", @"\data\subc-default-values.txt"));
            //InfoHMI.dataStore.Add(new KeyValueType<string, string>("MappingTags", @"\data\data-signal-map.txt"));
        }
    }

    public class ConfigInfo
    {
        private static ConfigInfo _instance = null;
        public ToolConfig Settings = null;

        private ConfigInfo()
        {
        }

        static private ConfigInfo GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConfigInfo();
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ToolConfig));
                    string configPath = Application.StartupPath + @"\config\bopepe-config.xml";
                    TextReader reader = new StreamReader(configPath);
                    Console.WriteLine("tool config file, " + configPath);
                    _instance.Settings = (ToolConfig)serializer.Deserialize(reader);
                    reader.Close();

                    // make dictionary from configuration
                    _instance.Settings.LoadDictionary();
                }
                catch (System.Exception e1)
                {
                    Console.WriteLine("tool config file loading error, " + e1.Message);
                    _instance.Settings = new ToolConfig();
                }

                // another issue?
                if (_instance.Settings.LogViews.Count == 0)
                {
                    //_instance.Settings.SetDefaultInfo();
                    Console.Error.WriteLine("Tool configuration loading error");
                    Console.WriteLine(_instance.ToString());
                }

                // Config file 로딩 후 추가 작업
                //_instance.Settings.LoadDictionary();
            }
            return _instance;
        }

        static public ToolConfig GetSettings()
        {
            return GetInstance().Settings;
        }


        override public string ToString()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ToolConfig));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, _instance.Settings);

            return writer.ToString();
        }

    }

    public static class SystemData {
        public static DataTable MemTable = new DataTable("MemTable");

        static SystemData()
        {
            // set table columns
            string[] colName = { "Tag Name", "Value", "Description", "Updated" };
            string[] colType = { "System.String", "System.Double", "System.String", "System.DateTime" };
            //bool[] colReadOnly = { true, false, true, false };
            for (int i=0; i<colName.Length; i++)
            {
                DataColumn col = new DataColumn(colName[i], Type.GetType(colType[i]));
                MemTable.Columns.Add(col);
            }
            // for searching, filtering
            MemTable.PrimaryKey = new DataColumn[] { MemTable.Columns["Tag Name"] };
        }


        // Tag - Value의 초기값을 SystemData.MemTable에 넣는 함수
        internal static void LoadTagValues(string filePath)
        {
            // open property file
            Property prop = new Property(filePath);

            // update data source
            foreach (KeyValuePair<string, string> kv in prop.GetList())
            {
                if (!double.TryParse(kv.Value, out double dblValue))
                {
                    Console.Error.WriteLine("invalid value " + kv.Key + ":" + kv.Value);
                    continue;
                }

                try
                {
                    // name, value
                    System.Data.DataRow row = SystemData.MemTable.Rows.Find(kv.Key);
                    //DataRow row = SystemData.SignalData.AsEnumerable().FirstOrDefault(tt => tt.Field<string>("Name") == kv.Key);
                    if (row != null)
                    {
                        // row exists
                        row["Value"] = dblValue;
                    }
                    else
                    {
                        SystemData.MemTable.Rows.Add(new object[] { kv.Key, dblValue });
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("insert value error, ex=" + ex.Message);
                    SystemData.MemTable.Rows.Add(new object[] { kv.Key, dblValue });
                    continue;
                }
            }
        }

        public static void UpdateTagData(Dictionary<string, float> values)
        {
            try
            {
                // update memory data table
                DateTime nowTime = DateTime.Now;
                foreach (KeyValuePair<string, float> kv in values)
                {
                    string tagName = kv.Key;
                    try
                    {
                        // find tag
                        bool exist = MemTable.Rows.Contains(tagName);
                        DataRow row = SystemData.MemTable.Rows.Find(tagName);
                        if (exist && row != null)
                        {
                            try
                            {
                                row[1] = kv.Value;
                                row[2] = nowTime;
                            }
                            catch (NullReferenceException e1)
                            {
                                Console.WriteLine("null reference, Tag=" + tagName + "ex=" + e1.Message);
                            }
                        }
                        else if (!string.IsNullOrEmpty(tagName))
                        {
                            //SystemData.MemTable.Rows.Add(new object[] { sigMemName, kv.Value });
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("update tag error, Tag=" + tagName + ", Val=" + kv.Value.ToString() + ", rowCnt=" + SystemData.MemTable.Rows.Count.ToString() + ", ex=" + ex.Message);
                        continue;
                    }
                }
            }
            catch(Exception e1)
            {
                Console.WriteLine("other ex=" + e1.Message);
            }
        }
    }
}


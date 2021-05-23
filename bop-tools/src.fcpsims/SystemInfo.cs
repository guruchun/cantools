using FcpUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FcpSims
{
    [XmlRootAttribute("SimsConfig")]
    public class ToolConfig {
        public class HMI
        {
            [XmlArrayItem(ElementName = "property")]
            public List<KeyValueType<string, string>> helpPage = new List<KeyValueType<string, string>>();

            [XmlArrayItem(ElementName = "property")]
            public List<KeyValueType<string, string>> dataStore = new List<KeyValueType<string, string>>();

            [XmlArrayItem(ElementName = "property")]
            public List<KeyValueType<string, string>> modbus = new List<KeyValueType<string, string>>();

            [XmlArrayItem(ElementName = "property")]
            public List<KeyValueType<string, string>> logViews = new List<KeyValueType<string, string>>();
        }

        // 2020.11.16 sungjun
        public class DEV
        {
            [XmlArrayItem(ElementName = "property")]
            public List<KeyValueType<string, string>> inv = new List<KeyValueType<string, string>>();
            [XmlArrayItem(ElementName = "property")]
            public List<KeyValueType<string, string>> tcm = new List<KeyValueType<string, string>>();
        }

        [XmlElement(ElementName = "hmi")]
        public HMI hmi = new HMI();

        // 2020.11.16 sungjun
        [XmlElement(ElementName = "dev")]
        public DEV dev = new DEV();

        internal List<KeyValueType<string, string>> LogViews {get => hmi.logViews;}
        internal Dictionary<string, string> Properties = new Dictionary<string, string>();

        // 2020.11.16 sungjun
        internal Dictionary<string, string> DeviceProperties = new Dictionary<string, string>();

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
                if(hmi.modbus.Count > 0)
                {
                    foreach(KeyValueType<string, string>kv in hmi.modbus)
                    {
                        Properties.Add("Modbus." + kv.Key, kv.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Fail to convert list to dictionary, " + ex.Message);
            }
        }


        // 2020.11.16 sungjun
        internal void LoadDeviceProperties()
        {
            try
            {
                DeviceProperties.Clear();

                if(dev.inv.Count > 0)
                {
                    foreach(KeyValueType<string, string> kv in dev.inv)
                    {
                        DeviceProperties.Add("Inv." + kv.Key, kv.Value);
                    }
                }
                if(dev.tcm.Count > 0)
                {
                    foreach(KeyValueType<string, string> kv in dev.tcm)
                    {
                        DeviceProperties.Add("Tcm." + kv.Key, kv.Value);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine("Fail to convert list to Device Properties, " + ex.Message);
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
                    TextReader reader = new StreamReader(Application.StartupPath + @"\config\sofcsims-config.xml");
                    _instance.Settings = (ToolConfig)serializer.Deserialize(reader);
                    reader.Close();

                    // make dictionary from configuration
                    _instance.Settings.LoadDictionary();

                    // 2020.11.16 sungjun
                    _instance.Settings.LoadDeviceProperties();
                }
                catch (System.Exception e1)
                {
                    Console.WriteLine("configuration loading error, " + e1.Message);
                    _instance.Settings = new ToolConfig();
                }

                // another issue?
                if (_instance.Settings.LogViews.Count == 0)
                {
                    //_instance.Settings.SetDefaultInfo();
                    Console.Error.WriteLine("configuration loading error");
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
        // system data to CAN raw signal
        public static Dictionary<string, string> DataToRawSignalName = new Dictionary<string, string>();
        // CAN raw signal to system data
        public static Dictionary<string, string> RawSignalToDataName = new Dictionary<string, string>();

        static SystemData()
        {
            // set table columns
            string[] colName = { "Tag Name", "Value", "Signal", "Updated", "Counter" };
            string[] colType = { "System.String", "System.Double", "System.String", "System.DateTime", "System.Int32" };
            bool[] colReadOnly = { true, false, true, false, false };
            for (int i = 0; i < colName.Length; i++)
            {
                DataColumn col = new DataColumn(colName[i], Type.GetType(colType[i]));
                //col.ReadOnly = colReadOnly[i];
                MemTable.Columns.Add(col);
            }
            // for searching, filtering
            MemTable.PrimaryKey = new DataColumn[] { MemTable.Columns["Tag Name"] };
        }

        public static void LoadDataMap(string filePath)
        {
            // load signal mapping file
            Property prop = new Property(filePath);

            foreach (KeyValuePair<string, string> kv in prop.GetList())
            {
                try
                {
                    // system data --> can raw signal
                    if (DataToRawSignalName.ContainsKey(kv.Key))
                    {
                        DataToRawSignalName[kv.Key] = kv.Value;
                        //DataToRawSignalName.Add(kv.Key, kv.Value);
                        Console.Error.WriteLine("duplicated system data name, key=" + kv.Key + ", value=" + kv.Value);
                    } else
                    {
                        DataToRawSignalName.Add(kv.Key, kv.Value);
                    }

                    // CAN raw signal --> system data
                    if (RawSignalToDataName.ContainsKey(kv.Value))
                    {
                        RawSignalToDataName[kv.Value] = kv.Key;
                        //RawSignalToDataName.Add(kv.Value, kv.Key);
                        Console.Error.WriteLine("duplicated raw signal name, key=" + kv.Value + ", value=" + kv.Key);
                    }
                    else
                    {
                        RawSignalToDataName.Add(kv.Value, kv.Key);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("load mapping signals error, key=" + kv.Key + ", value=" + kv.Value + ", ex=" + ex.Message);
                    continue;
                }
            }

            // Initialize MemTable
            foreach (KeyValuePair<string, string> kv in DataToRawSignalName)
            {
                System.Data.DataRow row = SystemData.MemTable.Rows.Find(kv.Key);
                if (row != null)
                {
                    // row exists
                    row["Signal"] = DataToRawSignalName[kv.Key];
                }
                else
                {
                    SystemData.MemTable.Rows.Add(new object[] { kv.Key, 0, DataToRawSignalName[kv.Key] });
                }
            }
            Console.WriteLine("load signal name mapping table complete");
            Console.WriteLine("DataToRaw Map={0}, RawToData Map={1}, MemTable={2}", 
                DataToRawSignalName.Count, RawSignalToDataName.Count, MemTable.Rows.Count);
        }

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
    }
}


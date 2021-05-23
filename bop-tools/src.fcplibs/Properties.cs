using System;
using System.Collections.Generic;
using System.Linq;

namespace FcpUtils {
    public class Property {
        private Dictionary<string, string> list;
        private string filename;

        public Property(string file)
        
        {
             Load(file);
        }

        public string Get(string field, string defValue)
        {
            // null이면 defValue 사용
            return Get(field) ?? defValue;
        }
        public string Get(string field)
        {
            return (list.ContainsKey(field)) ? (list[field]) : (null);
        }
        public Dictionary<string, string> GetList()
        {
            return list;
        }

        public void Set(string field, Object value)
        {
            if (!list.ContainsKey(field))
                list.Add(field, value.ToString());
            else
                list[field] = value.ToString();
        }

        public void Save()
        {
            Save(this.filename);
        }

        public void Save(string filename)
        {
            this.filename = filename;

            if (!System.IO.File.Exists(filename))
                System.IO.File.Create(filename);

            System.IO.StreamWriter file = new System.IO.StreamWriter(filename);

            foreach (string prop in list.Keys.ToArray())
                if (!string.IsNullOrWhiteSpace(list[prop]))
                    file.WriteLine(prop + "=" + list[prop]);

            file.Close();
        }

        public void Reload()
        {
            Load(this.filename);
        }

        public void Load(string filename)
        
        {
            this.filename = filename;
            list = new Dictionary<string, string>();

            if (System.IO.File.Exists(filename))
                LoadFromFile(filename);
            else
                System.IO.File.Create(filename);
        }

        private void LoadFromFile(string file)
        {
            System.IO.StreamReader fileReader = new System.IO.StreamReader(file);

            System.Console.WriteLine("load property file, {0}", file);
            //string line;
            //while ((line = fileReader.ReadLine()) != null)
            foreach (string line in System.IO.File.ReadAllLines(file, System.Text.Encoding.UTF8))
            {
                // check invalid line
                if ((string.IsNullOrEmpty(line)) || (line.StartsWith(";")) || (line.StartsWith("#")) || (!line.Contains('=')))
                {
                    Console.WriteLine("ignored line, " + line);
                    continue;
                }

                try
                {
                    // ignore line comment
                    string kvLine = line;
                    int pos = line.IndexOf(';');
                    if (pos > 0)
                        kvLine = line.Substring(0, pos).Trim();
                    pos = line.IndexOf('#');
                    if (pos > 0)
                        kvLine = line.Substring(0, pos).Trim();

                    // parse key & value
                    int index = kvLine.IndexOf('=');
                    string key = kvLine.Substring(0, index).Trim();
                    string value = kvLine.Substring(index + 1).Trim();
                    list.Add(key, value);
                }
                catch (Exception ex)
                {
                    // ignore duplicates
                    System.Console.WriteLine("ignore parsing error, line='{0}', ex={1}", line,  ex.Message);
                }
            }
            fileReader.Close();
        }
    }
}

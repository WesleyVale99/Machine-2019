
using System;
using System.Collections.Generic;
using System.IO;

namespace PointBlank___Machine
{
    public class LoadingFile
    {
        public FileInfo File;
        public Dictionary<string, string> list = new Dictionary<string, string>();
        public LoadingFile(string file)
        {
            File = new FileInfo(file);
            Load();
        }
        public void Load()
        {
            list.Clear();
            StreamReader stream = new StreamReader(File.FullName);
            try
            {
                while (!stream.EndOfStream)
                {
                    string str = stream.ReadLine();
                    if (str.Length != 0 && !str.StartsWith(";") && !str.StartsWith("["))
                    {
                        if (!list.ContainsKey(str.Split('=')[0]))
                            list.Add(str.Split('=')[0], str.Split('=')[1]);
                    }
                }
            }
            catch (Exception e)
            {
                new _Message().Error(e.ToString());
            }
            finally
            {
                stream.BaseStream.Flush();
                stream.BaseStream.Close();
                stream.Close();
                stream.Dispose();
            }
        }
        public string Get(string value)
        {
            try
            {
                return list[value];
            }
            catch (Exception e)
            {
                new _Message().Error($"value:{value} [" + e.ToString() + "]");
                return "";
            }
        }
    }
}

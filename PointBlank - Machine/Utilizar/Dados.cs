using System;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Threading;


namespace PointBlank___Machine
{
    public static class Dados
    {
        public static void Close(BinaryReader reader)
        {
            try
            {
                if (reader.BaseStream != null)
                    reader.BaseStream.Close();
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                    reader = null;
                }
            }
            catch (Exception e)
            {
                new _Message().Error((e.ToString()));
            }
        }
        public static void IniciarThead(ThreadStart start) => NewDelegate(new Thread(new ThreadStart(start)));
        public static void NewDelegate(Thread thread)
        {
            try
            {
                thread.Start();
            }
            catch
            {
                thread.Abort();
                thread.Interrupt();
                thread = null;
            }
        }
        public static string GetHashFile(string fileName)
        {
            string str = string.Empty;
            if (File.Exists(fileName) && fileName != string.Empty && fileName.Length != 0)
            {
                using (FileStream FS = File.OpenRead(fileName))
                {
                    str = BitConverter.ToString((new MD5CryptoServiceProvider()).ComputeHash(FS)).Replace("-", string.Empty);
                    FS.Flush();
                    FS.Close();
                }
            }
            return str;
        }
        public static byte[] Encrypt(byte[] buffer, int shift)
        {
            int length = buffer.Length;
            byte first = buffer[0];
            byte current;
            for (int i = 0; i < length; i++)
            {
                if (i >= (length - 1))
                    current = first;
                else
                    current = buffer[i + 1];
                buffer[i] = (byte)(current >> (8 - shift) | (buffer[i] << shift));
            }
            return buffer;
        }
        public static string MyHwid()
        {
            string Id = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            foreach (ManagementObject mo in mc.GetInstances())
            {
                Id = mo.Properties["processorID"].Value.ToString();
                mo.Dispose();
                break;
            }
            mc.Dispose();
            return Id;
        }
    }
}

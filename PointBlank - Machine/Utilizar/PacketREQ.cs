using System;
using System.IO;
using System.Text;

namespace PointBlank___Machine
{
    public abstract class PacketREQ : ICloneable
    {
        public AuthClient AuthClient;
        public GameClient clientGame;
        public BinaryReader reader;
        public Player player;
        public Carregar Carregar;
        public Classe_Raiz Classe_;
        public byte[] buffer;
        public void SetReader(AuthClient AuthClient, GameClient clientGame, BinaryReader reader, byte[] buffer)
        {
            this.clientGame = clientGame;
            this.AuthClient = AuthClient;
            this.reader = reader;
            this.buffer = buffer;
            Classe_ = Classe_Raiz.INTs();
            player = Conexão.INSTs().player;
            Carregar = Carregar.INTs();
        }
        public void Run()
        {
            try
            {
                Avoid();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                Close();
            }
        }
        public void Close()
        {
            try
            {
                Dados.Close(reader);
            }
            catch (Exception e)
            {
                new _Message().Error(e.ToString());
            }
        }
        public abstract void Avoid();
        protected internal byte ReadC() => reader.ReadByte();
        protected internal short ReadU() => reader.ReadInt16();
        protected internal int ReadD() => reader.ReadInt32();
        protected internal long ReadQ() => reader.ReadInt64();
        protected internal byte[] ReadB(int count) => reader.ReadBytes(count);
        protected internal sbyte ReadSB() => reader.ReadSByte();
        protected internal ushort ReadUH() => reader.ReadUInt16();
        protected internal uint ReadUD() => reader.ReadUInt32();
        protected internal ulong ReadUQ() => reader.ReadUInt64();
        protected internal string ReadS(int qty)
        {
            string texto = Encoding.GetEncoding(1251).GetString(ReadB(qty));
            int length = texto.IndexOf(char.MinValue);
            if (length != -1)
                texto = texto.Substring(0, length);
            return texto;
        }
        protected internal string ReadString(int size)
        {
            string texto = Encoding.GetEncoding(1252).GetString(ReadB(size));
            int length = texto.IndexOf(char.MinValue);
            if (length != -1)
                texto = texto.Substring(0, length);
            return texto;
        }
        protected internal string ReadUS(int qty)
        {
            string texto = Encoding.GetEncoding(1252).GetString(ReadB(qty * 2));
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < texto.Length; i++)
            {
                if (i % 2 == 0)
                    s.Append(texto[i].ToString());
            }
            return s.ToString();
        }
        public object Clone() => MemberwiseClone();
    }
}

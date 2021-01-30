using System;
using System.Linq;

namespace PointBlank___Machine
{
    public class Carregar : LoadingFile
    {
        public static string Path = "Config//Machine.ini";
        //STRINGS
        public string USER = "wsly";
        public string PASS = "vale";
        public string IP;
        public string meuMac;
        public string FILELISTDAT;
        public string fakeIP;
        public string HARDWAREID;
        public string CLIENTEVERSION;

        //int
        public int IPINDEX = 3;

        //bool
        public bool AutoCreate;

        // byte, byte[], ushort and ulong
        public Tipo_Conexão CONNECTION;
        public byte[] CLIENTE = new byte[3];
        public ulong KEY = 0;
        public Regions region;


        //GET CONFIG
        public Carregar() : base(Path)
        {
        }
        public void Run()
        {
            if (list.Count > 0)
                Load();

            IP = Get("Addr");
            fakeIP = Get("FakeAddr");
            CONNECTION = (Tipo_Conexão)byte.Parse(Get("Acoplamento"));
            KEY = ulong.Parse(Get("Arremessador"));
            region = (Regions)byte.Parse(Get("Local"));
            for (int i = 0; i < CLIENTE.Length; i++)
                CLIENTE[i] = byte.Parse((CLIENTEVERSION = Get("NumeroDaCliente")).Split('.')[i]);
            FILELISTDAT = Dados.GetHashFile("Config//UserFileList.dat");
            AutoCreate = bool.Parse(Get("ContaAutomatica"));
            if (AutoCreate)
                GetAccountAuto();
            meuMac = GetRandomMacAddress();//GetRandomMacAddress();
            if (bool.Parse(Get("HardwareID")))
                HARDWAREID = GetHWIDRandom();
            else
                HARDWAREID = "Wesley_Te_Comeu";
        }
        public void GetAccountAuto()
        {
            USER += string.Concat(new Random().Next(0, 1000));
            PASS += string.Concat(new Random().Next(0, 1000));
        }
        public static string GetRandomMacAddress()
        {
            var result = string.Concat(new byte[6].Select(x => string.Format("{0}:", x.ToString("X2"))).ToArray());
            return result.TrimEnd(':');
        }
        public static string GetHWIDRandom()
        {
            string HWID = string.Empty;
            switch (new Random().Next(0, 17))
            {
                case 1: HWID = "8ead5f0bc40579b106cdd9d2591cfec5"; break;
                case 2: HWID = "fbe5b7df18cd87c7c193e4fa503cba9f"; break;
                case 3: HWID = "d85f310b0871af13961d1c9a9695d756"; break;
                case 4: HWID = "949e0e42daad0418513b44c31a697ca5"; break;
                case 5: HWID = "d10ce25f7304cd6f69e1ef859d52e43e"; break;
                case 6: HWID = "0936955770489965eb9041d00636369d"; break;
                case 7: HWID = "6ef5f3f18413c367195f06e503ab86a6"; break;
                case 8: HWID = "7459301d21c2e21468823f73042d9f87"; break;
                case 9: HWID = "118ba3061b4040bdc17432b775f3a292"; break;
                case 10: HWID = "4102898869c3f72fbd50e7a7d003f530"; break;
                case 11: HWID = "4a4f18a6befa9d27e1c33c47dc617775"; break;
                case 12: HWID = "6a23068f2043726f706931d0f7867eed"; break;
                case 13: HWID = "e731e28520e527e9eac2049b3147d536"; break;
                case 14: HWID = "0dbba022ec74c68bcb66677c374f5898"; break;
                case 15: HWID = "89c616a2351571c80a1c8e59f06993c0"; break;
                case 16: HWID = "9d8bc943f18912a09c5724f35691b765"; break;
                case 17: HWID = "17c406d38c3989ff3bdb17d08c1991ce"; break;
            }
            return HWID;
        }
        static readonly Carregar INTS = new Carregar();
        public static Carregar INTs() => INTS;
    }
}

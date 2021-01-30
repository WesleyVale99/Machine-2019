using System;
using System.Net;

namespace PointBlank___Machine
{
   public class Player : ICloneable
    {
        public long ID;
        public int ClanID;
        public string nick;
        public int exp;
        public int rank;
        public int gold;
        public int cash;
        public NivelDeAcesso acess;
        public byte revs;
        public int roomId;
        public int Encrypt;
        public bool loggerUser = false;
        public volatile AuthClient AuthClient;
        public volatile GameClient GameClient;
        public IPEndPoint server;
        public byte[] ADDR = new byte[4];
        public object Clone() => MemberwiseClone();
    }
}

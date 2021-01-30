using System;
using System.Linq;

namespace PointBlank___Machine
{
    public class BASE_LOGIN_ACK : Processor
    {
        public BASE_LOGIN_ACK() : base(2561)
        {
        }
        public override byte[] Write()
        {
            send.WriteC(Carregar.CLIENTE[0]);
            send.WriteH(Carregar.CLIENTE[1]); 
            send.WriteH(Carregar.CLIENTE[2]);
            send.WriteC((byte)Carregar.region);
            send.WriteC((byte)Carregar.USER.Length);
            send.WriteC((byte)Carregar.PASS.Length);
            send.WriteS(Carregar.USER, Carregar.USER.Length);
            send.WriteS(Carregar.PASS, Carregar.PASS.Length);
            send.WriteB("5C:C9:D3:7B:DD:CA".Split(':').Select(x => Convert.ToByte(x, 16)).ToArray()); //Carregar.meuMac.Split(':').Select(x => Convert.ToByte(x, 16)).ToArray()
            send.WriteH(0);//0
            send.WriteC((byte)Carregar.CONNECTION);
            send.WriteB(player.ADDR);
            send.WriteQ(Carregar.KEY);
            send.WriteS(Carregar.FILELISTDAT, 32);
            send.WriteD(0);
            send.WriteS("18ae4149293d2baa7c3d1ac16aca19bb", 32);
            send.WriteD(0);
            return Return();
        }
    }
}

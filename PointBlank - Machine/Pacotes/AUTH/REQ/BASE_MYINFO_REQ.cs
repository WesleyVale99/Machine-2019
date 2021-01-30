using System.Drawing;

namespace PointBlank___Machine
{
    public class BASE_MYINFO_REQ : PacketREQ
    {
        public override void Avoid()
        {
            if (ReadD() > 1)
                Program.Form1.WriteSender("[ERROR] - Buscar informação do Usuario.", Color.Red);
            else
            {
                player.revs = ReadC();
                player.nick = ReadS(33);
                player.exp = ReadD();
                player.rank = ReadD();
                ReadD(); //FAKERANK
                player.gold = ReadD();
                player.cash = ReadD();
                player.ClanID = ReadD();
                ReadB(12);
                player.acess = (NivelDeAcesso)ReadC();
                ReadB(161);
                Program.Form1.InforSender("[Templates] Rev: [" + player.revs + "]", false);
                Program.Form1.InforSender("[Templates] Nick: [" + player.nick + "]", false);
                Program.Form1.InforSender("[Templates] Exp: [" + player.exp + "]", false);
                Program.Form1.InforSender("[Templates] Rank: [" + player.rank + "]", false);
                Program.Form1.InforSender("[Templates] Money: [" + player.cash + "]", false);
                Program.Form1.InforSender("[Templates] Gold: [" + player.gold + "]", false);
                Program.Form1.InforSender("[Templates] Acesso: [" + player.acess + "]", false);
            }
            AuthClient.SendPacket(new BASE_SOURCE_ACK().Write());
            AuthClient.SendPacket(new BASE_CONFIG_ACK().Write());
            AuthClient.SendPacket(new BASE_ENTER_SERVER_ACK().Write());
        }
    }
}

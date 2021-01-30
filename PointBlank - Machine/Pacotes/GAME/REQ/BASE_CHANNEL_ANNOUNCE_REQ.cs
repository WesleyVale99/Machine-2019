using System.Drawing;

namespace PointBlank___Machine
{
    public class BASE_CHANNEL_ANNOUNCE_REQ : PacketREQ
    {
        public override void Avoid()
        {
            Canal_Type channelId = (Canal_Type) ReadD();
            if (channelId >= Canal_Type.Canal_1 && channelId <= Canal_Type.Canal_9)
            {
                Program.Form1.label10.Text = Carregar.CLIENTE[2] >= 34 ? ReadUS(ReadU()) : ReadS(ReadU());
                Program.Form1.InforSender($"Entrou no canal { channelId }.", false);
                Program.Form1.WriteSender($"Entrou no canal { channelId }.", Color.Green);
                clientGame.SendPacket(new LOBBY_ENTER_ACK().Write());
            }
            else
            {
                Program.Form1.WriteSender($"error ao entrar no canal { channelId }.", Color.Red);
            }
        }
    }
}

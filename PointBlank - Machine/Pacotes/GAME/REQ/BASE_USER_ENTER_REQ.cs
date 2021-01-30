using System.Drawing;

namespace PointBlank___Machine
{
    public class BASE_USER_ENTER_REQ : PacketREQ
    {
        public override void Avoid()
        {
            int error = ReadD();
            if (error == 0 || error == 1)
            {
                if (Program.Form1.classe_.Robô)
                    Conexão.INSTs().player.GameClient.SendPacket(new BASE_CHANNEL_ANNOUNCE_ACK(0).Write());
                else
                {
                    Program.Form1.WriteSender("Digite o Numero do canal: ", Color.Yellow);
                    Program.Form1.Exceptions = Exceptions.Mundança_de_Canal;
                }
            }
            else
            {
                Program.Form1.WriteSender($"BASE_USER_ENTER_REQ:{error}", Color.Red);
            }
        }
    }
}

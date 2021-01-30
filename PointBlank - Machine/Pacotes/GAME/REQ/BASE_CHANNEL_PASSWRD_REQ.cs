using System.Drawing;

namespace PointBlank___Machine
{
    public class BASE_CHANNEL_PASSWRD_REQ : PacketREQ
    {
        public override void Avoid()
        {
            int error = ReadD();
            if (error == 0 || error == 1)
            {
                Program.Form1.WriteSender("a senha digitada está correta. ", Color.Green);
                clientGame.SendPacket(new GAME_BASE_USER_ENTER_ACK().Write());
            }
            else
                Program.Form1.WriteSender("a sua senha digitada está incorreta. ", Color.Red);
        }
    }
}

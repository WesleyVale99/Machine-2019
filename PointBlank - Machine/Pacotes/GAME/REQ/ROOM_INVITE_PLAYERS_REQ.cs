using System.Drawing;

namespace PointBlank___Machine
{
    public class ROOM_INVITE_PLAYERS_REQ : PacketREQ
    {
        public override void Avoid()
        {
            if (ReadD() > 0)
                Program.Form1.WriteSender("Error ao Enviar Convites para Players", Color.Red);
        }
    }
}

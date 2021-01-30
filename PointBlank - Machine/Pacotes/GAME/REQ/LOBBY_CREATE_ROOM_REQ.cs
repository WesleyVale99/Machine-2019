using System.Drawing;

namespace PointBlank___Machine
{
    public class LOBBY_CREATE_ROOM_REQ : PacketREQ
    {
        public override void Avoid()
        {
            int error = ReadD();
            if (error == 0 || error == 1)
            {
                int id = ReadD();
                string Name = ReadS(23);
                Program.Form1.label10.Text = "Você conseguiu criar uma sala.";
                Program.Form1.WriteSender("Você conseguiu criar uma sala.", Color.Green);
                Program.Form1.Lobby.room.EnabledAll();
            }
            else
            {
                Program.Form1.room.label10.Text = $"Você não conseguiu criar uma sala. [{error}]";
                Program.Form1.WriteSender($"Você não conseguiu criar uma sala. [{error}]", Color.Red);
            }
        }
    }
}

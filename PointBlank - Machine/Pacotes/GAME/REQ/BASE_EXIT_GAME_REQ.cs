using System;
using System.Drawing;
using System.Net.Sockets;

namespace PointBlank___Machine
{
    public class BASE_EXIT_GAME_REQ : PacketREQ
    {
        public override void Avoid()
        {
            new Action(() => Program.Form1.label9.Location = new Point(124, 19)).Invoke();
            new Action(() => Program.Form1.label9.Text = $"Aguardando Conexão...").Invoke();
            Program.Form1.WriteSender("Desconectado.", Color.Red);
            player.GameClient.socket.Shutdown(SocketShutdown.Both);
            player.GameClient.socket.BeginDisconnect(true, (result) =>
            player.GameClient.socket.EndDisconnect(result), player.GameClient.socket);
            player.GameClient.socket.Disconnect(true);
            player.GameClient.socket.Close();
            player = null;
        }
    }
}

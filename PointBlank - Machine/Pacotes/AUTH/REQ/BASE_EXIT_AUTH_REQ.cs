using System;
using System.Drawing;
using System.Net.Sockets;

namespace PointBlank___Machine
{
    public class BASE_EXIT_AUTH_REQ : PacketREQ
    {
        public override void Avoid()
        {
            new Action(() => Program.Form1.label9.Location = new Point(124, 19)).Invoke();
            new Action(() => Program.Form1.label9.Text = $"Aguardando Conexão...").Invoke();
            Program.Form1.WriteSender("Desconectado.", Color.Red);
            player.AuthClient.socket.Shutdown(SocketShutdown.Both);
            player.AuthClient.socket.BeginDisconnect(true, (result) =>
            player.AuthClient.socket.EndDisconnect(result), player.AuthClient.socket);
            player.AuthClient.socket.Disconnect(false);
            player.AuthClient.socket.Close();
            player = null;
        }
    }
}

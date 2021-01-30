using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PointBlank___Machine
{
    public class Conexão
    {
        public volatile Player player;
        public IPEndPoint remote = null;
        public Socket socket = null;
        public Carregar Carregar = Carregar.INTs();
        public void SyncronizeAuthLocation()
        {
            try
            {
                remote = new IPEndPoint(IPAddress.Parse(Carregar.IP), 39190);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(remote);
                if (socket.Connected)
                {
                    LoggerConexão(remote);
                    player = new Player
                    {
                        AuthClient = new AuthClient(socket, PacotesREQ.INST().read)
                    };
                }
            }
            catch (Exception ex)
            {
                new _Message().Error(ex.ToString());
            }
        }
        public void SyncronizeGameLocation()
        {
            try
            {
                if (player.AuthClient != null)
                    BeginDisconnect(player.AuthClient.socket);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.BeginConnect(player.server, (result) =>
                {
                    socket.EndConnect(result);
                    if (socket.Connected)
                    {
                        LoggerConexão(player.server);
                        player.GameClient = new GameClient(socket, PacotesREQ.INST().read);
                    }
                }, socket);

            }
            catch (Exception ex)
            {
                new _Message().Error(ex.ToString());
            }
        }
        public void BeginDisconnect(Socket socket)
        {
            try
            {
                if (socket != null)
                {
                    socket.BeginDisconnect(false, (result) =>
                    {
                        try
                        {
                            socket.EndDisconnect(result);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    },
                    socket);
                    GC.SuppressFinalize(player.AuthClient);
                }
                player.AuthClient = null;
            }
            catch (Exception ex)
            {
                new _Message().Error(ex.ToString());
            }
            finally
            {
                try
                {
                    if (socket != null)
                    {
                        socket.Disconnect(false);
                        socket.Shutdown(SocketShutdown.Both);
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }
        public void CloseSyncronizeLocation()
        {
            try
            {
                if (player != null || socket != null && socket.Connected)
                {
                    if (player.AuthClient != null)
                        player.AuthClient.SendPacket(new BASE_EXIT_AUTH_ACK().Write());
                    else if (player.GameClient != null)
                        player.GameClient.SendPacket(new BASE_EXIT_GAME_ACK().Write());
                    Thread.Sleep(10);
                }
                else
                    Program.Form1.WriteSender("Você não possuí uma conexão!", Color.Yellow);
            }
            catch (SocketException ex)
            {
                new _Message().Error(ex.ToString());
            }
        }
        public void LoggerConexão(IPEndPoint conexão)
        {
            new Action(() => Program.Form1.label9.Location = new Point(49, 20)).Invoke();
            new Action(() => Program.Form1.label9.Text = $"Terminal de Conexão: {conexão}").Invoke();
        }
        static readonly Conexão conexão = new Conexão();
        public static Conexão INSTs() => conexão;
    }
}

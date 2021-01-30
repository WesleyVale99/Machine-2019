using System;
using System.Drawing;
using System.Net.Sockets;

namespace PointBlank___Machine
{
    public class GameClient
    {
        public volatile Socket socket;
        public PacketREQ pacotes;
        public GameClient(Socket socket, PacketREQ pacotes)
        {
            this.socket = socket;
            this.pacotes = pacotes;
            Dados.IniciarThead(Receive);
        }
        public void SendPacket(byte[] data)
        {
            try
            {
                if (socket != null && socket.Connected)
                {
                    SocketError error = SocketError.InProgress;
                    socket.BeginSend(data, 0, data.Length, SocketFlags.None, out error, (result) =>
                    {
                        try
                        {
                            if (result.IsCompleted)
                                socket.EndSend(result, out error);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    },
                    socket);
                    SocketMessage(error);
                }
                else
                {
                    SockerVerific(null);
                }
                data = null;
            }
            catch (Exception e)
            {
                new _Message().Error(e.ToString());
            }
        }
        public void Receive()
        {
            try
            {
                if (socket != null && socket.Connected && socket.Available >= 0)
                {
                    PacotesREQ pacotes = PacotesREQ.INST();
                    byte[] buffer = new byte[2];
                    SocketError error = SocketError.InProgress;
                    socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, out error, (result) =>
                    {
                        try
                        {
                            if (result.IsCompleted && socket.EndReceive(result, out error) >= 0)
                            {
                                buffer = new byte[BitConverter.ToUInt16(buffer, 0) + 2];
                                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, out error, (IAsyncResult) =>
                                {
                                    try
                                    {
                                        if (IAsyncResult.IsCompleted && socket.EndReceive(IAsyncResult, out error) >= 0)
                                        {
                                            PacotesREQ.INST().GetPacketGame(this, buffer);
                                            Dados.IniciarThead(Receive);

                                        }
                                        else
                                        {
                                            SockerVerific(null);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
                                    }
                                },
                                socket);
                            }
                            else
                            {
                                SockerVerific(null);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    },
                    socket);
                    SocketMessage(error);
                }
                else
                {
                    SockerVerific(null);
                }
            }
            catch (Exception e)
            {
                new _Message().Error(e.ToString());
            }
        }
        public void SockerVerific(Player p)  //VERIFICAÇÃO DO SOCKET
        {
            if (socket != null && !socket.Connected || socket == null)
                Program.Form1.WriteSender("Connexão Bloqueada!", Color.Red);
            else
                Program.Form1.WriteSender("Jogo Finalizado!", Color.Red);
            Conexão.INSTs().CloseSyncronizeLocation();
        }
        public void SocketMessage(SocketError error)
        {
            if (error != SocketError.Success)
            {
                new _Message().Error(error.ToString());
            }
        }
    }
}

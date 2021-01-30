using System.Drawing;
using System.Net;

namespace PointBlank___Machine
{
    public class GAME_BASE_SCHANNEL_LIST_REQ : PacketREQ
    {
        public override void Avoid()
        {
            int SessionID = ReadD();
            IPAddress addr = new IPAddress(ReadB(4));
            short shift = ReadU();
            Calculator.INST().seed = ReadU();
            ReadB(10);
            ReadC();
            int serverSize = ReadD();
            player.ADDR = IPAddress.Parse(Carregar.fakeIP).GetAddressBytes();
            player.Encrypt = ((SessionID + shift) % 7) + 1;
            Program.Form1.InforSender("Servidor autorizado: Game", false);
            for (int i = 0; i < serverSize; i++)
            {
                int actived = ReadD();
                IPAddress serverIp = new IPAddress(ReadB(4));
                ushort serverPort = ReadUH();
                Servers_Type serverType = (Servers_Type)ReadC();
                short serverMax = ReadU();
                int serverPlayers = ReadD();
                if (actived == 1 && i > 0)
                {
                    switch (serverType)
                    {
                        case Servers_Type.Server_Championship:
                            {
                                Program.Form1.WriteSender("Digite a senha do canal: ", Color.Yellow);
                                Program.Form1.Exceptions = Exceptions.Senha_Do_Canal;
                                break;
                            }
                        case Servers_Type.Server_Normal:
                            {
                                Program.Form1.InforSender($"Servidor Type {serverType}", false);
                                clientGame.SendPacket(new GAME_BASE_USER_ENTER_ACK().Write());
                                break;
                            }
                        default:
                            {
                                Program.Form1.InforSender($"Integridade do Servidor: {serverType}", false);
                                break;
                            }
                    }
                }
            }
        }
    }
}

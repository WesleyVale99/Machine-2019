using System.Net;

namespace PointBlank___Machine
{
    public class AUTH_BASE_SCHANNEL_LIST_REQ : PacketREQ
    {
        public override void Avoid()
        {
            int SessionID = ReadD();
            IPAddress addr = new IPAddress(ReadB(4));
            short shift = ReadU();
            Calculator.INST().seed = ReadU();
            ReadB(10); //contando Writes
            ReadC();
            int serverSize = ReadD();
            player.ADDR = IPAddress.Parse(Carregar.fakeIP).GetAddressBytes();
            player.Encrypt = ((SessionID + shift) % 7) + 1;
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
                    player.server = new IPEndPoint(serverIp, serverPort);
                    Program.Form1.InforSender($"GameServer:  {player.server}", false);
                    Program.Form1.InforSender($"Seed do Canal: {Calculator.INST().seed}", false);
                    Program.Form1.InforSender($"Tipo do servidor: {serverType}", false);
                    Program.Form1.InforSender($"Max de Jogadores: {serverMax}", false);
                    Program.Form1.InforSender($"Jogadores Online: {serverPlayers}", false);
                    AuthClient.SendPacket(new BASE_LOGIN_ACK().Write());
                    break;
                }
            }
        }
    }
}

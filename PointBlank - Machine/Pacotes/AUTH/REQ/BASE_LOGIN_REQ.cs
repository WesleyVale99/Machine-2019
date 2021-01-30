
using System;
using System.Drawing;

namespace PointBlank___Machine
{
    public class BASE_LOGIN_REQ : PacketREQ
    {
        public override void Avoid()
        {
            Login_Error result = (Login_Error)ReadD();
            ReadC();
            player.ID = ReadQ();
            string login = ReadS(ReadC());
            ReadC();
            ReadC();
            if (AuthClient != null)
            {
                switch (result)
                {
                    case Login_Error.LOGIN_SUCESSO: //CAIU?
                    case Login_Error.LOGIN_SUCESSO_ACEITO:
                        {
                            if (Program.Form1.classe_.BotLogin)
                                Program.Form1.label3.Text = $"Contas [{++Classe_.Contas}] sendo floodadas.";
                            AuthClient.SendPacket(new BASE_MYINFO_ACK().Write());
                            Program.Form1.WriteSender("Sucesso ao Logar!", Color.Green);
                            player.loggerUser = true;
                            break;
                        }
                    case Login_Error.LOGIN_BLOQUEADO_REGIÃO:
                        {
                            Classe_.PadraoRegion = 1;
                            Carregar.region = (Regions)Enum.ToObject(typeof(Regions), ++Classe_.PadraoRegion);
                            if (Classe_.PadraoRegion < 15)
                                Program.Form1.WriteSender("[RegionBlocked] Região foi alterada, tente novamente.", Color.Green);
                            else
                                Program.Form1.WriteSender("Limites de Região atingido.", Color.Red);
                            break;
                        }
                    case Login_Error.LOGIN_CLIENT_INCOMPATIVEL:
                        {
                            if (ClientRevision() < 4)
                                Program.Form1.WriteSender("[ClientError] Client foi alterada, tente novamente.", Color.Green);
                            else
                                Program.Form1.WriteSender("Limites de Client atingido.", Color.Red);
                            break;
                        }
                    case Login_Error.LOGIN_ERROR_CONFIG: //SERVER MSG ANNOUNCE
                        {
                            Program.Form1.WriteSender("Sua configuração de login está errada.", Color.Green);
                            break;
                        }
                    default: Program.Form1.WriteSender($"Erro ao logar: {result}", Color.Red); break;
                }

            }
        }
        public int ClientRevision()
        {
            if (Classe_.PadraoClient == 0)
                Carregar.CLIENTEVERSION = "1.15.36";
            if (Classe_.PadraoClient == 1)
                Carregar.CLIENTEVERSION = "1.15.37";
            else if (Classe_.PadraoClient == 2)
                Carregar.CLIENTEVERSION = "1.15.41";
            else if (Classe_.PadraoClient == 3)
                Carregar.CLIENTEVERSION = "1.15.42";
            else if (Classe_.PadraoClient == 4)
                Carregar.CLIENTEVERSION = "1.15.43";
            return ++Classe_.PadraoClient;
        }
    }
}

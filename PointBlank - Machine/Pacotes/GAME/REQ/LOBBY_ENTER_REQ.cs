using System;
using System.Drawing;

namespace PointBlank___Machine
{
    public class LOBBY_ENTER_REQ : PacketREQ
    {
        public override void Avoid()
        {
            if (reader.BaseStream.Length >= 4)
                ReadD();
            Program.Form1.InforSender("Entrou no Lobby.", false);
            Program.Form1.WriteSender("Você está no Lobby.", Color.Green);
            if (player.nick.Length == 0)
            {
                if (Program.Form1.classe_.Robô)
                    Conexão.INSTs().player.GameClient.SendPacket(new LOBBY_CREATE_NICK_NAME_ACK("PUBLICO" + new Random().Next(0, 100)).Write());
                else
                {
                    Program.Form1.WriteSender($"Digite um novo apelido: ", Color.Yellow);
                    Program.Form1.Exceptions = Exceptions.Novo_Nome;
                }
            }
            else
            {
                Program.Form1.InforSender($"nick: [{player.nick}]", false);
                Program.Form1.Exceptions = Exceptions.Chat;
            }
        }
    }
}

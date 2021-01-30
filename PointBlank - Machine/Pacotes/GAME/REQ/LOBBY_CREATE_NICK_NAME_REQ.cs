using System;
using System.Drawing;

namespace PointBlank___Machine
{
    public class LOBBY_CREATE_NICK_NAME_REQ : PacketREQ
    {
        public override void Avoid()
        {
            int error = ReadD();
            if (error == 0 || error == 1)
            {
                Program.Form1.InforSender($"Player ID:  {player.ID}", false);
                Program.Form1.InforSender($"Player Nick:  {player.nick}", false);
                Program.Form1.WriteSender($"Você está no lobby, Bate-Papo liberado...", Color.Green);
                Program.Form1.Exceptions = Exceptions.Chat;
                if (Program.Form1.classe_.Robô)
                {
                    switch (new Random().Next(0, 2))
                    {
                        case 0: player.GameClient.SendPacket(new LOBBY_CHATTING_ACK("Falhas Publicas", Chat_Type.LOBBY_CHAT_ALL).Write()); break;
                        case 1:
                            {
                                Sala sala = new Sala
                                { Nome = "Publico", senha = "", Mapa = 1, slots = 15 };
                                player.GameClient.SendPacket(new LOBBY_CREATE_ROOM_ACK(sala).Write());
                                break;
                            }
                    }
                }

            }
            else
            {
                Program.Form1.WriteSender($"Digite um novo apelido: ", Color.Yellow);
                Program.Form1.Exceptions = Exceptions.Novo_Nome;
            }
        }
    }
}

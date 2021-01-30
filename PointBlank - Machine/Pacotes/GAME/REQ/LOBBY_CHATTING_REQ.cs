using System;
using System.Drawing;

namespace PointBlank___Machine
{
    public class LOBBY_CHATTING_REQ : PacketREQ
    {
        public override void Avoid()
        {
            ReadB(4);
            string Nick = ReadS(ReadC());
            byte color = ReadC(); //Color
            NivelDeAcesso acesso = (NivelDeAcesso)ReadC();//Access
            string Message = ReadString(ReadU());
            if (Nick == player.nick)
            {
                Program.Form1.ChatSender($"➤ Me: [ {Nick} ] Mensagem: {Message}", "lobby");
                Program.Form1.WriteSender($"[Lobby] Mensagem Enviada. ", Color.Green);
            }
            else
            {
                if (!Program.Form1.classe_.Robô)
                    Console.Beep();
                Program.Form1.ChatSender($"↪ Player: [ {Nick} ] Mensagem: {Message} ", "lobby");
            }
        }
    }
}

using System.Drawing;

namespace PointBlank___Machine
{
    public class CLAN_CHATTING_REQ : PacketREQ
    {
        public override void Avoid()
        {
            int type = ReadC();
            if (type == 0)
            {
                string nick = ReadS(ReadC());
                ReadC();
                string Message = ReadS(ReadC());
                if (nick == player.nick)
                {
                    Program.Form1.ChatSender($"➤ Me: [ {nick} ] Messagem: {Message}", "clã");
                    Program.Form1.WriteSender($"[Clã] Mensagem Enviada.", Color.Green);
                }
                else
                    Program.Form1.ChatSender($"↪ Player: [ {nick} ] Messagem: {Message}", "clã");
            }
            else
            {
                Program.Form1.WriteSender($"Erro ao enviar. {type} ", Color.Red);
            }
        }
    }
}

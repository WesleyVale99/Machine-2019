namespace PointBlank___Machine
{
    public class SERVER_MESSAGE_ANNOUNCE_REQ : PacketREQ
    {
        public override void Avoid()
        {
            ReadB(4);
            Program.Form1.ChatSender($"Mensagem Geral: {ReadUS(ReadU())} \n", "lobby");
        }
    }
}

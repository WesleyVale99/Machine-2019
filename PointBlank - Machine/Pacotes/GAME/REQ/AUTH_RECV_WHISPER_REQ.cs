namespace PointBlank___Machine
{
    public class AUTH_RECV_WHISPER_REQ : PacketREQ
    {
        public override void Avoid()
        {
            string PlayerName = ReadS(33);
            ReadC();
            string mensagem = ReadS(ReadUH());
            Program.Form1.ChatSender($"Sussuro of {PlayerName}: {mensagem}", "s");
        }
    }
}

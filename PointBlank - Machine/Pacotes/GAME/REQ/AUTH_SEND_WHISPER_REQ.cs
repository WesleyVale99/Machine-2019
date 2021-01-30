namespace PointBlank___Machine
{
   public class AUTH_SEND_WHISPER_REQ : PacketREQ
    {
        public override void Avoid()
        {
            if (ReadD() == 0)
            {
                int error = ReadD();
                string name = ReadS(33);
                if(error == 0)
                    Program.Form1.ChatSender($"Sussuro to {name}: {ReadS(ReadUH())}", "sussurro");
                else
                    Program.Form1.ChatSender($"Error ao enviar sussuro. {error}", "sussurro");
            }
        }
    }
}

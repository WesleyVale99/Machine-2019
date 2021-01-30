namespace PointBlank___Machine
{
    public class AUTH_SEND_WHISPER_ACK : Processor
    {
        public string nomedoplayer, txt;
        public AUTH_SEND_WHISPER_ACK(string nomedoplayer, string txt) : base(290)
        {
            this.nomedoplayer = nomedoplayer;
            this.txt = txt;
        }
        public override byte[] Write()
        {
            send.WriteS(nomedoplayer, 33);
            send.WriteH((short)txt.Length);
            send.WriteS(txt, txt.Length);
            return Return();
        }
    }
}

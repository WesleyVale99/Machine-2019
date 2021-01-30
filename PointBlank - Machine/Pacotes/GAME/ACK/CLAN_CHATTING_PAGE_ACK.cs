namespace PointBlank___Machine
{
    public class CLAN_CHATTING_PAGE_ACK : Processor
    {
        public string Text = string.Empty;
        public CLAN_CHATTING_PAGE_ACK(string Text) : base(1390)
        {
            this.Text = Text;
        }
        public override byte[] Write()
        {
            send.WriteH(8);
            send.WriteH((short)Text.Length);
            send.WriteS(Text, Text.Length);
            return Return();
        }
    }
}

namespace PointBlank___Machine
{
    public class CLAN_CLIENT_CLAN_LIST_ACK : Processor
    {
        public ulong page;
        public CLAN_CLIENT_CLAN_LIST_ACK(ulong page) : base(1445)
        {
            this.page = page;
        }
        public override byte[] Write()
        {
            send.WriteQ(page);
            return Return();
        }
    }
}

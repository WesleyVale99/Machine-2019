namespace PointBlank___Machine
{
    public class CLAN_CREATE_ACK : Processor
    {
        public Clan clan;
        public CLAN_CREATE_ACK(Clan clan) : base(1310)
        {
            this.clan = clan;
        }
        public override byte[] Write()
        {
            send.WriteC((byte)clan.Nome.Length);
            send.WriteC((byte)clan.Info.Length);
            send.WriteC((byte)clan.Notice.Length);
            send.WriteS(clan.Nome, clan.Nome.Length);
            send.WriteS(clan.Info, clan.Info.Length);
            send.WriteS(clan.Notice, clan.Notice.Length);
            send.WriteD(0);
            return Return();
        }
    }
}

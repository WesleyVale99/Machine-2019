namespace PointBlank___Machine.Pacotes.GAME.ACK
{
    public class ROOM_INVITE_PLAYERS_ACK : Processor
    {
        public int count;
        public ulong ids;
        public ROOM_INVITE_PLAYERS_ACK(int count, ulong Ids) : base(3884)
        {
            this.count = count;
            ids = Ids;
        }
        public override byte[] Write()
        {
            send.WriteD(count);
            send.WriteQ(ids);
            return Return();
        }
    }
}

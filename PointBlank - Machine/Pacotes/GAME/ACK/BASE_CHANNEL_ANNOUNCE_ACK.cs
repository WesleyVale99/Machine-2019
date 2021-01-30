namespace PointBlank___Machine
{

    public class BASE_CHANNEL_ANNOUNCE_ACK : Processor
    {
        public int Canal;
        public BASE_CHANNEL_ANNOUNCE_ACK(int canal) : base(2573)
        {
            Canal = canal;
        }
        public override byte[] Write()
        {
            send.WriteD(Canal);
            return Return();
        }
    }
}

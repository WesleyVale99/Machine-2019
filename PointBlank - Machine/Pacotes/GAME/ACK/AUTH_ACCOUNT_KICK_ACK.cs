namespace PointBlank___Machine
{
    public class AUTH_ACCOUNT_KICK_ACK : Processor
    {
        public AUTH_ACCOUNT_KICK_ACK() : base(513)
        {

        }
        public override byte[] Write()
        {
            send.WriteC(0);
            return Return();
        }
    }
}

namespace PointBlank___Machine
{
    public class SHOP_GET_ACK : Processor
    {
        public SHOP_GET_ACK() : base(2821)
        {
        }
        public override byte[] Write()
        {
            send.WriteD(0);
            return Return();
        }
    }
}

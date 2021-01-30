namespace PointBlank___Machine
{
    public class BATTLE_LOADING_ACK : Processor
    {
        public BATTLE_LOADING_ACK() : base(3904)
        {

        }
        public override byte[] Write()
        {
            send.WriteS("", "".Length);
            return Return();
        }
    }
}

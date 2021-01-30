namespace PointBlank___Machine
{
    public class BOX_MESSAGE_CREATE_ACK : Processor
    {
        public Box box;
        public BOX_MESSAGE_CREATE_ACK(Box box) : base(417)
        {
            this.box = box;
        }
        public override byte[] Write()
        {
            send.WriteC((byte)box.name.Length);
            send.WriteC((byte)box.txt.Length);
            send.WriteS(box.name, box.name.Length);
            send.WriteS(box.txt, box.txt.Length);
            return Return();
        }
    }
}

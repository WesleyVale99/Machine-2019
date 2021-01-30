namespace PointBlank___Machine
{
    public class FRIEND_INVITE_ACK : Processor
    {
        public string friendname;
        public FRIEND_INVITE_ACK(string friendname) : base(282)
        {
            this.friendname = friendname;
        }
        public override byte[] Write()
        {
            send.WriteS(friendname, 33);
            return Return();
        }
    }
}

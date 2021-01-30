namespace PointBlank___Machine
{
    public class GAME_BASE_USER_ENTER_ACK : Processor
    {
        public GAME_BASE_USER_ENTER_ACK() : base(2579)
        {
        }
        public override byte[] Write()
        {
            send.WriteC((byte)(Carregar.USER.Length + 1));
            send.WriteS(Carregar.USER, Carregar.USER.Length + 1);
            send.WriteQ(player.ID);
            send.WriteC((byte)Carregar.CONNECTION);
            send.WriteB(player.ADDR);
            return Return();
        }
    }
}

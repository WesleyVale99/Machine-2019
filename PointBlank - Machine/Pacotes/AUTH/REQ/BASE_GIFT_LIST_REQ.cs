namespace PointBlank___Machine
{
    public class BASE_GIFT_LIST_REQ : PacketREQ
    {
        public override void Avoid()
        {
            int date = ReadD();
            ReadD();
            if (ReadD() == 0)
                player.AuthClient.SendPacket(new BASE_GIFTLIST_ACK().Write());
            Program.Form1.InforSender(date.ToString(), false);
        }
    }
}

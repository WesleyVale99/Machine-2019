namespace PointBlank___Machine
{
    public class BATTLE_STARTBATTLE_REQ : PacketREQ
    {
        public override void Avoid()
        {
            int isbattle = ReadD();
            if (isbattle == 1)
                player.GameClient.SendPacket(new BATTLE_LOADING_ACK().Write());
        }
    }
}

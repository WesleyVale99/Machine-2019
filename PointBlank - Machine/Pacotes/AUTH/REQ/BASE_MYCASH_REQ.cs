

namespace PointBlank___Machine
{
    public class BASE_MYCASH_REQ : PacketREQ
    {
        public override void Avoid()
        {
            ReadD();
            Program.Form1.InforSender($"[Gold: {ReadD()}; Cash: {ReadD()}]", false);
        }
    }
}

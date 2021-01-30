namespace PointBlank___Machine
{
    public class BASE_CLIENT_URL_REQ : PacketREQ
    {
        public override void Avoid()
        {
          if(ReadC() > 0)
            {
                ReadB(8);
                Program.Form1.InforSender($"Site: { ReadS(256) }", false);
            }
        }
    }
}

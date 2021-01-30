using System.Drawing;

namespace PointBlank___Machine
{
    public class BASE_ENTER_SERVER_REQ : PacketREQ
    {
        public override void Avoid()
        {
            if (ReadD() == 0)
            {
                Program.Form1.WriteSender($"{GetType().Name}", Color.White);
                Conexão.INSTs().SyncronizeGameLocation();
            }
        }
    }
}

using System.Drawing;

namespace PointBlank___Machine
{
    public class BASE_LOGIN_ERROR_REQ : PacketREQ
    {
        public override void Avoid()
        {
            ReadD();
            Login_Error error = (Login_Error)ReadD();
            ReadD();
            Program.Form1.WriteSender($"Error ao Logar: {error}", Color.Red);
        }
    }
}

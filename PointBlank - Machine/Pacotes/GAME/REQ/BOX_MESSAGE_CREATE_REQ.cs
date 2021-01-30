using System.Drawing;

namespace PointBlank___Machine
{
    public class BOX_MESSAGE_CREATE_REQ : PacketREQ
    {
        public override void Avoid()
        {
            if (ReadD() == 0)
                Program.Form1.WriteSender("Box de mensagem enviado com sucesso.", Color.Green);
            else
                Program.Form1.WriteSender("Error ao enviar um box de mensagem.", Color.Red);
        }
    }
}

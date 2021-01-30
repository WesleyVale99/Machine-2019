using System.Drawing;

namespace PointBlank___Machine
{
    public class FRIEND_UPDATE_REQ : PacketREQ
    {
        public override void Avoid()
        {
            int type = ReadC();
            ReadC();
            ReadS(ReadC());
            long idPlayer = ReadQ();
            switch (type)
            {
                case 1: Program.Form1.WriteSender($"foi adicionado com sucesso. {idPlayer}", Color.Green); break;
                case 2: Program.Form1.WriteSender($"foi Atualizado com sucesso. {idPlayer}", Color.Green); break;
            }
            Program.Form1.WriteSender($"Você está no lobby, Digite...", Color.Green);
            Program.Form1.Exceptions = Exceptions.Chat;
        }
    }
}

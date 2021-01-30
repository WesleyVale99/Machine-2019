using System.Drawing;

namespace PointBlank___Machine
{
    public class LOBBY_GET_ROOMLIST_REQ : PacketREQ
    {
        public override void Avoid()
        {
            int salas = ReadD();
            if (salas > 0)
            {
                ReadB(12);
                int id = ReadD();
                string Nome = ReadS(23);
                for (int room = 0; room <= salas; room++)
                    Program.Form1.InforSender($"Contagem [{room}] 'SalaID: {id}, Nome: {Nome}.", false);
                Program.Form1.WriteSender($"Contém [{salas} salas no lobby]", Color.Green);
            }
            else
            {
                Program.Form1.WriteSender($"Não contém sala no lobby. {salas}", Color.Red);
            }
        }
    }
}

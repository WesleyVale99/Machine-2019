using System.Drawing;

namespace PointBlank___Machine
{
    public class FRIEND_INVITE_REQ : PacketREQ
    {
        public override void Avoid()
        {
            Enum_Amigos enum_Amigos = (Enum_Amigos)ReadD();
            if (enum_Amigos == Enum_Amigos.Friend_Sucess_0 || enum_Amigos == Enum_Amigos.Friend_Sucess_1)
                Program.Form1.WriteSender($"Adicionado com sucesso.", Color.Green);
            else
                Program.Form1.WriteSender($"Erro {enum_Amigos}", Color.Red);
            Program.Form1.Exceptions = Exceptions.Chat;
        }
    }
}

using System.Drawing;

namespace PointBlank___Machine
{
    public class LOBBY_USER_LIST_REQ : PacketREQ
    {
        public override void Avoid()
        {
            Program.Form1.InforSender($"=============================================", false);
            int player = ReadD();
            if (player > 1)
            {
                for (int i = 0; i < player; i++)
                {
                    int sessionid = ReadD();
                    int Rank = ReadD();
                    string name = ReadS(ReadC());
                    Program.Form1.InforSender($"[{name}] sessionid: {sessionid}, Rank: {Rank}", false);
                }
            }
            Program.Form1.WriteSender($"Foi Gerado [ {player} ] no lobby. ", Color.Yellow);
            Program.Form1.InforSender($"=============================================", false);
        }
    }
}

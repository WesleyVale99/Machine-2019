using System.Drawing;

namespace PointBlank___Machine
{
    public class CLAN_CREATE_REQ : PacketREQ
    {
        public override void Avoid()
        {
            if (ReadD() == 0)
            {
                player.ClanID = ReadD();
                string ClanName = ReadS(17);
                ReadB(3);
                int DateNow = ReadD();
                ReadB(56);
                string Infoname = ReadS(255);
                Program.Form1.WriteSender("Clã criado com sucesso.", Color.Green);
                new _Message().Info($"ID: {player.ClanID}, Nome: {ClanName}, DateNow: {DateNow}, Info: {Infoname}");
            }
            else
                Program.Form1.WriteSender("Error ao criar clã.", Color.Red);
        }
    }
}

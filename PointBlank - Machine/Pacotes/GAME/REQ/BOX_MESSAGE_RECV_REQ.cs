namespace PointBlank___Machine
{
    public class BOX_MESSAGE_RECV_REQ : PacketREQ
    {
        public override void Avoid()
        {
            ReadB(12);
            int type = ReadC();
            ReadB(2);
            ReadD();
            byte LenghtName = ReadC();
            ReadC();
            string sender_name = ReadS(LenghtName);
            string sender_txt = ReadString(ReadC());
            Program.Form1.InforSender($"BoxMsg of {sender_name}: {sender_txt}", false);
        }
    }
}

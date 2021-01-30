namespace PointBlank___Machine
{
    public class LOBBY_CREATE_NICK_NAME_ACK : Processor
    {
        public LOBBY_CREATE_NICK_NAME_ACK(string apelido) : base(3101)
        {
            player.nick = apelido;
        }
        public override byte[] Write()
        {
            send.WriteC((byte)(player.nick.Length + 1));
            send.WriteS(player.nick, player.nick.Length + 1);
            return Return();
        }
    }
}

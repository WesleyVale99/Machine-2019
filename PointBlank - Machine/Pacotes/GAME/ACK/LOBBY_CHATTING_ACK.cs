namespace PointBlank___Machine
{
    public class LOBBY_CHATTING_ACK : Processor
    {
        protected string Mensagem;
        public Chat_Type Chat;
        public LOBBY_CHATTING_ACK(string Mensagem, Chat_Type Chat) : base(2627)
        {
            this.Mensagem = Mensagem;
            this.Chat = Chat;
        }
        public override byte[] Write()
        {
            send.WriteH((short)Chat); //CHATTING_TYPE_ALL
            send.WriteH((short)Mensagem.Length);
            send.WriteS(Mensagem, Mensagem.Length);
            return Return();
        }
    }
}

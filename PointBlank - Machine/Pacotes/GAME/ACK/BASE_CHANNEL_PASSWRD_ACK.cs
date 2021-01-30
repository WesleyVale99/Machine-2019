namespace PointBlank___Machine
{
    public class BASE_CHANNEL_PASSWRD_ACK : Processor
    {
        public string Texto;
        public BASE_CHANNEL_PASSWRD_ACK(string texto) : base(2644)
        {
            Texto = texto;
        }
        public override byte[] Write()
        {

            send.WriteC((byte)Texto.Length);
            send.WriteS(Texto, Texto.Length);
            return Return();
        }
    }
}

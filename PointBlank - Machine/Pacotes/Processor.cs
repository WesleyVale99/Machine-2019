using System;
using System.Drawing;

namespace PointBlank___Machine
{
    public abstract class Processor : SendPacket
    {
        public SendPacket send = new SendPacket();
        public SendPacket BeginSend = new SendPacket();
        public SendPacket receive = new SendPacket();
        public Player player;
        public ushort opcode;
        public Carregar Carregar;
        public Processor(ushort opcode)
        {
            this.opcode = opcode;
            player = Conexão.INSTs().player;
            Carregar = Carregar.INTs();
        }
        public abstract byte[] Write();
        public byte[] Return()
        {
            try
            {
                BeginSend.WriteH(opcode);
                BeginSend.WriteH((short)Calculator.INST().GetNextSessionSeed());
                BeginSend.WriteB(send.stream.ToArray());

                byte[] data = Dados.Encrypt(BeginSend.stream.ToArray(), player.Encrypt); // Encrypt

                receive.WriteH((ushort)(data.Length - 2 | 32768)); //0x8000
                receive.WriteB(data);
                new Action(() => Program.Form1.WriteSender($"{GetType().Name}", Color.White)).Invoke();

                return receive.stream.ToArray();
            }
            catch (Exception ex)
            {
                new _Message().Error(ex.ToString());
                return null;
            }
            finally
            {
                receive.Close();
                BeginSend.Close();
                send.Close();
            }
        }
    }
}

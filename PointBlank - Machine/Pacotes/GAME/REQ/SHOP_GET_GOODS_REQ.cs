using System;
using System.Threading;

namespace PointBlank___Machine
{
    public class SHOP_GET_GOODS_REQ : PacketREQ
    {
        public override void Avoid()
        {
            Shop.Good = ReadD();
            int count = ReadD();
            ReadD();
            lock (this)
            {
                for (int i = 0; i < count; i++)
                {
                    int objid = ReadD();
                    ReadC();
                    string visivel = ReadC() == 4 ? "Vip" : "normal";
                    new Action(() =>
                       Program.Form1.Loja.listBox1.Items.Add($"[Good] id: {  objid } | Visivel: { visivel }")
                     ).Invoke();
                    ReadB(9);
                    Thread.Sleep(25);
                }
            }
            int pagina = ReadD();
            // Program.Form1.WriteSender($"Loja Atualizada. {pagina}, total: {total}", Color.Green);
        }
    }
}

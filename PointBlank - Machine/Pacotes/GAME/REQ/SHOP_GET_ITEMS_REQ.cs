using System;
using System.Threading;

namespace PointBlank___Machine
{
    public class SHOP_GET_ITEMS_REQ : PacketREQ
    {
        public override void Avoid()
        {
            Shop.Item = ReadD();
            int count = ReadD();
            ReadD();
            lock (this)
            {
                for (int i = 0; i < count; i++)
                {
                    int itemId = ReadD();
                    string buytype = ReadC() == 1 ? "Gold" : "Cash";
                    ReadB(2);
                    int title = ReadC();
                    new Action(() =>
                       Program.Form1.Loja.listBox2.Items.Add($"[items] id: { itemId } | type: {buytype} | title: {title}")
                       ).Invoke();
                    Thread.Sleep(25);
                }
            }
            int pagina = ReadD();
            //  Program.Form1.WriteSender($"Loja Atualizada. {pagina}, total: {total}", Color.Green);
        }
    }
}

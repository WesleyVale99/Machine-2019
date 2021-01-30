using System;
using System.Drawing;
using System.Threading;

namespace PointBlank___Machine
{
    public class SHOP_GET_MATCHING_REQ : PacketREQ
    {
        public override void Avoid()
        {
            int DayeUn = 0;
            Shop.Match = ReadD();
            int count = ReadD();
            ReadD();
            lock (this)
            {
                for (int i = 0; i < count; i++)
                {
                    int obid = ReadD();
                    int itemid = ReadD();
                    int minutes = ReadD();
                    if (minutes > 500) //Será que algum abestado vai criar um valor maior que 500 count? para as Unidades...
                        DayeUn = (minutes / 86400);
                    new Action(() =>
                      Program.Form1.Loja.listBox3.Items.Add($"[Match] objID: { obid }| id: {itemid}| D/U: {DayeUn}")
                      ).Invoke();

                    Thread.Sleep(25);
                }
            }
            int pagina = ReadD();
            Program.Form1.WriteSender($"Loja Atualizada.", Color.Green);
            new Action(() =>
                 Program.Form1.Loja.label1.Text = $"Item: [{ Shop.Item }], Good: [ { Shop.Good } ], Match: [{ Shop.Match }]"
                ).Invoke();
        }
    }
}


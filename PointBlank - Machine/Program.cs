using System;
using System.Windows.Forms;

namespace PointBlank___Machine
{
    public class Program
    {
        public static volatile Machine Form1;
        public static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(Form1 = new Machine());
            }
            catch
            {
                Environment.Exit(0);
            }
        }
    }
}

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PointBlank___Machine
{
    public partial class User : Form
    {
        public Carregar Carregar = Carregar.INTs();
        Player player = Conexão.INSTs().player;
        public User()
        {
            InitializeComponent();
            Config();
        }
        public void Config()
        {
            if (player != null && player.loggerUser)
            {
                label1.Text = ("Usuario: " + Carregar.USER);
                label2.Text = ("Senha: " + Carregar.PASS);
                label3.Text = ("LauncherKey: " + Carregar.KEY);
                label4.Text = ("ID: " + player.ID);
                label5.Text = ("Nick: " + player.nick);
                label6.Text = ("Rank: " + player.rank);
                label7.Text = ("acess: " + player.acess);
            }
        }
        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(player != null && player.loggerUser)
                {
                    using (FileStream fileStream = new FileStream(Application.StartupPath + @"\user"+player.ID+".txt", FileMode.CreateNew))
                    using (StreamWriter stream = new StreamWriter(fileStream))
                    {
                        stream.Write("======================================");
                        stream.WriteLine();
                        stream.Write("Usuario: " + Carregar.USER);
                        stream.WriteLine();
                        stream.Write("Senha: " + Carregar.PASS);
                        stream.WriteLine();
                        stream.Write("LauncherKey: " + Carregar.KEY);
                        stream.WriteLine();
                        stream.Write("ID: " + player.ID);
                        stream.WriteLine();
                        stream.Write("Nick: " + player.nick);
                        stream.WriteLine();
                        stream.Write("Rank: " + player.rank);
                        stream.WriteLine();
                        stream.Write("acess: " + player.acess);
                        stream.WriteLine();
                        stream.Write("======================================");
                        stream.WriteLine();
                        stream.Write("by: Wesley vale. ");
                        stream.Close();
                        fileStream.Close();
                        Close();
                    }
                }
                else
                {
                    new _Message().Info("Você precisa tentar se registrar!");
                }
            }
            catch (Exception ex)
            {
                new _Message().Error(ex.ToString());
            }
        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #region User32
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_LBUTTONDOWN)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
    }
}

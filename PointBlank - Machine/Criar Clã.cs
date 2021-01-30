using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PointBlank___Machine
{
    public partial class Criar_Clã : Form
    {
        public Criar_Clã()
        {
            InitializeComponent();
        }
        #region user32.dll       
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Fechar?", "Machine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Player player = Conexão.INSTs().player;
            Clan clan = new Clan
            {
                Nome = textBox3.Text,
                Info = textBox2.Text,
                Notice = textBox1.Text
            };
            if (player != null)
                player.GameClient.SendPacket(new CLAN_CREATE_ACK(clan).Write());
            else
                Program.Form1.WriteSender("Você precisa está logado.", Color.Red);
            Close();
        }
    }
}

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PointBlank___Machine
{
    public partial class Robô_Lobby : Form
    {
        public Carregar Carregar = Carregar.INTs();
        public bool stop = true;
        public int sizevalue = 0;
        public Robô_Lobby()
        {
            InitializeComponent();
            button1.Enabled = false;
        }
        #region Buttons
        private void Button1_Click(object sender, EventArgs e)
        {
            stop = false;
            label1.ForeColor = Color.Yellow;
            label1.Text = "Aguardando...";
            label2.Text = $"Robôs: 0";
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja finalizar esse função?", "Machine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.Form1.classe_.Robô = false;
                stop = false;
                Close();
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (Conexão.INSTs().player != null)
                Conexão.INSTs().CloseSyncronizeLocation();
            Thread.Sleep(100);
            Program.Form1.classe_.Robô = true;
            button1.Enabled = true;
            new Thread(new ThreadStart(RoboLobby)).Start();
            Application.DoEvents();
        }
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            sizevalue = trackBar1.Value / 2;
            label3.Text = string.Concat(sizevalue);
        }
        #endregion
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
        #region Comandos
        public void RoboLobby()
        {
            for (int i = 0; i <= 10000; i++)
            {
                if (!stop)
                    break;
                try
                {
                    string value = "ADMINACSS" + new Random().Next(0, 1000);
                    Carregar.USER = value;
                    Carregar.PASS = value;
                    Thread.Sleep(sizevalue);
                    Conexão.INSTs().SyncronizeAuthLocation();
                    label1.ForeColor = Color.Green;
                    label1.Text = "Você iniciou a função Robô...";
                    label2.Text = $"Robôs: {i}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    break;
                }
            }
            stop = true;
        }
        #endregion
    }
}

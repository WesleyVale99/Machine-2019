using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointBlank___Machine
{
    public partial class Room : Form
    {
        public Sala sala = new Sala();
        public Room()
        {
            InitializeComponent();
            Dados.IniciarThead(Ram);
            textBox3.Enabled = false;
            Dados.IniciarThead(BloquearInicio);
        }
        #region Inicio
        public async void Ram()
        {
            while (true)
            {
                Application.DoEvents();
                label9.Text = $"{GC.GetTotalMemory(true) / 4024 } KB";
                await Task.Delay(1000);
            }
        }

        public void EnabledAll()
        {
            textBox4.Enabled = false;
            groupBox3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
        }

        public void BloquearInicio()
        {
            textBox4.Enabled = false;
            groupBox3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
        }
        #endregion
        #region Buttons
        private void Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você deseja Finalizar?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (sala != null)
                    Conexão.INSTs().player.GameClient.SendPacket(new LOBBY_ENTER_ACK().Write());
                Close();
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Dados.IniciarThead(CriaçãoDASala);
            }
            catch (Exception ex)
            {
                new _Message().Error(ex.ToString());
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Player player = Conexão.INSTs().player;
            if (player != null)
            {
                //player.GameClient.SendPacket(new BATTLE_STARTBATTLE_ACK().Write());
                player.GameClient.SendPacket(new BATTLE_READYBATTLE_ACK().Write());
            }
        }
        private void Button7_Click(object sender, EventArgs e)
        {

            Player player = Conexão.INSTs().player;
            if (player != null)
                player.GameClient.SendPacket(new LOBBY_ENTER_ACK().Write());
            Close();
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            try
            {
                Dados.IniciarThead(FlodarSala);
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                new _Message().Error(ex.ToString());
            }

        }
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            label6.Text = string.Concat(trackBar1.Value);
        }
        #endregion
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
        #region Sala
        public void CriaçãoDASala()
        {
            sala.Nome = textBox1.Text;
            sala.senha = textBox2.Text;
            if (comboBox1.SelectedIndex == 9)
                sala.Mapa = 5000;
            else
                sala.Mapa = (short)comboBox1.SelectedIndex;
            sala.slots = (byte)trackBar1.Value;
            Player player = Conexão.INSTs().player;
            if (player != null)
                player.GameClient.SendPacket(new LOBBY_CREATE_ROOM_ACK(sala).Write());
            // new _Message().Info($"Nome: { sala.Nome } Mapa: { sala.Mapa } sala.slots: { sala.slots }");
        }
        public void FlodarSala()
        {
            for (int i = 0; i < 10; i++)
            {
                sala.Nome = textBox1.Text;
                sala.senha = textBox2.Text;
                sala.Mapa = (short)comboBox1.SelectedIndex;
                sala.slots = (byte)trackBar1.Value;

                Player player = Conexão.INSTs().player;
                Thread.Sleep(100);
                if (player != null)
                {
                    player.GameClient.SendPacket(new LOBBY_CREATE_ROOM_ACK(sala).Write());
                    player.GameClient.SendPacket(new LOBBY_ENTER_ACK().Write());
                }
                label10.Text = $"Tentando Flodar {i} salas";
            }
        }
        #endregion
    }
}

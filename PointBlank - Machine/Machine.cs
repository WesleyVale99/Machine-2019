using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointBlank___Machine
{
    public partial class Machine : Form
    {
        public Exceptions Exceptions = Exceptions.Hibernar;
        public Chat_Type chat;
        public Classe_Raiz classe_ = Classe_Raiz.INTs();
        public Carregar carregar = Carregar.INTs();
        public Room room = null;
        public volatile Comandos Lobby;
        public volatile Loja Loja;
        public Machine()
        {
            InitializeComponent();
            Started();
            ArredondaCantosdoForm();
            Dados.IniciarThead(Ram);
            Dados.IniciarThead(ChannelSlider);
            Thread.Sleep(50);
            Dados.IniciarThead(Creditos);
            Application.DoEvents();
        }

        #region CONFIGURAÇÃO
        public void ChannelSlider()
        {
            new Thread(() =>
            {
                while (classe_.announce)
                {
                    Application.DoEvents();
                    label10.Location = new Point(label10.Location.X + 1, label10.Location.Y);
                    if (label10.Location.X >= listBox1.Width)
                        label10.Location = new Point(-label10.Text.Length * 9, label10.Location.Y);
                    Thread.Sleep(5);
                }
            }).Start();
        }
        public async void Ram()
        {
            while (true)
            {
                new Action(() => label4.Text = $"{GC.GetTotalMemory(true) / 4024 } KB").Invoke();
                await Task.Delay(1000);
                Application.DoEvents();
            }
        }
        public void Started()
        {
            carregar.Run();
            textBox3.Enabled = false;
            switch (carregar.region)
            {
                case Regions.Brazil: pictureBox1.Visible = true; break;
                case Regions.Turkey: pictureBox2.Visible = true; break;
            }
            switch (carregar.CONNECTION)
            {
                case Tipo_Conexão.LOCAL_HOST: pictureBox3.Visible = true; break;
                case Tipo_Conexão.VIRTUAL_HOST: pictureBox4.Visible = true; break;
            }
            if (!carregar.AutoCreate)
            {
                groupBox4.Visible = true;
                button4.Enabled = false;
                button3.Enabled = false;
                button5.Enabled = false;
            }
            label14.Text = carregar.CLIENTEVERSION;
        }
        public void Creditos()
        {
            //new _Message().Info("ઽiʍષℓαđѳ૨ đ૯ ℓѳgiท ૮ѳท૯×ãѳ ૮ℓi૯ทƬ૯ ρα૨α ઽ૯૨√iđѳ૨.  \n                 " +
            //    "вy: ખ૯ઽℓ૯y √αℓ૯ 2019.");
            //Process.Start("https://www.facebook.com/wesley.vale.3192");
        }
        public void ArredondaCantosdoForm()
        {
            using (GraphicsPath PastaGrafica = new GraphicsPath())
            {
                PastaGrafica.AddRectangle(new Rectangle(1, 1, Size.Width, Size.Height));

                //Arredondar canto superior esquerdo        
                PastaGrafica.AddRectangle(new Rectangle(1, 1, 10, 10));
                PastaGrafica.AddPie(1, 1, 20, 20, 180, 90);

                //Arredondar canto superior direito
                PastaGrafica.AddRectangle(new Rectangle(Width - 12, 1, 12, 13));
                PastaGrafica.AddPie(Width - 24, 1, 24, 26, 270, 90);

                //Arredondar canto inferior esquerdo
                PastaGrafica.AddRectangle(new Rectangle(1, Height - 10, 10, 10));
                PastaGrafica.AddPie(1, Height - 20, 20, 20, 90, 90);

                //Arredondar canto inferior direito
                PastaGrafica.AddRectangle(new Rectangle(Width - 12, Height - 13, 13, 13));
                PastaGrafica.AddPie(Width - 24, Height - 26, 24, 26, 0, 90);

                PastaGrafica.SetMarkers();
                Region = new Region(PastaGrafica);
            }
        }
        private void Machine_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "Fechar");
            toolTip1.SetToolTip(button2, "Minimizar");
            toolTip1.SetToolTip(button3, "Iniciar o login!");
            toolTip1.SetToolTip(button4, "Fininalizar sua conexão com o servidor.");
            toolTip1.SetToolTip(button5, "Comandos para usar, no servidor...");
            toolTip1.SetToolTip(button6, "Criar uma conta manual.");
            toolTip1.SetToolTip(button7, "Duvidas???");
            toolTip1.SetToolTip(button8, "Ver informações detalhadas sobre o servidor, 'ID' 'Cash' e dados.");
            toolTip1.SetToolTip(button12, "Reiniciar o machine para novas configurações.");
            toolTip1.SetToolTip(button11, "Enviar Mensagem...");
            toolTip1.SetToolTip(groupBox2, "Verificar seu percentual de memoria consumida.");
            toolTip1.SetToolTip(label16, "Desenvolvido por Wesley vale.");
        }

        #endregion
        #region Textos
        public void WriteSender(string texto, Color color)
        {

            if (!string.IsNullOrEmpty(texto))
            {
                new Action(() => label2.ForeColor = color).Invoke();
                new Action(() => label2.Text = texto).Invoke();
            }
        }
        public void InforSender(string texto, bool clear)
        {
            if (clear)
            {
                textBox3.Clear();
            }
            else if (!string.IsNullOrEmpty(texto))
            {
                textBox3.AppendText(texto);
                textBox3.AppendText(Environment.NewLine);
            }
            else
            {
                texto = string.Empty;
                textBox3.Text = string.Empty;
            }
        }
        public void ChatSender(string texto, string lobby)
        {
            if (!string.IsNullOrEmpty(texto))
            {
                switch (lobby)
                {
                    case "lobby": new Action(() => listBox1.Items.Add($"Lobby: {texto}")).Invoke(); break;
                    case "clã":   new Action(() => listBox1.Items.Add($"Clã: {texto}")).Invoke(); break;
                    case "sussurro": new Action(() => listBox1.Items.Add($"Sussurro: texto")).Invoke(); break;
                }

            }
        }
        public void PreFlod()
        {
            button9.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
        }
        public void PosFlod()
        {
            Refresh();
            classe_.flag = false;
            button9.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button9.Visible = false;
            textBox2.Text = "";
            WriteSender(string.Empty, Color.Yellow);
            Conexão.INSTs().CloseSyncronizeLocation();
        }
        private void Digite_KeyPress(object sender, KeyPressEventArgs e)
        {
            Player p = Conexão.INSTs().player;
            if (p != null)
            {
                if ((Keys)e.KeyChar == Keys.Enter)
                {
                    if (textBox2.Text.ToLower() == ("/clear"))
                    {
                        listBox1.Items.Clear();
                        textBox2.Clear();
                        listBox1.Items.Add("[Sistema] Bate Papo foi limpo.");
                    }
                    else if (textBox2.Text.StartsWith("/w "))
                    {
                        listBox1.Items.Add("[Sistema] Você está em modo Sussuro.");
                        classe_.sussuro = textBox2.Text.Substring(3).Split(' ');
                        classe_.sussurro = true;
                    }
                    switch (Exceptions)
                    {
                        case Exceptions.Senha_Do_Canal:
                            {
                                if (textBox2.Text.Length <= 4)
                                {
                                    p.GameClient.SendPacket(new BASE_CHANNEL_PASSWRD_ACK(textBox2.Text).Write());
                                    break;
                                }
                                else
                                {
                                    WriteSender("a senha só pode ser até 4 letras ou numeros.", Color.Red);
                                    break;
                                }
                            }
                        case Exceptions.Novo_Nome:
                            {
                                if (textBox2.Text.Length <= 23)
                                {
                                    p.GameClient.SendPacket(new LOBBY_CREATE_NICK_NAME_ACK(textBox2.Text).Write());
                                    break;
                                }
                                else
                                {
                                    WriteSender("Nick tem que ser menor que 23 length", Color.Red);
                                    break;
                                }
                            }
                        case Exceptions.Mundança_de_Canal:
                            {

                                try
                                {
                                    int channelid = int.Parse(textBox2.Text);
                                    if (channelid >= 1 && channelid <= 10)
                                    {
                                        p.GameClient.SendPacket(new BASE_CHANNEL_ANNOUNCE_ACK(channelid - 1).Write());
                                        break;
                                    }
                                    else
                                    {
                                        WriteSender("Limites de canal é 1 até 10.", Color.Red);
                                        break;
                                    }
                                }
                                catch
                                {
                                    new _Message().Info("o canal está com a cadeia de caracteres em um formato incorreto.");
                                }
                                break;

                            }
                        case Exceptions.Chat:
                            {
                                if (chat == Chat_Type.LOBBY_CHAT_ALL)
                                    p.GameClient.SendPacket(new LOBBY_CHATTING_ACK(textBox2.Text, chat).Write());
                                else if (chat == Chat_Type.LOBBY_CHAT_CLAN)
                                {
                                    if (p.ClanID > 0)
                                        p.GameClient.SendPacket(new CLAN_CHATTING_ACK(chat, textBox2.Text).Write());
                                    else
                                        WriteSender("Você não possui um clã.", Color.Red);
                                }
                                else if (chat == Chat_Type.LOBBY_CHAT_WHISPER)
                                {
                                    if (classe_.sussurro)
                                        p.GameClient.SendPacket(new AUTH_SEND_WHISPER_ACK(classe_.sussuro[0], classe_.sussuro[1]).Write());
                                    else
                                        WriteSender("formato de sussurro incorreto.", Color.Red);
                                    classe_.sussurro = false;
                                }
                                else
                                    WriteSender("Selecione o campo de chat.", Color.Red);
                                break;
                            }
                        case Exceptions.AdicionarAmigos:
                            {
                                p.GameClient.SendPacket(new FRIEND_INVITE_ACK(textBox2.Text).Write());
                                break;
                            }
                        case Exceptions.flood:
                            {
                                if (!classe_.chatflood)
                                {
                                    classe_.chatflood = true;
                                    lock (this)
                                    {
                                        for (int i = 0; i <= 1000; i++)
                                        {
                                            //int opcode = new Random().Next(300, 5000);
                                            if (p != null)
                                            {
                                                //   p.GameClient.SendPacket(new CLAN_CHATTING_PAGE_ACK($".vv {opcode}").Write());
                                                //Program.Form1.WriteSender($"Pacote: {opcode}", Color.Yellow);
                                                Thread.Sleep(25);
                                                p.GameClient.SendPacket(new LOBBY_CHATTING_ACK($"{textBox2.Text} [{i}]", Chat_Type.LOBBY_CHAT_ALL).Write());
                                                Application.DoEvents();
                                            }
                                            else
                                            {
                                                WriteSender($"Você precisa está Online no jogo.", Color.Red);
                                                break;
                                            }
                                        }
                                    }
                                }
                                classe_.chatflood = false;
                                Exceptions = Exceptions.Chat;
                                break;
                            }
                        case Exceptions.Hibernar:
                            {
                                WriteSender("Seu API está em modo Hibernar.", Color.Red);
                                break;
                            }
                    }
                    textBox2.Clear();
                    textBox2.Text = "";
                    label7.Text = "0";
                }
            }
            else
            {
                WriteSender($"Você não está logado no jogo.", Color.Red);
                textBox2.Text = "";
                label7.Text = "0";
            }
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            label7.Text = string.Concat(textBox2.Text.Length);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 1: chat = Chat_Type.LOBBY_CHAT_ALL; break;
                case 2: chat = Chat_Type.LOBBY_CHAT_CLAN; break;
                case 3: chat = Chat_Type.LOBBY_CHAT_WHISPER; break;
            }
        }
        #endregion
        #region BUTTONS
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Você deseja Finalizar?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    classe_.announce = false;
                    classe_.flag = false;
                    Thread.ResetAbort();
                    Dados.IniciarThead(Conexão.INSTs().CloseSyncronizeLocation);
                    Process.GetProcessesByName("PointBlank - Machine")[0].Kill();
                    Close();
                }
            }
            catch
            {
                Process.GetProcessesByName("PointBlank - Machine")[0].Kill();
                Close();
            }


        }
        private void Button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            WriteSender("Aguarde tentando fazer login.", Color.Yellow);
            Dados.IniciarThead(Conexão.INSTs().SyncronizeAuthLocation);
        }
        public void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                new Thread(() =>
                {
                    label10.Text = "Esperando o Anuncio do canal...";
                    label15.Text = "0";
                    label13.Enabled = false;
                    button3.Enabled = true;
                    InforSender("", true);
                    listBox1.Items.Clear();
                    Calculator.INST().seed = 0;
                }).Start();
                Dados.IniciarThead(Conexão.INSTs().CloseSyncronizeLocation);
            }
            catch (Exception ex)
            {
                new _Message().Error(ex.ToString());
            }

        }
        private void Button5_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.Run(Lobby = new Comandos());
            }).Start();
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length >= 4 && textBox6.Text.Length >= 4)
            {
                carregar.USER = textBox5.Text;
                carregar.PASS = textBox6.Text;
                WriteSender("Você criou seu login e senha manual", Color.Yellow);
                groupBox4.Visible = false;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
            }
            else
            {
                WriteSender("Sua conta manual não pode ser nula!", Color.Red);
            }
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/wesley.vale.3192");
        }
        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            if (!classe_.guia)
                classe_.guia = true;
            else
                classe_.guia = false;
            if (!classe_.guia)
            {
                for (int i = 438; i > 0; i--)
                {
                    Application.DoEvents();
                    new Action(() =>
                    panel1.Size = new Size(596, i - 1)
                    ).Invoke();
                }
            }
            else
            {
                for (int i = 0; i < 438; i++)
                {
                    Application.DoEvents();
                    new Action(() =>
                    panel1.Size = new Size(596, i)
                    ).Invoke();
                }
            }
            button8.Enabled = true;
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            try
            {
                switch (MessageBox.Show("Você deseja parar?", Application.ProductName, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question))
                {
                    case DialogResult.Ignore: //IGNORAR
                        {
                            Dados.IniciarThead(PosFlod);
                            Close();
                            break;
                        }
                    case DialogResult.Abort: // ANULAR
                        {
                            Dados.IniciarThead(PosFlod);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Dados.IniciarThead(PosFlod);
                new _Message().Error(ex.ToString());
            }

        }
        private void Button11_Click(object sender, EventArgs e)
        {
            Digite_KeyPress(sender, new KeyPressEventArgs((char)13));
        }
        private void button12_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Application.ExitThread();
            carregar.Run();
        }
        #endregion
        #region Picture
        private void PictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/wesley.vale.3192");
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
        public void AccessAuth()
        {
            label3.Visible = true;
            classe_.BotLogin = true;
            for (int i = 0; i <= 1000; i++)
            {
                if (!classe_.flag)
                    break;
                try
                {
                    carregar.USER = "XuaXua" + new Random().Next(0, 1000);
                    carregar.PASS = "PuaPua" + new Random().Next(0, 1000);
                    Application.DoEvents();
                    Conexão.INSTs().SyncronizeAuthLocation();
                }
                catch (Exception ex)
                {
                    new _Message().Error(ex.ToString());
                    break;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.Run(new User());
            }).Start();
        }
    }
}

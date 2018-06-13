namespace WebDevChatRoom_Intec
{
    using System;
    using System.Windows.Forms;
    using System.Net.Sockets;
    using System.Text;
    using Newtonsoft.Json;

    public partial class Form1 : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream;
        private string ServerAddress = String.Empty;
        private int PortNumber = 0;
        private string Message = String.Empty;
        private string Username = String.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void msg(string mesg)
        {
            listview_chat.Items.Add(mesg);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ServerAddress = (txtServer.Text == String.Empty) ? null:txtServer.Text;
            PortNumber = (txtPort.Text == String.Empty) ? 0:Convert.ToInt16(txtPort.Text);

            if(ServerAddress!= null && PortNumber != 0)
            {
                if (clientSocket.Connected)
                {
                    MessageBox.Show($"El Usuario {Username} ya esta cconectado al servidor: {txtServer.Text}, Puerto: {txtPort.Text}");
                    return;
                }

                clientSocket.Connect(ServerAddress,PortNumber);
                msg("Client - Server Connected ...");
            }
            else
            {
                MessageBox.Show("Please insert Server Address and Port Number before connecting to the server.");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Message = (txtInput.Text == String.Empty) ? null : txtInput.Text;

            if(Message != null)
            {
                NetworkStream serverStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(Message);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, (int) clientSocket.ReceiveBufferSize);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            msg(String.Format(">>{0}: {1}", Username, returndata));
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            msg("Client Started");
            txtServer.Text = "127.0.0.1";
            txtPort.Text = "8889";
            txtUsername.Text = "Ricardo";
        }
    }
}

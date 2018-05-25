namespace WebDevChatRoom_Intec
{
    using System;
    using System.Windows.Forms;
    using System.Net.Sockets;
    using System.Text;
    using Newtonsoft.Json;
    using System.Threading;

    public partial class Form1 : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream;
        private string ServerAddress = String.Empty;
        private int PortNumber = 0;
        private string Message = String.Empty;
        private string Username = String.Empty;
        private string readData;

        public Form1()
        {
            InitializeComponent();
            txtPort.Text = "8888";
            //txtServer.Text = "10.12.3.35";
            //Username = txtUsername.Text = "Dsalas";
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            msg("Client Started");
        }

        public void msg(string mesg)
        {
            listview_chat.Text += "\n"+ mesg;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ServerAddress = (txtServer.Text == String.Empty) ? null:txtServer.Text;
            PortNumber = (txtPort.Text == String.Empty) ? 0:Convert.ToInt16(txtPort.Text);
            Username = (txtServer.Text == String.Empty) ? null : txtUsername.Text;

            if (ServerAddress!= null && PortNumber != 0 && Username != String.Empty)
            {
                clientSocket.Connect(ServerAddress,PortNumber);
                msg("Client - Server Connected ...");

                Thread readThread = new Thread(ReadMessages);
                readThread.Start();
            }
            else
            {
                MessageBox.Show("Please insert Server Address and Port Number before connecting to the server.");
            }
        }

        private void ReadMessages()
        {
            while(true)
            {
                serverStream = clientSocket.GetStream();
                int buffSize = 0;
                byte[] inStream = new byte[100000];
                buffSize = clientSocket.ReceiveBufferSize;
                serverStream.Read(inStream, 0, buffSize);
                readData = System.Text.Encoding.ASCII.GetString(inStream);
                DisplayMessages();   
            }
        }

        private void DisplayMessages()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(DisplayMessages));
            }
            else
            {
                listview_chat.Text += "\n" + readData;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            User MessageUser = new User();
            Message = (txtInput.Text == String.Empty) ? null : txtInput.Text;
           
            

            if(Message != null)
            {
                MessageUser.Username = Username;
                MessageUser.Message = Message;
                Message = JsonConvert.SerializeObject(MessageUser);
                NetworkStream serverStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(Message);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
                //listview_chat.Text += Message;

            }
            txtInput.Text = String.Empty;
        }

    }
}

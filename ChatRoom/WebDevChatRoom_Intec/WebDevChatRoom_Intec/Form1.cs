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
		private bool ExitFlag = false;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			msg(">> Client Started <<");
		}

		public void msg(string mesg)
		{
			listview_chat.AppendText(mesg);
			listview_chat.AppendText(Environment.NewLine);
			listview_chat.AppendText(Environment.NewLine);
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			ServerAddress = (txtServer.Text == String.Empty) ? null : txtServer.Text;
			PortNumber = (txtPort.Text == String.Empty) ? 0 : Convert.ToInt16(txtPort.Text);
			Username = (txtServer.Text == String.Empty) ? null : txtUsername.Text;

			if (ServerAddress != null && PortNumber != 0 && Username != String.Empty)
			{
				clientSocket.Connect(ServerAddress, PortNumber);
				msg(">> Connected to Chat Server <<");

				listViewUsers.Items.Add(Username);
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
			try
			{
				while (!ExitFlag)
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
			catch
			{

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
				listview_chat.AppendText(readData);
				listview_chat.AppendText(Environment.NewLine);
				listview_chat.AppendText(Environment.NewLine);
			}
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			User MessageUser = new User();
			Message = (txtInput.Text == String.Empty) ? null : txtInput.Text;

			if (Message != null)
			{
				MessageUser.Username = Username;
				MessageUser.Message = Message;
				Message = JsonConvert.SerializeObject(MessageUser);
				NetworkStream serverStream = clientSocket.GetStream();
				byte[] outStream = System.Text.Encoding.ASCII.GetBytes(Message);
				serverStream.Write(outStream, 0, outStream.Length);
				serverStream.Flush();
			}

			txtInput.Text = String.Empty;
		}

		private void listViewUsers_SelectedIndexChanged(object sender, EventArgs e)
		{

			var item = sender as ListView;
			string oldvalue = item.Items[0].Text;
			item.Items[0].Text = Username;

		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			ExitFlag = true;
			clientSocket.GetStream().Close();
			msg(">> Client - Server Disconnected <<");
		}

	}
}

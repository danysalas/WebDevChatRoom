using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using Newtonsoft.Json;
using System.Net;

namespace ChatServer
{
    class Program
    {
        public static Hashtable clientsList = new Hashtable();
        public static Socket _socket;
        public static byte[] _buffer =new byte[1024];
        public static string dataFromClient = null;

        static void Main(string[] args)
        {
                
         _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

         _socket.Bind(new IPEndPoint(IPAddress.Any,8889));

         _socket.Listen(500);

         _socket.BeginAccept(AcceptedCallBack, null);
         

         Console.WriteLine(" Server started ");
         Console.ReadLine();
        }
        public static void Accept()
        {

            _socket.BeginAccept(AcceptedCallBack, null);
        }

        public static void AcceptedCallBack(IAsyncResult result)
        {

            Socket CLientSocket = _socket.EndAccept(result);   
            _buffer= new byte[1024];
            CLientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallBack, CLientSocket);
            Accept();
        }

        public static void ReceiveCallBack(IAsyncResult result)
        {
            Socket clientSocket = result.AsyncState as Socket;
            int buffersize = clientSocket.EndReceive(result);
            byte[] packet = new byte[buffersize];
            Array.Copy(_buffer, packet, packet.Length);


            dataFromClient = System.Text.Encoding.ASCII.GetString(packet);

            Console.WriteLine();

            var userMessage = JsonConvert.DeserializeObject<User>(dataFromClient);
            
            if (!userMessage.Equals(null)  || userMessage.ToString()=="null" )
       

            Console.WriteLine(userMessage.UserName + " Joined chat room ");

            Console.WriteLine("Message from - " + userMessage.UserName + " : " + userMessage.Message);


            // Handle the packet
            _buffer = new byte[1024];
            clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallBack, clientSocket);

        }

        public static void broadcast(string msg, string uName, bool flag)
        {
            foreach (DictionaryEntry Item in clientsList)
            {
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream();
                Byte[] broadcastBytes = null;

                if (flag == true)
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(uName + " : " + msg);
                }
                else
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(msg);
                }

                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
        } 
    }

   
}

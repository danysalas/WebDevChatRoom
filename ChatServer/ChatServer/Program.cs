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
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener( IPAddress.Parse("127.0.0.0"), 8888);
            TcpClient clientSocket = default(TcpClient);
            int counter = 0;

            try
            {
                serverSocket.Start();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
            
            Console.WriteLine("Chat Server Started ....");
            counter = 0;
            while ((true))
            {
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();

                byte[] bytesFrom = new byte[200000];
                string dataFromClient = null;

                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                var userMessage =  JsonConvert.DeserializeObject<User>(dataFromClient);
                clientsList.Add(userMessage.UserName, clientSocket);
                broadcast("<<<" + userMessage.UserName + " Joined >>>", userMessage.UserName, false);
				broadcast(userMessage.Message, userMessage.UserName, true);
				Console.WriteLine(userMessage.UserName + " Joined chat room ");
				Console.WriteLine("Message from - " + userMessage.UserName + " : " + userMessage.Message);
				ClientHandler client = new ClientHandler();
                client.startClient(clientSocket, userMessage.UserName, clientsList);
            }
            //clientSocket.Close();
            //serverSocket.Stop();
            Console.WriteLine("exit");
            Console.ReadLine();
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

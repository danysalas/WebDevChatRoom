using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using Newtonsoft.Json;

namespace ChatServer
{
    class Program
    {


        public static Hashtable clientsList = new Hashtable();
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(8888);
            TcpClient clientSocket = default(TcpClient);
            int counter = 0;

            serverSocket.Start();
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
                //dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                clientsList.Add(userMessage.UserName, clientSocket);

                broadcast(userMessage.UserName + " Joined ", userMessage.Message, false);

                Console.WriteLine(userMessage.UserName + " Joined chat room ");
                handleClinet client = new handleClinet();
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
        }  //end broadcast function
    }//end Main class

   
}

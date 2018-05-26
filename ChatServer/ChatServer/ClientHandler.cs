using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChatServer
{
    public class ClientHandler
    {
        TcpClient clientSocket;
        string clNo;
        Hashtable clientsList;

        public void startClient(TcpClient inClientSocket, string clineNo, Hashtable ClientList)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            this.clientsList = ClientList;
            Thread ClientThread = new Thread(doChat);
            ClientThread.Start();
        }

        private void doChat()
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[200000];
            string dataFromClient = null;
            Byte[] sendBytes = null;
            string serverResponse = null;
            string rCount = null;
            requestCount = 0;

            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    var userMessage = JsonConvert.DeserializeObject<User>(dataFromClient);

                    Console.WriteLine("Message from - " + userMessage.UserName + " : " + userMessage.Message);
                    rCount = Convert.ToString(requestCount);

                    Program.broadcast(userMessage.Message, userMessage.UserName, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally {
                    Array.Clear(bytesFrom, 0, bytesFrom.Length);
                    dataFromClient = string.Empty;
                }
            }
            
        }
    } 
}



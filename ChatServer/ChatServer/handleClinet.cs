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
    public class handleClinet
    {
        TcpClient clientSocket;
        string clNo;
        Hashtable clientsList;

        public void startClient(TcpClient inClientSocket, string clineNo, Hashtable cList)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            this.clientsList = cList;
            Thread ctThread = new Thread(doChat);
            ctThread.Start();
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

                    //dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    Console.WriteLine("From client - " + userMessage.UserName + " : " + userMessage.Message);
                    rCount = Convert.ToString(requestCount);

                    Program.broadcast(userMessage.Message, userMessage.UserName, true);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally {
                    Array.Clear(bytesFrom, 0, bytesFrom.Length);
                    //bytesFrom = new byte[0];
                    dataFromClient = string.Empty;

                }
            }//end while
            
        }//end doChat
    } //end class handleClinet
}//end namespace



using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebDevChatRoom_Intec
{
     public class ClientSocket
    {
        public static Socket _socket;
        public static byte[] _buffer =new byte[1024];        
        
        public static void Connect(string IP, int Port)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(IP),Port),ConnectCallBack,null);
        }
        public static void ConnectCallBack(IAsyncResult result)
        {
            Console.WriteLine(" Connected to the server ");
	        
            _buffer= new byte[1024];

            _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallBack, null);            
        }
        public static void ReceiveCallBack(IAsyncResult result)
        {
            if (_socket.Connected)
            {
                int bufferlength = _socket.EndReceive(result);
                byte[] packet = new byte[bufferlength];
                Array.Copy(_buffer, packet, packet.Length);

                // Handle the packet                

                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallBack, null);   
            }
            else
            {
                Console.WriteLine(" Could not connect ");
            }

          

        }
    }
}

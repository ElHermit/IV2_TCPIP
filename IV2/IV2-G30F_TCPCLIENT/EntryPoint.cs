using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace IV2_G30F_TCPCLIENT
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            String ipAdress = "192.168.0.5";
            String trigger_result = "T2\r";
            String programChange = "PW,000\r";
            String getProgram = "PR\r";
            String trigger = "T1\r";
            String getResult = "SR\r";

            String myMessage = "";

            Int32 port = 8500;

            myMessage = trigger;

            Connect(ipAdress, myMessage, port);
        }
        static void Connect(String server, String message, Int32 port)
        {
            try
            {
                // Create a TcpCLient
                TcpClient IV2_Client = new TcpClient(server, port);

                // Translate the passed message into ASCII and store it as a Byte array
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Geta a client stream for reading and writing
                // Stream stream = client.GetStream();

                NetworkStream stream = IV2_Client.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                // Receive the TcpServer.response. 

                // Buffer to the store the response bytes.
                data = new byte[256];

                // String to store the ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes. 
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                // Close everything.
                stream.Close();
                IV2_Client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\nPress Enter to continue");
            Console.Read();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ObserverPattern
{
    static class CommunicationHelper
    {

        public static string decodeStream(byte[] bytes, int i)
        {
            string data = null;
            string hex = BitConverter.ToString(bytes);
            data = Encoding.ASCII.GetString(bytes, 0, i);

            return data;
        }

        public static byte[] encodeStream(string str)
        {
            Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);

            return reply;
        }

        public static void sendReply(string str, NetworkStream stream, Publisher publisher)
        {
            Byte[] reply = encodeStream(str);

            TcpClient u_client;
            NetworkStream u_stream;
            List<UserSubscriber> subscriber_list = publisher.getSubscribers();
            foreach (var user in subscriber_list)
            {
                u_client = user.getUserClient();
                u_stream = u_client.GetStream();

                u_stream.Write(reply, 0, reply.Length);
                Console.WriteLine("{1}: Sent: {0}", str, Thread.CurrentThread.ManagedThreadId);
            }


            
            
        }


    }
}


using System;
using System.Net.Sockets;
using System.Threading;

namespace ObserverPattern
{
    class UserSubscriber : Subscriber
    {

        private TcpClient _user_client;
        public UserSubscriber(TcpClient client)
        {
            _user_client = client;
        }

        public void update(string message)
        {
            // Do something
        }




        // Handle a single tcp client on thread
        public void HandleDeivce(dynamic thread_params)
        {
            Publisher publisher = thread_params.Publisher;

            TcpClient client = thread_params.Client;
            var stream = client.GetStream();
            string imei = String.Empty;

            string data = null;
            Byte[] bytes = new Byte[256];
            int i;
            try
            {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Message recieved from tcp client
                    data = CommunicationHelper.decodeStream(bytes, i);
                    Console.WriteLine("{1}: Received: {0}", data, Thread.CurrentThread.ManagedThreadId);


                    // Message to send back to tcp client
                    string str = "Hey " + client.Client.RemoteEndPoint + ". You sent " + data;
                    CommunicationHelper.sendReply(str, stream, publisher);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
                client.Close();
            }
        }



        public TcpClient getUserClient()
        {

            return _user_client;
        }


    }
}

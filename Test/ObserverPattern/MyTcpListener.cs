using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ObserverPattern
{
    class MyTcpListener
    {
        TcpListener server = null;


        // This is for a single room
        Publisher publisher = new Publisher();


        public MyTcpListener()
        {
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            server = new TcpListener(localAddr, port);
            server.Start();
            StartListener();
        }

        public void StartListener()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    UserSubscriber new_user = new UserSubscriber(client);
                    publisher.subscribe(new_user);


                    Thread t = new Thread(new ParameterizedThreadStart(new_user.HandleDeivce));

                    var thread_params = new { Client=client, Publisher=publisher};
                    t.Start(thread_params);
                    
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                server.Stop();
            }
        }



    }
}

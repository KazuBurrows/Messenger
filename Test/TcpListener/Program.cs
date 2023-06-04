using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Thread t = new Thread(delegate ()
        {
            // replace the IP with your system IP Address...
            MyTcpListener myserver = new MyTcpListener();
        });
        t.Start();

        Console.WriteLine("Server Started...!");
    }
}
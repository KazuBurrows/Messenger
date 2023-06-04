using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

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

    public static void sendReply(string str, NetworkStream stream)
    {

        Byte[] reply = encodeStream(str);
        stream.Write(reply, 0, reply.Length);
        Console.WriteLine("{1}: Sent: {0}", str, Thread.CurrentThread.ManagedThreadId);
    }
}


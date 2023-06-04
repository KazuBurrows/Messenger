using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ObserverPattern
{
    interface Subscriber
    {

        public void update(string message);
    }
}

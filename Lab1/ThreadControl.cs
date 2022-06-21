using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{
    public class ThreadControl
    {
        public Array Arr { get; }
        public Thread Thread { get; private set; }
        ThreadControl(Array arr, ThreadStart func)
        {
            Arr = arr;
            Thread = new Thread(func);
        }
        public ThreadControl() { }
        public void Start(ThreadStart func)
        {
            Thread = new Thread(func);
            Thread.Start();
        }
        public void Stop()
        {
            Thread.Abort();
        }

    }
}

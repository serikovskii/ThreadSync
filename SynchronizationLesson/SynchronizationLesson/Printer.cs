using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace SynchronizationLesson
{
    [Synchronization]
    public class Printer : ContextBoundObject
    {
        //Interlocked.Increment(ref _number);
        private int _number = 0;
        private object lockObject = new object();
        public void Print()
        {
            /*lock (lockObject)
            {*/
                var currentThread = Thread.CurrentThread;
                Console.WriteLine($"{currentThread.Name} - начинает работу");


                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(5 * new Random().Next(100));
                    Console.Write(i + " " + "(" + _number + ")");
                    _number = currentThread.ManagedThreadId;
                }
                Console.WriteLine($"\n{currentThread.Name} - закончил работу");
            //}
        }
    }
}

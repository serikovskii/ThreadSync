using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SyncHW
{
    class Program
    {
        static void Main(string[] args)
        {
            var trans = new Transaction();
            var threads = new Thread[20];
            
            for (int i = 0; i < 20; i++)
            {
                var thread = new Thread(trans.TransferMoney);
                thread.Name = $"Поток номер {thread.ManagedThreadId}";
                threads[i] = thread;
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            Console.ReadLine();
        }

    }
}

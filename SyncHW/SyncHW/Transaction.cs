using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncHW
{
    public class Transaction
    {
        private User user;
        public Transaction()
        {
            user = new User()
            {
                Name = "Tom",
                BankAccount = 5000
            };
        }

        public void TransferMoney()
        {
            var currentThread = Thread.CurrentThread;
            Console.WriteLine($"{currentThread.Name} - начинает работу");
            
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(5 * new Random().Next(100));
                Console.Write($"\n{i} - на счету {user.BankAccount}");
                user.BankAccount += new Random().Next(-2000, 2000);
            }
            Console.WriteLine($"\n{currentThread.Name} - закончил работу");
        }
    }
}

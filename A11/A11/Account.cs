using System.Collections;
using System.Runtime.InteropServices;
using System.Security;
using System;
using System.IO;


namespace A11
{
    public class Account
    {
        public double Balance { get; set; }
        public Account(double balance)
        {
            if (balance >= 0)
                Balance = balance;
            else
            {
                Balance = 0;
                Console.WriteLine($"Initial balance is invalid. Setting balance to 0.");

            }

        }
        public virtual void Credit(double amount)
        {
            if (amount >= 0)
                this.Balance += amount;
            else
                throw new ArgumentException("Credit amount must be positive");
        }
        public virtual bool Debit(double amount)
        {
            bool res = true;
            if (amount <= this.Balance)
            {
                this.Balance = Balance - amount;
            }
            else
            {
                Console.Write($"Debit amount exceeded account balance.{Environment.NewLine}");
                this.Balance = Balance;
                res = false;
            }
            return res;
        }
    }
}
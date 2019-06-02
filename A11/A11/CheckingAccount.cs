using System;

namespace A11
{
    public class CheckingAccount : Account
    {
        public double TransactionFee;
        public CheckingAccount(double balance, double transactionFee) : base(balance)
        {
            TransactionFee = transactionFee;
        }
        public override void Credit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount - TransactionFee;
            }
            else
            {
                throw new ArgumentException($"Credit amount must be positive");
            }
        }
        public override bool Debit(double amount)
        {
            if (amount <= this.Balance)
            {
                this.Balance = Balance - amount - TransactionFee;
                return true;
            }

            else
            {
                Console.Write($"Debit amount exceeded account balance.{Environment.NewLine}");
                this.Balance = Balance - 0;
                return false;

            }

        }
    }
}
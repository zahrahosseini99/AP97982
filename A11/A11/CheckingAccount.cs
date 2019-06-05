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
            base.Credit(amount);
            Balance = Balance - TransactionFee;
        }
        public override bool Debit(double amount)
        {
            if (base.Debit(amount))
            {
                Balance = Balance - TransactionFee;
                return true;
            }
            else
                return false;
        }
    }
}
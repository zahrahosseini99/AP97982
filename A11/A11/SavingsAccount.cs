using System.Collections;
using System.Runtime.InteropServices;
using System.Security;
using System;
using System.IO;

namespace A11
{
    public class SavingsAccount : Account
    {
        public double InterestRate { get; set; }
        public SavingsAccount(double balance,double interestRate) : base(balance)
        {
            
            InterestRate = interestRate;
          
            if (balance >= 0)
                Balance = balance;
    else
            {
                Balance = 0;
         

            }
        }
        public double CalculateInterest()
        {
            return InterestRate * Balance;
        }


    }
}
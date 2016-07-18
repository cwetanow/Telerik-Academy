using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework05.Banking
{
    public abstract class Account
    {
        public Customer Customer { get; private set; }
        private double balance;
        private double interestRate;

        public double InterestRate
        {
            get { return this.interestRate; }
            set { this.interestRate = value; }
        }

        public double Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }
        public abstract double CalculateInterest(int months);
        public Account(Customer customer, double balance, double interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;

        }
        public override string ToString()
        {
            return string.Format("Holder: {0}, Balance: {1}, Interest Rate: {2}",this.Customer,this.Balance,this.InterestRate);
        }
        
        


    }
}

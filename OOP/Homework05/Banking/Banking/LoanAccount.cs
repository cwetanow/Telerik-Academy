using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework05.Banking
{
    public class LoanAccount:Account, IDepositable
    {
        public LoanAccount(Customer customer, double balance, double interestRate)
            : base(customer, balance, interestRate)
        {

        }
        public override double CalculateInterest(int months)
        {
            if (this.Customer==Customer.individual)
            {
                months -= 3;
            }
            else
            {
                months -= 2;
            }
            
            return (this.InterestRate * months);
        }
        public void Deposit(double amount)
        {
            this.Balance += amount;
        }
       
    }
}

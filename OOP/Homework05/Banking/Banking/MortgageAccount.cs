using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework05.Banking
{
   public class MortgageAccount:Account, IDepositable
    {
        public MortgageAccount(Customer customer, double balance, double interestRate)
            : base(customer, balance, interestRate)
        {

        }
        public override double CalculateInterest(int months)
        {
            if (this.Customer==Customer.individual)
            {
                months -= 6;
            }
            else
            {
                if (months>=12)
                {
                    months -= -6;
                }
                else
                {
                    return (this.InterestRate * months) / 2;
                }
            }
            
            return (this.InterestRate * months);
        }
        public void Deposit(double amount)
        {
            this.Balance += amount;
        }
    }
}

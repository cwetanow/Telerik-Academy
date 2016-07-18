using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework05.Banking
{
    public class DepositAccount : Account, IDepositable, IWithdrawable
    {
        public DepositAccount(Customer customer, double balance, double interestRate)
            : base(customer, balance, interestRate)
        {

        }
        public override double CalculateInterest(int months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            return (this.InterestRate * months) ;
        }
        public void Deposit(double amount)
        {
            this.Balance += amount;
        }
        public void Withdraw(double amount)
        {
            this.Balance -= amount;
        }
    }
}

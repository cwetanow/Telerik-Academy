using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework05.Banking
{
    public class Bank
    {
        private List<Account> accounts;
        public List<Account> Accounts
        {
            get { return this.accounts; }
            set
            {
                this.accounts = value;
            }
        }
        public Bank(List<Account> acc)
        {
            this.Accounts = acc;
        }
        public void PrintAccounts()
        {
            foreach (var item in this.accounts)
            {
                Console.WriteLine(item);
            }
        }
        public void Add(Account account)
        {
            this.accounts.Add(account);
        }
        public void Remove(Account account)
        {
            this.accounts.Remove(account);
        }

    }
}

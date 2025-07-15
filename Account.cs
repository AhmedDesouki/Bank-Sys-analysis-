using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bank_Sys_Analysis_SURE_Intern
{
    internal class Account
    {
        private static int counter=0;
        public int AccountNumber { get; }
        public  Customer Owner { get; set; }

        public Account()
        {
            AccountNumber = ++counter;

        }
        public Account(Customer owner)
        {
            Owner = owner;  
        }

        public static Account CreateAccount(Customer owner)
        {
            Account account = new Account();
            account.Owner = owner;

            owner.Accounts.Add(account);
            return account;

        }

        
        public override string ToString()
        {
            return $"accountNumber: {AccountNumber} Customer: {Owner} ";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Sys_Analysis_SURE_Intern
{
    internal class Account
    {
        public string AccountNumber { get; set; }
        public  Customer Owner { get; set; }

        public Account(string accountNumber,Customer owner)
        {
            AccountNumber = accountNumber;
            Owner = owner;  
        }

    }
}

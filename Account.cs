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
        public string AccountNumber { get;}
        public  Customer Owner { get; set; }

        public Account(string accountNumber,Customer owner)
        {
            AccountNumber = accountNumber;
            Owner = owner;  
        }
        public override string ToString()
        {
            return $"accountNumber: {AccountNumber} Customer: {Owner}";
        }
    }
}

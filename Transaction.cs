using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Sys_Analysis_SURE_Intern
{
    internal class Transaction
    {
        

        public string Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public Transaction(string type, DateTime date, decimal amount)
        {
            Type = type;
            Date = date;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"Type: {Type} Date: {Date} Amount: {Amount}";
        }


    }
}

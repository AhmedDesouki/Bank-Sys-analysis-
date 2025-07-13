using Bank_Sys_analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bank_Sys_Analysis_SURE_Intern
{
    internal class Customer : Person
    {
       
        public decimal Balance { get; set; }
        public List<Transaction> transactions { get; set; }=new List<Transaction>();
        public Customer(int id, string name, int age,decimal balance) : base(id, name, age)
        {
            
            Balance = balance;
        }
         
        public Customer CreateAccount(int id, string name, int age, decimal balance)
        {
            Customer customer=new Customer(id,name,age,balance);
          
            return customer;
        }

        public static decimal ViewBalance(int id,Customer customer)
        {
            //if id == customer id --> return cutomer.balance
            
            if (id == customer.Id)
            {
                return customer.Balance;

            }
            else
            {
                Console.WriteLine("Invalid ID");
                return 0;
            }

            
        }
        public void Deposit(int id, decimal amount,Customer customer)
        {
            //if id == customer.id --->  balance+=amout

            Transaction transaction = new Transaction("Deposit", DateTime.Now, amount);
            if (id == customer.Id)
            {
                customer.Balance += amount;
                transactions.Add(transaction);
            }
        }

        public void Withdraw(int id, decimal amount,Customer customer)
        {

            //need to add the amount to List<trans> to save history  
            Transaction transaction = new Transaction("Withdraw", DateTime.Now, amount );
         
            if (id == customer.Id)
            {
                try
                {
                    if (customer.Balance < amount) throw new WithdrawMoreThanBalanceExcpetion();

                    customer.Balance -= amount;
                    transactions.Add(transaction);

                }

                catch (WithdrawMoreThanBalanceExcpetion Ex)
                {
                Console.WriteLine("Your balance is less then the amount");
                }




            }

        }
        //why this output [System.Collections.Generic.List`1[Bank_Sys_Analysis_SURE_Intern.Transaction]] tostring !!!
        //public static List<Transaction> ViewTransactionHistory(Customer customer)
        //{

        //    List<Transaction> history = new List<Transaction>();
        //    foreach (var transaction in customer.transactions)
        //    {
        //        history.Add(transaction);
        //    }
        //    return history;
        //}

        public static List<Transaction> ViewTransactionHistory(Customer customer)
        {

            if (customer.transactions == null)
            {
                return new List<Transaction>(); 
            }

            return new List<Transaction>(customer.transactions);
        }


        public override string ToString()
        {
            return $"Customer ID: {Id}, Name: {Name}, Balance: {Balance:C}";
        }
    }
}

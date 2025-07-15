using Bank_Sys_analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace Bank_Sys_Analysis_SURE_Intern
{
    internal class Customer : Person
    {
       
        public decimal Balance { get; set; }
        public List<Transaction> transactions { get; set; }=new List<Transaction>();
        BankData<Transaction> bankData = new BankData<Transaction>();

        //customer has list of accounts 1-to-many
        public List<Account> Accounts { get; set; } = new List<Account>();
        public Customer() : base() 
        {
            
        }
        public Customer(string name, int age,decimal balance) : base(name, age)
        {
            
             Balance = balance;
        }
        public Customer(string name, int age) : base(name, age)
        {

            
        }
        

        public static Customer CreateCustomer(string name, int age)
        {
            Customer customer=new Customer();
            customer.Name = name;  
            customer.Age = age;
            Account account = new Account(customer);
            //need to add account to list<account>
           // customer.Accounts.Add(account);
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
        public void Deposit(string name, decimal amount)
        {
            //if id == customer.id --->  balance+=amout
            //error conversion list
            string myfileAccounts = "D:\\ITI\\Bank Sys analysis\\Accounts.json";

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                PropertyNameCaseInsensitive = true
            };
            List<Customer> result= new List<Customer>();
            foreach (string line in File.ReadLines(myfileAccounts))
            {
                //customers = JsonSerializer.Deserialize<List<Customer>>(line, options);
                var customer = JsonSerializer.Deserialize<Customer>(line, options);
                result.Add(customer);
                
            }
            Customer customerToUpdate = result.FirstOrDefault(c => c.Name == name);
            if (customerToUpdate == null) { throw new ArgumentException($"Customer with username {name} not found"); }
            Transaction transaction = new Transaction("Deposit", DateTime.Now, amount);
            customerToUpdate.Balance += amount;
            customerToUpdate.transactions.Add(transaction);
            bankData.AddItem(transaction);

            //Save back to file
            string updatedJson = JsonSerializer.Serialize(result, options);
            File.WriteAllText(myfileAccounts, updatedJson+ Environment.NewLine);
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
        
        public static List<Transaction> ViewTransactionHistory(string username)
        {
            string myfileAccounts = "D:\\ITI\\Bank Sys analysis\\Accounts.json";

            var options = new JsonSerializerOptions
            {
                WriteIndented = false,
                PropertyNameCaseInsensitive = true
            };
            List<Customer> result = new List<Customer>();
            List<Transaction> CustomerTransactions = new List<Transaction>();
            foreach (string line in File.ReadLines(myfileAccounts))
            {
                //customers = JsonSerializer.Deserialize<List<Customer>>(line, options);
                var customer = JsonSerializer.Deserialize<Customer>(line, options);
                result.Add(customer);

            }
            Customer TragetedCustomer= result.FirstOrDefault(c => c.Name == username);
            if (TragetedCustomer == null) { throw new ArgumentException($"Customer with username {username} not found"); }
            //customer . trans -->>add it to list of trans
            CustomerTransactions= TragetedCustomer.transactions;
           
            return CustomerTransactions;
        }


        public override string ToString()
        {
            return $"Customer ID: {Id}, Name: {Name}, Balance: {Balance:C}";
        }
    }
}

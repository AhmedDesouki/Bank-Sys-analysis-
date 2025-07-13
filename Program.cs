using System.Text.Json;

namespace Bank_Sys_Analysis_SURE_Intern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person(1,"ahmed",20) ;

            Customer customer = new Customer(1, "ahmed", 20, 100.50m);
            Customer customer1 = new Customer(2, "mohamed", 26, 200.00m);

            var newCustomers = new List<Customer>
            {
                customer1,
                customer
            };

            BankData<Customer> bankData = new BankData<Customer>();
            bankData.AddItem(customer);

            BankData<Transaction> bankData1 = new BankData<Transaction>();

            //customer.CreateAccount(customer);
            //Console.WriteLine (Customer.ViewBalance(1, customer));
            customer.Deposit(1, 500.50m, customer);
            customer.Withdraw(1, 100.50m, customer);
            customer.Withdraw(1, 50000.00m, customer);
            List<Transaction> history = Customer.ViewTransactionHistory(customer);
            foreach (var transaction in history)
            {
               Console.WriteLine(transaction);
                bankData1.AddItem(transaction);
            }

            Account account1 = new Account("1",customer1);

            //Console.WriteLine(customer);
            //Console.WriteLine(customer.Balance);
            // Console.WriteLine("alo");
        }
    }
}

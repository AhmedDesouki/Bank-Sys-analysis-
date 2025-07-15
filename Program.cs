using System.Text.Json;

namespace Bank_Sys_Analysis_SURE_Intern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize data storage
            BankData<Customer> customerData = new BankData<Customer>();
            BankData<Transaction> transactionData = new BankData<Transaction>();
            Admin admin = new Admin("Hazem", 33);

            // Sample customers
            //Customer customer1 = new Customer("Ahmed", 20, 100.50m);
            // Customer customer2 = new Customer("Mohamed", 26, 200.00m);
            //Customer customer3 = Customer.CreateCustomer("Ammar", 21);
            //Customer customer4 = Customer.CreateCustomer("Hazem", 33);

            // Add sample accounts
            //Account.CreateAccount(customer3);
            //Account.CreateAccount(customer3);
            //Account.CreateAccount(customer3);


            //customer3.Deposit(3, 300);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Bank Management System ===");
                Console.WriteLine("1. View All Accounts");
                Console.WriteLine("2. View Transaction History");
                Console.WriteLine("3. Deposit Money");
                Console.WriteLine("4. Withdraw Money");
                Console.WriteLine("5. Create New Customer");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": // View All Accounts
                        Console.WriteLine("\nAll Accounts:");
                        foreach (var account in admin.View_all_accounts())
                        {
                            Console.WriteLine(account);
                        }
                        break;

                    case "2": // View Transaction History
                        Console.Write("\nEnter Customer username: ");
                        string username = Console.ReadLine();

                        List<Transaction> transactions = Customer.ViewTransactionHistory(username);

                        foreach (var transaction in transactions)
                        {
                            Console.WriteLine(transaction);
                        }
                        
                            
                        
                        break;

                    case "3": // Deposit Money
                        Console.Write("\nEnter Customer username: ");
                        string depositCustomerName = Console.ReadLine();
                        //read account from file 
                        //add amout to customer balance
                        Customer depositCustomer = new Customer();

                            Console.Write("Enter Amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                            {
                                depositCustomer.Deposit(depositCustomerName, depositAmount);
                                Console.WriteLine("Deposit successful!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount!");
                            }


                       
                        
                        break;

                    case "4": // Withdraw Money
                        Console.Write("\nEnter Customer ID: ");
                        if (int.TryParse(Console.ReadLine(), out int withdrawCustomerId))
                        {
                            Customer withdrawCustomer = customerData.items.FirstOrDefault(c => c.Id == withdrawCustomerId);
                            if (withdrawCustomer != null)
                            {
                                Console.Write("Enter Amount: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                                {
                                    withdrawCustomer.Withdraw(withdrawCustomerId, withdrawAmount, withdrawCustomer);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid amount!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Customer not found!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid customer ID!");
                        }
                        break;

                    case "5": // Create New Customer
                        Console.Write("\nEnter Customer Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Customer Age: ");
                        int age = int.Parse(Console.ReadLine());

                        Customer newCustomer = Customer.CreateCustomer(name, age);

                        customerData.AddItem(newCustomer);
                        Console.WriteLine("Customer created successfully!");


                        break;

                    case "6": // Exit
                        return;

                    default:
                        Console.WriteLine("Invalid option! Try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
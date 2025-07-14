using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Sys_Analysis_SURE_Intern
{
    internal class Admin : Person
    {
        public Admin(int id, string name, int age) : base(id, name, age)
        {
        }

        public void View_all_accounts( )
        {
            BankData<Customer> bankdata = new BankData<Customer>();
            Customer customer = null;
            List<Customer> allCustomers =bankdata.GetAll(customer);
            foreach (var item in allCustomers)
            {
                Console.WriteLine(item);
                
            }

        }
    }
}

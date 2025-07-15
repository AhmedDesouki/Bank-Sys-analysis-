using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bank_Sys_Analysis_SURE_Intern
{
    internal class Admin : Person
    {
        public Admin(string name, int age) : base(name, age)
        {
        }

        public List<Customer> View_all_accounts( )
        {

            //need to read from accounts.json
            List<Customer> result = new List<Customer>();
          
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true //case sensitive
            };

            foreach (string line in File.ReadLines("D:\\ITI\\Bank Sys analysis\\Accounts.json"))
            {
                
                        var customer = JsonSerializer.Deserialize<Customer>(line, options);
                       
                          result.Add(customer);
                
            }
            return result;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Sys_Analysis_SURE_Intern
{
    internal class BankData<T>
    {
        public List<T> items { get; set; }
        public void AddItem(T item)
        {
            if(item is Customer)
            {
                File.AppendAllText("D:\\ITI\\Bank Sys analysis\\AllAcounts.txt", item.ToString() + Environment.NewLine);
            }
             if(item is Transaction)
            {
                
                 File.AppendAllText("D:\\ITI\\Bank Sys analysis\\AllTransactions.txt", item.ToString() + Environment.NewLine);

                
            }
            
        }
        public List<T> GetAll() {

            return items;
 }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Sys_Analysis_SURE_Intern
{
    internal class BankData<T>
    {
        public List<T> items { get; set; }= new List<T>();  
        public void AddItem(T item)
        {
            
            if (item is Customer)
            {
                
                File.AppendAllText("D:\\ITI\\Bank Sys analysis\\AllAcounts.txt", item.ToString() + Environment.NewLine);
            }
             if(item is Transaction)
            {
                
                 File.AppendAllText("D:\\ITI\\Bank Sys analysis\\AllTransactions.txt", item.ToString() + Environment.NewLine);

                
            }
             items.Add(item);
            
        }
        public List<T> GetAll(T item)
        {
            List<T> list = new List<T>();
            if (item is Customer){ 
             foreach (T customer in items)
                {
                    
                    list.Add(customer);
                        
                }
                return list;
            }
            if (item is Transaction)
            {
                foreach (T transaction in items)
                {
                    
                    list.Add(transaction);
                   
                }
                return list;
            }

                return items;
        }

        public override string ToString()
        {
            return $"AllData: {items} ";
        }
    }
}

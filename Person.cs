using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Sys_Analysis_SURE_Intern
{
     internal class Person
    {
        private static int counter = 0;

        public int Id { get;}
        public string Name { get; set; }
        public  int Age { get; set; }

        public Person() {
            Id = ++counter;
        } 
        public Person(string name,int age)
        {
            
            Name = name;    
            Age = age;
        }
    }
}

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bank_Sys_Analysis_SURE_Intern
{
    internal class BankData<T>
    {
        public List<T> items { get; set; } = new List<T>();
        public void AddItem(T item)
        {

            if (item is Customer customer)
            {
                //need another option instead of copy/past
                var options = new JsonSerializerOptions
                {

                    //ReferenceHandler = ReferenceHandler.Preserve, // Handles circular references
                    WriteIndented = false,
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                    // MaxDepth = 128 // Increase if needed

                };
                string json = JsonSerializer.Serialize(customer, options);
                File.WriteAllText("D:\\ITI\\Bank Sys analysis\\Accounts.json", json.Trim() + Environment.NewLine);
            }
            if (item is Transaction)
            {
                var options = new JsonSerializerOptions
                {

                    WriteIndented = false,
                    ReferenceHandler = ReferenceHandler.IgnoreCycles

                };
                string json = JsonSerializer.Serialize(item, options);
                File.AppendAllText("D:\\ITI\\Bank Sys analysis\\Transactions.json", json.Trim() + Environment.NewLine);


            }
            items.Add(item);

        }
        public List<T> GetAll(T item)
        {
            List<T> list = new List<T>();
            if (item is Customer)
            {
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

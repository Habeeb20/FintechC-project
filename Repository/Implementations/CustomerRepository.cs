using System.Diagnostics;
using Entity;
using Repository.Abstractions;

namespace Repository.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private static readonly List<Customer> Customers_DB = [];
        public CustomerRepository()
        {
        }
        // CRUD
        public bool Add(Customer customer)
        {
            if (customer is not null)
            {
                var customerString = customer.ToString();
                using StreamWriter writer = new(ApplicationConstants.FileConstants.CUSTOMERFILE, true);
                writer.WriteLine(customerString);
                writer.Flush();
                writer.Close();
                return true;
            }
            return false;
        }
        public Customer GetByNIN(string nin)
        {
            var customer = Customers_DB
            .Find(c => c.NIN == nin);
            return customer;
        }
        public Customer Get(string phone, string password)
        {
            var customer = Customers_DB.
            FirstOrDefault(x => x.Phone == phone && x.Password == password);
            return customer;
        }
        public Customer Get(string password)
        {
            var customer = Customers_DB.
            FirstOrDefault(x => x.Password == password);
            return customer;
        }
        public Customer GetById(Guid id)
        {
            var customer = Customers_DB
            .Find(c => c.Id == id);
            return customer;
        }
        public (Customer, bool) Update(Guid id, Customer customer)
        {
            var customerToUpdate = Customers_DB
            .Find(c => c.Id == id);
            if (customerToUpdate is not null)
            {
                Customers_DB.Remove(customerToUpdate);
                Customers_DB.Add(customer);
                return (customer, true);
            }
            return (null, false);
        }
        public bool Delete(Customer customer)
        {
            if (customer is not null)
            {
                Customers_DB.Remove(customer);
                return true;
            }
            return false;
        }
        public static void LoadInitialData()
        {
            var absPaths = Path.Combine(Directory.GetCurrentDirectory(), ApplicationConstants.FileConstants.CUSTOMERFILE);
            using StreamReader reader = new(absPaths);
            var custmerData = reader.ReadLine();
            while (custmerData != null)
            {
                try
                {
                    var customerToAdd = Customer.FormatLine(custmerData);
                    Customers_DB.Add(customerToAdd);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); 
                }
                custmerData = reader.ReadLine();
            }
        }
    }
}
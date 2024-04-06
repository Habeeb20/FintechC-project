using Entity;
using Repository.Abstractions;

namespace Repository.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> Customers_DB;
        public CustomerRepository()
        {
            Customers_DB = [];
        }
        // CRUD
        public bool Add(Customer customer)
        {
            if (customer is not null)
            {
                Customers_DB.Add(customer);
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
   }
}
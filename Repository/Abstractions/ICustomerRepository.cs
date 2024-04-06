using Entity;
namespace Repository.Abstractions
{
    public interface ICustomerRepository
    {
        bool Add(Customer customer);

        Customer GetById(Guid id);
        Customer Get(string password);
        bool Delete(Customer customer);
        Customer Get(string phone, string password);
        (Customer, bool) Update(Guid id, Customer customer);



    }
}
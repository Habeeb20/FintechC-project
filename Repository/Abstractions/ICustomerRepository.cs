using OOP_Project.Entities;
namespace OOP_Project.Repository.Abstractions
{
    public interface ICustomerRepository
    {
        bool Add(Customer customer);

        Customer? GetByNIN(string nin);

        Customer? Update(Guid id, Customer customer);

       bool Delete(Customer customer);

         
    }
}
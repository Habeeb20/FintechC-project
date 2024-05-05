using System.Linq.Expressions;
using DTO.Command;
using Entity;
using Repository.Abstractions;
using Repository.Implementations;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }
        public bool Register(CreateCustomerRequest request)
        {
            if (request is null)
                return false;

            Customer customer = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Password = request.Password,
                Gender = request.Gender,
                NIN = request.NIN
            };
            var isCustomerAdded = _customerRepository.Add(customer);
            return isCustomerAdded;
        }
        public Customer GetCustomer(string phone, string password)
        {
            var customer = _customerRepository.Get(phone, password);
            return customer;
        }
    }
}
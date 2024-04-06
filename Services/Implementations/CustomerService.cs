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
        // DTO
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
        // public (Customer, bool) Update(string pass, UpdateCustomerRequest request)
        // {
        //     if (request is null)
        //         return (null, false);
            
        //     var authenticatedCustomer = _customerRepository.Get(pass);

        //     if (authenticatedCustomer is null)
        //         return (null, false);
            

        // }
    }
}
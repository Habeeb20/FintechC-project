using Services.Implementations;
using Services.Interfaces;

namespace Menu.Customer
{
    public class CustomerRegistration
    {
        ICustomerService _customerService;
        public CustomerRegistration()
        {
            _customerService = new CustomerService();
        }

        public void RegisterMenu()
        {
            Console.WriteLine("Enter your first name");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter your last name");
            string lName = Console.ReadLine();
            Console.WriteLine("Enter your first name");
            string phone = Console.ReadLine();
            
        }
    }
}
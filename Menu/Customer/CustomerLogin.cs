using Services.Implementations;
using Services.Interfaces;

namespace Menu.Customer
{
    public class CustomerLogin
    {
        CustomerLogin customerLogin;
        ICustomerService _customerService;
        public CustomerLogin()
        {
            _customerService = new CustomerService();

        }
        public void LoginMenu()
        {
            Entity.Customer customer = null;
            while (customer is null)
            {
                System.Console.WriteLine("###Login###");
                Console.ResetColor();
                Console.WriteLine("Enter Phone number");
                string phone = Console.ReadLine();
                Console.WriteLine("Enter your password");
                string pass = Console.ReadLine();
                customer = _customerService.GetCustomer(phone, pass);
                if (customer is null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Inavlid login details");
                }
            }
            Console.WriteLine("Login Successfull");
        }
    }
}
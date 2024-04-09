using DTO.Command;
using Entity.Enums;
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
            Console.WriteLine("Enter Phone number");
            string phone = Console.ReadLine();
            // password
            Console.WriteLine("Create a new password");
            string newPass = Console.ReadLine();
            string confirmPass = "";
            while (!confirmPass.Equals(newPass))
            {
                Console.WriteLine("Confirm password");
                confirmPass = Console.ReadLine();
            }
            //
            Console.WriteLine("Choose gender\n1. Male\t2. Female");
            int gender = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your NIN");
            string NIN = Console.ReadLine();

            var customDto = new CreateCustomerRequest
            {
                FirstName = fName,
                LastName = lName,
                Phone = phone,
                NIN = NIN,
                Gender = (Gender)gender,
                Password = newPass
            };

            var isCustomerRegistered = _customerService.Register(customDto);
            if (isCustomerRegistered)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Successfully Registered");
                Console.ResetColor();
            }
            else
                System.Console.WriteLine("Something went wrong");
        }



    }
}
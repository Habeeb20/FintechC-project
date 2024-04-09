using Menu.Customer;

namespace Menu
{
    public class Main
    {
        CustomerRegistration customerRegistration;
        CustomerLogin customerLogin;
        public Main()
        {
            customerLogin = new CustomerLogin();
            customerRegistration = new CustomerRegistration();
        }
        public void LandingMenu()
        {
            
            Console.WriteLine("########################");
            Console.WriteLine("########################");
            Console.WriteLine("######## FIN APP #######");
            Console.WriteLine("########################");
            Console.WriteLine("########################");
            Console.WriteLine("1. to Customer menu\n2. to Admin menu");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                System.Console.WriteLine("Invalid input");
            }
            switch (option)
            {
                case 1:
                    CustomerMenu();
                    break;
                case 2:
                    AdminMenu();
                    break;
                default:
                    break;
            }
        }
        public void CustomerMenu()
        {
            Console.WriteLine("1. Sign-in\n2. Sign-up");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input");
                Console.ResetColor();
            }
            switch (option)
            {
                case 1:
                    customerLogin.LoginMenu();
                    break;
                case 2:
                    customerRegistration.RegisterMenu();
                    customerLogin.LoginMenu();
                    break;
                default:
                    break;
            }
        }
        public void AdminMenu()
        {

        }
    }
}
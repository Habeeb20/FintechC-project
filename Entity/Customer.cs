using Entity.Enums;

namespace Entity
{
    public class Customer : User
    {
        public string? Address;
        public required string NIN;
        public Customer(string firstName, string lastName, string phoneNumber, string password, Gender gender)
        :base(firstName,lastName,phoneNumber,password,gender)
        {
            
        }
    }
}
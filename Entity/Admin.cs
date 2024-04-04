using Entity.Enums;

namespace Entity
{
    public class Admin : User
    {
        public Admin(string firstName, string lastName, string phoneNumber, string password, Gender gender)
        :base(firstName,lastName,phoneNumber,password,gender)
        {
            
        }
    }
}
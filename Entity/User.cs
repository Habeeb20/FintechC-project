using Entity.Enums;

namespace Entity
{
    public class User : BaseEntity
    {
        public required string FirstName;
        public required string LastName;
        public required string Phone;
        public required string Password;
        public required Gender Gender;
        public User(string firstName, string lastName, string phoneNumber, string password, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phoneNumber;
            Password = password;
            Gender = gender;
        }
    }
}
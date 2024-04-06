using Entity.Enums;

namespace DTO.Command
{
    public class CreateCustomerRequest
    {
        public required string FirstName;
        public required string LastName;
        public required string Password;
        public required string Phone;
        public required Gender Gender;
        public required string NIN;
        public string? Address;
    }
}
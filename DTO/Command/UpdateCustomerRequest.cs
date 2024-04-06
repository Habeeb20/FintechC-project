namespace DTO.Command
{
    public class UpdateCustomerRequest
    {
        public required string FirstName;
        public required string LastName;
        public required string Phone;
        public required string Password;
        public string? Address;
    }
}
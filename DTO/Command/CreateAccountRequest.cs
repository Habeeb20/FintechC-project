using Entity.Enums;

namespace DTO.Command
{
    public class CreateAccountRequest
    {
        public required int Pin;
        public required BankName BankName;
    }
}
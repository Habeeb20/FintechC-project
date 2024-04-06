using Entity.Enums;

namespace Entity
{
    public class Account : BaseEntity
    {
        public Guid CustomerUserId = default!;
        public decimal Balance = 0.00M;
        public required int Pin;
        public required string AccountNumber;
        public required BankName BankName;
        public Account(int pin, BankName bankName)
        {
            Pin = pin;
            BankName = bankName;
        }
    }
}
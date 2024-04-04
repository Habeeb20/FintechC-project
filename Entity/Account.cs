using Entity.Enums;

namespace Entity
{
    public class Account : BaseEntity
    {
        public decimal Balance = 0.00M;
        public required int Pin;
        public required string AccountNumber;
        public required BankName BankName;
        public Account(int pin, string acctNumber, BankName bankName)
        {
            Pin = pin;
            AccountNumber = acctNumber;
            BankName = bankName;
        }
    }
}
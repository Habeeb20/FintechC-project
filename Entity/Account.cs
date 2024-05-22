using Entity.Enums;

namespace Entity
{
    public class Account : BaseEntity
    {
        public Guid CustomerUserId = default!;
        public string Name;
        public decimal Balance = 2000.00M;
        public int Pin;
        public string AccountNumber;
        public BankName BankName;
        public Account(int pin, BankName bankName)
        {
            Pin = pin;
            BankName = bankName;
        }
        
    }
}
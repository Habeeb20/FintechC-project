using Entity.Enums;

namespace Entity
{
    public class Account : BaseEntity
    {
        public Guid CustomerUserId = default!;
        public string Name;
        public decimal Balance = 2000;
        public int Pin;
        public string AccountNumber;
        public BankName BankName;
        public Account(int pin, BankName bankName)
        {
            Pin = pin;
            BankName = bankName;
        }

       

          internal static Account FormatLine(string acct)
            {
                string[] arry = acct.Split(',');
                return new Account(int.Parse(arry[2]), (BankName)Enum.Parse(typeof(BankName), arry[4]))
                {
                    CustomerUserId = Guid.Parse(arry[0]),
                    Name = arry[1],
                    AccountNumber = arry[3],
                };
            }

            public override string ToString()
                {
                    return $"{CustomerUserId}, {Name}, {AccountNumber},{Pin}, {BankName}";
                    
                }

        
    }
}
using System;
using Entity.Enums;
namespace Entity
{
    public class Transaction : BaseEntity
    {
      
        public required Guid AccountId = default!;
        public decimal Amount;
        public DateTime TransactionDate = DateTime.Now;
        public string Description;
        public TransactionType TransactionType;
        public string ReceiverAcctNum; 


        internal static Transaction FormatLine(string transact)
        {
            string [] props = transact.Split("/t");
            return new Transaction
            {
                AccountId = Guid.Parse(props[0]),
                Amount = decimal.Parse(props[1]),
                TransactionDate = DateTime.Parse(props[2]),
                Description = props[3],
                TransactionType =(TransactionType)Enum.Parse(typeof(TransactionType), props[4]),
                ReceiverAcctNum = props[5]
            };
        }  


        public override string ToString()
        {
            return $"{AccountId}\t{Amount}\t{TransactionDate}\t{Description}\t{TransactionType}\t{ReceiverAcctNum}";
        }      
    }

 
}
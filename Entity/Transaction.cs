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
    }
}
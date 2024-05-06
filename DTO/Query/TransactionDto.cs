using Entity.Enums;

namespace DTO.Query
{
    public class TransactionDto
    {
        public decimal Amount;
        public DateTime TransactionDate;
        public string Description;
        public TransactionType TransactionType;
        public string ReceiverAcctNum;
    }
}
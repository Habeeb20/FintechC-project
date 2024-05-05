using Entity.Enums;

namespace DTO.Command
{
    public class CreateTransactionRequest
    {
        public decimal Amount;
        public string Description;
        public TransactionType TransactionType;
        public string ReceiverAcctNum;  
    }
}
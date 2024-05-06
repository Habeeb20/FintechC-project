using Entity.Enums;

namespace DTO.Command
{
    public class CreateTransactionRequest
    {
        public int Pin;
        public decimal Amount;
        public string Description;
        public string ReceiverAcctNum;  
        public TransactionType TransactionType;
    }
}
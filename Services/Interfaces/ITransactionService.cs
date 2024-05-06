using DTO.Command;
using DTO.Query;

namespace Services.Interfaces
{
    public interface ITransactionService
    {
        (TransactionDto, string) Create(CreateTransactionRequest request, Guid customerId);
    }
}
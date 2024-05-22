using DTO.Command;
using DTO.Query;

namespace Services.Interfaces
{
    public interface ITransactionService
    {
        List<TransactionDto> GetAll(Guid customerId);
        (TransactionDto, string) Create(CreateTransactionRequest request, Guid customerId);
    }
}
using System.Data;

namespace CVA.Repository.Interface
{
    public interface ITransactionManager
    {
        Task BeginTransactionAsync(IsolationLevel isolationLevel);

        Task CommitTransactionsAsync();

        Task RollbackTransactionsAsync();
    }
}

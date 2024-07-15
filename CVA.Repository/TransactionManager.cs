using CVA.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CVA.Repository
{
    public class TransactionManager : ITransactionManager
    {
        private readonly Context _context;

        public TransactionManager(Context context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync(IsolationLevel isolationLevel)
        {
            var activeTransaction = _context.Database.CurrentTransaction;
            if (activeTransaction == null)
            {
                var connection = _context.Database.GetDbConnection();
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                var transaction = await connection.BeginTransactionAsync(isolationLevel);
                await _context.Database.UseTransactionAsync(transaction);
            }
        }

        public async Task CommitTransactionsAsync()
        {
            var contextHasChanges = _context.ChangeTracker.HasChanges();

            if (contextHasChanges)
            {
                await _context.SaveChangesAsync();
            }
            else
            {
                var activeTransaction = _context.Database.CurrentTransaction;
                if (activeTransaction != null)
                    await activeTransaction.CommitAsync();
            }

            var transactionToDispose = _context.Database.CurrentTransaction;
            if (transactionToDispose != null)
                await transactionToDispose.DisposeAsync();
        }

        public async Task RollbackTransactionsAsync()
        {
            var activeTransaction = _context.Database.CurrentTransaction;
            if (activeTransaction != null)
            {
                await activeTransaction.RollbackAsync();
                await activeTransaction.DisposeAsync();
            }
        }
    }
}

using System.Transactions;
using IsolationLevel = System.Data.IsolationLevel;

namespace LevSundt.CrossCut.TransactionHandling;

public interface IUnitOfWork
{
    void BeginTransaction(IsolationLevel isolationLevel);
    void Rollback();
    void Commit();
}
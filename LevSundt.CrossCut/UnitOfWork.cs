using LevSundt.CrossCut.TransactionHandling;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using IsolationLevel = System.Data.IsolationLevel;

namespace LevSundt.CrossCut;

public class UnitOfWork : IUnitOfWork
{
    /// <summary>
    ///     Der skal laves variabel til DbContext der injectes i constructor
    ///     Dette gøres for at få adgang til DbContext i UnitOfWork
    ///     Der køres IKKE på de andre context men på selve DBContext superklassen
    /// </summary>
    private readonly DbContext _db;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(DbContext db)
    {
        _db = db;
    }

    void IUnitOfWork.BeginTransaction(IsolationLevel isolationLevel)
    {
        if (_db.Database.CurrentTransaction != null) return;
        // Når vi starter en transaktion, så gemmes den i _transaction
        _transaction = _db.Database.BeginTransaction(isolationLevel);
    }

    void IUnitOfWork.Commit()
    {
        if (_transaction == null) throw new Exception("You must call 'BeginTransaction' before Commit is called");
       
        _transaction.Commit();
        _transaction.Dispose();
    }

    void IUnitOfWork.Rollback()
    {
        if (_transaction == null) throw new Exception("You must call 'BeginTransaction' before Rollback is called");
        
        _transaction.Rollback();
        _transaction.Dispose();
        ;
    }
}
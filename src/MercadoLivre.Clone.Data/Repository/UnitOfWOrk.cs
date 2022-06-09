using MercadoLivre.Clone.Business.Repository;
using NHibernate;

namespace MercadoLivre.Clone.Data.Repository;

public class NHibernateUnitOfWork : IUnitOfWork
{
    public ISession Session { get; private set; }
    private ITransaction _transaction;

    public NHibernateUnitOfWork(ISession session)
    {
        Session = session;
        _transaction = Session.BeginTransaction();
    }

    public async Task<bool> Commit(CancellationToken cancellationToken)
    {
        var success = false;
        try
        {
            if (_transaction.IsActive)
                await _transaction.CommitAsync(cancellationToken);
            success = true;
        }
        catch (Exception e)
        {
            await Rollback(cancellationToken);
            // TODO: adicionar logs

            success = false;
        }

        return success;
    }

    public void Dispose()
        => _transaction.Dispose();

    public async Task Rollback(CancellationToken cancellationToken)
    {
        await _transaction.RollbackAsync(cancellationToken);
    }
}

public class UnitOfWork : IUnitOfWork
{
    private readonly NHibernateContext _context;
    public UnitOfWork(NHibernateContext context)
    {
        //context.BeginTransaction();
        _context = context;
    }

    public async Task<bool> Commit(CancellationToken cancellationToken)
    {
        var success = false;

        try
        {
            await _context.Transaction.CommitAsync(cancellationToken);
            success = true;
        }
        catch (Exception e)
        {
            await Rollback(cancellationToken);
            // TODO: adicionar logs

            success = false;
        }

        return success;
    }

    public void Dispose()
        => _context?.Dispose();


    public async Task Rollback(CancellationToken cancellationToken)
    {
        await _context.Transaction.RollbackAsync(cancellationToken);
    }
}
using MercadoLivre.Clone.Business.Repository;
using Microsoft.Extensions.Logging;
using NHibernate;

namespace MercadoLivre.Clone.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    public ISession Session { get; private set; }
    private ITransaction _transaction;
    private readonly ILogger _logger;

    public UnitOfWork(ISession session, ILogger<UnitOfWork> logger)
    {
        Session = session;
        _transaction = Session.BeginTransaction();
        _logger = logger;
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
            _logger.LogError(e.Message);

            await Rollback(cancellationToken);

            success = false;
        }

        return success;
    }

    public void Dispose()
        => _transaction.Dispose();

    public async Task Rollback(CancellationToken cancellationToken)
    {
        await _transaction?.RollbackAsync(cancellationToken);
    }
}
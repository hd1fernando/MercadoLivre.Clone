using NHibernate;
using System.Data;

namespace MercadoLivre.Clone.Data.Repository;

public class NHibernateContext : IDisposable
{
    private ISession _session;
    public ISession Session { get { return _session; } }
    public ITransaction Transaction { get; private set; }

    private ISessionFactory _sessionFactory;

    public NHibernateContext(ISession session)
    {
        _session = session;
        Transaction = _session.BeginTransaction();
    }

    public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
    {
        if (Transaction is null || Transaction.IsActive)
        {
            Transaction?.Dispose();
            _session?.BeginTransaction(isolationLevel);
        }
    }

    //public void OpenSession()
    //{
    //    if (_session is null || _session.IsConnected)
    //    {
    //        _session?.Dispose();
    //        _session = _sessionFactory?.OpenSession();
    //    }
    //}

    public void Dispose()
    {
        Transaction?.Dispose();
        Transaction = null;

        _session?.Dispose();
        _session = null;
    }
}

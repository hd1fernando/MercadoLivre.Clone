namespace MercadoLivre.Clone.Business.Entitties
{
    public abstract class Entity<TId>
    {
        public virtual TId Id { get; protected set; }
    }
}

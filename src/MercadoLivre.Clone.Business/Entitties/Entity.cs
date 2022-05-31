namespace MercadoLivre.Clone.Business.Entitties
{
    public abstract class Entity<TId>
    {
        public TId Id { get; protected set; }
    }
}

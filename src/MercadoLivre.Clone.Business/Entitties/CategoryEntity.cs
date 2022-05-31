namespace MercadoLivre.Clone.Business.Entitties
{
    public class CategoryEntity : Entity<int>
    {
        public string? Name { get; }

        public CategoryEntity(string? name)
        {
            Name = name;
        }

        public CategoryEntity(string? name, int categoryId)
        {
            Name = name;
            Id = categoryId;
        }
    }
}

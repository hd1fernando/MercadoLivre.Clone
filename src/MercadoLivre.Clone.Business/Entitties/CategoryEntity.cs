namespace MercadoLivre.Clone.Business.Entitties
{
    public class CategoryEntity
    {
        public string? Name { get; }
        public int CategoryId { get; }

        public CategoryEntity(string? name)
        {
            Name = name;
        }

        public CategoryEntity(string? name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}

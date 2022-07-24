using MercadoLivre.Clone.Business.Entitties;

namespace MercadoLivre.Clone.Business.Repository;

public interface IProductQuestionRepository : IRepository<ProductQuestionEntity, int>
{
    public IEnumerable<ProductQuestionEntity> FindByProductId(int productId);
}
using MercadoLivre.Clone.Api.Indentity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MercadoLivre.Clone.Api.Indentity.Db
{
    // CI: 1
    public class IdentityUserMercadoLivreContext : IdentityDbContext<IdentityUserEntity>
    {
        public IdentityUserMercadoLivreContext(DbContextOptions<IdentityUserMercadoLivreContext> options) : base(options)
        {

        }
    }
}

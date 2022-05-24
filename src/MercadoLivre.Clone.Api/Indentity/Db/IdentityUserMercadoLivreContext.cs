using MercadoLivre.Clone.Api.Indentity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MercadoLivre.Clone.Api.Indentity.Db
{
    public class IdentityUserMercadoLivreContext : IdentityDbContext<UserEntity>
    {
    }
}

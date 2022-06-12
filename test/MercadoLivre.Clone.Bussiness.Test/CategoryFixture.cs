using Bogus;

namespace MercadoLivre.Clone.Bussiness.Test;

public static class CategoryFixture
{
    public static string GenerateName()
        => new Faker("pt_BR").Name.ToString();
}


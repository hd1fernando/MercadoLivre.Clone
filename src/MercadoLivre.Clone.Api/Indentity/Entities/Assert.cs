namespace MercadoLivre.Clone.Api.Indentity.Entities;

public static class Assert
{
    public static void IsTrue(bool value, string message)
    {
        if (value == false)
            throw new InvalidOperationException(message);
    }
}

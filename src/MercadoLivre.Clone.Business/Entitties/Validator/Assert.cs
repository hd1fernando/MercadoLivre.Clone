namespace MercadoLivre.Clone.Business.Entitties.Validator;

internal static class Assert
{
    public static void IsTrue(bool value, string message)
    {
        if (value == false)
            throw new InvalidOperationException(message);
    }
}

namespace MercadoLivre.Clone.Business.Entitties;

public static class Assert
{
    public static void IsTrue(bool value, string message)
    {
        if (value == false)
            throw new InvalidOperationException(message);
    }
}

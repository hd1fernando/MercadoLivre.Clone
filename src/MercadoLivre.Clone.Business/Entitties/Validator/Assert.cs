using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MercadoLivre.Clone.Bussiness.Test")]
namespace MercadoLivre.Clone.Business.Entitties.Validator;

internal static class Assert
{
    public static void IsTrue(bool value, string message)
    {
        if (value == false)
            throw new InvalidOperationException(message);
    }

    public static void IsNotEmpty(string value, string errorMessage)
    {
        if (string.IsNullOrEmpty(value?.Trim()))
            throw new InvalidOperationException(errorMessage);
    }

    public static void Minimun(int length, int min, string errorMessage)
    {
        if (length < min)
            throw new InvalidOperationException(errorMessage);
    }

    public static void Maximun(int length, int max, string errorMessage)
    {
        if (length > max)
            throw new InvalidOperationException(errorMessage);
    }
}

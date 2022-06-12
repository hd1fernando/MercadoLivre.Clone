namespace MercadoLivre.Clone.Api.Extensions;

public class AppSettings
{
    /// <summary>
    /// Chave de criptografia do token JWT
    /// </summary>
    public string? Secret { get; set; }
    /// <summary>
    /// Tempo de duração do token em horas
    /// </summary>
    public int ExpirationTime { get; set; }
    /// <summary>
    /// Quem emite
    /// </summary>
    public string? Emiter { get; set; }
    /// <summary>
    /// Em quais URL esse token é válido
    /// </summary>
    public string? ValidIn { get; set; }
}

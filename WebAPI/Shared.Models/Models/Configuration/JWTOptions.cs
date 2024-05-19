namespace AuthProvider.Configuration
{
    public class JWTOptions
    {
        public const string SectionName = nameof(JWTOptions);
        public string Audience { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string SigningKey { get; set; } = string.Empty;
    }
}

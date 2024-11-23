namespace Source.Options
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}

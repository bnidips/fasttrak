namespace DIPS.FastTrak.Services
{
    public class OAuth2
    {
        public string? AuthorizationEndpoint { get; set; }
        public string? AccessTokenEndpoint { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? GrantType { get; set; }
        public string? RedirectUri { get; set; }
        public bool Enabled { get; set; }
    }
}

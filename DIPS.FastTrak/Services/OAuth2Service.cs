using DIPS.FastTrak.Utils;
using Microsoft.AspNetCore.Components;

namespace DIPS.FastTrak.Services
{
    public interface IAutorization
    {
        void Authorize();
    }

    public class OAuth2Service(IConfiguration config, NavigationManager navigation) : IAutorization
    {
        public void Authorize()
        {
            var OAuth2Config = new OAuth2();
            config.GetSection("OAuth2").Bind(OAuth2Config);
            if (OAuth2Config.Enabled)
            {
                buildAuthorizationUri(navigation, OAuth2Config);
            }
        }

        private static void buildAuthorizationUri(NavigationManager navigation, OAuth2 OAuth2Config)
        {
            var codeVerifier = PkceHelper.GenerateCodeVerifier();
            var codeChallenge = PkceHelper.GenerateCodeChallenge(codeVerifier);
            var uri = $"{OAuth2Config.AuthorizationEndpoint}?" +
                $"client_id={OAuth2Config.ClientId}&" +
                $"client_secret={OAuth2Config.ClientSecret}&" +
                $"redirect_uri={OAuth2Config.RedirectUri}&" +
                $"response_type=code&" +
                $"scope=launch&" +
                $"state=abcdefghijk&" +
                $"code_challenge={codeChallenge}&" +
                $"code_challenge_method=S256";
            navigation.NavigateTo(uri, true);
        }
    }
}

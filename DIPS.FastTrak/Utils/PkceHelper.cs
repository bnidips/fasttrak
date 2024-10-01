namespace DIPS.FastTrak.Utils;

using System;
using System.Security.Cryptography;
using System.Text;

public class PkceHelper
{
    public static string GenerateCodeChallenge(string codeVerifier)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] codeVerifierBytes = Encoding.ASCII.GetBytes(codeVerifier);
            byte[] hashBytes = sha256.ComputeHash(codeVerifierBytes);
            return Base64UrlEncode(hashBytes);
        }
    }

    public static string GenerateCodeVerifier()
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] randomBytes = new byte[32];
            rng.GetBytes(randomBytes);
            return Base64UrlEncode(randomBytes);
        }
    }

    private static string Base64UrlEncode(byte[] input)
    {
        return Convert.ToBase64String(input)
            .TrimEnd('=')
            .Replace('+', '-')
            .Replace('/', '_');
    }
}

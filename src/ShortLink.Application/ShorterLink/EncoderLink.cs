using System;
using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;

namespace ShortLink.Application.ShorterLink
{
    public static class EncoderLink
    {
        public static string Encode(string link)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(link));
                string base64Hash = Convert.ToBase64String(hashBytes);
                string safeHash = base64Hash.Replace("+", "-").Replace("/", "_").Replace("=", "");
                return safeHash.Substring(0, 8);
            }
        }
    }
}

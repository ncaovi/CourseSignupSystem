using CourseSignupSystem.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CourseSignupSystem.Helpers
{
    public class EncodeHelper : IEncode
    {
        public string Encode(string source)
        {
            string hash = "";
            using (var md5Hash = MD5.Create())
            {
                var sourceBytes = Encoding.UTF8.GetBytes(source);
                var hashBytes = md5Hash.ComputeHash(sourceBytes);
                hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
            return hash;
        }
    }
}

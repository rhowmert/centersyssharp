using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace helpers
{
    public static class MD5Helper
    {
        public static string ConvertToMD5(string input)
        {            
            using (MD5 md5 = MD5.Create())
            {        
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
             
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mambo.BusinessManagement
{
    public class Security
    {
        public static string GenerateHash(string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }
    }
}
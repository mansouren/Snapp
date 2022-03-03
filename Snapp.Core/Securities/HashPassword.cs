using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.Securities
{
   public static class HashPassword
    {
        //Hashing Password twice for more security
        public static string GetHashPassword(string password)
        {
            byte[] mainbyte;
            byte[] encodebyte;
            MD5 md5 = new MD5CryptoServiceProvider();
            mainbyte = ASCIIEncoding.Default.GetBytes(password); //encrypt password for the first time
            encodebyte = md5.ComputeHash(mainbyte); //encrypt password for the second time
            return BitConverter.ToString(encodebyte); //bitconverter convert hashpassword to string and string to hashpassword
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace core_api.Helpers
{
    public class PasswordHashing
    {
        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        private static readonly int SaltSize = 16;
        private static readonly int HashSize = 20;

        private static readonly int Iteration = 10000;

        public static string HashPasswword(string password){
            byte[] salt;;
            rng.GetBytes(salt = new byte[SaltSize]);
            var key= new Rfc2898DeriveBytes(password,salt,Iteration);
            var hash = key.GetBytes(HashSize);

            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt,0,hashBytes,0,SaltSize);
            Array.Copy(hash,0,hashBytes,SaltSize,HashSize);

            var base64Hash = Convert.ToBase64String(hashBytes);


            return base64Hash;

        }
        public static bool verifyPassword(){
            
        }

        
    }
}
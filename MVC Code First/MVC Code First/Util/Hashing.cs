using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MVC_Code_First.Util
{
    public class Hashing
    {
        private static string getRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(10);
        }

        public static string hashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, getRandomSalt());
        }

        public static bool validatePassword(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }
    }
}
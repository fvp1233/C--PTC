using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.Helper
{
    internal class SessionVar
    {
        private static string username = string.Empty;
        private static string access = string.Empty;
        private static string fullName = string.Empty;
        private static string password = string.Empty;
        private static byte[] profilePic;
        private static string email = string.Empty;
        private static string phone = string.Empty;
        private static string charge = string.Empty;
        private static string bussinesP = string.Empty;
        private static int idBussinesP = 0;

        public static string Username { get => username; set => username = value; }
        public static string Access { get => access; set => access = value; }
        public static string FullName { get => fullName; set => fullName = value; }
        public static string Password { get => password; set => password = value; }
        public static int IdBussinesP { get => idBussinesP; set => idBussinesP = value; }
        public static byte[] ProfilePic { get => profilePic; set => profilePic = value; }
        public static string Email { get => email; set => email = value; }
        public static string Phone { get => phone; set => phone = value; }
        public static string Charge { get => charge; set => charge = value; }
        public static string BussinesP { get => bussinesP; set => bussinesP = value; }
    }
}

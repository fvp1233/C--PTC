using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.LogInDTO
{
    internal class DTOLogin: dbContext
    {
        private string username;
        private string password;
        private int userStatus;
        private string token;
        private DateTime tokenExpiry;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int UserStatus { get => userStatus; set => userStatus = value; }
        public string Token { get => token; set => token = value; }
        public DateTime TokenExpiry { get => tokenExpiry; set => tokenExpiry = value; }
    }
}

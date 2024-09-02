using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.HelperDTO
{
    internal class DTOInitialView : dbContext
    {
        //Atributos
        private string token;
        private DateTime tokenExpiry;
        private string username;
        private DateTime currentDate;

        //getters y setters
        public string Token { get => token; set => token = value; }
        public DateTime TokenExpiry { get => tokenExpiry; set => tokenExpiry = value; }
        public string Username { get => username; set => username = value; }
        public DateTime CurrentDate { get => currentDate; set => currentDate = value; }
    }
}

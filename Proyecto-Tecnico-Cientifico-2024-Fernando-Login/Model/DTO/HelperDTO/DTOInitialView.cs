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

        private string actionType;
        private string tableName;
        private string actionBy;
        private DateTime actionDate;
        //getters y setters
        public string Token { get => token; set => token = value; }
        public DateTime TokenExpiry { get => tokenExpiry; set => tokenExpiry = value; }
        public string Username { get => username; set => username = value; }
        public DateTime CurrentDate { get => currentDate; set => currentDate = value; }
        public string ActionType { get => actionType; set => actionType = value; }
        public string TableName { get => tableName; set => tableName = value; }
        public string ActionBy { get => actionBy; set => actionBy = value; }
        public DateTime ActionDate { get => actionDate; set => actionDate = value; }
    }
}

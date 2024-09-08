using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.ProfileDTO
{
    internal class DTOChangeUserPass : dbContext
    {
        private string username;
        private string actualPass;
        private string newPass;

        public string Username { get => username; set => username = value; }
        public string ActualPass { get => actualPass; set => actualPass = value; }
        public string NewPass { get => newPass; set => newPass = value; }
    }
}

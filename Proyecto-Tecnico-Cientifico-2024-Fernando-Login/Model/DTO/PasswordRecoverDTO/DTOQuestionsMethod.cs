using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.PasswordRecoverDTO
{
    internal class DTOQuestionsMethod : dbContext
    {
        //Atributos 
        private string username;

        //método getter y setter
        public string Username { get => username; set => username = value; }
    }
}

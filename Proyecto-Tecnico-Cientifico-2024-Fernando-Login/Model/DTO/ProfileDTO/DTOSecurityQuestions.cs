using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.ProfileDTO
{
    internal class DTOSecurityQuestions : dbContext
    {
        //Atributos
        private string username;
        private string firstQ;
        private string secondQ;
        private string thirdQ;

        //metodos getter y setter
        public string Username { get => username; set => username = value; }
        public string FirstQ { get => firstQ; set => firstQ = value; }
        public string SecondQ { get => secondQ; set => secondQ = value; }
        public string ThirdQ { get => thirdQ; set => thirdQ = value; }

    }
}

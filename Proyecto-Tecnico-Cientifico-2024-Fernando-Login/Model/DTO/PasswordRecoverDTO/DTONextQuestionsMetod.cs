using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.PasswordRecoverDTO
{
    internal class DTONextQuestionsMetod : dbContext
    {
        //Atributos
        private string firstAnswer;
        private string secondAnswer;
        private string thirdAnswer;
        private string username;

        //Métodos getter y setter
        public string FirstAnswer { get => firstAnswer; set => firstAnswer = value; }
        public string SecondAnswer { get => secondAnswer; set => secondAnswer = value; }
        public string ThirdAnswer { get => thirdAnswer; set => thirdAnswer = value; }
        public string Username { get => username; set => username = value; }
    }
}

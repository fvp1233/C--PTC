using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.CustomersDTO
{
<<<<<<< Updated upstream
    internal class DTOUpdateCustomers:dbContext
    {
        private string names;
        private string lastNames;
        private string dui;
        private DateTime birthDate;
        private string address;
        private string email;
        private string phone;
        private int typeC;

        public string Names { get => names; set => names = value; }
        public string LastNames { get => lastNames; set => lastNames = value; }
        public string Dui { get => dui; set => dui = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public int TypeC { get => typeC; set => typeC = value; }
=======
    internal class DTOUpdateCustomers
    {
>>>>>>> Stashed changes
    }
}

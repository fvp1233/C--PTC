using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.CustomersDTO
{
    internal class DTOAddCustomers: dbContext
    {

        //Atributos del formulario addcustomers

        private int idCustomer;
        private string names;
        private string lastnames;
        private string DUI;
        private string address;
        private string email;
        private string phone;
        private int employeeType;

        //Getters y Setters
        public int IdCustomer { get => idCustomer; set => idCustomer = value; }
        public string Names { get => names; set => names = value; }
        public string Lastnames { get => lastnames; set => lastnames = value; }
        public string DUI1 { get => DUI; set => DUI = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public int EmployeeType { get => employeeType; set => employeeType = value; }
    }
}

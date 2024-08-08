using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.CustomersDTO
{
 class DTOCustomers:dbContext
    {
        private int IdCustomer;
        private string DUI;
        private string names;
        private string lastNames;
        private string phone;
        private string email;
        private string address;
        private int IdtypeC;
        private string search;

        public int IdCustomer1 { get => IdCustomer; set => IdCustomer = value; }
        public string DUI1 { get => DUI; set => DUI = value; }
        public string Names { get => names; set => names = value; }
        public string LastNames { get => lastNames; set => lastNames = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public int IdtypeC1 { get => IdtypeC; set => IdtypeC = value; }
        public string Search { get => search; set => search = value; }
    }
}

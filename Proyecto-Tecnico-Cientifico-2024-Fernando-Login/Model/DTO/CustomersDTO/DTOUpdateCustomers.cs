using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.CustomersDTO
{
    class DTOUpdateCustomers : dbContext
    {

        private int idClient;
        private string name;
        private string lastNames;
        private string  dui;
        private string email;
        private string address;
        private string phone;
        private int clientType;


        public int IdClient { get => idClient; set => idClient = value; }
        public string Name { get => name; set => name = value; }
        public string LastNames { get => lastNames; set => lastNames = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public int ClientType { get => clientType; set => clientType = value; }
    }
        
    }
    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.CustomersDTO
{
 class DTOCustomers:dbContext
    {   
        //Atributos 
        private int IdCustomer;
        private string search;

        //Getter y Setters
        public int IdCustomer1 { get => IdCustomer; set => IdCustomer = value; }
        public string Search { get => search; set => search = value; }
    }
}

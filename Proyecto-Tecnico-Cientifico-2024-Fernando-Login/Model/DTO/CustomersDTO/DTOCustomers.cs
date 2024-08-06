using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.CustomersDTO
{
    internal class DTOCustomers: dbContext
    {
       
        private string names;

        
        public string Names { get => names; set => names = value; }
    }
}

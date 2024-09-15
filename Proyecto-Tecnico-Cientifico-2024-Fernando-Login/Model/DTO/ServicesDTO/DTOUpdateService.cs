using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.ServicesDTO
{
    internal class DTOUpdateService : dbContext
    {
        /*Se declaran los atributos*/
        private int serviceId;
        private string name;
        private string description;
        private int category;
        private double amount;

        public int ServiceId { get => serviceId; set => serviceId = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Category { get => category; set => category = value; }
        public double Amount { get => amount; set => amount = value; }
    }
}

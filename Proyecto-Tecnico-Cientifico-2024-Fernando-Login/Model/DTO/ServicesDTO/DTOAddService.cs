using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.ServicesDTO
{
    internal class DTOAddService : dbContext
    {
        /*Se declaran los atributos*/
        private string name;
        private string description;
        private int category;
        private int cuatomer;
        private double amount;

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Category { get => category; set => category = value; }
        public int Cuatomer { get => cuatomer; set => cuatomer = value; }
        public double Amount { get => amount; set => amount = value; }
    }
}

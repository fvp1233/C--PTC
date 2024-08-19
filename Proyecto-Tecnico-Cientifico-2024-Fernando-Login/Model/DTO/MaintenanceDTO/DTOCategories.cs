using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.MaintenanceDTO
{
    internal class DTOCategories : dbContext
    {
        //Atributos
        private string category;
        private int idCategory;

        //método getter y setter
        public string Category { get => category; set => category = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
    }
}

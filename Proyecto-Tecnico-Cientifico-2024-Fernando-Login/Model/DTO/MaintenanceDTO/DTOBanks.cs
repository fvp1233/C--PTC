using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.MaintenanceDTO
{
    internal class DTOBanks : dbContext
    {
        //Atributos
        private string bank;
        private int idBank;

        //Getters y setters
        public string Bank { get => bank; set => bank = value; }
        public int IdBank { get => idBank; set => idBank = value; }
    }
}

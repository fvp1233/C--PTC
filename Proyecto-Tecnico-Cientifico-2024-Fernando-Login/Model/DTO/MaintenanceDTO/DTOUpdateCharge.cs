using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.MaintenanceDTO
{
    internal class DTOUpdateCharge: dbContext
    {
        private int idCharge;
        private string nameCharge;
        private double bonusCharge;

        public int IdCharge { get => idCharge; set => idCharge = value; }
        public string NameCharge { get => nameCharge; set => nameCharge = value; }
        public double BonusCharge { get => bonusCharge; set => bonusCharge = value; }
    }
}

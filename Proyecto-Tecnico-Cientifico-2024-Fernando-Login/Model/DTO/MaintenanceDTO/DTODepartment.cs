using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.MaintenanceDTO
{
    internal class DTODepartment:dbContext
    {
        private int idDepartment;
        private string department;
        public int IdDepartment { get => idDepartment; set => idDepartment = value; }
        public string Department { get => department; set => department = value; }
    }
}

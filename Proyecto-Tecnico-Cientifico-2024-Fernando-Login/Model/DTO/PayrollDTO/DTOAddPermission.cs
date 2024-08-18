using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.PayrollDTO
{
    internal class DTOAddPermission : dbContext
    {
        //Tipo de permiso
        private int idTypePermission;
        private string typePermission;
        //Tipo de estado
        private int idStatusPermission;
        private string statusPermission;
        //Permisos
        private int idPermission;
        private DateTime start;
        private DateTime end;
        private string context;
        private int idEmployee;

        public int IdTypePermission { get => idTypePermission; set => idTypePermission = value; }
        public string TypePermission { get => typePermission; set => typePermission = value; }
        public int IdStatusPermission { get => idStatusPermission; set => idStatusPermission = value; }
        public string StatusPermission { get => statusPermission; set => statusPermission = value; }
        public int IdPermission { get => idPermission; set => idPermission = value; }
        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }
        public string Context { get => context; set => context = value; }
        public int IdEmployee { get => idEmployee; set => idEmployee = value; }
    }
}

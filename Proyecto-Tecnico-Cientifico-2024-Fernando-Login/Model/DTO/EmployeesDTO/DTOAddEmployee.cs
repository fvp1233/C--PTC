using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO
{
    internal class DTOAddEmployee : dbContext
    {
        //Atributos de FrmAddEmployee
        private string nombres;
        private string apellidos;
        private string documento;
        private DateTime nacimiento;
        private string direccion;
        private string telefono;
        private string email;
        private int estadoCivil;
        private int departamento;
        private int tipoEmpleado;
        private int puestoEmpleado;
        private int estadoEmpleado;

        //Getters y setters
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Documento { get => documento; set => documento = value; }
        public DateTime Nacimiento { get => nacimiento; set => nacimiento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public int EstadoCivil { get => estadoCivil; set => estadoCivil = value; }
        public int Departamento { get => departamento; set => departamento = value; }
        public int TipoEmpleado { get => tipoEmpleado; set => tipoEmpleado = value; }
        public int PuestoEmpleado { get => puestoEmpleado; set => puestoEmpleado = value; }
        public int EstadoEmpleado { get => estadoEmpleado; set => estadoEmpleado = value; }
    }
}

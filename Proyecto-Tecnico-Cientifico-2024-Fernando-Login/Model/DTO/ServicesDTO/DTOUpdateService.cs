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
        private string nombre;
        private string descripcion;
        private int categoria;
        private int cliente;
        private double monto;

        public int ServiceId { get => serviceId; set => serviceId = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Categoria { get => categoria; set => categoria = value; }
        public int Cliente { get => cliente; set => cliente = value; }
        public double Monto { get => monto; set => monto = value; }
    }
}

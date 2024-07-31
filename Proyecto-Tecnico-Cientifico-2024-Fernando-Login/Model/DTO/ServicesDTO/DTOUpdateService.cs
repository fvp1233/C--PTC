using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.ServicesDTO
{
    internal class DTOUpdateService : dbContext
    {
        string nombre;
        string descripcion;
        int categoria;
        double monto;
        int serviceId;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Categoria { get => categoria; set => categoria = value; }
        public double Monto { get => monto; set => monto = value; }
        public int ServiceId { get => serviceId; set => serviceId = value; }
    }
}

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
        string nombre;
        string descripcion;
        int categorias;
        double monto;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Categorias { get => categorias; set => categorias = value; }
        public double Monto { get => monto; set => monto = value; }
    }
}

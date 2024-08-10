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
        private string nombre;
        private string descripcion;
        private int categorias;
        private int cliente;
        private double monto;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Categorias { get => categorias; set => categorias = value; }
        public int Cliente { get => cliente; set => cliente = value; }
        public double Monto { get => monto; set => monto = value; }
    }
}

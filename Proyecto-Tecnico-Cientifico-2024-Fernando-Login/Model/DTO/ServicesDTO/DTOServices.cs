using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.ServicesDTO
{
    internal class DTOServices : dbContext
    {

        /*Atributo para eliminar el servicio*/
        int IdService;

        public int IdService1 { get => IdService; set => IdService = value; }


        /*Atributo para buscar el servicio*/
        string Search;

        public string Search1 { get => Search; set => Search = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.ServicesDTO
{
    internal class DTOServices : dbContext
    {
        /*Atributos de delete*/
        private int IdService;

        public int IdService1 { get => IdService; set => IdService = value; }

        /*Atributos del search*/

        private string Search;

        public string Search1 { get => Search; set => Search = value; }
    }
}

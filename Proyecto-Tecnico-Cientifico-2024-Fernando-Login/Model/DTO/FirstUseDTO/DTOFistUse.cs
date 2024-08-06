using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.FirstUseDTO
{
    internal class DTOFistUse : dbContext
    {
        private int idBusiness;
        private string nameBusiness;
        private string addressBusiness;
        private string emailBusiness;
        private DateTime dateBusiness;
        private string phoneBusiness;
        private string pbxBusiness;
        private byte[] imageBusiness;

        public int IdBusiness { get => idBusiness; set => idBusiness = value; }
        public string NameBusiness { get => nameBusiness; set => nameBusiness = value; }
        public string AddressBusiness { get => addressBusiness; set => addressBusiness = value; }
        public string EmailBusiness { get => emailBusiness; set => emailBusiness = value; }
        public DateTime DateBusiness { get => dateBusiness; set => dateBusiness = value; }
        public string PhoneBusiness { get => phoneBusiness; set => phoneBusiness = value; }
        public string PbxBusiness { get => pbxBusiness; set => pbxBusiness = value; }
        public byte[] ImageBusiness { get => imageBusiness; set => imageBusiness = value; }
    }
}

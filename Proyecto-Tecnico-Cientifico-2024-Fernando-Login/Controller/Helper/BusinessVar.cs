using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.Helper
{
    internal class BusinessVar
    {
        private static int idBusiness = 0;
        private static string businessName = string.Empty;
        private static string businessAdress = string.Empty;
        private static string businessEmail = string.Empty;
        private static string businessPhone = string.Empty;
        private static string businessPBX = string.Empty;
        private static byte[] businessImg;

        public static int IdBusiness { get => idBusiness; set => idBusiness = value; }
        public static string BusinessName { get => businessName; set => businessName = value; }
        public static string BusinessAdress { get => businessAdress; set => businessAdress = value; }
        public static string BusinessEmail { get => businessEmail; set => businessEmail = value; }
        public static string BusinessPhone { get => businessPhone; set => businessPhone = value; }
        public static string BusinessPBX { get => businessPBX; set => businessPBX = value; }
        public static byte[] BusinessImg { get => businessImg; set => businessImg = value; }
    }
}

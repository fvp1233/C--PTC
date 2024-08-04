using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.BillsDTO
{
    internal class DTOBills : dbContext
    {
        //TABLE BILLS
        private int IdBill;
        private string companyName;
        private string NIT;
        private string NRC;
        private float discount;
        private float subtotalPay;
        private float totalPay;
        private DateTime startDate;
        private DateTime FinalDate;
        private string services;
        private string statusBills;
        private string customer;
        private string employee;
        private string methodP;
        private DateTime fiscalPeriod;
        //TABLE BILL DETAIL
        private int IdDetail;
        private int IdServices;
        private float Price;
        //TABLE FISCAL PERIOD
        private int IdfiscalPeriod;

        public int IdBill1 { get => IdBill; set => IdBill = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime FinalDate1 { get => FinalDate; set => FinalDate = value; }
        public DateTime FiscalPeriod { get => fiscalPeriod; set => fiscalPeriod = value; }
        public int IdDetail1 { get => IdDetail; set => IdDetail = value; }
        public int IdfiscalPeriod1 { get => IdfiscalPeriod; set => IdfiscalPeriod = value; }
        public string NIT1 { get => NIT; set => NIT = value; }
        public string NRC1 { get => NRC; set => NRC = value; }
        public string Services { get => services; set => services = value; }
        public string StatusBills { get => statusBills; set => statusBills = value; }
        public string Customer { get => customer; set => customer = value; }
        public string Employee { get => employee; set => employee = value; }
        public string MethodP { get => methodP; set => methodP = value; }
        public int IdServices1 { get => IdServices; set => IdServices = value; }
        public float Price1 { get => Price; set => Price = value; }
        public float Discount { get => discount; set => discount = value; }
        public float SubtotalPay { get => subtotalPay; set => subtotalPay = value; }
        public float TotalPay { get => totalPay; set => totalPay = value; }
    }
}
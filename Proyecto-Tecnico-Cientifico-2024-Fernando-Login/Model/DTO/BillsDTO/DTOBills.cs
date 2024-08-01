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
        private int NIT;
        private int NRC;
        private double discount;
        private double subtotalPay;
        private double totalPay;
        private DateTime startDate;
        private DateTime FinalDate;
        private int services;
        private int statusBills;
        private int customer;
        private int employee;
        private int methodP;
        private DateTime fiscalPeriod;
        //TABLE BILL DETAIL
        private int IdDetail;
        private int IdServices;
        //TABLE FISCAL PERIOD
        private int IdfiscalPeriod;

        public int IdBill1 { get => IdBill; set => IdBill = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public int NIT1 { get => NIT; set => NIT = value; }
        public int NRC1 { get => NRC; set => NRC = value; }
        public double Discount { get => discount; set => discount = value; }
        public double SubtotalPay { get => subtotalPay; set => subtotalPay = value; }
        public double TotalPay { get => totalPay; set => totalPay = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime FinalDate1 { get => FinalDate; set => FinalDate = value; }
        public int Services { get => services; set => services = value; }
        public int StatusBills { get => statusBills; set => statusBills = value; }
        public int Customer { get => customer; set => customer = value; }
        public int Employee { get => employee; set => employee = value; }
        public int MethodP { get => methodP; set => methodP = value; }
        public DateTime FiscalPeriod { get => fiscalPeriod; set => fiscalPeriod = value; }
        public int IdDetail1 { get => IdDetail; set => IdDetail = value; }
        public int IdServices1 { get => IdServices; set => IdServices = value; }
        public int IdfiscalPeriod1 { get => IdfiscalPeriod; set => IdfiscalPeriod = value; }
    }
}

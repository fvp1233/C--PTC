using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        private double discount;
        private double subtotalPay;
        private double totalPay;
        private DateTime startDate;
        private DateTime FinalDate;
        private DateTime dateissued;
        private string services;
        private string statusBills;
        private string customer;
        private string employee;
        //NOMBRE DEL EMPLEADO
        private int IdEmployee;
        private string EmployeeName;
        private string methodP;
        private string CustomerDui;
        private string CustomerPhone;
        private string CustomerEmail;
        private string CustomerName;
        //TABLE BILL DETAIL
        private int IdDetail;
        private int IdServices;
        private float Price;
        //TABLE FISCAL PERIOD
        private int IdfiscalPeriod;
        //FILTRAR DATOS DE CLIENTES
        private int IdCustomer;
        private string DUI;
        private string names;
        private string lastNames;
        private string phone;
        private string email;
        //BUSQUEDA
        private string search;
        //DATOS DE USUARIO
        private string username;
        private string password;
        private int userStatus;
        private int IdBussinessP;
        private bool temporalpassword;
        private string SearchB;

        public int IdBill1 { get => IdBill; set => IdBill = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime FinalDate1 { get => FinalDate; set => FinalDate = value; }
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
        public DateTime Dateissued { get => dateissued; set => dateissued = value; }
        public int IdCustomer1 { get => IdCustomer; set => IdCustomer = value; }
        public string DUI1 { get => DUI; set => DUI = value; }
        public string Names { get => names; set => names = value; }
        public string LastNames { get => lastNames; set => lastNames = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Search { get => search; set => search = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int UserStatus { get => userStatus; set => userStatus = value; }
        public string CustomerDui1 { get => CustomerDui; set => CustomerDui = value; }
        public string CustomerPhone1 { get => CustomerPhone; set => CustomerPhone = value; }
        public string CustomerEmail1 { get => CustomerEmail; set => CustomerEmail = value; }
        public string CustomerName1 { get => CustomerName; set => CustomerName = value; }
        public double Discount { get => discount; set => discount = value; }
        public double SubtotalPay { get => subtotalPay; set => subtotalPay = value; }
        public double TotalPay { get => totalPay; set => totalPay = value; }
        public string SearchB1 { get => SearchB; set => SearchB = value; }
        public int IdBussinessP1 { get => IdBussinessP; set => IdBussinessP = value; }
        public string EmployeeName1 { get => EmployeeName; set => EmployeeName = value; }
        public int IdEmployee1 { get => IdEmployee; set => IdEmployee = value; }
        public bool Temporalpassword { get => temporalpassword; set => temporalpassword = value; }
    }
}
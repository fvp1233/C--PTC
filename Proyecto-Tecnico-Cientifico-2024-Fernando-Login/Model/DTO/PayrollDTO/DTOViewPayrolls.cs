using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.PayrollDTO
{
    internal class DTOViewPayrolls : dbContext
    {
        //EMPLEADO INFO
        private int idEmployee;
        private string firstName;
        private string lastName;
        private string dui;
        private DateTime birthDate;
        private string email;
        private string phone;
        private string address;
        private float salary;
        private string securityNumber;
        private string banckAccount;
        private string username;
        private int departmentId;
        private int typeEmployeeId;
        private int maritalStatusId;
        private int statusId;
        //Cargos
        private int BusinessId;
        private string businessPossition;
        private float businessBonus;
        //Planilla
        private int idPayroll;
        private double isss;
        private double afp;
        private double rent;
        private double netPay;
        private double isssEmployer;
        private double afpEmployer;
        private double discountEmployee;
        private double discountEmployer;
        private DateTime issueDate;
        private double christmasBonus;
        private int daysWorked;
        private double daySalary;
        private double gossSalary;
        private int hoursWorked;
        private double hourSalary;
        //Estatus de planilla
        private int idPayrollStatus;
        private int statusPayroll;
        //Tipo de permiso
        private int idTypePermission;
        private string typePermission;
        //Tipo de estado
        private int idStatusPermission;
        private string statusPermission;
        //Permisos
        private int idPermission;
        private DateTime start;
        private DateTime end;
        private string context;

        public int IdEmployee { get => idEmployee; set => idEmployee = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Dui { get => dui; set => dui = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public float Salary { get => salary; set => salary = value; }
        public string Username { get => username; set => username = value; }
        public int DepartmentId { get => departmentId; set => departmentId = value; }
        public int TypeEmployeeId { get => typeEmployeeId; set => typeEmployeeId = value; }
        public int MaritalStatusId { get => maritalStatusId; set => maritalStatusId = value; }
        public int StatusId { get => statusId; set => statusId = value; }
        public int IdPayroll { get => idPayroll; set => idPayroll = value; }
        public string SecurityNumber { get => securityNumber; set => securityNumber = value; }
        public double Isss { get => isss; set => isss = value; }
        public double Afp { get => afp; set => afp = value; }
        public double Rent { get => rent; set => rent = value; }
        public double NetPay { get => netPay; set => netPay = value; }
        public string BanckAccount { get => banckAccount; set => banckAccount = value; }
        public DateTime IssueDate { get => issueDate; set => issueDate = value; }
        public int BusinessId1 { get => BusinessId; set => BusinessId = value; }
        public string BusinessPossition { get => businessPossition; set => businessPossition = value; }
        public float BusinessBonus { get => businessBonus; set => businessBonus = value; }
        public double IsssEmployer { get => isssEmployer; set => isssEmployer = value; }
        public double AfpEmployer { get => afpEmployer; set => afpEmployer = value; }
        public double DiscountEmployee { get => discountEmployee; set => discountEmployee = value; }
        public double DiscountEmployer { get => discountEmployer; set => discountEmployer = value; }
        public int IdPayrollStatus { get => idPayrollStatus; set => idPayrollStatus = value; }
        public int StatusPayroll { get => statusPayroll; set => statusPayroll = value; }
        public double ChristmasBonus { get => christmasBonus; set => christmasBonus = value; }
        public int DaysWorked { get => daysWorked; set => daysWorked = value; }
        public double DaySalary { get => daySalary; set => daySalary = value; }
        public double GossSalary { get => gossSalary; set => gossSalary = value; }
        public int IdTypePermission { get => idTypePermission; set => idTypePermission = value; }
        public string TypePermission { get => typePermission; set => typePermission = value; }
        public int IdStatusPermission { get => idStatusPermission; set => idStatusPermission = value; }
        public string StatusPermission { get => statusPermission; set => statusPermission = value; }
        public int IdPermission { get => idPermission; set => idPermission = value; }
        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }
        public string Context { get => context; set => context = value; }
        public int HoursWorked { get => hoursWorked; set => hoursWorked = value; }
        public double HourSalary { get => hourSalary; set => hourSalary = value; }
    }
}

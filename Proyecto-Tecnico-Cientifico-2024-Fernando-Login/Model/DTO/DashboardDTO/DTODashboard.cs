using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.DashboardDTO
{
    internal class DTODashboard : dbContext
    {
        public struct PayrollsByDate
        {
            private string date;
            private decimal totalAmount;

            public string Date { get => date; set => date = value; }
            public decimal TotalAmount { get => totalAmount; set => totalAmount = value; }
        }
        //EMPLOYEE
        private int idEmployee;
        private string names;
        private string lastNames;
        private string document;
        private DateTime birthDate;
        private string email;
        private string phone;
        private string address;
        private double salary;
        private string bankAccount;
        private DateTime hireDate;
        private string affiliationNumber;
        private int department;
        private int employeeType;
        private int maritalStatus;
        private int employeeStatus;
        private int bank;
        //PAYROLL
        private int idPayroll;
        private double isss;
        private double afp;
        private double rent;
        private decimal netPay;
        private double isssEmployer;
        private double afpEmployer;
        private double discountEmployee;
        private double discountEmployer;
        private DateTime issueDate;
        private double christmasBonus;
        private int daysWorked;
        private double daySalary;
        private double gossSalary;
        //Estatus de planilla
        private int idPayrollStatus;
        private int statusPayroll;
        //OTHERS
        private int numberEmployee;
        private int numberServices;
        private int numberCostumers;
        private int numberBills;
        private DateTime fromDate;
        private DateTime toDate;
        private List<PayrollsByDate>payrollsList;

        //EMPLOYEE
        public int IdEmployee { get => idEmployee; set => idEmployee = value; }
        public string Names { get => names; set => names = value; }
        public string LastNames { get => lastNames; set => lastNames = value; }
        public string Document { get => document; set => document = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public double Salary { get => salary; set => salary = value; }
        public string BankAccount { get => bankAccount; set => bankAccount = value; }
        public DateTime HireDate { get => hireDate; set => hireDate = value; }
        public string AffiliationNumber { get => affiliationNumber; set => affiliationNumber = value; }
        public int Department { get => department; set => department = value; }
        public int EmployeeType { get => employeeType; set => employeeType = value; }
        public int MaritalStatus { get => maritalStatus; set => maritalStatus = value; }
        public int EmployeeStatus { get => employeeStatus; set => employeeStatus = value; }
        public int Bank { get => bank; set => bank = value; }
        //EMPLOYEE

        //OTHERS
        public int NumberEmployee { get => numberEmployee; set => numberEmployee = value; }
        public int NumberServices { get => numberServices; set => numberServices = value; }
        public int NumberBills { get => numberBills; set => numberBills = value; }
        public int NumberCostumers { get => numberCostumers; set => numberCostumers = value; }
        public DateTime FromDate { get => fromDate; set => fromDate = value; }
        public DateTime ToDate { get => toDate; set => toDate = value; }
        internal List<PayrollsByDate> PayrollsList { get => payrollsList; set => payrollsList = value; }
        //OTHERS

        //PAYROLL
        public int IdPayroll { get => idPayroll; set => idPayroll = value; }
        public double Isss { get => isss; set => isss = value; }
        public double Afp { get => afp; set => afp = value; }
        public double Rent { get => rent; set => rent = value; }
        public decimal NetPay { get => netPay; set => netPay = value; }
        public double IsssEmployer { get => isssEmployer; set => isssEmployer = value; }
        public double AfpEmployer { get => afpEmployer; set => afpEmployer = value; }
        public double DiscountEmployee { get => discountEmployee; set => discountEmployee = value; }
        public double DiscountEmployer { get => discountEmployer; set => discountEmployer = value; }
        public DateTime IssueDate { get => issueDate; set => issueDate = value; }
        public double ChristmasBonus { get => christmasBonus; set => christmasBonus = value; }
        public int DaysWorked { get => daysWorked; set => daysWorked = value; }
        public double DaySalary { get => daySalary; set => daySalary = value; }
        public double GossSalary { get => gossSalary; set => gossSalary = value; }
        public int IdPayrollStatus { get => idPayrollStatus; set => idPayrollStatus = value; }
        public int StatusPayroll { get => statusPayroll; set => statusPayroll = value; }
        //PAYROLL

    }
}

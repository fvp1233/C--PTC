using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.PayrollDTO
{
    internal class DTOAddPayroll : dbContext
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
        private string username;
        private int departmentId;
        private int typeEmployeeId;
        private int maritalStatusId;
        private int statusId;
        //Planilla
        private int idPayroll;
        private string securityNumber;
        private float grossPay;
        private float iss;
        private float afp;
        private float income;
        private float netPay;
        private string banckAccount;
        private DateTime issueDate;
        public string SecurityNumber { get => securityNumber; set => securityNumber = value; }
        public float GrossPay { get => grossPay; set => grossPay = value; }
        public float Iss { get => iss; set => iss = value; }
        public float Afp { get => afp; set => afp = value; }
        public float Income { get => income; set => income = value; }
        public float NetPay { get => netPay; set => netPay = value; }
        public string BanckAccount { get => banckAccount; set => banckAccount = value; }
        public DateTime IssueDate { get => issueDate; set => issueDate = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int IdEmployee { get => idEmployee; set => idEmployee = value; }
        public int IdPayroll { get => idPayroll; set => idPayroll = value; }
        public string Dui { get => dui; set => dui = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string Email { get => email; set => email = value; }
        public float Salary { get => salary; set => salary = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Username { get => username; set => username = value; }
        public int DepartmentId { get => departmentId; set => departmentId = value; }
        public int DepartmentId1 { get => departmentId; set => departmentId = value; }
        public int TypeEmployeeId { get => typeEmployeeId; set => typeEmployeeId = value; }
        public int MaritalStatusId { get => maritalStatusId; set => maritalStatusId = value; }
        public int StatusId { get => statusId; set => statusId = value; }
    }
}

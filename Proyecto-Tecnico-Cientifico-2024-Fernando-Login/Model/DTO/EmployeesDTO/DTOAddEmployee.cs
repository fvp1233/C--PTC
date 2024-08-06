using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO
{
    internal class DTOAddEmployee : dbContext
    {
        //Atributos de FrmAddEmployee
        //TABLA tbmployees
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

        //TABLA tbUserData
        private string username;
        private string password;
        private int businessPosition;
        private bool userSatus;

        //métodos getters y setters
        public string Names { get => names; set => names = value; }
        public string LastNames { get => lastNames; set => lastNames = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public double Salary { get => salary; set => salary = value; }
        public string BankAccount { get => bankAccount; set => bankAccount = value; }
        public string AffiliationNumber { get => affiliationNumber; set => affiliationNumber = value; }
        public int Department { get => department; set => department = value; }
        public int EmployeeType { get => employeeType; set => employeeType = value; }
        public int MaritalStatus { get => maritalStatus; set => maritalStatus = value; }
        public int EmployeeStatus { get => employeeStatus; set => employeeStatus = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int BusinessPosition { get => businessPosition; set => businessPosition = value; }
        public string Document { get => document; set => document = value; }
        public DateTime HireDate { get => hireDate; set => hireDate = value; }
        public int Bank { get => bank; set => bank = value; }
        public int IdEmployee { get => idEmployee; set => idEmployee = value; }
        public bool UserSatus { get => userSatus; set => userSatus = value; }
    }
}

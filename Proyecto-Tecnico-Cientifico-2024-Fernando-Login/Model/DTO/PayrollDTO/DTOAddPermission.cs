using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.PayrollDTO
{
    internal class DTOAddPermission : dbContext
    {
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
        private int gender;

        public int IdTypePermission { get => idTypePermission; set => idTypePermission = value; }
        public string TypePermission { get => typePermission; set => typePermission = value; }
        public int IdStatusPermission { get => idStatusPermission; set => idStatusPermission = value; }
        public string StatusPermission { get => statusPermission; set => statusPermission = value; }
        public int IdPermission { get => idPermission; set => idPermission = value; }
        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }
        public string Context { get => context; set => context = value; }
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
        public int Gender { get => gender; set => gender = value; }
    }
}

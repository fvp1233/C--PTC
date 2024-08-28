using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.ProfileDTO
{
    internal class DTOProfile : dbContext
    {
        //USER INFO
        private byte[] profilePicture;
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

        public int IdEmployee { get => idEmployee; set => idEmployee = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Dui { get => dui; set => dui = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public float Salary { get => salary; set => salary = value; }
        public string SecurityNumber { get => securityNumber; set => securityNumber = value; }
        public string BanckAccount { get => banckAccount; set => banckAccount = value; }
        public string Username { get => username; set => username = value; }
        public int DepartmentId { get => departmentId; set => departmentId = value; }
        public int TypeEmployeeId { get => typeEmployeeId; set => typeEmployeeId = value; }
        public int MaritalStatusId { get => maritalStatusId; set => maritalStatusId = value; }
        public int StatusId { get => statusId; set => statusId = value; }
        public int BusinessId1 { get => BusinessId; set => BusinessId = value; }
        public string BusinessPossition { get => businessPossition; set => businessPossition = value; }
        public float BusinessBonus { get => businessBonus; set => businessBonus = value; }
        public byte[] ProfilePicture { get => profilePicture; set => profilePicture = value; }
    }
}

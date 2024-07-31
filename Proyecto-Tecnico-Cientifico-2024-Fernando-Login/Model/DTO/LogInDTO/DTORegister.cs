using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.LogInDTO
{
    internal class DTORegister : dbContext
    {
        //Atributos del formulario Register
        private string names;
        private string lastnames;
        private DateTime birth;
        private string email;
        private string DUI;
        private string phone;
        private string address;
        private string user;
        private string password;
        private string confirmPassword;
        private int businessP;
        private int department;
        private int typeE;
        private int maritalStatus;
        private int status;
        private float salary;
        private int bankType;
        private int affiliationNumber;
        private string bankAccount;
        private DateTime hireDate;
     

        //Getter y Settersde los atributos
        public string Names { get => names; set => names = value; }
        public string Lastnames { get => lastnames; set => lastnames = value; }
        
        public string Email { get => email; set => email = value; }
        public string DUI1 { get => DUI; set => DUI = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
        public int BusinessP { get => businessP; set => businessP = value; }
        public DateTime Birth { get => birth; set => birth = value; }
        public int Department { get => department; set => department = value; }
        public int TypeE { get => typeE; set => typeE = value; }
        public int MaritalStatus { get => maritalStatus; set => maritalStatus = value; }
        public int Status { get => status; set => status = value; }
        public float Salary { get => salary; set => salary = value; }
        public int BankType { get => bankType; set => bankType = value; }
        public int AffiliationNumber { get => affiliationNumber; set => affiliationNumber = value; }
        public string BankAccount { get => bankAccount; set => bankAccount = value; }
        public DateTime HireDate { get => hireDate; set => hireDate = value; }
        
    }
}

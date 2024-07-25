using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.PayrollDTO
{
    internal class DTOAddPayroll : dbContext
    {
        private int idPayroll;
        private string securityNumber;
        private float bonus;
        private float grossPay;
        private float iss;
        private float afp;
        private float income;
        private float netPay;
        private string banckAccount;
        private DateTime issueDate;
        private string firstName;
        private string lastName;
        private int idEmployee;
        public string SecurityNumber { get => securityNumber; set => securityNumber = value; }
        public float Bonus { get => bonus; set => bonus = value; }
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
        public int IdEmployee1 { get => idEmployee; set => idEmployee = value; }
        public int IdPayroll { get => idPayroll; set => idPayroll = value; }
    }
}

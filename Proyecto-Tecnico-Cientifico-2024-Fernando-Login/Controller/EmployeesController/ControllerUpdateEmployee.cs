using PTC2024.Controller.Helper;
using PTC2024.Model.DAO;
using PTC2024.Model.DAO.EmployeesDAO;
using PTC2024.View.Empleados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.EmployeesController
{
    internal class ControllerUpdateEmployee
    {
        FrmUpdateEmployee objUpdateEmployee;
        private string bank;
        private string department;
        private string employeeType;
        private string maritalStatus;
        private string status;
        private string businessP;
        bool emailValidation;
        //CONSTRUCTOR
        public ControllerUpdateEmployee(FrmUpdateEmployee View, int employeeId, string names, string lastNames, string dui, DateTime birthDate, string email, string phone, string address, double salary, string bankAccount, string bank, string affiliationNumber, DateTime hireDate, string department, string employeeType, string maritalStatus, string status, string username, string businessP)
        {
            objUpdateEmployee = View;
            //variables para que los combobox aparezcan seleccionados según los datos del registro
            this.bank = bank;
            this.department = department;
            this.employeeType = employeeType;
            this.maritalStatus = maritalStatus;
            this.status = status;
            this.businessP = businessP;
            //Métodos del formulario
            ChargeValues(employeeId ,names, lastNames, dui, birthDate, email, phone, address, salary, bankAccount, bank, affiliationNumber, hireDate, department, employeeType, maritalStatus, status, username, businessP);
            objUpdateEmployee.Load += new EventHandler(ChargeInfo);
            objUpdateEmployee.BtnCancelar.Click += new EventHandler(CancelProcess);
            objUpdateEmployee.btnEmployeUpdate.Click += new EventHandler(UpdateEmployee);
            objUpdateEmployee.txtSalary.Enter += new EventHandler(EnterSalary);
            objUpdateEmployee.txtSalary.Leave += new EventHandler(LeaveSalary);
            objUpdateEmployee.btnRestorePass.Click += new EventHandler(RestorePassword);

        }

        public void ChargeInfo(object sender, EventArgs e)
        {
            ChargeDropDowns();
        }
        public void CancelProcess(object sender, EventArgs e)
        {
            objUpdateEmployee.Close();
        }

        public void UpdateEmployee(object sender, EventArgs e)
        {
            //Verificación de que todos los campos estén llenos
            if (!(string.IsNullOrEmpty(objUpdateEmployee.txtNames.Text.Trim()) ||
                string.IsNullOrEmpty(objUpdateEmployee.txtLastNames.Text.Trim()) ||
                string.IsNullOrEmpty(objUpdateEmployee.txtDUI.Text.Trim()) ||
                string.IsNullOrEmpty(objUpdateEmployee.txtAddress.Text.Trim()) ||
                string.IsNullOrEmpty(objUpdateEmployee.txtPhone.Text.Trim()) ||
                string.IsNullOrEmpty(objUpdateEmployee.txtEmail.Text.Trim()) ||
                string.IsNullOrEmpty(objUpdateEmployee.txtDUI.Text.Trim()) ||
                objUpdateEmployee.txtSalary.Text.Equals("Ingrese con dos decimales") ||
                string.IsNullOrEmpty(objUpdateEmployee.txtAffiliationNumber.Text.Trim()) ||
                string.IsNullOrEmpty(objUpdateEmployee.txtBankAccount.Text.Trim()) ||
                string.IsNullOrEmpty(objUpdateEmployee.txtUsername.Text.Trim())
                ))
            {
                //validación del dominio del correo 
                emailValidation = ValidateEmail();
                if (emailValidation == true)
                {
                    //CREAMOS OBJETO DEL DAOUpdateEmployees
                    DAOUpdateEmployee daoUpdateEmployee = new DAOUpdateEmployee();
                    daoUpdateEmployee.Names = objUpdateEmployee.txtNames.Text.Trim();
                    daoUpdateEmployee.LastNames = objUpdateEmployee.txtLastNames.Text.Trim();
                    daoUpdateEmployee.Document = objUpdateEmployee.txtDUI.Text.Trim();
                    daoUpdateEmployee.BirthDate = objUpdateEmployee.dtBirthDate.Value;
                    daoUpdateEmployee.Address = objUpdateEmployee.txtAddress.Text.Trim();
                    daoUpdateEmployee.Phone = objUpdateEmployee.txtPhone.Text.Trim();
                    daoUpdateEmployee.Email = objUpdateEmployee.txtEmail.Text.Trim();
                    daoUpdateEmployee.HireDate = objUpdateEmployee.dpHireDate.Value;
                    daoUpdateEmployee.MaritalStatus = (int)objUpdateEmployee.comboMaritalStatus.SelectedValue;
                    daoUpdateEmployee.Department = (int)objUpdateEmployee.comboDepartment.SelectedValue;
                    daoUpdateEmployee.EmployeeType = (int)objUpdateEmployee.comboEmployeeType.SelectedValue;
                    daoUpdateEmployee.EmployeeStatus = (int)objUpdateEmployee.comboEmployeeStatus.SelectedValue;
                    daoUpdateEmployee.Salary = double.Parse(objUpdateEmployee.txtSalary.Text.Trim());
                    daoUpdateEmployee.AffiliationNumber = objUpdateEmployee.txtAffiliationNumber.Text.Trim();
                    daoUpdateEmployee.BankAccount = objUpdateEmployee.txtBankAccount.Text.Trim();
                    daoUpdateEmployee.Bank = (int)objUpdateEmployee.comboBanks.SelectedValue;
                    daoUpdateEmployee.IdEmployee = int.Parse(objUpdateEmployee.txtEmployeeId.Text.Trim());
                    //Datos para los getters de la tabla userData
                    daoUpdateEmployee.Username = objUpdateEmployee.txtUsername.Text.Trim();
                    daoUpdateEmployee.BusinessPosition = (int)objUpdateEmployee.comboBusinessP.SelectedValue;

                    //variable para saber la respuesta del proceso de update en el DAOUpdateEmployees
                    int updateAnswer = daoUpdateEmployee.UpdateEmployee();
                    //la evaluamos
                    if (updateAnswer == 1)
                    {
                        MessageBox.Show("Los datos del empleado han sido actualizados con éxito.", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        objUpdateEmployee.Close();
                    }
                    else
                    {
                        MessageBox.Show("Los datos del empleado no pudieron ser actualizados.", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                }
                
            }
            else
            {
                MessageBox.Show("Existen campos sin llenar.\n Porfavor llene todos los apartados para continuar", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        public void ChargeDropDowns()
        {
            //creando objeto de la clase DAOAddEmployee
            DAOUpdateEmployee daoUpdateEmployee = new DAOUpdateEmployee();

            //Dropdown de Estados civiles
            DataSet dsEstadosCiviles = daoUpdateEmployee.ObtenerEstadosCiviles();
            objUpdateEmployee.comboMaritalStatus.DataSource = dsEstadosCiviles.Tables["tbmaritalStatus"];
            objUpdateEmployee.comboMaritalStatus.DisplayMember = "maritalStatus";
            objUpdateEmployee.comboMaritalStatus.ValueMember = "IdMaritalS";
            //Para que el dropdown tenga seleccionado el dato del registro:
            objUpdateEmployee.comboMaritalStatus.Text = maritalStatus;

            //Dropdown de Departamentos
            DataSet dsDepartamentos = daoUpdateEmployee.ObtenerDepartamentos();
            objUpdateEmployee.comboDepartment.DataSource = dsDepartamentos.Tables["tbDepartment"];
            objUpdateEmployee.comboDepartment.DisplayMember = "departmentName";
            objUpdateEmployee.comboDepartment.ValueMember = "IdDepartment";
            //Para que el dropdown tenga seleccionado el dato del registro:
            objUpdateEmployee.comboDepartment.Text = department;

            //Dropdown de tipos de empleado
            DataSet dsTiposEmpleado = daoUpdateEmployee.ObtenerTiposEmpleado();
            objUpdateEmployee.comboEmployeeType.DataSource = dsTiposEmpleado.Tables["tbTypeE"];
            objUpdateEmployee.comboEmployeeType.DisplayMember = "typeEmployee";
            objUpdateEmployee.comboEmployeeType.ValueMember = "IdTypeE";
            //Para que el dropdown tenga seleccionado el dato del registro:
            objUpdateEmployee.comboEmployeeType.Text = employeeType;

            //Dropdown de puestos de empleado
            DataSet dsPuestosEmpleado = daoUpdateEmployee.ObtenerPuestosEmpleado();
            objUpdateEmployee.comboBusinessP.DataSource = dsPuestosEmpleado.Tables["tbBusinessP"];
            objUpdateEmployee.comboBusinessP.DisplayMember = "businessPosition";
            objUpdateEmployee.comboBusinessP.ValueMember = "IdBusinessP";
            //Para que el dropdown tenga seleccionado el dato del registro:
            objUpdateEmployee.comboBusinessP.Text = businessP;

            //Dropdown de estado de empleado
            DataSet dsEstadosEmpleado = daoUpdateEmployee.ObtenerEstadosEmpleado();
            objUpdateEmployee.comboEmployeeStatus.DataSource = dsEstadosEmpleado.Tables["tbEmployeeStatus"];
            objUpdateEmployee.comboEmployeeStatus.DisplayMember = "employeeStatus";
            objUpdateEmployee.comboEmployeeStatus.ValueMember = "IdStatus";
            //Para que el dropdown tenga seleccionado el dato del registro:
            objUpdateEmployee.comboEmployeeStatus.Text = status;

            //Dropdown de Bancos
            DataSet dsBanks = daoUpdateEmployee.ObtainBanks();
            objUpdateEmployee.comboBanks.DataSource = dsBanks.Tables["tbBanks"];
            objUpdateEmployee.comboBanks.DisplayMember = "BankName";
            objUpdateEmployee.comboBanks.ValueMember = "IdBank";
            //Para que el dropdown tenga seleccionado el dato del registro:
            objUpdateEmployee.comboBanks.Text = bank;

            //PARA HACER INVISIBLE EL TEXTBOX DEL ID DE EMPLEADO Y lblSalaryRequest:
            objUpdateEmployee.txtEmployeeId.Visible = false;
            objUpdateEmployee.lblEmployeeId.Visible = false;
            objUpdateEmployee.lblSalaryRequest.Visible = false;

            //PARA DESACTIVAR EL TEXTBOX DEL USUARIO, YA QUE ESTE NO PUEDE SER ACTUALIZADO POR QUE ES UNA LLAVE PRIMARIA
            objUpdateEmployee.txtUsername.Enabled = false;
        }

        public void ChargeValues( int employeeId, string names, string lastNames, string dui, DateTime birthDate, string email, string phone, string address, double salary, string bankAccount, string bank, string affiliationNumber, DateTime hireDate, string department, string employeeType, string maritalStatus, string status, string username, string businessP)
        {
            try
            {
                objUpdateEmployee.txtNames.Text = names;
                objUpdateEmployee.txtLastNames.Text = lastNames;
                objUpdateEmployee.txtDUI.Text = dui;
                objUpdateEmployee.dtBirthDate.Value = birthDate;
                objUpdateEmployee.txtAddress.Text = address;
                objUpdateEmployee.txtPhone.Text = phone;
                objUpdateEmployee.txtEmail.Text = email;
                objUpdateEmployee.dpHireDate.Value = hireDate;
                objUpdateEmployee.comboMaritalStatus.Text = maritalStatus.ToString();
                objUpdateEmployee.comboDepartment.Text = department.ToString();
                objUpdateEmployee.comboEmployeeType.Text = employeeType.ToString();
                objUpdateEmployee.comboEmployeeStatus.Text = status.ToString();
                objUpdateEmployee.txtSalary.Text = salary.ToString();
                objUpdateEmployee.txtAffiliationNumber.Text = affiliationNumber.ToString();
                objUpdateEmployee.txtBankAccount.Text = bankAccount;
                objUpdateEmployee.comboBanks.Text = bank.ToString();
                objUpdateEmployee.txtUsername.Text = username;
                objUpdateEmployee.comboBusinessP.Text = businessP.ToString();
                objUpdateEmployee.txtEmployeeId.Text = employeeId.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        public void EnterSalary(object sender, EventArgs e)
        {
            if (objUpdateEmployee.txtSalary.Text.Trim().Equals("Ingrese con dos decimales"))
            {
                objUpdateEmployee.txtSalary.Text = "";
                objUpdateEmployee.lblSalary.Visible = false;
                objUpdateEmployee.lblSalaryRequest.Visible = true;
            }

            objUpdateEmployee.lblSalary.Visible = false;
            objUpdateEmployee.lblSalaryRequest.Visible = true;

        }
        public void LeaveSalary(object sender, EventArgs e)
        {
            if (objUpdateEmployee.txtSalary.Text.Trim().Equals(""))
            {
                objUpdateEmployee.lblSalary.Visible = true;
                objUpdateEmployee.lblSalaryRequest.Visible = false;
                objUpdateEmployee.txtSalary.Text = "Ingrese con dos decimales";
            }

            objUpdateEmployee.lblSalary.Visible = true;
            objUpdateEmployee.lblSalaryRequest.Visible = false;
        }

        //validación de email
        private bool ValidateEmail()
        {
            string email = objUpdateEmployee.txtEmail.Text.Trim();
            if (!(email.Contains("@")))
            {
                MessageBox.Show("El formato del correo es incorrecto, verifique que contenga '@'.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //validación de dominio del correo
            string[] allowedDomains = { "gmail.com", "ricaldone.edu.sv" };
            //La variable domain guarda la cadena de carácteres que se presente después de la arroba en el campo de correo
            string domain = email.Substring(email.LastIndexOf('@') + 1);
            //Si la cadena de carácteres después de la arroba NO es uno de los dominios permitidos, nos envía un mensaje de error.
            if (!allowedDomains.Contains(domain))
            {
                MessageBox.Show("Dominio de correo inválido. \n El sistema solo admite los dominios '@gmail.com' y '@ricaldone.edu.sv'", "Dominio no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //Si no se detecta ningún fallo en el email, se devuelve directamente un true.
            return true;
        }

        private void RestorePassword(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Seguro que quiere restaurar la contraseña del usuario {objUpdateEmployee.txtUsername.Text.Trim()}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Creamos objeto del DAOUpdataEmployee y del commonClasses
                DAOUpdateEmployee daoUpdateEmployee = new DAOUpdateEmployee();
                CommonClasses commonClasses = new CommonClasses();
                //Le damos valor a los getters 
                daoUpdateEmployee.Username = objUpdateEmployee.txtUsername.Text.Trim();
                daoUpdateEmployee.Password = commonClasses.ComputeSha256Hash(objUpdateEmployee.txtUsername.Text.Trim() + "PU123");
                //invocamos al método en el DAO
                int restoreAnswer = daoUpdateEmployee.PasswordRestore();
                //evaluamos la respuesta que nos devolvió dicho método
                if (restoreAnswer == 1)
                {
                    MessageBox.Show($"La contraseña se restableció correctamente. \n Nueva contraseña: {objUpdateEmployee.txtUsername.Text.Trim()}PU123", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La contraseña no pudo ser restablecida, intente de nuevo", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}

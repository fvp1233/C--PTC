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
        private int idBank;
        private int idDepartment;
        private int idTypeE;
        private int idMaritalS;
        private int idStatus;
        private int idBusinessP;

        bool emailValidation;
        //CONSTRUCTOR
        public ControllerUpdateEmployee(FrmUpdateEmployee View, int employeeId, string names, string lastNames, string dui, DateTime birthDate, string email, string phone, string address, double salary, string bankAccount, string bank, string affiliationNumber, DateTime hireDate, string department, string employeeType, string maritalStatus, string status, string username, string businessP, int Idbank, int idDepartment, int idTypeE, int idMaritalS, int idStatus, int idBusinessP)
        {
            objUpdateEmployee = View;
            //variables para que los combobox aparezcan seleccionados según los datos del registro
            this.bank = bank;
            this.department = department;
            this.employeeType = employeeType;
            this.maritalStatus = maritalStatus;
            this.status = status;
            this.businessP = businessP;
            this.idBank = Idbank;
            this.idDepartment = idDepartment;
            this.idTypeE = idTypeE;
            this.idMaritalS = idMaritalS;
            this.idStatus = idStatus;
            this.idBusinessP = idBusinessP;
            //Métodos del formulario
            ChargeValues(employeeId ,names, lastNames, dui, birthDate, email, phone, address, salary, bankAccount, affiliationNumber, hireDate, username);
            EvaluateCEO(businessP);
            objUpdateEmployee.Load += new EventHandler(ChargeInfo);
            objUpdateEmployee.BtnCancelar.Click += new EventHandler(CancelProcess);
            objUpdateEmployee.btnEmployeUpdate.Click += new EventHandler(UpdateEmployee);
            objUpdateEmployee.txtSalary.Enter += new EventHandler(EnterSalary);
            objUpdateEmployee.txtSalary.Leave += new EventHandler(LeaveSalary);
            objUpdateEmployee.btnRestorePass.Click += new EventHandler(RestorePassword);
            objUpdateEmployee.txtDUI.TextChanged += new EventHandler(DUIMask);
            objUpdateEmployee.txtPhone.TextChanged += new EventHandler(PhoneMask);
            objUpdateEmployee.txtAffiliationNumber.TextChanged += new EventHandler(AffiliatioNumberMask);
            objUpdateEmployee.txtBankAccount.TextChanged += new EventHandler(BankAccountMask);

        }

        public void ChargeInfo(object sender, EventArgs e)
        {
            ChargeDropDowns();
        }

        public void EvaluateCEO(string businessP)
        {
            if (businessP == "CEO")
            {
                objUpdateEmployee.comboBusinessP.Enabled = false;
            }
            else
            {
                objUpdateEmployee.comboBusinessP.Enabled = true;
            }
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
                    //Validamos que el valor ingresado en el textbox del salario sea numérico
                    if (double.TryParse(objUpdateEmployee.txtSalary.Text, out _))
                    {
                        //Ahora verificamos la edad con el método de más abajo
                        int employeeAge = ValidateAge();
                        if (employeeAge >= 18)
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
                            //FIN DEL MANTENIMIENTO DE UPDATE EMPLOYEE
                        }
                        else
                        {
                            MessageBox.Show("El empleado debe tener al menos 18 años de edad.", "Edad no permitida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un valor numérico en el campo del salario", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                        
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
            objUpdateEmployee.comboMaritalStatus.SelectedValue = idMaritalS;

            //Dropdown de Departamentos
            DataSet dsDepartamentos = daoUpdateEmployee.ObtenerDepartamentos();
            objUpdateEmployee.comboDepartment.DataSource = dsDepartamentos.Tables["tbDepartment"];
            objUpdateEmployee.comboDepartment.DisplayMember = "departmentName";
            objUpdateEmployee.comboDepartment.ValueMember = "IdDepartment";
            //Para que el dropdown tenga seleccionado el dato del registro:
            objUpdateEmployee.comboDepartment.SelectedValue = idDepartment;

            //Dropdown de tipos de empleado
            DataSet dsTiposEmpleado = daoUpdateEmployee.ObtenerTiposEmpleado();
            objUpdateEmployee.comboEmployeeType.DataSource = dsTiposEmpleado.Tables["tbTypeE"];
            objUpdateEmployee.comboEmployeeType.DisplayMember = "typeEmployee";
            objUpdateEmployee.comboEmployeeType.ValueMember = "IdTypeE";
            //Para que el dropdown tenga seleccionado el dato del registro:
            objUpdateEmployee.comboEmployeeType.SelectedValue = idTypeE;

            //Dropdown de puestos de empleado
            if (businessP == "CEO")
            {
                //en caso de que se esté actualizando al CEO
                DataSet dsPuestosEmpleadoCEO = daoUpdateEmployee.ObtainBusinessPositionsCEOCase();
                objUpdateEmployee.comboBusinessP.DataSource = dsPuestosEmpleadoCEO.Tables["tbBusinessP"];
                objUpdateEmployee.comboBusinessP.DisplayMember = "businessPosition";
                objUpdateEmployee.comboBusinessP.ValueMember = "IdBusinessP";
                //Para que el dropdown tenga seleccionado el dato del registro:
                objUpdateEmployee.comboBusinessP.SelectedValue = idBusinessP;
            }
            else
            {
                DataSet dsPuestosEmpleado = daoUpdateEmployee.ObtenerPuestosEmpleado();
                objUpdateEmployee.comboBusinessP.DataSource = dsPuestosEmpleado.Tables["tbBusinessP"];
                objUpdateEmployee.comboBusinessP.DisplayMember = "businessPosition";
                objUpdateEmployee.comboBusinessP.ValueMember = "IdBusinessP";
                //Para que el dropdown tenga seleccionado el dato del registro:
                objUpdateEmployee.comboBusinessP.SelectedValue = idBusinessP;
            }
            
            //Dropdown de estado de empleado
            DataSet dsEstadosEmpleado = daoUpdateEmployee.ObtenerEstadosEmpleado();
            objUpdateEmployee.comboEmployeeStatus.DataSource = dsEstadosEmpleado.Tables["tbEmployeeStatus"];
            objUpdateEmployee.comboEmployeeStatus.DisplayMember = "employeeStatus";
            objUpdateEmployee.comboEmployeeStatus.ValueMember = "IdStatus";
            //Para que el dropdown tenga seleccionado el dato del registro:
            objUpdateEmployee.comboEmployeeStatus.SelectedValue = idStatus;

            //Dropdown de Bancos
            DataSet dsBanks = daoUpdateEmployee.ObtainBanks();
            objUpdateEmployee.comboBanks.DataSource = dsBanks.Tables["tbBanks"];
            objUpdateEmployee.comboBanks.DisplayMember = "BankName";
            objUpdateEmployee.comboBanks.ValueMember = "IdBank";
            //Para que el dropdown tenga seleccionado el dato del registro:
            objUpdateEmployee.comboBanks.SelectedValue = idBank;

            //PARA HACER INVISIBLE EL TEXTBOX DEL ID DE EMPLEADO Y lblSalaryRequest:
            objUpdateEmployee.txtEmployeeId.Visible = false;
            objUpdateEmployee.lblEmployeeId.Visible = false;
            objUpdateEmployee.lblSalaryRequest.Visible = false;

            //PARA DESACTIVAR EL TEXTBOX DEL USUARIO, YA QUE ESTE NO PUEDE SER ACTUALIZADO POR QUE ES UNA LLAVE PRIMARIA
            objUpdateEmployee.txtUsername.Enabled = false;
        }

        public void ChargeValues( int employeeId, string names, string lastNames, string dui, DateTime birthDate, string email, string phone, string address, double salary, string bankAccount, string affiliationNumber, DateTime hireDate, string username)
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
                objUpdateEmployee.txtSalary.Text = salary.ToString();
                objUpdateEmployee.txtAffiliationNumber.Text = affiliationNumber.ToString();
                objUpdateEmployee.txtBankAccount.Text = bankAccount;
                objUpdateEmployee.txtUsername.Text = username;
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

        private int ValidateAge()
        {
            //Declaramos la variable que captura el valor del dateTimePicker del formulario
            DateTime birthday = objUpdateEmployee.dtBirthDate.Value;
            //Ahora declaramos la variable que captura la fecha actual
            DateTime now = DateTime.Today;
            //Declaramos la variable que nos dirá que edad tiene la persona
            int employeeAge = now.Year - birthday.Year;

            //Ahora bien, verificaremos si la persona ya cumplió años el año actual
            //En el "now.AddYears(-employeeAge)" estamos restandole los años de la edad calculada antes a la fecha actual
            //Si la fecha que obtengamos es menor a la fecha puesta en el datetimepicker entonces se le resta 1 a la edad, porque aun no cumple años en el año actual

            if (birthday.Date > now.AddYears(-employeeAge))
            {
                employeeAge--;
            }

            //Ahora si retornamos la edad.
            return employeeAge;

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

        //Método para establecer una máscara al textbox del DUI
        public void DUIMask(object sender, EventArgs e)
        {
            // Aqui se guarda la posición inicial del cursor
            int cursorPosition = objUpdateEmployee.txtDUI.SelectionStart;

            //Con esto se remueve cualquier dato no numérico excepto el guión
            string text = new string(objUpdateEmployee.txtDUI.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());

            //Si ya existe algun guión, se elimina.
            text = text.Replace("-", "");

            //Acá especificamos la máscara del DUI, cuando llegue al caracter numero 9, va a ingresar el guion por si solo
            //
            if (text.Length >= 9)
            {
                text = text.Insert(8, "-");
            }
            else if (text.Length >= 1)
            {
                text = text.Insert(0, "");
            }

            //Le asignamos la máscara al texto que se presente en el textbox
            objUpdateEmployee.txtDUI.Text = text;

            //Restablecemos la posicion del cursor
            objUpdateEmployee.txtDUI.SelectionStart = cursorPosition;
        }

        //Máscara para el textbox del telefono
        public void PhoneMask(object sender, EventArgs e)
        {
            //Aqui se guarda la posición inicial del cursor, para que con el evento TextChanged el cursor no se mueva de lugar y no sea molesto para el usuario
            int cursorPosition = objUpdateEmployee.txtPhone.SelectionStart;

            //Con esto se remueve cualquier dato no numérico
            string text = new string(objUpdateEmployee.txtPhone.Text.Where(c => char.IsDigit(c)).ToArray());

            if (text.Length >= 5)
            {
                text = text.Insert(4, "-");

            }

            //Con esto se reposiciona el cursor, ya no se coloca antes del numero que va siguiente al guion, si no que se reajusta para que  se ponga en el orden que iba anteriormente
            if (cursorPosition == 5)
            {
                cursorPosition++;
            }

            //Le asignamos la máscara al texto que se ponga en el textbox
            objUpdateEmployee.txtPhone.Text = text;

            //Restablecemos la posición del cursor con la variable que se guardó antes
            objUpdateEmployee.txtPhone.SelectionStart = cursorPosition;
        }

        //Aplicamos una máscara que solo deje meter el guion y caracteres numéricos para los textbox de numero de afiliacion y cuenta bancaria.
        public void AffiliatioNumberMask(object sender, EventArgs e)
        {
            int cursorPosition = objUpdateEmployee.txtAffiliationNumber.SelectionStart;
            //Con esto se remueve cualquier dato no numérico excepto el guion
            string text = new string(objUpdateEmployee.txtAffiliationNumber.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());
            objUpdateEmployee.txtAffiliationNumber.Text = text;
            objUpdateEmployee.txtAffiliationNumber.SelectionStart = cursorPosition;
        }

        public void BankAccountMask(object sender, EventArgs e)
        {
            int cursorPosition = objUpdateEmployee.txtBankAccount.SelectionStart;
            //Con esto se remueve cualquier dato no numérico excepto el guion
            string text = new string(objUpdateEmployee.txtBankAccount.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());
            objUpdateEmployee.txtBankAccount.Text = text;
            objUpdateEmployee.txtBankAccount.SelectionStart = cursorPosition;
        }
    }
}

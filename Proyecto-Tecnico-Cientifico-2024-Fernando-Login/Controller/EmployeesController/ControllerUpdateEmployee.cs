﻿using PTC2024.Controller.Helper;
using PTC2024.Model.DAO;
using PTC2024.Model.DAO.EmployeesDAO;
using PTC2024.View.Empleados;
using PTC2024.View.formularios.inicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using PTC2024.Model.DAO.HelperDAO;
using System.Drawing;

namespace PTC2024.Controller.EmployeesController
{
    internal class ControllerUpdateEmployee
    {
        FrmUpdateEmployee objUpdateEmployee;
        StartMenu objStartMenu;
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
        private int gender;
        
        bool emailValidation;
        //CONSTRUCTOR
        public ControllerUpdateEmployee(FrmUpdateEmployee View, int employeeId, string names, string lastNames, string dui, DateTime birthDate, string email, string phone, string address, double salary, string bankAccount, string bank, string affiliationNumber, DateTime hireDate, string department, string employeeType, string maritalStatus, string status, string username, string businessP, int Idbank, int idDepartment, int idTypeE, int idMaritalS, int idStatus, int idBusinessP, int gender)
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
            this.gender = gender;
            //Métodos del formulario
            ChargeValues(employeeId ,names, lastNames, dui, birthDate, email, phone, address, salary, bankAccount, affiliationNumber, hireDate, username);
            EvaluateCEO(businessP);
            objUpdateEmployee.Load += new EventHandler(ChargeInfo);
            objUpdateEmployee.Load += new EventHandler(DarkMode);
            objUpdateEmployee.BtnCancelar.Click += new EventHandler(CancelProcess);
            objUpdateEmployee.btnEmployeUpdate.Click += new EventHandler(UpdateEmployee);
            objUpdateEmployee.txtSalary.Enter += new EventHandler(EnterSalary);
            objUpdateEmployee.txtSalary.Leave += new EventHandler(LeaveSalary);
            objUpdateEmployee.btnRestorePass.Click += new EventHandler(RestorePassword);
            objUpdateEmployee.txtDUI.TextChange += new EventHandler(DUIMask);
            objUpdateEmployee.txtPhone.TextChange += new EventHandler(PhoneMask);
            objUpdateEmployee.txtAffiliationNumber.TextChange += new EventHandler(AffiliatioNumberMask);
            objUpdateEmployee.txtBankAccount.TextChange += new EventHandler(BankAccountMask);
            objUpdateEmployee.txtNames.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateEmployee.txtLastNames.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateEmployee.txtDUI.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateEmployee.txtAddress.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateEmployee.txtPhone.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateEmployee.txtEmail.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateEmployee.txtSalary.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateEmployee.txtAffiliationNumber.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateEmployee.txtBankAccount.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateEmployee.txtNames.TextChanged += new EventHandler(OnlyLettersName);
            objUpdateEmployee.txtLastNames.TextChanged += new EventHandler(OnlyLettersLastName);
            objUpdateEmployee.txtSalary.TextChanged += new EventHandler(OnlyNum);
        }

        public void ChargeInfo(object sender, EventArgs e)
        {
            ChargeDropDowns();
        }

        public void DarkMode(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.darkMode == true)
            {
                objUpdateEmployee.BackColor = Color.FromArgb(30, 30, 30);
                objUpdateEmployee.lblTitle.ForeColor = Color.White;
                objUpdateEmployee.lblSubtitle.ForeColor = Color.White;
                objUpdateEmployee.groupBox1.ForeColor = Color.White;
                objUpdateEmployee.groupBox2.ForeColor = Color.White;
                objUpdateEmployee.groupBox3.ForeColor = Color.White;
                objUpdateEmployee.txtNames.FillColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.txtNames.BorderColorIdle = Color.Gray;
                objUpdateEmployee.txtLastNames.FillColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.txtLastNames.BorderColorIdle = Color.Gray;
                objUpdateEmployee.txtDUI.FillColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.txtDUI.BorderColorIdle = Color.Gray;
                objUpdateEmployee.dtBirthDate.BackColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.dtBirthDate.ForeColor = Color.White;
                objUpdateEmployee.dtBirthDate.IconColor = Color.White;
                objUpdateEmployee.txtAddress.FillColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.txtAddress.BorderColorIdle = Color.Gray;
                objUpdateEmployee.txtPhone.FillColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.txtPhone.BorderColorIdle = Color.Gray;
                objUpdateEmployee.txtEmail.FillColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.txtEmail.BorderColorIdle = Color.Gray;
                objUpdateEmployee.dpHireDate.BackColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.dpHireDate.ForeColor = Color.White;
                objUpdateEmployee.dpHireDate.IconColor = Color.White;
                objUpdateEmployee.comboMaritalStatus.BackgroundColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.comboMaritalStatus.BorderColor = Color.Gray;
                objUpdateEmployee.comboMaritalStatus.ForeColor = Color.White;
                objUpdateEmployee.comboMaritalStatus.ItemBackColor = Color.DimGray;
                objUpdateEmployee.comboMaritalStatus.ItemBorderColor = Color.Gray;
                objUpdateEmployee.comboMaritalStatus.ItemForeColor = Color.White;
                objUpdateEmployee.comboDepartment.BackgroundColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.comboDepartment.BorderColor = Color.Gray;
                objUpdateEmployee.comboDepartment.ForeColor = Color.White;
                objUpdateEmployee.comboDepartment.ItemBackColor = Color.DimGray;
                objUpdateEmployee.comboDepartment.ItemBorderColor = Color.Gray;
                objUpdateEmployee.comboDepartment.ItemForeColor = Color.White;
                objUpdateEmployee.comboEmployeeType.BackgroundColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.comboEmployeeType.BorderColor = Color.Gray;
                objUpdateEmployee.comboEmployeeType.ForeColor = Color.White;
                objUpdateEmployee.comboEmployeeType.ItemBackColor = Color.DimGray;
                objUpdateEmployee.comboEmployeeType.ItemBorderColor = Color.Gray;
                objUpdateEmployee.comboEmployeeType.ItemForeColor = Color.White;
                objUpdateEmployee.comboGender.BackgroundColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.comboGender.BorderColor = Color.Gray;
                objUpdateEmployee.comboGender.ForeColor = Color.White;
                objUpdateEmployee.comboGender.ItemBackColor = Color.DimGray;
                objUpdateEmployee.comboGender.ItemBorderColor = Color.Gray;
                objUpdateEmployee.comboGender.ItemForeColor = Color.White;
                objUpdateEmployee.txtSalary.FillColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.txtSalary.BorderColorIdle = Color.Gray;
                objUpdateEmployee.txtAffiliationNumber.FillColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.txtAffiliationNumber.BorderColorIdle = Color.Gray;
                objUpdateEmployee.txtBankAccount.FillColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.txtBankAccount.BorderColorIdle = Color.Gray;
                objUpdateEmployee.comboBanks.BackgroundColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.comboBanks.BorderColor = Color.Gray;
                objUpdateEmployee.comboBanks.ForeColor = Color.White;
                objUpdateEmployee.comboBanks.ItemBackColor = Color.DimGray;
                objUpdateEmployee.comboBanks.ItemBorderColor = Color.Gray;
                objUpdateEmployee.comboBanks.ItemForeColor = Color.White;
                objUpdateEmployee.txtUsername.OnDisabledState.FillColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.txtUsername.BorderColorDisabled = Color.Gray;
                objUpdateEmployee.txtUsername.OnDisabledState.ForeColor = Color.White;
                objUpdateEmployee.comboBusinessP.DisabledBackColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.comboBusinessP.DisabledBorderColor = Color.Gray;
                objUpdateEmployee.comboBusinessP.DisabledForeColor = Color.White;
                objUpdateEmployee.comboBusinessP.ItemBackColor = Color.DimGray;
                objUpdateEmployee.comboBusinessP.ItemBorderColor = Color.Gray;
                objUpdateEmployee.comboBusinessP.ItemForeColor = Color.White;
                objUpdateEmployee.comboEmployeeStatus.BackgroundColor = Color.FromArgb(60, 60, 60);
                objUpdateEmployee.comboEmployeeStatus.BorderColor = Color.Gray;
                objUpdateEmployee.comboEmployeeStatus.ForeColor = Color.White;
                objUpdateEmployee.comboEmployeeStatus.ItemBackColor = Color.DimGray;
                objUpdateEmployee.comboEmployeeStatus.ItemBorderColor = Color.Gray;
                objUpdateEmployee.comboEmployeeStatus.ItemForeColor = Color.White;
            }
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
            StartMenu objStart = new StartMenu(SessionVar.Username);
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
                            bool email = CheckEmail();
                            if (email == false)
                            {
                                bool dui = CheckDUI();
                                if (dui == false)
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
                                    daoUpdateEmployee.Gender = (int)objUpdateEmployee.comboGender.SelectedValue;
                                    //Datos para los getters de la tabla userData
                                    daoUpdateEmployee.Username = objUpdateEmployee.txtUsername.Text.Trim();
                                    daoUpdateEmployee.BusinessPosition = (int)objUpdateEmployee.comboBusinessP.SelectedValue;

                                    //variable para saber la respuesta del proceso de update en el DAOUpdateEmployees
                                    int updateAnswer = daoUpdateEmployee.UpdateEmployee();
                                    //la evaluamos
                                    if (updateAnswer == 1)
                                    {                                        
                                        objUpdateEmployee.Close();
                                        objUpdateEmployee.snackbar.Show(objStart, $"Los datos del empleado se actualizaron con éxito.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                                        DAOInitialView daoInitial = new DAOInitialView();
                                        daoInitial.ActionType = "Se actualizo un empleado";
                                        daoInitial.TableName = "Empleados";
                                        daoInitial.ActionBy = SessionVar.Username;
                                        daoInitial.ActionDate = DateTime.Now;
                                        int auditAnswer = daoInitial.InsertAudit();
                                        if (auditAnswer != 1)
                                        {
                                            objStartMenu.snackBar.Show(objStartMenu, $"La auditoria no pudo ser registrada", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                                        }
                                    }
                                    else
                                    {
                                        objUpdateEmployee.snackbar.Show(objUpdateEmployee, "Proceso fallido: Los datos del empleado no se pudieron actualizar.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                                        //MessageBox.Show("Los datos del empleado no pudieron ser actualizados.", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    //FIN DEL MANTENIMIENTO DE UPDATE EMPLOYEE
                                }
                                else
                                {
                                    MessageBox.Show("Este DUI ya está registrado con otro usuario.", "Documento de identidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Este correo electrónico ya está registrado con otro usuario.", "Correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            
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

            //Dropdown de Generos
            DataSet dsGender = daoUpdateEmployee.ObtainGenders();
            objUpdateEmployee.comboGender.DataSource = dsGender.Tables["tbGenders"];
            objUpdateEmployee.comboGender.DisplayMember = "gender";
            objUpdateEmployee.comboGender.ValueMember = "IdGender";
            //Para que el dropdown tenga seleccionado el dato del registro
            objUpdateEmployee.comboGender.SelectedValue = gender;

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

            // Verificar que el correo contenga una '@'
            if (!email.Contains("@"))
            {
                MessageBox.Show("El formato del correo es incorrecto, verifique que contenga '@'.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Asegurarse de que el correo tenga un dominio válido (parte después de '@')
            string domain = email.Substring(email.LastIndexOf('@') + 1);

            if (string.IsNullOrEmpty(domain))
            {
                MessageBox.Show("El formato del correo es incorrecto. No tiene un dominio válido.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verificar si el dominio tiene un registro MX
            if (!DomainHasMXRecord(domain))
            {
                MessageBox.Show("El dominio del correo no existe o no tiene un servidor de correo válido.", "Dominio inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool DomainHasMXRecord(string domain)
        {
            try
            {
                // Obtener registros DNS del dominio
                IPHostEntry hostEntry = Dns.GetHostEntry(domain);

                // Verificar que tenga registros de mail (MX)
                return hostEntry.AddressList.Length > 0;
            }
            catch (SocketException)
            {
                // Si ocurre un error al obtener la entrada DNS, el dominio no es válido o no tiene MX
                return false;
            }
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
                cursorPosition++;
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
            // Aquí se guarda la posición inicial del cursor, para que con el evento TextChanged el cursor no se mueva de lugar
            int cursorPosition = objUpdateEmployee.txtPhone.SelectionStart;

            // Remover cualquier dato no numérico
            string text = new string(objUpdateEmployee.txtPhone.Text.Where(c => char.IsDigit(c)).ToArray());
            // Aplicar la máscara de teléfono (ej: ####-###)
            if (text.Length >= 5)
            {
                text = text.Insert(4, "-");
            }

            // Ajustar la posición del cursor si está después del guion
            if (cursorPosition == 5)
            {
                cursorPosition++;
            }

            // Asignar el texto con la máscara al TextBox
            objUpdateEmployee.txtPhone.Text = text;

            // Restablecer la posición del cursor
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

        public bool CheckEmail()
        {
            //objeto del dao
            DAOUpdateEmployee daoUpdate = new DAOUpdateEmployee();
            daoUpdate.Email = objUpdateEmployee.txtEmail.Text.Trim();
            daoUpdate.Username = objUpdateEmployee.txtUsername.Text.Trim();
            //ejecutamos el método
            bool answer = daoUpdate.CheckEmail();
            return answer;
        }

        public bool CheckDUI()
        {
            //objeto del dao
            DAOUpdateEmployee daoUpdate = new DAOUpdateEmployee();
            daoUpdate.Document = objUpdateEmployee.txtDUI.Text.Trim();
            daoUpdate.Username = objUpdateEmployee.txtUsername.Text.Trim();
            //ejecutamos el método
            bool answer = daoUpdate.CheckDUI();
            return answer;
        }

        private void DisableContextMenu(object sender, MouseEventArgs e)
        {
            // Desactiva el menú contextual al hacer clic derecho
            if (e.Button == MouseButtons.Right)
            {
                ((Bunifu.UI.WinForms.BunifuTextBox)sender).ContextMenu = new ContextMenu();  // Asigna un menú vacío
            }
        }

        public void OnlyLettersName(object sender, EventArgs e)
        {
            // Obtener la posición actual del cursor
            int cursorPosition = objUpdateEmployee.txtNames.SelectionStart;

            // Filtrar el texto para que solo queden letras
            string text = new string(objUpdateEmployee.txtNames.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            // Actualizar el contenido del TextBox con el texto filtrado
            objUpdateEmployee.txtNames.Text = text;

            // Restaurar la posición del cursor
            objUpdateEmployee.txtNames.SelectionStart = cursorPosition;
        }

        public void OnlyLettersLastName(object sender, EventArgs e)
        {
            // Obtener la posición actual del cursor
            int cursorPosition = objUpdateEmployee.txtLastNames.SelectionStart;

            // Filtrar el texto para que solo queden letras
            string text = new string(objUpdateEmployee.txtLastNames.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            // Actualizar el contenido del TextBox con el texto filtrado
            objUpdateEmployee.txtLastNames.Text = text;

            // Restaurar la posición del cursor
            objUpdateEmployee.txtLastNames.SelectionStart = cursorPosition;
        }

        public void OnlyNum(object sender, EventArgs e)
        {
            int cursorPosition = objUpdateEmployee.txtSalary.SelectionStart;

            // Permitir solo dígitos y un solo punto decimal
            string text = new string(objUpdateEmployee.txtSalary.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            // Asegurarse de que solo haya un punto decimal
            int decimalCount = text.Count(c => c == '.');
            if (decimalCount > 1)
            {
                // Si hay más de un punto decimal, remover los adicionales
                int firstDecimalIndex = text.IndexOf('.');
                text = text.Substring(0, firstDecimalIndex + 1) + text.Substring(firstDecimalIndex + 1).Replace(".", "");
            }

            // Evitar que el texto comience con un punto decimal
            if (text.StartsWith("."))
            {
                text = text.TrimStart('.');
            }

            // Asignar el texto filtrado al TextBox
            objUpdateEmployee.txtSalary.Text = text;

            // Restablecer la posición del cursor
            objUpdateEmployee.txtSalary.SelectionStart = cursorPosition;
        }

    }
}

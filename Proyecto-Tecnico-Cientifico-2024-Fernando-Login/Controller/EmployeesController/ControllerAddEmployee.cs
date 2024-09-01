using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.View;
using PTC2024.Model.DAO;
using PTC2024.View.Empleados;
using System.Data;
using System.Windows.Forms;
using PTC2024.Controller.Helper;

namespace PTC2024.Controller
{
    internal class ControllerAddEmployee
    {
        FrmAddEmployee objAddEmployee;
        bool emailValidation;
        public ControllerAddEmployee(FrmAddEmployee View)
        {
            objAddEmployee = View;
            objAddEmployee.Load += new EventHandler(CargarCombos);
            objAddEmployee.BtnAgregarEmpleado.Click += new EventHandler(AgregarEmpleado);
            objAddEmployee.BtnCancelar.Click += new EventHandler(CancelarProceso);
            objAddEmployee.txtSalary.Enter += new EventHandler(EnterSalary);
            objAddEmployee.txtSalary.Leave += new EventHandler(LeaveSalary);
            objAddEmployee.txtDUI.TextChanged += new EventHandler(DUIMask);
            objAddEmployee.txtPhone.TextChanged += new EventHandler(PhoneMask);
            objAddEmployee.txtAffiliationNumber.TextChanged += new EventHandler(AffiliatioNumberMask);
            objAddEmployee.txtBankAccount.TextChanged += new EventHandler(BankAccountMask);
            objAddEmployee.txtUsername.TextChanged += new EventHandler(UsernameMask);
            objAddEmployee.txtNames.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddEmployee.txtLastNames.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddEmployee.txtDUI.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddEmployee.txtAddress.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddEmployee.txtPhone.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddEmployee.txtEmail.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddEmployee.txtSalary.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddEmployee.txtAffiliationNumber.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddEmployee.txtBankAccount.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddEmployee.txtUsername.MouseDown += new MouseEventHandler(DisableContextMenu);
        }


        public void CargarCombos(object sender, EventArgs e)
        {
            //creando objeto de la clase DAOAddEmployee
            DAOAddEmployee daoAddEmployee = new DAOAddEmployee();

            //Dropdown de Estados civiles
            DataSet dsEstadosCiviles = daoAddEmployee.ObtenerEstadosCiviles();
            objAddEmployee.comboMaritalStatus.DataSource = dsEstadosCiviles.Tables["tbmaritalStatus"];
            objAddEmployee.comboMaritalStatus.DisplayMember = "maritalStatus";
            objAddEmployee.comboMaritalStatus.ValueMember = "IdMaritalS";

            //Dropdown de Departamentos
            DataSet dsDepartamentos = daoAddEmployee.ObtenerDepartamentos();
            objAddEmployee.comboDepartment.DataSource = dsDepartamentos.Tables["tbDepartment"];
            objAddEmployee.comboDepartment.DisplayMember = "departmentName";
            objAddEmployee.comboDepartment.ValueMember = "IdDepartment";

            //Dropdown de tipos de empleado
            DataSet dsTiposEmpleado = daoAddEmployee.ObtenerTiposEmpleado();
            objAddEmployee.comboEmployeeType.DataSource = dsTiposEmpleado.Tables["tbTypeE"];
            objAddEmployee.comboEmployeeType.DisplayMember = "typeEmployee";
            objAddEmployee.comboEmployeeType.ValueMember = "IdTypeE";

            //Dropdown de puestos de empleado
            DataSet dsPuestosEmpleado = daoAddEmployee.ObtenerPuestosEmpleado();
            objAddEmployee.comboBusinessP.DataSource = dsPuestosEmpleado.Tables["tbBusinessP"];
            objAddEmployee.comboBusinessP.DisplayMember = "businessPosition";
            objAddEmployee.comboBusinessP.ValueMember = "IdBusinessP";

            //Dropdown de generos
            DataSet dsGender = daoAddEmployee.ObtainGenders();
            objAddEmployee.comboGender.DataSource = dsGender.Tables["tbGenders"];
            objAddEmployee.comboGender.DisplayMember = "gender";
            objAddEmployee.comboGender.ValueMember = "IdGender";

            //Dropdown de estado de empleado
            //DataSet dsEstadosEmpleado = daoAddEmployee.ObtenerEstadosEmpleado();
            //objAddEmployee.comboEmployeeStatus.DataSource = dsEstadosEmpleado.Tables["tbEmployeeStatus"];
            //objAddEmployee.comboEmployeeStatus.DisplayMember = "employeeStatus";
            //objAddEmployee.comboEmployeeStatus.ValueMember = "IdStatus";

            //Dropdown de Bancos
            DataSet dsBanks = daoAddEmployee.ObtainBanks();
            objAddEmployee.comboBanks.DataSource = dsBanks.Tables["tbBanks"];
            objAddEmployee.comboBanks.DisplayMember = "BankName";
            objAddEmployee.comboBanks.ValueMember = "IdBank";

            ////Dropdown de Empresas
            //DataSet dsBusiness = daoAddEmployee.ObtainBusiness();
            //objAddEmployee.comboBusinessInfo.DataSource = dsBusiness.Tables["tbBusinessInfo"];
            //objAddEmployee.comboBusinessInfo.DisplayMember = "nameBusiness";
            //objAddEmployee.comboBusinessInfo.ValueMember = "idBusiness";

            objAddEmployee.lblSalaryRequest.Visible = false;
        }

        public void EnterSalary(object sender, EventArgs e)
        {
            if (objAddEmployee.txtSalary.Text.Trim().Equals("Ingrese con dos decimales"))
            {
                objAddEmployee.lblSalary.Visible = false;
                objAddEmployee.lblSalaryRequest.Visible = true;
                objAddEmployee.txtSalary.Text = "";
            }
            objAddEmployee.lblSalary.Visible = false;
            objAddEmployee.lblSalaryRequest.Visible = true;
        }
        public void LeaveSalary(object sender, EventArgs e)
        {
            if (objAddEmployee.txtSalary.Text.Trim().Equals(""))
            {
                objAddEmployee.lblSalary.Visible = true;
                objAddEmployee.lblSalaryRequest.Visible = false;
                objAddEmployee.txtSalary.Text = "Ingrese con dos decimales";
            }
            objAddEmployee.lblSalaryRequest.Visible = false;
            objAddEmployee.lblSalary.Visible = true;
        }
        public void AgregarEmpleado(object sender, EventArgs e)
        {
            //Validamos los campos vacíos
            if (!(string.IsNullOrEmpty(objAddEmployee.txtNames.Text.Trim()) ||
                string.IsNullOrEmpty(objAddEmployee.txtLastNames.Text.Trim()) ||
                string.IsNullOrEmpty(objAddEmployee.txtDUI.Text.Trim()) ||
                string.IsNullOrEmpty(objAddEmployee.txtAddress.Text.Trim()) ||
                string.IsNullOrEmpty(objAddEmployee.txtPhone.Text.Trim()) ||
                string.IsNullOrEmpty(objAddEmployee.txtEmail.Text.Trim()) ||
                string.IsNullOrEmpty(objAddEmployee.txtDUI.Text.Trim()) ||
                objAddEmployee.txtSalary.Text.Equals("Ingrese con dos decimales") ||
                string.IsNullOrEmpty(objAddEmployee.txtAffiliationNumber.Text.Trim()) ||
                string.IsNullOrEmpty(objAddEmployee.txtBankAccount.Text.Trim()) ||
                string.IsNullOrEmpty(objAddEmployee.txtUsername.Text.Trim())
                ))
            {
                //validación del dominio del correo
                emailValidation = ValidateEmail();
                if (emailValidation == true)
                {
                    //Validamos que el valor ingresado en el textbox del salario sea numérico
                    if (double.TryParse(objAddEmployee.txtSalary.Text, out _))
                    {
                        //Ahora verificamos la edad con el método de más abajo
                        int employeeAge = ValidateAge();
                        if (employeeAge >= 18)
                        {
                            //Validación para saber si el nombre de usuario ya esta en uso, para evitar un error SQL
                            bool user = CheckUser();
                            if (user == false)
                            {
                                bool dui = CheckDUI();
                                if (dui == false)
                                {
                                    bool email = CheckEmail();
                                    if (email == false)
                                    {
                                        //Se crea un objeto de la clase DAOAddEmployee y de la clase CommonClasses
                                        DAOAddEmployee daoInsertEmployee = new DAOAddEmployee();
                                        CommonClasses commonClasses = new CommonClasses();
                                        //Datos para la creación de un empleado
                                        daoInsertEmployee.Names = objAddEmployee.txtNames.Text.Trim();
                                        daoInsertEmployee.LastNames = objAddEmployee.txtLastNames.Text.Trim();
                                        daoInsertEmployee.Document = objAddEmployee.txtDUI.Text.Trim();
                                        daoInsertEmployee.BirthDate = objAddEmployee.dtBirthDate.Value.Date;
                                        daoInsertEmployee.Email = objAddEmployee.txtEmail.Text.Trim();
                                        daoInsertEmployee.Phone = objAddEmployee.txtPhone.Text.Trim();
                                        daoInsertEmployee.Address = objAddEmployee.txtAddress.Text.Trim();
                                        daoInsertEmployee.Salary = double.Parse(objAddEmployee.txtSalary.Text.Trim());
                                        daoInsertEmployee.BankAccount = objAddEmployee.txtBankAccount.Text.Trim();
                                        daoInsertEmployee.AffiliationNumber = objAddEmployee.txtAffiliationNumber.Text.Trim();
                                        daoInsertEmployee.HireDate = objAddEmployee.dpHireDate.Value.Date;
                                        daoInsertEmployee.Bank = int.Parse(objAddEmployee.comboBanks.SelectedValue.ToString());
                                        daoInsertEmployee.Department = int.Parse(objAddEmployee.comboDepartment.SelectedValue.ToString());
                                        daoInsertEmployee.EmployeeType = int.Parse(objAddEmployee.comboEmployeeType.SelectedValue.ToString());
                                        daoInsertEmployee.MaritalStatus = int.Parse(objAddEmployee.comboMaritalStatus.SelectedValue.ToString());
                                        daoInsertEmployee.EmployeeStatus = 1;
                                        daoInsertEmployee.Gender = int.Parse(objAddEmployee.comboGender.SelectedValue.ToString());

                                        //Datos para la creación del usuario
                                        daoInsertEmployee.Username = objAddEmployee.txtUsername.Text.Trim();
                                        daoInsertEmployee.Password = commonClasses.ComputeSha256Hash(objAddEmployee.txtUsername.Text.Trim() + "PU123");
                                        daoInsertEmployee.BusinessPosition = int.Parse(objAddEmployee.comboBusinessP.SelectedValue.ToString());
                                        daoInsertEmployee.UserSatus = true;
                                        daoInsertEmployee.BusinessInfo = 1;
                                        //AHORA INVOCAMOS EL MÉTODO RegisterEmployee A TRAVÉS DEL OBJETO daoInsertEmployee
                                        int valorRespuesta = daoInsertEmployee.RegisterEmployee();
                                        //Verificamos el valor que nos retorna dicho método
                                        if (valorRespuesta == 1)
                                        {
                                            MessageBox.Show("Los datos se registraron de manera exitosa", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            MessageBox.Show($"Usuario: {objAddEmployee.txtUsername.Text.Trim()} \n Contraseña: {objAddEmployee.txtUsername.Text.Trim() + "PU123"}", "Credenciales de acceso del empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            objAddEmployee.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Los datos no pudieron ser registrados", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El correo ingresado ya está registrado en el sistema.", "Correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El DUI ingresado ya está registrado en el sistema.", "Documento de identidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("El nombre de usuario ya se encuentra en uso", "Nombre de usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Todos los campos son obligatorios y existen algunos vacíos, llene todos los apartados.",
                                    "Proceso interrumpido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
            //Fin del mantenimiento de agregar empleado.
        }

        public void CancelarProceso(object sender, EventArgs e)
        {
            objAddEmployee.Close();
        }

        //validación de email
        private bool ValidateEmail()
        {
            string email = objAddEmployee.txtEmail.Text.Trim();
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

        //Método encargado de verificar que el empleado sea mayor a 18 años
        public int ValidateAge()
        {
            //Declaramos la variable que captura el valor del dateTimePicker del formulario
            DateTime birthday = objAddEmployee.dtBirthDate.Value;
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

        //Método para establecer una máscara al textbox del DUI
        public void DUIMask(object sender, EventArgs e)
        {
            // Aqui se guarda la posición inicial del cursor
            int cursorPosition = objAddEmployee.txtDUI.SelectionStart;

            //Con esto se remueve cualquier dato no numérico excepto el guión
            string text = new string(objAddEmployee.txtDUI.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());

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
            objAddEmployee.txtDUI.Text = text;

            //Restablecemos la posicion del cursor
            objAddEmployee.txtDUI.SelectionStart = cursorPosition;
        }

        //Máscara para el textbox del telefono
        public void PhoneMask(object sender, EventArgs e)
        {
            //Aqui se guarda la posición inicial del cursor, para que con el evento TextChanged el cursor no se mueva de lugar y no sea molesto para el usuario
            int cursorPosition = objAddEmployee.txtPhone.SelectionStart;

            //Con esto se remueve cualquier dato no numérico
            string text = new string(objAddEmployee.txtPhone.Text.Where(c => char.IsDigit(c)).ToArray());

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
            objAddEmployee.txtPhone.Text = text;

            //Restablecemos la posición del cursor con la variable que se guardó antes
            objAddEmployee.txtPhone.SelectionStart = cursorPosition;
        }

        public void UsernameMask(object sender, EventArgs e)
        {
            //Almacena la posición original del cursor
            int cursorPosition = objAddEmployee.txtUsername.SelectionStart;

            //Filtra el texto del TextBox para eliminar caracteres especiales
            objAddEmployee.txtUsername.Text = new string(objAddEmployee.txtUsername.Text.Where(c => char.IsLetterOrDigit(c)).ToArray());

            //Restaura la posición del cursor
            objAddEmployee.txtUsername.SelectionStart = cursorPosition;
        }

        //Aplicamos una máscara que solo deje meter el guion y caracteres numéricos para los textbox de numero de afiliacion y cuenta bancaria.
        public void AffiliatioNumberMask(object sender, EventArgs e)
        {
            int cursorPosition = objAddEmployee.txtAffiliationNumber.SelectionStart;
            //Con esto se remueve cualquier dato no numérico excepto el guion
            string text = new string(objAddEmployee.txtAffiliationNumber.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());
            objAddEmployee.txtAffiliationNumber.Text = text;
            objAddEmployee.txtAffiliationNumber.SelectionStart = cursorPosition;
        }

        public void BankAccountMask(object sender, EventArgs e)
        {
            int cursorPosition = objAddEmployee.txtBankAccount.SelectionStart;
            //Con esto se remueve cualquier dato no numérico excepto el guion
            string text = new string(objAddEmployee.txtBankAccount.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());
            objAddEmployee.txtBankAccount.Text = text;
            objAddEmployee.txtBankAccount.SelectionStart = cursorPosition;
        }

        //Acá verificamos si el nombre de usuario ya está en uso por medio del método en el dao.
        public bool CheckUser()
        {
            //Creamos objeto del DAO
            DAOAddEmployee daoAddEmployee = new DAOAddEmployee();
            //Damos valor al getter username
            daoAddEmployee.Username = objAddEmployee.txtUsername.Text.Trim();
            // Creamos variable bool
            bool answer = daoAddEmployee.CheckUser();
            //Retornamos esta variable
            return answer;
        }

        public bool CheckDUI()
        {
            //Creamos objeto del DAO
            DAOAddEmployee daoAddEmployee = new DAOAddEmployee();
            //Damos valor al getter username
            daoAddEmployee.Document = objAddEmployee.txtDUI.Text.Trim();
            // Creamos variable bool
            bool answer = daoAddEmployee.CheckDUI();
            //Retornamos esta variable
            return answer;
        }

        public bool CheckEmail()
        {
            //Creamos objeto del DAO
            DAOAddEmployee daoAddEmployee = new DAOAddEmployee();
            //Damos valor al getter username
            daoAddEmployee.Email = objAddEmployee.txtEmail.Text.Trim();
            // Creamos variable bool
            bool answer = daoAddEmployee.CheckEmail();
            //Retornamos esta variable
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

    }
}

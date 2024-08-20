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

            //Dropdown de estado de empleado
            DataSet dsEstadosEmpleado = daoAddEmployee.ObtenerEstadosEmpleado();
            objAddEmployee.comboEmployeeStatus.DataSource = dsEstadosEmpleado.Tables["tbEmployeeStatus"];
            objAddEmployee.comboEmployeeStatus.DisplayMember = "employeeStatus";
            objAddEmployee.comboEmployeeStatus.ValueMember = "IdStatus";

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
                            daoInsertEmployee.EmployeeStatus = int.Parse(objAddEmployee.comboEmployeeStatus.SelectedValue.ToString());
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
        private int ValidateAge()
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
    }
}

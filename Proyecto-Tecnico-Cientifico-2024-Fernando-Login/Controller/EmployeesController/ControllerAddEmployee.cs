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
        }
        public void LeaveSalary(object sender, EventArgs e)
        {
            if (objAddEmployee.txtSalary.Text.Trim().Equals(""))
            {
                objAddEmployee.lblSalary.Visible = true;
                objAddEmployee.lblSalaryRequest.Visible = false;
                objAddEmployee.txtSalary.Text = "Ingrese con dos decimales";
            }
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
                //Se crea un objeto de la clase DAOAddEmployee y de la clase CommonClasses
                DAOAddEmployee daoInsertEmployee = new DAOAddEmployee();
                CommonClasses commonClasses = new CommonClasses();
                //Datos para la creación de un empleado
                daoInsertEmployee.Names = objAddEmployee.txtNames.Text;
                daoInsertEmployee.LastNames = objAddEmployee.txtLastNames.Text;
                daoInsertEmployee.Document = objAddEmployee.txtDUI.Text;
                daoInsertEmployee.BirthDate = objAddEmployee.dtBirthDate.Value.Date;
                daoInsertEmployee.Email = objAddEmployee.txtEmail.Text;
                daoInsertEmployee.Phone = objAddEmployee.txtPhone.Text;
                daoInsertEmployee.Address = objAddEmployee.txtAddress.Text;
                daoInsertEmployee.Salary = float.Parse(objAddEmployee.txtSalary.Text);
                daoInsertEmployee.BankAccount = objAddEmployee.txtBankAccount.Text;
                daoInsertEmployee.AffiliationNumber = int.Parse(objAddEmployee.txtAffiliationNumber.Text);
                daoInsertEmployee.HireDate = objAddEmployee.dpHireDate.Value.Date;
                daoInsertEmployee.Bank = int.Parse(objAddEmployee.comboBanks.SelectedValue.ToString());
                daoInsertEmployee.Department = int.Parse(objAddEmployee.comboDepartment.SelectedValue.ToString());
                daoInsertEmployee.EmployeeType = int.Parse(objAddEmployee.comboEmployeeType.SelectedValue.ToString());
                daoInsertEmployee.MaritalStatus = int.Parse(objAddEmployee.comboMaritalStatus.SelectedValue.ToString());
                daoInsertEmployee.EmployeeStatus = int.Parse(objAddEmployee.comboEmployeeStatus.SelectedValue.ToString());
                //Datos para la creación del usuario
                daoInsertEmployee.Username = objAddEmployee.txtUsername.Text;
                daoInsertEmployee.Password = commonClasses.ComputeSha256Hash(objAddEmployee.txtUsername.Text + "PU123");
                daoInsertEmployee.BusinessPosition = int.Parse(objAddEmployee.comboBusinessP.SelectedValue.ToString());
                daoInsertEmployee.UserSatus = true;
                //AHORA INVOCAMOS EL MÉTODO RegisterEmployee A TRAVÉS DEL OBJETO daoInsertEmployee
                int valorRespuesta = daoInsertEmployee.RegisterEmployee();
                //Verificamos el valor que nos retorna dicho método
                if (valorRespuesta == 1)
                {
                    MessageBox.Show("Los datos se registraron de manera exitosa", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objAddEmployee.Close();
                }
                else
                {
                    MessageBox.Show("Los datos no pudieron ser registrados", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


    }
}

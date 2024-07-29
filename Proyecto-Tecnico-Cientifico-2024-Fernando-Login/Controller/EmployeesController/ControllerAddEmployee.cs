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

namespace PTC2024.Controller
{
    internal class ControllerAddEmployee
    {
        FrmAddEmployee objAddEmployee;

        public ControllerAddEmployee(FrmAddEmployee View)
        {
            objAddEmployee = View;
            objAddEmployee.Load += new EventHandler(CargarCombos);
            //objAddEmployee.BtnAgregarEmpleado.Click += new EventHandler(AgregarEmpleado);
            objAddEmployee.BtnCancelar.Click += new EventHandler(CancelarProceso);
        }

        //private void BtnAgregarEmpleado_Click(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        public void CargarCombos(object sender, EventArgs e)
        {
            //creando objeto de la clase DAOAddEmployee
            DAOAddEmployee daoAddEmployee = new DAOAddEmployee();

            //Dropdown de Estados civiles
            DataSet dsEstadosCiviles = daoAddEmployee.ObtenerEstadosCiviles();
            objAddEmployee.comboEstadosCiviles.DataSource = dsEstadosCiviles.Tables["tbmaritalStatus"];
            objAddEmployee.comboEstadosCiviles.DisplayMember = "maritalStatus";
            objAddEmployee.comboEstadosCiviles.ValueMember = "IdMaritalS";

            //Dropdown de Departamentos
            DataSet dsDepartamentos = daoAddEmployee.ObtenerDepartamentos();
            objAddEmployee.comboDepartamento.DataSource = dsDepartamentos.Tables["tbDepartment"];
            objAddEmployee.comboDepartamento.DisplayMember = "departmentName";
            objAddEmployee.comboDepartamento.ValueMember = "IdDepartment";

            //Dropdown de tipos de empleado
            DataSet dsTiposEmpleado = daoAddEmployee.ObtenerTiposEmpleado();
            objAddEmployee.comboTipoEmpleado.DataSource = dsTiposEmpleado.Tables["tbTypeE"];
            objAddEmployee.comboTipoEmpleado.DisplayMember = "typeEmployee";
            objAddEmployee.comboTipoEmpleado.ValueMember = "IdTypeE";

            //Dropdown de puestos de empleado
            DataSet dsPuestosEmpleado = daoAddEmployee.ObtenerPuestosEmpleado();
            objAddEmployee.comboPuestoEmpleado.DataSource = dsPuestosEmpleado.Tables["tbBusinessP"];
            objAddEmployee.comboPuestoEmpleado.DisplayMember = "businessPosition";
            objAddEmployee.comboPuestoEmpleado.ValueMember = "IdBusinessP";

            //Dropdown de estado de empleado
            DataSet dsEstadosEmpleado = daoAddEmployee.ObtenerEstadosEmpleado();
            objAddEmployee.comboEstadoEmpleado.DataSource = dsEstadosEmpleado.Tables["tbEmployeeStatus"];
            objAddEmployee.comboEstadoEmpleado.DisplayMember = "employeeStatus";
            objAddEmployee.comboEstadoEmpleado.ValueMember = "IdStatus";
        }

        public void AgregarEmpleado(object sender, EventArgs e)
        {

        }

        public void CancelarProceso(object sender, EventArgs e)
        {
            objAddEmployee.Close();
        }


    }
}

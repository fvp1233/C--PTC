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
            objAddEmployee.BtnAgregarEmpleado.Click += new EventHandler(AgregarEmpleado);
        }

        public void CargarCombos(object sender, EventArgs e)
        {
            //creando objeto de la clase DAOAddEmployee
            DAOAddEmployee daoAddEmployee = new DAOAddEmployee();

            //Dropdown de Estados civiles
            DataSet dsEstadosCiviles = daoAddEmployee.ObtenerEstadosCiviles();
            objAddEmployee.comboEstadosCiviles.DataSource = dsEstadosCiviles.Tables["estadoCivil"];
            objAddEmployee.comboEstadosCiviles.DisplayMember = "nombreEstadoCivil";
            objAddEmployee.comboEstadosCiviles.ValueMember = "idEstadoCivil";

            //Dropdown de Departamentos
            DataSet dsDepartamentos = daoAddEmployee.ObtenerDepartamentos();
            objAddEmployee.comboDepartamento.DataSource = dsDepartamentos.Tables["departamentos"];
            objAddEmployee.comboDepartamento.DisplayMember = "nombreDepartamento";
            objAddEmployee.comboDepartamento.ValueMember = "idDepartamento";

            //Dropdown de tipos de empleado
            DataSet dsTiposEmpleado = daoAddEmployee.ObtenerTiposEmpleado();
            objAddEmployee.comboTipoEmpleado.DataSource = dsTiposEmpleado.Tables["tipoEmpleado"];
            objAddEmployee.comboTipoEmpleado.DisplayMember = "nombreTipoEmpleado";
            objAddEmployee.comboTipoEmpleado.ValueMember = "idTipoEmpleado";

            //Dropdown de puestos de empleado
            DataSet dsPuestosEmpleado = daoAddEmployee.ObtenerPuestosEmpleado();
            objAddEmployee.comboPuestoEmpleado.DataSource = dsPuestosEmpleado.Tables["puestoEmpleado"];
            objAddEmployee.comboPuestoEmpleado.DisplayMember = "nombrePuesto";
            objAddEmployee.comboPuestoEmpleado.ValueMember = "idPuestoEmpleado";

            //Dropdown de estado de empleado
            DataSet dsEstadosEmpleado = daoAddEmployee.ObtenerEstadosEmpleado();
            objAddEmployee.comboEstadoEmpleado.DataSource = dsEstadosEmpleado.Tables["estadoEmpleado"];
            objAddEmployee.comboEstadoEmpleado.DisplayMember = "nombreEstado";
            objAddEmployee.comboEstadoEmpleado.ValueMember = "idEstadoEmpleado";
        }

        public void AgregarEmpleado(object sender, EventArgs e)
        {
            
        }


    }
}

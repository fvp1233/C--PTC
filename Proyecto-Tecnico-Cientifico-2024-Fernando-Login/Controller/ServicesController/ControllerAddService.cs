using Microsoft.VisualBasic.Logging;
using PTC2024.Model.DAO.ServicesDAO;
using PTC2024.View.InventarioServicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.ServicesController
{
    internal class ControllerAddService
    {
        FrmAddService objAddService;

        public ControllerAddService(FrmAddService view)
        {
            objAddService = view;
            objAddService.Load += new EventHandler(cargarcombos);
            objAddService.BtnCancelar.Click += new EventHandler(CloseAddService);
            objAddService.btnAddService.Click += new EventHandler(AddService);
        }

        public void cargarcombos(object sender, EventArgs e)
        {
            DAOAddService daoAddService = new DAOAddService();

            DataSet dsAddService = daoAddService.ObtenerCategoriasServicios();
            objAddService.comboTipoEmpleado.DataSource = dsAddService.Tables["tbCategoryS"];
            objAddService.comboTipoEmpleado.DisplayMember = "categoryName";
            objAddService.comboTipoEmpleado.ValueMember = "IdCategory";
        }

        public void AddService(object sender, EventArgs e)
        {
            DAOAddService dAOAddService = new DAOAddService();
     
            /* Se le dan valores a los atributos del DAOAddService*/
    
            dAOAddService.Nombre = objAddService.txtNombres.Text;
            dAOAddService.Descripcion = objAddService.txtDescripcion.Text;
            dAOAddService.Categorias = (int)objAddService.comboTipoEmpleado.SelectedValue;
            dAOAddService.Monto = double.Parse(objAddService.txtMonto.Text);
            int respuesta = dAOAddService.InsertService();
            if (respuesta == 1)
            {
                MessageBox.Show("Los datos se ingresaron correctamente", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            objAddService.Close();
        }

        public void CloseAddService(object sender, EventArgs e)
        {
            objAddService.Close();
        }
    }
}

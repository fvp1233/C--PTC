using PTC2024.Model.DAO.ServicesDAO;
using PTC2024.Model.DTO.ServicesDTO;
using PTC2024.View.InventarioServicios;
using PTC2024.View.Service_inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.ServicesController
{
    internal class ControllerUpdateService
    {
        FrmUpdateService objUpdateService;
        private string categoria;
        public ControllerUpdateService(FrmUpdateService view, int id, string nombre, string descripcion, double monto, string categoria)
        {

            this.categoria = categoria;
            objUpdateService = view;
            objUpdateService.Load += new EventHandler(ChargeData);
            ChargeValues(id, nombre, descripcion, monto);
            objUpdateService.btnCloseUpdateService.Click += new EventHandler(CloseUpdateService);
            objUpdateService.btnUpdateService.Click += new EventHandler(UpdateService);
        }



        public void ChargeData(object sender, EventArgs e) 
        {
            DAOUpdateService dAOUpdateService = new DAOUpdateService();

            DataSet answer = dAOUpdateService.GetCategories();
            objUpdateService.comboTipoEmpleado.DataSource = answer.Tables["tbCategoryS"];
            objUpdateService.comboTipoEmpleado.DisplayMember = "categoryName";
            objUpdateService.comboTipoEmpleado.ValueMember = "IdCategory";
        }


        public void UpdateService(object sender, EventArgs e)
        {
            DAOUpdateService dAOUpdateService = new DAOUpdateService();
            dAOUpdateService.ServiceId = int.Parse(objUpdateService.txtId.Text);
            dAOUpdateService.Nombre = objUpdateService.txtNombres.Text;
            dAOUpdateService.Descripcion = objUpdateService.txtDescripcion.Text;
            dAOUpdateService.Categoria = int.Parse(objUpdateService.comboTipoEmpleado.SelectedValue.ToString());
            dAOUpdateService.Monto = double.Parse(objUpdateService.txtMonto.Text);

            int ValorRetornado = dAOUpdateService.UpdateService();
            
            if (ValorRetornado == 1)
            {
                MessageBox.Show("Los datos se actualizaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            objUpdateService.Close(); 

        }


        public void CloseUpdateService(object sender, EventArgs e)
        {
            objUpdateService.Close();
        }

        public void ChargeValues(int id, string nombre, string descripcion, double monto)
        {
            try
            {
                objUpdateService.txtId.Text = id.ToString();
                objUpdateService.txtNombres.Text = nombre;
                objUpdateService.txtDescripcion.Text = descripcion;
                objUpdateService.txtMonto.Text = monto.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
        }
    }
}

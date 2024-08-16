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
        /*Se crea el objeto del formulario*/
        FrmUpdateService objUpdateService;
        private string categoria;
        /*Se delara el constructor con sus respectivos parametros*/
        public ControllerUpdateService(FrmUpdateService view, int id, string nombre, string descripcion, double monto, string categoria)
        {

            this.categoria = categoria;
            /*Los controles del formulario ahora pasan al objeto del formulario*/
            objUpdateService = view;
            /*Este metodo cargara los valores de los parametros del constructor*/
            ChargeValues(id, nombre, descripcion, monto);
            /*Eventos*/
            objUpdateService.Load += new EventHandler(ChargeDropDown);
            objUpdateService.btnCloseUpdateService.Click += new EventHandler(CloseUpdateService);
            objUpdateService.btnUpdateService.Click += new EventHandler(UpdateService);
        }


        /*Este metodo cargara los valores del combobox*/
        public void ChargeDropDown(object sender, EventArgs e)
        {
            DAOUpdateService dAOUpdateService = new DAOUpdateService();

            /*Se guarda el valor retornado de GetCategories en la variable answer*/
            DataSet answer = dAOUpdateService.GetCategories();

            /*Aca se les asignan los valores al comboBox*/
            objUpdateService.comboTipoEmpleado.DataSource = answer.Tables["tbCategoryS"];
            objUpdateService.comboTipoEmpleado.DisplayMember = "categoryName";
            objUpdateService.comboTipoEmpleado.ValueMember = "IdCategory";
        }

        /*Este metodo se ejecutara cuando se vayan actualizar los datos*/
        public void UpdateService(object sender, EventArgs e)
        {

            bool Update;
            /*Se verifica si los campos no estan vacios*/
            if (objUpdateService.txtNombres.Text.Trim() == "" || objUpdateService.txtMonto.Text.Trim() == "")
            {
                Update = false;
                MessageBox.Show("Favor llenar los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Update= false;
                if (double.TryParse(objUpdateService.txtMonto.Text, out double result))
                {
                    Update = true;
                }
                else
                {
                    Update = false;
                    MessageBox.Show("Favor ingresar un valor numerico valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


            /*Si los campos no estan vacios entonces se siguq con el proceso*/
            if (Update == true)
            {
                DAOUpdateService dAOUpdateService = new DAOUpdateService();

                /*Se les asigna el valor a los atributos de la clase*/
                dAOUpdateService.ServiceId = int.Parse(objUpdateService.txtId.Text);
                dAOUpdateService.Nombre = objUpdateService.txtNombres.Text;
                dAOUpdateService.Descripcion = objUpdateService.txtDescripcion.Text;
                dAOUpdateService.Categoria = int.Parse(objUpdateService.comboTipoEmpleado.SelectedValue.ToString());
                dAOUpdateService.Monto = double.Parse(objUpdateService.txtMonto.Text);

                /*Se obtiene el valor retornado por el metodo UpdateService y se guarda en la variable ValorRetornado*/
                int ValorRetornado = dAOUpdateService.UpdateService();

                /*Se valida el valor retornado*/
                if (ValorRetornado == 1)
                {
                    MessageBox.Show("Los datos se actualizaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Los datos no pudieron ser actualizados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*Al haberse ejecutado todo se cerrara el formulario automaticamente*/
                objUpdateService.Close();

            }


        }

        /*Metodo para cerrar el formulario*/
        public void CloseUpdateService(object sender, EventArgs e)
        {
            /*Se cierra el formulario*/
            objUpdateService.Close();
        }

        /*Este metodo asigna los valores de los parametros que se le llevaran al constructor*/
        public void ChargeValues(int id, string nombre, string descripcion, double monto)
        {
            try
            {
                /*FrmServices objServices = new FrmServices();
                objUpdateService.combocliente.DataSource = objServices.DgvServicios;

                objUpdateService.combocliente.DisplayMember = objServices.DgvServicios[1, pos].ToString();*/


                /*Aca se les asignara un valor a los parametros para asi llevarlos al constructor*/
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



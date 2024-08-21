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
        /*Objeto del formulario*/
        FrmAddService objAddService;

        /*Constructor*/
        public ControllerAddService(FrmAddService view)
        {
            /*Eventos*/
            objAddService = view;
            objAddService.Load += new EventHandler(ChargeDropDowns);
            objAddService.BtnCancelar.Click += new EventHandler(CloseAddService);
            objAddService.btnAddService.Click += new EventHandler(AddService);
        }

        /*Metodo para cargar el combobox*/
        public void ChargeDropDowns(object sender, EventArgs e)
        {
            DAOAddService daoAddService = new DAOAddService();

            /*COMBO CATEGORIA DEL SERVICIO*/
            /*Aca se obtiene el valor que retorno el metodo*/
            DataSet dsAddService = daoAddService.GetCategories();
            /*Se establece el DataSource del ComboBox con la tabla "tbCategoryS"*/
            objAddService.comboTipoEmpleado.DataSource = dsAddService.Tables["tbCategoryS"];
            /*Se establece el miembro a mostrar en el ComboBox con el nombre de la categoría*/
            objAddService.comboTipoEmpleado.DisplayMember = "categoryName";
            /*Se establece el miembro de valor en el ComboBox con el Id de la categoría*/
            objAddService.comboTipoEmpleado.ValueMember = "IdCategory";
        }

        /*Metodo para añadir servicio*/
        public void AddService(object sender, EventArgs e)
        {
            bool Add;

            /*Se verifica si los campos no estan vacios*/
            if (objAddService.txtNombres.Text.Trim() == "" || objAddService.txtMonto.Text.Trim() == "")
            {
                Add = false;
                MessageBox.Show("Favor rellenar los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Add = false;
                if (double.TryParse(objAddService.txtMonto.Text,out double result))
                {
                    Add = true;
                }
                else
                {
                    Add = false;
                    MessageBox.Show("Favor ingresar un valor numerico valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


            /*Si los campos no estan vacios entonces se sigue con el proceso*/
            if (Add == true)
            {
                DAOAddService dAOAddService = new DAOAddService();

                /* Se le dan valores a los atributos del DAOAddService*/
                dAOAddService.Nombre = objAddService.txtNombres.Text;
                dAOAddService.Descripcion = objAddService.txtDescripcion.Text;
                dAOAddService.Categorias = (int)objAddService.comboTipoEmpleado.SelectedValue;
                dAOAddService.Monto = double.Parse(objAddService.txtMonto.Text);

                /*Se obtiene el valor que retorno el metodo InsertService*/
                int respuesta = dAOAddService.InsertService();

                /*Se valida la respuesta*/
                if (respuesta == 1)
                {
                    MessageBox.Show("Los datos se ingresaron correctamente", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objAddService.Close();
                }
                else
                {
                    MessageBox.Show("Los datos no pudieron ser ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        /*Metodo para cerrar el formulario*/
        public void CloseAddService(object sender, EventArgs e)
        {
            /*Se cierra el formulario*/
            objAddService.Close();
        }

    }
}

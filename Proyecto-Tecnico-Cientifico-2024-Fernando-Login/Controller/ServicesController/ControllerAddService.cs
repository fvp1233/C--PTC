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
            objAddService.txtNombres.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddService.txtDescripcion.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddService.txtMonto.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddService.txtMonto.TextChanged += new EventHandler(OnlyNum);
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

        private void DisableContextMenu(object sender, MouseEventArgs e)
        {
            // Desactiva el menú contextual al hacer clic derecho
            if (e.Button == MouseButtons.Right)
            {
                ((Bunifu.UI.WinForms.BunifuTextBox)sender).ContextMenu = new ContextMenu();  // Asigna un menú vacío
            }
        }
        public void OnlyNum(object sender, EventArgs e)
        {
            int cursorPosition = objAddService.txtMonto.SelectionStart;

            // Permitir solo dígitos y un solo punto decimal
            string text = new string(objAddService.txtMonto.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            // Asegurarse de que solo haya un punto decimal
            int decimalCount = text.Count(c => c == '.');
            if (decimalCount > 1)
            {
                // Si hay más de un punto decimal, remover los adicionales
                int firstDecimalIndex = text.IndexOf('.');
                text = text.Substring(0, firstDecimalIndex + 1) + text.Substring(firstDecimalIndex + 1).Replace(".", "");
            }

            // Asignar el texto filtrado al TextBox
            objAddService.txtMonto.Text = text;

            // Restablecer la posición del cursor
            objAddService.txtMonto.SelectionStart = cursorPosition;
        }

    }
}

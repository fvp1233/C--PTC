﻿using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.HelperDAO;
using PTC2024.Model.DAO.ServicesDAO;
using PTC2024.Model.DTO.ServicesDTO;
using PTC2024.Resources.Language;
using PTC2024.View.formularios.inicio;
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
        StartMenu objStartMenu;
        private string category;
        private int idCategory;
        /*Se delara el constructor con sus respectivos parametros*/
        public ControllerUpdateService(FrmUpdateService view, int id, string name, string description, double amount, string category, int idCategory)
        {

            this.category = category;
            this.idCategory = idCategory;
            /*Los controles del formulario ahora pasan al objeto del formulario*/
            objUpdateService = view;
            /*Este metodo cargara los valores de los parametros del constructor*/
            ChargeValues(id, name, description, amount);
            /*Eventos*/
            objUpdateService.Load += new EventHandler(ChargeDropDown);
            objUpdateService.btnCloseUpdateService.Click += new EventHandler(CloseUpdateService);
            objUpdateService.btnUpdateService.Click += new EventHandler(UpdateService);
            objUpdateService.txtName.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateService.txtDescription.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateService.txtAmount.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateService.txtAmount.TextChanged += new EventHandler(OnlyNum);
        }
        public void ChargeLanguage()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            EnglishL();
        }
        public void EnglishL()
        {
            objUpdateService.lblName.Text = English.addServiceTitle;
            objUpdateService.lblInformation.Text = English.addServiceDesc;
            objUpdateService.lblName.Text = English.addServiceDesc;
            objUpdateService.lblName.Text = English.nameService;
            objUpdateService.lblDescription.Text = English.description;
            objUpdateService.lblCategory.Text = English.category;
            objUpdateService.lblAmount.Text = English.amount;
            objUpdateService.btnUpdateService.Text = English.updateForm;
            objUpdateService.btnCloseUpdateService.Text = English.gobackForm;
        }
        public void OnlyNum(object sender, EventArgs e)
        {
            int cursorPosition = objUpdateService.txtAmount.SelectionStart;

            // Permitir solo dígitos y un solo punto decimal
            string text = new string(objUpdateService.txtAmount.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            // Asegurarse de que solo haya un punto decimal
            int decimalCount = text.Count(c => c == '.');
            if (decimalCount > 1)
            {
                // Si hay más de un punto decimal, remover los adicionales
                int firstDecimalIndex = text.IndexOf('.');
                text = text.Substring(0, firstDecimalIndex + 1) + text.Substring(firstDecimalIndex + 1).Replace(".", "");
            }

            // Evitar que el texto comience con un punto decimal
            if (text.StartsWith("."))
            {
                text = text.TrimStart('.');
            }

            // Limitar a solo dos decimales después del punto
            int decimalPosition = text.IndexOf('.');
            if (decimalPosition != -1 && text.Length > decimalPosition + 3)
            {
                // Truncar a dos dígitos después del punto decimal
                text = text.Substring(0, decimalPosition + 3);
            }

            // Asignar el texto filtrado al TextBox
            objUpdateService.txtAmount.Text = text;

            // Restablecer la posición del cursor
            objUpdateService.txtAmount.SelectionStart = cursorPosition;
        }



        /*Este metodo cargara los valores del combobox*/
        public void ChargeDropDown(object sender, EventArgs e)
        {
            DAOUpdateService dAOUpdateService = new DAOUpdateService();
            ChargeLanguage();
            /*Se guarda el valor retornado de GetCategories en la variable answer*/
            DataSet answer = dAOUpdateService.GetCategories();

            /*Aca se les asignan los valores al comboBox*/
            objUpdateService.cmbCategoryS.DataSource = answer.Tables["tbCategoryS"];
            objUpdateService.cmbCategoryS.DisplayMember = "categoryName";
            objUpdateService.cmbCategoryS.ValueMember = "IdCategory";
            objUpdateService.cmbCategoryS.SelectedValue = idCategory;
        }

        /*Este metodo se ejecutara cuando se vayan actualizar los datos*/
        public void UpdateService(object sender, EventArgs e)
        {

            bool Update;
            /*Se verifica si los campos no estan vacios*/
            if (objUpdateService.txtName.Text.Trim() == "" || objUpdateService.txtAmount.Text.Trim() == "")
            {
                Update = false;
                MessageBox.Show("Favor llenar los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Update= false;
                if (double.TryParse(objUpdateService.txtAmount.Text, out double result))
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
                dAOUpdateService.Name = objUpdateService.txtName.Text;
                dAOUpdateService.Description = objUpdateService.txtDescription.Text;
                dAOUpdateService.Category = int.Parse(objUpdateService.cmbCategoryS.SelectedValue.ToString());
                dAOUpdateService.Amount = double.Parse(objUpdateService.txtAmount.Text);

                /*Se obtiene el valor retornado por el metodo UpdateService y se guarda en la variable ValorRetornado*/
                int returnedValue = dAOUpdateService.UpdateService();

                /*Se valida el valor retornado*/
                if (returnedValue == 1)
                {
                    MessageBox.Show("Los datos se actualizaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DAOInitialView daoInitial = new DAOInitialView();
                    daoInitial.ActionType = "Se actualizó un servicio";
                    daoInitial.TableName = "Servicios";
                    daoInitial.ActionBy = SessionVar.Username;
                    daoInitial.ActionDate = DateTime.Now;
                    int auditAnswer = daoInitial.InsertAudit();
                    if (auditAnswer != 1)
                    {
                        objStartMenu.snackBar.Show(objStartMenu, $"La auditoria no pudo ser registrada", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                    }
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
        public void ChargeValues(int id, string name, string description, double amount)
        {
            try
            {
                /*FrmServices objServices = new FrmServices();
                objUpdateService.combocliente.DataSource = objServices.DgvServicios;

                objUpdateService.combocliente.DisplayMember = objServices.DgvServicios[1, pos].ToString();*/


                /*Aca se les asignara un valor a los parametros para asi llevarlos al constructor*/
                objUpdateService.txtId.Text = id.ToString();
                objUpdateService.txtName.Text = name;
                objUpdateService.txtDescription.Text = description;
                objUpdateService.txtAmount.Text = amount.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
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



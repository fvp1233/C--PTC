using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Model.DAO.CustomersDAO;
using PTC2024.View.Clientes;

namespace PTC2024.Controller.CustomersController
{
    internal class ControllerUpdateCustomers
    {
        FrmUploadCustomers objUpdateCustomers;
        private int idTypeC;

        //Se declara el constructor con sus respectivos parametros
        public ControllerUpdateCustomers(FrmUploadCustomers View, int idClient, string dui,string names, string lastnames,  string phone, string email, string address, int idTypeC)
        {

            objUpdateCustomers = View;
            this.idTypeC = idTypeC;
            ChargeValues(idClient, dui, names, lastnames, phone, email, address);
            //Evento para cargar los combos
            objUpdateCustomers.Load += new EventHandler(loadCombos);
            //Evento para actulizar los clientes
            objUpdateCustomers.BtnActualizarCliente.Click += new EventHandler(UpdateCustomers);
            //Evento para cancelar el proceso
            objUpdateCustomers.txtNames.TextChanged += new EventHandler(OnlyLettersName);
            objUpdateCustomers.txtLastNames.TextChanged += new EventHandler(OnlyLettersLastName);
            objUpdateCustomers.BtnCancelar.Click += new EventHandler(CancelProcess);
            objUpdateCustomers.txtNames.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateCustomers.txtLastNames.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateCustomers.txtDui.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateCustomers.txtAddress.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateCustomers.txtPhone.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateCustomers.txtEmail.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateCustomers.txtPhone.TextChanged += new EventHandler(PhoneMask);

        }

        public void loadCombos(object sender, EventArgs e)
        {
            DAOAddCustomers dAOAddCustomers = new DAOAddCustomers();


            DataSet dsclientType = dAOAddCustomers.getTypeCustomers();
            objUpdateCustomers.dpClientType.DataSource = dsclientType.Tables["tbTypeC"];
            objUpdateCustomers.dpClientType.DisplayMember = "customerType";
            objUpdateCustomers.dpClientType.ValueMember = "IdTypeC";
            objUpdateCustomers.dpClientType.SelectedValue = idTypeC;


        }

        public void UpdateCustomers(object sender, EventArgs e)
        {
            DAOUpdateCustomers daoUpdateCustomers = new DAOUpdateCustomers();

            daoUpdateCustomers.IdClient = int.Parse(objUpdateCustomers.txtId.Text); 
            daoUpdateCustomers.Dui = objUpdateCustomers.txtDui.Text;
            daoUpdateCustomers.Name = objUpdateCustomers.txtNames.Text;
            daoUpdateCustomers.LastNames = objUpdateCustomers.txtLastNames.Text;
            daoUpdateCustomers.Email = objUpdateCustomers.txtEmail.Text;
            daoUpdateCustomers.Address = objUpdateCustomers.txtAddress.Text;
            daoUpdateCustomers.Phone = objUpdateCustomers.txtPhone.Text;
            daoUpdateCustomers.ClientType = int.Parse(objUpdateCustomers.dpClientType.SelectedValue.ToString());

            int answer = daoUpdateCustomers.updateCustomers();
            if (answer == 1)
            {
                MessageBox.Show("Datos Actualizados");
                objUpdateCustomers.Close();
            }

          }

        public void ChargeValues(int idClient, string dui, string names, string lastnames, string phone, string email, string address) {


            try
            {
                objUpdateCustomers.txtId.Text = idClient.ToString();
                objUpdateCustomers.txtDui.Text = dui;
                objUpdateCustomers.txtNames.Text = names;
                objUpdateCustomers.txtLastNames.Text = lastnames;
                objUpdateCustomers.txtEmail.Text= email;
                objUpdateCustomers.txtAddress.Text = address;
                objUpdateCustomers.txtPhone.Text = phone;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void CancelProcess(object sender, EventArgs e)
        {
            objUpdateCustomers.Close();

        }

        private void DisableContextMenu(object sender, MouseEventArgs e)
        {
            // Desactiva el menú contextual al hacer clic derecho
            if (e.Button == MouseButtons.Right)
            {
                ((Bunifu.UI.WinForms.BunifuTextBox)sender).ContextMenu = new ContextMenu();  // Asigna un menú vacío
            }
        }
        public void PhoneMask(object sender, EventArgs e)
        {
            // Aquí se guarda la posición inicial del cursor, para que con el evento TextChanged el cursor no se mueva de lugar
            int cursorPosition = objUpdateCustomers.txtPhone.SelectionStart;

            // Remover cualquier dato no numérico
            string text = new string(objUpdateCustomers.txtPhone.Text.Where(c => char.IsDigit(c)).ToArray());

            // Validar que el número empiece con 2, 6 o 7
            if (text.Length > 0 && (text[0] != '2' && text[0] != '6' && text[0] != '7'))
            {
                // Si el primer carácter no es válido, limpiar el texto
                text = string.Empty;
            }

            // Aplicar la máscara de teléfono (ej: ####-###)
            if (text.Length >= 5)
            {
                text = text.Insert(4, "-");
            }

            // Ajustar la posición del cursor si está después del guion
            if (cursorPosition == 5)
            {
                cursorPosition++;
            }

            // Asignar el texto con la máscara al TextBox
            objUpdateCustomers.txtPhone.Text = text;

            // Restablecer la posición del cursor
            objUpdateCustomers.txtPhone.SelectionStart = cursorPosition;
        }
        public void OnlyLettersName(object sender, EventArgs e)
        {
            // Obtener la posición actual del cursor
            int cursorPosition = objUpdateCustomers.txtNames.SelectionStart;

            // Filtrar el texto para que solo queden letras
            string text = new string(objUpdateCustomers.txtNames.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            // Actualizar el contenido del TextBox con el texto filtrado
            objUpdateCustomers.txtNames.Text = text;

            // Restaurar la posición del cursor
            objUpdateCustomers.txtNames.SelectionStart = cursorPosition;
        }
        public void OnlyLettersLastName(object sender, EventArgs e)
        {
            // Obtener la posición actual del cursor
            int cursorPosition = objUpdateCustomers.txtLastNames.SelectionStart;

            // Filtrar el texto para que solo queden letras
            string text = new string(objUpdateCustomers.txtLastNames.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            // Actualizar el contenido del TextBox con el texto filtrado
            objUpdateCustomers.txtLastNames.Text = text;

            // Restaurar la posición del cursor
            objUpdateCustomers.txtLastNames.SelectionStart = cursorPosition;
        }



    }
}

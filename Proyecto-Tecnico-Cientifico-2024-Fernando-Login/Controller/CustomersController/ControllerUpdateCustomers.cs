using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Model.DAO.CustomersDAO;
using PTC2024.View.Clientes;
using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.HelperDAO;
using PTC2024.View.formularios.inicio;

namespace PTC2024.Controller.CustomersController
{
    internal class ControllerUpdateCustomers
    {
        FrmUploadCustomers objUpdateCustomers;
        StartMenu objStartMenu;
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
            if (ValidateEmail() == true)
            {
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
                    SendEmail();
                    MessageBox.Show("Datos Actualizados");
                    DAOInitialView daoInitial = new DAOInitialView();
                    daoInitial.ActionType = "Se actualizo un cliente";
                    daoInitial.TableName = "tbCustomer";
                    daoInitial.ActionBy = SessionVar.Username;
                    daoInitial.ActionDate = DateTime.Now;
                    int auditAnswer = daoInitial.InsertAudit();
                    if (auditAnswer != 1)
                    {
                        objStartMenu.snackBar.Show(objStartMenu, $"La auditoria no pudo ser registrada", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                    }
                    objUpdateCustomers.Close();
                }
                else
                {
                    MessageBox.Show("Datos no se pudieron actualizar", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
          }

        public void ChargeValues(int idClient, string dui, string names, string lastnames, string phone, string email, string address) 
        {
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
        private bool ValidateEmail()
        {
            string email = objUpdateCustomers.txtEmail.Text.Trim();

            // Verificar que el correo contenga una '@'
            if (!email.Contains("@"))
            {
                MessageBox.Show("El formato del correo es incorrecto, verifique que contenga '@'.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Asegurarse de que el correo tenga un dominio válido (parte después de '@')
            string domain = email.Substring(email.LastIndexOf('@') + 1);

            if (string.IsNullOrEmpty(domain))
            {
                MessageBox.Show("El formato del correo es incorrecto. No tiene un dominio válido.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verificar si el dominio tiene un registro MX
            if (!DomainHasMXRecord(domain))
            {
                MessageBox.Show("El dominio del correo no existe o no tiene un servidor de correo válido.", "Dominio inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool DomainHasMXRecord(string domain)
        {
            try
            {
                // Obtener registros DNS del dominio
                IPHostEntry hostEntry = Dns.GetHostEntry(domain);

                // Verificar que tenga registros de mail (MX)
                return hostEntry.AddressList.Length > 0;
            }
            catch (SocketException)
            {
                // Si ocurre un error al obtener la entrada DNS, el dominio no es válido o no tiene MX
                return false;
            }
        }

        public bool SendEmail()
        {
            string para = objUpdateCustomers.txtEmail.Text.Trim();
            string de = "h2c.soporte.usuarios@gmail.com";
            string subject = "H2C: Actualización del correo";
            string message = $"Hola estimado cliente, se ha realizado un cambio de correo electrónico en su registro como cliente con éxito.\nEste es un correo de confirmación, puede hacer caso omiso al mismo.";

            Email email = new Email();
            bool answer = email.UpdatedEmail(para, de, subject, message);

            return answer;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Model.DAO.CustomersDAO;
using PTC2024.View.Clientes;
using PTC2024.Controller.Helper;
using System.Windows.Forms;
using PTC2024.Model.DTO.CustomersDTO;
using System.Net.Sockets;
using System.Net;

namespace PTC2024.Controller.CustomersController
{
    class ControllerAddCustomers
    {
        FrmAddCustomers objAddCustomers;
        bool emailValidation; //Sirve para validar mas adelante el correo

        public ControllerAddCustomers(FrmAddCustomers Vista)
        {
            objAddCustomers = Vista;
            // Evento para cargar los combos
            objAddCustomers.Load += new EventHandler(LoadCombos);
            //Evento para agregar un cliente
            objAddCustomers.BtnAgregarCliente.Click += new EventHandler(AddClient);
            //Evento para cancelar el proceso
            objAddCustomers.BtnCancelar.Click += new EventHandler(CancelProcess);
            //Evento para validacion de dui
            objAddCustomers.txtDui.TextChange += new EventHandler(DUIMask);
            //Evento para validacion de telefono
            objAddCustomers.txtPhone.TextChange += new EventHandler(PhoneMask);
            //Eventos para evitar el copiar y pegar dentro de textbox
            objAddCustomers.txtNames.KeyDown += new KeyEventHandler(pasteDisabledNames);
            objAddCustomers.txtLastnames.KeyDown += new KeyEventHandler(pasteDisabledLastNames);
            objAddCustomers.txtDui.KeyDown += new KeyEventHandler(pasteDisabledDocument);
            objAddCustomers.txtNames.TextChanged += new EventHandler(OnlyLettersName);
            objAddCustomers.txtLastnames.TextChanged += new EventHandler(OnlyLettersLastName);
            objAddCustomers.txtAddress.KeyDown += new KeyEventHandler(pasteDisabledAddress);
            objAddCustomers.txtPhone.KeyDown += new KeyEventHandler(pasteDisabledPhone);
            objAddCustomers.txtEmail.KeyDown += new KeyEventHandler(pasteDisabledEmail);
            objAddCustomers.txtNames.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddCustomers.txtLastnames.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddCustomers.txtDui.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddCustomers.txtAddress.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddCustomers.txtPhone.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddCustomers.txtEmail.MouseDown += new MouseEventHandler(DisableContextMenu);
        }


        //Metodo para cargar el combo de tipo de empleado
        public void LoadCombos(object sender, EventArgs e)
        {
            DAOAddCustomers dAOAddCustomers = new DAOAddCustomers();
            DataSet dsClientType = dAOAddCustomers.getTypeCustomers();

            //Obtiene un conjunto de datos del dataset del tipo de empleado
            //Asigna la tabla tbTypeC para llenar el comboBox
            objAddCustomers.comboTypeC.DataSource = dsClientType.Tables["tbTypeC"];
            //Se mostrara el valor de los tipos de clientes al desplegar el comboBox
            objAddCustomers.comboTypeC.DisplayMember = "customerType";
            //Identifica que valor tiene (1,2)
            objAddCustomers.comboTypeC.ValueMember = "IdTypeC";
        }

        //Metodo para añadir un cliente
        public void AddClient(object sender, EventArgs e)
        {
            //validaciones para que no queden en blanco
            if (!(string.IsNullOrEmpty(objAddCustomers.txtNames.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtLastnames.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtDui.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtAddress.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtEmail.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtPhone.Text.Trim())
                ))
            {
                emailValidation = ValidateEmail();
                if (emailValidation == true)
                {
                    DAOAddCustomers dAOAddCustomers = new DAOAddCustomers();
                    CommonClasses commonClasses = new CommonClasses();

                    //Se le asgina el valor de los parametros 
                    dAOAddCustomers.Names = objAddCustomers.txtNames.Text;
                    dAOAddCustomers.Lastnames = objAddCustomers.txtLastnames.Text;
                    dAOAddCustomers.DUI1 = objAddCustomers.txtDui.Text;
                    dAOAddCustomers.Address = objAddCustomers.txtAddress.Text;
                    dAOAddCustomers.Email = objAddCustomers.txtEmail.Text;
                    dAOAddCustomers.Phone = objAddCustomers.txtPhone.Text;
                    dAOAddCustomers.ClientType = int.Parse(objAddCustomers.comboTypeC.SelectedValue.ToString());

                    //Se evalua el valorRespuesta del metodo register customer
                    int AnswerValue = dAOAddCustomers.RegisterCustomer();

                    if (AnswerValue == 1)
                    {//Si el valor es 1 se mostrara el mensaje
                        SendEmail();
                        MessageBox.Show("Los datos se registraron de manera exitosa", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        objAddCustomers.Close();

                    }
                    else
                    {//Si el valor es diferente a 1 se mostrara el mensaje de error
                        MessageBox.Show("Los datos no pudieron ser registrados", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    //Se evalua si todos los cambos estan llenos 
                    MessageBox.Show("Todos los campos son obligatorios y existen algunos vacíos, llene todos los apartados.", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //Metodo para cancelar el proceso
        //Unicamente cierra el formulario de añadir cliente y regresar al de clientes
        public void CancelProcess(object sender, EventArgs e)
        {
            objAddCustomers.Close();
        }


        private bool ValidateEmail()
        {
            string email = objAddCustomers.txtEmail.Text.Trim();

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

        public void DUIMask(object sender, EventArgs e)
        {
            // Aqui se guarda la posición inicial del cursor
            int cursorPosition = objAddCustomers.txtDui.SelectionStart;

            //Con esto se remueve cualquier dato no numérico excepto el guión
            string text = new string(objAddCustomers.txtDui.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());

            //Si ya existe algun guión, se elimina.
            text = text.Replace("-", "");

            //Acá especificamos la máscara del DUI, cuando llegue al caracter numero 9, va a ingresar el guion por si solo
            //
            if (text.Length >= 9)
            {
                text = text.Insert(8, "-");
            }
            else if (text.Length >= 1)
            {
                text = text.Insert(0, "");
            }
            if (cursorPosition == 9)
            {
                cursorPosition++;
            }

            //Le asignamos la máscara al texto que se presente en el textbox
            objAddCustomers.txtDui.Text = text;

            //Restablecemos la posicion del cursor
            objAddCustomers.txtDui.SelectionStart = cursorPosition;
        }

        public void PhoneMask(object sender, EventArgs e)
        {
            // Aquí se guarda la posición inicial del cursor, para que con el evento TextChanged el cursor no se mueva de lugar
            int cursorPosition = objAddCustomers.txtPhone.SelectionStart;

            // Remover cualquier dato no numérico
            string text = new string(objAddCustomers.txtPhone.Text.Where(c => char.IsDigit(c)).ToArray());

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
            objAddCustomers.txtPhone.Text = text;

            // Restablecer la posición del cursor
            objAddCustomers.txtPhone.SelectionStart = cursorPosition;
        }

        private void pasteDisabledNames (object sender, KeyEventArgs e)
        {
            // Verifica si se está presionando Ctrl+C o Ctrl+V
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                // Cancela la operación
                e.SuppressKeyPress = true;
            }
        }
        private void pasteDisabledLastNames(object sender, KeyEventArgs e)
        {
            // Verifica si se está presionando Ctrl+C o Ctrl+V
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                // Cancela la operación
                e.SuppressKeyPress = true;
            }
        }
        private void pasteDisabledDocument(object sender, KeyEventArgs e)
        {
            // Verifica si se está presionando Ctrl+C o Ctrl+V
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                // Cancela la operación
                e.SuppressKeyPress = true;
            }
        }
        private void pasteDisabledAddress(object sender, KeyEventArgs e)
        {
            // Verifica si se está presionando Ctrl+C o Ctrl+V
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                // Cancela la operación
                e.SuppressKeyPress = true;
            }
        }
        private void pasteDisabledPhone(object sender, KeyEventArgs e)
        {
            // Verifica si se está presionando Ctrl+C o Ctrl+V
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                // Cancela la operación
                e.SuppressKeyPress = true;
            }
        }
        private void pasteDisabledEmail(object sender, KeyEventArgs e)
        {
            // Verifica si se está presionando Ctrl+C o Ctrl+V
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                // Cancela la operación
                e.SuppressKeyPress = true;
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
        public void OnlyLettersName(object sender, EventArgs e)
        {
            // Obtener la posición actual del cursor
            int cursorPosition = objAddCustomers.txtNames.SelectionStart;

            // Filtrar el texto para que solo queden letras
            string text = new string(objAddCustomers.txtNames.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            // Actualizar el contenido del TextBox con el texto filtrado
            objAddCustomers.txtNames.Text = text;

            // Restaurar la posición del cursor
            objAddCustomers.txtNames.SelectionStart = cursorPosition;
        }

        public void OnlyLettersLastName(object sender, EventArgs e)
        {
            // Obtener la posición actual del cursor
            int cursorPosition = objAddCustomers.txtLastnames.SelectionStart;

            // Filtrar el texto para que solo queden letras
            string text = new string(objAddCustomers.txtLastnames.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            // Actualizar el contenido del TextBox con el texto filtrado
            objAddCustomers.txtLastnames.Text = text;

            // Restaurar la posición del cursor
            objAddCustomers.txtLastnames.SelectionStart = cursorPosition;
        }

        public bool SendEmail()
        {
            string para = objAddCustomers.txtEmail.Text.Trim();
            string de = "h2c.soporte.usuarios@gmail.com";
            string subject = "H2C: Gracias por visitarnos.";
            string message = $"Hola estimado cliente, se ha registrado este correo electrónico en su perfil como cliente en la empresa {BusinessVar.BusinessName}.\nEste es un correo de confirmación, puede hacer caso omiso al mismo.";

            Email email = new Email();
            bool answer = email.CustomerEmail(para, de, subject, message);

            return answer;
        }
    }
}
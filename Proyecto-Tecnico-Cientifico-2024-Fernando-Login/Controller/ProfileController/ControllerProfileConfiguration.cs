using PTC2024.Controller.Helper;
using PTC2024.Model.DAO;
using PTC2024.Model.DAO.ProfileDAO;
using PTC2024.View.formularios.inicio;
using PTC2024.View.ProfileSettings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PTC2024.Controller.ProfileController
{
    internal class ControllerProfileConfiguration
    {
        FrmProfileConfiguration objProfileC;
        public ControllerProfileConfiguration(FrmProfileConfiguration View, string names, string lastnames, string dui, string phone, string email, string adress, string affilitiation, string bankAccount)
        {
            objProfileC = View;
            ChargeValues(names, lastnames, dui, phone, email, adress, affilitiation, bankAccount);
            objProfileC.txtDui.TextChanged += new EventHandler(DUIMask);
            objProfileC.txtPhone.TextChanged += new EventHandler(PhoneMask);
            objProfileC.txtAffilliation.TextChanged += new EventHandler(AffiliatioNumberMask);
            objProfileC.txtBankA.TextChanged += new EventHandler(BankAccountMask);
            objProfileC.btnSavePhoto.Click += new EventHandler(PutImage);
            objProfileC.btnGuardar.Click += new EventHandler(UpdateInfo);
            objProfileC.btnChangePassword.Click += new EventHandler(ChangePass);
            objProfileC.txtNames.MouseDown += new MouseEventHandler(DisableContextMenu);
            objProfileC.txtLastNames.MouseDown += new MouseEventHandler(DisableContextMenu);
            objProfileC.txtEmail.MouseDown += new MouseEventHandler(DisableContextMenu);
            objProfileC.txtNames.TextChanged += new EventHandler(OnlyLettersName);
            objProfileC.txtLastNames.TextChanged += new EventHandler(OnlyLettersLastName);
            objProfileC.txtPhone.MouseDown += new MouseEventHandler(DisableContextMenu);
            objProfileC.txtDui.MouseDown += new MouseEventHandler(DisableContextMenu);
            objProfileC.txtBankA.MouseDown += new MouseEventHandler(DisableContextMenu);
            objProfileC.txtAffilliation.MouseDown += new MouseEventHandler(DisableContextMenu);
            objProfileC.txtAddress.MouseDown += new MouseEventHandler(DisableContextMenu);
            objProfileC.txtEmail.TextChanged += new EventHandler(EmailValidation);
        }

        public void ChargeValues(string names, string lastnames, string dui, string phone, string email, string adress, string affilitiation, string bankAccount)
        {
            try
            {
                objProfileC.txtNames.Text = names;
                objProfileC.txtLastNames.Text = lastnames;
                objProfileC.txtDui.Text = dui;
                objProfileC.txtPhone.Text = phone;
                objProfileC.txtEmail.Text = email;
                objProfileC.txtAddress.Text = adress;
                objProfileC.txtAffilliation.Text = affilitiation;
                objProfileC.txtBankA.Text = bankAccount;
                objProfileC.picUser.Image = ByteArrayToImage(SessionVar.ProfilePic);
            }
            catch
            {

            }
        }

        public Image ByteArrayToImage(byte[] byteArray)
        {
            Image imageDefaul = objProfileC.picUser.Image;
            if (byteArray == null || byteArray.Length == 0)
            {
                // En caso de que byteArrary sea nulo o este vacio         
                return imageDefaul; //devolvemos la imagen por defecto que trae el picturebox
            }

            MemoryStream ms = new MemoryStream(byteArray);
            return Image.FromStream(ms);
        }

        public void SavePfp()
        {
            try
            {
                DAOProfileConfiguration daoProfile = new DAOProfileConfiguration();
                Image image = objProfileC.picUser.Image;
                byte[] imageBytes;
                if (image == null)
                {
                    imageBytes = null;
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    image.Save(ms, ImageFormat.Jpeg);
                    imageBytes = ms.ToArray();
                }
                daoProfile.ProfilePicture = imageBytes;
                daoProfile.Username = SessionVar.Username;
                int answer = daoProfile.SavePfp();
                if (answer == 1)
                {
                    MessageBox.Show($"Tu nueva foto de perfil se ha agregado exitosamente.", "Agregar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Algo salio mal al actualizar tu foto, intentalo nuevamente", "Agregar imagen interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error al procesar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void PutImage(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png| Todos los archivos(*.*)| *.* ";
            ofd.Title = "Seleccionar imagen";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string imageRute = ofd.FileName;
                objProfileC.picUser.Image = Image.FromFile(imageRute);
            }
        }

        public void UpdateInfo(object sender, EventArgs e)
        {
            
            //validación campos vacíos
            if (!(string.IsNullOrEmpty(objProfileC.txtNames.Text.Trim()) ||
                  string.IsNullOrEmpty(objProfileC.txtLastNames.Text.Trim()) ||
                  string.IsNullOrEmpty(objProfileC.txtDui.Text.Trim()) ||
                  string.IsNullOrEmpty(objProfileC.txtPhone.Text.Trim()) ||
                  string.IsNullOrEmpty(objProfileC.txtEmail.Text.Trim()) ||
                  string.IsNullOrEmpty(objProfileC.txtAddress.Text.Trim()) ||
                  string.IsNullOrEmpty(objProfileC.txtAffilliation.Text.Trim()) ||
                  string.IsNullOrEmpty(objProfileC.txtBankA.Text.Trim())
                ))
            {
                //validación dominio del correo
                if (ValidateEmail() == true)
                {
                    //Validación para saber si el Dui ya esta ingresado en otro usuario
                    if (CheckDUI() == false)
                    {
                        //validación para saber si el email ya esta registrado
                        if (CheckEmail() == false)
                        {
                            bool answerEmail = SendEmail();
                            if(answerEmail == true)
                            {
                                //damos valor a los getters
                                DAOProfileConfiguration daoP = new DAOProfileConfiguration();
                                daoP.FirstName = objProfileC.txtNames.Text.Trim();
                                daoP.LastName = objProfileC.txtLastNames.Text.Trim();
                                daoP.Dui = objProfileC.txtDui.Text.Trim();
                                daoP.Phone = objProfileC.txtPhone.Text.Trim();
                                daoP.Email = objProfileC.txtEmail.Text.Trim();
                                daoP.Address = objProfileC.txtAddress.Text.Trim();
                                daoP.SecurityNumber = objProfileC.txtAffilliation.Text.Trim();
                                daoP.BanckAccount = objProfileC.txtBankA.Text.Trim();
                                daoP.Username = SessionVar.Username;
                                //ejecutamos el método update
                                int answer = daoP.UpdateInfo();
                                if (answer == 1)
                                {
                                    //si es 1, los datos se actualizaron correctamente, pasamos a actualizar la foto ingresada.
                                    StartMenu start = new StartMenu(SessionVar.Username);
                                    FrmProfile objProfile = new FrmProfile();
                                    SavePfp();
                                    daoP.ReadNewCredentials();
                                    objProfileC.Close();
                                    daoP.ReadNewCredentials();
                                    start.btnIcon.Image = ByteArrayToImage(SessionVar.ProfilePic);
                                    objProfile.lblFullName.Text = SessionVar.FullName;
                                    objProfile.lblUser.Text = SessionVar.Username;
                                    objProfile.lblEAdress.Text = SessionVar.Email;
                                    objProfile.lblPhone.Text = SessionVar.Phone;
                                    objProfile.lblAddress.Text = SessionVar.Adress;
                                    objProfile.picUser.Image = ByteArrayToImage(SessionVar.ProfilePic);
                                    objProfileC.snack.Show(start, "Reinicie el programa o cierre y vuelva a iniciar sesión para ver todos los cambios.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                                    objProfileC.snack.Show(start, "Su información se actualizó correctamente.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);

                                }
                                else
                                {
                                    objProfileC.snack.Show(objProfileC, "No se pudieron actualizar sus datos, inténtelo de nuevo", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomCenter);
                                }
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("El correo ingresado ya está registrado en el sistema con otro empleado.", "Correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El DUI ingresado ya está registrado en el sistema con otro empleado.", "Documento de identidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios y existen algunos vacíos, llene todos los apartados.",
                                    "Proceso interrumpido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
        }

        private bool ValidateEmail()
        {
            string email = objProfileC.txtEmail.Text.Trim();

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
        //Método para establecer una máscara al textbox del DUI
        public void DUIMask(object sender, EventArgs e)
        {
            // Aqui se guarda la posición inicial del cursor
            int cursorPosition = objProfileC.txtDui.SelectionStart;

            //Con esto se remueve cualquier dato no numérico excepto el guión
            string text = new string(objProfileC.txtDui.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());

            //Si ya existe algun guión, se elimina.
            text = text.Replace("-", "");

            //Acá especificamos la máscara del DUI, cuando llegue al caracter numero 9, va a ingresar el guion por si solo
            //
            if (text.Length >= 9)
            {
                text = text.Insert(8, "-");
                cursorPosition++;
            }
            else if (text.Length >= 1)
            {
                text = text.Insert(0, "");
            }

            //Le asignamos la máscara al texto que se presente en el textbox
            objProfileC.txtDui.Text = text;

            //Restablecemos la posicion del cursor
            objProfileC.txtDui.SelectionStart = cursorPosition;
        }

        //Máscara para el textbox del telefono
        public void PhoneMask(object sender, EventArgs e)
        {
            // Aquí se guarda la posición inicial del cursor, para que con el evento TextChanged el cursor no se mueva de lugar
            int cursorPosition = objProfileC.txtPhone.SelectionStart;

            // Remover cualquier dato no numérico
            string text = new string(objProfileC.txtPhone.Text.Where(c => char.IsDigit(c)).ToArray());
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
            objProfileC.txtPhone.Text = text;

            // Restablecer la posición del cursor
            objProfileC.txtPhone.SelectionStart = cursorPosition;
        }

        //Aplicamos una máscara que solo deje meter el guion y caracteres numéricos para los textbox de numero de afiliacion y cuenta bancaria.
        public void AffiliatioNumberMask(object sender, EventArgs e)
        {
            int cursorPosition = objProfileC.txtAffilliation.SelectionStart;
            //Con esto se remueve cualquier dato no numérico excepto el guion
            string text = new string(objProfileC.txtAffilliation.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());
            objProfileC.txtAffilliation.Text = text;
            objProfileC.txtAffilliation.SelectionStart = cursorPosition;
        }

        public void BankAccountMask(object sender, EventArgs e)
        {
            int cursorPosition = objProfileC.txtBankA.SelectionStart;
            //Con esto se remueve cualquier dato no numérico excepto el guion
            string text = new string(objProfileC.txtBankA.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());
            objProfileC.txtBankA.Text = text;
            objProfileC.txtBankA.SelectionStart = cursorPosition;
        }

        public bool CheckDUI()
        {
            //Creamos objeto del DAO
            DAOProfileConfiguration daoProfile = new DAOProfileConfiguration();
            //Damos valor al getter username
            daoProfile.Dui = objProfileC.txtDui.Text.Trim();
            daoProfile.Username = SessionVar.Username;
            // Creamos variable bool
            bool answer = daoProfile.CheckDUI();
            //Retornamos esta variable
            return answer;
        }

        public bool CheckEmail()
        {
            //Creamos objeto del DAO
            DAOProfileConfiguration daoProfile = new DAOProfileConfiguration();
            //Damos valor al getter username
            daoProfile.Email = objProfileC.txtEmail.Text.Trim();
            daoProfile.Username = SessionVar.Username;
            // Creamos variable bool
            bool answer = daoProfile.CheckEmail();
            //Retornamos esta variable
            return answer;
        }

        public void ChangePass(object sender, EventArgs e)
        {
            FrmChangeUserPass open = new FrmChangeUserPass();
            open.ShowDialog();
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
            int cursorPosition = objProfileC.txtNames.SelectionStart;

            // Filtrar el texto para que solo queden letras
            string text = new string(objProfileC.txtNames.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            // Actualizar el contenido del TextBox con el texto filtrado
            objProfileC.txtNames.Text = text;

            // Restaurar la posición del cursor
            objProfileC.txtNames.SelectionStart = cursorPosition;
        }
        public void OnlyLettersLastName(object sender, EventArgs e)
        {
            // Obtener la posición actual del cursor
            int cursorPosition = objProfileC.txtLastNames.SelectionStart;

            // Filtrar el texto para que solo queden letras
            string text = new string(objProfileC.txtLastNames.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            // Actualizar el contenido del TextBox con el texto filtrado
            objProfileC.txtLastNames.Text = text;

            // Restaurar la posición del cursor
            objProfileC.txtLastNames.SelectionStart = cursorPosition;
        }
        public void EmailValidation(object sender, EventArgs e)
        {
            int cursorPosition = objProfileC.txtEmail.SelectionStart;

            // Filtrar solo caracteres permitidos para un email: letras, números, @, . y algunos caracteres especiales comunes
            string text = new string(objProfileC.txtEmail.Text.Where(c => char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '_' || c == '-').ToArray());

            // Asegurarse de que el @ no sea el primer carácter
            if (text.StartsWith("@"))
            {
                // Remover el @ si está al inicio
                text = text.Substring(1);
            }

            // Asignar el texto filtrado al TextBox
            objProfileC.txtEmail.Text = text;

            // Restablecer la posición del cursor
            objProfileC.txtEmail.SelectionStart = cursorPosition;
        }

        public bool SendEmail()
        {
            string para = objProfileC.txtEmail.Text.Trim();
            string de = "h2c.soporte.usuarios@gmail.com";
            string subject = "H2C: Actualización del correo";
            string message = $"Hola, {SessionVar.FullName}, se ha realizado un cambio de correo electrónico en su cuenta: '{SessionVar.Username}' con éxito.\nEste es un correo de confirmación, puede hacer caso omiso al mismo.";

            Email email = new Email();
            bool answer = email.UpdatedEmail(para, de, subject, message);

            return answer;
        }

    }
}

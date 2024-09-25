using PTC2024.View.Maintenance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.MaintenanceDAO;
using PTC2024.Model.DAO.ProfileDAO;
using System.Windows.Forms;
using PTC2024.View.formularios.inicio;
using PTC2024.Model.DAO;

namespace PTC2024.Controller.MaintenanceController
{
    internal class ControllerBusinessConfiguration
    {
        FrmBusinessConfiguration objBusinessConf;
        public ControllerBusinessConfiguration(FrmBusinessConfiguration View)
        {
            objBusinessConf = View;
            objBusinessConf.Load += new EventHandler(LoadData);
            objBusinessConf.btnUploadPhoto.Click += new EventHandler(PutImage);
            objBusinessConf.btnSave.Click += new EventHandler(UpdateInfoBusiness);
            objBusinessConf.txtPhone.TextChanged += new EventHandler(PhoneMask);
            objBusinessConf.txtPBX.TextChanged += new EventHandler(PBXMask);
            objBusinessConf.txtBusinessName.MouseDown += new MouseEventHandler(DisableContextMenu);
            objBusinessConf.txtEmail.MouseDown += new MouseEventHandler(DisableContextMenu);
            objBusinessConf.txtAdress.MouseDown += new MouseEventHandler(DisableContextMenu);
            objBusinessConf.txtPBX.MouseDown += new MouseEventHandler(DisableContextMenu);
            objBusinessConf.txtPhone.MouseDown += new MouseEventHandler(DisableContextMenu);
            objBusinessConf.txtEmail.TextChanged += new EventHandler(EmailValidation);
        }
        public void LoadData(object sender, EventArgs e)
        {
            DAOBusinessConfiguration objDao = new DAOBusinessConfiguration();
            objBusinessConf.picBusiness.Image = ByteArrayToImage(BusinessVar.BusinessImg);
            objBusinessConf.txtBusinessName.Text = BusinessVar.BusinessName;
            objBusinessConf.txtAdress.Text = BusinessVar.BusinessAdress;
            objBusinessConf.txtEmail.Text = BusinessVar.BusinessEmail;
            objBusinessConf.txtPhone.Text = BusinessVar.BusinessPhone;
            objBusinessConf.txtPBX.Text = BusinessVar.BusinessPBX;
            objBusinessConf.txtID.Text = BusinessVar.IdBusiness.ToString();
            objBusinessConf.txtID.Visible = false;
        }
        public void UpdateInfoBusiness(object sender, EventArgs e)
        {
            DAOBusinessConfiguration DAObusiness = new DAOBusinessConfiguration();
            DAObusiness.IdBusiness = BusinessVar.IdBusiness;
            DAObusiness.NameBusiness = objBusinessConf.txtBusinessName.Text.Trim();
            DAObusiness.AddressBusiness = objBusinessConf.txtAdress.Text.Trim();
            DAObusiness.EmailBusiness = objBusinessConf.txtEmail.Text.Trim();
            DAObusiness.PhoneBusiness = objBusinessConf.txtPBX.Text.Trim();
            DAObusiness.PbxBusiness = objBusinessConf.txtPBX.Text.Trim();
            int answer = DAObusiness.UpdateBusinessInfo();
            if (answer == 1)
            {
                SavePfp();
                MessageBox.Show("Se enviará un correo al email del usuario para confirmar el correo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SendEmail();
                StartMenu start = new StartMenu(SessionVar.Username);
                objBusinessConf.snack.Show(start, "Reinicie el programa o cierre y vuelva a iniciar sesión para ver todos los cambios.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                objBusinessConf.snack.Show(start, "Su información se actualizó correctamente.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                Close();
            }
            else
            {
                objBusinessConf.snack.Show(objBusinessConf, "No se pudieron actualizar sus datos, inténtelo de nuevo", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomCenter);
            }
        }
        public void SavePfp()
        {
            try
            {
                DAOBusinessConfiguration daoBusiness = new DAOBusinessConfiguration();
                Image image = objBusinessConf.picBusiness.Image;
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
                daoBusiness.ImageBusiness = imageBytes;
                daoBusiness.IdBusiness = BusinessVar.IdBusiness;
                int answer = daoBusiness.SavePfp();
                if (answer == 1)
                {
                    MessageBox.Show($"Tu foto de perfil se ha agregado exitosamente.", "Agregar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                objBusinessConf.picBusiness.Image = Image.FromFile(imageRute);
            }
        }
        public Image ByteArrayToImage(byte[] byteArray)
        {
            Image imageDefaul = objBusinessConf.picBusiness.Image;
            if (byteArray == null || byteArray.Length == 0)
            {
                // En caso de que byteArrary sea nulo o este vacio         
                return imageDefaul; //devolvemos la imagen por defecto que trae el picturebox
            }

            MemoryStream ms = new MemoryStream(byteArray);
            return Image.FromStream(ms);
        }
        public void Close()
        {
            objBusinessConf.Close();
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
            //Aqui se guarda la posición inicial del cursor, para que con el evento TextChanged el cursor no se mueva de lugar y no sea molesto para el usuario
            int cursorPosition = objBusinessConf.txtPhone.SelectionStart;

            //Con esto se remueve cualquier dato no numérico
            string text = new string(objBusinessConf.txtPhone.Text.Where(c => char.IsDigit(c)).ToArray());

            if (text.Length >= 5)
            {
                text = text.Insert(4, "-");

            }

            //Con esto se reposiciona el cursor, ya no se coloca antes del numero que va siguiente al guion, si no que se reajusta para que  se ponga en el orden que iba anteriormente
            if (cursorPosition == 5)
            {
                cursorPosition++;
            }

            //Le asignamos la máscara al texto que se ponga en el textbox
            objBusinessConf.txtPhone.Text = text;

            //Restablecemos la posición del cursor con la variable que se guardó antes
            objBusinessConf.txtPhone.SelectionStart = cursorPosition;
        }

        public void PBXMask(object sender, EventArgs e)
        {
            //Aqui se guarda la posición inicial del cursor, para que con el evento TextChanged el cursor no se mueva de lugar y no sea molesto para el usuario
            int cursorPosition = objBusinessConf.txtPBX.SelectionStart;

            //Con esto se remueve cualquier dato no numérico
            string text = new string(objBusinessConf.txtPBX.Text.Where(c => char.IsDigit(c)).ToArray());

            if (text.Length >= 5)
            {
                text = text.Insert(4, "-");

            }

            //Con esto se reposiciona el cursor, ya no se coloca antes del numero que va siguiente al guion, si no que se reajusta para que  se ponga en el orden que iba anteriormente
            if (cursorPosition == 5)
            {
                cursorPosition++;
            }

            //Le asignamos la máscara al texto que se ponga en el textbox
            objBusinessConf.txtPBX.Text = text;

            //Restablecemos la posición del cursor con la variable que se guardó antes
            objBusinessConf.txtPBX.SelectionStart = cursorPosition;
        }
        public void EmailValidation(object sender, EventArgs e)
        {
            int cursorPosition = objBusinessConf.txtEmail.SelectionStart;

            // Filtrar solo caracteres permitidos para un email: letras, números, @, . y algunos caracteres especiales comunes
            string text = new string(objBusinessConf.txtEmail.Text.Where(c => char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '_' || c == '-').ToArray());

            // Asegurarse de que el @ no sea el primer carácter
            if (text.StartsWith("@"))
            {
                // Remover el @ si está al inicio
                text = text.Substring(1);
            }

            // Asignar el texto filtrado al TextBox
            objBusinessConf.txtEmail.Text = text;

            // Restablecer la posición del cursor
            objBusinessConf.txtEmail.SelectionStart = cursorPosition;
        }
        public bool SendEmail()
        {

            string para = objBusinessConf.txtEmail.Text.Trim();
            string de = "h2c.soporte.usuarios@gmail.com";
            string subject = $"H2C: Bienvenido a {BusinessVar.BusinessName} nuevo empleado.";
            string message = $"Hola estimado usuario, este correo ahora esta asociado a la empresa {BusinessVar.BusinessName}.";

            Email email = new Email();
            bool answer = email.UpdateBusiness(para, de, subject, message);

            return answer;
        }
    }


}

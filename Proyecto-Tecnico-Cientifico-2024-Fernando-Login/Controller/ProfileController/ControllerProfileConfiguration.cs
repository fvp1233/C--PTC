using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.ProfileDAO;
using PTC2024.View.ProfileSettings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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
            objProfileC.btnSavePhoto.Click += new EventHandler(PutImage);
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

        public void SaveInfo(object sender, EventArgs e)
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
                int answer = daoProfile.SaveInfo();
                if (answer == 1)
                {
                    MessageBox.Show($"Tu foto de perfil se ha agregado exitosamente.", "Agregar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Algo salio mal al cargar tu imagen, intentalo nuevamente", "Agregar imagen interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}

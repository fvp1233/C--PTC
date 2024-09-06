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
    }
}

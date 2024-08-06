using PTC2024.Model.DAO.FirstUseDAO;
using PTC2024.View.FirstUse;
using PTC2024.View.login;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.FirstUseController
{
    internal class ControllerFirstUse
    {
        FrmFirstUse objFistUse;
        bool action;
        public ControllerFirstUse(FrmFirstUse View)
        {
            objFistUse = View;
            View.btnSave.Click += new EventHandler(SaveInfo);
            View.btnAddImage.Click += new EventHandler(PutImage);

        }
        void SaveInfo(object sender, EventArgs e)
        {
            try
            {
                //Validacion para ferificar que todos los campos esten llenos
                if (!(string.IsNullOrEmpty(objFistUse.txtNameBusiness.Text.Trim()) ||
                    string.IsNullOrEmpty(objFistUse.txtAddress.Text.Trim()) ||
                    string.IsNullOrEmpty(objFistUse.txtEmail.Text.Trim()) ||
                    string.IsNullOrEmpty(objFistUse.txtPhone.Text.Trim()) ||
                    string.IsNullOrEmpty(objFistUse.txtPBX.Text.Trim()) ||
                    objFistUse.picBusiness.Image == null))
                {
                    DAOFirstUse DAOSave = new DAOFirstUse();
                    DAOSave.NameBusiness = objFistUse.txtNameBusiness.Text.Trim();
                    DAOSave.AddressBusiness = objFistUse.txtAddress.Text.Trim();
                    DAOSave.EmailBusiness = objFistUse.txtEmail.Text.Trim();
                    DAOSave.DateBusiness = objFistUse.dtCreationDate.Value.Date;
                    DAOSave.PhoneBusiness = objFistUse.txtPhone.Text.Trim();
                    DAOSave.PbxBusiness = objFistUse.txtPBX.Text.Trim();
                    //Guardar Imagen
                    Image image = objFistUse.picBusiness.Image;
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
                    action = ValidateEmail();
                    if (action == true)
                    {
                        DAOSave.ImageBusiness = imageBytes;
                        bool answer = DAOSave.AddBusiness();
                        if (answer != false)
                        {
                            MessageBox.Show($"Tu negocio ha sido registrada exitosamente.", "Creación de negocio completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FrmRegister nextForm = new FrmRegister();
                            nextForm.Show();
                            objFistUse.Hide();
                        }
                        else
                        {
                            MessageBox.Show($"Oops, algo salio mal, revisemos los datos e intentemos nuevamente.", "Creacion de negocio  interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Todos los campos son requeridos.", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                objFistUse.picBusiness.Image = Image.FromFile(imageRute);
            }
        }
        bool ValidateEmail()
        {
            string email = objFistUse.txtEmail.Text.Trim();
            if (!(email.Contains("@")))
            {
                MessageBox.Show("Formato de correo invalido, verifica que contiene @.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string[] dominiosPermitidos = { "gmail.com", "ricaldone.edu.sv" };
            string extension = email.Substring(email.LastIndexOf('@') + 1);
            if (!dominiosPermitidos.Contains(extension))
            {
                MessageBox.Show("Dominio del correo es invalido, el sistema unicamente admite dominios 'gmail.com' y 'correo institucional'.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}

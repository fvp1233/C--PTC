using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.Model.DAO.ProfileDAO;
using PTC2024.View.login;
using PTC2024.View.ProfileSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PTC2024.Controller.ProfileController
{
    internal class ControllerProfile
    {
        FrmProfile objProfile;
        public ControllerProfile(FrmProfile View)
        {
            objProfile = View;
            objProfile.Load += new EventHandler(ChargeValues);
            //objProfile.btnSavePhoto.Click += new EventHandler(PutImage);
            //objProfile.btnSave.Click += new EventHandler(SaveInfo);
            objProfile.btnSecurityQ.Click += new EventHandler(SecurityQuestions);
            objProfile.btnUpdate.Click += new EventHandler(UpdateInfo);
            objProfile.btnUserManual.Click += new EventHandler(OpenManualU);
            objProfile.btnManualT.Click += new EventHandler(OpenManualT);
            objProfile.btnMore.Click += new EventHandler(OpenOptions);
            
        }

        public void ChargeValues(object sender, EventArgs e)
        {
            objProfile.lblFullName.Text = SessionVar.FullName;
            objProfile.lblUser.Text = SessionVar.Username;
            objProfile.lblEAdress.Text = SessionVar.Email;
            objProfile.lblPhone.Text = SessionVar.Phone;
            objProfile.lblCharge.Text = SessionVar.Access;
            objProfile.lblAddress.Text = SessionVar.Adress;
            objProfile.picUser.Image = ByteArrayToImage(SessionVar.ProfilePic);
            if(Properties.Settings.Default.darkMode == true)
            {
                objProfile.BackColor = Color.FromArgb(18,18,18);
                objProfile.lblTitle.ForeColor = Color.White;
                objProfile.lblSubtitle.ForeColor = Color.White;
                objProfile.bunifuSeparator1.LineColor = Color.White;
                objProfile.lblEmployeeName.ForeColor = Color.White;
                objProfile.lblFullName.ForeColor = Color.White;
                objProfile.lblUserTitle.ForeColor = Color.White;
                objProfile.lblUser.ForeColor = Color.White;
                objProfile.lblEmailTitle.ForeColor = Color.White;
                objProfile.lblEAdress.ForeColor = Color.White;
                objProfile.lblPTitle.ForeColor = Color.White;
                objProfile.lblPhone.ForeColor = Color.White;
                objProfile.lblATitle.ForeColor = Color.White;
                objProfile.lblAddress.ForeColor = Color.White;
                objProfile.lblRoleTitle.ForeColor = Color.White;
                objProfile.lblCharge.ForeColor = Color.White;
                //objProfile.btnManualT.OnIdleState.FillColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnManualT.OnIdleState.BorderColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnManualT.IdleFillColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnManualT.IdleBorderColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnSecurityQ.OnIdleState.FillColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnSecurityQ.OnIdleState.BorderColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnSecurityQ.IdleFillColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnSecurityQ.IdleBorderColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnUpdate.OnIdleState.FillColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnUpdate.OnIdleState.BorderColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnUpdate.IdleFillColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnUpdate.IdleBorderColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnUserManual.OnIdleState.FillColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnUserManual.OnIdleState.BorderColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnUserManual.IdleFillColor = Color.FromArgb(26, 32, 161);
                //objProfile.btnUserManual.IdleBorderColor = Color.FromArgb(26, 32, 161);

            }
        }

        public Image ByteArrayToImage(byte[] byteArray)
        {
            Image imageDefaul = objProfile.picUser.Image;
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
                DAOProfile DAOProfile = new DAOProfile();
                Image image = objProfile.picUser.Image;
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
                DAOProfile.ProfilePicture = imageBytes;
                DAOProfile.Username = SessionVar.Username;
                int answer = DAOProfile.SaveInfo();
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
                objProfile.picUser.Image = Image.FromFile(imageRute);
            }
        }

        public void SecurityQuestions(object sender, EventArgs e)
        {
            //Creamos objeto del DAO
            DAOProfile daoProfile = new DAOProfile();
            //damos valor al getter de Username que usamos en las consultas para verificar si ya hay respuestas existentes a las preguntas.
            daoProfile.Username = SessionVar.Username.Trim();
            //ejecutamos el método del dao
            bool answer = daoProfile.CheckSecurityQ();
            //evaluamos la respuesta
            if (answer == true)
            {
                //si la respuesta es true, entonces ya respondió antes a las preguntas, por lo que consultamos si quiere eliminar las respuestas ya existentes y volver a responder.
                if (MessageBox.Show("Usted ya ha contestado a las preguntas de seguridad anteriormente. \n\n¿Desea eliminar las respuestas ya existentes y contestarlas nuevamente?", "Respuestas ya existentes", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    //Si responde que si, procedemos a eliminar el registro de sus respuestas con el método del DAO
                    int answer2 = daoProfile.DeleteSecurityQ();
                    //evaluamos la respuesta del método
                    if (answer2 == 1)
                    {
                        //si la respuesta es 1, el registro se eliminó con éxito, asi que mostramos el formulario.
                        MessageBox.Show("Las respuestas que ya existían con anterioridad fueron eliminadas correctamente.", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //le mostramos el formulario 
                        FrmSecurityQuestions openForm = new FrmSecurityQuestions(SessionVar.Username);
                        openForm.ShowDialog();

                    }
                    else
                    {
                        //si la respuesta no es 1, entonces no pudo ser eliminado el registro de respuestas y no se puede seguir con el proceso.
                        MessageBox.Show("Las respuestas que ya existían con anterioridad no pudieron ser eliminadas", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                //Si la respuesta no es 1, significa que el usuario no tiene ningún registro de respuestas existente, por lo que solo pasamos a enseñar el form
                FrmSecurityQuestions openForm = new FrmSecurityQuestions(SessionVar.Username);
                openForm.ShowDialog();
            }

        }

        public void UpdateInfo(object sender, EventArgs e)
        {
            DAOProfile dAOProfile = new DAOProfile();
            dAOProfile.GetEmployeeData();
            FrmProfileConfiguration open = new FrmProfileConfiguration(SessionVar.Names, SessionVar.LastNames, SessionVar.Dui, SessionVar.Phone, SessionVar.Email, SessionVar.Adress, SessionVar.Affiliation, SessionVar.BankAccount);
            open.ShowDialog();
        }
        public void OpenManualU(object sender, EventArgs e)
        {
            // Ruta de la carpeta Resources/PDF dentro del directorio de la aplicación
            string pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Resources", "PDF", "MANUAL DE USUARIO - H2C.pdf");

            if (System.IO.File.Exists(pdfPath))
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = pdfPath,
                    UseShellExecute = true
                };

                System.Diagnostics.Process.Start(psi);
            }
            else
            {
                MessageBox.Show($"El archivo PDF no se encuentra en la ubicación: {pdfPath}", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenManualT(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Resources", "PDF", "MANUAL TÉCNICO - H2C.pdf");

            if (System.IO.File.Exists(pdfPath))
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = pdfPath,
                    UseShellExecute = true
                };

                System.Diagnostics.Process.Start(psi);
            }
            else
            {
                MessageBox.Show($"El archivo PDF no se encuentra en la ubicación: {pdfPath}", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenOptions(object sender, EventArgs e)
        {
            FrmOptions objform = new FrmOptions();
            objform.ShowDialog();
        }
    }
}

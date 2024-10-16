﻿using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.Helpers.Transitions;
using iTextSharp.text.pdf.security;
using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.AlertsDAO;
using PTC2024.Model.DAO.ProfileDAO;
using PTC2024.View.Alerts;
using PTC2024.View.formularios.inicio;
using PTC2024.View.ProfileSettings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.ProfileController
{
    internal class ControllerChangeUserPass
    {
        FrmChangeUserPass objChangeP;

        public ControllerChangeUserPass(FrmChangeUserPass View)
        {
            objChangeP = View;
            objChangeP.MaximizeBox = false;
            objChangeP.Load += new EventHandler(DarkMode);
            objChangeP.btnCheck.Click += new EventHandler(CheckPassword);
            objChangeP.btnSave.Click += new EventHandler(UpdatePass);
            objChangeP.txtPass.MouseDown += new MouseEventHandler(DisableContextMenu);
            objChangeP.txtNewPass.MouseDown += new MouseEventHandler(DisableContextMenu);
            objChangeP.txtConfirmPass.MouseDown += new MouseEventHandler(DisableContextMenu);
        }

        public void CheckPassword(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(objChangeP.txtPass.Text.Trim()))
            {
                bool answer;
                CommonClasses common = new CommonClasses();
                DAOChangeUserPass daoPass = new DAOChangeUserPass();
                //Damos valor a los parámetros
                daoPass.Username = SessionVar.Username;
                daoPass.ActualPass = common.ComputeSha256Hash(objChangeP.txtPass.Text.Trim());
                //Ejecutamos el método del DAO
                answer = daoPass.CheckPass();
                if (answer == true)
                {
                    if (Properties.Settings.Default.darkMode == true)
                    {
                        objChangeP.txtConfirmPass.FillColor = Color.FromArgb(60, 60, 60);
                        objChangeP.txtConfirmPass.BorderColorIdle = Color.Gray;
                        objChangeP.txtNewPass.FillColor = Color.FromArgb(60, 60, 60);
                        objChangeP.txtNewPass.BorderColorIdle = Color.Gray;
                    }
                    objChangeP.lblCorrectPass.Visible = true;
                    objChangeP.lblIncorrectPass.Visible = false;
                    objChangeP.groupBox.Enabled = true;
                    objChangeP.lbl1.Enabled = true;
                    objChangeP.txtNewPass.Enabled = true;
                    objChangeP.lbl2.Enabled = true;
                    objChangeP.txtConfirmPass.Enabled = true;
                    objChangeP.btnSave.Enabled = true;
                }
                else
                {

                    objChangeP.lblCorrectPass.Visible = false;
                    objChangeP.lblIncorrectPass.Visible = true;
                    objChangeP.lbl1.Enabled = false;
                    objChangeP.txtNewPass.Enabled = false;
                    objChangeP.lbl2.Enabled = false;
                    objChangeP.txtConfirmPass.Enabled = false;
                }
            }
            else
            {
                objChangeP.snack.Show(objChangeP, "Ingrese su contraseña actual", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
            }

        }

        public void DarkMode(object sender, EventArgs e)
        {
            objChangeP.txtConfirmPass.Enabled = false;
            objChangeP.txtNewPass.Enabled = false;
            if (Properties.Settings.Default.darkMode == true)
            {
                objChangeP.BackColor = Color.FromArgb(30, 30, 30);
                objChangeP.lblTitle.ForeColor = Color.White;
                objChangeP.bunifuSeparator1.LineColor = Color.White;
                objChangeP.lblActualPass.ForeColor = Color.White;
                objChangeP.lbl1.ForeColor = Color.White;
                objChangeP.lbl2.ForeColor = Color.White;
                objChangeP.txtPass.FillColor = Color.FromArgb(60, 60, 60);
                objChangeP.txtPass.BorderColorIdle = Color.Gray;
                objChangeP.txtConfirmPass.FillColor = Color.FromArgb(60, 60, 60);
                objChangeP.txtConfirmPass.BorderColorIdle = Color.Gray;
                objChangeP.txtNewPass.FillColor = Color.FromArgb(60, 60, 60);
                objChangeP.txtNewPass.BorderColorIdle = Color.Gray;
                objChangeP.bunifuPanel1.BackgroundColor = Color.FromArgb(60, 60, 60);
                objChangeP.bunifuPanel1.BorderColor = Color.FromArgb(60, 60, 60);
                objChangeP.groupBox.ForeColor = Color.White;
                objChangeP.txtConfirmPass.OnDisabledState.FillColor = Color.FromArgb(60, 60, 60);
                objChangeP.txtConfirmPass.BorderColorDisabled = Color.Gray;
                objChangeP.txtNewPass.OnDisabledState.FillColor = Color.FromArgb(60, 60, 60);
                objChangeP.txtNewPass.BorderColorDisabled = Color.Gray;
            }

        }

        public void UpdatePass(object sender, EventArgs e)
        {
            CommonClasses common = new CommonClasses();
            if (!(string.IsNullOrEmpty(objChangeP.txtNewPass.Text.Trim()) ||
                 string.IsNullOrEmpty(objChangeP.txtConfirmPass.Text.Trim()))
                )
            {
                if (objChangeP.txtNewPass.Text.Trim() == objChangeP.txtConfirmPass.Text.Trim())
                {
                    if (common.IsValid(objChangeP.txtNewPass.Text) == true && common.IsValid(objChangeP.txtConfirmPass.Text) == true)
                    {
                        FrmProfile profile = new FrmProfile();
                        int answer;
                        DAOChangeUserPass daoPass = new DAOChangeUserPass();
                        daoPass.NewPass = common.ComputeSha256Hash(objChangeP.txtNewPass.Text.Trim());
                        daoPass.Username = SessionVar.Username;
                        //Ejecutamos el método del DAO
                        answer = daoPass.UpdatePass();
                        if (answer == 1)
                        {
                            objChangeP.txtPass.Clear();
                            objChangeP.txtConfirmPass.Clear();
                            objChangeP.txtNewPass.Clear();
                            objChangeP.lblCorrectPass.Visible = false;
                            objChangeP.lblIncorrectPass.Visible = false;
                            objChangeP.groupBox.Enabled = false;
                            objChangeP.lbl1.Enabled = false;
                            objChangeP.txtNewPass.Enabled = false;
                            objChangeP.lbl2.Enabled = false;
                            objChangeP.txtConfirmPass.Enabled = false;
                            objChangeP.btnSave.Enabled = false;

                            SendEmail();
                            objChangeP.snack.Show(objChangeP, "La contraseña se actualizó con exito.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 2500, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
                        }
                        else
                        {
                            objChangeP.snack.Show(objChangeP, "La contraseña no se pudo actualizar.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
                        }
                    }
                    else
                    {
                        objChangeP.snack.Show(objChangeP, "La contrasela debe tener al menos 8 caracteres, una mayuscula, un numero y un caracter", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2500, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomCenter);
                    }
                }
                else
                {
                    MessageBox.Show("La confirmación de la contraseña es incorrecta, intente de nuevo.", "Nueva contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                objChangeP.snack.Show(objChangeP, "Llene los campos necesarios.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
            }
        }

        public void SendEmail()
        {
            Email email = new Email();
            string para;
            string de;
            string subject;
            string message;

            para = SessionVar.Email;
            de = "h2c.soporte.usuarios@gmail.com";
            subject = "H2C: Cambio de contraseña";
            message = $"Hola \b{SessionVar.FullName}\b, se te ha enviado este correo debido a que alguien realizó un cambio de contraseña en tu cuenta \b'{SessionVar.Username}'\b.\n\n Si tú no fuiste quien realizó este cambio de contraseña, contáctate inmediatamente con un administrador.";

            email.SendPasswordChange(para, de, subject, message);
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

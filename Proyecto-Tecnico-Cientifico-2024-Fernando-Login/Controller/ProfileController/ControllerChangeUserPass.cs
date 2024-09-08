using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.AlertsDAO;
using PTC2024.Model.DAO.ProfileDAO;
using PTC2024.View.Alerts;
using PTC2024.View.formularios.inicio;
using PTC2024.View.ProfileSettings;
using System;
using System.Collections.Generic;
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
            objChangeP.btnCheck.Click += new EventHandler(CheckPassword);
            objChangeP.btnSave.Click += new EventHandler(UpdatePass);
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
                    objChangeP.groupBox.Enabled = false;
                    objChangeP.lbl1.Enabled = false;
                    objChangeP.txtNewPass.Enabled = false;
                    objChangeP.lbl2.Enabled = false;
                    objChangeP.txtConfirmPass.Enabled = false;
                    objChangeP.btnSave.Enabled = false;
                }
            }
            else
            {
                objChangeP.snack.Show(objChangeP, "Ingrese su contraseña actual", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
            }

        } 

        public void UpdatePass(object sender, EventArgs e)
        {

            if(!(string.IsNullOrEmpty(objChangeP.txtNewPass.Text.Trim()) ||
                 string.IsNullOrEmpty(objChangeP.txtConfirmPass.Text.Trim()))
                )
            {
                if(objChangeP.txtNewPass.Text.Trim().Length >= 6)
                {
                    if(objChangeP.txtNewPass.Text.Trim() == objChangeP.txtConfirmPass.Text.Trim())
                    {
                        FrmProfile profile = new FrmProfile();
                        int answer;
                        CommonClasses common = new CommonClasses();
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

                            objChangeP.snack.Show(objChangeP, "La contraseña se actualizó con exito.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 2500, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
                        }
                        else
                        {
                            objChangeP.snack.Show(objChangeP, "La contraseña no se pudo actualizar.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La confirmación de la contraseña es incorrecta, intente de nuevo.", "Nueva contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La nueva contraseña debe contener al menos 6 caracteres.", "Nueva contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                objChangeP.snack.Show(objChangeP, "Llene los campos necesarios.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
            }
        }
    }
}

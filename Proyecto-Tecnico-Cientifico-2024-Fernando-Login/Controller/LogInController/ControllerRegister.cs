using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Model.DAO.LogInDAO;
using PTC2024.View.formularios.inicio;
using PTC2024.View.login;

namespace PTC2024.Controller.LogInController
{
    internal class ControllerRegister
    {
        FrmRegister objNewUser;
        public ControllerRegister(FrmRegister view)
        {
            objNewUser = view;
            objNewUser.btnRegister.Click += new EventHandler(RegisterData);
        }

        public void RegisterData(object sender, EventArgs e)
        {
            DAORegister DAOInsertar = new DAORegister();

            //Insercion de datos de tabla tbEmployees
            DAOInsertar.Names = objNewUser.txtNames.Text;
            DAOInsertar.Lastnames = objNewUser.txtLastnames.Text;
            DAOInsertar.Birth = objNewUser.dtBirth.Value.Date;
            DAOInsertar.Email = objNewUser.txtEmail.Text;
            DAOInsertar.DUI1 = objNewUser.txtDUI.Text;
            DAOInsertar.Phone = objNewUser.txtPhone.Text;
            DAOInsertar.Address = objNewUser.txtAddress.Text;
            DAOInsertar.BusinessP = 1;
            DAOInsertar.Department = 1;
            DAOInsertar.TypeE = 1;
            DAOInsertar.MaritalStatus = 1;
            DAOInsertar.Status = 1;

            //Insercion de datos de tabla tbUserData
            DAOInsertar.User = objNewUser.txtUser.Text;
            DAOInsertar.Password = objNewUser.txtPassword.Text;
            DAOInsertar.ConfirmPassword = objNewUser.txtConfirmedPassword.Text;
            int returnn = DAOInsertar.GetNames();

            if (returnn == 1) {

                MessageBox.Show("Datos ingresados correctamente" + MessageBoxButtons.OK + MessageBoxIcon.Information);

            }

            else
            {
                MessageBox.Show("No se pudieron ingresar los datos", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Eventos visuales


        }

        
}
        


    }


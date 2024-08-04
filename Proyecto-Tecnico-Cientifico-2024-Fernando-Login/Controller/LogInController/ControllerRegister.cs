using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using PTC2024.Controller.Helper;
using PTC2024.formularios.login;
using PTC2024.Model.DAO;
using PTC2024.Model.DAO.LogInDAO;
using PTC2024.View.formularios.inicio;
using PTC2024.View.login;

namespace PTC2024.Controller.LogInController
{
    internal class ControllerRegister
    {
        FrmRegister objNewUser;
        int Cpassword = 0;
        formularios.login.Login log;
        
        public ControllerRegister(FrmRegister view)
        {
            objNewUser = view;
            objNewUser.Load += new EventHandler(LoadCombobox);
            objNewUser.btnRegister.Click += new EventHandler(RegisterData);
            
        }

        public void LoadCombobox(object sender, EventArgs e)
        {
            DAORegister DAOCombobox = new DAORegister();
            //Dropdown de diferentes bancos
            DataSet dsBank = DAOCombobox.ObtenerBanco();
            objNewUser.DdBankType.DataSource = dsBank.Tables["tbBanks"];
            objNewUser.DdBankType.DisplayMember = "BankName";
            objNewUser.DdBankType.ValueMember = "IdBank";

        }

        public void RegisterData(object sender, EventArgs e)
        {
            DAORegister DAOInsertar = new DAORegister();
            CommonClasses commonClasses = new CommonClasses();


            //Insercion de datos de tabla tbEmployees
            DAOInsertar.Names = objNewUser.txtNames.Text;
            DAOInsertar.Lastnames = objNewUser.txtLastnames.Text;
            DAOInsertar.DUI1 = objNewUser.txtDUI.Text;
            DAOInsertar.Birth = objNewUser.dtBirth.Value.Date;
            DAOInsertar.Email = objNewUser.txtEmail.Text;
            DAOInsertar.Salary = 950;
            DAOInsertar.BankAccount = objNewUser.txtBankAccount.Text;
            DAOInsertar.AffiliationNumber = int.Parse(objNewUser.txtISSS.Text);
            DAOInsertar.HireDate = objNewUser.dtHireDate.Value.Date;
            DAOInsertar.BankType = int.Parse(objNewUser.DdBankType.SelectedValue.ToString());
            DAOInsertar.Phone = objNewUser.txtPhone.Text;
            DAOInsertar.Address = objNewUser.txtAddress.Text;
            DAOInsertar.BusinessP = 1;
            DAOInsertar.Department = 1;
            DAOInsertar.TypeE = 1;
            DAOInsertar.MaritalStatus = 1;
            DAOInsertar.Status = 1;


            //Insercion de datos de tabla tbUserData
            DAOInsertar.User = objNewUser.txtUser.Text;
            DAOInsertar.Password = commonClasses.ComputeSha256Hash(objNewUser.txtPassword.Text);
            DAOInsertar.ConfirmPassword = commonClasses.ComputeSha256Hash(objNewUser.txtConfirmedPassword.Text);
            DAOInsertar.Status=1;


            //Insercion de datos de tabla tbBankAccount
            int returnn = DAOInsertar.GetNames();

            if (returnn == 1)
            {

                MessageBox.Show("Datos ingresados correctamente" + MessageBoxButtons.OK + MessageBoxIcon.Information);
                objNewUser.Hide();
                log = new formularios.login.Login();
                log.Show();
                
               

            }

            else
            {
                MessageBox.Show("No se pudieron ingresar los datos", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Eventos visuales


        }
       
        private void OpenLogin(object sender, EventArgs e)
        {
        

        }

                    }
    }





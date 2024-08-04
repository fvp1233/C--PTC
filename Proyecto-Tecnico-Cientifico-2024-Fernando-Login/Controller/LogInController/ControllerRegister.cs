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
            //Evento para nombres
            objNewUser.txtNames.Enter += new EventHandler(EnterUsername);
            objNewUser.txtNames.Leave += new EventHandler(LeaveUsername);
            //Eventos para apellidos
            objNewUser.txtLastnames.Enter += new EventHandler(EnterLastNames);
            objNewUser.txtLastnames.Leave += new EventHandler(LeaveLastNames);
            //Eventos para el email
            objNewUser.txtEmail.Enter += new EventHandler(EnterEmail);
            objNewUser.txtEmail.Leave += new EventHandler(LeaveEmail);
            //Eventos para el DUI
            objNewUser.txtDUI.Enter += new EventHandler(EnterDUI);
            objNewUser.txtDUI.Leave += new EventHandler(LeaveDUI);
            //Eventos para el telefono
            objNewUser.txtPhone.Enter += new EventHandler(EnterPhone);
            objNewUser.txtPhone.Leave += new EventHandler(LeavePhone);
            //Eventos para la direccion
            objNewUser.txtAddress.Enter += new EventHandler(EnterAddress);
            objNewUser.txtAddress.Leave += new EventHandler(LeaveAddress);
            //Eventos para el usuario
            objNewUser.txtUser.Enter += new EventHandler(EnterUser);
            objNewUser.txtUser.Leave += new EventHandler(LeaveAddress);
            //Eventos para la contraseña
            objNewUser.txtPassword.Enter += new EventHandler(EnterPassword);
            objNewUser.txtPassword.Leave += new EventHandler(LeavePassword);
            //Eventos para el confirmar contraseña
            objNewUser.txtConfirmedPassword.Enter += new EventHandler(EnterConfirmPassword);
            objNewUser.txtConfirmedPassword.Leave += new EventHandler(LeaveConfirmPassword);
            //Eventos para la cuenta del banco
            objNewUser.txtBankAccount.Enter += new EventHandler(EnterBankAccount);
            objNewUser.txtBankAccount.Leave += new EventHandler(LeaveAfilliation);
            //Eventos para la afiliacion
            objNewUser.txtISSS.Enter += new EventHandler(EnterAfilliation);
            objNewUser.txtISSS.Leave += new EventHandler(LeaveAfilliation);
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
        //Username enter
        private void EnterUsername(object sennder, EventArgs e)
        {
            if (objNewUser.txtNames.Text.Trim().Equals("Ingrese sus nombres"))
            {
                {
                    objNewUser.txtNames.ForeColor = Color.Black;
                    objNewUser.txtNames.Clear();
                    objNewUser.txtNames.Focus();


                }
            }

        }
        //Username Leave
        private void LeaveUsername(object sender, EventArgs e)
        {
            if (objNewUser.txtNames.Text.Trim().Equals(""))
            {
                objNewUser.txtNames.Text = "Ingrese sus nombres";

            }
        }

        //Lastname Enter
        private void EnterLastNames(object sennder, EventArgs e)
        {
            if (objNewUser.txtLastnames.Text.Trim().Equals("Ingrese sus apellidos"))
            {
                {
                    objNewUser.txtLastnames.ForeColor = Color.Black;
                    objNewUser.txtLastnames.Clear();
                    objNewUser.txtLastnames.Focus();

                }
            }

        }
        //Lastname Leave
        private void LeaveLastNames(object sender, EventArgs e)
        {
            if (objNewUser.txtLastnames.Text.Trim().Equals(""))
            {
                objNewUser.txtLastnames.Text = "Ingrese sus apellidos";

            }
        }

        //Email Enter
        private void EnterEmail(object sennder, EventArgs e)
        {
            if (objNewUser.txtEmail.Text.Trim().Equals("Ingresa un correo electrónico"))
            {
                {
                    objNewUser.txtEmail.ForeColor = Color.Black;
                    objNewUser.txtEmail.Clear();
                    objNewUser.txtEmail.Focus();


                }
            }

        }
        //Email Leave
        private void LeaveEmail(object sender, EventArgs e)
        {
            if (objNewUser.txtEmail.Text.Trim().Equals(""))
            {
                objNewUser.txtEmail.Text = "Ingresa un correo electrónico";

            }
        }
        //Dui Enter
        private void EnterDUI(object sennder, EventArgs e)
        {
            if (objNewUser.txtDUI.Text.Trim().Equals("Ingrese su DUI"))
            {
                {
                    objNewUser.txtDUI.ForeColor = Color.Black;
                    objNewUser.txtDUI.Clear();
                    objNewUser.txtDUI.Focus();

                }
            }

        }

        //Dui Leave
        private void LeaveDUI(object sender, EventArgs e)
        {
            if (objNewUser.txtDUI.Text.Trim().Equals(""))
            {
                objNewUser.txtDUI.Text = "Ingrese su DUI";

            }
        }

        //Phone Enter
        private void EnterPhone(object sender, EventArgs e)
        {

            if (objNewUser.txtPhone.Text.Trim().Equals("Ingrese su número teléfonico"))
            {
                {
                    objNewUser.txtPhone.ForeColor = Color.Black;
                    objNewUser.txtPhone.Clear();
                    objNewUser.txtPhone.Focus();
                }
            }
        }

        //Phone Leave
        private void LeavePhone(object sender, EventArgs e)
        {

            if (objNewUser.txtPhone.Text.Trim().Equals(""))
            {
                objNewUser.txtPhone.Text = "Ingrese su número teléfonico";
            }
        }

        //Address Enter
        private void EnterAddress(object sender, EventArgs e)
        {
            if (objNewUser.txtAddress.Text.Trim().Equals("Ingrese su dirección"))
            {
                {
                    objNewUser.txtAddress.ForeColor = Color.Black;
                    objNewUser.txtAddress.Clear();
                    objNewUser.txtAddress.Focus();
                }
            }
        }

        //Address Leave
        private void LeaveAddress(object sender, EventArgs e)
        {
            if (objNewUser.txtAddress.Text.Trim().Equals(""))
            {
                objNewUser.txtAddress.Text = "Ingrese su dirección";
            }
        }

        //User Enter
        private void EnterUser(object sender, EventArgs e)
        {
            if (objNewUser.txtUser.Text.Trim().Equals("Ingrese un nombre de usuario"))
            {
                {
                    objNewUser.txtUser.ForeColor = Color.Black;
                    objNewUser.txtUser.Clear();
                    objNewUser.txtUser.Focus();
                }
            }
        }

        //User Leave
        private void LeaveUser(object sender, EventArgs e)
        {
            if (objNewUser.txtUser.Text.Trim().Equals(""))
            {
                objNewUser.txtUser.Text = "Ingrese un nombre de usuario";
            }
        }

        private void EnterPassword(object sender, EventArgs e)
        {
            if (objNewUser.txtPassword.Text.Trim().Equals("Ingrese una contraseña"))
            {
                {
                    objNewUser.txtPassword.ForeColor = Color.Black;
                    objNewUser.txtPassword.Clear();
                    objNewUser.txtPassword.Focus();
                }
            }
        }

        private void LeavePassword(object sender, EventArgs e)
        {
            if (objNewUser.txtPassword.Text.Trim().Equals(""))
            {
                objNewUser.txtPassword.Text = "Ingrese una contraseña";
            }
        }

        private void EnterConfirmPassword(object sender, EventArgs e)
        {
            if (objNewUser.txtConfirmedPassword.Text.Trim().Equals("Confirme su contraseña"))
            {
                {
                    objNewUser.txtConfirmedPassword.ForeColor = Color.Black;
                    objNewUser.txtConfirmedPassword.Clear();
                    objNewUser.txtConfirmedPassword.Focus();
                }
            }
        }

        private void LeaveConfirmPassword(object sender, EventArgs e)
        {
            if (objNewUser.txtConfirmedPassword.Text.Trim().Equals(""))
            {
                objNewUser.txtConfirmedPassword.Text = "Confirme su contraseña";
            }
        }


        private void ConfirmPassword(object sender, EventArgs e)
        {

        }

        private void EnterBankAccount(object sender, EventArgs e)
        {
            if (objNewUser.txtBankAccount.Text.Trim().Equals("Ingrese la cuenta de su banco"))
            {
                {
                    objNewUser.txtBankAccount.ForeColor = Color.Black;
                    objNewUser.txtBankAccount.Clear();
                    objNewUser.txtBankAccount.Focus();
                }
            }
        }

        //User Leave
        private void LeaveBankAccount(object sender, EventArgs e)
        {
            if (objNewUser.txtBankAccount.Text.Trim().Equals(""))
            {
                objNewUser.txtBankAccount.Text = "Ingrese la cuenta de su banco";
            }
        }

        private void EnterAfilliation(object sender, EventArgs e)
        {
            if (objNewUser.txtISSS.Text.Trim().Equals("Ingrese su número de afiliación"))
            {
                {
                    objNewUser.txtISSS.ForeColor = Color.Black;
                    objNewUser.txtISSS.Clear();
                    objNewUser.txtISSS.Focus();
                }
            }
        }

        //User Leave
        private void LeaveAfilliation(object sender, EventArgs e)
        {
            if (objNewUser.txtISSS.Text.Trim().Equals(""))
            {
                objNewUser.txtISSS.Text = "Ingrese su número de afiliación";
            }
        }

        private void OpenLogin(object sender, EventArgs e)
        {
        

        }

                    }
    }





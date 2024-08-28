﻿using System;
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
        FrmRegister objRegister;
        bool emailValidation;

        //Constructor
        public ControllerRegister(FrmRegister view)
        {
            objRegister = view;
            objRegister.Load += new EventHandler(LoadCombobox);
            objRegister.btnRegister.Click += new EventHandler(RegisterData);
            objRegister.ShowPassword.Click += new EventHandler(ShowPassword);
            objRegister.HidePassword.Click += new EventHandler(HidePassword);
            objRegister.txtDUI.TextChanged += new EventHandler(DUIMask);
            objRegister.txtPhone.TextChanged += new EventHandler(PhoneMask);
            objRegister.txtAffiliationNumber.TextChanged += new EventHandler(AffiliatioNumberMask);
            objRegister.txtBankAccount.TextChanged += new EventHandler(BankAccountMask);

        }

        public void LoadCombobox(object sender, EventArgs e)
        {
            DAORegister DAOCombobox = new DAORegister();
            //Dropdown de diferentes bancos
            DataSet dsBank = DAOCombobox.ObtainBanks();
            objRegister.comboBank.DataSource = dsBank.Tables["tbBanks"];
            objRegister.comboBank.DisplayMember = "BankName";
            objRegister.comboBank.ValueMember = "IdBank";

            //Esconder el botón de hidepassword inicialmente
            objRegister.HidePassword.Visible = false;

        }

        public void RegisterData(object sender, EventArgs e)
        {  
            //Validación para campos vacíos
            if (!(string.IsNullOrEmpty(objRegister.txtNames.Text.Trim()) ||
                  string.IsNullOrEmpty(objRegister.txtLastNames.Text.Trim()) ||
                  string.IsNullOrEmpty(objRegister.txtDUI.Text.Trim()) ||
                  string.IsNullOrEmpty(objRegister.txtEmail.Text.Trim()) ||
                  string.IsNullOrEmpty(objRegister.txtPhone.Text.Trim()) ||
                  string.IsNullOrEmpty(objRegister.txtAddress.Text.Trim()) ||
                  string.IsNullOrEmpty(objRegister.txtAffiliationNumber.Text.Trim()) ||
                  string.IsNullOrEmpty(objRegister.txtBankAccount.Text.Trim()) ||
                  string.IsNullOrEmpty(objRegister.txtUser.Text.Trim()) ||
                  string.IsNullOrEmpty(objRegister.txtPassword.Text.Trim()) ||
                  string.IsNullOrEmpty(objRegister.txtConfirmedPassword.Text.Trim())
                  ))
            {
                //Validación del dominio del correo
                emailValidation = ValidateEmail();
                if (emailValidation == true)
                {
                    //Validación de la edad del empleado
                    int employeeAge = ValidateAge();
                    if (employeeAge >= 18)
                    {
                        //Validación para el campo de confirmar contraseña.
                        if (objRegister.txtConfirmedPassword.Text.Trim() == objRegister.txtPassword.Text.Trim())
                        {
                            bool passLength = ValidatePasswordLength();
                            if (passLength == true)
                            {
                                //Si todas las validaciones son correctas, pasamos a asignarles el valor a los métodos getter del DAORegister
                                //creamos objeto del DAORegister
                                DAORegister daoRegister = new DAORegister();
                                //creamos objeto de CommonClasses para la encriptación de la contraseña
                                CommonClasses commonClasses = new CommonClasses();
                                //Asignación de valores a los métodos getter

                                //Atributos para la tabla tbUserData
                                daoRegister.Username = objRegister.txtUser.Text.Trim();
                                daoRegister.Password = commonClasses.ComputeSha256Hash(objRegister.txtPassword.Text.Trim());
                                daoRegister.BusinessPosition = 1;
                                daoRegister.UserSatus = true;
                                daoRegister.BusinessInfo = 1;

                                //Atributos para la tabla tbEmployee
                                daoRegister.Names = objRegister.txtNames.Text.Trim();
                                daoRegister.LastNames = objRegister.txtLastNames.Text.Trim();
                                daoRegister.Document = objRegister.txtDUI.Text.Trim();
                                daoRegister.BirthDate = objRegister.dtBirth.Value.Date;
                                daoRegister.Email = objRegister.txtEmail.Text.Trim();
                                daoRegister.Phone = objRegister.txtPhone.Text.Trim();
                                daoRegister.Address = objRegister.txtAddress.Text.Trim();
                                daoRegister.Salary = 1000.00;
                                daoRegister.BankAccount = objRegister.txtBankAccount.Text.Trim();
                                daoRegister.AffiliationNumber = objRegister.txtAffiliationNumber.Text.Trim();
                                daoRegister.HireDate = objRegister.dtHireDate.Value.Date;
                                daoRegister.Bank = int.Parse(objRegister.comboBank.SelectedValue.ToString());
                                daoRegister.Department = 1;
                                daoRegister.EmployeeType = 1;
                                daoRegister.MaritalStatus = 1;
                                daoRegister.EmployeeStatus = 1;

                                //Ahora invocamos el método del DAO para hacer la inserción del empleado por medio del objeto daoRegister.
                                int value = daoRegister.EmployeeRegister();
                                //Evaluamos la variable value para saber si el empleado se registró correctamente.
                                if (value == 1)
                                {
                                    //si la respuesta es 1, la inserción  se realizó.
                                    MessageBox.Show("El primer usuario ha sido registrado exitosamente.", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    MessageBox.Show($"Usuario: {objRegister.txtUser.Text.Trim()} \n Contraseña: {objRegister.txtPassword.Text.Trim()}", "Credenciales de acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Procedemos a abrir el login después de la inserción
                                    FrmLogin objLogin = new FrmLogin();
                                    objLogin.Show();
                                    objRegister.Hide();
                                }
                                else
                                {
                                    //Si la respuesta no es 1, la inserción no se realizó.
                                    MessageBox.Show("El pirmer usuario no pudo ser ingresado.", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("La contraseña debe de tener un mínimo de 6 carácteres", "Contraseña muy corta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("La confirmación de contraseña es incorrecta, intentelo de nuevo", "Confirmar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {

                        MessageBox.Show("El empleado debe tener al menos 18 años.", "Edad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);                        
                    }
                }
                else
                {
                    MessageBox.Show("Porfavor ingrese el correo electónico correctamente.", "Correo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                              
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios, llene todos los apartados.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidateEmail()
        {
            string email = objRegister.txtEmail.Text.Trim();
            if (!(email.Contains("@")))
            {
                MessageBox.Show("El formato del correo es incorrecto, verifique que contenga '@'.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //validación de dominio del correo
            string[] allowedDomains = { "gmail.com", "ricaldone.edu.sv" };
            //La variable domain guarda la cadena de carácteres que se presente después de la arroba en el campo de correo
            string domain = email.Substring(email.LastIndexOf('@') + 1);
            //Si la cadena de carácteres después de la arroba NO es uno de los dominios permitidos, nos envía un mensaje de error.
            if (!allowedDomains.Contains(domain))
            {
                MessageBox.Show("Dominio de correo inválido. \n El sistema solo admite los dominios '@gmail.com' y '@ricaldone.edu.sv'", "Dominio no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //Si no se detecta ningún fallo en el email, se devuelve directamente un true.
            return true;
        }

        //Método encargado de verificar la edad
        private int ValidateAge()
        {
            //Declaramos la variable que captura el valor del dateTimePicker del formulario
            DateTime birthday = objRegister.dtBirth.Value;
            //Ahora declaramos la variable que captura la fecha actual
            DateTime now = DateTime.Today;
            //Declaramos la variable que nos dirá que edad tiene la persona
            int employeeAge = now.Year - birthday.Year;

            //Ahora bien, verificaremos si la persona ya cumplió años el año actual
            //En el "now.AddYears(-employeeAge)" estamos restandole los años de la edad calculada antes a la fecha actual
            //Si la fecha que obtengamos es menor a la fecha puesta en el datetimepicker entonces se le resta 1 a la edad, porque aun no cumple años en el año actual

            if (birthday.Date > now.AddYears(-employeeAge))
            {
                employeeAge--;
            }

            //Ahora si retornamos la edad.
            return employeeAge;

        }

        //Eventos de esconder y mostrar contraseña
        public void ShowPassword(object sender, EventArgs e)
        {
            objRegister.txtPassword.PasswordChar = '\0';
            objRegister.ShowPassword.Visible = false;
            objRegister.HidePassword.Visible = true;
        }

        public void HidePassword(object sender, EventArgs e)
        {
            objRegister.txtPassword.PasswordChar = '*';
            objRegister.HidePassword.Visible = false;
            objRegister.ShowPassword.Visible = true;
        }

        //Método para establecer una máscara al textbox del DUI
        public void DUIMask(object sender, EventArgs e)
        {
            // Aqui se guarda la posición inicial del cursor
            int cursorPosition = objRegister.txtDUI.SelectionStart;

            //Con esto se remueve cualquier dato no numérico excepto el guión
            string text = new string(objRegister.txtDUI.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());

            //Si ya existe algun guión, se elimina.
            text = text.Replace("-", "");

            //Acá especificamos la máscara del DUI, cuando llegue al caracter numero 9, va a ingresar el guion por si solo
            //
            if (text.Length >= 9)
            {
                text = text.Insert(8, "-");
            }
            else if (text.Length >= 1)
            {
                text = text.Insert(0, "");
            }

            //Le asignamos la máscara al texto que se presente en el textbox
            objRegister.txtDUI.Text = text;

            //Restablecemos la posicion del cursor
            objRegister.txtDUI.SelectionStart = cursorPosition;
        }

        //Máscara para el textbox del telefono
        public void PhoneMask(object sender, EventArgs e)
        {
            //Aqui se guarda la posición inicial del cursor, para que con el evento TextChanged el cursor no se mueva de lugar y no sea molesto para el usuario
            int cursorPosition = objRegister.txtPhone.SelectionStart;

            //Con esto se remueve cualquier dato no numérico
            string text = new string(objRegister.txtPhone.Text.Where(c => char.IsDigit(c)).ToArray());

            //Le asignamos la máscara al texto que se ponga en el textbox
            objRegister.txtPhone.Text = text;

            //Restablecemos la posición del cursor con la variable que se guardó antes
            objRegister.txtPhone.SelectionStart = cursorPosition;
        }

        //Aplicamos una máscara que solo deje meter el guion y caracteres numéricos para los textbox de numero de afiliacion y cuenta bancaria.
        public void AffiliatioNumberMask(object sender, EventArgs e)
        {
            int cursorPosition = objRegister.txtAffiliationNumber.SelectionStart;
            //Con esto se remueve cualquier dato no numérico excepto el guion
            string text = new string(objRegister.txtAffiliationNumber.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());
            objRegister.txtAffiliationNumber.Text = text;
            objRegister.txtAffiliationNumber.SelectionStart = cursorPosition;
        }

        public void BankAccountMask(object sender, EventArgs e)
        {
            int cursorPosition = objRegister.txtBankAccount.SelectionStart;
            //Con esto se remueve cualquier dato no numérico excepto el guion
            string text = new string(objRegister.txtBankAccount.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());
            objRegister.txtBankAccount.Text = text;
            objRegister.txtBankAccount.SelectionStart = cursorPosition;
        }

        public bool ValidatePasswordLength()
        {
            if (objRegister.txtPassword.Text.Length >= 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region CÓDIGO ANTERIOR
        //public void RegisterData(object sender, EventArgs e)
        //{
        //    DAORegister DAOInsertar = new DAORegister();
        //    CommonClasses commonClasses = new CommonClasses();


        //    //Insercion de datos de tabla tbEmployees
        //    DAOInsertar.Names = objNewUser.txtNames.Text;
        //    DAOInsertar.Lastnames = objNewUser.txtLastnames.Text;
        //    DAOInsertar.DUI1 = objNewUser.txtDUI.Text;
        //    DAOInsertar.Birth = objNewUser.dtBirth.Value.Date;
        //    DAOInsertar.Email = objNewUser.txtEmail.Text;
        //    DAOInsertar.Salary = 950;
        //    DAOInsertar.BankAccount = objNewUser.txtBankAccount.Text;
        //    DAOInsertar.AffiliationNumber = int.Parse(objNewUser.txtISSS.Text);
        //    DAOInsertar.HireDate = objNewUser.dtHireDate.Value.Date;
        //    DAOInsertar.BankType = int.Parse(objNewUser.DdBankType.SelectedValue.ToString());
        //    DAOInsertar.Phone = objNewUser.txtPhone.Text;
        //    DAOInsertar.Address = objNewUser.txtAddress.Text;
        //    DAOInsertar.BusinessP = 1;
        //    DAOInsertar.Department = 1;
        //    DAOInsertar.TypeE = 1;
        //    DAOInsertar.MaritalStatus = 1;
        //    DAOInsertar.Status = 1;


        //    //Insercion de datos de tabla tbUserData
        //    DAOInsertar.User = objNewUser.txtUser.Text;
        //    DAOInsertar.Password = commonClasses.ComputeSha256Hash(objNewUser.txtPassword.Text);
        //    DAOInsertar.ConfirmPassword = commonClasses.ComputeSha256Hash(objNewUser.txtConfirmedPassword.Text);
        //    DAOInsertar.Status = 1;


        //    //Insercion de datos de tabla tbBankAccount
        //    int returnn = DAOInsertar.GetNames();

        //    if (returnn == 1)
        //    {

        //        MessageBox.Show("Datos ingresados correctamente" + MessageBoxButtons.OK + MessageBoxIcon.Information);
        //        objNewUser.Hide();
        //        FrmLogin log = new FrmLogin();
        //        log.Show();




        //    }

        //    else
        //    {
        //        MessageBox.Show("No se pudieron ingresar los datos", "Proceso interrumpido", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    //Eventos visuales


        //}

        //private void OpenLogin(object sender, EventArgs e)
        //{


        //}
        #endregion
    }
}





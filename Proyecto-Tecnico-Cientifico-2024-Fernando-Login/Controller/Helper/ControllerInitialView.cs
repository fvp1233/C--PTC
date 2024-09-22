using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Controller.LogInController;
using PTC2024.Model.DAO;
using PTC2024.Model.DAO.LogInDAO;
using PTC2024.View.login;
using System.Windows.Forms;
using PTC2024.formularios.login;
using PTC2024.Model.DAO.FirstUseDAO;
using PTC2024.View.FirstUse;
using PTC2024.View.Clientes;
using PTC2024.View.Empleados;
using PTC2024.Model.DAO.HelperDAO;
using PTC2024.View.Start;
using PTC2024.View.formularios.inicio;

namespace PTC2024.Controller.Helper
{
    internal class ControllerInitialView
    {
        //Método para determinar que formulario se enseñará al iniciar el programa
        public static void InitialView()
        {
            //Creamos los objetos de las clases DAO para llamar a los métodos que usaremos
            XMLConnection xmlCon = new XMLConnection();
            DAOLogin daoLogin = new DAOLogin();
            DAOFirstUse daoFirstUse = new DAOFirstUse();
            DAOAddEmployee daoAddEmployee = new DAOAddEmployee();
            DAOInitialView daoInitial = new DAOInitialView();
            StartMenu objMenu = new StartMenu(SessionVar.Username);
            //Antes de todo, mandamos a llamar al método que comprueba que exista un archivo XML con los valores de conexión a la base de datos.
            xmlCon.ReadXMLDocument();
            //Primero que nada, evaluamos si existe un token de recuerdame en las variables locales.
            string savedToken = Properties.Settings.Default.Token;
            if (!string.IsNullOrEmpty(savedToken))
            {
                //Si existe un token es porque alguien activó la opción de recuérdame
                //entonces primero, vamos a verificar que algún usuario tenga el mismo token que existe de manera local en la base de datos y que no haya expirado , con el método CompararTokens.
                //Damos valor a los getters para el método
                daoInitial.Token = savedToken;
                daoInitial.CurrentDate = DateTime.Now;
                bool tokenExistency = daoInitial.CompararToken();
                if (tokenExistency == true)
                {
                    //si es true, significa que si existe un usuario que no necesita iniciar sesión porque el token es igual y no ha expirado.
                    //Entonces pasamos a leer todos sus datos y asignarlos a la clase SessionVar para mostrarle de una vez el StartMenu con el método GetCredentials
                    //damos valor al getter
                    daoInitial.Token = Properties.Settings.Default.Token;
                    //Ejecutamos el método
                    bool credentials = daoInitial.GetCredentials();
                    if (credentials == true)
                    {
                        //si es true, se encontró un usuario y se leyeron sus datos correctamente
                        //abrimos el startMenu
                        Application.Run(new StartMenu(SessionVar.Username));
                        objMenu.snackBar.Show(objMenu, $"Bienvenido de vuelta, {SessionVar.Username}.",Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                    }
                    else
                    {
                        //Si esto es false entonces ocurrió un error y las credenciales no se pudieron leer por medio del token     
                        //ejecutamos todo de forma normal
                        int firstBusiness = daoFirstUse.VerifyRegister();
                        int firstUser = daoAddEmployee.ValidateFirstUse();
                        if (firstBusiness == 0)
                        {
                            Application.Run(new FrmFirstUse());
                        }
                        else if (firstUser == 0)
                        {
                            Application.Run(new FrmRegister());
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error y no pudimos obtener sus datos por medio del token. \nPorfavor, inicie sesión normalmente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Run(new FrmLogin());
                        }
                    }
                }
                else
                {
                    //si es false significa que no se encontró un usuario con el token local o él token ya ha expirado
                    //Se ejecuta todo de forma normal.
                    int firstBusiness = daoFirstUse.VerifyRegister();
                    int firstUser = daoAddEmployee.ValidateFirstUse();
                    if (firstBusiness == 0)
                    {
                        Application.Run(new FrmFirstUse());
                    }
                    else if (firstUser == 0)
                    {
                        Application.Run(new FrmRegister());
                    }
                    else
                    {
                        MessageBox.Show("Su token de inicio de sesión expiró. \nInicie sesión nuevamente", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DeleteLocalToken();
                        Application.Run(new FrmLogin());
                    }
                }

            }
            else
            {
                //Si no existe ningún token, todo se ejecuta de forma normal
                int firstBusiness = daoFirstUse.VerifyRegister();
                int firstUser = daoAddEmployee.ValidateFirstUse();
                if (firstBusiness == 0)
                {
                    Application.Run(new FrmFirstUse());
                }
                else if (firstUser == 0)
                {
                    Application.Run(new FrmRegister());
                }
                else
                {
                    Application.Run(new FrmLogin());
                }
            }           
                                    
        }

        public static void DeleteLocalToken()
        {
            //eliminamos el token local
            Properties.Settings.Default.Token = string.Empty;
            Properties.Settings.Default.Save();
        }

    }
}

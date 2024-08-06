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

namespace PTC2024.Controller.Helper
{

    internal class ControllerInitialView
    {
        //Método para determinar que formulario se enseñará al iniciar el programa

        public static void InitialView()
        {
            //Creamos los objetos de las clases DAOAddEmployee para llamar al método que usaremos
            DAOLogin daoLogin = new DAOLogin();
            DAOFirstUse daoFirstUse = new DAOFirstUse();
            DAOAddEmployee daoAddEmployee = new DAOAddEmployee();
            int firstBusiness = daoFirstUse.VerifyRegister();
            int firstUser = daoAddEmployee.ValidateFirstUse();
            if (firstBusiness == 0)
            {
                Application.Run(new FrmFirstUse());
            }
            else if(firstUser == 0)
            {
                Application.Run(new FrmRegister());
            }
            else
            {
                Application.Run(new FrmLogin());
            }


         }
            



     }
        
        
    }
    


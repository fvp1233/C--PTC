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

namespace PTC2024.Controller.Helper
{

    internal class ControllerInitialView
    {
        //Método para determinar que formulario se enseñará al iniciar el programa
         public static void InitialView()
         {
             //Creamos los objetos de las clases DAOAddEmployee para llamar al método que usaremos
            DAOAddEmployee daoAddEmployee = new DAOAddEmployee();

             int firstUser = daoAddEmployee.ValidateFirstUse();
             if (firstUser == 0)
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
    


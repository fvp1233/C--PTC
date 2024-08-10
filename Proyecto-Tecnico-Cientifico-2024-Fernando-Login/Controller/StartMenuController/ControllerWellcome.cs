using PTC2024.Controller.Helper;
using PTC2024.Model.DTO.EmployeesDTO;
using PTC2024.Model.DTO.ServicesDTO;
using PTC2024.View.Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.StartMenuController
{
    internal class ControllerWellcome
    {
        FrmWelcome objWellcome;
        public ControllerWellcome(FrmWelcome Vista)
        {
            objWellcome = Vista;
            objWellcome.lblNombreUsuario.Text = SessionVar.Username;
        }
    }
}

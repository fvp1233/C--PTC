using PTC2024.Controller.Helper;
using PTC2024.Model.DTO.EmployeesDTO;
using PTC2024.Model.DTO.ServicesDTO;
using PTC2024.View.Start;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            objWellcome.lblWelcome.Text = $"Bienvenido, {SessionVar.Username}";
            if(Properties.Settings.Default.darkMode == true )
            {
                objWellcome.BackColor = Color.FromArgb(18, 18, 18);
                objWellcome.lblWelcome.ForeColor = Color.White;
            }
        }
    }
}

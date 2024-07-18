using PTC2024.View.formularios.inicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.StartMenuController
{

    internal class ControllerStartMenu
    {
        StartMenu objStartMenu;
        Form currentForm;
        public ControllerStartMenu(StartMenu View) 
        {
            objStartMenu = View;
        }    
    }
}

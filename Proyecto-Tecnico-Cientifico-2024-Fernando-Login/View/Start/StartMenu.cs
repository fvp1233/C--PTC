using PTC2024.Controller.StartMenuController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.formularios.inicio
{
    public partial class StartMenu : Form
    {
        public StartMenu(string username)
        {
            InitializeComponent();
            ControllerStartMenu objStart = new ControllerStartMenu(this, username);
        }

    }
}

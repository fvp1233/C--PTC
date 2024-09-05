using PTC2024.Controller.MaintenanceController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Dashboard
{
    public partial class FrmCharge : Form
    {
        public FrmCharge()
        {
            InitializeComponent();
            ControllerCharge objCharge = new ControllerCharge(this);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Verificar si Ctrl+C o Ctrl+V se presionaron
            if (keyData == (Keys.Control | Keys.C) || keyData == (Keys.Control | Keys.V))
            {
                //Retorna true para ignorar el comando y evitar la acción de copiar o pegar
                return true;
            }

            //Llamar al método base para manejar otras teclas
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

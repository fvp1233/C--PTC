using PTC2024.View.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.Server
{
    internal class ControllerServerConfiguration
    {
        FrmServerConfiguration objServer;

        public ControllerServerConfiguration(FrmServerConfiguration View)
        {
            objServer = View;
            objServer.rdFalse.CheckedChanged += new EventHandler(rdFalseMarked);
            objServer.rdTrue.CheckedChanged += new EventHandler(rdTrueMarked);
            objServer.txtDB.MouseDown += new MouseEventHandler(DisableContextMenu);
            objServer.txtServer.MouseDown += new MouseEventHandler(DisableContextMenu);
            objServer.txtPasswordAuth.MouseDown += new MouseEventHandler(DisableContextMenu);
            objServer.txtSqlAuth.MouseDown += new MouseEventHandler(DisableContextMenu);
        }
        void rdFalseMarked(object sender, EventArgs e)
        {
            if (objServer.rdFalse.Checked == true)
            {
                objServer.txtPasswordAuth.Enabled = true;
                objServer.txtSqlAuth.Enabled = true;
            }
        }

        void rdTrueMarked(object sender, EventArgs e)
        {
            if (objServer.rdTrue.Checked == true)
            {
                objServer.txtPasswordAuth.Enabled = false;
                objServer.txtSqlAuth.Enabled = false;
                objServer.txtSqlAuth.Clear();
                objServer.txtPasswordAuth.Clear();
            }
        }
        private void DisableContextMenu(object sender, MouseEventArgs e)
        {
            // Desactiva el menú contextual al hacer clic derecho
            if (e.Button == MouseButtons.Right)
            {
                ((Bunifu.UI.WinForms.BunifuTextBox)sender).ContextMenu = new ContextMenu();  // Asigna un menú vacío
            }
        }
    }
}

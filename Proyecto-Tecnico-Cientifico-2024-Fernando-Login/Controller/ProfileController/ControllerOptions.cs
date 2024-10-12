using PTC2024.View.ProfileSettings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.ProfileController
{
    internal class ControllerOptions
    {
        FrmOptions objOp;
        public ControllerOptions(FrmOptions View)
        {
            objOp = View;
            objOp.Load += new EventHandler(VerifyDarkMode);
            objOp.btnManualT.Click += new EventHandler(OpenManualT);
            objOp.btnUserManual.Click += new EventHandler(OpenManualU);
            objOp.switchDarkMode.Click += new EventHandler(DarkModeSwitch);
            objOp.switchDarkMode.Click += new EventHandler(ChangeTheme);

        }

        public void VerifyDarkMode(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.darkMode == true)
            {
                objOp.switchDarkMode.Checked = true;
                objOp.switchDarkMode.Tag = "dark";
                objOp.BackColor = Color.FromArgb(30, 30, 30);
                objOp.lbl1.ForeColor = Color.White;
                objOp.darkModeWhite.Visible = true;
                objOp.darkModeBlack.Visible = false;
            }
            else
            {
                objOp.switchDarkMode.Checked = false;
                objOp.switchDarkMode.Tag = "light";
            }
        }

        public void DarkModeSwitch(object sender, EventArgs e)
        {
            if(objOp.switchDarkMode.Tag.ToString() == "dark")
            {
                Properties.Settings.Default.darkMode = false;
                Properties.Settings.Default.Save();
                objOp.switchDarkMode.Tag = "light";
            }
            else
            {
                Properties.Settings.Default.darkMode = true;
                Properties.Settings.Default.Save();
                objOp.switchDarkMode.Tag = "dark";
            }
        }

        public void ChangeTheme(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.darkMode == true)
            {
                objOp.BackColor = Color.WhiteSmoke;
                objOp.lbl1.ForeColor = SystemColors.ControlText;
                objOp.darkModeWhite.Visible = false;
                objOp.darkModeBlack.Visible = true;
            }
            else
            {
                objOp.BackColor = Color.FromArgb(30,30,30);
                objOp.lbl1.ForeColor = Color.White;
                objOp.darkModeWhite.Visible = true;
                objOp.darkModeBlack.Visible = false;
            }
        }

        public void OpenManualU(object sender, EventArgs e)
        {
            // Ruta de la carpeta Resources/PDF dentro del directorio de la aplicación
            string pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "PDF", "MANUAL DE USUARIO - H2C.pdf");

            if (System.IO.File.Exists(pdfPath))
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = pdfPath,
                    UseShellExecute = true
                };

                System.Diagnostics.Process.Start(psi);
            }
            else
            {
                MessageBox.Show($"El archivo PDF no se encuentra en la ubicación: {pdfPath}", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenManualT(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "PDF", "MANUAL TÉCNICO - H2C.pdf");

            if (System.IO.File.Exists(pdfPath))
            {
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = pdfPath,
                    UseShellExecute = true
                };

                System.Diagnostics.Process.Start(psi);
            }
            else
            {
                MessageBox.Show($"El archivo PDF no se encuentra en la ubicación: {pdfPath}", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

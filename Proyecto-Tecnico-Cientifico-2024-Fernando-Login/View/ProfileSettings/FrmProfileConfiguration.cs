using PTC2024.Controller.Helper;
using PTC2024.Controller.ProfileController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.ProfileSettings
{
    public partial class FrmProfileConfiguration : Form
    {
        public FrmProfileConfiguration(string names, string lastnames, string dui, string phone, string email, string adress, string affilitiation, string bankAccount)
        {
            InitializeComponent();
            ControllerProfileConfiguration control = new ControllerProfileConfiguration(this, names, lastnames, dui, phone, email, adress, affilitiation, bankAccount);           
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

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }


}

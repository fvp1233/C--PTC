using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PTC2024.Controller.CustomersController;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PTC2024.View.Clientes
{
    public partial class FrmUploadCustomers : Form
    {
        private int clientType;
        public FrmUploadCustomers(int idClient,string dui, string names, string lastnames, string phone,string email, string address, int idTypeC)
        {
            InitializeComponent();
            ControllerUpdateCustomers obj = new ControllerUpdateCustomers(this,  idClient, dui, names, lastnames,   phone,  email,  address, idTypeC);
            
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

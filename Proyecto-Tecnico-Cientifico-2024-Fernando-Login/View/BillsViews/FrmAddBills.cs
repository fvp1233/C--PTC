using PTC2024.Controller;
using PTC2024.Controller.BillsController;
using PTC2024.Controller.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PTC2024.View.Facturacion
{
    public partial class FrmAddBills : Form
    {
        internal object btnBack2;

        public FrmAddBills(int accions)
        {
            InitializeComponent();
            ControllerAddBills objAddBills = new ControllerAddBills(this, accions);
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));


        }
        public FrmAddBills(int accions,string companyName, string NIT, string NRC, string customer, string employee, string CustomerDui, string CustomerPhone, string CustomerEmail)
        {
            InitializeComponent();
            ControllerAddBills objAddBills = new ControllerAddBills(this, accions,companyName, NIT, NRC, customer, CustomerDui, CustomerPhone, CustomerEmail, employee);
        }
        public FrmAddBills(int accions, int id, string IdServices1, float Price1)
        {
            InitializeComponent();
            ControllerAddBills objAddBills = new ControllerAddBills (this, accions, id, IdServices1, Price1);
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

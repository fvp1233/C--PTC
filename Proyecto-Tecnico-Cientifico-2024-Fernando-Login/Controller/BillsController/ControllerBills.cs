using PTC2024.View.Facturacion;
using System;
using System.Text;
using PTC2024.Model.DAO.BillsDAO;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using PTC2024.Controller.Helper;
using System.Drawing;
using PTC2024.Model.DAO.EmployeesDAO;
using PTC2024.Model.DTO.EmployeesDTO;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace PTC2024.Controller.BillsController
{
    internal class ControllerBills
    {
        FrmBills objFormBills;
        Form currentForm;
        int disabledBillId;

        public ControllerBills(FrmBills View)
        {
            objFormBills = View;
            objFormBills.Load += new EventHandler(LoadDataBills);
            objFormBills.btnNewBills.Click += new EventHandler(AddBills);
            objFormBills.cmsPrintBill.Click += new EventHandler(printBills);
<<<<<<< Updated upstream
            objFormBills.cmsRectifyBill.Click += new EventHandler(RectifyBills);
           // objFormBills.cmsOverrideBill.Click += new EventHandler(OverrideBills);
            objFormBills.txtSearchB.Click += new EventHandler(SearchBills);
=======
            objFormBills.cmsRectifyBill.Click += new EventHandler(Rectificar);
            objFormBills.cmsOverrideBill.Click += new EventHandler(OverrideBills);
            objFormBills.txtSearchB.KeyPress += new KeyPressEventHandler(SearchBills);
>>>>>>> Stashed changes
            objFormBills.dgvBills.CellMouseDown += new DataGridViewCellMouseEventHandler(objFormBills_CellMouseDown);
            objFormBills.dgvBills.SelectionChanged += new EventHandler(dgvBills_SelectionChanged);
            objFormBills.cbEfectivo.Click += new EventHandler(CheckboxFiltersMethod);
            objFormBills.cbCheque.Click += new EventHandler(CheckboxFiltersMethod);
            objFormBills.cbCriptomoneda.Click += new EventHandler(CheckboxFiltersMethod);
            objFormBills.cbEmitida.Click += new EventHandler(CheckboxFiltersStatus);
            objFormBills.cbRectificada.Click += new EventHandler(CheckboxFiltersStatus);
            objFormBills.cbPagada.Click += new EventHandler(CheckboxFiltersStatus);
            objFormBills.cbAnulada.Click += new EventHandler(CheckboxFiltersStatus);
            objFormBills.cbPendiente.Click += new EventHandler(CheckboxFiltersStatus);
            objFormBills.cmsRectifyBill.Enabled = true;
            disabledBillId = -1;
        }
        public void LoadDataBills(object sender, EventArgs e)
        {
            ChargeData();
        }
        public void ChargeData()
        {
            DAOBills dAOBills = new DAOBills();
            DataSet ds = dAOBills.Bills();
            //Llenando el datagridview
            objFormBills.dgvBills.DataSource = ds.Tables["viewBill"];
            objFormBills.dgvBills.Columns[0].DividerWidth = 1;
            objFormBills.dgvBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            objFormBills.dgvBills.Columns[2].Visible = false;
            objFormBills.dgvBills.Columns[3].Visible = false;
            objFormBills.dgvBills.Columns[9].Visible = false;
            //objFormBills.dgvBills.Columns[12].Visible = false;
            objFormBills.dgvBills.Columns[13].Visible = false;
            objFormBills.dgvBills.Columns[14].Visible = false;

        }
        //filtracion por busqueda
        public void SearchBills(object sender, EventArgs e)
        {
            Search();
        }

        public void Search()
        {
            DAOBills dAOBills = new DAOBills();

            /*Aca se le da valor al atributo de la clase*/
            dAOBills.SearchB1 = objFormBills.txtSearchB.Text;

            /*Se captura la respuesta de l metodo SearchData y se le agrega su respectivo parametro*/
            DataSet respuesta = dAOBills.SearchData(dAOBills.SearchB1);
            /*Se le dice al DataGridView lo que tiene que mostrar*/
            objFormBills.dgvBills.DataSource = respuesta.Tables["viewBill"];
        }
        //Filtracion por checkBox
        public void CheckboxFiltersMethod(object senderl, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOBills dAOBills = new DAOBills();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string Method;
            //Si un checkbox esta activado, todos los demás no
            if (objFormBills.cbEfectivo.Checked == true)
            {
                Method = objFormBills.cbEfectivo.Tag.ToString();
                objFormBills.cbCheque.Enabled = false;
                objFormBills.cbCriptomoneda.Enabled = false;
                //se crea un dataset que capturará el que nos envía el método en el DAO y le enviamos la variable string que necesita
                DataSet dsCheckBoxMethod = dAOBills.CheckboxFiltersStatus(Method);
                objFormBills.dgvBills.DataSource = dsCheckBoxMethod.Tables["viewBill"];
            }
            else if (objFormBills.cbCheque.Checked == true)
            {
                Method = objFormBills.cbCheque.Tag.ToString();
                objFormBills.cbEfectivo.Enabled = false;
                objFormBills.cbEfectivo.Enabled = false;
                //se crea un dataset que capturará el que nos envía el método en el DAO y le enviamos la variable string que necesita
                DataSet dsCheckBoxMethod = dAOBills.CheckboxFiltersMethod(Method);
                objFormBills.dgvBills.DataSource = dsCheckBoxMethod.Tables["viewBill"];
            }
            else if (objFormBills.cbCriptomoneda.Checked == true)
            {
                Method = objFormBills.cbCriptomoneda.Tag.ToString();
                objFormBills.cbEfectivo.Enabled = false;
                objFormBills.cbCheque.Enabled = false;
                //se crea un dataset que capturará el que nos envía el método en el DAO y le enviamos la variable string que necesita
                DataSet dsCheckBoxMethod = dAOBills.CheckboxFiltersMethod(Method);
                objFormBills.dgvBills.DataSource = dsCheckBoxMethod.Tables["viewBill"];
            }
            else
            {
                //en caso de que ninguno esté checkeado, todos estarán habilitados y se refrescará el datagrid
                objFormBills.cbEfectivo.Enabled = true;
                objFormBills.cbCheque.Enabled = true;
                objFormBills.cbCriptomoneda.Enabled = true;
                
                ChargeData();
            }
            }

        public void CheckboxFiltersStatus(object senderl, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOBills dAOBills = new DAOBills();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string status;
            //Si un checkbox esta activado, todos los demás no
            if (objFormBills.cbEmitida.Checked == true)
            {
                status = objFormBills.cbEmitida.Tag.ToString();
                objFormBills.cbRectificada.Enabled = false;
                objFormBills.cbPagada.Enabled = false;
                objFormBills.cbAnulada.Enabled = false;
                objFormBills.cbPendiente.Enabled = false;
                //se crea un dataset que capturará el que nos envía el método en el DAO y le enviamos la variable string que necesita
                DataSet ds = dAOBills.CheckboxFiltersStatus(status);
                objFormBills.dgvBills.DataSource = ds.Tables["viewBill"];
            }
            else if (objFormBills.cbRectificada.Checked == true)
            {
                status = objFormBills.cbRectificada.Tag.ToString();
                objFormBills.cbEmitida.Enabled = false;
                objFormBills.cbPagada.Enabled = false;
                objFormBills.cbAnulada.Enabled = false;
                objFormBills.cbPendiente.Enabled = false;
                //se crea un dataset que capturará el que nos envía el método en el DAO y le enviamos la variable string que necesita
                DataSet ds = dAOBills.CheckboxFiltersStatus(status);
                objFormBills.dgvBills.DataSource = ds.Tables["viewBill"];
            }
            else if (objFormBills.cbPagada.Checked == true)
            {
                status = objFormBills.cbPagada.Tag.ToString();
                objFormBills.cbEmitida.Enabled = false;
                objFormBills.cbRectificada.Enabled = false;
                objFormBills.cbAnulada.Enabled = false;
                objFormBills.cbPendiente.Enabled = false;
                //se crea un dataset que capturará el que nos envía el método en el DAO y le enviamos la variable string que necesita
                DataSet ds = dAOBills.CheckboxFiltersStatus(status);
                objFormBills.dgvBills.DataSource = ds.Tables["viewBill"];
            }
            else if (objFormBills.cbAnulada.Checked == true)
            {
                status = objFormBills.cbAnulada.Tag.ToString();
                objFormBills.cbEmitida.Enabled = false;
                objFormBills.cbPagada.Enabled = false;
                objFormBills.cbRectificada.Enabled = false;
                objFormBills.cbPendiente.Enabled = false;
                //se crea un dataset que capturará el que nos envía el método en el DAO y le enviamos la variable string que necesita
                DataSet ds = dAOBills.CheckboxFiltersStatus(status);
                objFormBills.dgvBills.DataSource = ds.Tables["viewBill"];
            }
            else if (objFormBills.cbPendiente.Checked == true)
            {
                status = objFormBills.cbPendiente.Tag.ToString();
                objFormBills.cbEmitida.Enabled = false;
                objFormBills.cbPagada.Enabled = false;
                objFormBills.cbAnulada.Enabled = false;
                objFormBills.cbRectificada.Enabled = false;
                //se crea un dataset que capturará el que nos envía el método en el DAO y le enviamos la variable string que necesita
                DataSet ds = dAOBills.CheckboxFiltersStatus(status);
                objFormBills.dgvBills.DataSource = ds.Tables["viewBill"];
            }
            else
            {
                //en caso de que ninguno esté checkeado, todos estarán habilitados y se refrescará el datagrid
                objFormBills.cbEmitida.Enabled = true;
                objFormBills.cbRectificada.Enabled = true;
                objFormBills.cbPagada.Enabled = true;
                objFormBills.cbAnulada.Enabled = true;
                objFormBills.cbPendiente.Enabled = true;

                ChargeData();
            }
        }

        public void printBills(object sender, EventArgs e)
        {
            int row = objFormBills.dgvBills.CurrentRow.Index;
            if (row < 0)
            {
                MessageBox.Show("Por favor, seleccione una factura para imprimir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener los datos de la fila seleccionada
            int id = int.Parse(objFormBills.dgvBills[0, row].Value.ToString());
            string companyName = objFormBills.dgvBills[1, row].Value.ToString();
            string NIT = objFormBills.dgvBills[2, row].Value.ToString();
            string NRC = objFormBills.dgvBills[3, row].Value.ToString();
            string customer = objFormBills.dgvBills[4, row].Value.ToString();
            string customerDui = objFormBills.dgvBills[5, row].Value.ToString();
            string customerPhone = objFormBills.dgvBills[6, row].Value.ToString();
            string customerEmail = objFormBills.dgvBills[7, row].Value.ToString();
            string serviceName = objFormBills.dgvBills[8, row].Value.ToString();
            double discount = double.Parse(objFormBills.dgvBills[9, row].Value.ToString());
            double subtotalPay = double.Parse(objFormBills.dgvBills[10, row].Value.ToString());
            double totalPay = double.Parse(objFormBills.dgvBills[11, row].Value.ToString());
            string methodP = objFormBills.dgvBills[12, row].Value.ToString();
            DateTime startDate = DateTime.Parse(objFormBills.dgvBills[13, row].Value.ToString());
            DateTime finalDate = DateTime.Parse(objFormBills.dgvBills[14, row].Value.ToString());
            DateTime dateissued = DateTime.Parse(objFormBills.dgvBills[17, row].Value.ToString());
            string employee = objFormBills.dgvBills[15, row].Value.ToString();
            string statusBill = objFormBills.dgvBills[16, row].Value.ToString();

            // Crear el contenido de la factura
            string content = $"Factura ID: {id}\n" +
                             $"Empresa: {companyName}\n" +
                             $"NIT: {NIT}\n" +
                             $"NRC: {NRC}\n" +
                             $"Cliente: {customer}\n" +
                             $"DUI Cliente: {customerDui}\n" +
                             $"Teléfono Cliente: {customerPhone}\n" +
                             $"Email Cliente: {customerEmail}\n" +
                             $"Servicio: {serviceName}\n" +
                             $"Descuento: {discount}\n" +
                             $"Subtotal: {subtotalPay}\n" +
                             $"Total: {totalPay}\n" +
                             $"Método de Pago: {methodP}\n" +
                             $"Fecha de Inicio: {startDate.ToShortDateString()}\n" +
                             $"Fecha Final: {finalDate.ToShortDateString()}\n" +
                             $"Fecha de Emisión: {dateissued.ToShortDateString()}\n" +
                             $"Empleado: {employee}\n" +
                             $"Estado de la Factura: {statusBill}";

            // Configurar el documento para impresión
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (s, ev) =>
            {
                ev.Graphics.DrawString(content, new Font("Arial", 12), Brushes.Black, new PointF(100, 100));
            };

            // Establecer la impresora a imprimir en archivo
            printDocument.PrinterSettings.PrintToFile = true;

            // Especificar la ruta completa para guardar el archivo PDF en la carpeta de Descargas
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadsPath, $"Factura_{id}.pdf");
            printDocument.PrinterSettings.PrintFileName = filePath;

            // Imprimir el documento
            try
            {
                printDocument.Print();
                MessageBox.Show($"Factura guardada como PDF en {filePath}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void AddBills(object sender, EventArgs e)
        {
            FrmAddBills newBill = new FrmAddBills(1);
            newBill.ShowDialog();
            ChargeData();
        }
        public void Rectificar(object sender, EventArgs e)
        {
            FrmAddBills newBill = new FrmAddBills(1);
            newBill.ShowDialog();
            ChargeData();
        }
        /*
        public void Rectificar()
        {
            int row = objFormBills.dgvBills.CurrentRow.Index;
            int id;
            string NIT, NRC;
            string companyName, serviceName, statusBill, customer, employee, methodP, CustomerDui, CustomerPhone, CustomerEmail;
            DateTime startDate, FinalDate, Dateissued;
            double Discount, SubtotalPay, TotalPay;

            // Verifica que el índice de fila es válido
            if (row < 0 || row >= objFormBills.dgvBills.RowCount)
            {
                MessageBox.Show("Fila no válida seleccionada.");
                return;
            }

            // Verifica que el DataGridView tenga al menos 18 columnas
            if (objFormBills.dgvBills.ColumnCount < 18)
            {
                MessageBox.Show("El DataGridView no tiene suficientes columnas.");
                return;
            }

            id = int.Parse(objFormBills.dgvBills[0, row].Value.ToString());
            companyName = objFormBills.dgvBills[1, row].Value.ToString();
            NIT = objFormBills.dgvBills[2, row].Value.ToString();
            NRC = objFormBills.dgvBills[3, row].Value.ToString();
            customer = objFormBills.dgvBills[4, row].Value.ToString();
            CustomerDui = objFormBills.dgvBills[5, row].Value.ToString();
            CustomerPhone = objFormBills.dgvBills[6, row].Value.ToString();
            CustomerEmail = objFormBills.dgvBills[7, row].Value.ToString();
            serviceName = objFormBills.dgvBills[8, row].Value.ToString();

            if (!double.TryParse(objFormBills.dgvBills[9, row].Value.ToString(), out Discount))
            {
                Discount = 0;
            }

            if (!double.TryParse(objFormBills.dgvBills[10, row].Value.ToString(), out SubtotalPay))
            {
                SubtotalPay = 0;
            }

            if (!double.TryParse(objFormBills.dgvBills[11, row].Value.ToString(), out TotalPay))
            {
                TotalPay = 0;
            }

            methodP = objFormBills.dgvBills[12, row].Value.ToString();

            if (!DateTime.TryParse(objFormBills.dgvBills[13, row].Value.ToString(), out startDate))
            {
                startDate = DateTime.MinValue;
            }

            if (!DateTime.TryParse(objFormBills.dgvBills[14, row].Value.ToString(), out FinalDate))
            {
                FinalDate = DateTime.MinValue;
            }

            employee = objFormBills.dgvBills[15, row].Value.ToString();
            statusBill = objFormBills.dgvBills[16, row].Value.ToString();

            if (!DateTime.TryParse(objFormBills.dgvBills[17, row].Value.ToString(), out Dateissued))
            {
                Dateissued = DateTime.MinValue;
            }

            FrmAddBills rectifyBill = new FrmAddBills(2, id, companyName, NIT, NRC, customer, serviceName, Discount, SubtotalPay, TotalPay, methodP, startDate, FinalDate, Dateissued, employee, statusBill, CustomerDui, CustomerPhone, CustomerEmail);

            rectifyBill.ShowDialog();
        }
        */
        public void OverrideBills(object sender, EventArgs e)
        {
            int row = objFormBills.dgvBills.CurrentRow.Index;
            if (row < 0)
            {
                MessageBox.Show("Por favor, seleccione una factura para anular.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idBill = int.Parse(objFormBills.dgvBills[0, row].Value.ToString());
            FrmOverrideBill openForm = new FrmOverrideBill();
            ControllerOverride controller = new ControllerOverride(openForm);

            openForm.ShowDialog();

            if (controller.ConfirmValue == 1)
            {
                // Deshabilitar visualmente la fila y marcarla como solo lectura
                disabledBillId = idBill;
                DisableRow(idBill);
                SetRowReadOnly(idBill);
                objFormBills.cmsRectifyBill.Enabled = true;
            }
            else
            {
                MessageBox.Show("Operación cancelada.", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
<<<<<<< Updated upstream
        }


        public void SearchBills(object sender, EventArgs e)
        {
            DAOBills dAOBills = new DAOBills();
            dAOBills.Search = objFormBills.txtSearchB.Text;
            DataSet ans = dAOBills.SearchDataB(dAOBills.Search);
            objFormBills.dgvBills.DataSource = ans.Tables["ViewBills"];
=======
            ChargeData();
>>>>>>> Stashed changes
        }

        private void DisableRow(int idBill)
        {
            foreach (DataGridViewRow row in objFormBills.dgvBills.Rows)
            {
                if (row.Cells["N°"].Value != null && (int)row.Cells["N°"].Value == idBill)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.DarkGray;
                    row.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                    row.DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                    break;
                }
            }
        }

        private void SetRowReadOnly(int idBill)
        {
            foreach (DataGridViewRow row in objFormBills.dgvBills.Rows)
            {
                if (row.Cells["N°"].Value != null && (int)row.Cells["N°"].Value == idBill)
                {
                    row.ReadOnly = true;
                    break;
                }
            }
        }

        private void objFormBills_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = objFormBills.dgvBills.Rows[e.RowIndex];
                if (row.Cells["N°"].Value != null && (int)row.Cells["N°"].Value == disabledBillId)
                {
                }
            }
        }

        private void dgvBills_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in objFormBills.dgvBills.SelectedRows)
            {
                if (row.Cells["N°"].Value != null && (int)row.Cells["N°"].Value == disabledBillId)
                {
                    row.Selected = false;
                }
            }
        }
    }
}

using PTC2024.View.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.View.BillsViews;
using PTC2024.Model.DAO;
using PTC2024.Model.DTO;
using PTC2024.Model.DAO.BillsDAO;
using System.Data;
using System.Windows.Forms;
using System.Numerics;
using PTC2024.Model.DAO.ServicesDAO;
using RestSharp;
using System.Runtime.InteropServices.ComTypes;
using System.Web.UI.WebControls;
using PTC2024.View.login;
using PTC2024.formularios.login;
using PTC2024.Model.DAO.LogInDAO;
using System.Security.Cryptography;
using PTC2024.Controller.Helper;
using System.Drawing;

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
            objFormBills.cmsRectifyBill.Click += new EventHandler(RectifyBills);
            //objFormBills.cmsOverrideBill.Click += new EventHandler(OverrideBills);
            objFormBills.txtSearchB.Click += new EventHandler(SearchBills);
            objFormBills.dgvBills.CellMouseDown += new DataGridViewCellMouseEventHandler(objFormBills_CellMouseDown);
            objFormBills.dgvBills.SelectionChanged += new EventHandler(dgvBills_SelectionChanged);
            objFormBills.cmsRectifyBill.Enabled = false;
            disabledBillId = -1;
        }
        public void LoadDataBills(object sender, EventArgs e)
        {
            ChargeData();
        }
        public void ChargeData()
        {
            DAOBills objBills = new DAOBills();
            DataSet ds = objBills.Bills();
            if (ds != null && ds.Tables.Contains("viewBills"))
            {
                objFormBills.dgvBills.DataSource = ds.Tables["viewBills"];
            }
            else
            {
                MessageBox.Show("No se encontraron datos para cargar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void printBills(object sender, EventArgs e)
        {

        }
        public void AddBills(object sender, EventArgs e)
        {
            FrmAddBills newBill = new FrmAddBills(1);
            newBill.ShowDialog();
        }
        public void RectifyBills(object sender, EventArgs e)
        {
            int row = objFormBills.dgvBills.CurrentRow.Index;
            int id;
            string NIT, NRC;
            string companyName, serviceName, statusBill, customer, employee, methodP, CustomerDui, CustomerPhone, CustomerEmail;
            DateTime startDate, FinalDate, Dateissued;
            float discount, subtotalPay, totalPay;
            id = int.Parse(objFormBills.dgvBills[0, row].Value.ToString());
            companyName = objFormBills.dgvBills[1, row].Value.ToString();
            NIT = objFormBills.dgvBills[2, row].Value.ToString();
            NRC = objFormBills.dgvBills[3, row].Value.ToString();
            customer = objFormBills.dgvBills[4, row].Value.ToString();
            CustomerDui = objFormBills.dgvBills[5, row].Value.ToString();
            CustomerPhone = objFormBills.dgvBills[6, row].Value.ToString();
            CustomerEmail= objFormBills.dgvBills[7, row].Value.ToString();
            serviceName = objFormBills.dgvBills[8, row].Value.ToString();
            discount = float.Parse(objFormBills.dgvBills[9, row].Value.ToString());
            subtotalPay = float.Parse(objFormBills.dgvBills[10, row].Value.ToString());
            totalPay = float.Parse(objFormBills.dgvBills[11, row].Value.ToString());
            methodP = objFormBills.dgvBills[12, row].Value.ToString();
            startDate = DateTime.Parse(objFormBills.dgvBills[13, row].Value.ToString());
            FinalDate = DateTime.Parse(objFormBills.dgvBills[14, row].Value.ToString());
            employee = objFormBills.dgvBills[15, row].Value.ToString();
            statusBill = objFormBills.dgvBills[16, row].Value.ToString();
            Dateissued = DateTime.Parse(objFormBills.dgvBills[17, row].Value.ToString());

            FrmAddBills rectifyBill = new FrmAddBills(2, id, companyName, NIT, NRC, customer, serviceName, discount, subtotalPay, totalPay, methodP, startDate, FinalDate, Dateissued, employee, statusBill, CustomerDui, CustomerPhone, CustomerEmail);

            rectifyBill.ShowDialog();
            ChargeData();

        }
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
        }

        public void SearchBills(object sender, EventArgs e)
        {
            DAOBills dAOBills = new DAOBills();
            dAOBills.Search = objFormBills.txtSearchB.Text;
            DataSet ans = dAOBills.SearchDataB(dAOBills.Search);
            objFormBills.dgvBills.DataSource = ans.Tables["ViewBills"];
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

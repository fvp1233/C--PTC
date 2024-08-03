using PTC2024.View.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.View.BillsViews;
using System.ComponentModel.Design;
using PTC2024.Model.DAO;
using PTC2024.Model.DAO.BillsDAO;
using System.Data;
using PTC2024.Model.DTO;
using PTC2024.Model.DAO.ServicesDAO;
using System.Windows.Forms;
using System.Web.UI.Design.WebControls;
using PTC2024.Model.DTO.ServicesDTO;

namespace PTC2024.Controller.BillsController
{
    internal class ControllerAddBills
    {
        FrmAddBills objAddBills;
        private int accions;
        private string IdServices;
        public ControllerAddBills(FrmAddBills View, int accions)
        {
            objAddBills = View;
            this.accions = accions;

            chooseAccions();
            objAddBills.Load += new EventHandler(LoadDataServices);

            objAddBills.btnAddBill.Click += new EventHandler(NewBill);
            objAddBills.btnmore.Click += new EventHandler(More);
            objAddBills.btnBack.Click += new EventHandler(BackProcess);
            objAddBills.btnDeletemore.Click += new EventHandler(DataProcessS);
        }
        public ControllerAddBills(FrmAddBills view, int accions, int id, string companyName, string NIT, string NRC, string customer, string serviceName, double discount, double subtoralPay, double totalPay, string methodP, DateTime startDate, DateTime FinalDate, string employee, string statusBill, DateTime fiscalPeriod)
        {
            objAddBills = view;
            this.accions = accions;

            objAddBills.Load += new EventHandler(LoadDataServices);
            chooseAccions();
            ChargeValues(id, companyName, NIT, NRC, customer, discount, subtoralPay, totalPay, startDate, FinalDate, employee, fiscalPeriod);

            //objAddBills.btnRectify.Click += new EventHandler(RectifyBills);
        }
        public ControllerAddBills(FrmAddBills view, int accions, int id, string IdServices)
        {
            objAddBills = view;
            this.accions = accions;
            this.IdServices = IdServices;

            objAddBills.Load += new EventHandler(LoadDataServices);
            chooseAccions();
            ChargeV(id, IdServices);

            //objAddBills.btnRectify.Click += new EventHandler(RectifyBills);
        }
        public void LoadDataServices(object sender, EventArgs e)
        {
            InitialCharge();
        }
        public void InitialCharge()
        {
            DAOAddBills objBills = new DAOAddBills();
            DataSet dsMethodP = objBills.Methodp();
            objAddBills.comboMethodP.DataSource = dsMethodP.Tables["tbMethodP"];
            objAddBills.comboMethodP.DisplayMember = "PaymentMethod";
            objAddBills.comboMethodP.ValueMember = "IdmethodP";

            DataSet dsStatusBill = objBills.statusBill();
            objAddBills.comboStatusBill.DataSource = dsStatusBill.Tables["tbStatusBill"];
            objAddBills.comboStatusBill.DisplayMember = "billStatus";
            objAddBills.comboStatusBill.ValueMember = "IdStatusBill";

            DataSet dsServices = objBills.DataServices();
            objAddBills.comboServiceBill.DataSource = dsServices.Tables["tbServices"];
            objAddBills.comboServiceBill.DisplayMember = "serviceName";
            objAddBills.comboServiceBill.ValueMember = "IdServices";

            DAOAddBills objBillsD = new DAOAddBills();
            DataSet ds = objBillsD.BillsD();
            objAddBills.dgvData.DataSource = ds.Tables["viewDetail"];
        }
        public void chooseAccions()
        {
            if (accions == 1)
            {
                objAddBills.btnAddBill.Enabled = true;
                objAddBills.btnRectify.Enabled = false;
            }
            else if (accions == 2)
            {
                objAddBills.btnAddBill.Enabled = false;
                objAddBills.btnRectify.Enabled = true;
            }
            else if (accions == 3) 
            {
                objAddBills.btnmore.Enabled = true;
            }
        }
        public void More(object sender, EventArgs e)
        {
            DAOAddBills dAOAdd = new DAOAddBills();
            dAOAdd.IdServices1 = int.Parse(objAddBills.comboServiceBill.SelectedValue.ToString());
            int An = dAOAdd.DataB();
            //Verificamos el valor que nos retorna dicho método
            if (An == 1)
            {
                MessageBox.Show("Servicio seleccionado con exito", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor vuelva a seleccionar el servicio", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                objAddBills.Close();

            }
            InitialCharge();

        }
        public void DataProcessS(object sender, EventArgs e)
        {
            if (objAddBills.dgvData.SelectedRows.Count > 0)
            {
                // Verifica que las filas puedan ser eliminadas
                if (objAddBills.dgvData.AllowUserToDeleteRows)
                {
                    // Elimina la fila seleccionada del DataGridView
                    foreach (DataGridViewRow row in objAddBills.dgvData.SelectedRows)
                    {
                        // Verifica que la fila no sea una nueva fila
                        if (!row.IsNewRow)
                        {
                            objAddBills.dgvData.Rows.Remove(row);
                        }
                    }
                }
                else
                {

                    MessageBox.Show("No está permitido eliminar filas en esta tabla.", "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void NewBill(object sender, EventArgs e)
        {
            DAOAddBills daoNew = new DAOAddBills();
            daoNew.CompanyName = objAddBills.txtRazónsocial.Text.Trim();
            daoNew.NIT1 = objAddBills.txtNITCompany.Text.Trim();
            daoNew.NRC1 = objAddBills.txtNRCompany.Text.Trim();
            daoNew.Discount = double.Parse(objAddBills.txtDiscount.Text.ToString());
            daoNew.SubtotalPay = double.Parse(objAddBills.txtSubTotal.Text.ToString());
            daoNew.TotalPay = double.Parse(objAddBills.txtTotalPay.Text.ToString());
            daoNew.StartDate = objAddBills.dtStartDate.Value.Date;
            daoNew.FinalDate1 = objAddBills.dtFinalDate.Value.Date;
            daoNew.Services = objAddBills.comboServiceBill.SelectedValue.ToString();
            daoNew.StatusBills = objAddBills.comboStatusBill.SelectedValue.ToString();
            daoNew.Customer = objAddBills.txtCustomerName.ToString();
            daoNew.Employee = objAddBills.txtEmployee.ToString();
            daoNew.MethodP = objAddBills.comboMethodP.SelectedValue.ToString();
            daoNew.FiscalPeriod = objAddBills.dtfiscalPeriod.Value.Date;

        }
        // public void RectifyBills()
        //{

        // }
        public void BackProcess(object sender, EventArgs e)
        {
            objAddBills.Close();
        }
        public void ChargeValues(int id, string companyName, string NIT, string NRC, string customer, double discount, double subtoralPay, double totalPay, DateTime startDate, DateTime FinalDate, string employee, DateTime fiscalPeriod)
        {
            objAddBills.txtRazónsocial.Text = companyName;
            objAddBills.txtNITCompany.Text = NIT.ToString();
            objAddBills.txtNRCompany.Text = NRC.ToString();
            objAddBills.txtCustomerName.Text = customer.ToString();
            objAddBills.txtDiscount.Text = discount.ToString();
            objAddBills.txtSubTotal.Text = subtoralPay.ToString();
            objAddBills.txtTotalPay.Text = totalPay.ToString();
            objAddBills.dtStartDate.Value = startDate;
            objAddBills.dtFinalDate.Value = FinalDate;
            objAddBills.txtEmployee.Text = employee.ToString();
            objAddBills.dtfiscalPeriod.Value = fiscalPeriod;

        }
        public void ChargeV(int id, string IdServices1)
        {
            objAddBills.comboServiceBill.SelectedValue.ToString();
        }
    }
}
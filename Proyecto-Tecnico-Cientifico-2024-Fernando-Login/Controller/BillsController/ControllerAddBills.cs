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
using System.Numerics;
using PTC2024.Model.DTO.CustomersDTO;

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
            objAddBills.txtSubTotal.TextChanged += new EventHandler(CalculateTotal);
            objAddBills.txtDiscount.TextChanged += new EventHandler(TxtDiscount_TextChanged);
            objAddBills.txtDiscount.KeyUp += new KeyEventHandler(txtDiscount_KeyPress);
            objAddBills.txtTotalPay.TextChanged += new EventHandler(CalculateTotal);
            objAddBills.dgvData.CellValueChanged += new DataGridViewCellEventHandler(CalculateTotal);
            objAddBills.dgvData.RowsAdded += new DataGridViewRowsAddedEventHandler(CalculateTotal);
            objAddBills.dgvData.RowsRemoved += new DataGridViewRowsRemovedEventHandler(CalculateTotal);

        }
        public ControllerAddBills(FrmAddBills view, int accions, int id, string companyName, string NIT, string NRC, string customer, string serviceName, float discount, float subtoralPay, float totalPay, string methodP, DateTime startDate, DateTime FinalDate, DateTime Dateissued, string employee, string statusBill)
        {
            objAddBills = view;
            this.accions = accions;

            objAddBills.Load += new EventHandler(LoadDataServices);
            chooseAccions();
            ChargeValues(id, companyName, NIT, NRC, customer, discount, subtoralPay, totalPay, startDate, FinalDate, Dateissued, employee);

            //objAddBills.btnRectify.Click += new EventHandler(RectifyBills);
        }
        public ControllerAddBills(FrmAddBills view, int accions, int id, string IdServices, float Price1)
        {
            objAddBills = view;
            this.accions = accions;
            this.IdServices = IdServices;

            objAddBills.Load += new EventHandler(LoadDataServices);
            chooseAccions();
            ChargeV(id, IdServices, Price1);

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
            //Data grid de detalle de servicio
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
            if (int.TryParse(objAddBills.comboServiceBill.SelectedValue.ToString(), out int selectedServiceId))
            {
                // Obtener el precio del servicio seleccionado
                float price = dAOAdd.GetServicePrice(selectedServiceId);

                // Añadir el servicio y precio a la base de datos
                dAOAdd.IdServices1 = selectedServiceId;
                dAOAdd.Price1 = price;
                int An = dAOAdd.DataB();

                // Verificamos el valor que nos retorna dicho método
                if (An == 1)
                {
                    MessageBox.Show("Servicio seleccionado con éxito", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor vuelva a seleccionar el servicio", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objAddBills.Close();
                }
                InitialCharge();
            }
            else
            {
                MessageBox.Show("El valor seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void TxtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal(null, null);
        }
        public void CalculateTotal(object sender, EventArgs e)
        {
            try
            {
                float total = 0;
                // Iterar sobre las filas del DataGridView
                foreach (DataGridViewRow row in objAddBills.dgvData.Rows)
                {
                    if (row.Cells["Precio"].Value != null) // Verificar que no sea nulo
                    {
                        // Parsear el valor a decimal y sumarlo al total
                        float price = 0;
                        if (float.TryParse(row.Cells["Precio"].Value.ToString(), out price))
                        {
                            total += price;
                        }
                    }
                }
                objAddBills.txtSubTotal.Text = total.ToString("F2");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el total: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void txtDiscount_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Obtener los valores de los TextBox
                if (float.TryParse(objAddBills.txtSubTotal.Text, out float subTotal) &&
                    float.TryParse(objAddBills.txtDiscount.Text, out float discount))
                {
                    // Calcular el total
                    float total = subTotal - (subTotal * discount / 100);

                    // Mostrar el resultado en el TextBox del total
                    objAddBills.txtTotalPay.Text = total.ToString("F2");
                }
                else
                {
                    // Mostrar un mensaje de error si los valores no son numéricos
                    MessageBox.Show("Por favor, ingresa valores numéricos válidos.");
                }
            }
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
            if (!(string.IsNullOrEmpty(objAddBills.txtCompany.Text.Trim()) ||
                string.IsNullOrEmpty(objAddBills.txtNITCompany.Text.Trim()) ||
                string.IsNullOrEmpty(objAddBills.txtNRCompany.Text.Trim()) ||
                string.IsNullOrEmpty(objAddBills.txtDiscount.Text.Trim()) ||
                string.IsNullOrEmpty(objAddBills.txtSubTotal.Text.Trim()) ||
                string.IsNullOrEmpty(objAddBills.txtTotalPay.Text.Trim()) ||
                string.IsNullOrEmpty(objAddBills.txtCustomerName.Text.Trim()) ||
                string.IsNullOrEmpty(objAddBills.txtCustomerLastname.Text.Trim()) ||
                string.IsNullOrEmpty(objAddBills.txtCustomerEmail.Text.Trim()) ||
                string.IsNullOrEmpty(objAddBills.txtCustomerPhone.Text.Trim()) ||
                string.IsNullOrEmpty(objAddBills.txtDUICustomer.Text.Trim()) ||
                string.IsNullOrEmpty(objAddBills.txtEmployee.Text.Trim())))
            {
                DAOAddBills daoNew = new DAOAddBills();
                daoNew.CompanyName = objAddBills.txtRazónsocial.Text.Trim();
                daoNew.NIT1 = objAddBills.txtNITCompany.Text.Trim();
                daoNew.NRC1 = objAddBills.txtNRCompany.Text.Trim();
                daoNew.Discount = float.Parse(objAddBills.txtDiscount.Text);
                daoNew.SubtotalPay = float.Parse(objAddBills.txtSubTotal.Text);
                daoNew.TotalPay = float.Parse(objAddBills.txtTotalPay.Text);
                daoNew.StartDate = objAddBills.dtStartDate.Value.Date;
                daoNew.FinalDate1 = objAddBills.dtFinalDate.Value.Date;
                daoNew.Dateissued = objAddBills.dtfiscalPeriod.Value.Date;
                daoNew.Services = objAddBills.comboServiceBill.SelectedValue.ToString();
                daoNew.StatusBills = objAddBills.comboStatusBill.SelectedValue.ToString();
                daoNew.Customer = objAddBills.txtCustomerName.Text.Trim();
                daoNew.Customer = objAddBills.txtCustomerLastname.Text.Trim();
                daoNew.Customer = objAddBills.txtCustomerEmail.Text.Trim();
                daoNew.Customer = objAddBills.txtCustomerPhone.Text.Trim();
                daoNew.Customer = objAddBills.txtDUICustomer.Text.Trim();
                daoNew.Employee = objAddBills.txtEmployee.Text.Trim();
                daoNew.MethodP = objAddBills.comboMethodP.SelectedValue.ToString();
                int checks = daoNew.RegisterBills();

                // Verificamos el valor que nos retorna dicho método
                if (checks == 1)
                {
                    MessageBox.Show("Los datos se registraron de manera exitosa", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objAddBills.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    



    // public void RectifyBills()
    //{

    // }
    public void BackProcess(object sender, EventArgs e)
            {
                objAddBills.Close();
            }
            public void ChargeValues(int id, string companyName, string NIT, string NRC, string customer, float discount, float subtoralPay, float totalPay, DateTime startDate, DateTime FinalDate, DateTime Dateissued, string employee)
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
            objAddBills.dtfiscalPeriod.Value = Dateissued;
                objAddBills.txtEmployee.Text = employee.ToString();

            }
            public void ChargeV(int id, string IdServices1, float Price1)
            {
                objAddBills.comboServiceBill.SelectedValue.ToString();
            }
        }
    }
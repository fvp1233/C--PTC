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
using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.Model.DTO.BillsDTO;

namespace PTC2024.Controller.BillsController
{
    internal class ControllerAddBills
    {
        FrmAddBills objAddBills;
        private int accions;
        private string IdServices;
        private string customer;
        public ControllerAddBills(FrmAddBills View, int accions)
        {
            objAddBills = View;
            this.accions = accions;


            chooseAccions();
            objAddBills.Load += new EventHandler(LoadDataServices);

            objAddBills.btnAddBill.Click += new EventHandler(NewBill);
            objAddBills.btnRectify.Click += new EventHandler(RectifyBills);
            objAddBills.btnmore.Click += new EventHandler(More);
            objAddBills.btnBack.Click += new EventHandler(BackProcess);
            objAddBills.btnDeletemore.Click += new EventHandler(DataProcessS);
            objAddBills.txtSubTotal.TextChanged += new EventHandler(CalculateTotal);
            objAddBills.txtDiscount.TextChanged += new EventHandler(TxtDiscount_TextChanged);
            //objAddBills.txtDiscount.KeyDown += new KeyEventHandler(txtDiscount_KeyDown);
            objAddBills.txtTotalPay.TextChanged += new EventHandler(CalculateTotal);
            objAddBills.dgvData.CellValueChanged += new DataGridViewCellEventHandler(CalculateTotal);
            objAddBills.dgvData.RowsAdded += new DataGridViewRowsAddedEventHandler(CalculateTotal);
            objAddBills.dgvData.RowsRemoved += new DataGridViewRowsRemovedEventHandler(CalculateTotal);
            objAddBills.txtCustomerName.Leave += new EventHandler(TxtCustomerName_Leave);


        }
        public ControllerAddBills(FrmAddBills view, int accions, int id, string companyName, string NIT, string NRC, string Customer, string serviceName, double Discount, double SubtotalPay, double TotalPay, string methodP, DateTime startDate, DateTime FinalDate, DateTime Dateissued, string employee, string statusBill, string CustomerDui, string CustomerPhone, string CustomerEmail)
        {
            objAddBills = view;
            this.accions = accions;
            this.customer = Customer;


            objAddBills.Load += new EventHandler(LoadDataServices);
            chooseAccions();
            ChargeValues(id, companyName,  NIT,  NRC,  Customer, Discount, SubtotalPay, TotalPay,  startDate,  FinalDate,  Dateissued,  employee,  CustomerDui,  CustomerPhone,  CustomerEmail);

           objAddBills.btnRectify.Click += new EventHandler(RectifyBills);
        }

            public ControllerAddBills(FrmAddBills view, int accions, int id, string IdServices, float Price1)
        {
            objAddBills = view;
            this.accions = accions;
            this.IdServices = IdServices;

            objAddBills.Load += new EventHandler(LoadDataServices);
            chooseAccions();
            ChargeV(id, IdServices, Price1);
            

            objAddBills.btnRectify.Click += new EventHandler(RectifyBills);
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
                objAddBills.btnBack.Enabled = true;
                objAddBills.btnRectify.Enabled = true;
            }
            else if (accions == 2)
            {
                objAddBills.btnRectify.Enabled = true;
                objAddBills.btnAddBill.Enabled = false;
                objAddBills.btnBack.Enabled = false;
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
            CalculateTotal(sender, e);
        }

        public void CalculateTotal(object sender, EventArgs e)
        {
            try
            {
                float subtotal = 0;
                // Filas del DataGridView para calcular el subtotal
                foreach (DataGridViewRow row in objAddBills.dgvData.Rows)
                {
                    if (row.Cells["Precio"].Value != null)
                    {
                        float price = 0;
                        if (float.TryParse(row.Cells["Precio"].Value.ToString(), out price))
                        {
                            subtotal += price;
                        }
                    }
                }

                objAddBills.txtSubTotal.Text = subtotal.ToString("F2");

                // Aplicar el descuento si se ha ingresado uno válido
                if (float.TryParse(objAddBills.txtDiscount.Text, out float discount))
                {
                    float totalPay = subtotal - (subtotal * discount / 100);
                    objAddBills.txtTotalPay.Text = totalPay.ToString("F2");
                }
                else
                {
                    // Si no hay un descuento válido, solo mostrar el subtotal
                    objAddBills.txtTotalPay.Text = subtotal.ToString("F2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el total: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void TxtCustomerName_Leave(object sender, EventArgs e)
        {
            DAOAddBills dAOAddBills = new DAOAddBills();
            string customerName = objAddBills.txtCustomerName.Text.Trim();
            Dictionary<string, string> customerData = dAOAddBills.DataCustomer(customerName);

            if (customerData.Count > 0)
            {
                objAddBills.txtDUICustomer.Text = customerData["DUI"];
                objAddBills.txtCustomerPhone.Text = customerData["phone"];
                objAddBills.txtCustomerEmail.Text = customerData["email"];
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* public void ConfigurarAutocompletar()
         {
             AutoCompleteStringCollection autoCompleteCollection = GetAutocompleteData();

             // Configuración del TextBox de DUI
             objAddBills.txtDUICustomer.AutoCompleteCustomSource = autoCompleteCollection;
             objAddBills.txtDUICustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
             objAddBills.txtDUICustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;

             // Configuración del TextBox de Teléfono
             objAddBills.txtCustomerPhone.AutoCompleteCustomSource = autoCompleteCollection;
             objAddBills.txtCustomerPhone.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
             objAddBills.txtCustomerPhone.AutoCompleteSource = AutoCompleteSource.CustomSource;

             // Configuración del TextBox de Email
             objAddBills.txtCustomerEmail.AutoCompleteCustomSource = autoCompleteCollection;
             objAddBills.txtCustomerEmail.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
             objAddBills.txtCustomerEmail.AutoCompleteSource = AutoCompleteSource.CustomSource;
         }

         public AutoCompleteStringCollection GetAutocompleteData()
         {
             DAOAddBills dAOAddBills = new DAOAddBills();
             // Obtener datos desde DAO
             DataSet dataSet = dAOAddBills.DataCustomer();

             AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
             DataTable dataTable = dataSet.Tables[0];

             foreach (DataRow row in dataTable.Rows)
             {
                 autoCompleteCollection.Add(row["DUI"].ToString());
                 autoCompleteCollection.Add(row["phone"].ToString());
                 autoCompleteCollection.Add(row["email"].ToString());
             }

             return autoCompleteCollection;
         }
        */
        public void NewBill(object sender, EventArgs e)
{
    if (!(
        string.IsNullOrEmpty(objAddBills.txtNITCompany.Text.Trim()) ||
        string.IsNullOrEmpty(objAddBills.txtNRCompany.Text.Trim()) ||
        string.IsNullOrEmpty(objAddBills.txtDiscount.Text.Trim()) ||
        string.IsNullOrEmpty(objAddBills.txtSubTotal.Text.Trim()) ||
        string.IsNullOrEmpty(objAddBills.txtTotalPay.Text.Trim()) ||
        string.IsNullOrEmpty(objAddBills.txtCustomerName.Text.Trim()) ||
        string.IsNullOrEmpty(objAddBills.txtCustomerEmail.Text.Trim()) ||
        string.IsNullOrEmpty(objAddBills.txtCustomerPhone.Text.Trim()) ||
        string.IsNullOrEmpty(objAddBills.txtDUICustomer.Text.Trim()) ||
        string.IsNullOrEmpty(objAddBills.txtEmployee.Text.Trim())))
    {
        DAOAddBills daoNew = new DAOAddBills();

        daoNew.CompanyName = objAddBills.txtRazónsocial.Text.Trim();
        daoNew.NIT1 = objAddBills.txtNITCompany.Text.Trim();
        daoNew.NRC1 = objAddBills.txtNRCompany.Text.Trim();
        daoNew.Discount = double.Parse(objAddBills.txtDiscount.Text.Trim());
        daoNew.SubtotalPay = double.Parse(objAddBills.txtSubTotal.Text.Trim());
        daoNew.TotalPay = double.Parse(objAddBills.txtTotalPay.Text.Trim());
        daoNew.StartDate = objAddBills.dtStartDate.Value.Date;
        daoNew.FinalDate1 = objAddBills.dtFinalDate.Value.Date;
        daoNew.Dateissued = objAddBills.dtfiscalPeriod.Value.Date;
        daoNew.Services = objAddBills.comboServiceBill.SelectedValue.ToString();
        daoNew.StatusBills = objAddBills.comboStatusBill.SelectedValue.ToString();
        daoNew.CustomerDui1 = objAddBills.txtDUICustomer.Text.Trim();
        daoNew.CustomerPhone1 = objAddBills.txtCustomerPhone.Text.Trim();
        daoNew.CustomerEmail1 = objAddBills.txtCustomerEmail.Text.Trim();
        daoNew.Employee = objAddBills.txtEmployee.Text.Trim();
                int EmployeeId = daoNew.GetEmployeeIdByName(daoNew.Employee);
                if (EmployeeId == 1)
                {
                    MessageBox.Show("Empleado no encontrado en la base de datos.");
                    return;
                }

                daoNew.IdEmployee1 = EmployeeId;

                daoNew.MethodP = objAddBills.comboMethodP.SelectedValue.ToString();

        // Obtener IdCustomer basado en el nombre del cliente
        daoNew.Customer = objAddBills.txtCustomerName.Text.Trim();
        int customerId = daoNew.GetCustomerIdByName(daoNew.Customer);
        if (customerId == 1)
        {
            MessageBox.Show("Cliente no encontrado en la base de datos.");
            return;
        }

        daoNew.IdCustomer1 = customerId;
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

        public void RectifyBills(object sender, EventArgs e)
        {
            if (!(
         string.IsNullOrEmpty(objAddBills.txtNITCompany.Text.Trim()) ||
         string.IsNullOrEmpty(objAddBills.txtNRCompany.Text.Trim()) ||
         string.IsNullOrEmpty(objAddBills.txtDiscount.Text.Trim()) ||
         string.IsNullOrEmpty(objAddBills.txtSubTotal.Text.Trim()) ||
         string.IsNullOrEmpty(objAddBills.txtTotalPay.Text.Trim()) ||
         string.IsNullOrEmpty(objAddBills.txtCustomerName.Text.Trim()) ||
         string.IsNullOrEmpty(objAddBills.txtCustomerEmail.Text.Trim()) ||
         string.IsNullOrEmpty(objAddBills.txtCustomerPhone.Text.Trim()) ||
         string.IsNullOrEmpty(objAddBills.txtDUICustomer.Text.Trim()) ||
         string.IsNullOrEmpty(objAddBills.txtEmployee.Text.Trim())))
            {
                DAOAddBills daoNew = new DAOAddBills();

                daoNew.CompanyName = objAddBills.txtRazónsocial.Text.Trim();
                daoNew.NIT1 = objAddBills.txtNITCompany.Text.Trim();
                daoNew.NRC1 = objAddBills.txtNRCompany.Text.Trim();
                daoNew.Discount = double.Parse(objAddBills.txtDiscount.Text.Trim());
                daoNew.SubtotalPay = double.Parse(objAddBills.txtSubTotal.Text.Trim());
                daoNew.TotalPay = double.Parse(objAddBills.txtTotalPay.Text.Trim());
                daoNew.StartDate = objAddBills.dtStartDate.Value.Date;
                daoNew.FinalDate1 = objAddBills.dtFinalDate.Value.Date;
                daoNew.Dateissued = objAddBills.dtfiscalPeriod.Value.Date;
                daoNew.Services = objAddBills.comboServiceBill.SelectedValue.ToString();
                daoNew.StatusBills = objAddBills.comboStatusBill.SelectedValue.ToString();
                daoNew.CustomerDui1 = objAddBills.txtDUICustomer.Text.Trim();
                daoNew.CustomerPhone1 = objAddBills.txtCustomerPhone.Text.Trim();
                daoNew.CustomerEmail1 = objAddBills.txtCustomerEmail.Text.Trim();
                daoNew.Employee = objAddBills.txtEmployee.Text.Trim();
                int EmployeeId = daoNew.GetEmployeeIdByName(daoNew.Employee);
                if (EmployeeId == 1)
                {
                    MessageBox.Show("Empleado no encontrado en la base de datos.");
                    return;
                }

                daoNew.IdEmployee1 = EmployeeId;

                daoNew.MethodP = objAddBills.comboMethodP.SelectedValue.ToString();

                // Obtener IdCustomer basado en el nombre del cliente
                daoNew.Customer = objAddBills.txtCustomerName.Text.Trim();
                int customerId = daoNew.GetCustomerIdByName(daoNew.Customer);
                if (customerId == 1)
                {
                    MessageBox.Show("Cliente no encontrado en la base de datos.");
                    return;
                }

                daoNew.IdCustomer1 = customerId;
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
            objAddBills.Close();
        }

        public void BackProcess(object sender, EventArgs e)
            {
                objAddBills.Close();
            }
            public void ChargeValues(int id, string companyName, string NIT, string NRC, string customer, double discount, double SubtotalPay, double TotalPay, DateTime startDate, DateTime FinalDate, DateTime Dateissued, string employee, string CustomerDui, string CustomerPhone, string CustomerEmail)
            {
                objAddBills.txtRazónsocial.Text = companyName;
                objAddBills.txtNITCompany.Text = NIT.ToString();
                objAddBills.txtNRCompany.Text = NRC.ToString();
                objAddBills.txtCustomerName.Text = customer.ToString();
                objAddBills.txtCustomerEmail.Text = CustomerEmail;
                objAddBills.txtCustomerPhone.Text = CustomerPhone.ToString();
                objAddBills.txtDUICustomer.Text = CustomerDui.ToString();
                objAddBills.txtDiscount.Text = discount.ToString();
                objAddBills.txtSubTotal.Text = SubtotalPay.ToString();
                objAddBills.txtTotalPay.Text = TotalPay.ToString();
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
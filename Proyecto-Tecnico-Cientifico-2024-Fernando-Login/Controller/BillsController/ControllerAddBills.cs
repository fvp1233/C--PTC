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
using PTC2024.View.Clientes;
using PTC2024.Controller.CustomersController;
using PTC2024.Model.DAO.EmployeesDAO;
using PTC2024.Controller.Helper;
using PTC2024.View.formularios.inicio;
using PTC2024.Model.DAO.HelperDAO;
using System.Drawing;
using System.IO;
using QRCoder;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Imaging;
using System.Diagnostics; // Para abrir el PDF después de generarlo

namespace PTC2024.Controller.BillsController
{
    internal class ControllerAddBills
    {
        FrmAddBills objAddBills;
        private int accions;
        private string IdServices;
        private string customer;
        private DataSet reportDataSet;
        StartMenu objStartMenu;
        public ControllerAddBills(FrmAddBills View, int accions)
        {
            objAddBills = View;
            this.accions = accions;


            chooseAccions();
            objAddBills.Load += new EventHandler(LoadDataServices);

            objAddBills.btnAddBill.Click += new EventHandler(NewBill);
            objAddBills.btnmore.Click += new EventHandler(More);
            objAddBills.btnPlusC.Click += new EventHandler(AddOtherCustomer);
            objAddBills.btnBack.Click += new EventHandler(BackProcess);
            objAddBills.btnDeletemore.Click += new EventHandler(DataProcessS);
            objAddBills.txtSubTotal.TextChanged += new EventHandler(CalculateTotal);
            objAddBills.txtDiscount.TextChanged += new EventHandler(TxtDiscount_TextChanged);
            objAddBills.txtCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            objAddBills.txtCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            objAddBills.txtCustomerName.TextChanged += txtCustomerName_TextChanged;
            objAddBills.txtEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            objAddBills.txtEmployee.AutoCompleteSource = AutoCompleteSource.CustomSource;
            objAddBills.txtEmployee.TextChanged += txtEmployeeName_TextChanged;
            objAddBills.txtTotalPay.TextChanged += new EventHandler(CalculateTotal);
            objAddBills.dgvData.CellValueChanged += new DataGridViewCellEventHandler(CalculateTotal);
            objAddBills.dgvData.RowsAdded += new DataGridViewRowsAddedEventHandler(CalculateTotal);
            objAddBills.dgvData.RowsRemoved += new DataGridViewRowsRemovedEventHandler(CalculateTotal);
            objAddBills.txtcompanyN.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddBills.txtcompanyN.TextChanged += new EventHandler(OnlyLettersAndNumbers);
            objAddBills.txtNITCompany.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddBills.txtNITCompany.TextChanged += new EventHandler(NITMask);
            objAddBills.txtNRCompany.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddBills.txtNRCompany.TextChanged += new EventHandler(NRCNumberMask);
            objAddBills.txtEmployee.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddBills.txtEmployee.TextChanged += new EventHandler(OnlyLettersName);
            objAddBills.txtCustomerName.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddBills.txtCustomerName.TextChanged += new EventHandler(OnlyLettersNameC);
            objAddBills.txtCustomerPhone.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddBills.txtCustomerPhone.TextChanged += new EventHandler(PhoneMask);
            objAddBills.txtDUICustomer.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddBills.txtDUICustomer.TextChanged += new EventHandler(DUIMask);
            objAddBills.txtCustomerEmail.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddBills.txtDiscount.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddBills.txtDiscount.TextChanged += new EventHandler(DiscountMask);
            objAddBills.txtDiscount.TextChanged += new EventHandler(OnlyNum);
            objAddBills.txtSubTotal.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddBills.txtTotalPay.MouseDown += new MouseEventHandler(DisableContextMenu);

        }

        
        private void TxtDiscount_TextChanged1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public ControllerAddBills(FrmAddBills view, int accions, string companyName, string NIT, string NRC, string Customer,   string CustomerDui, string CustomerPhone, string CustomerEmail, string employee)
        {
            objAddBills = view;
            this.accions = accions;
            this.customer = Customer;



            objAddBills.Load += new EventHandler(LoadDataServices);
            chooseAccions();
            ChargeValues( companyName, NIT, NRC, Customer,CustomerDui, CustomerPhone, CustomerEmail, employee);

           // objAddBills.btnRectify.Click += new EventHandler(RectifyBills);
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
            objAddBills.dtfiscalPeriod.Value = DateTime.Now;
            InitialCharge();
            if(Properties.Settings.Default.darkMode == true)
            {
                objAddBills.BackColor = Color.FromArgb(30,30,30);
                objAddBills.lblTitle.ForeColor = Color.White;
                objAddBills.lblSubTitle.ForeColor = Color.White;
                objAddBills.gbInfoEmployee.ForeColor = Color.White;
                objAddBills.gbInfoCustomer.ForeColor = Color.White;
                objAddBills.gbPayInfo.ForeColor = Color.White;
                objAddBills.gbService.ForeColor = Color.White;
                objAddBills.txtcompanyN.FillColor = Color.FromArgb(60,60,60);
                objAddBills.txtcompanyN.BorderColorIdle = Color.Gray;
                objAddBills.txtNITCompany.FillColor = Color.FromArgb(60, 60, 60);
                objAddBills.txtNITCompany.BorderColorIdle = Color.Gray;
                objAddBills.txtNRCompany.FillColor = Color.FromArgb(60, 60, 60);
                objAddBills.txtNRCompany.BorderColorIdle = Color.Gray;
                objAddBills.txtEmployee.FillColor = Color.FromArgb(60, 60, 60);
                objAddBills.txtEmployee.BorderColorIdle = Color.Gray;
                objAddBills.txtCustomerName.FillColor = Color.FromArgb(60, 60, 60);
                objAddBills.txtCustomerName.BorderColorIdle = Color.Gray;
                objAddBills.txtDUICustomer.FillColor = Color.FromArgb(60, 60, 60);
                objAddBills.txtDUICustomer.BorderColorIdle = Color.Gray;
                objAddBills.txtCustomerPhone.FillColor = Color.FromArgb(60, 60, 60);
                objAddBills.txtCustomerPhone.BorderColorIdle = Color.Gray;
                objAddBills.txtCustomerEmail.FillColor = Color.FromArgb(60, 60, 60);
                objAddBills.txtCustomerEmail.BorderColorIdle = Color.Gray;
                objAddBills.comboServiceBill.BackgroundColor = Color.FromArgb(60, 60, 60);
                objAddBills.comboServiceBill.BorderColor = Color.Gray;
                objAddBills.comboServiceBill.ForeColor = Color.White;
                objAddBills.comboServiceBill.ItemBackColor = Color.DimGray;
                objAddBills.comboServiceBill.ItemBorderColor = Color.Gray;
                objAddBills.comboServiceBill.ItemForeColor = Color.White;
                objAddBills.dtStartDate.BackColor = Color.FromArgb(60, 60, 60);
                objAddBills.dtStartDate.ForeColor = Color.White;
                objAddBills.dtStartDate.IconColor = Color.White;
                objAddBills.dtFinalDate.BackColor = Color.FromArgb(60, 60, 60);
                objAddBills.dtFinalDate.ForeColor = Color.White;
                objAddBills.dtFinalDate.IconColor = Color.White;
                objAddBills.dtfiscalPeriod.BackColor = Color.FromArgb(60, 60, 60);
                objAddBills.dtfiscalPeriod.ForeColor = Color.White;
                objAddBills.dtfiscalPeriod.IconColor = Color.White;
                objAddBills.comboMethodP.BackgroundColor = Color.FromArgb(60, 60, 60);
                objAddBills.comboMethodP.BorderColor = Color.Gray;
                objAddBills.comboMethodP.ForeColor = Color.White;
                objAddBills.comboMethodP.ItemBackColor = Color.DimGray;
                objAddBills.comboMethodP.ItemBorderColor = Color.Gray;
                objAddBills.comboMethodP.ItemForeColor = Color.White;
                objAddBills.comboStatusBill.BackgroundColor = Color.FromArgb(60, 60, 60);
                objAddBills.comboStatusBill.BorderColor = Color.Gray;
                objAddBills.comboStatusBill.ForeColor = Color.White;
                objAddBills.comboStatusBill.ItemBackColor = Color.DimGray;
                objAddBills.comboStatusBill.ItemBorderColor = Color.Gray;
                objAddBills.comboStatusBill.ItemForeColor = Color.White;
                objAddBills.txtDiscount.FillColor = Color.FromArgb(60, 60, 60);
                objAddBills.txtDiscount.BorderColorIdle = Color.Gray;
                objAddBills.txtSubTotal.FillColor = Color.FromArgb(60, 60, 60);
                objAddBills.txtSubTotal.BorderColorIdle = Color.Gray;
                objAddBills.txtTotalPay.FillColor = Color.FromArgb(60, 60, 60);
                objAddBills.txtTotalPay.BorderColorIdle = Color.Gray;
                objAddBills.dgvData.BackgroundColor = Color.FromArgb(45, 45, 45);
                objAddBills.dgvData.HeaderBackColor = Color.LightSlateGray;
                objAddBills.dgvData.GridColor = Color.FromArgb(45, 45, 45);
                objAddBills.dgvData.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
                objAddBills.dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray;
            }
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
                objAddBills.btnAddBill.Visible = false;
                objAddBills.btnBack.Visible = true;
                objAddBills.btnRectify.Visible = true;
            }
            else if (accions == 2)
            {
                objAddBills.btnRectify.Visible = false;
                objAddBills.btnAddBill.Visible = true;
                objAddBills.btnBack.Visible = true;
            }
            else if (accions == 3)
            {
                objAddBills.btnmore.Enabled = true;
            }
        }

        public void More(object sender, EventArgs e)
        {
            try
            {
                DAOAddBills dAOAdd = new DAOAddBills();
                if (int.TryParse(objAddBills.comboServiceBill.SelectedValue.ToString(), out int selectedServiceId))
                {
                    // Obtener el precio del servicio seleccionado
                    float price = dAOAdd.GetServicePrice(selectedServiceId);

                    // Añadir el servicio y precio a la base de datos
                    dAOAdd.IdServices1 = selectedServiceId;
                    dAOAdd.Price1 = price;
                    int result = dAOAdd.DataB();

                    // Verificamos el valor que nos retorna dicho método
                    if (result == 1)
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
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateDataSetForReport(DataSet reportDataSet)
        {
            // Recorrer todas las filas del DataGridView
            foreach (DataGridViewRow row in objAddBills.dgvData.Rows)
            {
                // Revisar si la fila ha sido eliminada (o marcada como eliminada)
                bool isDeleted = Convert.ToBoolean(row.Cells["IsDeletedColumn"].Value); // Suponiendo que tienes una columna que marca eliminados

                // Si está eliminada, buscar y eliminar del DataSet
                if (isDeleted)
                {
                    // Buscar la fila correspondiente en el DataSet por el ID del servicio
                    string serviceName = row.Cells["Servicio"].Value.ToString();
                    DataRow[] rowsToDelete = reportDataSet.Tables["tbBillDataS"].Select($"Servicio = '{serviceName}'");

                    // Eliminar la fila del DataSet
                    foreach (DataRow dr in rowsToDelete)
                    {
                        dr.Delete(); // Marcar como eliminada en el DataSet
                    }
                }
            }

            // Asegurarse de aceptar cambios para actualizar el estado del DataSet
            reportDataSet.AcceptChanges();
        }

        public DataSet GetUpdatedDataSet()
        {
            return reportDataSet;
        }
        /// <summary>
        /// Método para agregar cliente no registrado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddOtherCustomer(object sender, EventArgs e)
        {
            FrmAddCustomers openA = new FrmAddCustomers();
            openA.ShowDialog();

        }
        /// <summary>
        /// Método para calcular total, subtotal en base al descuento aplicado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Método para eliminar los datos de dgvDetail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private string previousCustomerName = string.Empty; // Para evitar consultas repetidas

        public async void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string customerName = objAddBills.txtCustomerName.Text.Trim();

                // Solo buscar si el texto ha cambiado y tiene al menos 3 caracteres
                if (customerName.Length >= 3 && customerName != previousCustomerName)
                {
                    previousCustomerName = customerName; // Actualizar el nombre de búsqueda previo

                    DAOAddBills dAOAddBills = new DAOAddBills();

                    // Obtener lista de nombres de cliente de manera asíncrona
                    List<string> customerNames = await Task.Run(() => dAOAddBills.GetCustomerNames(customerName));

                    if (customerNames.Count > 0)
                    {
                        AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                        autoCompleteCollection.AddRange(customerNames.ToArray());
                        objAddBills.txtCustomerName.AutoCompleteCustomSource = autoCompleteCollection; // Asignar la fuente de autocompletado

                        // Obtener los detalles del cliente de manera asíncrona
                        Dictionary<string, string> customerData = await Task.Run(() => dAOAddBills.GetCustomerDetails(customerName));

                        if (customerData.Count > 0)
                        {
                            // Actualizar formulario con los detalles del cliente
                            objAddBills.txtDUICustomer.Text = customerData["DUI"];
                            objAddBills.txtCustomerPhone.Text = customerData["phone"];
                            objAddBills.txtCustomerEmail.Text = customerData["email"];
                        }
                    }
                    else
                    {
                        objAddBills.txtCustomerName.AutoCompleteCustomSource = null; // Limpiar la fuente de autocompletado si no hay resultados
                    }
                }
                else if (customerName.Length < 3)
                {
                    // Si el nombre tiene menos de 3 caracteres, limpiar la fuente de autocompletado
                    objAddBills.txtCustomerName.AutoCompleteCustomSource = null;
                    previousCustomerName = string.Empty; // Reiniciar la búsqueda previa
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string previousEmployeeName = string.Empty; // Para almacenar el nombre de empleado anterior

        public async void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string employeeName = objAddBills.txtEmployee.Text.Trim();

                // Solo buscar si el nombre tiene al menos 3 caracteres y es diferente al anterior
                if (employeeName.Length >= 3 && employeeName != previousEmployeeName)
                {
                    previousEmployeeName = employeeName; // Actualizar el nombre de búsqueda anterior

                    DAOAddBills dAOAddBills = new DAOAddBills();

                    // Realizar la búsqueda de manera asíncrona para no bloquear la UI
                    List<string> employeeNames = await Task.Run(() => dAOAddBills.GetEmployeesNames(employeeName));

                    if (employeeNames.Count > 0)
                    {
                        // Solo actualizar el autocompletado si los resultados son diferentes
                        AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                        autoCompleteCollection.AddRange(employeeNames.ToArray());
                        objAddBills.txtEmployee.AutoCompleteCustomSource = autoCompleteCollection;
                    }
                    else
                    {
                        objAddBills.txtEmployee.AutoCompleteCustomSource = null; // Limpiar si no hay resultados
                    }
                }
                else if (employeeName.Length < 3)
                {
                    // Limpiar el autocompletado si el nombre es muy corto
                    objAddBills.txtEmployee.AutoCompleteCustomSource = null;
                    previousEmployeeName = string.Empty; // Reiniciar el nombre previo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public bool ValidateDates(DateTime startDate, DateTime finalDate, DateTime dateIssued)
        {
            //Fecha de inicio y fecha final
            if (startDate > finalDate)
            {
                MessageBox.Show("La fecha de inicio debe ser menor o igual a la fecha de finalización.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //Fecha de emisión 
            if (dateIssued < finalDate || dateIssued < DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de emisión debe ser mayor o igual a la fecha final o igual a la fecha actual.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

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

                daoNew.CompanyName = objAddBills.txtcompanyN.Text.Trim();
                daoNew.NIT1 = objAddBills.txtNITCompany.Text.Trim();
                daoNew.NRC1 = objAddBills.txtNRCompany.Text.Trim();
                daoNew.Discount = double.Parse(objAddBills.txtDiscount.Text.Trim());
                daoNew.SubtotalPay = double.Parse(objAddBills.txtSubTotal.Text.Trim());
                daoNew.TotalPay = double.Parse(objAddBills.txtTotalPay.Text.Trim());
                daoNew.StartDate = objAddBills.dtStartDate.Value.Date;
                daoNew.FinalDate1 = objAddBills.dtFinalDate.Value.Date;
                daoNew.Dateissued = objAddBills.dtfiscalPeriod.Value.Date;

                // Validación de fechas utilizando el método ValidateDates
                if (!ValidateDates(daoNew.StartDate, daoNew.FinalDate1, daoNew.Dateissued))
                {
                    return;
                }

                daoNew.Services = objAddBills.comboServiceBill.SelectedValue.ToString();
                daoNew.StatusBills = objAddBills.comboStatusBill.SelectedValue.ToString();
                daoNew.CustomerDui1 = objAddBills.txtDUICustomer.Text.Trim();
                daoNew.CustomerPhone1 = objAddBills.txtCustomerPhone.Text.Trim();
                daoNew.CustomerEmail1 = objAddBills.txtCustomerEmail.Text.Trim();
                daoNew.Employee = objAddBills.txtEmployee.Text.Trim();

                int EmployeeId = daoNew.GetEmployeeIdByName(daoNew.Employee);
                if (EmployeeId == 1)
                {
                    StartMenu startMenu = new StartMenu(SessionVar.Username);
                    startMenu.snackBar.Show(startMenu, $"Empleado no encontrado en la base de datos", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
                    
                    return;
                }

                daoNew.IdEmployee1 = EmployeeId;
                daoNew.MethodP = objAddBills.comboMethodP.SelectedValue.ToString();

                // Obtener IdCustomer basado en el nombre del cliente
                daoNew.Customer = objAddBills.txtCustomerName.Text.Trim();
                int customerId = daoNew.GetCustomerIdByName(daoNew.Customer);
                if (customerId == -1)
                {
                    StartMenu startMenu = new StartMenu(SessionVar.Username);
                    startMenu.snackBar.Show(startMenu, $"Cliente no encontrado en la base de datos", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
                    
                    return;
                }

                daoNew.IdCustomer1 = customerId;
                int checks = daoNew.RegisterBills();

                // Verificamos el valor que nos retorna dicho método
                if (checks == 1)
                {
                    StartMenu startMenu = new StartMenu(SessionVar.Username);
                    startMenu.snackBar.Show(startMenu, $"Los datos se registraron de manera exitosa", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
                    int idBill = daoNew.GetLastInsertedBillId(); 

                    // Generar el PDF con el ID de la factura
                    string pdfFilePath = GenerateBillPDF(idBill);

                    // Enviar el PDF por correo si la ruta del archivo es válida
                    if (!string.IsNullOrEmpty(pdfFilePath))
                    {
                        bool emailSent = SendEmail(pdfFilePath);

                        if (!emailSent)
                        {
                            startMenu.snackBar.Show(startMenu, $"La factura fue generada pero no se pudo enviar por correo.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                        }
                    }
                    DAOInitialView daoInitial = new DAOInitialView();
                    daoInitial.ActionType = "Se insertó una factura";
                    daoInitial.TableName = "Facturas";
                    daoInitial.ActionBy = SessionVar.Username;
                    daoInitial.ActionDate = DateTime.Now;
                    int auditAnswer = daoInitial.InsertAudit();
                    if (auditAnswer != 1)
                    {
                        objStartMenu.snackBar.Show(objStartMenu, $"La auditoria no pudo ser registrada", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                    }

                    objAddBills.Close();
                }
            }
            else
            {
                StartMenu startMenu = new StartMenu(SessionVar.Username);
                startMenu.snackBar.Show(startMenu, $"Por favor, complete todos los campos requeridos", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
            }
        }
        // Método para generar el PDF de una factura
        public string GenerateBillPDF(int idBill)
        {
            try
            {
                DAOBills dAOBills = new DAOBills();
                DataSet dsBill = dAOBills.GetBillDetails(idBill);

                if (dsBill != null && dsBill.Tables["viewBill"].Rows.Count > 0)
                {
                    DataRow billRow = dsBill.Tables["viewBill"].Rows[0];

                    string tempFilePath = Path.Combine(Path.GetTempPath(), $"Bill_{idBill}.pdf");

                    Document doc = new Document(PageSize.A4, 50, 50, 25, 25); // Márgenes ajustados
                    PdfWriter.GetInstance(doc, new FileStream(tempFilePath, FileMode.Create));
                    doc.Open();

                    // Fuentes mejoradas
                    var titleFont = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD, BaseColor.RED);
                    var regularFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                    var boldFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    var headerFont = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.RED);

                    // Añadir el logo
                    string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "H2C_HR negro.png");
                    if (System.IO.File.Exists(imagePath))
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagePath);
                        img.ScaleToFit(140f, 120f);
                        img.Alignment = Element.ALIGN_CENTER;
                        doc.Add(img);
                    }
                    else
                    {
                        doc.Add(new Paragraph("No se encontró la imagen.", boldFont));
                    }

                    // Datos principales
                    doc.Add(new Paragraph($"Número de Factura: {billRow["N°"]}", boldFont));
                    doc.Add(new Paragraph($"Razón Social: {billRow["Razon Social"]}", regularFont));
                    doc.Add(new Paragraph($"NIT: {billRow["NIT"]}", regularFont));
                    doc.Add(new Paragraph($"NRC: {billRow["NRC"]}", regularFont));
                    doc.Add(new Paragraph($"Cliente: {billRow["Cliente"]}", regularFont));
                    doc.Add(new Paragraph($"DUI del Cliente: {billRow["DUI"]}", regularFont));
                    doc.Add(new Paragraph($"Teléfono del Cliente: {billRow["Télefono"]}", regularFont));
                    doc.Add(new Paragraph($"Email del Cliente: {billRow["Email"]}", regularFont));
                    doc.Add(new Paragraph(" "));

                    // Segunda tabla para detalles del servicio
                    PdfPTable serviceTable = new PdfPTable(2);
                    serviceTable.WidthPercentage = 100;
                    serviceTable.SetWidths(new float[] { 1f, 2f });

                    serviceTable.AddCell(CreateCell("Servicio:", boldFont, BaseColor.LIGHT_GRAY));
                    serviceTable.AddCell(CreateCell(billRow["Servicios"].ToString(), regularFont, BaseColor.WHITE));

                    serviceTable.AddCell(CreateCell("Descuento:", boldFont, BaseColor.LIGHT_GRAY));
                    serviceTable.AddCell(CreateCell($"{billRow["Descuento"]}%", regularFont, BaseColor.WHITE));

                    serviceTable.AddCell(CreateCell("Subtotal:", boldFont, BaseColor.LIGHT_GRAY));
                    serviceTable.AddCell(CreateCell($"${billRow["Subtotal"]}", regularFont, BaseColor.WHITE));

                    serviceTable.AddCell(CreateCell("Total a Pagar:", boldFont, BaseColor.LIGHT_GRAY));
                    serviceTable.AddCell(CreateCell($"${billRow["Total"]}", regularFont, BaseColor.WHITE));

                    serviceTable.AddCell(CreateCell("Método de Pago:", boldFont, BaseColor.LIGHT_GRAY));
                    serviceTable.AddCell(CreateCell(billRow["Método de Pago"].ToString(), regularFont, BaseColor.WHITE));

                    doc.Add(serviceTable);
                    doc.Add(new Paragraph(" "));

                    // Fechas
                    doc.Add(new Paragraph($"Fecha de Emisión: {billRow["Fecha de emisión"]}", regularFont));
                    doc.Add(new Paragraph($"Fecha Inicio del Servicio: {billRow["Fecha inicio"]}", regularFont));
                    doc.Add(new Paragraph($"Fecha Fin del Servicio: {billRow["Fecha fin"]}", regularFont));
                    doc.Add(new Paragraph(" "));

                    // Encargado y estado
                    doc.Add(new Paragraph($"Encargado: {billRow["Encargado"]}", regularFont));
                    doc.Add(new Paragraph($"Estado de la Factura: {billRow["Estado"]}", regularFont));

                    // Generar código QR
                    string qrData = $"Factura N°: {billRow["N°"]}\n" +
                                    $"Razón Social: {billRow["Razon Social"]}\n" +
                                    $"Cliente: {billRow["Cliente"]}\n" +
                                    $"Total a Pagar: ${billRow["Total"]}\n" +
                                    $"Fecha de Emisión: {billRow["Fecha de emisión"]}";

                    using (MemoryStream msQrCode = new MemoryStream())
                    {
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);

                        using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
                        {
                            qrCodeImage.Save(msQrCode, ImageFormat.Png);
                        }

                        iTextSharp.text.Image qrImage = iTextSharp.text.Image.GetInstance(msQrCode.ToArray());
                        qrImage.ScaleToFit(100f, 100f);
                        qrImage.Alignment = Element.ALIGN_RIGHT;

                        doc.Add(qrImage);
                    }

                    doc.Close();
                    // Enviar el PDF por correo
                    bool emailSent = SendEmail(tempFilePath);

                    if (!emailSent)
                    {
                        MessageBox.Show("La factura fue generada pero no se pudo enviar por correo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Factura generada y enviada por correo exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //// Abrir el PDF en el navegador predeterminado o visor de PDF
                    //Process.Start(new ProcessStartInfo(tempFilePath)
                    //{
                    //    UseShellExecute = true // Esto asegurará que se abra con el programa predeterminado del sistema
                    //});
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para la factura seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message);
            }
            return null;
        }

        public bool SendEmail(string pdfFilePath)
        {
            string para = objAddBills.txtCustomerEmail.Text.Trim();
            string de = "h2c.soporte.usuarios@gmail.com";
            string subject = "H2C: Gracias por visitarnos.";
            string message = $"Hola estimado cliente, se adjunta los datos de tu factura electronica {BusinessVar.BusinessName}.\nEn caso de tener algun problema, favor enviarla en este mismo correo.";

            Email email = new Email();
            bool answer = email.CustomerEmailAttachment(para, de, subject, message, pdfFilePath);

            return answer;
        }
        // Método auxiliar para crear celdas con estilo
        private PdfPCell CreateCell(string text, iTextSharp.text.Font font, BaseColor backgroundColor)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font)) // Aquí asegúrate de usar iTextSharp.text.Font
            {
                BackgroundColor = backgroundColor,
                Padding = 5,
                BorderColor = BaseColor.BLACK,
                HorizontalAlignment = Element.ALIGN_LEFT
            };
            return cell;
        }

        //Método para deshabilitar el contextmenu de los textbox
        private void DisableContextMenu(object sender, MouseEventArgs e)
        {
            // Desactiva el menú contextual al hacer clic derecho
            if (e.Button == MouseButtons.Right)
            {
                ((Bunifu.UI.WinForms.BunifuTextBox)sender).ContextMenu = new ContextMenu();  // Asigna un menú vacío
            }
        }

        public void OnlyLettersAndNumbers(object sender, EventArgs e)
        {
                // Obtener la posición actual del cursor
                int cursorPosition = objAddBills.txtcompanyN.SelectionStart;

                // Filtrar el texto para que solo queden letras, números, puntos y espacios
                string text = new string(objAddBills.txtcompanyN.Text
                                           .Where(c => char.IsLetter(c) || char.IsDigit(c) || char.IsWhiteSpace(c) || c == '.')
                                           .ToArray());

                // Actualizar el contenido del TextBox con el texto filtrado
                objAddBills.txtcompanyN.Text = text;

                // Restaurar la posición del cursor
                objAddBills.txtcompanyN.SelectionStart = cursorPosition;
            

        }

        public void OnlyLettersName(object sender, EventArgs e)
        {
            // Obtener la posición actual del cursor
            int cursorPosition = objAddBills.txtEmployee.SelectionStart;

            // Filtrar el texto para que solo queden letras y espacios
            string text = new string(objAddBills.txtEmployee.Text
                                       .Where(c => char.IsLetter(c) || char.IsWhiteSpace(c))
                                       .ToArray());

            // Actualizar el contenido del TextBox con el texto filtrado
            objAddBills.txtEmployee.Text = text;

            // Restaurar la posición del cursor
             objAddBills.txtEmployee.SelectionStart = cursorPosition;
        }

        public void OnlyLettersNameC(object sender, EventArgs e)
        {
            // Obtener la posición actual del cursor
            int cursorPosition = objAddBills.txtCustomerName.SelectionStart;

            // Filtrar el texto para que solo queden letras y espacios
            string text = new string(objAddBills.txtCustomerName.Text
                                       .Where(c => char.IsLetter(c) || char.IsWhiteSpace(c))
                                       .ToArray());

            // Actualizar el contenido del TextBox con el texto filtrado
            objAddBills.txtCustomerName.Text = text;

            // Restaurar la posición del cursor
            objAddBills.txtCustomerName.SelectionStart = cursorPosition;
        }

        //Aplicamos una máscara que solo deje meter el guion y caracteres numéricos para los textbox de numero de afiliacion y cuenta bancaria.
        public void NRCNumberMask(object sender, EventArgs e)
        {
            int cursorPosition = objAddBills.txtNRCompany.SelectionStart;

            // Remover cualquier dato no numérico excepto el guion
            string text = new string(objAddBills.txtNRCompany.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());

            // Remover todos los guiones para reformatear correctamente
            text = text.Replace("-", "");

            // Asegurar que el texto no exceda los 14 dígitos (sin guiones)
            if (text.Length > 14)
            {
                text = text.Substring(0, 14);
            }

            // Formatear a ####-######-###-##
            if (text.Length > 4)
            {
                text = text.Insert(4, "-");
            }
            if (text.Length > 11)
            {
                text = text.Insert(11, "-");
            }
            if (text.Length > 15)
            {
                text = text.Insert(15, "-");
            }

            // Aplicar el texto formateado
            objAddBills.txtNRCompany.Text = text;

            // Restaurar la posición del cursor
            objAddBills.txtNRCompany.SelectionStart = cursorPosition;
        }


        //Método de validación de numeros NIT 

        public void NITMask(object sender, EventArgs e)
        {
            // Guardar la posición actual del cursor
            int cursorPosition = objAddBills.txtNITCompany.SelectionStart;

            // Remover cualquier dato no numérico excepto el guion
            string text = new string(objAddBills.txtNITCompany.Text.Where(c => char.IsDigit(c) || c == '-').ToArray());

            // Remover todos los guiones para reformatear correctamente
            text = text.Replace("-", "");

            // Asegurar que el texto no exceda los 14 dígitos (sin guiones)
            if (text.Length > 14)
            {
                text = text.Substring(0, 14);
            }

            // Formatear a ####-######-###-#
            if (text.Length > 4)
            {
                text = text.Insert(4, "-");
            }
            if (text.Length > 11)
            {
                text = text.Insert(11, "-");
            }
            if (text.Length > 15)
            {
                text = text.Insert(15, "-");
            }

            // Aplicar el texto formateado
            objAddBills.txtNITCompany.Text = text;

            // Restaurar la posición del cursor
            objAddBills.txtNITCompany.SelectionStart = cursorPosition;
        }


        //Método para admitir solo numeros en descuento
        public void DiscountMask(object sender, EventArgs e)
        {
            // Guardar la posición actual del cursor
            int cursorPosition = objAddBills.txtDiscount.SelectionStart;

            // Permitir dígitos y un solo punto decimal
            string text = new string(objAddBills.txtDiscount.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            // Asegurarse de que solo hay un punto decimal
            int dotIndex = text.IndexOf('.');
            if (dotIndex != -1)
            {
                text = text.Substring(0, dotIndex + 1) + text.Substring(dotIndex + 1).Replace(".", "");
            }

            // Actualizar el texto en el campo
            objAddBills.txtDiscount.Text = text;

            // Restaurar la posición del cursor
            objAddBills.txtDiscount.SelectionStart = cursorPosition;
        }


        //Método para establecer una máscara al textbox del DUI
        public void DUIMask(object sender, EventArgs e)
        {
            // Aqui se guarda la posición inicial del cursor
            int cursorPosition = objAddBills.txtDUICustomer.SelectionStart;

            //Con esto se remueve cualquier dato no numérico excepto el guión
            string text = new string(objAddBills.txtDUICustomer. Text.Where(c => char.IsDigit(c) || c == '-').ToArray());

            //Si ya existe algun guión, se elimina.
            text = text.Replace("-", "");

            //Acá especificamos la máscara del DUI, cuando llegue al caracter numero 9, va a ingresar el guion por si solo
            //
            if (text.Length >= 9)
            {
                text = text.Insert(8, "-");
                cursorPosition++;
            }
            else if (text.Length >= 1)
            {
                text = text.Insert(0, "");
            }

            //Le asignamos la máscara al texto que se presente en el textbox
            objAddBills.txtDUICustomer.Text = text;

            //Restablecemos la posicion del cursor
            objAddBills.txtDUICustomer.SelectionStart = cursorPosition;
        }

        //Máscara para el textbox del telefono
        public void PhoneMask(object sender, EventArgs e)
        {
            // Aquí se guarda la posición inicial del cursor, para que con el evento TextChanged el cursor no se mueva de lugar
            int cursorPosition = objAddBills.txtCustomerPhone.SelectionStart;

            // Remover cualquier dato no numérico
            string text = new string(objAddBills.txtCustomerPhone.Text.Where(c => char.IsDigit(c)).ToArray());

            // Aplicar la máscara de teléfono (ej: ####-###)
            if (text.Length >= 5)
            {
                text = text.Insert(4, "-");
            }

            // Ajustar la posición del cursor si está después del guion
            if (cursorPosition == 5)
            {
                cursorPosition++;
            }

            // Asignar el texto con la máscara al TextBox
            objAddBills.txtCustomerPhone.Text = text;

            // Restablecer la posición del cursor
            objAddBills.txtCustomerPhone.SelectionStart = cursorPosition;
        }


        public void BackProcess(object sender, EventArgs e)
        {
            objAddBills.Close();
        }
        public void ChargeValues( string companyName, string NIT, string NRC, string customer, string CustomerDui, string CustomerPhone, string CustomerEmail, string employee)
        {
            objAddBills.txtcompanyN.Text = companyName;
            objAddBills.txtNITCompany.Text = NIT.ToString();
            objAddBills.txtNRCompany.Text = NRC.ToString();
            objAddBills.txtCustomerName.Text = customer.ToString();
            objAddBills.txtCustomerEmail.Text = CustomerEmail;
            objAddBills.txtCustomerPhone.Text = CustomerPhone.ToString();
            objAddBills.txtDUICustomer.Text = CustomerDui.ToString();
            objAddBills.txtEmployee.Text = employee;
        }
        public void ChargeV(int id, string IdServices1, float Price1)
        {
            objAddBills.comboServiceBill.SelectedValue.ToString();
        }
        public void OnlyNum(object sender, EventArgs e)
        {
            int cursorPosition = objAddBills.txtDiscount.SelectionStart;

            // Permitir solo dígitos y un solo punto decimal
            string text = new string(objAddBills.txtDiscount.Text.Where(c => char.IsDigit(c) || c == '.').ToArray());

            // Asegurarse de que solo haya un punto decimal
            int decimalCount = text.Count(c => c == '.');
            if (decimalCount > 1)
            {
                // Si hay más de un punto decimal, remover los adicionales
                int firstDecimalIndex = text.IndexOf('.');
                text = text.Substring(0, firstDecimalIndex + 1) + text.Substring(firstDecimalIndex + 1).Replace(".", "");
            }

            // Evitar que el texto comience con un punto decimal
            if (text.StartsWith("."))
            {
                text = text.TrimStart('.');
            }

            // Limitar a solo dos decimales después del punto
            int decimalPosition = text.IndexOf('.');
            if (decimalPosition != -1 && text.Length > decimalPosition + 3)
            {
                // Truncar a dos dígitos después del punto decimal
                text = text.Substring(0, decimalPosition + 3);
            }

            // Validar que el número no sea mayor a 100
            if (decimalPosition == -1) // Si no hay decimales
            {
                if (int.TryParse(text, out int number) && number > 100)
                {
                    text = "100"; // Limitar a 100 si se excede
                }
            }
            else // Si hay decimales, validar la parte entera
            {
                if (int.TryParse(text.Substring(0, decimalPosition), out int integerPart) && integerPart > 100)
                {
                    text = "100"; // Limitar la parte entera a 100 si se excede
                }
            }

            // Si el valor es 100, eliminar cualquier punto decimal
            if (text == "100" && text.Contains("."))
            {
                text = "100"; // Forzar el valor a 100 sin punto
            }

            // Asignar el texto filtrado al TextBox
            objAddBills.txtDiscount.Text = text;

            // Restablecer la posición del cursor
            objAddBills.txtDiscount.SelectionStart = cursorPosition;
        }




    }
}
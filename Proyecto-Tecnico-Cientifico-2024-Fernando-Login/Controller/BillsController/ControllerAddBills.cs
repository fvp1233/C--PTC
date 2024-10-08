﻿using PTC2024.View.Facturacion;
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
                if (customerId == 1)
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

    }
}
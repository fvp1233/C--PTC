using PTC2024.Controller.Alerts;
using PTC2024.Controller.Helper;
using PTC2024.Controller.Server;
using PTC2024.Controller.StartMenuController;
using PTC2024.Model.DAO.CustomersDAO;
using PTC2024.Model.DAO.HelperDAO;
using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.View.Alerts;
using PTC2024.View.Empleados;
using PTC2024.View.formularios.inicio;
using PTC2024.View.Reporting.Bills;
using PTC2024.View.Reporting.Payrolls;
using PTC2024.View.Server;
using PTC2024.View.Start;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Imaging;
using System.Diagnostics; // Para abrir el PDF después de generarlo
using System.IO;
using PTC2024.Model.DAO.BillsDAO;
using QRCoder;


namespace PTC2024.Controller.EmployeesController
{
    internal class ControllerViewPayrolls
    {
        FrmViewPayrolls objViewPayrolls;
        StartMenu objStartForm;
        public ControllerViewPayrolls(FrmViewPayrolls Vista)
        {
            objViewPayrolls = Vista;
            objViewPayrolls.Load += new EventHandler(InitialCharge);
            objViewPayrolls.btnAll.Click += new EventHandler(SearchAll);
            objViewPayrolls.btnFirstT.Click += new EventHandler(SearchByFirstTrimester);
            objViewPayrolls.btnSecondT.Click += new EventHandler(SearchBySecondTrimester);
            objViewPayrolls.btnThirtht.Click += new EventHandler(SearchByThirthTrimester);
            objViewPayrolls.btnFourth.Click += new EventHandler(SearchByFourthTrimester);
            objViewPayrolls.ch1.Click += new EventHandler(SearchByMonth1);
            objViewPayrolls.ch2.Click += new EventHandler(SearchByMonth2);
            objViewPayrolls.ch3.Click += new EventHandler(SearchByMonth3);
            objViewPayrolls.ch4.Click += new EventHandler(SearchByMonth4);
            objViewPayrolls.ch5.Click += new EventHandler(SearchByMonth5);
            objViewPayrolls.ch6.Click += new EventHandler(SearchByMonth6);
            objViewPayrolls.ch7.Click += new EventHandler(SearchByMonth7);
            objViewPayrolls.ch8.Click += new EventHandler(SearchByMonth8);
            objViewPayrolls.ch9.Click += new EventHandler(SearchByMonth9);
            objViewPayrolls.ch10.Click += new EventHandler(SearchByMonth10);
            objViewPayrolls.ch11.Click += new EventHandler(SearchByMonth11);
            objViewPayrolls.ch12.Click += new EventHandler(SearchByMonth12);
            objViewPayrolls.chPaid.Click += new EventHandler(SearchByPaid);
            objViewPayrolls.chuUnpaid.Click += new EventHandler(SearchByUnpaid);
            objViewPayrolls.chCompensation.Click += new EventHandler(SearchByCompensation);
            objViewPayrolls.btnCreatePayroll.Click += new EventHandler(CreatePayroll);
            objViewPayrolls.btnCompensation.Click += new EventHandler(CreateCompensationPayroll);
            objViewPayrolls.btnActualizarPlanillas.Click += new EventHandler(RefreshData);
            objViewPayrolls.cmsUpdatePayroll.Click += new EventHandler(OpenUpdatePayroll);
            objViewPayrolls.btnDeletePayrolls.Click += new EventHandler(DeletePayrolls);
            objViewPayrolls.dgvPayrolls.Click += new EventHandler(Disable);
            objViewPayrolls.cmsDownloadPDF.Click += new EventHandler(Payroll);
            objViewPayrolls.cmsPayPayroll.Click += new EventHandler(UpdatePayrollPaid);
            objViewPayrolls.cmsUpdateUnpaid.Click += new EventHandler(UpdatePayrollToUnpaid);
            objViewPayrolls.cmsPayrollInformation.Click += new EventHandler(ViewInfoPayroll);
            objViewPayrolls.txtSearch.KeyDown += new KeyEventHandler(SearchPayrollEvent);
            objViewPayrolls.txtSearch.TextChanged += new EventHandler(OnlyLetters);
            objViewPayrolls.btnPayAll.Click += new EventHandler(UpdateXmonth);
            objViewPayrolls.btnRevertPay.Click += new EventHandler(RevertPayXMonth);
        }
        public double TruncateToTwoDecimals(double value)
        {
            return Math.Round(value, 2);
        }

        public void InitialCharge(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.darkMode == true)
            {
                objViewPayrolls.BackColor = Color.FromArgb(18,18,18);
                objViewPayrolls.lblTitle.ForeColor = Color.White;
                objViewPayrolls.lblSubTitle.ForeColor = Color.White;
                objViewPayrolls.lblMonth.ForeColor = Color.White;
                objViewPayrolls.lblMonth1.ForeColor = Color.White;
                objViewPayrolls.lblMonth2.ForeColor = Color.White;
                objViewPayrolls.lblMonth3.ForeColor = Color.White;
                objViewPayrolls.lblMonth4.ForeColor = Color.White;
                objViewPayrolls.lblMonth5.ForeColor = Color.White;
                objViewPayrolls.lblMonth6.ForeColor = Color.White;
                objViewPayrolls.lblMonth7.ForeColor = Color.White;
                objViewPayrolls.lblMonth8.ForeColor = Color.White;
                objViewPayrolls.lblMonth9.ForeColor = Color.White;
                objViewPayrolls.lblMonth10.ForeColor = Color.White;
                objViewPayrolls.lblMonth11.ForeColor = Color.White;
                objViewPayrolls.lblMonth12.ForeColor = Color.White;
                objViewPayrolls.lblPay.ForeColor = Color.White;
                objViewPayrolls.lblUnpaid.ForeColor = Color.White;
                objViewPayrolls.lblCompensation.ForeColor = Color.White;
                //objViewPayrolls.btnAll.OnIdleState.FillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnAll.OnIdleState.BorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnAll.IdleFillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnAll.IdleBorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnFirstT.OnIdleState.FillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnFirstT.OnIdleState.BorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnFirstT.IdleFillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnFirstT.IdleBorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnSecondT.OnIdleState.FillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnSecondT.OnIdleState.BorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnSecondT.IdleFillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnSecondT.IdleBorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnThirtht.OnIdleState.FillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnThirtht.OnIdleState.BorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnThirtht.IdleFillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnThirtht.IdleBorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnFourth.OnIdleState.FillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnFourth.OnIdleState.BorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnFourth.IdleFillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnFourth.IdleBorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnCreatePayroll.OnIdleState.FillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnCreatePayroll.OnIdleState.BorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnCreatePayroll.IdleFillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnCreatePayroll.IdleBorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnActualizarPlanillas.OnIdleState.FillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnActualizarPlanillas.OnIdleState.BorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnActualizarPlanillas.IdleFillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnActualizarPlanillas.IdleBorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnCompensation.OnIdleState.FillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnCompensation.OnIdleState.BorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnCompensation.IdleFillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnCompensation.IdleBorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnDeletePayrolls.OnIdleState.FillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnDeletePayrolls.OnIdleState.BorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnDeletePayrolls.IdleFillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.btnDeletePayrolls.IdleBorderColor = Color.FromArgb(26, 32, 161); 
                //objViewPayrolls.btnPayAll.OnIdleState.FillColor = Color.FromArgb(255, 128, 0);
                //objViewPayrolls.btnPayAll.OnIdleState.BorderColor = Color.FromArgb(255, 128, 0);
                //objViewPayrolls.btnPayAll.IdleFillColor = Color.FromArgb(255, 128, 0);
                //objViewPayrolls.btnPayAll.IdleBorderColor = Color.FromArgb(255, 128, 0);
                //objViewPayrolls.btnRevertPay.OnIdleState.FillColor = Color.FromArgb(255, 128, 0);
                //objViewPayrolls.btnRevertPay.OnIdleState.BorderColor = Color.FromArgb(255, 128, 0);
                //objViewPayrolls.btnRevertPay.IdleFillColor = Color.FromArgb(255, 128, 0);
                //objViewPayrolls.btnRevertPay.IdleBorderColor = Color.FromArgb(255, 128, 0);
                //objViewPayrolls.txtSearch.FillColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.txtSearch.BorderColorActive = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.txtSearch.OnIdleState.BorderColor = Color.FromArgb(26, 32, 161);
                //objViewPayrolls.txtSearch.BorderColorIdle = Color.FromArgb(26, 32, 161);
                objViewPayrolls.dgvPayrolls.BackgroundColor = Color.FromArgb(45, 45, 45);
                objViewPayrolls.dgvPayrolls.HeaderBackColor = Color.LightSlateGray;
                objViewPayrolls.dgvPayrolls.GridColor = Color.FromArgb(45, 45, 45);
                objViewPayrolls.dgvPayrolls.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
                objViewPayrolls.dgvPayrolls.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray;
            }
        }
        public async void CreatePayroll(object sender, EventArgs e)
        {
            ProgressBarForm progressBarForm = new ProgressBarForm();
            progressBarForm.Show();
            ControllerProgressBar objProgress = new ControllerProgressBar(progressBarForm);
            DAOViewPayrolls DAOInsertPayroll = new DAOViewPayrolls();
            DataSet employeeDs = DAOInsertPayroll.GetEmployee();
            DataSet bonusDs = DAOInsertPayroll.GetBonus();
            DataSet userDs = DAOInsertPayroll.GetUsername();
            DataSet payrollDs = DAOInsertPayroll.GetPayroll();
            DataSet businessDs = DAOInsertPayroll.GetBusiness();
            int returnValue = 0;

            if (employeeDs != null && employeeDs.Tables.Count > 0 &&
                bonusDs != null && bonusDs.Tables.Count > 0 &&
                userDs != null && userDs.Tables.Count > 0 && businessDs.Tables.Count > 0)
            {
                DataTable employeeDt = employeeDs.Tables["tbEmployee"];
                DataTable bonusDt = bonusDs.Tables["tbBusinessP"];
                DataTable userDt = userDs.Tables["tbUserData"];
                DataTable payrollDt = payrollDs.Tables["tbPayroll"];
                DataTable businessDT = businessDs.Tables["tbBusinessInfo"];

                int totalEmployees = 1;
                int currentEmployee = 0;

                foreach (DataRow row in employeeDt.Rows)
                {
                    int status = int.Parse(row["IdStatus"].ToString());
                    int idEmployee = int.Parse(row["IdEmployee"].ToString());
                    DateTime hireDate = DateTime.Parse(row["hireDate"].ToString());
                    double salary = double.Parse(row["salary"].ToString());

                    DataRow businessRow = businessDT.Rows[0];
                    DateTime firstUse = DateTime.Parse(businessRow["firstUse"].ToString());
                    int firstUseMonth = firstUse.Month;
                    int firstUseYear = firstUse.Year;

                    // unicamente se le generaran a los empleados activos
                    if (status != 2)
                    {
                        //Aca establecemos la generación de planillas la cual va desde el año de uso hasta el año acutal
                        for (int year = firstUseYear; year <= DateTime.Now.Year; year++)
                        {
                            // Aca definimos el mes inicial de la generación de planillas
                            int startMonth = (year == firstUseYear) ? firstUseMonth : 1; // Inicia en el mes de primero uso unicamente si es el primer año

                            //Si el empleado fue contratado despues del primer uso del sistema, entonces el startMonth sera el mes de la fecha de contratación
                            if (hireDate.Year == year && hireDate.Month > startMonth)
                            {
                                startMonth = hireDate.Month;
                            }

                            // Establecemos la generación de planillas hasta el mes actual
                            int endMonth = (year == DateTime.Now.Year) ? DateTime.Now.Month : 12;

                            for (int month = startMonth; month <= endMonth; month++)
                            {
                                // Verificamos si la planilla ya existe
                                DataRow[] existingPayrollRows = payrollDt.Select($"IdEmployee = {idEmployee} AND IssueDate = '{year}-{month:D2}-01'");
                                if (existingPayrollRows.Length == 0)
                                {

                                    string username = row["username"].ToString();
                                    DataRow[] userRows = userDt.Select($"username = '{username}'");
                                    if (userRows.Length > 0)
                                    {
                                        DataRow userRow = userRows[0];
                                        string businessRole = userRow["IdBusinessP"].ToString();
                                        DataRow[] bonusRows = bonusDt.Select($"IdBusinessP = '{businessRole}'");
                                        if (bonusRows.Length > 0)
                                        {
                                            await Task.Run(() =>
                                            {
                                                DataRow bonusRow = bonusRows[0];
                                                double roleBonus = double.Parse(bonusRow["positionBonus"].ToString());

                                                DateTime currentDate = new DateTime(year, month, 1);
                                                int totalDaysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);

                                                int daysWorked = 0;
                                                int hoursWorked = 0;
                                                if (hireDate.Year == currentDate.Year && hireDate.Month == currentDate.Month)
                                                {
                                                    // Caso de un empleado contratado en el mismo mes que estamos generando la planilla
                                                    daysWorked = totalDaysInMonth - hireDate.Day + 1;
                                                    hoursWorked = daysWorked * 8;
                                                }
                                                else
                                                {
                                                    daysWorked = 30;
                                                    hoursWorked = 240;
                                                }

                                                double daySalary = salary / 30;
                                                double hourSalary = daySalary / 8;
                                                double calculatedSalaryByHours = TruncateToTwoDecimals(hoursWorked * hourSalary);
                                                double calculatedSalary = TruncateToTwoDecimals(calculatedSalaryByHours + roleBonus);

                                                DAOInsertPayroll = new DAOViewPayrolls
                                                {
                                                    BusinessBonus = float.Parse(roleBonus.ToString()),
                                                    ChristmasBonus = 0,
                                                    Username = row["username"].ToString(),
                                                    Isss = GetISSS(calculatedSalary),
                                                    Afp = GetAFP(calculatedSalary),
                                                    Rent = GetRent(calculatedSalary),
                                                    NetPay = GetNetSalary(calculatedSalary),
                                                    IsssEmployer = GetISSSEmployeer(calculatedSalary),
                                                    AfpEmployer = GetAFPEmployer(calculatedSalary),
                                                    DiscountEmployee = GetEmployeeDiscount(calculatedSalary),
                                                    DiscountEmployer = GetEmployerDiscount(calculatedSalary),
                                                    IssueDate = new DateTime(year, month, 1),
                                                    IdEmployee = idEmployee,
                                                    IdPayrollStatus = 2,
                                                    DaysWorked = daysWorked,
                                                    DaySalary = TruncateToTwoDecimals(daySalary),
                                                    GossSalary = TruncateToTwoDecimals(calculatedSalary),
                                                    HoursWorked = hoursWorked,
                                                    HourSalary = TruncateToTwoDecimals(hourSalary),
                                                    ExtraHours = 0
                                                };

                                                if (month == 12)
                                                {
                                                    double christmasBonus = GetChristmasBonus(salary, hireDate, year);
                                                    if (christmasBonus > 1500)
                                                    {
                                                        christmasBonus = GetChristmasBonusRent(christmasBonus);
                                                        DAOInsertPayroll.ChristmasBonus = christmasBonus;
                                                    }
                                                    else
                                                    {
                                                        DAOInsertPayroll.ChristmasBonus = christmasBonus;
                                                    }
                                                }
                                                returnValue = DAOInsertPayroll.AddPayroll();
                                                currentEmployee++;
                                                int progress = (currentEmployee * 100) / totalEmployees;
                                                objProgress.UpdateProgress(progress, $"Procesando planillas {currentEmployee} de {totalEmployees}");
                                                if (returnValue == 1)
                                                {
                                                    totalEmployees++;
                                                }
                                            });
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                RefreshData();
            }
            progressBarForm.Close();

            if (returnValue == 1)
            {
                int idPayroll = DAOInsertPayroll.GetLastInsertedPayrollId(); 

                // Generar el PDF con el ID de la factura
                string pdfFilePath = GeneratePayrollPDF(idPayroll);

                // Enviar el PDF por correo si la ruta del archivo es válida
                if (!string.IsNullOrEmpty(pdfFilePath))
                {
                    bool emailSent = SendEmail(pdfFilePath);

                    if (!emailSent)
                    {
                        objStartForm.snackBar.Show(objStartForm, $"La planilla fue generada pero no se pudo enviar por correo.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                    }
                }
                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStartForm = objStart;
                objStartForm.snackBar.Show(objStartForm, $"Los datos fueron insertados exitosamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
            }
            else
            {
                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStartForm = objStart;
                objStartForm.snackBar.Show(objStartForm, $"No hay empleados a los cuales generar planillas", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
            }
        }

        // Método para generar el PDF de una factura
        public string GeneratePayrollPDF(int idPayroll)
        {
            try
            {
                DAOViewPayrolls dAOViewPayrolls = new DAOViewPayrolls();
                DataSet dsPayroll = dAOViewPayrolls.GetPayrollDetails(idPayroll);

                if (dsPayroll != null && dsPayroll.Tables["viewPayrolls"].Rows.Count > 0)
                {
                    DataRow payrollrow = dsPayroll.Tables["viewPayrolls"].Rows[0];

                    // Obtener un directorio temporal para almacenar el PDF
                    string tempFilePath = Path.Combine(Path.GetTempPath(), $"Payroll_{idPayroll}.pdf");

                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(tempFilePath, FileMode.Create));
                    doc.Open();

                    // Fuentes para los textos
                    var titleFont = iTextSharp.text.FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD, BaseColor.RED);
                    var regularFont = iTextSharp.text.FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                    var boldFont = iTextSharp.text.FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                    // Título del documento
                    doc.Add(new Paragraph("Planilla", titleFont));
                    doc.Add(new Paragraph(" "));

                    // Datos principales
                    doc.Add(new Paragraph($"Número de planilla: {payrollrow["N°"]}", boldFont));
                    doc.Add(new Paragraph($"DUI del Empleado: {payrollrow["DUI"]}", regularFont));
                    doc.Add(new Paragraph($"Empledo: {payrollrow["Empleado"]}", regularFont));
                    doc.Add(new Paragraph($"Salario: {payrollrow["Salario"]}", regularFont));
                    doc.Add(new Paragraph($"Bono: {payrollrow["Bono"]}", regularFont));
                    doc.Add(new Paragraph($"Salario Bruto: {payrollrow["Salario bruto"]}", regularFont));
                    doc.Add(new Paragraph($"Cargo: {payrollrow["Cargo"]}", regularFont));
                    doc.Add(new Paragraph($"Cuenta Bancaria: {payrollrow["Cuenta bancaria"]}", regularFont));
                    doc.Add(new Paragraph(" "));

                    // Detalles de descuentos y pago
                    doc.Add(new Paragraph("Detalles de pago:", boldFont));
                    doc.Add(new Paragraph($"N° de afiliación: {payrollrow["N° de afiliación"]}", regularFont));
                    doc.Add(new Paragraph($"AFP: {payrollrow["AFP"]}%", regularFont));
                    doc.Add(new Paragraph($"ISSS: ${payrollrow["ISSS"]}", regularFont));
                    doc.Add(new Paragraph($"Renta: ${payrollrow["Renta"]}", regularFont));
                    doc.Add(new Paragraph($"Salario Neto: {payrollrow["Salario Neto"]}", regularFont));
                    doc.Add(new Paragraph(" "));

                    // Fechas y dias trabajados
                    doc.Add(new Paragraph($"Fecha de Emisión: {payrollrow["Fecha de emisión"]}", regularFont));
                    doc.Add(new Paragraph($"Estado: {payrollrow["Estado"]}", regularFont));
                    doc.Add(new Paragraph($"Aguinaldo: {payrollrow["Aguinaldo"]}", regularFont));
                    doc.Add(new Paragraph($"Dias trabajados: {payrollrow["Dias trabajados"]}", regularFont));
                    doc.Add(new Paragraph($"Salario por día: {payrollrow["Salario por día"]}", regularFont));
                    doc.Add(new Paragraph($"Horas trabajadas: {payrollrow["Horas trabajadas"]}", regularFont));
                    doc.Add(new Paragraph($"Salario por hora: {payrollrow["Salario por hora"]}", regularFont));
                    doc.Add(new Paragraph(" "));

                    // Horas extra y estado
                    doc.Add(new Paragraph($"Horas extra: {payrollrow["Horas extra"]}", regularFont));


                    // Generar el código QR basado en los datos de la factura
                    string qrData = $"Planilla N°: {payrollrow["N°"]}\n" +
                                    $"Empleado: {payrollrow["Empleado"]}\n" +
                                    $"Salario: {payrollrow["Salario"]}\n" +
                                    $"Bono: ${payrollrow["Bono"]}\n" +
                                    $"Fecha de Emisión: {payrollrow["Fecha de emisión"]}";

                    using (MemoryStream msQrCode = new MemoryStream())
                    {
                        // Generar el código QR usando QRCoder
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);

                        using (Bitmap qrCodeImage = qrCode.GetGraphic(20)) // Ajusta la escala del código QR aquí
                        {
                            // Guardar el código QR como imagen en memoria
                            qrCodeImage.Save(msQrCode, ImageFormat.Png);
                        }

                        // Convertir el stream en una imagen que iTextSharp pueda usar
                        iTextSharp.text.Image qrImage = iTextSharp.text.Image.GetInstance(msQrCode.ToArray());
                        qrImage.ScaleToFit(100f, 100f); // Ajusta el tamaño del QR según sea necesario
                        qrImage.Alignment = Element.ALIGN_RIGHT;

                        // Añadir el código QR al PDF
                        doc.Add(qrImage);
                    }

                    // Cerrar el documento PDF
                    doc.Close();
                    // Enviar el PDF por correo
                    bool emailSent = SendEmail(tempFilePath);

                    if (!emailSent)
                    {
                        MessageBox.Show("La planilla fue generada pero no se pudo enviar por correo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Planilla generada y enviada por correo exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //// Abrir el PDF en el navegador predeterminado o visor de PDF
                    //Process.Start(new ProcessStartInfo(tempFilePath)
                    //{
                    //    UseShellExecute = true // Esto asegurará que se abra con el programa predeterminado del sistema
                    //});
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para la planilla seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            
            string de = "h2c.soporte.usuarios@gmail.com";
            string subject = "H2C: Gracias por visitarnos.";
            string message = $"Hola usuario se adjunta los datos de tu planilla de pago {BusinessVar.BusinessName}.\nEn caso de tener algun problema, favor enviarla en este mismo correo.";

            Email email = new Email();
            bool answer = email.SendEmailWithAttachment(de, subject, message, pdfFilePath);

            return answer;
        }


        public async void UpdateXmonth(object sender, EventArgs e)
        {
            // Verificar si el día es = 30
            DateTime actualDate = DateTime.Now;
            if (actualDate.Day != 30)
            {
                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStart.snackBar.Show(objStart, "Este proceso solo se puede ejecutar el día 30 del mes", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
                return; // Nos salimos del método si el día es diferente de 30
            }

            // Continuar con el proceso si es el día 30
            ProgressBarForm progressBarForm = new ProgressBarForm();
            progressBarForm.Show();
            ControllerProgressBar objProgress = new ControllerProgressBar(progressBarForm);
            DAOViewPayrolls DAOUpdatePayroll = new DAOViewPayrolls();
            StartMenu objStartMenu = new StartMenu(SessionVar.Username);

            // Verificar si hay planillas no pagadas en meses anteriores
            DateTime lastDayOfPreviousMonth = new DateTime(actualDate.Year, actualDate.Month, 1).AddDays(-1);
            DataSet previousUnpaidPayrolls = DAOUpdatePayroll.GetPreviousUnpaidPayrolls(lastDayOfPreviousMonth);

            if (previousUnpaidPayrolls != null && previousUnpaidPayrolls.Tables[0].Rows.Count > 0)
            {
                objStartMenu.snackBar.Show(objStartMenu, "No se puede pagar las planillas de este mes. Existen planillas no pagadas en meses anteriores.",
                    Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
                progressBarForm.Close();
                return; // Salir si hay planillas no pagadas
            }

            DataSet employeeDs = DAOUpdatePayroll.GetEmployee();
            DataSet payrollDs = DAOUpdatePayroll.GetPayroll();

            DateTime actualMonth = DateTime.Now;
            int year = actualMonth.Year;
            int month = actualMonth.Month;

            if (employeeDs != null && payrollDs != null)
            {
                DataTable payrollDt = payrollDs.Tables["tbPayroll"];
                int totalRowsAffected = 0;
                int totalPayrolls = payrollDt.Rows.Count;
                int currentPayroll = 0;

                foreach (DataRow dr in payrollDt.Rows)
                {
                    DateTime issueDate = DateTime.Parse(dr["issueDate"].ToString());
                    int idPayrollStatus = int.Parse(dr["IdPayrollStatus"].ToString());

                    if (issueDate.Year == year && issueDate.Month == month && idPayrollStatus != 1)
                    {
                        await Task.Run(() =>
                        {
                            DAOUpdatePayroll.IdPayroll = int.Parse(dr["IdPayroll"].ToString());
                            DAOUpdatePayroll.IdPayrollStatus = 1;

                            totalRowsAffected += DAOUpdatePayroll.UpdatePayrollStatusPaid();
                            //Posible mencion del metodo para enviar planillla alcorreo
                            if (totalRowsAffected > 0)
                            {
                                DAOInitialView daoInitial = new DAOInitialView();
                                daoInitial.ActionType = "Se pagó una planilla";
                                daoInitial.TableName = "Planillas";
                                daoInitial.ActionBy = SessionVar.Username;
                                daoInitial.ActionDate = DateTime.Now;
                                int auditAnswer = daoInitial.InsertAudit();

                                if (auditAnswer != 1)
                                {
                                    objStartMenu.snackBar.Show(objStartMenu, "La auditoría no pudo ser registrada", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                                }
                            }
                            currentPayroll++;
                            int progress = (currentPayroll * 100) / totalPayrolls;
                            objProgress.UpdateProgress(progress, $"Pagando planillas {currentPayroll} de {totalPayrolls}");
                        });
                    }
                }

                progressBarForm.Close();
                if (totalRowsAffected > 0)
                {
                    objStartMenu.snackBar.Show(objStartMenu, "Se pagaron todas las planillas del mes exitosamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                }
                else
                {
                    objStartMenu.snackBar.Show(objStartMenu, "No se encontraron planillas pendientes para pagar", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                }
            }
        }

        public async void RevertPayXMonth(object sender, EventArgs e)
        {
            ProgressBarForm progressBarForm = new ProgressBarForm();
            progressBarForm.Show();
            ControllerProgressBar objProgress = new ControllerProgressBar(progressBarForm);
            DAOViewPayrolls DAOUpdatePayroll = new DAOViewPayrolls();
            StartMenu objStart = new StartMenu(SessionVar.Username);


            DataSet employeeDs = DAOUpdatePayroll.GetEmployee();
            DataSet payrollDs = DAOUpdatePayroll.GetPayroll();
            DateTime actualMonth = DateTime.Now;
            int year = actualMonth.Year;
            int month = actualMonth.Month;
            if (employeeDs != null && payrollDs != null)
            {
                DataTable payrollDt = payrollDs.Tables["tbPayroll"];
                int totalRowsAffected = 0;
                int totalPayrolls = payrollDt.Rows.Count;
                int currentPayroll = 0;

                foreach (DataRow dr in payrollDt.Rows)
                {
                    DateTime issueDate = DateTime.Parse(dr["issueDate"].ToString());
                    int idPayrollStatus = int.Parse(dr["IdPayrollStatus"].ToString());

                    if (issueDate.Year == year && issueDate.Month == month && idPayrollStatus != 2)
                    {
                        await Task.Run(() =>
                        {
                            DAOUpdatePayroll.IdPayroll = int.Parse(dr["IdPayroll"].ToString());
                            DAOUpdatePayroll.IdPayrollStatus = 2;

                            totalRowsAffected += DAOUpdatePayroll.UpdatePayrollStatusUnPaid();
                            if (totalRowsAffected > 0)
                            {
                                DAOInitialView daoInitial = new DAOInitialView();
                                daoInitial.ActionType = "Se revirtio el pago de una planilla";
                                daoInitial.TableName = "Planillas";
                                daoInitial.ActionBy = SessionVar.Username;
                                daoInitial.ActionDate = DateTime.Now;
                                int auditAnswer = daoInitial.InsertAudit();

                                if (auditAnswer != 1)
                                {
                                    objStart.snackBar.Show(objStart, $"La auditoría no pudo ser registrada",
                                        Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                                }
                            }
                            currentPayroll++;
                            int progress = (currentPayroll * 100) / totalPayrolls;
                            objProgress.UpdateProgress(progress, $"Revirtiendo planillas {currentPayroll} de {totalPayrolls}");
                        });
                    }
                }

                progressBarForm.Close();

                if (totalRowsAffected > 0)
                {
                    objStart.snackBar.Show(objStart, $"Se revirtieron las planillas del mes exitosamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                }
                else
                {
                    objStart.snackBar.Show(objStart, $"No se encontraron planillas pagadas para revertir", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Information, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                }
            }
        }
        public async void RefreshData(object sender, EventArgs e)
        {
            ProgressBarForm progressBarForm = new ProgressBarForm();
            progressBarForm.Show();
            ControllerProgressBar objProgress = new ControllerProgressBar(progressBarForm);

            DAOViewPayrolls DAOUpdatePayroll = new DAOViewPayrolls();
            DataSet employeeDs = DAOUpdatePayroll.GetEmployee();
            DataSet bonusDs = DAOUpdatePayroll.GetBonus();
            DataSet userDs = DAOUpdatePayroll.GetUsername();
            DataSet payrollDs = DAOUpdatePayroll.GetPayroll();
            DataSet unpaidPayrollsDs = DAOUpdatePayroll.GetUnpaidPayrolls();
            int totalRowsAffected = 0;

            if (employeeDs != null && payrollDs != null && bonusDs != null && userDs != null)
            {
                DataTable employeeDt = employeeDs.Tables["tbEmployee"];
                DataTable payrollDt = payrollDs.Tables["tbPayroll"];
                DataTable bonusDt = bonusDs.Tables["tbBusinessP"];
                DataTable userDt = userDs.Tables["tbUserData"];
                DataTable unpaidDt = unpaidPayrollsDs.Tables["tbPayroll"];
                int totalEmployees = unpaidDt.Rows.Count;
                int currentEmployee = 0;

                foreach (DataRow row in employeeDt.Rows)
                {
                    int status = int.Parse(row["IdStatus"].ToString());
                    int idEmployee = int.Parse(row["IdEmployee"].ToString());
                    DateTime hireDate = DateTime.Parse(row["hireDate"].ToString());
                    double salary = double.Parse(row["salary"].ToString());

                    if (status != 2)
                    {
                        DataRow[] unpaidPayrolls = payrollDt.Select($"IdEmployee = {idEmployee} AND IdPayrollStatus = 2");
                        foreach (DataRow payrollRow in unpaidPayrolls)
                        {
                            await Task.Run(() =>
                            {
                                int idPayroll = int.Parse(payrollRow["IdPayroll"].ToString());
                                DateTime issueDate = DateTime.Parse(payrollRow["issueDate"].ToString());
                                int daysWorked = int.Parse(payrollRow["daysWorked"].ToString());

                                // Recuperar daySalary y hourSalary de la base de datos
                                double daySalary = salary / 30; // Consistencia en el cálculo
                                double hourSalary = daySalary / 8; // Consistencia en el cálculo
                                int hoursWorked = int.Parse(payrollRow["hoursWorked"].ToString());
                                int extraHours = int.Parse(payrollRow["extraHours"].ToString());

                                // Bonus del rol de negocio
                                double roleBonus = 0;
                                DataRow[] userRows = userDt.Select($"username = '{row["username"]}'");
                                if (userRows.Length > 0)
                                {
                                    DataRow userRow = userRows[0];
                                    string businessRole = userRow["IdBusinessP"].ToString();
                                    DataRow[] bonusRows = bonusDt.Select($"IdBusinessP = '{businessRole}'");
                                    if (bonusRows.Length > 0)
                                    {
                                        DataRow bonusRow = bonusRows[0];
                                        roleBonus = double.Parse(bonusRow["positionBonus"].ToString());
                                    }
                                }
                                double calculatedSalaryByHours;
                                double calculatedSalary;
                                if (hoursWorked == 0)
                                {
                                    calculatedSalary = 0;
                                }
                                else
                                {
                                    // Calculando el salario bruto y neto con los valores recuperados
                                    calculatedSalaryByHours = (hoursWorked + extraHours) * hourSalary;
                                    calculatedSalary = TruncateToTwoDecimals(calculatedSalaryByHours + roleBonus);
                                }

                                // Aplicar los descuentos igual que en CreatePayroll
                                double rent = GetRent(calculatedSalary);
                                double isss = GetISSS(calculatedSalary);
                                double afp = GetAFP(calculatedSalary);
                                double christmasBonus = 0;

                                if (issueDate.Month == 12)
                                {
                                    christmasBonus = TruncateToTwoDecimals(GetChristmasBonus(salary, hireDate, issueDate.Year));
                                    if (christmasBonus > 1500)
                                    {
                                        christmasBonus = TruncateToTwoDecimals(GetChristmasBonusRent(christmasBonus));
                                    }
                                }

                                double netPay = TruncateToTwoDecimals(calculatedSalary - isss - afp - rent);

                                // Asignar los valores actualizados en el DAO para la actualización
                                DAOUpdatePayroll.IdPayroll = idPayroll;
                                DAOUpdatePayroll.NetPay = netPay;
                                DAOUpdatePayroll.Rent = rent;
                                DAOUpdatePayroll.Afp = afp;
                                DAOUpdatePayroll.Isss = isss;
                                DAOUpdatePayroll.IsssEmployer = TruncateToTwoDecimals(GetISSSEmployeer(calculatedSalary));
                                DAOUpdatePayroll.AfpEmployer = TruncateToTwoDecimals(GetAFPEmployer(calculatedSalary));
                                DAOUpdatePayroll.DiscountEmployee = TruncateToTwoDecimals(GetEmployeeDiscount(calculatedSalary));
                                DAOUpdatePayroll.DiscountEmployer = TruncateToTwoDecimals(GetEmployerDiscount(calculatedSalary));
                                DAOUpdatePayroll.ChristmasBonus = christmasBonus;
                                DAOUpdatePayroll.DaySalary = daySalary;
                                DAOUpdatePayroll.DaysWorked = daysWorked;
                                DAOUpdatePayroll.HourSalary = hourSalary;
                                DAOUpdatePayroll.GossSalary = calculatedSalary;
                                DAOUpdatePayroll.HoursWorked = hoursWorked;
                                DAOUpdatePayroll.ExtraHours = extraHours;
                                DAOUpdatePayroll.IdPayrollStatus = 2;

                                // Actualizar en la base de datos
                                totalRowsAffected += DAOUpdatePayroll.UpdatePayroll();
                                currentEmployee++;
                                int progress = (currentEmployee * 100) / totalEmployees;
                                objProgress.UpdateProgress(progress, $"Procesando planillas {currentEmployee} de {totalEmployees}");
                            });
                        }
                    }
                }
                RefreshData();
            }
            progressBarForm.Close();

            if (totalRowsAffected > 0)
            {
                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStartForm = objStart;
                objStartForm.snackBar.Show(objStartForm, $"Los datos fueron fueron refrescados exitosamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);

            }
            else
            {
                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStartForm = objStart;
                objStartForm.snackBar.Show(objStartForm, $"Los datos no pudieron ser refrescados", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);

            }
        }
        public async void CreateCompensationPayroll(object sender, EventArgs e)
        {
            ProgressBarForm progressBarForm = new ProgressBarForm();
            progressBarForm.Show();
            ControllerProgressBar objProgress = new ControllerProgressBar(progressBarForm);

            int totalEmployees = 1;
            int currentEmployee = 0;
            // Creamos un objeto del DaoViewPayrolls
            DAOViewPayrolls DAOInsertPayroll = new DAOViewPayrolls();
            // Accedemos a los datos de los empleados
            DAOInsertPayroll.GetEmployee();
            // Se crean los dataSets
            DataSet employeeDs = DAOInsertPayroll.GetEmployee();
            DataSet payrollDs = DAOInsertPayroll.GetPayroll();
            int returnValue = 0;

            // Se crea la condición en la cual establecemos que los data set no estén vacios
            if (employeeDs != null && employeeDs.Tables.Count > 0 &&
                payrollDs != null && payrollDs.Tables.Count > 0)
            {
                // Creamos los dataTable
                DataTable employeeDt = employeeDs.Tables["tbEmployee"];
                DataTable payrollDt = payrollDs.Tables["tbPayroll"];

                // Verificamos que los dataTable no estén vacíos
                if (employeeDt != null && payrollDt != null)
                {
                    // Iteramos a través de todas las filas de la tabla employee
                    foreach (DataRow row in employeeDt.Rows)
                    {
                        // Verificar el estado del empleado
                        int status = int.Parse(row["IdStatus"].ToString());
                        int idEmployee = int.Parse(row["IdEmployee"].ToString());
                        DateTime hireDate = DateTime.Parse(row["hireDate"].ToString());
                        double salary = double.Parse(row["salary"].ToString());
                        DateTime now = DateTime.Now;
                        // Generacion de planillas para empleados inactivos
                        int totalMonthsWorked = ((now.Year - hireDate.Year) * 12) + now.Month - hireDate.Month;
                        double monthlyCompensation = salary / 12;
                        double compensation = 0.0;

                        if (status == 2)
                        {
                            if (totalMonthsWorked > 12)
                            {
                                // Caso de empleados que han trabajado un año o más
                                double totalYearsWorked = now.Year - hireDate.Year;
                                compensation = salary * totalYearsWorked;
                            }
                            else
                            {
                                // Caso de empleados que se van antes de un año
                                compensation = monthlyCompensation * totalMonthsWorked;
                            }

                            // Comprobar si ya existe una planilla de liquidación para el empleado
                            DataRow[] existingCompensationPayroll = payrollDt.Select($"IdEmployee = {idEmployee} AND IdPayrollStatus = 3");
                            if (existingCompensationPayroll.Length == 0)
                            {
                                await Task.Run(() =>
                                {
                                    // Calcular la renta aplicable a la indemnización (si corresponde)
                                    double netPay = compensation;

                                    // Crear y llenar un nuevo objeto DAOViewPayrolls para la planilla de liquidación
                                    DAOInsertPayroll = new DAOViewPayrolls
                                    {
                                        //En las liquidaciones se tienen que tener ciertos parámetros
                                        Username = row["username"].ToString(),
                                        Isss = 0.00,
                                        Afp = 0.00,
                                        Rent = 0.00,
                                        NetPay = netPay,
                                        IsssEmployer = 0.00,
                                        AfpEmployer = 0.00,
                                        DiscountEmployee = 0.00,
                                        DiscountEmployer = 0.00,
                                        IssueDate = DateTime.Now,
                                        IdEmployee = idEmployee,
                                        IdPayrollStatus = 3,
                                        ChristmasBonus = 0.00
                                    };
                                    returnValue = DAOInsertPayroll.AddPayroll();
                                    currentEmployee++;
                                    int progress = (currentEmployee * 100) / totalEmployees;
                                    objProgress.UpdateProgress(progress, $"Procesando planillas {currentEmployee} de {totalEmployees}");
                                    totalEmployees++;
                                });
                            }
                        }
                    }
                    RefreshData();
                }
                progressBarForm.Close();

                if (returnValue == 1)
                {
                    StartMenu objStart = new StartMenu(SessionVar.Username);
                    objStartForm = objStart;
                    objStartForm.snackBar.Show(objStartForm, $"Las planillas de liquidacion fueron registradas exitosamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);

                }
                else
                {
                    StartMenu objStart = new StartMenu(SessionVar.Username);
                    objStartForm = objStart;
                    objStartForm.snackBar.Show(objStartForm, $"No hay empleados a los cuales registrar planillas de liquidación", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);

                }
            }
        }


        public void UpdatePayrollPaid(object sender, EventArgs e)
        {
            DAOViewPayrolls daoUpdate = new DAOViewPayrolls();
            int pos = objViewPayrolls.dgvPayrolls.CurrentRow.Index;
            daoUpdate.IdPayroll = int.Parse(objViewPayrolls.dgvPayrolls[0, pos].Value.ToString());
            DateTime issueDate = DateTime.Parse(objViewPayrolls.dgvPayrolls[13, pos].Value.ToString());
            int monthPayroll = issueDate.Month;

            DateTime selectedPayrollIssueDate = DateTime.Parse(objViewPayrolls.dgvPayrolls[13, pos].Value.ToString());

            DataSet previousUnpaidPayrolls = daoUpdate.GetPreviousUnpaidPayrolls(selectedPayrollIssueDate);
            if (previousUnpaidPayrolls != null && previousUnpaidPayrolls.Tables[0].Rows.Count > 0)
            {
                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStartForm = objStart;
                objStartForm.snackBar.Show(objStartForm, $"No se puede pagar esta planilla. Existen planillas no pagadas en meses anteriores.",
                    Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
                return;
            }
            int currentMonth = DateTime.Now.Month;
            if (monthPayroll != currentMonth)
            {
                FrmConfirmPayment objForm = new FrmConfirmPayment();
                ControllerConfirmPayment objController = new ControllerConfirmPayment(objForm);
                objForm.ShowDialog();
                if (objController.ConfirmValue == 1)
                {
                    daoUpdate.IdPayrollStatus = 1;
                    int returnedValues = daoUpdate.UpdatePayrollStatusPaid();

                    if (returnedValues >= 1)
                    {
                        StartMenu objStart = new StartMenu(SessionVar.Username);
                        objStartForm = objStart;
                        objStartForm.snackBar.Show(objStartForm, $"La planilla fue pagada exitosamente",
                            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);

                        DAOInitialView daoInitial = new DAOInitialView();
                        daoInitial.ActionType = "Se pagó una planilla";
                        daoInitial.TableName = "Planillas";
                        daoInitial.ActionBy = SessionVar.Username;
                        daoInitial.ActionDate = DateTime.Now;
                        int auditAnswer = daoInitial.InsertAudit();

                        if (auditAnswer != 1)
                        {
                            objStart.snackBar.Show(objStart, $"La auditoría no pudo ser registrada",
                                Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                        }
                    }
                    else
                    {
                        StartMenu objStart = new StartMenu(SessionVar.Username);
                        objStartForm = objStart;
                        objStartForm.snackBar.Show(objStartForm, $"La planilla no pudo ser pagada",
                            Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
                    }
                }
                else
                {
                    StartMenu objStart = new StartMenu(SessionVar.Username);
                    objStartForm = objStart;
                    objStartForm.snackBar.Show(objStartForm, $"Se necesita la contraseña del CEO para realizar este proceso",
                        Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
                }
            }
            else
            {
                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStartForm = objStart;
                objStartForm.snackBar.Show(objStartForm, $"Las planillas de este mes unicamente pueden ser pagadas el día 30",
                    Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
            }
            RefreshData();

        }

        public void UpdatePayrollToUnpaid(object sender, EventArgs e)
        {
            DAOViewPayrolls daoUpdate = new DAOViewPayrolls();
            int pos = objViewPayrolls.dgvPayrolls.CurrentRow.Index;
            daoUpdate.IdPayroll = int.Parse(objViewPayrolls.dgvPayrolls[0, pos].Value.ToString());

            // Obtener la fecha de emisión de la planilla
            DateTime issueDate = DateTime.Parse(objViewPayrolls.dgvPayrolls[13, pos].Value.ToString());
            int monthPayroll = issueDate.Month;
            // Validar si la planilla corresponde al mes anterior o anterior a ese
            DateTime currentDate = DateTime.Now;
            DateTime previousMonth = currentDate.AddMonths(-1);

            FrmConfirmPayment objConfirmPayment = new FrmConfirmPayment();
            ControllerConfirmPayment objController = new ControllerConfirmPayment(objConfirmPayment);
            objConfirmPayment.ShowDialog();
            if (objController.ConfirmValue == 1)
            {
                daoUpdate.IdPayrollStatus = 2;
                int returnedValues = daoUpdate.UpdatePayrollStatusUnPaid();
                if (returnedValues >= 1)
                {
                    StartMenu objStart = new StartMenu(SessionVar.Username);
                    objStartForm = objStart;
                    objStartForm.snackBar.Show(objStartForm, $"El pago fue revertido exitosamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);

                    // Registrar la auditoría
                    DAOInitialView daoInitial = new DAOInitialView();
                    daoInitial.ActionType = "Se revirtió un pago";
                    daoInitial.TableName = "Planillas";
                    daoInitial.ActionBy = SessionVar.Username;
                    daoInitial.ActionDate = DateTime.Now;
                    int auditAnswer = daoInitial.InsertAudit();
                    if (auditAnswer != 1)
                    {
                        objStart.snackBar.Show(objStart, $"La auditoría no pudo ser registrada", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                    }
                }
                else
                {
                    StartMenu objStart = new StartMenu(SessionVar.Username);
                    objStartForm = objStart;
                    objStartForm.snackBar.Show(objStartForm, $"El pago no pudo ser revertido", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
                }
            }
            else
            {
                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStartForm = objStart;
                objStartForm.snackBar.Show(objStartForm, $"Se necesita la contraseña del CEO para realizar este proceso",
                    Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
            }
            RefreshData();
        }

        public async void DeletePayrolls(object sender, EventArgs e)
        {
            ProgressBarForm progressBarForm = new ProgressBarForm();
            progressBarForm.Show();
            ControllerProgressBar objProgress = new ControllerProgressBar(progressBarForm);

            int totalEmployees = 1;
            int currentEmployee = 0;
            // Creamos un objeto del DaoViewPayrolls
            DAOViewPayrolls DAOInsertPayroll = new DAOViewPayrolls();
            // Accedemos a los datos de los empleados y planillas
            DataSet employeeDs = DAOInsertPayroll.GetEmployee();
            DataSet payrollDs = DAOInsertPayroll.GetPayroll();
            int returnValue = 0;
            DataTable employeeDt = employeeDs.Tables["tbEmployee"];
            DataTable payrollDt = payrollDs.Tables["tbPayroll"];

            foreach (DataRow row in employeeDt.Rows)
            {
                // Verificar el estado del empleado (inactivo en este caso)
                int employeeStatus = int.Parse(row["IdStatus"].ToString());
                if (employeeStatus == 2)
                {
                    int idEmployee = int.Parse(row["IdEmployee"].ToString());
                    // Seleccionar todas las planillas no
                    // s de este empleado
                    DataRow[] unpaidPayrolls = payrollDt.Select($"IdEmployee = {idEmployee} AND IdPayrollStatus = 2");

                    // Eliminar cada planilla no pagada encontrada
                    foreach (DataRow payrollRow in unpaidPayrolls)
                    {
                        await Task.Run(() =>
                        {
                            int idPayroll = int.Parse(payrollRow["IdPayroll"].ToString());
                            // Asignar el ID de la planilla a eliminar
                            DAOInsertPayroll.IdPayroll = idPayroll;
                            // Eliminar la planilla
                            returnValue = DAOInsertPayroll.DeletePayroll();
                            currentEmployee++;
                            int progress = (currentEmployee * 100) / totalEmployees;
                            objProgress.UpdateProgress(progress, $"Procesando planillas {currentEmployee} de {totalEmployees}");
                            totalEmployees++;
                        });

                    }
                }
            }
            // Refrescar los datos después de la eliminación
            RefreshData();
            progressBarForm.Close();
            if (returnValue == 1)
            {
                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStartForm = objStart;
                objStartForm.snackBar.Show(objStartForm, $"Las planillas fueron eliminadas exitosamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);

            }
            else
            {
                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStartForm = objStart;
                objStartForm.snackBar.Show(objStartForm, $"No hay empleados a los cuales eliminar las planillas", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);

            }
        }
        #region Aca estan los metodos $$$$$$
        //--------------------------METODOS $$$$$$$---------------------------//

        //Metodo para obtener el AFP el cual es igual al 7.5% del salario
        public double GetAFP(double Salary)
        {
            double AFP = Salary * 0.0725;
            return AFP;
        }
        //Metodo para obtener el ISS el cual es igual al 3% del salario co un techo de $1000
        public double GetISSS(double Salary)
        {
            double ISS;
            if (Salary >= 1000)
            {
                ISS = 1000 * 0.03;
            }
            else
            {
                ISS = Salary * 0.03;
            }
            return ISS;
        }
        public double GetAFPEmployer(double Salary)
        {
            double AFP = Salary * 0.0875;
            return AFP;
        }
        public double GetISSSEmployeer(double Salary)
        {
            double ISSS = Salary * 0.075; ;
            return ISSS;
        }
        //Metodo para obtener la renta la cual es igual a 0 si la persona gana $472 del salario
        //Metodo para obtener la renta la cual es igual al 10% del salario + $17.67 si la persona arriba de $472 hasta $895.24
        //Metodo para obtener la renta la cual es igual al 20% del salario + $60 si la persona arriba de $895.24 hasta $2028.11
        //Metodo para obtener la renta la cual es igual al 30% del salario + $288.57 si la persona arriba de $2028.11
        public double GetRent(double Salary)
        {
            double rent;
            double AFP_ISSS = GetAFP(Salary) + GetISSS(Salary);
            double prerent = Salary - AFP_ISSS;
            if (prerent >= 0 && prerent < 472.01)
            {
                rent = 0;
            }
            else if (prerent > 472.01 && prerent <= 895.24)
            {
                rent = ((prerent - 472) * 0.1) + 17.67;
            }
            else if (prerent > 895.24 && prerent <= 2038.11)
            {
                rent = ((prerent - 895.24) * 0.2) + 60;
            }
            else
            {
                rent = ((prerent - 2038.10) * 0.3) + 288.57;
            }
            double retencion = rent;
            return retencion;
        }
        public double GetChristmasBonusRent(double Salary)
        {
            double rent;
            if (Salary > 1500 && Salary < 2038.11)
            {
                rent = ((Salary - 895.24) * 0.2) + 60;
            }
            else if (Salary > 2028.11)
            {
                rent = ((Salary - 2038.10) * 0.3) + 288.57;
            }
            else
            {
                rent = 0;
            }
            double retencion = rent;
            return retencion;
        }
        //Metodo para obtener el salario neto
        public double GetNetSalary(double Salary)
        {
            double netSalary = Salary - (GetISSS(Salary) + GetAFP(Salary) + GetRent(Salary));
            return netSalary;
        }
        public double GetEmployeeDiscount(double Salary)
        {
            double employeeDiscount = Salary - GetNetSalary(Salary);
            return employeeDiscount;
        }
        public double GetEmployerDiscount(double Salary)
        {
            double employerDiscount = GetAFPEmployer(Salary) + GetISSS(Salary) + GetRent(Salary);
            return employerDiscount;
        }
        public double GetChristmasBonus(double salary, DateTime hireDate, int year)
        {
            // Determinar el tiempo trabajado hasta el 15 de diciembre del año específico
            DateTime endDate = new DateTime(year, 12, 12);
            if (hireDate > endDate)
            {
                // Si la fecha de contratación es después del 15 de diciembre, el aguinaldo es 0
                return 0;
            }
            int workedYears = year - hireDate.Year;
            double christmasBonus;

            if (workedYears >= 1 && workedYears < 3)
            {
                christmasBonus = (salary / 30) * 15;
            }
            else if (workedYears >= 3 && workedYears < 10)
            {
                christmasBonus = (salary / 30) * 19;
            }
            else if (workedYears >= 10)
            {
                christmasBonus = (salary / 30) * 21;
            }
            else
            {
                TimeSpan workedDays = endDate - hireDate;
                double dailyPayment = (salary / 2) / 365;
                christmasBonus = dailyPayment * workedDays.Days;
            }

            return christmasBonus;
        }
        #endregion
        //------------------Busqueda----------------------//
        public void SearchPayrollEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchPayroll();

            }
        }
        void SearchPayroll()
        {
            DAOViewPayrolls objAdmin = new DAOViewPayrolls();
            objViewPayrolls.dgvPayrolls.Enabled = true;
            DataSet ds = objAdmin.SearchPayroll(objViewPayrolls.txtSearch.Text.Trim());
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
        }
        public void LoadData(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            DAOViewPayrolls objRefresh = new DAOViewPayrolls();
            DataSet ds = objRefresh.GetEmployeesDgv();
            objViewPayrolls.dgvPayrolls.Enabled = true;
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            objViewPayrolls.dgvPayrolls.Columns[7].Visible = false;
            objViewPayrolls.dgvPayrolls.Columns[8].Visible = false;

        }
        public void Disable(object sender, EventArgs e)
        {
            DAOViewPayrolls objDisable = new DAOViewPayrolls();
            int pos = objViewPayrolls.dgvPayrolls.CurrentRow.Index;
            if (objViewPayrolls.dgvPayrolls[14, pos].Value.ToString() == "Pagada" /*&& objDisable.StatusPayroll == 1*/)
            {
                objViewPayrolls.cmsUpdateUnpaid.Visible = true;
                objViewPayrolls.cmsPayPayroll.Visible = false;
                objViewPayrolls.cmsUpdatePayroll.Visible = false;
            }
            else
            {
                objViewPayrolls.cmsUpdateUnpaid.Visible = false;
                objViewPayrolls.cmsPayPayroll.Visible = true;
                objViewPayrolls.cmsUpdatePayroll.Visible = true;

            }
        }
        public void Payroll(object sender, EventArgs e)
        {
            // Método que se encarga de manejar el evento Click del botón cmsPrintBill
            if (objViewPayrolls.dgvPayrolls.CurrentRow != null)
            {
                // Capturar el IdBill de la factura seleccionada en el DataGridView
                int idPayroll = Convert.ToInt32(objViewPayrolls.dgvPayrolls.CurrentRow.Cells["N°"].Value);

                // Generar el PDF de la factura con el IdBill seleccionado
                GeneratePPDF(idPayroll);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una factura para imprimir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // Método para generar el PDF de una factura
        public void GeneratePPDF(int idPayroll)
        {
            try
            {
                DAOViewPayrolls dAOViewPayrolls = new DAOViewPayrolls();
                DataSet dsPayroll = dAOViewPayrolls.GetPayrollDetails(idPayroll);

                if (dsPayroll != null && dsPayroll.Tables["viewPayrolls"].Rows.Count > 0)
                {
                    DataRow payrollrow = dsPayroll.Tables["viewPayrolls"].Rows[0];

                    // Directorio temporal para almacenar el PDF
                    string tempFilePath = Path.Combine(Path.GetTempPath(), $"Payroll_{idPayroll}.pdf");

                    Document doc = new Document(PageSize.A4, 36, 36, 36, 36);
                    PdfWriter.GetInstance(doc, new FileStream(tempFilePath, FileMode.Create));
                    doc.Open();

                    // Establecer fuentes y colores
                    var titleFont = iTextSharp.text.FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD, BaseColor.RED);
                    var regularFont = iTextSharp.text.FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                    var boldFont = iTextSharp.text.FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                    // Agregar logo de la empresa 
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("C:\\Users\\jenni\\Documents\\GitHub\\C--PTC\\Proyecto-Tecnico-Cientifico-2024-Fernando-Login\\Resources\\H2C_HR negro.png");
                    logo.ScaleToFit(100f, 100f);
                    logo.Alignment = Element.ALIGN_LEFT;
                    doc.Add(logo);

                    // Título del documento
                    doc.Add(new Paragraph("Planilla de Pago", titleFont));
                    doc.Add(new Paragraph(" ")); // Espacio

                    // Crear tabla para la información del empleado
                    PdfPTable employeeTable = new PdfPTable(2);
                    employeeTable.WidthPercentage = 100;
                    employeeTable.AddCell(new PdfPCell(new Phrase("Número de Planilla", boldFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    employeeTable.AddCell(new PdfPCell(new Phrase(payrollrow["N°"].ToString(), regularFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    employeeTable.AddCell(new PdfPCell(new Phrase("Empleado", boldFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    employeeTable.AddCell(new PdfPCell(new Phrase(payrollrow["Empleado"].ToString(), regularFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    employeeTable.AddCell(new PdfPCell(new Phrase("Salario Bruto", boldFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    employeeTable.AddCell(new PdfPCell(new Phrase($"${payrollrow["Salario bruto"]}", regularFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    employeeTable.AddCell(new PdfPCell(new Phrase("Cargo", boldFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    employeeTable.AddCell(new PdfPCell(new Phrase(payrollrow["Cargo"].ToString(), regularFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    doc.Add(employeeTable);
                    doc.Add(new Paragraph(" ")); // Espacio

                    // Agregar sección de descuentos
                    PdfPTable discountTable = new PdfPTable(2);
                    discountTable.WidthPercentage = 100;
                    discountTable.AddCell(new PdfPCell(new Phrase("Detalles de Pago", titleFont)) { Colspan = 2, Border = iTextSharp.text.Rectangle.NO_BORDER });
                    discountTable.AddCell(new PdfPCell(new Phrase("AFP", boldFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    discountTable.AddCell(new PdfPCell(new Phrase($"{payrollrow["AFP"]}%")) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    discountTable.AddCell(new PdfPCell(new Phrase("ISSS", boldFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    discountTable.AddCell(new PdfPCell(new Phrase($"${payrollrow["ISSS"]}")) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    discountTable.AddCell(new PdfPCell(new Phrase("Renta", boldFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    discountTable.AddCell(new PdfPCell(new Phrase($"${payrollrow["Renta"]}")) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    discountTable.AddCell(new PdfPCell(new Phrase("Salario Neto", boldFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    discountTable.AddCell(new PdfPCell(new Phrase($"${payrollrow["Salario Neto"]}")) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    doc.Add(discountTable);
                    doc.Add(new Paragraph(" ")); // Espacio

                    // Agregar sección de fechas
                    doc.Add(new Paragraph($"Fecha de Emisión: {payrollrow["Fecha de emisión"]}", regularFont));
                    doc.Add(new Paragraph($"Estado: {payrollrow["Estado"]}", regularFont));
                    doc.Add(new Paragraph($"Aguinaldo: {payrollrow["Aguinaldo"]}", regularFont));
                    doc.Add(new Paragraph($"Dias trabajados: {payrollrow["Dias trabajados"]}", regularFont));

                    // Agregar el código QR
                    string qrData = $"Planilla N°: {payrollrow["N°"]}\nEmpleado: {payrollrow["Empleado"]}\nSalario Neto: {payrollrow["Salario Neto"]}";
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
                    Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para la planilla seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message);
            }
        }


        //----------------------Metodos de interaccion con otros formularios---------------------------//
        public void OpenUpdatePayroll(object sender, EventArgs e)
        {
            int pos = objViewPayrolls.dgvPayrolls.CurrentRow.Index;
            int nP, daysWorked, hoursWorked, extraHours;
            string employee, dui, possition, bankAccount, affiliationNumber;
            double salary, bonus, afp, isss, rent, discountEmployee, netSalary, daySalary, grossPay, hourSalary;
            DateTime issueDate;
            nP = int.Parse(objViewPayrolls.dgvPayrolls[0, pos].Value.ToString());
            dui = objViewPayrolls.dgvPayrolls[1, pos].Value.ToString();
            employee = objViewPayrolls.dgvPayrolls[2, pos].Value.ToString();
            salary = double.Parse(objViewPayrolls.dgvPayrolls[3, pos].Value.ToString());
            bonus = double.Parse(objViewPayrolls.dgvPayrolls[4, pos].Value.ToString());
            grossPay = double.Parse(objViewPayrolls.dgvPayrolls[5, pos].Value.ToString());
            possition = objViewPayrolls.dgvPayrolls[6, pos].Value.ToString();
            bankAccount = objViewPayrolls.dgvPayrolls[7, pos].Value.ToString();
            affiliationNumber = objViewPayrolls.dgvPayrolls[8, pos].Value.ToString();
            afp = double.Parse(objViewPayrolls.dgvPayrolls[9, pos].Value.ToString());
            isss = double.Parse(objViewPayrolls.dgvPayrolls[10, pos].Value.ToString());
            rent = double.Parse(objViewPayrolls.dgvPayrolls[11, pos].Value.ToString());
            netSalary = double.Parse(objViewPayrolls.dgvPayrolls[12, pos].Value.ToString());
            discountEmployee = isss + afp + rent;
            issueDate = DateTime.Parse(objViewPayrolls.dgvPayrolls[13, pos].Value.ToString());
            daysWorked = int.Parse(objViewPayrolls.dgvPayrolls[16, pos].Value.ToString());
            daySalary = double.Parse(objViewPayrolls.dgvPayrolls[17, pos].Value.ToString());
            hoursWorked = int.Parse(objViewPayrolls.dgvPayrolls[18, pos].Value.ToString());
            hourSalary = double.Parse(objViewPayrolls.dgvPayrolls[19, pos].Value.ToString());
            extraHours = int.Parse(objViewPayrolls.dgvPayrolls[20, pos].Value.ToString());
            FrmUpdatePayroll openForm = new FrmUpdatePayroll(nP, dui, employee, salary, possition, bonus, bankAccount, affiliationNumber, afp, isss, rent, netSalary, discountEmployee, issueDate, daysWorked, daySalary, grossPay, hoursWorked, hourSalary, extraHours);
            openForm.ShowDialog();
            RefreshData();
        }

        private void ViewInfoPayroll(object sender, EventArgs e)
        {
            int pos = objViewPayrolls.dgvPayrolls.CurrentRow.Index;
            int daysWorked;
            string employee, dui, possition, bankAccount, payrollStatus, affiliationNumber;
            double salary, bonus, afp, isss, rent, discountEmployee, netSalary, issEmployer, afpEmployer, discountEmployer, christmasBonus, grossPay, daySalary;
            DateTime issueDate;
            dui = objViewPayrolls.dgvPayrolls[1, pos].Value.ToString();
            employee = objViewPayrolls.dgvPayrolls[2, pos].Value.ToString();
            salary = double.Parse(objViewPayrolls.dgvPayrolls[3, pos].Value.ToString());
            bonus = double.Parse(objViewPayrolls.dgvPayrolls[4, pos].Value.ToString());
            grossPay = double.Parse(objViewPayrolls.dgvPayrolls[5, pos].Value.ToString());
            possition = objViewPayrolls.dgvPayrolls[6, pos].Value.ToString();
            bankAccount = objViewPayrolls.dgvPayrolls[7, pos].Value.ToString();
            affiliationNumber = objViewPayrolls.dgvPayrolls[8, pos].Value.ToString();
            afp = double.Parse(objViewPayrolls.dgvPayrolls[9, pos].Value.ToString());
            isss = double.Parse(objViewPayrolls.dgvPayrolls[10, pos].Value.ToString());
            rent = double.Parse(objViewPayrolls.dgvPayrolls[11, pos].Value.ToString());
            netSalary = double.Parse(objViewPayrolls.dgvPayrolls[12, pos].Value.ToString());
            discountEmployee = isss + afp + rent;
            double calculatedSalary = bonus + salary;
            issueDate = DateTime.Parse(objViewPayrolls.dgvPayrolls[13, pos].Value.ToString());
            issEmployer = GetISSSEmployeer(calculatedSalary);
            afpEmployer = GetAFPEmployer(calculatedSalary);
            discountEmployer = issEmployer + afpEmployer;
            payrollStatus = objViewPayrolls.dgvPayrolls[14, pos].Value.ToString();
            christmasBonus = double.Parse(objViewPayrolls.dgvPayrolls[15, pos].Value.ToString());
            daysWorked = int.Parse(objViewPayrolls.dgvPayrolls[16, pos].Value.ToString());
            daySalary = double.Parse(objViewPayrolls.dgvPayrolls[17, pos].Value.ToString());
            FrmInfoPayroll openForm = new FrmInfoPayroll(dui, employee, possition, bonus, bankAccount, affiliationNumber, salary, grossPay, afp, isss, rent, netSalary, discountEmployee, issueDate, christmasBonus, issEmployer, afpEmployer, discountEmployer, payrollStatus, daysWorked, daySalary);
            openForm.ShowDialog();
            RefreshData();
        }
        #region Aca estan los metodos para los checkbox
        public void SearchAll(object sender, EventArgs e)
        {
            objViewPayrolls.dgvPayrolls.Enabled = true;
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.GetEmployeesDgv();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
        }
        public void SearchByFirstTrimester(object sender, EventArgs e)
        {
            objViewPayrolls.dgvPayrolls.Enabled = true;

            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SerachPayrollFirstTrimester();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
        }
        public void SearchBySecondTrimester(object sender, EventArgs e)
        {
            objViewPayrolls.dgvPayrolls.Enabled = true;

            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SerachPayrollSecondTrimester();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
        }
        public void SearchByThirthTrimester(object sender, EventArgs e)
        {
            objViewPayrolls.dgvPayrolls.Enabled = true;

            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SerachPayrollThirthTrimester();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
        }
        public void SearchByFourthTrimester(object sender, EventArgs e)
        {
            objViewPayrolls.dgvPayrolls.Enabled = true;

            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SerachPayrollFourthTrimester();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
        }
        public void SearchByMonth1(object sender, EventArgs e)
        {

            if (objViewPayrolls.ch1.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearchPayrollJanuary();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch2.Checked = false;
                objViewPayrolls.ch3.Checked = false;
                objViewPayrolls.ch4.Checked = false;
                objViewPayrolls.ch5.Checked = false;
                objViewPayrolls.ch6.Checked = false;
                objViewPayrolls.ch7.Checked = false;
                objViewPayrolls.ch8.Checked = false;
                objViewPayrolls.ch9.Checked = false;
                objViewPayrolls.ch10.Checked = false;
                objViewPayrolls.ch11.Checked = false;
                objViewPayrolls.ch12.Checked = false;
                objViewPayrolls.chPaid.Checked = false;
                objViewPayrolls.chuUnpaid.Checked = false;
                objViewPayrolls.chCompensation.Checked = false;
            }
        }
        public void SearchByMonth2(object sender, EventArgs e)
        {
            if (objViewPayrolls.ch2.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearchPayrollFebruary();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch1.Checked = false;
                objViewPayrolls.ch3.Checked = false;
                objViewPayrolls.ch4.Checked = false;
                objViewPayrolls.ch5.Checked = false;
                objViewPayrolls.ch6.Checked = false;
                objViewPayrolls.ch7.Checked = false;
                objViewPayrolls.ch8.Checked = false;
                objViewPayrolls.ch9.Checked = false;
                objViewPayrolls.ch10.Checked = false;
                objViewPayrolls.ch11.Checked = false;
                objViewPayrolls.ch12.Checked = false;
                objViewPayrolls.chPaid.Checked = false;
                objViewPayrolls.chuUnpaid.Checked = false;
                objViewPayrolls.chCompensation.Checked = false;
            }
        }
        public void SearchByMonth3(object sender, EventArgs e)
        {

            if (objViewPayrolls.ch3.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearchPayrollMarch();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch2.Checked = false;
                objViewPayrolls.ch1.Checked = false;
                objViewPayrolls.ch4.Checked = false;
                objViewPayrolls.ch5.Checked = false;
                objViewPayrolls.ch6.Checked = false;
                objViewPayrolls.ch7.Checked = false;
                objViewPayrolls.ch8.Checked = false;
                objViewPayrolls.ch9.Checked = false;
                objViewPayrolls.ch10.Checked = false;
                objViewPayrolls.ch11.Checked = false;
                objViewPayrolls.ch12.Checked = false;
                objViewPayrolls.chPaid.Checked = false;
                objViewPayrolls.chuUnpaid.Checked = false;
                objViewPayrolls.chCompensation.Checked = false;
            }
        }
        public void SearchByMonth4(object sender, EventArgs e)
        {
            if (objViewPayrolls.ch4.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearchPayrollApril();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch2.Checked = false;
                objViewPayrolls.ch1.Checked = false;
                objViewPayrolls.ch3.Checked = false;
                objViewPayrolls.ch5.Checked = false;
                objViewPayrolls.ch6.Checked = false;
                objViewPayrolls.ch7.Checked = false;
                objViewPayrolls.ch8.Checked = false;
                objViewPayrolls.ch9.Checked = false;
                objViewPayrolls.ch10.Checked = false;
                objViewPayrolls.ch11.Checked = false;
                objViewPayrolls.ch12.Checked = false;
                objViewPayrolls.chPaid.Checked = false;
                objViewPayrolls.chuUnpaid.Checked = false;
                objViewPayrolls.chCompensation.Checked = false;
            }
        }
        public void SearchByMonth5(object sender, EventArgs e)
        {
            if (objViewPayrolls.ch5.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearchPayrollMay();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch2.Checked = false;
                objViewPayrolls.ch1.Checked = false;
                objViewPayrolls.ch3.Checked = false;
                objViewPayrolls.ch4.Checked = false;
                objViewPayrolls.ch6.Checked = false;
                objViewPayrolls.ch7.Checked = false;
                objViewPayrolls.ch8.Checked = false;
                objViewPayrolls.ch9.Checked = false;
                objViewPayrolls.ch10.Checked = false;
                objViewPayrolls.ch11.Checked = false;
                objViewPayrolls.ch12.Checked = false;
                objViewPayrolls.chPaid.Checked = false;
                objViewPayrolls.chuUnpaid.Checked = false;
                objViewPayrolls.chCompensation.Checked = false;
            }
        }
        public void SearchByMonth6(object sender, EventArgs e)
        {
            if (objViewPayrolls.ch6.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearchPayrollJune();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch2.Checked = false;
                objViewPayrolls.ch1.Checked = false;
                objViewPayrolls.ch3.Checked = false;
                objViewPayrolls.ch4.Checked = false;
                objViewPayrolls.ch5.Checked = false;
                objViewPayrolls.ch7.Checked = false;
                objViewPayrolls.ch8.Checked = false;
                objViewPayrolls.ch9.Checked = false;
                objViewPayrolls.ch10.Checked = false;
                objViewPayrolls.ch11.Checked = false;
                objViewPayrolls.ch12.Checked = false;
                objViewPayrolls.chPaid.Checked = false;
                objViewPayrolls.chuUnpaid.Checked = false;
                objViewPayrolls.chCompensation.Checked = false;
            }
        }
        public void SearchByMonth7(object sender, EventArgs e)
        {
            if (objViewPayrolls.ch7.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearchPayrollJuly();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch2.Checked = false;
                objViewPayrolls.ch1.Checked = false;
                objViewPayrolls.ch3.Checked = false;
                objViewPayrolls.ch4.Checked = false;
                objViewPayrolls.ch6.Checked = false;
                objViewPayrolls.ch5.Checked = false;
                objViewPayrolls.ch8.Checked = false;
                objViewPayrolls.ch9.Checked = false;
                objViewPayrolls.ch10.Checked = false;
                objViewPayrolls.ch11.Checked = false;
                objViewPayrolls.ch12.Checked = false;
                objViewPayrolls.chPaid.Checked = false;
                objViewPayrolls.chuUnpaid.Checked = false;
                objViewPayrolls.chCompensation.Checked = false;
            }
        }
        public void SearchByMonth8(object sender, EventArgs e)
        {
            if (objViewPayrolls.ch8.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearchPayrollAgust();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch2.Checked = false;
                objViewPayrolls.ch1.Checked = false;
                objViewPayrolls.ch3.Checked = false;
                objViewPayrolls.ch4.Checked = false;
                objViewPayrolls.ch6.Checked = false;
                objViewPayrolls.ch7.Checked = false;
                objViewPayrolls.ch5.Checked = false;
                objViewPayrolls.ch9.Checked = false;
                objViewPayrolls.ch10.Checked = false;
                objViewPayrolls.ch11.Checked = false;
                objViewPayrolls.ch12.Checked = false;
                objViewPayrolls.chPaid.Checked = false;
                objViewPayrolls.chuUnpaid.Checked = false;
                objViewPayrolls.chCompensation.Checked = false;
            }
        }
        public void SearchByMonth9(object sender, EventArgs e)
        {
            if (objViewPayrolls.ch9.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearchPayrollSeptember();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch2.Checked = false;
                objViewPayrolls.ch1.Checked = false;
                objViewPayrolls.ch3.Checked = false;
                objViewPayrolls.ch4.Checked = false;
                objViewPayrolls.ch6.Checked = false;
                objViewPayrolls.ch7.Checked = false;
                objViewPayrolls.ch5.Checked = false;
                objViewPayrolls.ch8.Checked = false;
                objViewPayrolls.ch10.Checked = false;
                objViewPayrolls.ch11.Checked = false;
                objViewPayrolls.ch12.Checked = false;
                objViewPayrolls.chPaid.Checked = false;
                objViewPayrolls.chuUnpaid.Checked = false;
                objViewPayrolls.chCompensation.Checked = false;
            }
        }
        public void SearchByMonth10(object sender, EventArgs e)
        {
            if (objViewPayrolls.ch10.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearchPayrollOctober();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch2.Checked = false;
                objViewPayrolls.ch1.Checked = false;
                objViewPayrolls.ch3.Checked = false;
                objViewPayrolls.ch4.Checked = false;
                objViewPayrolls.ch6.Checked = false;
                objViewPayrolls.ch7.Checked = false;
                objViewPayrolls.ch5.Checked = false;
                objViewPayrolls.ch9.Checked = false;
                objViewPayrolls.ch8.Checked = false;
                objViewPayrolls.ch11.Checked = false;
                objViewPayrolls.ch12.Checked = false;
                objViewPayrolls.chPaid.Checked = false;
                objViewPayrolls.chuUnpaid.Checked = false;
                objViewPayrolls.chCompensation.Checked = false;
            }
        }
        public void SearchByMonth11(object sender, EventArgs e)
        {
            if (objViewPayrolls.ch11.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearchPayrollNovember();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch2.Checked = false;
                objViewPayrolls.ch1.Checked = false;
                objViewPayrolls.ch3.Checked = false;
                objViewPayrolls.ch4.Checked = false;
                objViewPayrolls.ch6.Checked = false;
                objViewPayrolls.ch7.Checked = false;
                objViewPayrolls.ch5.Checked = false;
                objViewPayrolls.ch9.Checked = false;
                objViewPayrolls.ch8.Checked = false;
                objViewPayrolls.ch10.Checked = false;
                objViewPayrolls.ch12.Checked = false;
                objViewPayrolls.chPaid.Checked = false;
                objViewPayrolls.chuUnpaid.Checked = false;
                objViewPayrolls.chCompensation.Checked = false;
            }
        }
        public void SearchByMonth12(object sender, EventArgs e)
        {
            if (objViewPayrolls.ch12.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearchPayrollDecember();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch2.Checked = false;
                objViewPayrolls.ch1.Checked = false;
                objViewPayrolls.ch3.Checked = false;
                objViewPayrolls.ch4.Checked = false;
                objViewPayrolls.ch6.Checked = false;
                objViewPayrolls.ch7.Checked = false;
                objViewPayrolls.ch5.Checked = false;
                objViewPayrolls.ch9.Checked = false;
                objViewPayrolls.ch8.Checked = false;
                objViewPayrolls.ch10.Checked = false;
                objViewPayrolls.ch11.Checked = false;
                objViewPayrolls.chPaid.Checked = false;
                objViewPayrolls.chuUnpaid.Checked = false;
                objViewPayrolls.chCompensation.Checked = false;
            }
        }
        public void SearchByPaid(object sender, EventArgs e)
        {

            if (objViewPayrolls.chPaid.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearchPaidPayrols();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch2.Checked = false;
                objViewPayrolls.ch12.Checked = false;
                objViewPayrolls.ch1.Checked = false;
                objViewPayrolls.ch3.Checked = false;
                objViewPayrolls.ch4.Checked = false;
                objViewPayrolls.ch6.Checked = false;
                objViewPayrolls.ch7.Checked = false;
                objViewPayrolls.ch5.Checked = false;
                objViewPayrolls.ch9.Checked = false;
                objViewPayrolls.ch8.Checked = false;
                objViewPayrolls.ch10.Checked = false;
                objViewPayrolls.ch11.Checked = false;
                objViewPayrolls.chuUnpaid.Checked = false;
                objViewPayrolls.chCompensation.Checked = false;
            }
        }
        public void SearchByUnpaid(object sender, EventArgs e)
        {

            if (objViewPayrolls.chuUnpaid.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearchUnpaidPayrols();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch2.Checked = false;
                objViewPayrolls.ch12.Checked = false;
                objViewPayrolls.ch1.Checked = false;
                objViewPayrolls.ch3.Checked = false;
                objViewPayrolls.ch4.Checked = false;
                objViewPayrolls.ch6.Checked = false;
                objViewPayrolls.ch7.Checked = false;
                objViewPayrolls.ch5.Checked = false;
                objViewPayrolls.ch9.Checked = false;
                objViewPayrolls.ch8.Checked = false;
                objViewPayrolls.ch10.Checked = false;
                objViewPayrolls.ch11.Checked = false;
                objViewPayrolls.chPaid.Checked = false;
                objViewPayrolls.chCompensation.Checked = false;
            }
        }
        public void SearchByCompensation(object sender, EventArgs e)
        {
            if (objViewPayrolls.chCompensation.Checked == true)
            {
                objViewPayrolls.dgvPayrolls.Enabled = true;

                DAOViewPayrolls objSearch = new DAOViewPayrolls();
                DataSet ds = objSearch.SearcCompensationPayrols();
                objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
                objViewPayrolls.ch2.Checked = false;
                objViewPayrolls.ch12.Checked = false;
                objViewPayrolls.ch1.Checked = false;
                objViewPayrolls.ch3.Checked = false;
                objViewPayrolls.ch4.Checked = false;
                objViewPayrolls.ch6.Checked = false;
                objViewPayrolls.ch7.Checked = false;
                objViewPayrolls.ch5.Checked = false;
                objViewPayrolls.ch9.Checked = false;
                objViewPayrolls.ch8.Checked = false;
                objViewPayrolls.ch10.Checked = false;
                objViewPayrolls.ch11.Checked = false;
                objViewPayrolls.chPaid.Checked = false;
                objViewPayrolls.chuUnpaid.Checked = false;
            }
        }
        #endregion
        public void OnlyLetters(object sender, EventArgs e)
        {
            // Obtener la posición actual del cursor
            int cursorPosition = objViewPayrolls.txtSearch.SelectionStart;

            // Filtrar el texto para que solo queden letras y espacios
            string text = new string(objViewPayrolls.txtSearch.Text
                                       .Where(c => char.IsLetter(c) || char.IsWhiteSpace(c))
                                       .ToArray());

            // Actualizar el contenido del TextBox con el texto filtrado
            objViewPayrolls.txtSearch.Text = text;

            // Restaurar la posición del cursor
            objViewPayrolls.txtSearch.SelectionStart = cursorPosition;
        }
    }
}

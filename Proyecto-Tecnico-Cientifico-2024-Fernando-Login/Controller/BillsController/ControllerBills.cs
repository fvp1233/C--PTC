using PTC2024.View.Facturacion;
using System;
using System.Text;
using PTC2024.Model.DAO.BillsDAO;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace PTC2024.Controller.BillsController
{
    internal class ControllerBills
    {
        FrmBills objFormBills;
        public ControllerBills(FrmBills View)
        {
            objFormBills = View;
            objFormBills.Load += new EventHandler(LoadDataBills);
            objFormBills.btnNewBills.Click += new EventHandler(AddBills);
            objFormBills.cmsPrintBill.Click += new EventHandler(printBills);
            objFormBills.cmsRectifyBill.Click += new EventHandler(RectifyBills);
           // objFormBills.cmsOverrideBill.Click += new EventHandler(OverrideBills);
            objFormBills.txtSearchB.Click += new EventHandler(SearchBills);
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

            // DataSet ds = objBills.Bills();
            //objFormBills.dgvBills.DataSource = ds.Tables["viewBills"];
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
            string companyName, serviceName, statusBill, customer, employee, methodP;
            DateTime startDate, FinalDate, Dateissued;
            float discount, subtotalPay, totalPay;
            id = int.Parse(objFormBills.dgvBills[0, row].Value.ToString());
            companyName = objFormBills.dgvBills[1, row].Value.ToString();
            NIT = objFormBills.dgvBills[2, row].Value.ToString();
            NRC = objFormBills.dgvBills[3, row].Value.ToString();
            customer = objFormBills.dgvBills[3, row].Value.ToString();
            serviceName = objFormBills.dgvBills[4, row].Value.ToString();
            discount = float.Parse(objFormBills.dgvBills[6, row].Value.ToString());
            subtotalPay = float.Parse(objFormBills.dgvBills[7, row].Value.ToString());
            totalPay = float.Parse(objFormBills.dgvBills[8, row].Value.ToString());
            methodP = objFormBills.dgvBills[9, row].Value.ToString();
            startDate = DateTime.Parse(objFormBills.dgvBills[10, row].Value.ToString());
            FinalDate = DateTime.Parse(objFormBills.dgvBills[11, row].Value.ToString());
            employee = objFormBills.dgvBills[12, row].Value.ToString();
            statusBill = objFormBills.dgvBills[13, row].Value.ToString();
            Dateissued = DateTime.Parse(objFormBills.dgvBills[14, row].Value.ToString());

            FrmAddBills rectifyBill = new FrmAddBills(2, id, companyName, NIT, NRC, customer, serviceName, discount, subtotalPay, totalPay, methodP, startDate, FinalDate, Dateissued, employee, statusBill);

            rectifyBill.ShowDialog();
            ChargeData();

        }
        public class CommonClasses
        {
            public string ComputeSha256Hash(string rawData)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                    StringBuilder builder = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        builder.Append(b.ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }
        /*
        public void OverrideBills(object sender, EventArgs e)
        {
            int row = objFormBills.dgvBills.CurrentRow.Index;
            int idBill = int.Parse(objFormBills.dgvBills[0, row].Value.ToString());

            if (MessageBox.Show($"¿Está seguro de que desea anular la factura con ID: {idBill}?\nEsta acción no se puede deshacer.",
                "Confirmar anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var frmOverrideBill = new FrmOverrideBill())
                {
                    if (frmOverrideBill.ShowDialog() == DialogResult.OK)
                    {
                        // Obtén la contraseña ingresada por el usuario
                        string enteredPassword = frmOverrideBill.EnteredPassword;

                        // Obtén el hash de la contraseña ingresada
                        CommonClasses commonClasses = new CommonClasses();
                        string enteredPasswordHash = commonClasses.ComputeSha256Hash(enteredPassword);

                        // Supongamos que el hash de la contraseña de administrador almacenada se recupera de alguna fuente segura
                        string storedAdminPasswordHash = GetStoredAdminPasswordHash(); // Implementa este método para obtener el hash almacenado

                        if (enteredPasswordHash == storedAdminPasswordHash)
                        {
                            // Si los hashes coinciden, la contraseña es correcta
                            DAOBills daoDel = new DAOBills();
                            if (daoDel.OverBill(idBill))
                            {
                                MessageBox.Show("Factura anulada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ChargeData();
                            }
                            else
                            {
                                MessageBox.Show("Ocurrió un error al intentar anular la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            // Si los hashes no coinciden, la contraseña es incorrecta
                            MessageBox.Show("Contraseña de administrador incorrecta. No se pudo anular la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        */
        private string GetStoredAdminPasswordHash()
        {
           
            return "x" ; 
        }


        public void SearchBills(object sender, EventArgs e)
        {
            DAOBills dAOBills = new DAOBills();
            /*Aca se le da valor al atributo de la clase*/
            dAOBills.Search = objFormBills.txtSearchB.Text;

            /*Se captura la respuesta de l metodo SearchData y se le agrega su respectivo parametro*/
            DataSet ans = dAOBills.SearchDataB(dAOBills.Search);
            /*Se le dice al DataGridView lo que tiene que mostrar*/
            objFormBills.dgvBills.DataSource = ans.Tables["ViewBills"];
        }
    }
}
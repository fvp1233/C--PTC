using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.View.EmployeeViews;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.PayrollsController
{
    internal class ControllerAddPermission
    {
        FrmAddPermission objAddPermission;
        public ControllerAddPermission(FrmAddPermission View)
        {
            objAddPermission = View;
            objAddPermission.Load += new EventHandler(FillDropdown);
            objAddPermission.btnAddPermission.Click += new EventHandler(AddPermission);
            objAddPermission.btnCancel.Click += new EventHandler(CloseForm);
        }
        public void FillDropdown(object sender, EventArgs e)
        {
            DAOAddPermission daoddPermission = new DAOAddPermission();

            DataSet dsTypePermission = daoddPermission.GetTypePermission();
            objAddPermission.cmbTypePermission.DataSource = dsTypePermission.Tables["tbTypePermission"];
            objAddPermission.cmbTypePermission.DisplayMember = "typePermisiion";
            objAddPermission.cmbTypePermission.ValueMember = "IdTypePermission"; 

            DataSet dsStatusPermission = daoddPermission.GetStatusPermission();
            objAddPermission.cmbStatusPermission.DataSource = dsStatusPermission.Tables["tbStatusPermission"];
            objAddPermission.cmbStatusPermission.DisplayMember = "statusPermission";
            objAddPermission.cmbStatusPermission.ValueMember = "IdStatusPermission";
        }  
        public void AddPermission(object sender, EventArgs e)
        {
            DAOAddPermission DaoInsert = new DAOAddPermission();
            DaoInsert.Start = objAddPermission.dtpStart.Value.Date;
            DaoInsert.End = objAddPermission.dtpEnd.Value.Date;
            DaoInsert.Context = objAddPermission.rtxtContext.Text.Trim();
            DaoInsert.IdEmployee = int.Parse(objAddPermission.txtIdEmployee.Text.Trim());
            DaoInsert.IdStatusPermission = int.Parse(objAddPermission.cmbStatusPermission.SelectedValue.ToString());
            DaoInsert.IdTypePermission = int.Parse(objAddPermission.cmbTypePermission.SelectedValue.ToString());
            int returnedValue = DaoInsert.InsertPermission();
            if (returnedValue == 1)
            {
                MessageBox.Show("Los datos han sido registrados exitosamente",
            "Proceso completado",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser registrados",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            Close();
        }
        public void Close()
        {
            objAddPermission.Close();

        }
        public void CloseForm(object sender, EventArgs e)
        {
            Close()
;       }
    }
}

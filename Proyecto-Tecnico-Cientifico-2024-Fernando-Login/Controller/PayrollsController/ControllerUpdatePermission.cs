using PTC2024.View.EmployeeViews;
using PTC2024.View.Service_inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.PayrollsController
{
    internal class ControllerUpdatePermission
    {
        FrmUpdatePermission objUpdatePermission;
        public ControllerUpdatePermission(FrmUpdatePermission View, int idEmployee, int idPermission, DateTime start, DateTime end, string context, string status, string typeP)
        {
            objUpdatePermission = View;
            DisableComponents();
            ChargeValues(idEmployee,idPermission, start, end, context, status, typeP);
        }
        public void ChargeValues(int idEmployee, int idPermission, DateTime start, DateTime end, string context, string status, string typeP)
        {
            try
            {
                objUpdatePermission.txtIdEmployee.Text = idEmployee.ToString();
                objUpdatePermission.txtIdPermission.Text = idPermission.ToString();
                objUpdatePermission.dtpStart.Value = start;
                objUpdatePermission.dtpEnd.Value = end;
                objUpdatePermission.rtxtContext.Text = context.ToString();
                objUpdatePermission.cmbStatusPermission.Text = status.ToString();
                objUpdatePermission.cmbTypePermission.Text = typeP.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DisableComponents()
        {
            objUpdatePermission.txtIdPermission.Visible = false;
        }
    }
}

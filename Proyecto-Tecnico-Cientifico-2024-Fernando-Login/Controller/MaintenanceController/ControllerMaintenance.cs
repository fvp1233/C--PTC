using PTC2024.View.Alerts;
using PTC2024.View.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.MaintenanceController
{
    internal class ControllerMaintenance
    {
        FrmMaintenance objMaintenance;
        public ControllerMaintenance(FrmMaintenance View)
        {
            objMaintenance = View;
            objMaintenance.panelDepartments.Click += new EventHandler(OpenDepartments);
            objMaintenance.panelCharge.Click += new EventHandler(OpenCharge);
            objMaintenance.pictureDepartments.Click += new EventHandler(OpenDepartments);
            objMaintenance.lblDepartments.Click += new EventHandler(OpenDepartments);
            objMaintenance.lblDepartments2.Click += new EventHandler(OpenDepartments);
            objMaintenance.picturePositions.Click += new EventHandler(OpenCharge);
            objMaintenance.lblPositions.Click += new EventHandler(OpenCharge);
            objMaintenance.lblPositions2.Click += new EventHandler(OpenCharge);
        }

        public void OpenDepartments(object sender, EventArgs e)
        {
            FrmDepartments objDepartments = new FrmDepartments();
            objDepartments.ShowDialog();
        }
        public void OpenCharge(object sender, EventArgs e)
        {
            FrmCharge objCharge = new FrmCharge();
            objCharge.ShowDialog();
        }
    }
}

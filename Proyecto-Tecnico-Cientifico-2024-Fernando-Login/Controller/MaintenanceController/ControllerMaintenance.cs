using PTC2024.View.Alerts;
using PTC2024.View.Dashboard;
using PTC2024.View.Maintenance;
using PTC2024.View.Server;
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
            objMaintenance.panelCategories.Click += new EventHandler(OpenCategories);
            objMaintenance.panelBanks.Click += new EventHandler(OpenBanks);
            objMaintenance.pictureDepartments.Click += new EventHandler(OpenDepartments);
            objMaintenance.lblDepartments.Click += new EventHandler(OpenDepartments);
            objMaintenance.lblDepartments2.Click += new EventHandler(OpenDepartments);
            objMaintenance.picturePositions.Click += new EventHandler(OpenCharge);
            objMaintenance.lblPositions.Click += new EventHandler(OpenCharge);
            objMaintenance.lblPositions2.Click += new EventHandler(OpenCharge);
            objMaintenance.pictureCategories.Click += new EventHandler(OpenCategories);
            objMaintenance.lblCategories.Click += new EventHandler(OpenCategories);
            objMaintenance.lblCategories2.Click += new EventHandler(OpenCategories);
            objMaintenance.pictureBanks.Click += new EventHandler(OpenBanks);
            objMaintenance.lblBanks.Click += new EventHandler(OpenBanks);
            objMaintenance.lblBanks2.Click += new EventHandler(OpenBanks);
            objMaintenance.btnServerConfiguration.Click += new EventHandler(OpenCEOPassword);
            objMaintenance.btnBusinessConfiguration.Click += new EventHandler(OpenBusinessConfiguration);
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

        public void OpenCategories(object sender, EventArgs e)
        {
            FrmCategories objCategories = new FrmCategories();
            objCategories.ShowDialog();
        }

        public void OpenBanks(object sender, EventArgs e)
        {
            FrmBanks objBanks = new FrmBanks();
            objBanks.ShowDialog();
        }
        public void OpenCEOPassword(object sender, EventArgs e)
        {
            FrmConfirmPassword objOpen = new FrmConfirmPassword();
            objOpen.ShowDialog();
        }
        public void OpenBusinessConfiguration(object sender, EventArgs e)
        {
            FrmBusinessConfiguration objOpen = new FrmBusinessConfiguration();
            objOpen.ShowDialog();
        }
    }
}

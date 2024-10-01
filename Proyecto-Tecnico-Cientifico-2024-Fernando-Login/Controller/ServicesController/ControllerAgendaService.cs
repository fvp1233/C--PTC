using PTC2024.Model.DAO.ServicesDAO;
using PTC2024.View.Service_inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.ServicesController
{
    internal class ControllerAgendaService
    {
        FrmAgendaServices objAgendaS;

        public ControllerAgendaService(FrmAgendaServices view)
        {
            objAgendaS = view;

            objAgendaS.Load += new EventHandler(ChargeData);
            objAgendaS.btnClose.Click += new EventHandler(CloseForm);

        }


        public void ChargeData(object sender, EventArgs e)
        {
            DAOAgendaService dAOAgendaService = new DAOAgendaService();

            DataSet Answer = dAOAgendaService.ChargeData();

            objAgendaS.DgvAgendaServices.DataSource = Answer.Tables["viewAgendaS"];
        }

        public void CloseForm(object sender, EventArgs e)
        {
            objAgendaS.Close();
        }
    }
}

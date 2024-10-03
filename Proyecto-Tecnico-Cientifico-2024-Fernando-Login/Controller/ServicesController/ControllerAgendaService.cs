using PTC2024.Model.DAO.ServicesDAO;
using PTC2024.View.Service_inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            objAgendaS.cmbAgendaS.SelectedIndexChanged += new EventHandler(FilterData);
            objAgendaS.txtSearch.KeyDown += new KeyEventHandler(SearchData);
        }

        public void ChargeData(object sender, EventArgs e)
        {
            ChargeData();
        }


        public void ChargeData()
        {
            DAOAgendaService dAOAgendaService = new DAOAgendaService();

            DataSet Answer = dAOAgendaService.ChargeData();

            objAgendaS.DgvAgendaServices.DataSource = Answer.Tables["viewAgendaS"];
        }

        public void FilterData(object sender, EventArgs e)
        {
            DAOAgendaService dAOAgendaService = new DAOAgendaService();

            string value = objAgendaS.cmbAgendaS.SelectedItem.ToString();

            if(value != "Ninguno")
            {
                DataSet answer = dAOAgendaService.FilterData(value);

                objAgendaS.DgvAgendaServices.DataSource = answer.Tables["viewAgendaS"];
            }
            else
            {
                ChargeData();
            }


        }

        public void SearchData(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchAgenda();

            }
        }
        void SearchAgenda()
        {

            string value = objAgendaS.txtSearch.Text.Trim();

            if (value != "")
            {
                DAOAgendaService dAOAgendaService = new DAOAgendaService();
                DataSet answer = dAOAgendaService.SearchData(value);
                objAgendaS.DgvAgendaServices.DataSource = answer.Tables["viewAgendaS"];
            }
            else
            {
                ChargeData();
            }

        }

        public void CloseForm(object sender, EventArgs e)
        {
            objAgendaS.Close();
        }
    }
}

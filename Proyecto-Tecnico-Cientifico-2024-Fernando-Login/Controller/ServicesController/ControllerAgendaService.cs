using PTC2024.Model.DAO.ServicesDAO;
using PTC2024.View.Service_inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            objAgendaS.Load += new EventHandler(DarkMode);
            objAgendaS.btnClose.Click += new EventHandler(CloseForm);
            objAgendaS.cmbFilterS.SelectedIndexChanged += new EventHandler(FilterData);
            objAgendaS.txtSearch.KeyDown += new KeyEventHandler(SearchData);
        }

        public void DarkMode(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.darkMode == true)
            {
                objAgendaS.BackColor = Color.FromArgb(30,30,30);
                objAgendaS.lblTitle.ForeColor = Color.White;
                objAgendaS.lblFilter.ForeColor = Color.White;
                objAgendaS.cmbFilterS.BackgroundColor = Color.FromArgb(60, 60, 60);
                objAgendaS.cmbFilterS.BorderColor = Color.Gray;
                objAgendaS.cmbFilterS.ForeColor = Color.White;
                objAgendaS.cmbFilterS.ItemBackColor = Color.DimGray;
                objAgendaS.cmbFilterS.ItemBorderColor = Color.Gray;
                objAgendaS.cmbFilterS.ItemForeColor = Color.White;
                objAgendaS.DgvAgendaServices.BackgroundColor = Color.FromArgb(45, 45, 45);
                objAgendaS.DgvAgendaServices.HeaderBackColor = Color.LightSlateGray;
                objAgendaS.DgvAgendaServices.GridColor = Color.FromArgb(45, 45, 45);
                objAgendaS.DgvAgendaServices.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
                objAgendaS.DgvAgendaServices.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray;
            }
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

            string value = objAgendaS.cmbFilterS.SelectedItem.ToString();

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

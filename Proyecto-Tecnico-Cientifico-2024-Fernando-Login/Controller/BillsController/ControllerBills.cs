﻿using PTC2024.View.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.View.BillsViews;
using PTC2024.Model.DAO;
using PTC2024.Model.DTO;
using PTC2024.Model.DAO.BillsDAO;
using System.Data;
using System.Windows.Forms;
using System.Numerics;
using PTC2024.Model.DAO.ServicesDAO;

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
            objFormBills.cmsBills.Click += new EventHandler(printBills);
            objFormBills.cmsBills.Click += new EventHandler(RectifyBills);
            objFormBills.cmsBills.Click += new EventHandler(OverrideBills);
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

            //DataSet ds = objBills.Bills();
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
            int pos = objFormBills.dgvBills.CurrentRow.Index;
            int id;
            string NIT, NRC;
            string companyName, serviceName, statusBill, customer, employee, methodP;
            DateTime startDate, FinalDate, Dateissued;
            float discount, subtotalPay, totalPay;
            id = int.Parse(objFormBills.dgvBills[0, pos].Value.ToString());
            companyName = objFormBills.dgvBills[1, pos].Value.ToString();
            NIT = objFormBills.dgvBills[2, pos].Value.ToString();
            NRC = objFormBills.dgvBills[3, pos].Value.ToString();
            customer = objFormBills.dgvBills[3, pos].Value.ToString();
            serviceName = objFormBills.dgvBills[4, pos].Value.ToString();
            discount = float.Parse(objFormBills.dgvBills[6, pos].Value.ToString());
            subtotalPay = float.Parse(objFormBills.dgvBills[7, pos].Value.ToString());
            totalPay = float.Parse(objFormBills.dgvBills[8, pos].Value.ToString());
            methodP = objFormBills.dgvBills[9, pos].Value.ToString();
            startDate = DateTime.Parse(objFormBills.dgvBills[10, pos].Value.ToString());
            FinalDate = DateTime.Parse(objFormBills.dgvBills[11, pos].Value.ToString());
            employee = objFormBills.dgvBills[12, pos].Value.ToString();
            statusBill = objFormBills.dgvBills[13, pos].Value.ToString();
            Dateissued = DateTime.Parse(objFormBills.dgvBills[14, pos].Value.ToString());

            FrmAddBills rectifyBill = new FrmAddBills(2, id, companyName, NIT, NRC, customer, serviceName, discount, subtotalPay, totalPay, methodP, startDate, FinalDate, Dateissued, employee, statusBill);
                //, fiscalPeriod);

            rectifyBill.ShowDialog();
            ChargeData();

        }
        public void OverrideBills(object sender, EventArgs e)
        {
            FrmOverrideBill overrideBill = new FrmOverrideBill();
            overrideBill.ShowDialog();
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
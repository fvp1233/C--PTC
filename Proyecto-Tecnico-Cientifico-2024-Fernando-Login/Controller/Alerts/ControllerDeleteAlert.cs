using PTC2024.View.Alerts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.Alerts
{
    internal class ControllerDeleteAlert
    {
        FrmDeleteAlert objDeleteAlert;
        int confirmValue;
        //CONSTRUCTOR DEL FORMULARIO
        public ControllerDeleteAlert(FrmDeleteAlert View) 
        {
            objDeleteAlert = View;
            //Eventos para los clicks de los botones
            objDeleteAlert.Load += new EventHandler(DarkMode);
            objDeleteAlert.btnCancelar.Click += new EventHandler(CancelProcess);
            objDeleteAlert.btnConfirmDelete.Click += new EventHandler(ConfirmProcess);
        }

        public void DarkMode(object sender, EventArgs e)
        {
            objDeleteAlert.BackColor = Color.FromArgb(30,30,30);
            objDeleteAlert.lbl1.ForeColor = Color.White;
            objDeleteAlert.lbl2.ForeColor = Color.White;
        }

        public void CancelProcess(object sender, EventArgs e)
        {
            CancelProcessValue();
            objDeleteAlert.Close();
        }

        public void ConfirmProcess(object sender, EventArgs e)
        {
            ConfirmProcessValue();
            objDeleteAlert.Close();
        }

        public int CancelProcessValue()
        {
            confirmValue = 0;
            return confirmValue;
        }

        public int ConfirmProcessValue()
        {
            confirmValue = 1;
            return confirmValue;
        }

        public int ConfirmValue
        {
            get { return confirmValue; }
            
        }
    }
}

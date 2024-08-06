using PTC2024.Model;
using PTC2024.View.Alerts;
using PTC2024.View.BillsViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.BillsController
{
    internal class ControllerOverride
    {
       
            FrmOverrideBill objoverrideBill;
            int confirmValue;
            //CONSTRUCTOR DEL FORMULARIO
            public ControllerOverride(FrmOverrideBill View)
            {
            objoverrideBill = View;
            //Eventos para los clicks de los botones
            objoverrideBill.btnback.Click += new EventHandler(CancelProcess);
            objoverrideBill.btnConfirm.Click += new EventHandler(ConfirmProcess);
            }

            public void CancelProcess(object sender, EventArgs e)
            {
                CancelProcessValue();
            objoverrideBill.Close();
            }

            public void ConfirmProcess(object sender, EventArgs e)
            {
                ConfirmProcessValue();
            objoverrideBill.Close();
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



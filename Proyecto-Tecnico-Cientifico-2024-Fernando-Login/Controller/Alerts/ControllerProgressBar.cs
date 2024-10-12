using PTC2024.View.Alerts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.Alerts
{
    internal class ControllerProgressBar
    {
        ProgressBarForm objForm;
        public ControllerProgressBar(ProgressBarForm View)
        {
            objForm = View;
            objForm.Load += new EventHandler(Event);
            objForm.Load += new EventHandler(DarkMode);
        }

        public void DarkMode(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.darkMode == true)
            {
                objForm.BackColor = Color.FromArgb(30, 30, 30);
                objForm.lblStatus.ForeColor = Color.White;
                //objForm.progressBar.ProgressColorLeft = Color.FromArgb(26, 32, 161);
                //objForm.progressBar.ProgressColorRight = Color.FromArgb(10, 182, 238);
                //objForm.progressBar.BackColor = Color.Gray;
                //objForm.progressBar.BorderColor = Color.Gray;
            }
            
        }

        public void Event(object sender, EventArgs e) 
        {
            UpdateProgress(0, " ");
        }
        public void UpdateProgress(int progress, string message)
        {
 
            if (objForm.progressBar.InvokeRequired)
            {
                objForm.progressBar.Invoke(new Action(() =>
                {
                    objForm.progressBar.Value = progress;
                    objForm.lblStatus.Text = message;
                }));
            }
            else
            {
                objForm.progressBar.Value = progress;
                objForm.lblStatus.Text = message;
            }
        }
    }
}

using PTC2024.View.Alerts;
using System;
using System.Collections.Generic;
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

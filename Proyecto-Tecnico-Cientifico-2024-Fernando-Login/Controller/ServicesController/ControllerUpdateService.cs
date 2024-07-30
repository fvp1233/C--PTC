using PTC2024.View.Service_inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.ServicesController
{
    internal class ControllerUpdateService
    {
        FrmUpdateService objUpdateService;

        public ControllerUpdateService(FrmUpdateService view)
        {
            objUpdateService = view;

            objUpdateService.btnCloseUpdateService.Click += new EventHandler(CloseUpdateService);
        }

        public void CloseUpdateService(object sender, EventArgs e)
        {
            objUpdateService.Close();
        }
    }
}

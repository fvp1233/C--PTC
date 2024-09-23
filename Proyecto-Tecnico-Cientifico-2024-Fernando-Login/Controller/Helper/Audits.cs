using PTC2024.Model.DAO.HelperDAO;
using PTC2024.View.formularios.inicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.Helper
{
    internal class Audits : DAOInitialView
    {
        StartMenu objStartForm;
        public void Audit()
        {
            DAOInitialView daoInitial = new DAOInitialView();
            daoInitial.ActionType = "INSERT";
            daoInitial.TableName = "tbEmployee";
            daoInitial.ActionBy = SessionVar.Username;
            daoInitial.ActionDate = DateTime.Now;
            int answer = daoInitial.InsertAudit();
            if (answer == 1 )
            {
                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStartForm = objStart;
                objStartForm.snackBar.Show(objStartForm, $"La auditoria fue registrada exitosamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
            }
            else
            {
                StartMenu objStart = new StartMenu(SessionVar.Username);
                objStartForm = objStart;
                objStartForm.snackBar.Show(objStartForm, $"La auditoria no fue registrada exitosamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.View.Maintenance;
using PTC2024.Model.DAO.MaintenanceDAO;
using System.Data;
using System.Windows.Forms;

namespace PTC2024.Controller.MaintenanceController
{
    internal class ControllerCategories
    {
        //objeto del formulario
        FrmCategories objCategories;
        //objeto de la clase DAOCategories

        //Constructor del controlador
        public ControllerCategories(FrmCategories View)
        {
            objCategories = View;
            objCategories.Load += new EventHandler(InitialCharge);
            objCategories.btnGoBack.Click += new EventHandler(CloseForm);
            objCategories.btnAddCategorie.Click += new EventHandler(AddCategorie);
            objCategories.cmsDeleteCategorie.Click += new EventHandler(DeleteCategorie);

        }

        public void InitialCharge(object sender, EventArgs e)
        {
            GetCategoriesDgv();
        }
        public void CloseForm(object sender, EventArgs e)
        {
            objCategories.Close();
        }

        public void GetCategoriesDgv()
        {
            DAOCategories daoCategories = new DAOCategories();
            DataSet ds = daoCategories.GetCategories();
            objCategories.dgvCategories.DataSource = ds.Tables["viewCategories"];
        }

        public void AddCategorie(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(objCategories.txtCategorie.Text)))
            {
                DAOCategories daoCategories = new DAOCategories();
                daoCategories.Category = objCategories.txtCategorie.Text.Trim();
                int returnedAnswer = daoCategories.AddCategorie();
                if (returnedAnswer == 1)
                {
                    MessageBox.Show("La categoría se ingresó correctamente", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La categoría no pudo ser ingresada", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Llene el campo para ingresar una nueva categoría", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            GetCategoriesDgv();
            objCategories.txtCategorie.Clear();
        }

        public void DeleteCategorie(object sender, EventArgs e)
        {
            DAOCategories daoCategories = new DAOCategories();
            int row = objCategories.dgvCategories.CurrentRow.Index;
            int idCategory = int.Parse(objCategories.dgvCategories[0, row].Value.ToString());
            if (MessageBox.Show("¿Seguro que desea eliminar esta categoría?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                daoCategories.IdCategory = int.Parse(objCategories.dgvCategories[0, row].Value.ToString());
                int returnedAnswer = daoCategories.DeleteCategorie();
                if (returnedAnswer == 1)
                {
                    MessageBox.Show("La categoría se eliminó correctamente", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    objCategories.snack.Show(objCategories, "Esta categoria no se puede eliminar debido a que algun servicio pertenece a esta categoria", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomCenter);
                }
                GetCategoriesDgv();
            }
        }
    }
}

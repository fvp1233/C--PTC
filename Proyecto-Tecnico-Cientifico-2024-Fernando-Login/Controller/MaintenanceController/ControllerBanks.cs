using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Model.DAO.MaintenanceDAO;
using PTC2024.View.Maintenance;

namespace PTC2024.Controller.MaintenanceController
{
    internal class ControllerBanks
    {
        FrmBanks objBanks;
        public ControllerBanks(FrmBanks View)
        {
            objBanks = View;
            objBanks.Load += new EventHandler(InitialCharge);
            objBanks.btnAddBank.Click += new EventHandler(NewBank);
            objBanks.cmsDeleteBank.Click += new EventHandler(DeleteBank);
            objBanks.btnGoBack.Click += new EventHandler(CloseForm);
        }

        public void InitialCharge(object sender, EventArgs e)
        {
            LoadDataGridBanks();
        }

        public void CloseForm(object sender, EventArgs e)
        {
            objBanks.Close();
        }

        public void LoadDataGridBanks()
        {
            //Creamos objeto del daoBanks
            DAOBanks daoBanks = new DAOBanks();
            //Creamos un dataset que recogerá lo que nos manda el método del DTO
            DataSet ds = daoBanks.GetBanks();
            //Le damos valor al datasource del datagrid
            objBanks.dgvBanks.DataSource = ds.Tables["viewBanks"];
        }

        public void NewBank(object sender,EventArgs e)
        {
            //Verificación de campos vacíos
            if (!(string.IsNullOrEmpty(objBanks.txtBank.Text)))
            {
                //Creamos objeto del dao
                DAOBanks daoBanks = new DAOBanks();
                //damos valor al getter
                daoBanks.Bank = objBanks.txtBank.Text.Trim();
                //ejecutamos el método del dao
                int returnedAnswer = daoBanks.AddBank();

                //Validamos la respuesta que nos retornaron
                if (returnedAnswer == 1)
                {
                    MessageBox.Show("El banco se agregó correctamente", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
                else
                {
                    MessageBox.Show("El banco no pudo ser agregado", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadDataGridBanks();
                objBanks.txtBank.Clear();

            }
            else
            {
                MessageBox.Show("Llene el campo para agregar un nuevo banco", "Campo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void DeleteBank(object sender, EventArgs e)
        {
            //Creamos objeto de la clase DAO
            DAOBanks daoBanks = new DAOBanks();
            //Creamos la variable con la que sabremos que registro esta seleccionado en el datagrid
            int row = objBanks.dgvBanks.CurrentRow.Index;
            int idBank = int.Parse(objBanks.dgvBanks[0, row].Value.ToString());
            if (idBank > 12){
                //Confirmación por parte del usuario
                if (MessageBox.Show("¿Está seguro que desea eliminar este banco?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Damos valor al getter del dao
                    daoBanks.IdBank = int.Parse(objBanks.dgvBanks[0, row].Value.ToString());
                    //ejecutamos el método del dao
                    int returnedAnswer = daoBanks.DeleteBank();
                    //validamos la respuesta devuelta
                    if (returnedAnswer == 1)
                    {
                        MessageBox.Show("El banco se eliminó correctamente", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El banco no pudo ser eliminado", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadDataGridBanks();
                }
            }
            else
            {
                objBanks.snack.Show(objBanks, "Este banco no se puede eliminar.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomCenter);
            }
            
        }
    }
}

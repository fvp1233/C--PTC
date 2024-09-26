using PTC2024.Model.DAO.ServicesDAO;
using PTC2024.View.InventarioServicios;
using PTC2024.View.Service_inventory;
using PTC2024.View.Reporting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.View.Reporting.Service;
using PTC2024.Model.DAO.CustomersDAO;
using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.HelperDAO;
using PTC2024.View.formularios.inicio;

namespace PTC2024.Controller.ServicesController
{

    internal class ControllerServices
    {
        FrmServices objServices;
        StartMenu objStartMenu;

        public ControllerServices(FrmServices view)
        {
            objServices = view;

            /*Aca se encuentran todos los eventos del Controlador de servicios*/
            objServices.Load += new EventHandler(ChargeData);
            objServices.btnAddService.Click += new EventHandler(OpenAddService);
            objServices.btnReportServices.Click += new EventHandler(ReportAllServices);
            objServices.cmsDeleteService.Click += new EventHandler(DeleteService);
            objServices.cmsUpdateService.Click += new EventHandler(OpenUpdateService);
            objServices.txtSearch.KeyDown += new KeyEventHandler(Search);
            objServices.CbSeguridad.Click += new EventHandler(SearchCheckBox1);
            objServices.CbInfraestructura.Click += new EventHandler(SearchCheckBox2);
            objServices.CbProgramacion.Click += new EventHandler(SearchCheckBox3);
            objServices.CbMantenimiento.Click += new EventHandler(SearchCheckBox4);
            objServices.CbSoporte.Click += new EventHandler(SearchCheckBox5);

        }

        /*Este metodo cargara inicialmente el DataGridView*/
        public void ChargeData(object sender, EventArgs e)
        {
            ChargeDgv();
        }

        /*Este metodo se usara para cargar el DataGridView al momento de abrir el apartado de servicios asi mismo de refrescarlo cuando se actualice, elimine o inserte algun dato*/
        public void ChargeDgv()
        {
            DAOServices dAOServices = new DAOServices();
            DataSet Result = dAOServices.GetDataTable();
            objServices.DgvServicios.DataSource = Result.Tables["viewServices"];
            objServices.DgvServicios.Columns[5].Visible = false;
        }

        /*Método para abrir formulario de reporte general*/
        public void ReportAllServices (object sender, EventArgs e)
        {
            FrmReportServices openReport = new FrmReportServices();
            openReport.ShowDialog();
        }

        /*Este metodo se ejecutara cuando se haga click en actualizar servicio*/
        public void OpenUpdateService(object sender, EventArgs e)
        {
            /*Aca se captura la fila seleccionada al dar click derecho*/
            int pos = objServices.DgvServicios.CurrentRow.Index;

            /*Aca le estamos dando valor a los parametros que se mandaran al objeto del formulario UpdateService*/
            int id = int.Parse(objServices.DgvServicios[0, pos].Value.ToString());
            string name = objServices.DgvServicios[1, pos].Value.ToString();
            string description = objServices.DgvServicios[2, pos].Value.ToString();
            double amount = double.Parse(objServices.DgvServicios[3, pos].Value.ToString());
            string category = objServices.DgvServicios[4, pos].Value.ToString();
            int idCategory = (int)objServices.DgvServicios[5, pos].Value;
            /*Aca se crea un objeto del formulario UpdateService y se les agrega sus respectivos parametros*/
            FrmUpdateService objUpdateService = new FrmUpdateService( id, name, description, amount, category, idCategory);
            /*Se abre el formulario*/
            objUpdateService.ShowDialog();
            /*Se refresca el DataGridView*/
            ChargeDgv();
        }

        /*Este metodo se ejecutara cuando se haga click en añadir servicio*/
        public void OpenAddService(object sender, EventArgs e)
        {
            FrmAddService objAddService = new FrmAddService();
            objAddService.ShowDialog();
            ChargeDgv();
        }

        /*Este metodo se ejecutara cuando se haga click en eliminar servicio*/
        public void DeleteService(object sender, EventArgs e)
        {
            /*Aca se le pregunta al usuario si sta seguro de borrar los datos ya que esta opcion no tiene vuelta atras*/
            if (MessageBox.Show("Estas seguro de borrar los datos, esta accion no se puede revertir", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /*Si el usuario confirma la accion entonces se procede a eliminar el servicio*/
                DAOServices dAOServices = new DAOServices();
                /*Se captura la fila seleccionada*/
                int pos = objServices.DgvServicios.CurrentRow.Index;

                /*Aca se le da valor al atributo de la clase*/
                dAOServices.IdService1 = int.Parse(objServices.DgvServicios[0, pos].Value.ToString());

                /*Se captura la respuesta que retorno el metodo DeleteService*/
                int answer = dAOServices.DeleteService();

                /*Se evalua la respuesta*/
                if (answer == 1)
                {
                    MessageBox.Show("Los datos se eliminaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DAOInitialView daoInitial = new DAOInitialView();
                    daoInitial.ActionType = "Se eliminó un servicio";
                    daoInitial.TableName = "Servicios";
                    daoInitial.ActionBy = SessionVar.Username;
                    daoInitial.ActionDate = DateTime.Now;
                    int auditAnswer = daoInitial.InsertAudit();
                    if (auditAnswer != 1)
                    {
                        objStartMenu.snackBar.Show(objStartMenu, $"La auditoria no pudo ser registrada", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                    }
                }
                else
                {
                    MessageBox.Show("Los datos no se eliminaron debido a un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                /*Se refresca el DataGridView*/
                ChargeDgv();

            }

        }

        /*Este metodo se ejecutara cuando se escriba en el textbox para filtrar un servicio*/
        public void Search(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DAOServices dAOServices = new DAOServices();

                /*Aca se le da valor al atributo de la clase*/
                dAOServices.Search1 = objServices.txtSearch.Text;

                /*Se captura la respuesta de l metodo SearchData y se le agrega su respectivo parametro*/
                DataSet answer = dAOServices.SearchData(dAOServices.Search1);
                /*Se le dice al DataGridView lo que tiene que mostrar*/
                objServices.DgvServicios.DataSource = answer.Tables["viewServices"];
            }
            if (objServices.txtSearch.Text == string.Empty)
            {
                ChargeDgv();            
            }

        }

        /*Este se ejecutara cuando se haga click en cualquier checkbox*/
        public void SearchCheckBox1(object sender, EventArgs e)
        {
            DAOServices dAOServices = new DAOServices();

            /*Se crea una variable cuyo valor dependera de cual checkbox este checkeado*/
            string category = "";

            /*Se verificara cual checkbox esta checkeado*/
            /*Los demas checkbox estaran desabilitados si uno esta checkeado*/
            if (objServices.CbSeguridad.Checked == true)
            {
                category = objServices.CbSeguridad.Tag.ToString();
                objServices.CbInfraestructura.Checked = false;
                objServices.CbMantenimiento.Checked = false;
                objServices.CbSoporte.Checked = false;
                objServices.CbProgramacion.Checked = false;
                DataSet respuesta = dAOServices.SearchDataCb(category);
                objServices.DgvServicios.DataSource = respuesta.Tables["viewServices"];
            }
            else
            {
                ChargeDgv();
            }


        }

        /*Este se ejecutara cuando se haga click en cualquier checkbox*/
        public void SearchCheckBox2(object sender, EventArgs e)
        {
            DAOServices dAOServices = new DAOServices();

            /*Se crea una variable cuyo valor dependera de cual checkbox este checkeado*/
            string category = "";

            /*Se verificara cual checkbox esta checkeado*/
            /*Los demas checkbox estaran desabilitados si uno esta checkeado*/
            if (objServices.CbInfraestructura.Checked == true)
            {
                category = objServices.CbInfraestructura.Tag.ToString();
                objServices.CbSeguridad.Checked = false;
                objServices.CbMantenimiento.Checked = false;
                objServices.CbSoporte.Checked = false;
                objServices.CbProgramacion.Checked = false;
                DataSet respuesta = dAOServices.SearchDataCb(category);
                objServices.DgvServicios.DataSource = respuesta.Tables["viewServices"];
            }
            else
            {
                ChargeDgv();
            }
        }

        /*Este se ejecutara cuando se haga click en cualquier checkbox*/
        public void SearchCheckBox3(object sender, EventArgs e)
        {
            DAOServices dAOServices = new DAOServices();

            /*Se crea una variable cuyo valor dependera de cual checkbox este checkeado*/
            string category = "";

            /*Se verificara cual checkbox esta checkeado*/
            /*Los demas checkbox estaran desabilitados si uno esta checkeado*/
            if (objServices.CbProgramacion.Checked == true)
            {
                category = objServices.CbProgramacion.Tag.ToString();
                objServices.CbSeguridad.Checked = false;
                objServices.CbInfraestructura.Checked = false;
                objServices.CbMantenimiento.Checked = false;
                objServices.CbSoporte.Checked = false;
                DataSet respuesta = dAOServices.SearchDataCb(category);
                objServices.DgvServicios.DataSource = respuesta.Tables["viewServices"];
            }
            else
            {
                ChargeDgv();
            }

        }

        /*Este se ejecutara cuando se haga click en cualquier checkbox*/
        public void SearchCheckBox4(object sender, EventArgs e)
        {
            DAOServices dAOServices = new DAOServices();

            /*Se crea una variable cuyo valor dependera de cual checkbox este checkeado*/
            string category = "";

            /*Se verificara cual checkbox esta checkeado*/
            /*Los demas checkbox estaran desabilitados si uno esta checkeado*/
            if (objServices.CbMantenimiento.Checked == true)
            {
                category = objServices.CbMantenimiento.Tag.ToString();
                objServices.CbSeguridad.Checked = false;
                objServices.CbInfraestructura.Checked = false;
                objServices.CbSoporte.Checked = false;
                objServices.CbProgramacion.Checked = false;
                DataSet respuesta = dAOServices.SearchDataCb(category);
                objServices.DgvServicios.DataSource = respuesta.Tables["viewServices"];
            }
            else
            {
                ChargeDgv();
            }

        }

        /*Este se ejecutara cuando se haga click en cualquier checkbox*/
        public void SearchCheckBox5(object sender, EventArgs e)
        {
            DAOServices dAOServices = new DAOServices();

            /*Se crea una variable cuyo valor dependera de cual checkbox este checkeado*/
            string category = "";

            /*Se verificara cual checkbox esta checkeado*/
            /*Los demas checkbox estaran desabilitados si uno esta checkeado*/
            if (objServices.CbSoporte.Checked == true)
            {
                category = objServices.CbSoporte.Tag.ToString();
                objServices.CbSeguridad.Checked = false;
                objServices.CbInfraestructura.Checked = false;
                objServices.CbProgramacion.Checked = false;
                objServices.CbMantenimiento.Checked = false;
                DataSet respuesta = dAOServices.SearchDataCb(category);
                objServices.DgvServicios.DataSource = respuesta.Tables["viewServices"];
            }
            else
            {
                ChargeDgv();
            }

        }
    }
}

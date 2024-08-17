﻿using PTC2024.Model.DAO.EmployeesDAO;
using PTC2024.View.Empleados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.View.Alerts;
using PTC2024.Controller.Alerts;
using System.Windows.Forms;
using PTC2024.View.EmployeeViews;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using PTC2024.Model.DTO.EmployeesDTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PTC2024.Controller.Employees
{
    internal class ControllerEmployees
    {
        FrmEmployees objEmployees;

        //CONSTRUCTOR
        public ControllerEmployees(FrmEmployees Vista)
        {
            objEmployees = Vista;
            //Evento para cargar el dataGrid
            objEmployees.Load += new EventHandler(LoadData);
            //Eventos de click de botones
            objEmployees.BtnAddEmployee.Click += new EventHandler(NewEmployee);
            objEmployees.cmsUpdateEmployee.Click += new EventHandler(UpdateEmployee);
            objEmployees.cmsDeleteEmployee.Click += new EventHandler(DisableEmployee);
            objEmployees.cmsEmployeeInformation.Click += new EventHandler(ViewEmployeeInfo);
            objEmployees.txtEmployeeSearch.KeyPress += new KeyPressEventHandler(SearchEmployeeEvent);
            objEmployees.cbTiempoCompleto.Click += new EventHandler(CheckedTiempoCompleto);
            objEmployees.cbVoluntario.Click += new EventHandler(CheckedVoluntario);
            objEmployees.cbBecario.Click += new EventHandler(CheckedBecario);
            objEmployees.cbInterno.Click += new EventHandler(CheckedInterno);
            objEmployees.cbAdmin.Click += new EventHandler(CheckedAdministracion);
            objEmployees.cbDesarrollo.Click += new EventHandler(CheckedDesarrollo);
            objEmployees.cbSoporte.Click += new EventHandler(CheckedSoporte);
            objEmployees.cbRecursosH.Click += new EventHandler(CheckedRecursosH);
            objEmployees.cbMarketing.Click += new EventHandler(CheckedMarketing);
            objEmployees.cbActivo.Click += new EventHandler(CheckedActivo);
            objEmployees.cbInactivo.Click += new EventHandler(CheckedInactivo);
            objEmployees.cbIncapacidad.Click += new EventHandler(CheckedIncapacidad);
            objEmployees.cbMaternidad.Click += new EventHandler(CheckedMaternidad);
        }

        public void LoadData (object sender, EventArgs e)
        {
            RefreshDataGridEmployees();
        }

        public void SearchEmployeeEvent(object sender, EventArgs e)
        {
            SearchEmployee();
        }

        public void SearchEmployee()
        {
            DAOEmployees daoEmployees = new DAOEmployees();
            DataSet ds = daoEmployees.EmployeeSearch(objEmployees.txtEmployeeSearch.Text.Trim());
            objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            if (objEmployees.txtEmployeeSearch.Text.Equals(""))
            {
                RefreshDataGridEmployees();
            }

        }

        public void RefreshDataGridEmployees()
        {
            DAOEmployees daoEmployees = new DAOEmployees();
            DataSet ds = daoEmployees.GetEmployees();
            //Llenando el datagridview
            objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            objEmployees.dgvEmployees.Columns[0].DividerWidth = 1;
            objEmployees.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            objEmployees.dgvEmployees.Columns[4].Visible = false;
            objEmployees.dgvEmployees.Columns[9].Visible = false;
            objEmployees.dgvEmployees.Columns[10].Visible = false;
            objEmployees.dgvEmployees.Columns[11].Visible = false;
            objEmployees.dgvEmployees.Columns[12].Visible = false;
            objEmployees.dgvEmployees.Columns[14].Visible = false;
            objEmployees.dgvEmployees.Columns[15].Visible = false;
            objEmployees.dgvEmployees.Columns[18].Visible = false;
        }
        public void ViewEmployeeInfo(object sender, EventArgs e)
        {
            int row = objEmployees.dgvEmployees.CurrentRow.Index;

            int affiliationNumber;
            string names, lastNames, dui, adress, phone, email, maritalStatus, typeEmployee, statusEmployee, bankAccount, username, businessP, department, bank;
            DateTime birthDate, hireDate;
            double salary;

            //Asignación de valores a la variables que se colocaran en los textbox del formulario.
            names = objEmployees.dgvEmployees[1, row].Value.ToString();
            lastNames = objEmployees.dgvEmployees[2, row].Value.ToString();
            dui = objEmployees.dgvEmployees[3, row].Value.ToString();
            birthDate = DateTime.Parse(objEmployees.dgvEmployees[4, row].Value.ToString());
            adress = objEmployees.dgvEmployees[7, row].Value.ToString();
            phone = objEmployees.dgvEmployees[6, row].Value.ToString();
            email = objEmployees.dgvEmployees[5, row].Value.ToString();
            hireDate = DateTime.Parse(objEmployees.dgvEmployees[12, row].Value.ToString());
            maritalStatus = objEmployees.dgvEmployees[15, row].Value.ToString();
            typeEmployee = objEmployees.dgvEmployees[14, row].Value.ToString();
            statusEmployee = objEmployees.dgvEmployees[16, row].Value.ToString();
            salary = double.Parse(objEmployees.dgvEmployees[8, row].Value.ToString());
            affiliationNumber = int.Parse(objEmployees.dgvEmployees[11, row].Value.ToString());
            bankAccount = objEmployees.dgvEmployees[9, row].Value.ToString();
            username = objEmployees.dgvEmployees[17, row].Value.ToString();
            businessP = objEmployees.dgvEmployees[19, row].Value.ToString();
            department = objEmployees.dgvEmployees[13, row].Value.ToString();
            bank = objEmployees.dgvEmployees[10, row].Value.ToString();

            //Se crea instancia del formulario para abrirlo
            FrmInfoEmployee openForm = new FrmInfoEmployee(names, lastNames, dui, birthDate, adress, phone, email, hireDate, maritalStatus, typeEmployee, statusEmployee, salary, affiliationNumber, bankAccount, username, businessP, department, bank);
            openForm.ShowDialog();
        }

        public void NewEmployee(object sender, EventArgs e)
        {
            //Creando objeto del formulario FrmAddEmployee
            FrmAddEmployee abrirForm = new FrmAddEmployee();
            abrirForm.ShowDialog();
            RefreshDataGridEmployees();
        }

        public void UpdateEmployee(object sender, EventArgs e) 
        {
            //Se crea una variable para saber la fila del empleado al que se le dio click
            int row = objEmployees.dgvEmployees.CurrentRow.Index;
            //se manda a llamar al formulario para la actualización de empleados por medio de un objeto con los parámetros necesarios.
            FrmUpdateEmployee abrirfForm = new FrmUpdateEmployee(
                int.Parse(objEmployees.dgvEmployees[0, row].Value.ToString()),
                objEmployees.dgvEmployees[1, row].Value.ToString(),
                objEmployees.dgvEmployees[2, row].Value.ToString(),
                objEmployees.dgvEmployees[3, row].Value.ToString(),
                DateTime.Parse(objEmployees.dgvEmployees[4, row].Value.ToString()),
                objEmployees.dgvEmployees[5, row].Value.ToString(),
                objEmployees.dgvEmployees[6, row].Value.ToString(),
                objEmployees.dgvEmployees[7, row].Value.ToString(),
                double.Parse(objEmployees.dgvEmployees[8, row].Value.ToString()),
                objEmployees.dgvEmployees[9, row].Value.ToString(),
                objEmployees.dgvEmployees[10, row].Value.ToString(),
                objEmployees.dgvEmployees[11, row].Value.ToString(),
                DateTime.Parse(objEmployees.dgvEmployees[12, row].Value.ToString()),
                objEmployees.dgvEmployees[13, row].Value.ToString(),
                objEmployees.dgvEmployees[14, row].Value.ToString(),
                objEmployees.dgvEmployees[15, row].Value.ToString(),
                objEmployees.dgvEmployees[16, row].Value.ToString(),
                objEmployees.dgvEmployees[17, row].Value.ToString(),
                objEmployees.dgvEmployees[19, row].Value.ToString()
                );
            abrirfForm.ShowDialog();
            RefreshDataGridEmployees();
        }

        public void DisableEmployee(object sender, EventArgs e)
        {
            //Se declara la variable row, que va a guardar el número de la fila del registro escogido para eliminar
            int row = objEmployees.dgvEmployees.CurrentRow.Index;
            //Le damos valor al getter IdEmployee para la verificación de primer usuario.
            DAOEmployees daoEmployees = new DAOEmployees();
            //Damos valor al getter idEmployee para hacer una validación mas abajo.
            daoEmployees.IdEmployee = int.Parse(objEmployees.dgvEmployees[0,row].Value.ToString());
            //Creamos un objeto del formulario que servirá para confirmar la accion de eliminar - 
            FrmDeleteAlert openDeleteAlert = new FrmDeleteAlert();
            //Creamos una instancia del controlador del formulario que usaremos para confirmar la acción a partir de un valor int que este nos va enviar. 
            ControllerDeleteAlert objControllerDeleteAlert = new ControllerDeleteAlert(openDeleteAlert);
            openDeleteAlert.FormBorderStyle = FormBorderStyle.None;
            openDeleteAlert.ShowDialog();
            //Evaluamos la respuesta que nos envió el formulario despues de presionar uno de los botones 
            if (objControllerDeleteAlert.ConfirmValue == 1)
            {
                //Validación para saber si es el primer empleado registrado en el sistema, si lo es, este no podrá ser deshabilitado.
                if (!(daoEmployees.IdEmployee == 20240001))
                {
                    //Le damos valor al getter IdEmployee 
                    daoEmployees.Username = objEmployees.dgvEmployees[17, row].Value.ToString();
                    //Mandamos a llamar el proceso de la eliminación de empleado del DAOEmployees para evaluar el valor que el metodo nos retorna 
                    int value = daoEmployees.DisableEmployee();
                    if (value == 1)
                    {
                        openDeleteAlert.Close();
                        MessageBox.Show("El empleado fue deshabilitado junto a su usuario de manera exitosa", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        openDeleteAlert.Close();
                        MessageBox.Show("Ocurrió un error, el empleado no pudo ser deshabilitado", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Este es el primer empleado registrado en el sistema, por lo que no puede ser eliminado", "Proceso imposible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            #region disable con messagebox de windows
            //if (MessageBox.Show($"Esta seguro que desea eliminar a:\n {objEmployees.dgvEmployees[1, row].Value.ToString()}. \n Esta acción no puede ser revertida. ", "Confirme su acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    DAOEmployees daoEmployees = new DAOEmployees();
            //    daoEmployees.Username = objEmployees.dgvEmployees[16, row].Value.ToString();
            //    int value = daoEmployees.DisableEmployee();
            //    if (value == 1)
            //    {
            //        MessageBox.Show("El empleado fue deshabilitado de manera exitosa", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Ocurrió un error, el empleado no pudo ser deshabilitado", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            #endregion
            RefreshDataGridEmployees();
        }

        public void CheckedTiempoCompleto(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string employeeType;
            if (objEmployees.cbTiempoCompleto.Checked == true)
            {
                employeeType = objEmployees.cbTiempoCompleto.Tag.ToString();
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                //Creamos un dataset para capturar el que nos va a devolver el método en el DAO, y le enviamos la variable string que este tiene como parámetro
                DataSet dsEmployeeType = daoEmployees.CheckboxFiltersTypeE(employeeType);
                //Le damos el valor al datagrid
                objEmployees.dgvEmployees.DataSource = dsEmployeeType.Tables["viewEmployees"];

            }
            else
            {
                RefreshDataGridEmployees();
            }
        }

        public void CheckedVoluntario(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string employeeType;
            if (objEmployees.cbVoluntario.Checked == true)
            {
                //Repetimos el mismo proceso anterior para todos los checkbox
                employeeType = objEmployees.cbVoluntario.Tag.ToString();
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;

                DataSet dsEmployeeType = daoEmployees.CheckboxFiltersTypeE(employeeType);
                objEmployees.dgvEmployees.DataSource = dsEmployeeType.Tables["viewEmployees"];
            }
            else
            {
                RefreshDataGridEmployees();
            }
        }

        public void CheckedBecario(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string employeeType;
            if (objEmployees.cbBecario.Checked == true)
            {
                employeeType = objEmployees.cbBecario.Tag.ToString();
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;

                DataSet dsEmployeeType = daoEmployees.CheckboxFiltersTypeE(employeeType);
                objEmployees.dgvEmployees.DataSource = dsEmployeeType.Tables["viewEmployees"];
            }
            else
            {
                RefreshDataGridEmployees();
            }
        }

        public void CheckedInterno(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string employeeType;
            if (objEmployees.cbInterno.Checked == true)
            {
                employeeType = objEmployees.cbInterno.Tag.ToString();
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;

                DataSet dsEmployeeType = daoEmployees.CheckboxFiltersTypeE(employeeType);
                objEmployees.dgvEmployees.DataSource = dsEmployeeType.Tables["viewEmployees"];
            }
            else
            {
                RefreshDataGridEmployees();
            }
        }

        public void CheckedAdministracion(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string department;
            if (objEmployees.cbAdmin.Checked == true)
            {
                department = objEmployees.cbAdmin.Tag.ToString();
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                DataSet ds = daoEmployees.CheckboxFiltersDepartment(department);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else
            {
                RefreshDataGridEmployees();
            }
        }

        public void CheckedDesarrollo(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string department;
            if (objEmployees.cbDesarrollo.Checked == true)
            {
                department = objEmployees.cbDesarrollo.Tag.ToString();
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                DataSet ds = daoEmployees.CheckboxFiltersDepartment(department);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else
            {
                RefreshDataGridEmployees();
            }
        }

        public void CheckedSoporte(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string department;
            if (objEmployees.cbSoporte.Checked == true)
            {
                department = objEmployees.cbSoporte.Tag.ToString();
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                DataSet ds = daoEmployees.CheckboxFiltersDepartment(department);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else
            {
                RefreshDataGridEmployees();
            }
        }

        public void CheckedRecursosH(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string department;
            if (objEmployees.cbRecursosH.Checked == true)
            {
                department = objEmployees.cbRecursosH.Tag.ToString();
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                DataSet ds = daoEmployees.CheckboxFiltersDepartment(department);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else
            {
                RefreshDataGridEmployees();
            }
        }

        public void CheckedMarketing(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string department;
            if (objEmployees.cbMarketing.Checked == true)
            {
                department = objEmployees.cbMarketing.Tag.ToString();
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                DataSet ds = daoEmployees.CheckboxFiltersDepartment(department);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else
            {
                RefreshDataGridEmployees();
            }
        }

        public void CheckedActivo(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string status;
            if (objEmployees.cbActivo.Checked == true)
            {
                status = objEmployees.cbActivo.Tag.ToString();
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                //se crea un dataset que capturará el que nos envía el método en el DAO y le enviamos la variable string que necesita
                DataSet ds = daoEmployees.CheckboxFiltersStatus(status);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else
            {
                RefreshDataGridEmployees();
            }
        }

        public void CheckedInactivo(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string status;
            if (objEmployees.cbInactivo.Checked == true)
            {
                status = objEmployees.cbInactivo.Tag.ToString();
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;

                DataSet ds = daoEmployees.CheckboxFiltersStatus(status);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else
            {
                RefreshDataGridEmployees();
            }
        }

        public void CheckedMaternidad(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string status;
            if (objEmployees.cbIncapacidad.Checked == true)
            {
                status = objEmployees.cbIncapacidad.Tag.ToString();
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;

                DataSet ds = daoEmployees.CheckboxFiltersStatus(status);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else
            {
                RefreshDataGridEmployees();
            }
        }

        public void CheckedIncapacidad(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string status;
            if (objEmployees.cbIncapacidad.Checked == true)
            {
                status = objEmployees.cbIncapacidad.Tag.ToString();
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;

                DataSet ds = daoEmployees.CheckboxFiltersStatus(status);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else
            {
                RefreshDataGridEmployees();
            }
        }

        #region Método filtración antiguo (Tipo Empleado)
        public void CheckBoxFilterTypeEmployee(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string employeeType;
            //Si un checkbox esta activado, todos los demás no
            if (objEmployees.cbTiempoCompleto.Checked == true)
            {
                employeeType = objEmployees.cbTiempoCompleto.Tag.ToString();
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                //Creamos un dataset para capturar el que nos va a devolver el método en el DAO, y le enviamos la variable string que este tiene como parámetro
                DataSet dsEmployeeType = daoEmployees.CheckboxFiltersTypeE(employeeType);
                //Le damos el valor al datagrid
                objEmployees.dgvEmployees.DataSource = dsEmployeeType.Tables["viewEmployees"];

            }
            else if (objEmployees.cbVoluntario.Checked == true)
            {
                //Repetimos el mismo proceso anterior para todos los checkbox
                employeeType = objEmployees.cbVoluntario.Tag.ToString();
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;

                DataSet dsEmployeeType = daoEmployees.CheckboxFiltersTypeE(employeeType);
                objEmployees.dgvEmployees.DataSource = dsEmployeeType.Tables["viewEmployees"];
            }
            else if (objEmployees.cbBecario.Checked == true)
            {
                employeeType = objEmployees.cbBecario.Tag.ToString();
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;

                DataSet dsEmployeeType = daoEmployees.CheckboxFiltersTypeE(employeeType);
                objEmployees.dgvEmployees.DataSource = dsEmployeeType.Tables["viewEmployees"];
            }
            else if (objEmployees.cbInterno.Checked == true)
            {
                employeeType = objEmployees.cbInterno.Tag.ToString();
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;

                DataSet dsEmployeeType = daoEmployees.CheckboxFiltersTypeE(employeeType);
                objEmployees.dgvEmployees.DataSource = dsEmployeeType.Tables["viewEmployees"];
            }
            else
            {
                //en caso de que ninguno esté checkeado, todos estarán habilitados y se refrescará el datagrid
                objEmployees.cbTiempoCompleto.Enabled = true;
                objEmployees.cbVoluntario.Enabled = true;
                objEmployees.cbBecario.Enabled = true;
                objEmployees.cbInterno.Enabled = true;
                objEmployees.cbAdmin.Enabled = true;
                objEmployees.cbDesarrollo.Enabled = true;
                objEmployees.cbSoporte.Enabled = true;
                objEmployees.cbRecursosH.Enabled = true;
                objEmployees.cbMarketing.Enabled = true;
                objEmployees.cbActivo.Enabled = true;
                objEmployees.cbInactivo.Enabled = true;
                objEmployees.cbIncapacidad.Enabled = true;
                objEmployees.cbMaternidad.Enabled = true;
                RefreshDataGridEmployees();
            }
        }
        #endregion

        #region Método de filtración antiguo (Departamentos)
        public void CheckBoxFilterDepartment(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string department;
            //Si un checkbox esta activado, todos los demás no
            if (objEmployees.cbAdmin.Checked == true)
            {
                department = objEmployees.cbAdmin.Tag.ToString();
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                DataSet ds = daoEmployees.CheckboxFiltersDepartment(department);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else if (objEmployees.cbDesarrollo.Checked == true)
            {
                department = objEmployees.cbDesarrollo.Tag.ToString();
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                DataSet ds = daoEmployees.CheckboxFiltersDepartment(department);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else if (objEmployees.cbSoporte.Checked == true)
            {
                department = objEmployees.cbSoporte.Tag.ToString();
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                DataSet ds = daoEmployees.CheckboxFiltersDepartment(department);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else if (objEmployees.cbRecursosH.Checked == true)
            {
                department = objEmployees.cbRecursosH.Tag.ToString();
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                DataSet ds = daoEmployees.CheckboxFiltersDepartment(department);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else if (objEmployees.cbMarketing.Checked == true)
            {
                department = objEmployees.cbMarketing.Tag.ToString();
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                DataSet ds = daoEmployees.CheckboxFiltersDepartment(department);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else
            {
                //Si ningún checkbox esta marcado, todos estan activados y se refresca el datagrid
                objEmployees.cbTiempoCompleto.Enabled = true;
                objEmployees.cbVoluntario.Enabled = true;
                objEmployees.cbBecario.Enabled = true;
                objEmployees.cbInterno.Enabled = true;
                objEmployees.cbAdmin.Enabled = true;
                objEmployees.cbDesarrollo.Enabled = true;
                objEmployees.cbSoporte.Enabled = true;
                objEmployees.cbRecursosH.Enabled = true;
                objEmployees.cbMarketing.Enabled = true;
                objEmployees.cbActivo.Enabled = true;
                objEmployees.cbInactivo.Enabled = true;
                objEmployees.cbIncapacidad.Enabled = true;
                objEmployees.cbMaternidad.Enabled = true;
                RefreshDataGridEmployees();
            }
        }
        #endregion

        #region Método de filtración antiguo (Estados) 
        public void CheckboxFilterStatus(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOEmployees daoEmployees = new DAOEmployees();
            //Creamos una variable string que dependerá de que checkbox esta activado
            string status;
            //Si un checkbox esta activado, todos los demás no
            if (objEmployees.cbActivo.Checked == true)
            {
                status = objEmployees.cbActivo.Tag.ToString();
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;
                //se crea un dataset que capturará el que nos envía el método en el DAO y le enviamos la variable string que necesita
                DataSet ds = daoEmployees.CheckboxFiltersStatus(status);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else if (objEmployees.cbInactivo.Checked == true)
            {
                status = objEmployees.cbInactivo.Tag.ToString();
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;

                DataSet ds = daoEmployees.CheckboxFiltersStatus(status);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else if (objEmployees.cbIncapacidad.Checked == true)
            {
                status = objEmployees.cbIncapacidad.Tag.ToString();
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbMaternidad.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;

                DataSet ds = daoEmployees.CheckboxFiltersStatus(status);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else if (objEmployees.cbMaternidad.Checked == true)
            {
                status = "Maternidad";
                objEmployees.cbActivo.Checked = false;
                objEmployees.cbInactivo.Checked = false;
                objEmployees.cbIncapacidad.Checked = false;
                objEmployees.cbTiempoCompleto.Checked = false;
                objEmployees.cbVoluntario.Checked = false;
                objEmployees.cbBecario.Checked = false;
                objEmployees.cbInterno.Checked = false;
                objEmployees.cbAdmin.Checked = false;
                objEmployees.cbDesarrollo.Checked = false;
                objEmployees.cbSoporte.Checked = false;
                objEmployees.cbRecursosH.Checked = false;
                objEmployees.cbMarketing.Checked = false;

                DataSet ds = daoEmployees.CheckboxFiltersStatus(status);
                objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            }
            else
            {
                //Si ningún checkbox esta activo, todos estaran habilitados y se refrescará el datagrid.
                objEmployees.cbTiempoCompleto.Enabled = true;
                objEmployees.cbVoluntario.Enabled = true;
                objEmployees.cbBecario.Enabled = true;
                objEmployees.cbInterno.Enabled = true;
                objEmployees.cbAdmin.Enabled = true;
                objEmployees.cbDesarrollo.Enabled = true;
                objEmployees.cbSoporte.Enabled = true;
                objEmployees.cbRecursosH.Enabled = true;
                objEmployees.cbMarketing.Enabled = true;
                objEmployees.cbActivo.Enabled = true;
                objEmployees.cbInactivo.Enabled = true;
                objEmployees.cbIncapacidad.Enabled = true;
                objEmployees.cbMaternidad.Enabled = true;
                RefreshDataGridEmployees();
            }
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Model.DAO.CustomersDAO;
using PTC2024.View.Clientes;
using PTC2024.Controller.Helper;
using System.Windows.Forms;
using PTC2024.Model.DTO.CustomersDTO;

namespace PTC2024.Controller.CustomersController
{
    class ControllerAddCustomers
    {
        FrmAddCustomers objAddCustomers;
        bool emailValidation;

        public ControllerAddCustomers(FrmAddCustomers Vista)
        {
            objAddCustomers = Vista;
            // Evento para cargar los combos
            objAddCustomers.Load += new EventHandler(CargarCombos);
            //Evento para agregar un cliente
            objAddCustomers.BtnAgregarCliente.Click += new EventHandler(AgregarCliente);
            //Evento para cancelar el proceso
            objAddCustomers.BtnCancelar.Click += new EventHandler(CancelarProceso);
        }


        //Metodo para cargar el combo de tipo de empleado
        public void CargarCombos(object sender, EventArgs e)
        {
            DAOAddCustomers dAOAddCustomers = new DAOAddCustomers();


            DataSet dsTipodeCliente = dAOAddCustomers.ObtenerTiposEmpleado();
            //Obtiene un conjunto de datos del dataset del tipo de empleado
            //Asigna la tabla tbTypeC para llenar el comboBox
            objAddCustomers.comboTipodeCliente.DataSource = dsTipodeCliente.Tables["tbTypeC"];
            //Se mostrara el valor de los tipos de clientes al desplegar el comboBox
            objAddCustomers.comboTipodeCliente.DisplayMember = "customerType";
            //Identifica que valor tiene (1,2)
            objAddCustomers.comboTipodeCliente.ValueMember = "IdTypeC";


        }

        //Metodo para añadir un cliente
        public void AgregarCliente(object sender, EventArgs e)
        {
            //validaciones para que no queden en blanco
            if (!(string.IsNullOrEmpty(objAddCustomers.txtNombres.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtApellidos.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtDui.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtDireccion.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtEmail.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtTelefono.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.comboTipodeCliente.Text.Trim())
                ))
            {
                emailValidation = ValidateEmail();
                if (emailValidation == true)
                {


                    DAOAddCustomers dAOAddCustomers = new DAOAddCustomers();
                    CommonClasses commonClasses = new CommonClasses();

                    //Se le asgina el valor de los parametros 
                    dAOAddCustomers.Names = objAddCustomers.txtNombres.Text;
                    dAOAddCustomers.Lastnames = objAddCustomers.txtApellidos.Text;
                    dAOAddCustomers.DUI1 = objAddCustomers.txtDui.Text;
                    dAOAddCustomers.Address = objAddCustomers.txtDireccion.Text;
                    dAOAddCustomers.Email = objAddCustomers.txtEmail.Text;
                    dAOAddCustomers.Phone = objAddCustomers.txtTelefono.Text;
                    dAOAddCustomers.EmployeeType = int.Parse(objAddCustomers.comboTipodeCliente.SelectedValue.ToString());

                    //Se evalua el valorRespuesta del metodo register customer
                    int valorRespuesta = dAOAddCustomers.RegisterCustomer();

                    if (valorRespuesta == 1)
                    {//Si el valor es 1 se mostrara el mensaje
                        MessageBox.Show("Los datos se registraron de manera exitosa", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        objAddCustomers.Close();
                    }
                    else
                    {//Si el valor es diferente a 1 se mostrara el mensaje de error
                        MessageBox.Show("Los datos no pudieron ser registrados", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {//Se evalua si todos los cambos estan llenos 
                    MessageBox.Show("Todos los campos son obligatorios y existen algunos vacíos, llene todos los apartados.",
                                        "Proceso interrumpido",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                }

            }
        }

        //Metodo para cancelar el proceso
        //Unicamente cierra el formulario de añadir cliente y regresar al de clientes
        public void CancelarProceso(object sender, EventArgs e)
        {
            objAddCustomers.Close();
        }


        private bool ValidateEmail()
        {
            string email = objAddCustomers.txtEmail.Text.Trim();

            if ((!email.Contains("@")))
            {
                MessageBox.Show("El formato del correo es incorrecto, verifique que contenga '@'.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }
            //validación de dominio del correo
            string[] allowedDomains = { "gmail.com", "ricaldone.edu.sv" };
            //La variable domain guarda la cadena de carácteres que se presente después de la arroba en el campo de correo
            string domain = email.Substring(email.LastIndexOf('@') + 1);
            //Si la cadena de carácteres después de la arroba NO es uno de los dominios permitidos, nos envía un mensaje de error.
            if (!allowedDomains.Contains(domain))
            {
                MessageBox.Show("Dominio de correo inválido. \n El sistema solo admite los dominios '@gmail.com' y '@ricaldone.edu.sv'", "Dominio no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //Si no se detecta ningún fallo en el email, se devuelve directamente un true.
            return true;
        }
    }
}





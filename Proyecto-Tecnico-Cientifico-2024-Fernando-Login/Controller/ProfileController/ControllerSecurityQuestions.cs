using PTC2024.Model.DAO.ProfileDAO;
using PTC2024.View.ProfileSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.ProfileController
{
    internal class ControllerSecurityQuestions
    {
        //Creamos objeto del formulario
        FrmSecurityQuestions objSecurityQ;
        //Constructor del formulario
        public ControllerSecurityQuestions(FrmSecurityQuestions View, string username)
        {
            objSecurityQ = View;
            ChargeUser(username);
            objSecurityQ.btnSave.Click += new EventHandler(NewAnswers);
            objSecurityQ.btnVolver.Click += new EventHandler(GoBack);
        }

        //método para cargar el user en su textbox
        public void ChargeUser(string username)
        {
            objSecurityQ.txtUser.Text = username;
        }

        //Método para insertar las respuestas
        public void NewAnswers(object sender, EventArgs e)
        {
            //creamos método del DAO
            DAOSecurityQuestions daoSecurityQuestions = new DAOSecurityQuestions();
            //validación de campos vacíos.
            if (!(string.IsNullOrEmpty(objSecurityQ.txtFirstQ.Text.Trim()) ||
                 string.IsNullOrEmpty(objSecurityQ.txtSecondQ.Text.Trim()) ||
                 string.IsNullOrEmpty(objSecurityQ.txtThirdQ.Text.Trim())
                ))
            {
                //si todos los campos estan llenos pasamos a darle valor a los getters
                daoSecurityQuestions.FirstQ = objSecurityQ.txtFirstQ.Text.Trim();
                daoSecurityQuestions.SecondQ = objSecurityQ.txtSecondQ.Text.Trim();
                daoSecurityQuestions.ThirdQ = objSecurityQ.txtThirdQ.Text.Trim();
                daoSecurityQuestions.Username = objSecurityQ.txtUser.Text.Trim();
                //Ejecutamos el método del DAO
                int answer = daoSecurityQuestions.InsertAnswers();
                //Evaluamos la respuesta del método
                if (answer == 1)
                {
                    //si la respuesta es 1, la inserción se hizo correctamente
                    MessageBox.Show("Sus respuestas se registraron correctamente. \n\nAhora el método de recuperación de contraseña por preguntas de seguridad esta disponible para usted.", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objSecurityQ.Close();
                }
                else
                {
                    //si la respuesta no es 1, la inserción no se pudo realizar.
                    MessageBox.Show("Sus respuestas no pudieron ser ingresadas, inténtelo de nuevo", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben estar llenos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void GoBack(object sender, EventArgs e)
        {
            objSecurityQ.Close();
        }
    }
}

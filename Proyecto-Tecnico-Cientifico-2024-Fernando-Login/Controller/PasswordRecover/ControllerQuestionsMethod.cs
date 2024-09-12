using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Model.DAO.PasswordRecoverDAO;
using PTC2024.View.PasswordRecover;

namespace PTC2024.Controller.PasswordRecover
{
    internal class ControllerQuestionsMethod
    {
        FrmQuestionsMethod objQMethod;

        public ControllerQuestionsMethod(FrmQuestionsMethod Vista)
        {
            objQMethod = Vista;
            objQMethod.btnVolver.Click += new EventHandler(Back);
            objQMethod.btnConfirm.Click += new EventHandler(CheckRegister);
            objQMethod.txtUser.MouseDown += new MouseEventHandler(DisableContextMenu);
            objQMethod.txtUser.TextChanged += new EventHandler(UsernameMask);
        }

        public void Back(object sender, EventArgs e)
        {
            objQMethod.Close();
        }

        //Método que comprueba que el usuario tenga un registro de respuestas

        public void CheckRegister(object sender, EventArgs e)
        {
            //Creamos objeto del DAO
            DAOQuestionsMethod daoQuestionsMethod = new DAOQuestionsMethod();
            //Damos el valor al getter del username
            daoQuestionsMethod.Username = objQMethod.txtUser.Text.Trim();
            //Primero verificamos si el usuario existe en la base con el método CheckUser
            bool answerUser = daoQuestionsMethod.CheckUser();
            if (answerUser == true)
            {
                //Si la respuesta es true, el usuario si existe
                //Ahora evaluamos si tiene un registro de respuestas
                bool answerQuestions = daoQuestionsMethod.CheckSecurityQ();
                if (answerQuestions == true)
                {
                    //si la respuesta es true, significa que si había configurado sus respuestas, y le damos paso al siguiente formulario.
                    FrmNextQuestionsMethod openForm = new FrmNextQuestionsMethod(objQMethod.txtUser.Text.Trim());
                    objQMethod.Hide();
                    openForm.ShowDialog();
                }
                else
                {
                    //Si la respuesta es false, el usuario no había respondido antes a las preguntas
                    MessageBox.Show("Este usuario no ha configurado sus preguntas de seguridad anteriormente.", "Sin respuestas", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                //Si la respuesta es false, el usuario no existe
                MessageBox.Show("No existe ningún empleado registrado con ese usuario", "Usuario inexistente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DisableContextMenu(object sender, MouseEventArgs e)
        {
            // Desactiva el menú contextual al hacer clic derecho
            if (e.Button == MouseButtons.Right)
            {
                ((Bunifu.UI.WinForms.BunifuTextBox)sender).ContextMenu = new ContextMenu();  // Asigna un menú vacío
            }
        }
        public void UsernameMask(object sender, EventArgs e)
        {
            //Almacena la posición original del cursor
            int cursorPosition = objQMethod.txtUser.SelectionStart;

            //Filtra el texto del TextBox para eliminar caracteres especiales
            objQMethod.txtUser.Text = new string(objQMethod.txtUser.Text.Where(c => char.IsLetterOrDigit(c)).ToArray());

            //Restaura la posición del cursor
            objQMethod.txtUser.SelectionStart = cursorPosition;
        }

    }
}

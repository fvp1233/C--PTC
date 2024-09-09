using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Model.DAO.PasswordRecoverDAO;
using PTC2024.View.Alerts;
using PTC2024.View.PasswordRecover;

namespace PTC2024.Controller.PasswordRecover
{
    internal class ControllerNextQuestionsMetod
    {
        //Creamos instancia del formulario
        FrmNextQuestionsMethod objQuestionsM;

        //Constructor
        public ControllerNextQuestionsMetod(FrmNextQuestionsMethod View, string username)
        {
            objQuestionsM = View;
            ChargeValues(username);
            objQuestionsM.btnVolver.Click += new EventHandler(Back);
            objQuestionsM.btnConfirm.Click += new EventHandler(CheckAnswers);
            objQuestionsM.txtFirstAnswer.MouseDown += new MouseEventHandler(DisableContextMenu);
            objQuestionsM.txtSecondAnswer.MouseDown += new MouseEventHandler(DisableContextMenu);
            objQuestionsM.txtThirdAnswer.MouseDown += new MouseEventHandler(DisableContextMenu);
        }

        public void Back(object sender, EventArgs e)
        {           
            objQuestionsM.Close();
        }

        //Método para cargar el user en su textbox
        public void ChargeValues(string username)
        {
            objQuestionsM.txtUser.Text = username;
        }

        //Método para verificar las respuestas
        public void CheckAnswers (object sender, EventArgs e)
        {
            //creamos objetod del DAO
            DAONextQuestionsMetod daoNextQM = new DAONextQuestionsMetod();
            //Damos valor a los getters del DAO
            daoNextQM.FirstAnswer = objQuestionsM.txtFirstAnswer.Text.Trim();
            daoNextQM.SecondAnswer = objQuestionsM.txtSecondAnswer.Text.Trim();
            daoNextQM.ThirdAnswer = objQuestionsM.txtThirdAnswer.Text.Trim();
            daoNextQM.Username = objQuestionsM.txtUser.Text.Trim();
            //Ejecutamos el método del DAO
            bool answer = daoNextQM.ValidateAnswers();
            //validamos la respuesta del método
            if (answer == true)
            {
                //si la respuesta es true, significa que todas las respuestas coinciden, por lo que llevamos al usuario a cambiar su contraseña.
                MessageBox.Show("Las respuestas son correctas, proceda a cambiar su contraseña.", "Respuestas correctas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Llamamos al form para cambiar la contraseña
                FrmChangePassword openForm = new FrmChangePassword(objQuestionsM.txtUser.Text.Trim());
                objQuestionsM.Dispose();
                objQuestionsM.Close();
                openForm.ShowDialog();
                
            }
            else
            {
                //si la respuesta es false, las respuestas no coinciden con el registro.
                MessageBox.Show("Las respuestas no coinciden con el registro, inténtelo de nuevo", "Respuestas incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Controller.Helper;
using PTC2024.Controller.PasswordRecover;

namespace PTC2024.View.PasswordRecover
{
    public partial class FrmNextQuestionsMethod : Form
    {
        public FrmNextQuestionsMethod(string username)
        {
            InitializeComponent();
            //LLamamos a su controlador
            ControllerNextQuestionsMetod control = new ControllerNextQuestionsMetod(this, username);
            Region = Region.FromHrgn(CommonClasses.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Verificar si Ctrl+C o Ctrl+V se presionaron
            if (keyData == (Keys.Control | Keys.C) || keyData == (Keys.Control | Keys.V))
            {
                //Retorna true para ignorar el comando y evitar la acción de copiar o pegar
                return true;
            }

            //Llamar al método base para manejar otras teclas
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

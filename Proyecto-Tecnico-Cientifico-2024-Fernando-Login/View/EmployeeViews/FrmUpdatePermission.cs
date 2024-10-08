﻿using PTC2024.Controller.Helper;
using PTC2024.Controller.PayrollsController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.EmployeeViews
{
    public partial class FrmUpdatePermission : Form
    {
        public FrmUpdatePermission(int idEmployee, int idPermission, DateTime start, DateTime end, string context, string status, string typeP, int idType, int idStatus)
        {
            InitializeComponent();
            ControllerUpdatePermission objPermission = new ControllerUpdatePermission(this, idEmployee, idPermission, start, end, context, status, typeP, idType, idStatus);
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

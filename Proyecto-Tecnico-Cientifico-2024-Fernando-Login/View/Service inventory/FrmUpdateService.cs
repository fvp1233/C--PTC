﻿using PTC2024.Controller.Helper;
using PTC2024.Controller.ServicesController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.View.Service_inventory
{
    public partial class FrmUpdateService : Form
    {
        public FrmUpdateService(int id ,string name, string description, double amount, string category, int idCategory)
        {
            InitializeComponent();
            ControllerUpdateService update = new ControllerUpdateService(this, id, name, description, amount, category, idCategory);
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

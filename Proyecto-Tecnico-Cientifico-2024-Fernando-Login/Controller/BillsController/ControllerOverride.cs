using PTC2024.Controller.Helper;
using PTC2024.Model;
using PTC2024.Model.DAO.BillsDAO;
using PTC2024.Model.DAO.LogInDAO;
using PTC2024.View.Alerts;
using PTC2024.View.BillsViews;
using PTC2024.View.Facturacion;
using PTC2024.View.formularios.inicio;
using PTC2024.View.Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.BillsController
{
    internal class ControllerOverride
    {
        FrmOverrideBill objoverrideBill;
        int confirmValue;
        //CONSTRUCTOR DEL FORMULARIO
        public ControllerOverride(FrmOverrideBill View)
        {
            objoverrideBill = View;
            //Eventos para los clicks de los botones
            objoverrideBill.btnback.Click += new EventHandler(CancelProcess);
            objoverrideBill.btnConfirm.Click += new EventHandler(ConfirmProcess);
            objoverrideBill.txtPasswordBunifu.Click += new EventHandler(HidePassword);

        }

        public void CancelProcess(object sender, EventArgs e)
        {
            CancelProcessValue();
            objoverrideBill.Close();
        }

        public void ConfirmProcess(object sender, EventArgs e)
        {
            ConfirmProcessValue();
            Access();
            objoverrideBill.Close();
        }
        public void Access()
        {
            switch (SessionVar.Access)
            {
                case "Administrador":
                    break;
            }
        }

        public int CancelProcessValue()
        {
            confirmValue = 0;
            return confirmValue;
        }

        public int ConfirmProcessValue()
        {
            confirmValue = 1;
            return confirmValue;
        }

        public int ConfirmValue
        {
            get { return confirmValue; }

        }
        private void DataAccess(object sender, EventArgs e)
        {
            DAOLogin DAOData = new DAOLogin();
            CommonClasses common = new CommonClasses();
            string encriptedpass = common.ComputeSha256Hash(objoverrideBill.txtPasswordBunifu.Text);
            DAOData.Password = encriptedpass;
            DAOData.UserStatus = 1;
            bool answer = DAOData.ValidarLogin();
            if (answer == true)
            {
                objoverrideBill.Hide();

            }
            else
            {
                MessageBox.Show("Datos incorrectos", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void HidePassword(object sender, EventArgs e)
        {
            objoverrideBill.txtPasswordBunifu.PasswordChar = '*';
            objoverrideBill.txtPasswordBunifu.Visible = true;
        }

        public void InitialCharge(object sender, EventArgs e)
        {
            objoverrideBill.txtPasswordBunifu.PasswordChar = '*';
        }
    }
    /*
    FrmOverrideBill objOverride;
    private int confirmValue;
    private int IdBill1; // ID de la factura a anular

    // Constructor del formulario
    public ControllerOverride(FrmOverrideBill view, int IdBill1)
    {
        objOverride = view;
        this.IdBill1 = IdBill1;

        // Eventos para los clicks de los botones
        objOverride.btnback.Click += new EventHandler(CancelProcess);
        objOverride.btnConfirm.Click += new EventHandler(ConfirmProcess);
        objOverride.txtPasswordBunifu.Enter += new EventHandler(HidePassword);
        objOverride.Shown += new EventHandler(InitialCharge);
    }

    public void CancelProcess(object sender, EventArgs e)
    {
        confirmValue = 0;
        objOverride.Close();
    }

    public void ConfirmProcess(object sender, EventArgs e)
    {
        confirmValue = 1;

            AnularFactura();
        Access();
        objOverride.Close();
    }
    public void Access()
    {
        switch (SessionVar.Access)
        {
            case "Administrador":
                break;
        }
    }
    public int CancelProcessValue()
    {
        confirmValue = 0;
        return confirmValue;
    }

    public int ConfirmProcessValue()
    {
        confirmValue = 1;
        return confirmValue;
    }

    public int ConfirmValue
    {
        get { return confirmValue; }

    }
    private void DataAccess(object sender, EventArgs e)
    {
        DAOLogin DAOData = new DAOLogin();
        CommonClasses common = new CommonClasses();
        string encriptedpass = common.ComputeSha256Hash(objOverride.txtPasswordBunifu.Text);
        DAOData.Password = encriptedpass;
        DAOData.UserStatus = 1;
        bool answer = DAOData.ValidarLogin();
        if (answer == true)
        {
            objOverride.Hide();

        }
        else
        {
            MessageBox.Show("Datos incorrectos", "Vuelva a ingresar la contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    private void AnularFactura()
    {
        DAOBills daoBills = new DAOBills();
        if (daoBills.OverBill(IdBill1))
        {
            MessageBox.Show("Factura anulada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Ocurrió un error al intentar anular la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            confirmValue = 0; 
        }
    }
    public void HidePassword(object sender, EventArgs e)
    {
        objOverride.txtPasswordBunifu.PasswordChar = '*';
        objOverride.txtPasswordBunifu.Visible = true;
    }

    public void InitialCharge(object sender, EventArgs e)
    {
        objOverride.txtPasswordBunifu.PasswordChar = '*';
    }
}
    */
    /*
    FrmOverrideBill objoverrideBill;
    int confirmValue;
    //CONSTRUCTOR DEL FORMULARIO
    public ControllerOverride(FrmOverrideBill View)
    {
        objoverrideBill = View;
        //Eventos para los clicks de los botones
        objoverrideBill.btnback.Click += new EventHandler(CancelProcess);
        objoverrideBill.btnConfirm.Click += new EventHandler(ConfirmProcess);
        objoverrideBill.txtPasswordBunifu.Click += new EventHandler(HidePassword);

    }

    public void CancelProcess(object sender, EventArgs e)
    {
        CancelProcessValue();
        objoverrideBill.Close();
    }

    public void ConfirmProcess(object sender, EventArgs e)
    {
        ConfirmProcessValue();
        Access();
        objoverrideBill.Close();
    }
    public void Access()
    {
        switch (SessionVar.Access)
        {
            case "Administrador":
                break;
        }
    }

    public int CancelProcessValue()
    {
        confirmValue = 0;
        return confirmValue;
    }

    public int ConfirmProcessValue()
    {
        confirmValue = 1;
        return confirmValue;
    }

    public int ConfirmValue
    {
        get { return confirmValue; }

    }
    private void DataAccess(object sender, EventArgs e)
    {
        DAOLogin DAOData = new DAOLogin();
        CommonClasses common = new CommonClasses();
        string encriptedpass = common.ComputeSha256Hash(objoverrideBill.txtPasswordBunifu.Text);
        DAOData.Password = encriptedpass;
        DAOData.UserStatus = 1;
        bool answer = DAOData.ValidarLogin();
        if (answer == true)
        {
            objoverrideBill.Hide();

        }
        else
        {
            MessageBox.Show("Datos incorrectos", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    public void HidePassword(object sender, EventArgs e)
    {
        objoverrideBill.txtPasswordBunifu.PasswordChar = '*';
        objoverrideBill.txtPasswordBunifu.Visible = true;
    }

    public void InitialCharge(object sender, EventArgs e)
    {
        objoverrideBill.txtPasswordBunifu.PasswordChar = '*';
    }
}
*/


}

using PTC2024.View.Maintenance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.MaintenanceDAO;

namespace PTC2024.Controller.MaintenanceController
{
    internal class ControllerBusinessConfiguration
    {
        FrmBusinessConfiguration objBusinessConf;
        public ControllerBusinessConfiguration(FrmBusinessConfiguration View)
        {
            objBusinessConf = View;
            objBusinessConf.Load += new EventHandler(LoadData);
        }
        public void LoadData(object sender, EventArgs e)
        {
            DAOBusinessConfiguration objDao = new DAOBusinessConfiguration();
            objBusinessConf.picBusiness.Image = ByteArrayToImage(BusinessVar.BusinessImg);
            objBusinessConf.txtBusinessName.Text = BusinessVar.BusinessName;
            objBusinessConf.txtAdress.Text = BusinessVar.BusinessAdress;
            objBusinessConf.txtEmail.Text = BusinessVar.BusinessEmail;
            objBusinessConf.txtPhone.Text = BusinessVar.BusinessPhone;
            objBusinessConf.txtPBX.Text = BusinessVar.BusinessPBX;
            objBusinessConf.txtID.Text = BusinessVar.IdBusiness.ToString();
            objBusinessConf.txtID.Visible = false;
        }
        public void UpdateInfoBusiness()
        {
            DAOBusinessConfiguration DAObusiness = new DAOBusinessConfiguration();
            DAObusiness.IdBusiness = BusinessVar.IdBusiness;
            DAObusiness.NameBusiness = objBusinessConf.txtBusinessName.Text.Trim();
            DAObusiness.AddressBusiness = objBusinessConf.txtAdress.Text.Trim();
            DAObusiness.PhoneBusiness = objBusinessConf.txtPBX.Text.Trim();
            DAObusiness.PbxBusiness = objBusinessConf.txtPBX.Text.Trim();
        }
        public Image ByteArrayToImage(byte[] byteArray)
        {
            Image imageDefaul = objBusinessConf.picBusiness.Image;
            if (byteArray == null || byteArray.Length == 0)
            {
                // En caso de que byteArrary sea nulo o este vacio         
                return imageDefaul; //devolvemos la imagen por defecto que trae el picturebox
            }

            MemoryStream ms = new MemoryStream(byteArray);
            return Image.FromStream(ms);
        }

    }
}

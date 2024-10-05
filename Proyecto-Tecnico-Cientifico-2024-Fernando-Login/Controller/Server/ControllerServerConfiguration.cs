using PTC2024.Controller.Helper;
using PTC2024.Model;
using PTC2024.Model.DTO.HelperDTO;
using PTC2024.View.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PTC2024.Controller.Server
{
    internal class ControllerServerConfiguration
    {
        FrmServerConfiguration objServer;

        public ControllerServerConfiguration(FrmServerConfiguration View, int origin)
        {
            objServer = View;
            VerifyOrigin(origin);
            objServer.rdFalse.CheckedChanged += new EventHandler(rdFalseMarked);
            objServer.rdTrue.CheckedChanged += new EventHandler(rdTrueMarked);
            objServer.txtDB.MouseDown += new MouseEventHandler(DisableContextMenu);
            objServer.txtServer.MouseDown += new MouseEventHandler(DisableContextMenu);
            objServer.txtPasswordAuth.MouseDown += new MouseEventHandler(DisableContextMenu);
            objServer.txtSqlAuth.MouseDown += new MouseEventHandler(DisableContextMenu);
            objServer.btnSave.Click += new EventHandler(SaveConfig);
            if (origin == 1)
            {
                objServer.FormClosed += new FormClosedEventHandler(CloseProgram);
            }
        }

        //Método para cerrar todo el programa en caso de que el usuario no coloque ningun valor y solo cierre el formulario cuando no existe ningún documento XML
        public void CloseProgram(Object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        public void VerifyOrigin(int origin)
        {
            if ((origin == 2))
            {
                objServer.txtServer.Text = DTOXMLConnection.Server;
                objServer.txtDB.Text = DTOXMLConnection.Database;
                objServer.txtSqlAuth.Text = DTOXMLConnection.User;
                objServer.txtPasswordAuth.Text = DTOXMLConnection.Password;

            }
        }

        void rdFalseMarked(object sender, EventArgs e)
        {
            if (objServer.rdFalse.Checked == true)
            {
                objServer.txtPasswordAuth.Enabled = false;
                objServer.txtSqlAuth.Enabled = false;              
            }
        }

        void rdTrueMarked(object sender, EventArgs e)
        {
            if (objServer.rdTrue.Checked == true)
            {
                objServer.txtPasswordAuth.Enabled = true;
                objServer.txtSqlAuth.Enabled = true;                
            }
        }

        public void SaveConfig(object sender, EventArgs e)
        {
            CreateXMLConfig();
        }

        //CONFIGURACIÓN DEL ARCHIVO XML
        public void CreateXMLConfig()
        {
            CommonClasses common = new CommonClasses();
            try
            {
                //Objeto tipo documento XML
                XmlDocument xmlDoc = new XmlDocument();


                //Declaración xml
                XmlDeclaration decl = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);


                //Creamos elemento raíz
                XmlElement root = xmlDoc.CreateElement("Conn");
                xmlDoc.AppendChild(root);


                //CREAR LOS ELEMENTOS HIJOS Y AÑADIRLOS AL ELEMENTO RAÍZ
                    //SERVIDOR
                XmlElement server = xmlDoc.CreateElement("Server");
                string encodedServer = common.EncodeString(objServer.txtServer.Text.Trim());

                //añadimos el texto codificado al elemento hijo
                server.InnerText = encodedServer;
                root.AppendChild(server);

                    //DATABASE
                XmlElement database = xmlDoc.CreateElement("Database");
                string encodedDatabase = common.EncodeString(objServer.txtDB.Text.Trim());
                database.InnerText = encodedDatabase;
                root.AppendChild(database);

                if(objServer.rdTrue.Checked == true)
                {
                    XmlElement sqlAuth = xmlDoc.CreateElement("SqlAuth");
                    string encodedSqlAuth = common.EncodeString(objServer.txtSqlAuth.Text.Trim());
                    sqlAuth.InnerText = encodedSqlAuth;
                    root.AppendChild(sqlAuth);

                    XmlElement sqlAuthPassword = xmlDoc.CreateElement("SqlPass");
                    string encodedSqlAuthPassword = common.EncodeString(objServer.txtPasswordAuth.Text.Trim());
                    sqlAuthPassword.InnerText = encodedSqlAuthPassword;
                    root.AppendChild(sqlAuthPassword);
                }
                else
                {
                    XmlElement sqlAuth = xmlDoc.CreateElement("SqlAuth");
                    sqlAuth.InnerText = string.Empty;
                    root.AppendChild(sqlAuth);

                    XmlElement sqlAuthPassword = xmlDoc.CreateElement("SqlPass");
                    sqlAuthPassword.InnerText = string.Empty;
                    root.AppendChild(sqlAuthPassword);
                }

                //Objeto tipo conexión para hacer una prueba de conexión con los nuevos valores
                SqlConnection connection = dbContext.VerifyConnection(objServer.txtServer.Text.Trim(), objServer.txtDB.Text.Trim(), objServer.txtSqlAuth.Text.Trim(), objServer.txtPasswordAuth.Text.Trim());
                if (connection != null)
                {
                    xmlDoc.Save("serverConfig.xml");
                    DTOXMLConnection.Server = objServer.txtServer.Text.Trim();
                    DTOXMLConnection.Database = objServer.txtDB.Text.Trim();
                    DTOXMLConnection.User = objServer.txtSqlAuth.Text.Trim();
                    DTOXMLConnection.Password = objServer.txtPasswordAuth.Text.Trim();
                    MessageBox.Show("El archivo con las credenciales de conexión se creó con éxito. \nInicie el programa nuevamente.","Archivo de conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objServer.Dispose();
                }
                else
                {
                    MessageBox.Show("Los valores ingresados no generan una conexión con ninguna base de datos.", "Archivo de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (XmlException ex)
            {
                MessageBox.Show($"{ex.Message}, no se pudo crear el archivo de configuración.", "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

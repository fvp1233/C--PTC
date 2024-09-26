using PTC2024.Model;
using PTC2024.Model.DTO.HelperDTO;
using PTC2024.View.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PTC2024.Controller.Helper
{
    internal class XMLConnection
    {
        //Método para leer el archivo XML con los valores de conexión
        public void ReadXMLDocument()
        {
            CommonClasses common = new CommonClasses();
            string path = Path.Combine(Directory.GetCurrentDirectory().ToString(), "serverConfig.xml");
            if (File.Exists(path))
            {
                
                //Objeto tipo XML
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(path);

                //Despúes de haber cargado el archivo XML leemos lo que contiene cada nodo del archivo

                XmlNode root = xmlDocument.DocumentElement;
                XmlNode serverNode = root.SelectSingleNode("Server/text()");
                XmlNode databaseNode = root.SelectSingleNode("Database/text()");
                XmlNode sqlAuthNode = root.SelectSingleNode("SqlAuth/text()");
                XmlNode sqlPassNode = root.SelectSingleNode("SqlPass/text()");

                string codeServer = serverNode.Value;
                string codeDatabase = databaseNode.Value;
                DTOXMLConnection.Server = common.DecodeString(codeServer);
                DTOXMLConnection.Database = common.DecodeString(codeDatabase);
                
                if (sqlAuthNode != null && sqlPassNode != null)
                {
                    string codeUser = sqlAuthNode.Value;
                    string codeP = sqlPassNode.Value;

                    DTOXMLConnection.User = common.DecodeString(codeUser);
                    DTOXMLConnection.Password = common.DecodeString(codeP);

                }
                else
                {
                    DTOXMLConnection.User = common.DecodeString(string.Empty);
                    DTOXMLConnection.Password = common.DecodeString(string.Empty);
                }
            }
            else
            {
                //Si el archivo no existe en las carpetas del programa entonces mostramos el formulario para la creación de uno.
                FrmServerConfiguration objForm = new FrmServerConfiguration(1);
                objForm.ShowDialog();
            }
        }
    }
}

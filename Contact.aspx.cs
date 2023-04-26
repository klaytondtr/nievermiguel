using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ListaConvidados
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSalvar_Click(object sender, EventArgs e)
        {
            string pagante = "Nao";
            string path = Server.MapPath("~/xml/convidados.xml");
            if (CheckBoxPagante.Checked)
            {
                pagante = "Sim";
            }
            try
            {
                
                var contact = new XElement("Convidado", new XElement("Nome", TextBoxNome.Text), new XElement("Pagante", pagante), new XElement("Situacao", "Nao Convidado"));
                var doc = new XDocument();

                if (File.Exists(path))
                {
                    doc = XDocument.Load(path);
                    doc.Element("Convidados").Add(contact);
                }
                else
                {
                    doc = new XDocument(new XElement("Convidados", contact));
                }
                doc.Save(path);
                //XmlTextWriter writer = new XmlTextWriter(path, null);

                ////inicia o documento xml
                //writer.WriteStartDocument();
                ////escreve o elmento raiz
                //writer.WriteStartElement("Convidado");
                ////Escreve os sub-elementos
                //writer.WriteElementString("Nome", TextBoxNome.Text);
                //writer.WriteElementString("Pagante", pagante);
                //writer.WriteElementString("Situacao", "Nao Convidado");
                //// encerra o elemento raiz
                //writer.WriteEndElement();
                ////Escreve o XML para o arquivo e fecha o objeto escritor
                //writer.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alerta", "alert('Salvo Com Sucesso!!!')", true);
            }
            catch (Exception ex)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");

        }
    }
}
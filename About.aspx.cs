using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace ListaConvidados
{
    public partial class About : Page
    {
        XElement rootElem;
        IEnumerable<XElement> prodElementos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaTudo();
            }
        }

   
        public void VerificaGrid()
        {
            int totalConfirmado = 0, totalAguardando = 0, totalRemovido = 0, totalNaoConvidado = 0, totalConfirmadopagantes = 0, totalAguardandopagantes = 0, totalRemovidopagantes = 0, totalNaoConvidadopagantes = 0; 
            foreach (GridViewRow linha in GridViewLista.Rows)
            {
                ((DropDownList)linha.Cells[3].Controls[1]).SelectedValue = linha.Cells[2].Text;
                linha.Cells[2].Visible = false;
                if (((DropDownList)linha.Cells[3].Controls[1]).SelectedValue == "Nao Convidado")
                {
                    linha.BackColor = Color.White;
                    totalNaoConvidado++;
                    if(linha.Cells[1].Text == "Sim")
                    {
                        totalNaoConvidadopagantes++;
                    }
                }
                else
                {
                    if (((DropDownList)linha.Cells[3].Controls[1]).SelectedValue == "Confirmado")
                    {
                        linha.BackColor = Color.FromArgb(242, 255, 250);
                        totalConfirmado++;
                        if (linha.Cells[1].Text == "Sim")
                        {
                            totalConfirmadopagantes++;
                        }
                    }
                    else
                    {
                        if (((DropDownList)linha.Cells[3].Controls[1]).SelectedValue == "Removido")
                        {
                            linha.BackColor = Color.FromArgb(255, 228, 225);
                            totalRemovido++;
                            if (linha.Cells[1].Text == "Sim")
                            {
                                totalRemovidopagantes++;
                            }
                        }
                        else
                        {
                            if (((DropDownList)linha.Cells[3].Controls[1]).SelectedValue == "Aguardando")
                            {
                                linha.BackColor = Color.FromArgb(255, 255, 225);
                                totalAguardando++;
                                if (linha.Cells[1].Text == "Sim")
                                {
                                    totalAguardandopagantes++;
                                }
                            }
                        }
                    }
                }
            }
            LabelTotalAguardando.Text = "Total Aguardando: " + totalAguardando.ToString();
            LabelTotalConfirmados.Text = "Total Confirmados: " + totalConfirmado.ToString();
            LabelTotalRemovidos.Text = "Total Removidos: " + totalRemovido.ToString();
            LabelTotalNaoConvidados.Text = "Total Não Convidados: " + totalNaoConvidado.ToString();
            LabelTotalAguardandoPagantes.Text = "Total Aguardando Pagantes: " + totalAguardandopagantes.ToString();
            LabelTotalConfirmadosPagantes.Text = "Total Confirmados Pagantes: " + totalConfirmadopagantes.ToString();
            LabelTotalRemovidosPagantes.Text = "Total Removidos Pagantes: " + totalRemovidopagantes.ToString();
            LabelTotalNaoConvidadosPagantes.Text = "Total Não Convidados Pagantes: " + totalNaoConvidadopagantes.ToString();
        }

        protected void GridViewLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void ButtonSalvar_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/xml/convidados.xml");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            foreach (GridViewRow linha in GridViewLista.Rows)
            {
                var contact = new XElement("Convidado", new XElement("Nome", linha.Cells[0].Text), new XElement("Pagante", linha.Cells[1].Text), new XElement("Situacao", ((DropDownList)linha.Cells[3].Controls[1]).SelectedValue));
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
                CarregaTudo();
            }
        }
        public void CarregaTudo()
        {
            string caminhoArquivo = Server.MapPath("~/xml/convidados.xml");

            List<Convidados> convidados = new List<Convidados>();
            Convidados convidado = new Convidados();
            int controle = 0;
            using (XmlTextReader xmlReader = new XmlTextReader(caminhoArquivo))
            {

                while (xmlReader.Read())
                {
                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Element:

                            break;
                        case XmlNodeType.Text:
                            if (controle == 0)
                            {
                                convidado.Nome = xmlReader.Value;
                                controle++;
                            }
                            else
                            {
                                if (controle == 1)
                                {
                                    convidado.Pagante = xmlReader.Value;
                                    controle++;
                                }
                                else
                                {
                                    if (controle == 2)
                                    {
                                        convidado.Situacao = xmlReader.Value;
                                        convidados.Add(convidado);
                                        controle = 0;
                                        convidado = new Convidados();
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            ;
                            break;
                        case XmlNodeType.EndElement:


                            break;
                    }
                }
            }

            DataTable taskTable = new DataTable("TaskList");
            // Create the columns.
            taskTable.Columns.Add("Nome", typeof(string));
            taskTable.Columns.Add("Pagante", typeof(string));
            taskTable.Columns.Add("Situacao", typeof(string));



            foreach (Convidados convidado1 in convidados){
                DataRow tableRow = taskTable.NewRow();
                tableRow["Nome"] = convidado1.Nome;
                tableRow["Pagante"] = convidado1.Pagante;
                tableRow["Situacao"] = convidado1.Situacao;
                taskTable.Rows.Add(tableRow);
            }
            Session["TaskTable"] = taskTable;

            GridViewLista.DataSource = convidados;
            GridViewLista.DataBind();

            VerificaGrid();
        }

        protected void GridViewLista_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = Session["TaskTable"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridViewLista.DataSource = Session["TaskTable"];
                GridViewLista.DataBind();
            }

        }

        protected void GridViewLista_Sorted(object sender, EventArgs e)
        {
            VerificaGrid();
        }
        private string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");

        }
    }
}
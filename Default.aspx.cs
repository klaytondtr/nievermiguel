using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListaConvidados
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Contact.aspx");

        }

        protected void ButtonLista_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/About.aspx");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 

namespace ProjetoFinal
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Remove o cookie com o nome de Login
            Response.Cookies["login"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["id_user"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["nomeC"].Expires = DateTime.Now.AddDays(-1);

            // Redireciona para a página de Login
            Response.Redirect("~/login.aspx");
        }


    }
}
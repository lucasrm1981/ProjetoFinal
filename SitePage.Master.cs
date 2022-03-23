using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal
{
    public partial class SitePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["login"] == null)
            {                
               Response.Redirect("~/login.aspx");              

            } 
            else 
            {
                getPropriedadesCookie("login");
            }

        }

        public void getPropriedadesCookie(string nomeCookie)
        {
            // Obtém a requisição com dos dados do cookie
            HttpCookie cookie = ObterRequisicaoCookie(nomeCookie);
            if (cookie != null)
            {
                // Separa os valores das propriedade
                string valores = cookie.Value.ToString();
                
                    // Escreve os valores das propriedades encontradas
                    ltrCookie.Text = valores;                
            }
           else ltrCookie.Text = string.Empty;
        }

        /*
         * Método 03
         * Método responsável por Obter a requisição HttpCookie de um determinado cookie caso ele exista
         */
        private HttpCookie ObterRequisicaoCookie(string nomeCookie)
        {
            try
            {
                // Retornando o cookie caso exista
                return this.Page.Request.Cookies[nomeCookie];
            }
            catch
            {
                // Caso não exista o cookie informado, retorna NULL
                return null;
            }
        }

        /*
        * Método 04
        * Método responsável por remover um determinado cookie
        */
        private void removerCookie(string nomeCookie)
        {
            // Removendo o Cookie
            Response.Cookies[nomeCookie].Expires = DateTime.Now.AddDays(-1);
        }


       
        protected void btnLer_Click(object sender, EventArgs e)
        {
            getPropriedadesCookie("login");
        }

        public void btnRemoverCookie_Click(object sender, EventArgs e)
        {
            removerCookie("login");
            // Label ltrCookie propriedade text = vazio
            ltrCookie.Text = string.Empty;
        }

       
    }
}
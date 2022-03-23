using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getPropriedadesCookie("login");

            //capturar a string de conexão
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from documento where id_usuario = @email";
            cmd.Parameters.AddWithValue("email", ltrCookie.Text);
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            // Encontrou um registro que satisfez a condição           

            
            // Enquanto exixtir Registro Cria as Linhas na tabela
            while (registro.Read())
            {
                string id_doc = "<tr><td>" + registro["Id_documento"].ToString() + "</td>";
              
                string titulo_doc = "<td>" + registro["titulo"].ToString() + "</td>";
                
                string caminho_doc = "<td><a href='uploads/" + registro["caminho"].ToString() + "'>Download</a></td>";
               
                string data_criacao_doc = "<td>" + registro["data_criacao"].ToString() + "</td>";
               
                string id_usuario_doc = "<td>" + registro["id_usuario"].ToString() + "</td>";

                string remover = "<td><a href='deletar.aspx?id=" + registro["Id_documento"].ToString() + "'>Deletar</a></td></tr>";


                row_table.InnerHtml += id_doc + titulo_doc + caminho_doc + data_criacao_doc + id_usuario_doc + remover;
            } 

            /*
            //Cria o cookie do Login Com email do Banco de Dados
            string loginCookie = registro["email"].ToString();
            HttpCookie login = new HttpCookie("login", loginCookie);
            Response.Cookies.Add(login);

            //Cria o cookie do id do usuário
            string IdUserCookie = registro["Id_user"].ToString();
            // Preaparaçao para o Navegador
            HttpCookie IdUser = new HttpCookie("id_user", IdUserCookie);
            // Inserção do cookie no navegador
            Response.Cookies.Add(IdUser);

            //Cria o cookie do id do usuário
            string nomeCookie = registro["nome"].ToString(); // Resgata no Banco
            HttpCookie nomeC = new HttpCookie("nomeC", nomeCookie);
            Response.Cookies.Add(nomeC);

            //string cookie = Request.Cookies["login"];

            //direcionar para a pagina principal
            Response.Redirect("~/index.aspx");/**
        }*/
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

        
    }
}
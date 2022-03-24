using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal
{
    public partial class deletar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string valor = Request.QueryString["id"];
            
            getPropriedadesCookie("login");

            //capturar a string de conexão
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");


            //Seleciona as informacoes para o log
            System.Configuration.ConnectionStringSettings connString0;
            connString0 = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];            
            //cria um objeto de conexão
            SqlConnection con0 = new SqlConnection();
            con0.ConnectionString = connString0.ToString();
            SqlCommand cmd0 = new SqlCommand();
            cmd0.Connection = con0;
            cmd0.CommandText = "select * from documento where id_documento = @valor and id_usuario = @email";
            cmd0.Parameters.AddWithValue("valor", valor);
            cmd0.Parameters.AddWithValue("email", ltrCookie.Text);

            con0.Open();
            cmd0.ExecuteNonQuery();
            SqlDataReader registro0 = cmd0.ExecuteReader();
            string titulo_doc = "";
            string nameFile = "";
            if (registro0.Read())
            {
                titulo_doc = registro0["titulo"].ToString();
                nameFile = registro0["caminho"].ToString();
                string strFolder;
                string strFilePath;
                strFolder = Server.MapPath("./");
                strFilePath = strFolder + "uploads/" + nameFile;
                File.Delete(strFilePath);
            }
            con0.Close();                      
                      

            // Cria as informações do LOG
            System.Configuration.ConnectionStringSettings connString2;
            connString2 = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
            //capturar a string de conexão                    
            connString2 = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
            //cria um objeto de conexão
            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = connString2.ToString();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con2;
            // Faz a inserção no Banco de dado
            cmd2.CommandText = "Insert into log (id_usuario,titulo_documento,tipo_log) values (@id_usuario,@titulo_documento,@tipo_log)";
            // Passagem dos valores das variáveis
            cmd2.Parameters.AddWithValue("id_usuario", ltrCookie.Text);
            cmd2.Parameters.AddWithValue("titulo_documento", titulo_doc);
            cmd2.Parameters.AddWithValue("tipo_log", "Apagado");
            con2.Open();
            cmd2.ExecuteNonQuery();
            con2.Close();

            // Cria a conexão para deleção/*
            System.Configuration.ConnectionStringSettings connString1;
            connString1 = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
            //cria um objeto de conexão
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = connString1.ToString();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            cmd1.CommandText = "delete from documento where Id_documento = @valor";
            cmd1.Parameters.AddWithValue("valor", valor);            
            con1.Open();
            cmd1.ExecuteNonQuery();
            con1.Close();

            Response.Redirect("~/manager.aspx");

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
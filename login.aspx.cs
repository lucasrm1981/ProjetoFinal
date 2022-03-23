using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal
{
    public partial class logincad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogar_Click(object sender, EventArgs e)
        {
            String email = tbEmail.Text;
            String senha = tbSenha.Text;
            //
            //capturar a string de conexão
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from usuario where email = @email and senha = @senha";
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("senha", senha);
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            // Encontrou um registro que satisfez a condição
            if (registro.HasRows)
            {
                // Fez a leitura de todas as linha encontradas no banco
                registro.Read();
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
                Response.Redirect("~/index.aspx");
            }
            else
            {
                // Alert Javascript
                Response.Write("<script> alert('Email ou Senha Incorretos!');</script>");
            }
        }
    }
}
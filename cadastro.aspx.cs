using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal
{
    public partial class cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btCadastrar_Click(object sender, EventArgs e)
        {
            
            //capturar a string de conexão
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            // Criado pelo SQL Data Source
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            // Chamada da Inserção pelo SQL insert, escolha da tabela into, campos (nome,email,senha) e variáveis (@nome,@email,@senha)
            cmd.CommandText = "Insert into usuario (nome,email,senha) values (@nome,@email,@senha)";

            // Varáveis do banco de dados iniciado por @ arroba
            cmd.Parameters.AddWithValue("nome", tbNome.Text);
            cmd.Parameters.AddWithValue("email", tbEmail.Text);
            cmd.Parameters.AddWithValue("senha", tbSenha.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            
           Response.Redirect("~/login.aspx");
        }
    }
}
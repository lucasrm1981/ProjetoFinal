using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.SqlClient;

namespace ProjetoFinal
{
    public partial class UploadDeArquivo : System.Web.UI.Page
    {     

        private void Page_Load(object sender, System.EventArgs e)
        {
            getPropriedadesCookie("login");
        }
        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            InitializeComponent();
            base.OnInit(e);
        }
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion

        private void btnUpload_Click(object sender, System.EventArgs e)
        {
            
            getPropriedadesCookie2("id_user");

            // Nome do Arquivo
            string strFileName;
            // Caminho do Arquivo
            string strFilePath;
            // Diretório do Arquivo
            string strFolder;

            strFolder = Server.MapPath("./");
            // Get the name of the file that is posted.
            strFileName = oFile.PostedFile.FileName;
            strFileName = Path.GetFileName(strFileName);
            if (oFile.Value != "")
            {
                // Create the directory if it does not exist.
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }
                // Save the uploaded file to the server.
                string nameFile = ltriduser.Text +"-"+ strFileName;
                strFilePath = strFolder + "uploads/" + nameFile;
                if (File.Exists(strFilePath))
                {
                    lblUploadResult.Text = nameFile + " Já existe no Servidor!";
                }
                else
                {
                    oFile.PostedFile.SaveAs(strFilePath);
                    lblUploadResult.Text = nameFile + " foi carregado com sucesso.";

                    //capturar a string de conexão
                    System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
                    System.Configuration.ConnectionStringSettings connString;
                    connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ConnectionString"];
                    //cria um objeto de conexão
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = connString.ToString();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    // Faz a inserção no Banco de dado
                    cmd.CommandText = "Insert into documento (titulo,id_usuario,tipo,caminho) values (@strFileName,@id_usuario,@tipo,@caminho)";
                    cmd.Parameters.AddWithValue("strFileName", strFileName);
                    cmd.Parameters.AddWithValue("id_usuario", ltrCookie.Text);
                    cmd.Parameters.AddWithValue("tipo", "Arquivo");
                    cmd.Parameters.AddWithValue("caminho", nameFile);
                    con.Open();
                    cmd.ExecuteNonQuery();


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
                    cmd2.Parameters.AddWithValue("titulo_documento", strFileName);
                    cmd2.Parameters.AddWithValue("tipo_log", "Criação");
                    con2.Open();
                    cmd2.ExecuteNonQuery();
                    con2.Close();
                }
            }
            else
            {
                lblUploadResult.Text = "Clique para selecionar um Arquivo.";
            }
            // Display the result of the upload.
            frmConfirmation.Visible = true;
        }

        public void getPropriedadesCookie(string nomeCookie)
        {
            // Obtém a requisição com dos dados do cookie
            HttpCookie cookie = ObterRequisicaoCookie(nomeCookie);
            if (cookie != null)
            {
                // Separa os valores das propriedade
                string valores = cookie.Value.ToString();
                // Varre os valores das propriedades encontrados               
                    // Escreve os valores das propriedades encontradas
                    ltrCookie.Text = valores;
                            }
            else ltrCookie.Text = string.Empty;
        }

        public void getPropriedadesCookie2(string nomeCookie)
        {
            // Obtém a requisição com dos dados do cookie
            HttpCookie cookie = ObterRequisicaoCookie(nomeCookie);
            if (cookie != null)
            {
                // Separa os valores das propriedade
                string valores = cookie.Value.ToString();
                // Varre os valores das propriedades encontrados               
                // Escreve os valores das propriedades encontradas
                ltriduser.Text = valores;
            }
            else ltriduser.Text = string.Empty;
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
       
        protected void btnLer_Click(object sender, EventArgs e)
        {
            getPropriedadesCookie("login");
        }
        
    }
}
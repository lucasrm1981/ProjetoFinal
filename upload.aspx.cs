using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] caminhoArquivos = Directory.GetFiles(Server.MapPath("~/uploads/"));
                List<ListItem> arquivos = new List<ListItem>();
                foreach (string filePath in caminhoArquivos)
                {
                    arquivos.Add(new ListItem(Path.GetFileName(filePath), filePath));
                }
                gvArquivos.DataSource = arquivos;
                gvArquivos.DataBind();
            }
        }

        protected void EnviarArquivo(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string nomeArquivo = Path.GetFileName(FileUpload1.PostedFile.FileName);
                long tamanhoArquivo = FileUpload1.PostedFile.ContentLength;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/uploads/") + nomeArquivo);
                lblmsg.Text = "Arquivo enviado com sucesso.\n" + "Tamanho do Arquivo = " + tamanhoArquivo.ToString() + "bytes";
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                lblmsg.Text = "Por Favor, selecione um arquivo a enviar.";
            }
        }


        protected void DownloadArquivo(object sender, EventArgs e)
        {
            try
            {
                string caminhoArquivo = (sender as LinkButton).CommandArgument;
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(caminhoArquivo));
                Response.WriteFile(caminhoArquivo);
                Response.End();
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }


        protected void DeletarArquivo(object sender, EventArgs e)
        {
            try
            {
                string caminhoArquivo = (sender as LinkButton).CommandArgument;
                File.Delete(caminhoArquivo);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }
    }
}
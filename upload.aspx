<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="ProjetoFinal.upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        
        <hr />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnEnviarArquivo" runat="server" Text="Enviar Arquivo" OnClick="EnviarArquivo" />
        <br /> <asp:Label ID="lblmsg" runat="server" Text="Label"></asp:Label><br />
        <hr />
        <asp:GridView ID="gvArquivos" runat="server" AutoGenerateColumns="false" EmptyDataText = "Nenhum arquivo enviado" Width="321px">
            <Columns>
                <asp:BoundField DataField="Text" HeaderText="Nome do Arquivo" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadArquivo"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID = "lnkDeleta" Text = "Deletar" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeletarArquivo" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>

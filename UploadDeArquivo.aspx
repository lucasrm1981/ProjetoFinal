<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="UploadDeArquivo.aspx.cs" Inherits="ProjetoFinal.UploadDeArquivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Up Load De Arquivo</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

          <form id="Form1" method="post" runat="server" enctype="multipart/form-data" action="UploadDeArquivo.aspx">
         Arquivo Enviado para o servidor: <input id="oFile" type="file" runat="server" name="oFile">
         <asp:button id="btnUpload" type="submit" text="Upload" runat="server"></asp:button>
         <asp:Panel ID="frmConfirmation" Visible="False" Runat="server">
            <asp:Label id="lblUploadResult" Runat="server"></asp:Label>
             <br />
         </asp:Panel>
      </form>

    <br />
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [documento] WHERE [Id_documento] = @Id_documento" InsertCommand="INSERT INTO [documento] ([caminho], [tipo], [titulo], [id_usuario]) VALUES (@caminho, @tipo, @titulo, @id_usuario)" SelectCommand="SELECT [caminho], [tipo], [titulo], [id_usuario], [Id_documento] FROM [documento]" UpdateCommand="UPDATE [documento] SET [caminho] = @caminho, [tipo] = @tipo, [titulo] = @titulo, [id_usuario] = @id_usuario WHERE [Id_documento] = @Id_documento">
        <DeleteParameters>
            <asp:Parameter Name="Id_documento" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="caminho" Type="String" />
            <asp:Parameter Name="tipo" Type="String" />
            <asp:Parameter Name="titulo" Type="String" />
            <asp:Parameter Name="id_usuario" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="caminho" Type="String" />
            <asp:Parameter Name="tipo" Type="String" />
            <asp:Parameter Name="titulo" Type="String" />
            <asp:Parameter Name="id_usuario" Type="String" />
            <asp:Parameter Name="Id_documento" Type="Int32" />
        </UpdateParameters>
          </asp:SqlDataSource>
          <br />
          <br />
    <asp:Label ID="ltrCookie" runat="server" Visible="false" ></asp:Label>
    <asp:Label ID="ltriduser" runat="server" Visible="false" ></asp:Label>
    </asp:Content>
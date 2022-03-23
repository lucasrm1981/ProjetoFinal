<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="manager.aspx.cs" Inherits="ProjetoFinal.manager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <asp:Label ID="managerCookie" runat="server" Text="" Visible="false"></asp:Label>

        
            <table style="width:100%;">
                  <tr>
    <th>ID</th>
    <th>Título</th>
    <th>Download</th>
      <th>Data</th>
      <th>Usuário</th>
      <th>Remover</th>
  </tr>  
                <div id="row_table" runat="server"></div>
            </table>
        
    </form>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" CodeBehind="default.aspx.cs"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form id="form1" runat="server">
        <asp:Label ID="ltrCookie" Text="" runat="server"></asp:Label>
        <table>
  <tr>
    <th>ID</th>
    <th>Título</th>
    <th>Download</th>
      <th>Data</th>
      <th>Usuário</th>
      <th>Remover</th>
  </tr>           
                <p id="row_table" runat="server" />
</table>

    </form>
</asp:Content>

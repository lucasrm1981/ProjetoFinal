<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="teste.aspx.cs" Inherits="ProjetoFinal.teste" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [data_criacao], [caminho], [tipo], [titulo], [id_usuario], [Id_documento] FROM [documento] WHERE ([id_usuario] = @id_usuario)">
            <SelectParameters>
                <asp:CookieParameter CookieName="login" Name="id_usuario" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id_documento" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="data_criacao" HeaderText="data_criacao" SortExpression="data_criacao" />
                <asp:BoundField DataField="caminho" HeaderText="caminho" SortExpression="caminho" />
                <asp:BoundField DataField="tipo" HeaderText="tipo" SortExpression="tipo" />
                <asp:BoundField DataField="titulo" HeaderText="titulo" SortExpression="titulo" />
                <asp:BoundField DataField="id_usuario" HeaderText="id_usuario" SortExpression="id_usuario" />
                <asp:BoundField DataField="Id_documento" HeaderText="Id_documento" InsertVisible="False" ReadOnly="True" SortExpression="Id_documento" />
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>

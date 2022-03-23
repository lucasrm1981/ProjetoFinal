<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjetoFinal.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Faz a Conexao com o Banco e liberar os elementos  pelo ConnectionString -->
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [usuario] WHERE [email] = @email" InsertCommand="INSERT INTO [usuario] ([email], [senha], [nome]) VALUES (@email, @senha, @nome)" SelectCommand="SELECT * FROM [usuario]" UpdateCommand="UPDATE [usuario] SET [Id] = @Id, [senha] = @senha, [nome] = @nome WHERE [email] = @email" OnSelecting="SqlDataSource1_Selecting">
    <DeleteParameters>
        <asp:Parameter Name="email" Type="String" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="email" Type="String" />
        <asp:Parameter Name="senha" Type="String" />
        <asp:Parameter Name="nome" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="Id" Type="Int32" />
        <asp:Parameter Name="senha" Type="String" />
        <asp:Parameter Name="nome" Type="String" />
        <asp:Parameter Name="email" Type="String" />
    </UpdateParameters>
</asp:SqlDataSource>
    
    <form id="form1" runat="server">




                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id_documento" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="data_criacao" HeaderText="Data" SortExpression="data_criacao" />
                        <asp:BoundField DataField="caminho" HeaderText="Caminho" SortExpression="caminho" />
                        <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo" />
                        <asp:BoundField DataField="titulo" HeaderText="Título" SortExpression="titulo" />
                        <asp:BoundField DataField="id_usuario" HeaderText="Usuário" SortExpression="id_usuario" />
                        <asp:BoundField DataField="Id_documento" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="Id_documento" />
                                               
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>





                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [data_criacao], [caminho], [tipo], [titulo], [id_usuario], [Id_documento] FROM [documento] WHERE ([id_usuario] = @id_usuario)" DeleteCommand="DELETE FROM [documento] WHERE [Id_documento] = @Id_documento" InsertCommand="INSERT INTO [documento] ([data_criacao], [caminho], [tipo], [titulo], [id_usuario]) VALUES (@data_criacao, @caminho, @tipo, @titulo, @id_usuario)" UpdateCommand="UPDATE [documento] SET [data_criacao] = @data_criacao, [caminho] = @caminho, [tipo] = @tipo, [titulo] = @titulo, [id_usuario] = @id_usuario WHERE [Id_documento] = @Id_documento">
                    <DeleteParameters>
                        <asp:Parameter Name="Id_documento" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="data_criacao" Type="DateTime" />
                        <asp:Parameter Name="caminho" Type="String" />
                        <asp:Parameter Name="tipo" Type="String" />
                        <asp:Parameter Name="titulo" Type="String" />
                        <asp:Parameter Name="id_usuario" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:CookieParameter CookieName="login" Name="id_usuario" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="data_criacao" Type="DateTime" />
                        <asp:Parameter Name="caminho" Type="String" />
                        <asp:Parameter Name="tipo" Type="String" />
                        <asp:Parameter Name="titulo" Type="String" />
                        <asp:Parameter Name="id_usuario" Type="String" />
                        <asp:Parameter Name="Id_documento" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>


                </form>
    
</asp:Content>

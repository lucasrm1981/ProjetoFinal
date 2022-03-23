<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="log.aspx.cs" Inherits="ProjetoFinal.log" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id_log" DataSourceID="SqlDataSource1">
        <AlternatingItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="tipo_logLabel" runat="server" Text='<%# Eval("tipo_log") %>' />
                </td>
                <td>
                    <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("data") %>' />
                </td>
                <td>
                    <asp:Label ID="titulo_documentoLabel" runat="server" Text='<%# Eval("titulo_documento") %>' />
                </td>
                <td>
                    <asp:Label ID="id_usuarioLabel" runat="server" Text='<%# Eval("id_usuario") %>' />
                </td>
                <td>
                    <asp:Label ID="Id_logLabel" runat="server" Text='<%# Eval("Id_log") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Atualizar" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                </td>
                <td>
                    <asp:TextBox ID="tipo_logTextBox" runat="server" Text='<%# Bind("tipo_log") %>' />
                </td>
                <td>
                    <asp:TextBox ID="dataTextBox" runat="server" Text='<%# Bind("data") %>' />
                </td>
                <td>
                    <asp:TextBox ID="titulo_documentoTextBox" runat="server" Text='<%# Bind("titulo_documento") %>' />
                </td>
                <td>
                    <asp:TextBox ID="id_usuarioTextBox" runat="server" Text='<%# Bind("id_usuario") %>' />
                </td>
                <td>
                    <asp:Label ID="Id_logLabel1" runat="server" Text='<%# Eval("Id_log") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>Nenhum dado foi retornado.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Inserir" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Limpar" />
                </td>
                <td>
                    <asp:TextBox ID="tipo_logTextBox" runat="server" Text='<%# Bind("tipo_log") %>' />
                </td>
                <td>
                    <asp:TextBox ID="dataTextBox" runat="server" Text='<%# Bind("data") %>' />
                </td>
                <td>
                    <asp:TextBox ID="titulo_documentoTextBox" runat="server" Text='<%# Bind("titulo_documento") %>' />
                </td>
                <td>
                    <asp:TextBox ID="id_usuarioTextBox" runat="server" Text='<%# Bind("id_usuario") %>' />
                </td>
                <td>&nbsp;</td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="tipo_logLabel" runat="server" Text='<%# Eval("tipo_log") %>' />
                </td>
                <td>
                    <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("data") %>' />
                </td>
                <td>
                    <asp:Label ID="titulo_documentoLabel" runat="server" Text='<%# Eval("titulo_documento") %>' />
                </td>
                <td>
                    <asp:Label ID="id_usuarioLabel" runat="server" Text='<%# Eval("id_usuario") %>' />
                </td>
                <td>
                    <asp:Label ID="Id_logLabel" runat="server" Text='<%# Eval("Id_log") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr runat="server" style="">
                                <th runat="server">tipo_log</th>
                                <th runat="server">data</th>
                                <th runat="server">titulo_documento</th>
                                <th runat="server">id_usuario</th>
                                <th runat="server">Id_log</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style=""></td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="tipo_logLabel" runat="server" Text='<%# Eval("tipo_log") %>' />
                </td>
                <td>
                    <asp:Label ID="dataLabel" runat="server" Text='<%# Eval("data") %>' />
                </td>
                <td>
                    <asp:Label ID="titulo_documentoLabel" runat="server" Text='<%# Eval("titulo_documento") %>' />
                </td>
                <td>
                    <asp:Label ID="id_usuarioLabel" runat="server" Text='<%# Eval("id_usuario") %>' />
                </td>
                <td>
                    <asp:Label ID="Id_logLabel" runat="server" Text='<%# Eval("Id_log") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [tipo_log], [data], [titulo_documento], [id_usuario], [Id_log] FROM [log] WHERE ([id_usuario] = @id_usuario)">
        <SelectParameters>
            <asp:CookieParameter CookieName="login" Name="id_usuario" Type="String" />
        </SelectParameters>
        </asp:SqlDataSource>
</form>
</asp:Content>

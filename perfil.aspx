<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="ProjetoFinal.perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
      <!--FORMULÁRIO DE LOGIN-->
      <div id="login">
        <form id="form1" runat="server">
          <h1>Perfíl do Usuário<asp:Label ID="ltrCookie" runat="server" Text="" Visible="false"></asp:Label>
            </h1>           
           
          <p> 
            <label for="tbSenha">Atualizar Senha</label>
            
              <asp:TextBox ID="tbSenha" runat="server" TextMode="Password"></asp:TextBox>
          </p>
         
          <p> 
            <asp:Button ID="btnatualizar" runat="server" Text="Atualizar" OnClick="btnatualizar_Click" /> 
          </p>
           
          
        </form>
</asp:Content>

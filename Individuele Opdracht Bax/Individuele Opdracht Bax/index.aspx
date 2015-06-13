<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Individuele_Opdracht_Bax.WebForm1" %>
<%@ Register TagPrefix="userControl" TagName="MainMenu"
    Src="test.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="goToLogin">
        <asp:Button ID="BtnGoToLogin" runat="server" Text="Inloggen" OnClick="Redirect_Login" />
        <asp:Button ID="btnTestUserControl" runat="server" Text="Test" OnClick="Add_UserControl" />
    </div>

    <div id="innerContent" clientidmode="Static" runat="server">
        
    </div>
</asp:Content>

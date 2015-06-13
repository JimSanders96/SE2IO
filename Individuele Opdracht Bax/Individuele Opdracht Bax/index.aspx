<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Individuele_Opdracht_Bax.WebForm1" %>
<%@ Register TagPrefix="userControl" TagName="MainMenu"
    Src="test.ascx" %>

<!-->  This is (or should be) the homepage of the application. Because of time and stress related reasons, the application will begin within the main category 'Gitaar'. </!-->

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="goToLogin">
        <asp:Button ID="BtnGoToLogin" runat="server" Text="Inloggen" OnClick="Redirect_Login" />
        <h1>
            U bevindt zich in de categorie [Gitaar]. <!-->   </!-->
        </h1>
    </div>

    <div id="innerContent" clientidmode="Static" runat="server">
        
    </div>
</asp:Content>

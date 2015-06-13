<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Individuele_Opdracht_Bax.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="goToLogin">
        <asp:Button ID="BtnGoToLogin" runat="server" Text="Inloggen" OnClick="Redirect_Login" />
    </div>
</asp:Content>

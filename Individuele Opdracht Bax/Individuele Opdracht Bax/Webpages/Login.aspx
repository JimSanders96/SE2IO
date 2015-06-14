<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Individuele_Opdracht_Bax.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:Label ID="LblUsername" runat="server" Text="Gebruikersnaam"></asp:Label>
    <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
    <asp:Label ID="lblPassword" runat="server" Text="Wachtwoord"></asp:Label>
    <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="submit_Click"/>
    <asp:Button ID="btnReturn" runat="server" Text="Terug" OnClick="btnReturn_Click"/>
</asp:Content>

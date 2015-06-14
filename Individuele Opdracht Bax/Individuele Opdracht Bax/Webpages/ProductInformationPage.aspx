<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ProductInformationPage.aspx.cs" Inherits="Individuele_Opdracht_Bax.Webpages.ProductInformationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div id="innerContent" clientidmode="Static" runat="server">
        <div class="Buttons">

            <asp:Button ID="BtnGoToLogin" runat="server" Text="Inloggen" OnClick="Redirect_Login" />
            <asp:Button ID="btnAddToCart" runat="server" Text="Voeg toe aan winkelmand" OnClick="btnAddToCart_Click" />

        </div>

        <div class="ProductImages">
            <asp:Image ID="imgProductMain" runat="server" />
            <asp:Image ID="imgProductSecond" runat="server" />
        </div>

        <div class="ProductSmallData">
            <asp:Label ID="lblName" runat="server" Text="Artikelnaam"></asp:Label>
            <asp:Label ID="lblBrand" runat="server" Text="Merk"></asp:Label>

            <asp:Label ID="lblPrice" runat="server" Text="Prijs"></asp:Label>
        </div>

        <textarea id="taDescription" cols="100" rows="2" runat="server" disabled="disabled"></textarea>


    </div>
    <div id="newReview">
        <asp:Label ID="lblRating" runat="server" Text="Beoordeling:"></asp:Label>
        <asp:RadioButtonList ID="rblRating" runat="server">
            <asp:ListItem Selected="True">1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:RadioButtonList>
        <textarea id="taReview" cols="50" rows="3" runat="server"></textarea>
        <asp:Button ID="btnReview" runat="server" Text="Plaats beoordeling" OnClick="btnReview_Click" />
    </div>
    <div id="reviews" clientidmode="Static" runat="server">
    </div>

</asp:Content>

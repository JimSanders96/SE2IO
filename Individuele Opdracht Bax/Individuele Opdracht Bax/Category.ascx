<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="Individuele_Opdracht_Bax.Category" %>

<div class="categoryContainer">

    <div class="categoryImage">
        <asp:ImageButton ID="ibCategory" runat="server" OnClick="ibCategory_Click" />
    </div>

    <div class="categoryName">
        <asp:Label ID="lblCategoryName" runat="server" Text="Categorie"></asp:Label>
    </div>

</div>

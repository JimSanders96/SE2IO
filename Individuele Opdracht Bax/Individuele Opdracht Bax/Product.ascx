<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Product.ascx.cs" Inherits="Individuele_Opdracht_Bax.Product" %>

<div class="productContainer">

    <asp:Label ID="lblProductName" runat="server" Text="Product"></asp:Label>
    <asp:Label ID="lblProductPrice" runat="server" Text="Price"></asp:Label>
    <div class="productImage">
        <asp:ImageButton ID="ibProduct" runat="server" />
    </div>
    <textarea id="taDescription" cols="100" rows="2" runat="server" disabled></textarea>

</div>
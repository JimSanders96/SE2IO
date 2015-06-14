<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Review.ascx.cs" Inherits="Individuele_Opdracht_Bax.Review" %>

<div class="reviewContainer">

    
    <div class="rating">
        <asp:Label ID="lblUser" runat="server" Text="User"></asp:Label>
        <asp:Label ID="lblRating" runat="server" Text="Rating"></asp:Label>
    </div>

    <div class="comment">
        <textarea id="taComment" cols="50" rows="2" disabled runat="server"></textarea>
    </div>

</div>
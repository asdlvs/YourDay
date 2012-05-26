<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OfferEventCardCatalog.ascx.cs" Inherits="YourDay.Site.Controls.Contractor.OfferEventCardCatalog" %>
<asp:Repeater runat="server" ID="RepeaterOfferEventCards">
<ItemTemplate>
<div>
<%# Eval("Title") %>
</div>
</ItemTemplate>
</asp:Repeater>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftMenuBody.ascx.cs" Inherits="YourDay.Site.Controls.Navigate.LeftMenuBody" %>
<asp:Repeater ID="RepeaterLinks" runat="server">
<ItemTemplate>
<div runat="server" class="bodyitem">
    <asp:HyperLink ID="HyperLinkItem" runat="server" NavigateUrl='<%# Eval("Key") %>'><%# Eval("Value") %></asp:HyperLink>
</div>

</ItemTemplate>
</asp:Repeater>

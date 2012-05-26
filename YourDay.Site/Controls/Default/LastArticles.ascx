<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LastArticles.ascx.cs" Inherits="YourDay.Site.Controls.Default.LastArticles" %>
<div class="articles">
<asp:Repeater runat="server" ID="RepeaterArticles">
<ItemTemplate>
<div class="one">
    <img src='<%# Eval("Path") %>' alt='<%# Eval("Alt") %>' width="163" height="108" style="float:left; margin-right:10px;margin-bottom:10px;"></img>
    <asp:HyperLink ID="HyperLinkTitle" runat="server" NavigateUrl='<%# Eval("Url") %>'><%# Eval("Title") %></asp:HyperLink><br />
    <asp:Label ID="LabelText" runat="server" Text='<%# Eval("Content") %>'></asp:Label>
    <br /><br /><br />
</div>
</ItemTemplate>
</asp:Repeater>
</div>
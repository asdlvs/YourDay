<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News.ascx.cs" Inherits="YourDay.Site.Controls.Default.News" %>
<div class="news">
<asp:Repeater runat="server" ID="RepeaterNews">
<ItemTemplate>
<div class="one">
  <asp:HyperLink ID="HyperLinkTitle" runat="server" NavigateUrl='<%# Eval("Url") %>'><%# Eval("Title") %></asp:HyperLink><br /><br />
    <asp:Label ID="LabelText" runat="server" Text='<%# Eval("Content") %>'></asp:Label>
    <br /><br /><br />
    </div>
</ItemTemplate>
</asp:Repeater>
</div>
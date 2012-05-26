<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InputBox.ascx.cs" Inherits="YourDay.Site.Controls.Common.Messenger.InputBox" %>
<div class="<%= Class %>">
    <asp:TextBox runat="server" ID="TextBoxMessageArea" TextMode="MultiLine">
    </asp:TextBox>
    <asp:HyperLink runat="server" ID="HyperLinkCreateMessage">
    </asp:HyperLink>
</div>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BestContractor.ascx.cs" Inherits="YourDay.Site.Controls.Default.BestContractor" %>
<div class="one">
    <div class="item no">
        <asp:Label ID="LabelNo" runat="server" Text="Label"></asp:Label>
    </div>
    <div class="item avatar">
        <img runat="server" id="avatar"  width="50"/>
    </div>
    <div class="item info">
        <asp:HyperLink ID="HyperLinkName" runat="server" CssClass="name">Name</asp:HyperLink><br />
        <%--<asp:Label runat="server" ID="LabelOnlineStatus"></asp:Label>--%>
        <asp:Label runat="server" ID="LabelOnlineStatusValue" CssClass="status"></asp:Label><br />
    </div>
</div>
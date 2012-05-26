<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShortInfo.ascx.cs" Inherits="YourDay.Site.Controls.Catalog.ShortInfo" %>
<div id="shortInfoDiv" runat="server">
<div id="shortInfoContentDiv" runat="server">

<img runat="server" id="avatar"  class="avatar"/>

<div class="ColumnInfo first">
    <div class="addinfo">
        <asp:HyperLink ID="HyperLinkName" runat="server" CssClass="Name">name</asp:HyperLink><br />
        <asp:Label runat="server" ID="LabelSpecialization"></asp:Label>
        <asp:Label runat="server" ID="LabelSpecializationsLink"></asp:Label><br />
        <asp:Label runat="server" ID="LabelOnlineStatus"></asp:Label>
        <asp:Label runat="server" ID="LabelOnlineStatusValue"></asp:Label>
    </div>
</div>
<div class="ColumnInfo second">
 <div class="addinfo">
 <br class="skip" />
        <asp:Label runat="server" ID="LabelFeedbacks"></asp:Label>
        <asp:HyperLink runat="server" ID="HyperLinkPositiveFeedbacks" CssClass="good"></asp:HyperLink>
        /
        <asp:HyperLink runat="server" ID="HyperLinkNegativeFeedbacks" CssClass="bad"></asp:HyperLink>
        <br />
        <asp:Label runat="server" ID="LabelEvents"></asp:Label><asp:HyperLink runat="server" ID="HyperLinkEvents"></asp:HyperLink>
</div>        
</div>
<div class="ColumnInfo third">
<br class="skip" />
        <asp:Label runat="server" ID="LabelCity"></asp:Label><asp:HyperLink runat="server" ID="HyperLinkCity"></asp:HyperLink><br />
        <asp:Label runat="server" ID="LabelRating"></asp:Label>*****<br />
</div>
</div>
</div>

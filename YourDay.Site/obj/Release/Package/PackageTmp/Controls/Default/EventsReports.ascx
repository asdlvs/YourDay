<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventsReports.ascx.cs" Inherits="YourDay.Site.Controls.Default.EventsReports" %>
<%@ Register src="LastPhotoes.ascx" tagname="LastPhotoes" tagprefix="uc1" %>
<%@ Register src="LastVideo.ascx" tagname="LastVideo" tagprefix="uc2" %>
<%@ Register src="LastArticles.ascx" tagname="LastArticles" tagprefix="uc3" %>
<%@ Register src="News.ascx" tagname="News" tagprefix="uc4" %>
<br />
<asp:Label runat="server" ID="LabelTitle" CssClass="lobstertitle"></asp:Label>
<br /><br />
<div class="eventreports">
    <div class="column1">
        <uc1:LastPhotoes ID="LastPhotoes1" runat="server" />
    </div>
    <div class="column2">
        
        
        
        <uc2:LastVideo ID="LastVideo1" runat="server" />
    </div>
</div>
<br />

<div class="lasttexts">
    <div class="t column1">
        <asp:Label runat="server" ID="LabelArticles" CssClass="lobstertitle"></asp:Label>
        <br /><br />
        <uc3:LastArticles ID="LastArticles1" runat="server" />
    </div>
    <div class="t column2">
        <asp:Label runat="server" ID="LabelNews" CssClass="lobstertitle"></asp:Label>
        <br /><br />
        <uc4:News ID="News1" runat="server" />
    </div>

</div>



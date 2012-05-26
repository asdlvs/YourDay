<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopContractor.ascx.cs" Inherits="YourDay.Site.Controls.Catalog.TopContractor" %>
<%@ Register src="ShortInfo.ascx" tagname="ShortInfo" tagprefix="uc1" %>

<div>
    <div style="display: table">
        <div class="top">
        </div>
    </div>
    <div style="display: table">
        <div class="middle">
              <div class="middle">
            <div class="plate">

    <uc1:ShortInfo ID="ShortInfoContractor" runat="server" />

    <br />
<div class="promoPhotoes">
<asp:Repeater runat="server" ID="RepeaterPromoPhotoes">
    <ItemTemplate>
            <img src='<%# Eval("Path") %>' class="one" alt='<%# Eval("Alt") %>'/>
    </ItemTemplate>
</asp:Repeater>
</div>
<br /><br />
<div class="bottomCounters">
    <div class="addToFavourites">
         <div class="icon">
                <img src="/Pict/Contractor/starIcon.png" /></div>
            <div class="text">
                <a runat="server" id="HtmlLinkFavourite"></a>
            </div>
    </div>
    <div class="photovideocounters">
    <asp:HyperLink runat="server" ID="HyperLinkPhotoesCount"></asp:HyperLink>
    /
    <asp:HyperLink runat="server" ID="HyperLinkVideoCount"></asp:HyperLink>
    </div>
</div>
</div>
        </div>
        </div>
    </div>
    <div style="display: table">
        <div class="bottom">
        </div>
    </div>
</div>






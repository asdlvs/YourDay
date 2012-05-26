<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UnregisteredUser.ascx.cs" Inherits="YourDay.Site.Controls.Contractor.UnregisteredUser" %>
<script src="/JS/Contractor/Actions.js" type="text/javascript"></script>

<div class="infoplate">
    <div class="avatar">
    <img runat="server" id="avatar" />
    </div>
    <div class="info">
        <asp:Label runat="server" ID="LabelFullName" CssClass="name"></asp:Label><br />
        <asp:Label runat="server" ID="LabelCity"></asp:Label><asp:HyperLink runat="server" ID="HyperLinkCity"></asp:HyperLink><br />
        <asp:Label runat="server" ID="LabelRating"></asp:Label>*****<br />
        <asp:Label runat="server" ID="LabelSpecialization"></asp:Label>
        <asp:Label runat="server" ID="LabelSpecializationsLink"></asp:Label>
        <br />
        <asp:Label runat="server" ID="LabelFeedbacks"></asp:Label>
        <asp:HyperLink runat="server" ID="HyperLinkPositiveFeedbacks" CssClass="good"></asp:HyperLink>
        /
        <asp:HyperLink runat="server" ID="HyperLinkNegativeFeedbacks" CssClass="bad"></asp:HyperLink>
        <br />
        <asp:Label runat="server" ID="LabelEvents"></asp:Label><asp:HyperLink runat="server" ID="HyperLinkEvents"></asp:HyperLink>
    </div>
    <div class="action">
        <div class="element">
            <div class="icon">
                <img src="/Pict/Contractor/plusIcon.png" />
            </div>
            <div class="text">
                <a runat="server" id="HtmlLinkPlus"></a>
            </div>
        </div>
        <div class="element">
            <div class="icon">
                <img src="/Pict/Contractor/sendMessageIcon.png" /></div>
            <div class="text">
                <a runat="server" id="HtmlLinkSend"></a>
            </div>
        </div>
        <div class="element">
            <div class="icon">
                <img src="/Pict/Contractor/starIcon.png" /></div>
            <div class="text">
                <a runat="server" id="HtmlLinkFavourite"></a>
            </div>
        </div>
        <div class="element">
            <div class="icon">
                <img src="/Pict/Contractor/priceIcon.png" /></div>
            <div class="text">
                <a runat="server" id="HtmlLinkPrice"></a>
            </div>
        </div>
    </div>
</div>
<br />
<div class="moreinfoplate">
    <div style="display:table-row">
        <div class="top">
        
        </div>
    </div>
    <div style="display:table-row">
        <div class="middle  padding">
            <div class="contactsinfo">
                <asp:Label runat="server" ID="LabelContactInfoTitle" Font-Bold="true"></asp:Label><br />
                <asp:Label runat="server" ID="LabelPhone"></asp:Label>
                <asp:Label runat="server" ID="LabelMail"></asp:Label><asp:HyperLink runat="server" ID="HyperLinkMail"></asp:HyperLink>
                <asp:Label runat="server" ID="LabelSite"></asp:Label><asp:HyperLink runat="server" ID="HyperLinkSite"></asp:HyperLink>
                <asp:Label runat="server" ID="LabelVK"></asp:Label><asp:HyperLink runat="server" ID="HyperLinkVK"></asp:HyperLink>
                <asp:Label runat="server" ID="LabelFacebook"></asp:Label><asp:HyperLink runat="server" ID="HyperLinkFacebook"></asp:HyperLink>
                <asp:Label runat="server" ID="LabelTwitter"></asp:Label><asp:HyperLink runat="server" ID="HyperLinkTwitter"></asp:HyperLink>
            </div>
            <hr />
            <div class="description">
                <asp:Label runat="server" ID="LabelDescriptionTitle" Font-Bold="true"></asp:Label><br />
                <asp:Label runat="server" ID="LabelDescriptionBody"></asp:Label>
            </div>
            <hr style="color:#000000"/>
            <div class="addition">
                 <asp:Label runat="server" ID="AdditionalTitle" Font-Bold="true"></asp:Label><br />
                 <asp:Label runat="server" ID="AdditionalBody"></asp:Label>
            </div>
        </div>
    </div>
    <div style="display:table-row">
        <div class="bottom">
        
        </div>
    </div>
</div>
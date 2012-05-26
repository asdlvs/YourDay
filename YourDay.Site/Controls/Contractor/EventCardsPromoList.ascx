<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventCardsPromoList.ascx.cs" Inherits="YourDay.Site.Controls.Contractor.EventCardsPromoList" %>
<%@ Register src="EventCardPromo.ascx" tagname="EventCardPromo" tagprefix="uc1" %>

<div class="eventcardpromolist">
<div class="title">
    <img src="/Pict/Contractor/ecListTitle.png" alt="Events" />
</div>
<asp:Repeater ID="RepeaterEventCardPromoList" runat="server">
<ItemTemplate>
<uc1:EventCardPromo ID="EventCardPromo" runat="server" 
    EventCard="<%# Container.DataItem%>" 
    ContractorId = "<%# ContractorId %>"
    SubcategoryId = "<%# SubcategoryId %>"
    ContractorName = "<%# ContractorName %>"
     />
</ItemTemplate>
</asp:Repeater>
</div>



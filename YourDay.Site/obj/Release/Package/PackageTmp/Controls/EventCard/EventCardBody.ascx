<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventCardBody.ascx.cs" Inherits="YourDay.Site.Controls.EventCard.EventCardBody" %>
<%@ Register src="EventCardBodyEls/ContractorsList.ascx" tagname="ContractorsList" tagprefix="uc1" %>
<%@ Register src="../Common/Photoes.ascx" tagname="Photoes" tagprefix="uc2" %>
<div id="contractorsConcerned">

    <uc1:ContractorsList ID="ContractorsListConcerned" runat="server" />

</div>

<div id="contractorsAccepted">

    <uc1:ContractorsList ID="ContractorsListAccepted" runat="server" />

</div>

<div id="video">

    

</div>

<div id="photoes">
    <asp:Label runat="server" ID="LabelPhotoes" CssClass="lobstertitle"></asp:Label>
    <uc2:Photoes ID="Photoes1" runat="server" />
</div>

<div id="comments">

</div>
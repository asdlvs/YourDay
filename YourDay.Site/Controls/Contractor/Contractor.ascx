<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contractor.ascx.cs" Inherits="YourDay.Site.Controls.Contractor.UCContractor" %>
<%@ Register src="UnregisteredUser.ascx" tagname="UnregisteredUser" tagprefix="uc1" %>
<%@ Register src="EventCardsPromoList.ascx" tagname="EventCardsPromoList" tagprefix="uc2" %>

<link href="/css/Contractor.css" rel="stylesheet" type="text/css" />
<uc1:UnregisteredUser ID="UnregisteredUser" runat="server" />




<uc2:EventCardsPromoList ID="EventCardsPromoListItem" runat="server" />













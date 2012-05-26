<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YourDay.Site.Default" %>
<%@ Register src="Controls/Default/WayToEventCard.ascx" tagname="WayToEventCard" tagprefix="uc1" %>
<%@ Register src="Controls/Navigate/CategoriesMenu.ascx" tagname="CategoriesMenu" tagprefix="uc2" %>
<%@ Register src="Controls/Navigate/MenuSimple.ascx" tagname="CategoriesMenuSimple" tagprefix="uc3" %>
<%@ Register src="Controls/Default/PromoBlock.ascx" tagname="PromoBlock" tagprefix="uc4" %>
<%@ Register src="Controls/Default/BestContractors.ascx" tagname="BestContractors" tagprefix="uc5" %>
<%@ Register src="Controls/Default/EventsReports.ascx" tagname="EventsReports" tagprefix="uc6" %>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <link href="/css/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderBreadCrumbs" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTopDiv" runat="server">
    <uc1:WayToEventCard ID="WayToEventCard1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
<br />
    <uc3:CategoriesMenuSimple ID="CategoriesMenuSimpleItem" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
<br />
    
    <uc4:PromoBlock ID="PromoBlock1" runat="server" />
    <br /><br />
    <uc5:BestContractors ID="BestContractors1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderBottomDiv" runat="server">
    
    
    
    <uc6:EventsReports ID="EventsReports1" runat="server" />
    
    
    
</asp:Content>

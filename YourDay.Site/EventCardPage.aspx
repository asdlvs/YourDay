<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="EventCardPage.aspx.cs" Inherits="YourDay.Site.EventCardPage" %>
<%@ Register src="Controls/EventCard/EventCardHeader.ascx" tagname="EventCardHeader" tagprefix="uc1" %>
<%@ Register src="Controls/EventCard/EventCardBody.ascx" tagname="EventCardBody" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBreadCrumbs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderTopDiv" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    
    
    
    <uc1:EventCardHeader ID="EventCardHeader1" runat="server" />
    <uc2:EventCardBody ID="EventCardBody1" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderBottomDiv" runat="server">
</asp:Content>

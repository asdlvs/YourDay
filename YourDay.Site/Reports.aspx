<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="YourDay.Site.Reports" %>
<%@ Register src="Controls/Contractor/OfferEventCardCatalog.ascx" tagname="OfferEventCardCatalog" tagprefix="uc1" %>
<%@ Register src="Controls/Navigate/MenuSimple.ascx" tagname="MenuSimple" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBreadCrumbs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderTopDiv" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
    <uc2:MenuSimple ID="MenuSimpleLeft" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:OfferEventCardCatalog ID="OfferEventCardCatalog1" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderBottomDiv" runat="server">
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="catalog.aspx.cs" Inherits="YourDay.Site.Catalog" %>
<%@ Register src="/Controls/Navigate/CategoriesMenu.ascx" tagname="CategoriesMenu" tagprefix="uc1" %>
<%@ Register src="/Controls/Catalog/ContractorList.ascx" tagname="ContractorList" tagprefix="uc2" %>
<%@ Register src="Controls/Navigate/BreadCrumbs.ascx" tagname="BreadCrumbs" tagprefix="uc3" %>
<%@ Register src="Controls/EventCard/ContractorsSelection.ascx" tagname="ContractorsSelection" tagprefix="uc4" %>
<asp:Content ID="ContentBreadCrumbs" ContentPlaceHolderID="ContentPlaceHolderBreadCrumbs" runat="server">
    <uc3:BreadCrumbs ID="BreadCrumbsControl" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
    
<uc1:CategoriesMenu ID="CategoriesMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc2:ContractorList ID="ContractorList1" runat="server" />
    <uc4:ContractorsSelection ID="ContractorsSelection1" runat="server" />
</asp:Content>

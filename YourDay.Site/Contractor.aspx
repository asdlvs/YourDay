<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Contractor.aspx.cs" Inherits="YourDay.Site.Contractor" %>
<%@ Register src="Controls/Contractor/Contractor.ascx" tagname="Contractor" tagprefix="uc1" %>
<%@ Register src="Controls/EventCard/ContractorsSelection.ascx" tagname="ContractorsSelection" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBreadCrumbs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderTopDiv" runat="server">
    
    
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc2:ContractorsSelection ID="ContractorsSelection1" runat="server" />
    <uc1:Contractor ID="ContractorCurrent" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderBottomDiv" runat="server">
</asp:Content>

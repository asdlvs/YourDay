<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ContractorCabinet.aspx.cs" Inherits="YourDay.Site.ContractorCabinet" EnableEventValidation="false" %>


<%@ Register src="Controls/Contractor/ContractorCabinetUC.ascx" tagname="ContractorCabinetUC" tagprefix="uc2" %>


<%@ Register src="Controls/Navigate/MenuSimple.ascx" tagname="MenuSimple" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBreadCrumbs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderTopDiv" runat="server">
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
    <uc1:MenuSimple ID="MenuSimple1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    
   
    
    <uc2:ContractorCabinetUC ID="ContractorCabinetUC1" runat="server" />
    
   
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderBottomDiv" runat="server">
    
</asp:Content>

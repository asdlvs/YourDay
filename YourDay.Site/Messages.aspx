<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="YourDay.Site.Messages" %>
<%@ Register src="Controls/Navigate/MenuSimple.ascx" tagname="MenuSimple" tagprefix="uc1" %>
<%@ Register src="Controls/Contractor/Messages.ascx" tagname="Messages" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
<link href="/CSS/Contractor.css" rel="stylesheet" type="text/css" />
    <script src="/JS/Contractor/Cabinet.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBreadCrumbs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderTopDiv" runat="server">
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
    <uc1:MenuSimple ID="MenuSimpleMessages" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc2:Messages ID="Messages1" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderBottomDiv" runat="server">
</asp:Content>

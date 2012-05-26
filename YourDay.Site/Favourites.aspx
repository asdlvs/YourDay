<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Favourites.aspx.cs" Inherits="YourDay.Site.WebForm2" %>
<%@ Register src="Controls/User/FavouritesList.ascx" tagname="FavouritesList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBreadCrumbs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderTopDiv" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderMenu" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">

    <uc1:FavouritesList ID="FavouritesList1" runat="server" />

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderBottomDiv" runat="server">
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BestContractors.ascx.cs" Inherits="YourDay.Site.Controls.Default.BestContractors" %>
<%@ Register src="BestContractor.ascx" tagname="BestContractor" tagprefix="uc1" %>
<div class="lobstertitle" id="lobsterTitle" runat="server">

</div>
<asp:DataList ID="DataListBestContractors" RepeatColumns="2"  runat="server" CssClass="contractors">
<ItemTemplate>
    <uc1:BestContractor ID="BestContractorsItem" runat="server" />
</ItemTemplate>

</asp:DataList>


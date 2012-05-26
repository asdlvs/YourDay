<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContractorList.ascx.cs" Inherits="YourDay.Site.Controls.Catalog.ContractorList" %>
<%@ Register src="TopContractor.ascx" tagname="TopContractor" tagprefix="uc1" %>
<%@ Register src="ShortInfo.ascx" tagname="ShortInfo" tagprefix="uc2" %>
<link href="../../CSS/Catalog.css" rel="stylesheet" type="text/css" />
<asp:Repeater runat="server" ID="RepeaterTopContactors">
<ItemTemplate>
<uc1:TopContractor ID="TopContractor1" runat="server"  Contractor='<%# Container.DataItem %>' />
</ItemTemplate>
</asp:Repeater>
<asp:Repeater runat="server" ID="RepeaterOtherContractors">
<ItemTemplate>
<uc2:ShortInfo ID="ShortInfo1" runat="server" Contractor='<%# Container.DataItem %>' />
</ItemTemplate>
</asp:Repeater>
<asp:HiddenField runat="server" ClientIDMode="Static" ID="HiddenFieldContractorsCount"  />





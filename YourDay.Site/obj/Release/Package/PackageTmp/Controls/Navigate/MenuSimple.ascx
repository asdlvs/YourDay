<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuSimple.ascx.cs" Inherits="YourDay.Site.Controls.Navigate.CategoriesMenuSimple" %>
<%@ Register src="LeftMenuHeader.ascx" tagname="LeftMenuHeader" tagprefix="uc1" %>
<div class="leftmenu">
<asp:Repeater runat="server" ID="RepeaterItems">
<ItemTemplate>
    <uc1:LeftMenuHeader ID="LeftMenuHeaderItem" runat="server" Title='<%# Eval("Key") %>' Href='<%# Eval("Value") %>' WithSubcategories="false" />
</ItemTemplate>
</asp:Repeater>
</div>







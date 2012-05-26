<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubcategoriesList.ascx.cs" Inherits="YourDay.Site.Controls.EventCard.SubcategoriesList" %>

<div id="subcategoriesselect" style="display:none; background-color:#FFFFFF;position:fixed; top:200px; left:50%;">
<asp:DataList ID="DataListSubcategories" runat="server" RepeatColumns="3">
<ItemTemplate>
    <input id='<%# "DataListSubcategories"+ Eval("Value") %>' type="checkbox"  title='<%# Eval("Text") %>' value='<%# Eval("Value") %>' onchange="ch(this);" /><%# Eval("Text") %>
    
</ItemTemplate>
</asp:DataList>
<a href="#" onclick="ccl(); return false;">Select</a>
</div>
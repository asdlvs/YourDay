<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalendarShort.ascx.cs" Inherits="YourDay.Site.Controls.Contractor.CalendarShort" %>
<%@ Register src="OneDay.ascx" tagname="OneDay" tagprefix="uc1" %>
<div class="shortcalendar">
<asp:Repeater runat="server" ID="RepeaterCalendar">
<ItemTemplate>
<uc1:OneDay ID="OneDay1" runat="server" Today='<%# Container.DataItem %>' />
</ItemTemplate>
</asp:Repeater>
</div>
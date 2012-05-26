<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContractorCabinetUC.ascx.cs" Inherits="YourDay.Site.Controls.Contractor.ContractorCabinetUC" %>

<%@ Register src="CalendarShort.ascx" tagname="CalendarShort" tagprefix="uc2" %>
<%@ Register src="EventsInCabinet.ascx" tagname="EventsInCabinet" tagprefix="uc3" %>
<link href="/CSS/Contractor.css" rel="stylesheet" type="text/css" />
<script src="/JS/Contractor/Cabinet.js" type="text/javascript"></script>

<uc2:CalendarShort ID="CalendarShort1" runat="server" />

<br />
<div class="events" runat="server" id="DivEventsHead">
    <div class="lobstertitle">
        <asp:Label ID="LabelTitle" runat="server" Text="Label"></asp:Label>
    </div>
    <asp:Repeater runat="server" ID="RepeaterDayFilter">
    <ItemTemplate>
        <div class="dayfilter">
            <a onclick='<%# "getevents(" + Eval("Year") + "," + Eval("Month") + "," + Eval("Date") + "," +Eval("Count") +");return false;" %>'  id='<%# "dayfilter_" + Eval("Count") %>'  href="#"><%# Eval("Title") %></a>
        </div>
    </ItemTemplate>
    </asp:Repeater>
  
    <div class="addevent">
    </div>
    <br />
    <div class="header">
        <div class="event">
            <asp:Label ID="LabelEvent" runat="server" Text="Label"></asp:Label><span id="dateperionselected"></span></div>
        <div class="specialization"> <asp:Label ID="LabelSpecialization" runat="server" Text="Label"></asp:Label></div>
        <div class="paymentstatus"> <asp:Label ID="LabelPaymentStatus" runat="server" Text="Label"></asp:Label></div>
        <div class="time"> <asp:Label ID="LabelTime" runat="server" Text="Label"></asp:Label></div>
    </div>
</div>
<uc3:EventsInCabinet ID="EventsInCabinet1" runat="server" />
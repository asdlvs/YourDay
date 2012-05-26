<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventsInCabinet.ascx.cs" Inherits="YourDay.Site.Controls.Contractor.EventsInCabinet" %>
<link href="/CSS/DropDown/ECStatus.css" rel="stylesheet" type="text/css" />



<%@ Register src="EventInCabinet.ascx" tagname="EventInCabinet" tagprefix="uc1" %>


<div class="events" id="events" runat="server" clientidmode="Static">
<script type="text/javascript">

    jQuery(document).ready(function () {
        renderddl();
    });
    
	</script>
<asp:Repeater runat="server" ID="RepeaterEventsInCabinet">
<ItemTemplate>
<uc1:EventInCabinet ID="EventInCabinet1" runat="server" EventCardCategory='<%# Container.DataItem %>' />
</ItemTemplate>
</asp:Repeater> 
<br />
<div class="navdates">
 <div class="anchoryesterday"><a runat="server" id="AnchorYesterday" clientidmode="Static"> ← Вчера</a></div>
<div class="anchortomorrows"><a runat="server" id="AnchorTomorrow" clientidmode="Static">Завтра →</a></div> 
</div>  
</div>

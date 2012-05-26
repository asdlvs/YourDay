<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContractorsList.ascx.cs" Inherits="YourDay.Site.Controls.EventCard.ContractorsList" %>
<asp:Label runat="server" ID="LabelTitle" CssClass="lobstertitle"></asp:Label>
<asp:DataList ID="DataListContractors" runat="server" RepeatColumns="2"  CssClass="contractors">
    <ItemTemplate>

        <div class="one">
            <div class="item avatar">
                <img src="<%# Eval("Avatar") %>" alt="<%# Eval("Alt") %>" />
            </div>
            <div class="item info">
                <a href="<%# Eval("Link") %>" class="name"><%# Eval("FullName") %></a><br />
                <asp:Literal runat="server" ID="Literal1">Специализация: </asp:Literal> 
                 <a href="#" onclick="<%# "changeCategory(" + Eval("scId") + ");return false;" %>"><%# Eval("Specialization") %></a>
            </div>
        </div>
       
    </ItemTemplate>
</asp:DataList>
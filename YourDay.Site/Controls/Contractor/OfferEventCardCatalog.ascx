<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OfferEventCardCatalog.ascx.cs"
    Inherits="YourDay.Site.Controls.Contractor.OfferEventCardCatalog" %>
<asp:HiddenField runat="server" ClientIDMode="Static" ID="hiddenFieldEventsCurrentCount" />
<asp:Repeater runat="server" ID="RepeaterOfferEventCards">
    <ItemTemplate>
        <div class="b-list-item clearfix">
            <h2 class="clearfix"><a href="<%# Eval("Link") %>"><%# Eval("Title") %></a>
                <span class="price"><%# Eval("Price") %></span></h2>
            <div class="descr">
                <%# Eval("Description") %>
            </div>
            <span class="published c-2"><%# Eval("PublishedDate") %></span><span class="reply"><a
                href="#">Ответить на событие</a><%# Eval("Requests") %></span>
        </div>
    </ItemTemplate>
</asp:Repeater>

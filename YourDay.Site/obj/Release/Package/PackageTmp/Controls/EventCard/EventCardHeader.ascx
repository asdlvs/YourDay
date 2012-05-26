<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventCardHeader.ascx.cs" Inherits="YourDay.Site.Controls.EventCard.EventCardHeader" %>
<div>
<div style="display:table">
    <div class="top">
    </div>
</div>
<div style="display:table">
    <div class="middle padding">
        <div id="shortInfoDiv" style="display:table" runat="server">
            <div id="shortInfoContentDiv" runat="server">
                <img runat="server" id="avatar" class="avatar" />
                <div class="ColumnInfo first">
                    <div class="addinfo">
                        <asp:HyperLink runat="server" ID="HyperLinkCreator" CssClass="Name"></asp:HyperLink><br />
                        <asp:Literal runat="server" ID="LiteralEventType">Тип События: </asp:Literal><asp:HyperLink runat="server" ID="HyperLinkEventType"></asp:HyperLink><br />
                        <asp:Literal runat="server" ID="LiteralIsOnline">Сейчас на сайте: </asp:Literal>
                    </div>
                </div>
                <div class="ColumnInfo second">
                    <div class="addinfo">
                         <br class="skip" />
                         <asp:Literal runat="server" ID="LiteralDate">Дата: </asp:Literal><asp:HyperLink runat="server" ID="HyperLinkDate"></asp:HyperLink><br />
                         <asp:Literal runat="server" ID="LiteralTimeTitle">Время: </asp:Literal><asp:Literal runat="server" ID="LiteralTime"></asp:Literal>
                    </div>
                </div>
                <div class="ColumnInfo third">
                     <br class="skip" />
                     <asp:Literal runat="server" ID="LiteralCity">Город: </asp:Literal><asp:HyperLink runat="server" ID="HyperLinkCity"></asp:HyperLink><br />
                     <asp:Literal runat="server" ID="LiteralBudjet">Бюджет: </asp:Literal><asp:Label runat="server" ID="LabelBudjet" Font-Bold="true"></asp:Label>
                </div>
            </div>
        </div>
        <br class="skip" />
        <div style="display:table">
            <div>
                <asp:Label runat="server" ID="LabelEventName" CssClass="Title">Днюха у посанцека</asp:Label>
            </div>
            <br class="skip" />
            <asp:Literal runat="server" ID="LiteralDescription">Карочи, Днюха у посона реального. Типа будем бухать че! Фотограф нужен, типа, карочи. Ну и этот баклан, как там его, шоу-мен. Ну а хуйли, фестивалить, так, по полной, спасибо.</asp:Literal>
        </div>
        <br class="skip" />
        <div style="display:table">
            <asp:Literal runat="server" ID="LiteralCategories">Категории поиска: </asp:Literal>
            <asp:Repeater runat="server" ID="RepeaterCategories">
                <ItemTemplate>
                    <a id="ACategory" onclick="<%# "changeCategory('" + Eval("Id") + "');return false;" %>" href="#"><%# Eval("Title") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
<div style="display:table">
    <div class="bottom">
    </div>
</div>
</div>

<asp:LinkButton runat="server" ID="LinkButtonBeginContractorsSelection" 
    onclick="LinkButtonBeginContractorsSelection_Click">Начать подбор</asp:LinkButton>


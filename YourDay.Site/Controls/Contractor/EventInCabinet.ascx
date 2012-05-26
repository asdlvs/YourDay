<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventInCabinet.ascx.cs" Inherits="YourDay.Site.Controls.Contractor.EventInCabinet" %>


<div class="one">
    <div class="write">
    <a href="#" onclick="showMessageBox(this, 'anchorMessages');return false;" runat="server" id="anchorMessages" clientidmode="Predictable">
        <img src="/Pict/Contractor/pencil.png" alt="Сообщения" border="0"/>
    </a>
    </div>
    <div class="title">
        <asp:HyperLink runat="server" ID="HyperLinkTitle" onclick="showMessageBox(this, 'HyperLinkTitle');return false;" ClientIDMode="Predictable">{0}</asp:HyperLink>
        <img src="/Pict/Contractor/arrow.png" alt="Развернуть" runat="server" id="arrow" clientidmode="Predictable" />
    </div>
    <div class="specialization">
        <asp:Label runat="server" ID="LabelSpecialization">{1}</asp:Label>
    </div>
    <div class="status">
    <span class="lineForm">
       <asp:DropDownList runat="server" ID="DropDownListStatus" DataTextField="Value" DataValueField="Key"></asp:DropDownList>
     </span>
    </div>
    <div class="time">
        <asp:Label runat="server" ID="LabelTime">{2}</asp:Label>
    </div>
</div>
<div class="one comment" id="messagesBlock" runat="server" clientidmode="Predictable">
    <div class="author">
        <asp:Literal runat="server" ID="LiteralAuthor"></asp:Literal>
        <asp:HyperLink runat="server" ID="HyperlinkAuthor"></asp:HyperLink>
    </div>
    <div class="city">
         <asp:Literal runat="server" ID="LiteralCity"></asp:Literal>
    </div>
    <div class="description">
         <asp:Literal runat="server" ID="LiteralDescription"></asp:Literal>
    </div>
    <br />
    <div class="messages top"></div>
    <div class="messages middle">
    <div class="messagesitems" runat="server" clientidmode="Predictable" id="messagesitems" >
        <asp:Repeater runat="server" ID="RepeaterMessages" >
            <ItemTemplate>
            <div class="item">
                <div class="author"><a href='<%# Eval("Url") %>'><%# Eval("Author") %></a></div>
                <div class="message"><%# Eval("Message") %></div>
                <div class="mtime"><%# Eval("Time") %></div>
            </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="messagebox">
        <asp:TextBox runat="server" ID="TextBoxNewMessage" TextMode="MultiLine" ClientIDMode="Predictable">
        </asp:TextBox>
    </div>
    <div class="bottomblock">
    <div class="btnsendmessage">
        <a href="#" runat="server" id="anchorSendMessage" clientidmode="Predictable" ><img src="/Pict/Contractor/sendButton.png" border="0" /></a>
    </div>
    </div>
    </div>
    <div class="messages bottom"></div>
</div>
<div class="line"></div>


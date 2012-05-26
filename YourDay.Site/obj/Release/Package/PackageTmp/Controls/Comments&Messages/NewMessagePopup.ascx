<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewMessagePopup.ascx.cs" Inherits="YourDay.Site.Controls.Comments_Messages.NewMessagePopup" %>
<link href="/CSS/CommentsIMessages.css" rel="stylesheet" type="text/css" />

<div class="newmessageblockpopup">
    <div class="newmessageinsideblockpopup">
    <div>
            <asp:Label runat="server" ID="LabelMessage" style="float:left;" ClientIDMode="Static">Сообщение</asp:Label>
            <a href="#" onclick="<%= "hidemessagepopup(" +  LinkId + ");return false;" %>">X</a>
        </div>
        <div>
            <asp:TextBox runat="server" ID="TextBoxNewMessage" ClientIDMode="Predictable" TextMode="MultiLine"></asp:TextBox>
        </div>
        <br />
        <div class="button">
            <a href="#" id="anchorSendMessage" runat="server" clientidmode="Predictable">
            <img border="0" src="/Pict/CommentsIMessages/send.png" alt="Отправить" />
               </a>
        </div>

    </div>
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewMessage.ascx.cs" Inherits="YourDay.Site.Controls.Comments_Messages.NewMessage" %>
<link href="/CSS/CommentsIMessages.css" rel="stylesheet" type="text/css" />
<div class="newmessageblock">
    <div class="newmessageinsideblock">

        <div>
            <asp:Label runat="server" ID="LabelReceiver" ClientIDMode="Static">Получатель</asp:Label>
            <asp:HiddenField runat="server" ID="HiddenFieldReceiver" ClientIDMode="Static" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="TextBoxReceiver"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" ID="LabelTheme" ClientIDMode="Static">Тема</asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="TextBoxTheme"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" ID="LabelMessage" ClientIDMode="Static">Сообщение</asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="TextBoxMessage" TextMode="MultiLine"></asp:TextBox>
        </div>
        <br />
        <div class="button">
            <a href="#" onclick="sendmessage();return false;">
            <img border="0" src="/Pict/CommentsIMessages/send.png" alt="Отправить" />
               </a>
        </div>

    </div>
</div>
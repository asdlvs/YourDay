<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Authentication.ascx.cs" Inherits="YourDay.Site.Controls.Auth.Authentication" %>

<div class="grayauthblock" id="authblock">
<div class="authenticationBlock">
<div class="closeblock">
<a href="#" onclick="ha();return false;">
<img src="/Pict/Auth/close.png" border="0" alt="Закрыть" />
</a>
</div>
<div class="authenticationInnerBlock">
<br />
<div class="lobstertitle">
    <asp:Label ID="LabelAuthenticationTitle" runat="server" Text="Label">Авторизация</asp:Label>
</div>
<br /><br />
<div class="underblock">
<div>
<asp:Label ID="LabelEMail" runat="server" ClientIDMode="Static" Text="Label">E-mail</asp:Label>
        
</div>
<div>
<asp:TextBox runat="server" ID="TextBoxEMail" ClientIDMode="Static" onkeypress="clearLabelEMail();"></asp:TextBox>
</div>
<br />
<div>
<asp:Label ID="LabelPassword" runat="server" Text="Label">Пароль</asp:Label>
</div>
<div>
<asp:TextBox runat="server" ID="TextBoxPassword" ClientIDMode="Static"></asp:TextBox>
</div>
<br />
<div class="cell checkbox">
<asp:CheckBox runat="server" ID="CheckBoxRememberMe" Checked="true"  ClientIDMode="Static"/>
</div>
<div class="cell checkboxlabel">
<asp:Label ID="LabelRememberMe" runat="server" Text="Label">Запомнить меня</asp:Label>
</div>
<div class="cell forgetpwd" id="divforgetpwd">
<a id="HyperlinkForgetPassword" href="#" onclick="sendCPMail();return false;">Забыли пароль?</a>
</div>
<br /><br /><br />
<div class="button">
<a href="#" onclick="login(); return false;">
    <img src="/Pict/Auth/login.png" border="0">
</a>
</div>
</div>
</div>
</div>
</div>
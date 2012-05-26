<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CI.ascx.cs" Inherits="YourDay.Site.Controls.Contractor.Preferences.CI" %>
<div  class="privateinfo">

    <div>Город</div>
    <div><asp:TextBox runat="server" ID="TextBoxCity"></asp:TextBox></div>
    <br />

    <div>Телефон</div>
    <div><asp:TextBox runat="server" ID="TextBoxPhone"></asp:TextBox></div>
    <br />

    <div>E-mail</div>
    <div><asp:TextBox runat="server" ID="TextBoxMail"></asp:TextBox></div>
    <br />

    <div>Сайт</div>
    <div><asp:TextBox runat="server" ID="TextBoxSite"></asp:TextBox></div>
    <br />

    <div>Вконтакте</div>
    <div><asp:TextBox runat="server" ID="TextBoxVK"></asp:TextBox></div>
    <br />

    <div>Facebook</div>
    <div><asp:TextBox runat="server" ID="TextBoxFB"></asp:TextBox></div>
    <br />

    <div>Twitter</div>
    <div><asp:TextBox runat="server" ID="TextBoxTwitter"></asp:TextBox></div>
    <br />

    <asp:ImageButton ID="ImageButtonSave" ImageUrl="~/Pict/Common/save.png" 
                 CssClass="btnsave" ClientIDMode="Static" runat="server" onclick="ImageButtonSave_Click" 
                  />

</div>
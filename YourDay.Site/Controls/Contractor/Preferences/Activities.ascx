<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Activities.ascx.cs" Inherits="YourDay.Site.Controls.Contractor.Preferences.Activities" %>
<div class="privateinfo">

    <div>Описание деятельности</div>
    <div><asp:TextBox runat="server" TextMode="MultiLine" ID="TextBoxDescription"></asp:TextBox></div>
    <br />
    <div>Доволнительная информация (сертификаты, опыт работы, известные клиенты и т.п.)</div>
    <div><asp:TextBox runat="server" TextMode="MultiLine" ID="TextBoxAdditional"></asp:TextBox></div>
    <br /><br /><br />
        <asp:ImageButton ID="ImageButtonSave" ImageUrl="~/Pict/Common/save.png" 
                 CssClass="btnsave" ClientIDMode="Static" runat="server" onclick="ImageButtonSave_Click"
                  />
</div>
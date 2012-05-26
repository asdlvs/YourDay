<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginRegister.ascx.cs" Inherits="YourDay.Site.Controls.Auth.LoginRegister" %>
<%@ Register src="Authentication.ascx" tagname="Authentication" tagprefix="uc1" %>
<%@ Register src="Registration.ascx" tagname="Registration" tagprefix="uc2" %>
    <div class="nalinks">
        <div style="display:table-cell;text-align:right;vertical-align:inherit;">
        <a href="#" onclick="showregister();return false" class="showregister">Регистрация</a>
        |
        <a href="#" onclick="showlogin();return false"" class="showlogin">Вход</a>
        </div>
    </div>

    
    <uc1:Authentication ID="Authentication1" runat="server" />
    <uc2:Registration ID="Registration1" runat="server" />
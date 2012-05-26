<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Main.ascx.cs" Inherits="YourDay.Site.Controls.Main" %>

<%@ Register src="HeaderLinks.ascx" tagname="HeaderLinks" tagprefix="uc3" %>

<%@ Register src="LoginRegister.ascx" tagname="LoginRegister" tagprefix="uc4" %>
<link href="/CSS/Auth.css" rel="stylesheet" type="text/css" />
<script src="/JS/Auth/auth.js" type="text/javascript"></script>
<div class="authmain" id="authmaindiv">
<asp:LoginView ID="LoginViewHeader" ClientIDMode="Static" runat="server">
<AnonymousTemplate>
    <uc4:LoginRegister ID="LoginRegister1" runat="server" />
</AnonymousTemplate>
<LoggedInTemplate>
    <uc3:HeaderLinks ID="HeaderLinks1" runat="server" />
</LoggedInTemplate>
</asp:LoginView>
</div>













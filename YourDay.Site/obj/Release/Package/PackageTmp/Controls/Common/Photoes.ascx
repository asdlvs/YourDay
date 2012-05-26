<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Photoes.ascx.cs" Inherits="YourDay.Site.Controls.Common.Photoes" %>
<div class="photoes">
    <asp:Repeater runat="server" ID="RepeaterPhotoes">
        <ItemTemplate>
            <div class="photo">
                <img src='<%# Eval("Path") %>' alt='<%# Eval("Alt") %>' />
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
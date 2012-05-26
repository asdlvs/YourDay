<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BottomLinksArray.ascx.cs" Inherits="YourDay.Site.Controls.Default.BottomLinksArray" %>
<div class="bottomLinkArray">
<div style="float:left">
    <asp:Repeater runat="server" ID="RepeaterCategoriesLinkArray">
    <HeaderTemplate>
        <div>
            <asp:Label runat="server" ID="LabelMapAnchorDivCategoriesTitle" CssClass="LabelMapAnchorDivTitle">Каталог контрагентов</asp:Label>
        </div>
        <div style="float:left; padding-right:30px;">
    </HeaderTemplate>
        <ItemTemplate>
            <div class="MapAnchorDiv">
                <a href="<%# Eval("Link") %>">
                    <%# Eval("Title") %>
                </a>
                <br />
            </div>
        </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
    </asp:Repeater>
</div>
<div style="float:left">
    <asp:Repeater ID="RepeaterLKLinkArray" runat="server">
        <HeaderTemplate>
        <div>
            <asp:Label runat="server" ID="LabelMapAnchorDivLKTitle" CssClass="LabelMapAnchorDivTitle">Личный кабинет</asp:Label>
        </div>
        <div style="padding-right:30px;">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="MapAnchorDiv">
                <a href="<%# Eval("Link") %>">
                    <%# Eval("Title") %>
                </a>
                <br />
            </div>
        </ItemTemplate>
        <FooterTemplate>
        </div>
        </FooterTemplate>
    </asp:Repeater>

     <asp:Repeater ID="RepeaterProjectLinkArray" runat="server">
        <HeaderTemplate>
        <div>
            <asp:Label runat="server" ID="LabelMapAnchorDivProjectTitle" CssClass="LabelMapAnchorDivTitle">О проекте</asp:Label>
        </div>
        <div style="padding-right:30px;">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="MapAnchorDiv">
                <a href="<%# Eval("Link") %>">
                    <%# Eval("Title") %>
                </a>
                <br />
            </div>
        </ItemTemplate>
        <FooterTemplate>
        </div>
        </FooterTemplate>
    </asp:Repeater>
</div>
</div>
<div class="bottomBenderBlock">

</div>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderLinks.ascx.cs"
    Inherits="YourDay.Site.Controls.Auth.HeaderLinks" %>
<div class="headerlinks">
    <asp:LoginView runat="server" ID="LoginViewHeaderLinks">
        <RoleGroups>
            <asp:RoleGroup Roles="notApproved">
                <ContentTemplate>
                    <asp:Label runat="server" ID="LabelNotApprovedText">
                    </asp:Label>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Contractor">
                <ContentTemplate>
                    <div class="cell userimg">
                        <img src="" alt="" id="userimg" runat="server" />
                    </div>
                    <div class="cell name">
                        <asp:Label runat="server" ID="LabelUserName"></asp:Label>
                    </div>
                    <div class="cell links">
                        <asp:Repeater runat="server" ID="RepeaterLinks">
                            <ItemTemplate>
                                <div class="one">
                                    <asp:HyperLink ID="HyperLinkItem" runat="server" NavigateUrl='<%# Eval("Url") %>'><%# Eval("Text")%></asp:HyperLink>
                                </div>
                                <div class="whitespace"></div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="SimpleUser">
                <ContentTemplate>
                    Молодец.
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
    <div class="cell exit">
        <a href="#" onclick="logout(''); return false" class="yellow">Выход</a>
    </div>
</div>

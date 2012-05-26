<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventCardPromo.ascx.cs" Inherits="YourDay.Site.Controls.Contractor.EventCardPromo" %>
<%@ Register src="../Common/Photoes.ascx" tagname="Photoes" tagprefix="uc1" %>
<div class="eventcardpromo" runat="server" id="divEventCardPromo">
    <asp:Label runat="server" ID="LabelDateTime" CssClass="date"></asp:Label>
    <asp:HyperLink runat="server" ID="HyperLinkTitle"></asp:HyperLink>
    <uc1:Photoes ID="Photoes1" runat="server" />
    <%--<div class="photoes">
        <asp:Repeater runat="server" ID="RepeaterPhotoes">
            <ItemTemplate>
                <div class="photo">
                    <img src='<%# Eval("Path") %>' alt='<%# Eval("Alt") %>' />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>--%>
    <div class="counts">
        <div class="commentcount"><asp:HyperLink runat="server" ID="HyperLinkCommentsCount"></asp:HyperLink>
            
        </div>
        <div class="photovideocount"><asp:HyperLink runat="server" ID="HyperLinkPhotoesCount"></asp:HyperLink>&nbsp/&nbsp<asp:HyperLink runat="server" ID="HyperLinkVideoCount"></asp:HyperLink></div>
    </div>
    <div style="float:left; height:20px; width:100%"></div>
</div>

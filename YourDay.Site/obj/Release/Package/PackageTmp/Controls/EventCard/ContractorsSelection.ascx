<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContractorsSelection.ascx.cs" Inherits="YourDay.Site.Controls.EventCard.ContractorsSelection" %>
<script src="/JS/EventCard/ContractorSelection.js" type="text/javascript"></script>
<div class="contractorSelection" runat="server" id="divContractorSelection">
    <div style="display:table-row">
        <div id="c_s_header" class="topSmall">
        </div>
    </div>
    <div style="display:table-row">
        <div id="c_s_contractors" class="middleSmall">
            <asp:Repeater runat="server" ID="RepeaterSelectedContractors">
                <ItemTemplate>
                    <div style="vertical-align:middle">
                        <div style="display:table-cell;">
                            <img src="<%# Eval("Avatar") %>" />
                            <a  href="<%# Eval("Link") %>" style="position:relative; bottom:10px; left:10px;" ><%# Eval("Name") %></a>
                        </div>
                        <div style="display:table-cell;">
                            <a href="#" onclick="RemoveFromEc(<%# Eval("Id") %>,<%# Eval("Sc") %>);return false;"><img src="#" /></a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div style="display:table-row">
        <div id="c_s_message" class="bottomSmall">
        </div>
    </div>
</div>
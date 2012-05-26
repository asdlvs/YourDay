<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FavouritesList.ascx.cs"
    Inherits="YourDay.Site.Controls.User.FavouritesList" %>
<div class="l-wrap clearfix">
    <div class="l-content-wrap">
        <div class="l-content">
            <div class="b-list-items favorites">
                <section>
                    <asp:Repeater runat="server" ID="RepeaterFavouriteEventCards">
                        <HeaderTemplate>
                            <header>
                                <h2 class="lobstertitle">Избранные события</h2>
                            </header>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="b-list-item clearfix">
                                <table class="va-middle">
                                    <col width="70">
                                    <col width="28%">
                                    <col>
                                    <col width="23.5%">
                                    <col width="16">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <img src="<%# Eval("Avatar") %>" alt="<%# Eval("Title") %>" width="52"></td>
                                            <td>
                                                <h3><a href="#"><%# Eval("Author") %></a></h3>
                                                Статус: <span class="c-3"><%# Eval("State") %></span></td>
                                            <td><a href="#"><%# Eval("Title") %></a></td>
                                            <td><%# Eval("Date") %><br>
                                                Время: <span class="c-3"><%# Eval("Time") %></span></td>
                                            <td class="actions"><a href="#" class="i i-remove"></a></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <br />
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="b-show-more">
                                <a href="#" class="a-3">Все пользователи</a>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </section>
                <section>
                    <asp:Repeater runat="server" ID="RepeaterFavouriteContractors">
                        <HeaderTemplate>
                            <header>
                                <h2 class="lobstertitle">Избранные контрагенты</h2>
                            </header>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="b-list-item clearfix">
                                <table class="va-middle">
                                    <col width="70">
                                    <col width="53%">
                                    <col>
                                    <col width="16">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <img src="<%# Eval("Avatar") %>" alt="<%# Eval("Title") %>" width="52"></td>
                                            <td>
                                                <h3><a href="#"><%# Eval("Title") %></a></h3>
                                                Специализация: <a href="#"><%# Eval("Specializations") %></a>
                                                <br>
                                                Статус: <span class="c-3"><%# Eval("State") %></span></td>
                                            <td>Город: <%# Eval("City") %><br>
                                                Рейтинг: <span class="i i-rating"><i class="i i-rating-3"></i></span>
                                                <br>
                                                <!-- possible to set width manually, i.e. <i class="i i-rating-3" style="width: 53.25%"> -->
                                                <a href="#"><%# Eval("Photoes") %></a>/ <a href="#"><%# Eval("Videos") %></a></td>
                                            <td class="actions"><a href="#" class="i i-remove"></a></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <br />
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="b-show-more">
                                <a href="#" class="a-3">Все контрагенты</a>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </section>
                <section>
                    <asp:Repeater runat="server" ID="RepeaterFavouriteArticles">
                        <HeaderTemplate>
                            <header>
                                <h2 class="lobstertitle">Избранные статьи</h2>
                            </header>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="b-list-item clearfix">
                                <table class="va-middle">
                                    <col width="180">
                                    <col>
                                    <col width="16">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <img src="<%# Eval("Avatar") %>" alt="<%# Eval("Title") %>"></td>
                                            <td>
                                                <h3><a href="<%# Eval("Link") %>"><%# Eval("Title") %></a></h3>
                                                <%# Eval("Description") %> </td>
                                            <td class="actions"><a href="#" class="i i-remove"></a></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div class="b-show-more">
                                <a href="#" class="a-3">Все статьи</a>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </section>
            </div>
        </div>
    </div>
</div>

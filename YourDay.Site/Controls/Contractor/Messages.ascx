<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Messages.ascx.cs" Inherits="YourDay.Site.Controls.Contractor.Messages" %>
<%@ Register src="../Comments&Messages/NewMessagePopup.ascx" tagname="NewMessagePopup" tagprefix="uc1" %>
<script type="text/javascript">
    function pageLoad() {
        setHistoryPoint(<%=YourDay.Security.MembershipUser.CurrentUser.Id %>, '<%= this.Type %>','','','',  0, 10, 'Нет фильтра');
        MakeBackButtonDisabled();
        //TODO: Перенести в код
        <% if(!String.IsNullOrEmpty(EventCardId)) 
        { %>
        var c = hist[hist.length - 1];
        c.sh = true;
        setHistoryPoint(<%=YourDay.Security.MembershipUser.CurrentUser.Id %>, '<%= this.Type %>','<%= this.EventCardId %>','','',  0, 10, '<%=YourDay.BLL.Get.EventCard(Int32.Parse(this.EventCardId)).Title %>');
        <% } else if(!String.IsNullOrEmpty(UserId)) 
        {%>
         var c = hist[hist.length - 1];
        c.sh = true;
        setHistoryPoint(<%=YourDay.Security.MembershipUser.CurrentUser.Id %>, '<%= this.Type %>','','<%= this.UserId %>','',  0, 10, '<%=YourDay.BLL.Manager.GetUser(UserId).FullName %>');
        
       <% } else if(!String.IsNullOrEmpty(Date)) 
        {%>
         var c = hist[hist.length - 1];
        c.sh = true;
        setHistoryPoint(<%=YourDay.Security.MembershipUser.CurrentUser.Id %>, '<%= this.Type %>','','','<%= this.Date %>',  0, 10, '<%=this.Date %>');
        
        <% } %>
    }
</script>

<div class="messageslinks" id="messagesLink">
   
    <div class="el f">Фильтр:</div>
    <div class="el c"><a href="#" id="currentFilterDel" onclick="getMessagesBack();return false;">Нет фильтра</a></div>
    &nbsp;&nbsp;
    <div class="sel el">Выделить:</div>
     <%--<div class="el a"><a href="#" onclick="selectCheckBoxes('all');return false;">Все</a></div>--%>
    <div class="el n"><a href="#" onclick="selectCheckBoxes('new');return false;">Новые</a></div>
    <a href="#" id="markAsRead" onclick="markMessagesAsAlreadyRead();return false;">
    <img src="/Pict/Contractor/markasRead.png" border="0" alt="Отметить как прочитанное" style="position:relative; top:3px" />
    </a>
    <div class="other"></div>
</div>
<div class="messages" id="messages">
<br />
    

<asp:Repeater ID="RepeaterMessages" runat="server">
    <ItemTemplate>
        <div class="oneTop"></div>
        <div class="one oneMiddle" runat="server" id="MessageBlock" clientidmode="Predictable">
            <input type="hidden" value="<%# Eval("Already") %>" id="<%# "message_hf_" + Eval("ID") %>" />
            <div class="cb elem">
               <input type="checkbox" <%# Eval("Disabled") %>  <%# Eval("Checked") %>  id="<%# "message_" + Eval("ID") %>" />
            </div>
            <div class="avatar elem">
                <img src="<%# Eval("ImageSrc") %>" alt="<%# Eval("ImageAlt") %>" width="70px" />
            </div>
            <div class="name elem">
                <a href="#" onclick="<%# Eval("AuthorLink") %>"><%# Eval("Author") %></a><br />
                <span onclick="<%# Eval("DateLink") %>" style="cursor:pointer;">
                <%# Eval("DateTime") %>
                </span>
            </div>
            <div class="itself elem">
                 <a href="#" onclick="<%# Eval("MessageLink") %>"><%# Eval("MessageTitle") %></a><br />
                 <%# Eval("Annotation") %>
            </div>
        </div>
        <div class="oneMiddle answer">
        <a href="#" onclick="showNewMessagePopup(this);return false;" class="answerlink" id="<%# "newmessage_show_popup_" + Eval("ID") %>">Ответить</a>
        <div class="answerpositionblock">
            <div class="answertextblock" id="<%# "newmessage_popup_" + Eval("ID") %>">
                <uc1:NewMessagePopup LinkId='<%# Eval("ID") %>' RelationId='<%# Eval("RelationId") %>' ReceiverId='<%# Eval("ReceiverId") %>' ID="NewMessagePopup1" runat="server" />
            </div>
        </div>
        </div>
        <div class="oneBottom"></div>

      
    </ItemTemplate>
</asp:Repeater>

<%--<div class="messagesdark" id="messagesdark">

</div>--%>
</div>

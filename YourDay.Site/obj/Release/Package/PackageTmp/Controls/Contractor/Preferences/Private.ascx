﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Private.ascx.cs" Inherits="YourDay.Site.Controls.Contractor.Preferences.Private" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script src="/JS/Contractor/ajaxupload.js" type="text/javascript"></script>
<script src="/JS/Contractor/Cabinet.js" type="text/javascript"></script>
<script type="text/javascript">
    function pageLoad() {
        setgOnLoad();
        document.forms(0).action = "";
    }

</script>
<div class="privateinfo">
    Фото<br />
    <asp:UpdatePanel runat="server" ID="UpdatePanelAvatar" ClientIDMode="Static" UpdateMode="Conditional"  RenderMode="Inline">
    <ContentTemplate>
   
    <asp:Image ID="ImageAvatar" ClientIDMode="Static" runat="server" Width="100" Height="100" />
    
    </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="LinkButtonDelAvatar" />
    </Triggers>
    </asp:UpdatePanel>
      &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButtonDelAvatar" runat="server" 
        onclick="LinkButtonDelAvatar_Click">Удалить</asp:LinkButton><br />
      
       <div id="uploadButton" class="button">
              <img id="load" src="/Pict/Contractor/load.png"/>
         </div>

         <br />
         <div>Имя*</div>
         <div class="name"><asp:TextBox runat="server" ID="TextBoxName" 
                onkeyup="setg(this);" 
                onpaste="setg(this);" 
                oninput="setg(this);"
                onblur="makesel(this,false);"
                onfocus="makesel(this ,true);"
                autocomplete="off"
                ClientIDMode="Static"></asp:TextBox>
         </div>
         <br />
         <div>Фамилия*</div>
         <div class="surname"><asp:TextBox runat="server" ID="TextBoxSurname" 
                onkeyup="setg(this);" 
                onpaste="setg(this);" 
                oninput="setg(this);"
                onblur="makesel(this,false);"
                onfocus="makesel(this ,true);" ClientIDMode="Static"></asp:TextBox>
         </div>
         <br />

       <%--  <div>Специализация*</div>
         <div class="specialization"><asp:TextBox runat="server" ID="TextBoxSpecialization" 
                onkeyup="setg(this);" 
                onpaste="setg(this);" 
                oninput="setg(this);"
               onblur="makesel(this,false);"
                onfocus="makesel(this ,true);"
         ClientIDMode="Static"></asp:TextBox>
         </div>--%>
         <br />
        
         <div  onmouseover="checkpi(true);" onmouseout="checkpi(false);">
    <asp:ImageButton ID="ImageButtonSave" ImageUrl="~/Pict/Common/save.png"  style="opacity:0.5;"
                 CssClass="btnsave" Enabled="false" ClientIDMode="Static" runat="server" 
                 onclick="ImageButtonSave_Click" />
       </div>
</div>
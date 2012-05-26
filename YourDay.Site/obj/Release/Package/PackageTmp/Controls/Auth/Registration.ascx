<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Registration.ascx.cs" Inherits="YourDay.Site.Controls.Auth.Registration" %>

<div class="grayauthblock" id="registrationblock">
<div class="authblock">
<div class="closeblock">
<a href="#" onclick="h();return false;">
<img src="/Pict/Auth/close.png" border="0" />
</a>
</div>
<div class="breaker"></div>
<div class="lobstertitle">
    <asp:Label ID="LabelRegistrationTitle" runat="server" Text="Label"></asp:Label>
</div>

<div class="breaker"></div>
    <asp:UpdatePanel ID="UpdatePanelCreateWizard" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server"  CssClass="regfields"
    RequireEmail="False" oncreatinguser="CreateUserWizard1_CreatingUser" 
            ActiveStepIndex="0">
    <WizardSteps>
    
        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
            <ContentTemplate>
             <div class="radiobuttons">
                <asp:RadioButton ID="RadioButtonSimpleUser" runat="server" GroupName="Role" Text="Я хочу заказать праздник" onclick="sb(this);" ClientIDMode="Static" Checked="true" Font-Bold="true" />
                <br /><br  style="font-size:5pt;"/>
                <asp:RadioButton ID="RadioButtonContractor" runat="server" GroupName="Role" Text="Я организую праздники" onclick="sb(this);"  ClientIDMode="Static"/>
             </div>
            <br /><br />
            <div>
                <div><%= YourDay.Constants.Strings.EMail %></div>
                <div><asp:TextBox ID="UserName" runat="server"  ClientIDMode="Static"
                onkeyup="a(this);" 
                onpaste="a(this);" 
                oninput="a(this);"
                onblur="n(this);"
                onfocus="a(this);"
                autocomplete="off"
                ></asp:TextBox></div><div class="breaker">
                <asp:Label runat="server" ID="LoginError" ClientIDMode="Static" CssClass="error"></asp:Label>
                </div>
                <div><%= YourDay.Constants.Strings.Pwd%></div>
                <div> <asp:TextBox ID="Password" runat="server" TextMode="Password" ClientIDMode="Static"
                 onkeyup="p(this);"
                ></asp:TextBox></div>
                <div class="breaker">
                <asp:Label runat="server" ID="PasswordError" ClientIDMode="Static" CssClass="error"></asp:Label>
                </div>
                <div><%= YourDay.Constants.Strings.ConfirmPwd%></div>
                <div><asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" ClientIDMode="Static"
                onkeyup="p(this);"
                onpaste="p(this);" 
                oninput="p(this);"
                ></asp:TextBox></div>
                <div class="breaker">
                <asp:Label runat="server" ID="ConfirmPasswordError" ClientIDMode="Static" CssClass="error"></asp:Label>
                </div>
            </div>
            
            </ContentTemplate>
            <CustomNavigationTemplate>
            <div class="createuserbutton">
                   <asp:ImageButton ID="StepNextButton" 
                   ClientIDMode="Static"
                   runat="server" 
                   CommandName="MoveNext"  
                   ImageUrl="~/Pict/Auth/createuser.png"
                   ValidationGroup="CreateUserWizard1"
                   style="opacity:0.5;filter: alpha(opacity=50);"
                   Enabled="false"
                      />
            </div>
            <div id="ggg"></div>
            </CustomNavigationTemplate>
        </asp:CreateUserWizardStep>
        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                
            <ContentTemplate>
                <div class="lobstertitle" style="position:relative; bottom:35px;">
                успешно завершена!
                </div>
                <div>
               <%=  YourDay.Constants.Strings.RegistrationComplete%>
                </div>

                           <%-- <asp:Button ID="ContinueButton" runat="server" CausesValidation="False"  OnClientClick="h();"
                                CommandName="Continue" Text="Continue" ValidationGroup="CreateUserWizard1" />--%>
                       <div class="createuserbutton">
                        <asp:ImageButton ID="ContinueButton" 
                   ClientIDMode="Static"
                   runat="server" 
                   OnClientClick="h();"
                   CommandName="Continue"  
                   ImageUrl="~/Pict/Auth/continue.png"
                   ValidationGroup="CreateUserWizard1"
                      />
                       </div>
            </ContentTemplate>
        
        </asp:CompleteWizardStep>
        
    </WizardSteps>
</asp:CreateUserWizard>
    </ContentTemplate>
    </asp:UpdatePanel>

</div>
</div>

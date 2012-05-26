<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePwd.ascx.cs" Inherits="YourDay.Site.Controls.Contractor.Preferences.ChangePwd" %>
<div  class="privateinfo">
    <div>Старый пароль</div>
    <div>
        <asp:TextBox runat="server" ID="TextBoxOldPwd" ValidationGroup="pwdChange"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="TextBoxOldPwd" runat="server" ValidationGroup="pwdChange">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ControlToValidate="TextBoxOldPwd" runat="server" ValidationExpression="\S{6,}" ValidationGroup="pwdChange"></asp:RegularExpressionValidator>
    </div>
    <br />

    <div>Новый пароль</div>
    <div>
        <asp:TextBox runat="server" ID="TextBoxNewPwd" ValidationGroup="pwdChange"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxNewPwd" ControlToValidate="TextBoxNewPwd" runat="server" ValidationGroup="pwdChange">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator  ValidationGroup="pwdChange" ID="RegularExpressionValidatorTextBoxNewPwd" ControlToValidate="TextBoxNewPwd" runat="server" ValidationExpression="\S{6,}">*</asp:RegularExpressionValidator>
        

    </div>
    <br />

    <div>Повторите новый пароль</div>
    <div>
        <asp:TextBox runat="server" ID="TextBoxRepeatNewPwd" ValidationGroup="pwdChange"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxRepeatNewPwd" ValidationGroup="pwdChange" ControlToValidate="TextBoxRepeatNewPwd" runat="server">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxRepeatNewPwd" ValidationGroup="pwdChange" ControlToValidate="TextBoxRepeatNewPwd" runat="server" ValidationExpression="\S{6,}">*</asp:RegularExpressionValidator>
        <asp:CompareValidator ID="CompareValidatorTextBoxRepeatNewPwd"  ValidationGroup="pwdChange" ControlToValidate="TextBoxRepeatNewPwd" ControlToCompare="TextBoxNewPwd" Operator="Equal"  runat="server">*</asp:CompareValidator>

    </div>
    <br />

    <asp:ImageButton ID="ImageButtonSave" ImageUrl="~/Pict/Common/save.png" 
                 CssClass="btnsave" ClientIDMode="Static" runat="server" onclick="ImageButtonSave_Click"   ValidationGroup="pwdChange"
                  />
</div>

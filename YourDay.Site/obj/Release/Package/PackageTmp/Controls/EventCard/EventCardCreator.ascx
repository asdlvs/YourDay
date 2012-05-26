<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventCardCreator.ascx.cs" Inherits="YourDay.Site.Controls.EventCard.EventCardCreator" %>
<%@ Register src="SubcategoriesList.ascx" tagname="SubcategoriesList" tagprefix="uc1" %>
<link href="/CSS/EventCard.css" rel="stylesheet" type="text/css" />
<link href="/CSS/Jquery.UI/jquery.ui.all.css" rel="stylesheet" type="text/css" />
<script src="/JS/DatePicker/jquery.ui.datepicker.js" type="text/javascript"></script>

<script src="/JS/DatePicker/jquery.ui.datepicker-ru.js" type="text/javascript"></script>
<link href="/CSS/DropDown/cusel.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript">

        jQuery(document).ready(function () {
            //Enabled = "false"
            document.getElementById("ImageButtonReady").setAttribute("disabled", "disabled");
            var params = {
                changedEl: ".lineForm select",
                visRows: 5,
                scrollArrows: true
            }
            cuSel(params);
            var params = {
                changedEl: "#type",
                scrollArrows: false
            }
            cuSel(params);
        });


        $(function () {
            $("#datepicker").datepicker();
        });
	</script>




<div class="eventcardcreateblocktop"></div>
<div class="eventcardcreateblock">
<div class="content">
<div class="lobstertitle">
<%= YourDay.Constants.Strings.EventCard %>
</div>
<br /><br />
<div class="smalltitle">
<%= YourDay.Constants.Strings.EventCardTitle %>
<span id="ectitleerror" runat="server" clientidmode="Static">
</span>
</div>
<div>

    <asp:TextBox ID="TextBoxTitle" runat="server" ClientIDMode="Static"  autocomplete="off"
    onkeyup="cect(this, 5, 'ectitleerror', '( длина должна быть больше 5 символов )', 'tgood');"
    onpaste="cect(this, 5, 'ectitleerror', '( длина должна быть больше 5 символов )', 'tgood');"
    oninput="cect(this, 5, 'ectitleerror', '( длина должна быть больше 5 символов )', 'tgood');"
    onblur="cbs(this, tgood, 'ectitleerror');"
    onfocus="cect(this, 5, 'ectitleerror', '( длина должна быть больше 5 символов )', 'tgood');"
    ></asp:TextBox>
</div>

<br />

<div style=" display:table">
<div style="display:table-cell;width:150px;float:left;">
<div class="table">
<div class="smalltitle" style="display:table-row">

<%= YourDay.Constants.Strings.EventCardType %>
</div>
<div style="display:table-row" class="lineForm">
    <asp:DropDownList ID="DropDownListEventCardType" runat="server" ClientIDMode="Static" DataTextField="Title" DataValueField="Id" Width="140px">
    </asp:DropDownList>
</div>
</div>
</div>

<div style="display:table-cell;width:80px;float:left;">
<div class="table">
<div class="smalltitle" style="display:table-row">

<%= YourDay.Constants.Strings.Date %>
</div>

<div style="display:table-row">
<input type="text" id="datepicker" runat="server" clientidmode="Static" onkeyup="cd(this);" onchange="cd(this);"/>
    <%--<asp:DropDownList ID="DropDownListDate" runat="server" ClientIDMode="Static">
    </asp:DropDownList>--%>
</div>
</div>
</div>

<div style="display:table-cell;float:right;">
<div class="table">
<div class="smalltitle" style="display:table-row;left:10px;">

<%= YourDay.Constants.Strings.Time %>
</div>

    <div style="display:table-row; ">
        <span style="position:relative; bottom:8px;">
            <%= YourDay.Constants.Strings.From %>
        </span>
        <span class="lineForm">
        <asp:DropDownList ID="DropDownListFromTime" runat="server" ClientIDMode="Static" name="fromtime" CssClass="dropdowntime"></asp:DropDownList>
        </span>
        <span style="position:relative; bottom:8px;">
            <%= YourDay.Constants.Strings.To %>
        </span>
        <span class="lineForm">
            <asp:DropDownList ID="DropDownListToTime" runat="server" ClientIDMode="Static" name="totime" CssClass="dropdowntime">
            </asp:DropDownList>
        </span>
    </div>


</div>
</div>
</div>

<br />
<div class="smalltitle">
<%= YourDay.Constants.Strings.EventCardDescription %>
<span id="descriptionerror" runat="server" clientidmode="Static">
</span>
</div>
<div>
    <asp:TextBox ID="TextBoxDescription" runat="server" ClientIDMode="Static" TextMode="MultiLine"
    onkeyup="cect(this, 25, 'descriptionerror', '( длина должна быть больше 25 символов )', 'dgood');"
    onpaste="cect(this, 25, 'descriptionerror', '( длина должна быть больше 25 символов )', 'dgood');"
    oninput="cect(this, 25, 'descriptionerror', '( длина должна быть больше 25 символов )', 'dgood');"
    onblur="cbs(this, dgood, 'descriptionerror');"
    onfocus="cect(this, 5, 'descriptionerror', '( длина должна быть больше 25 символов )', 'dgood');"
    ></asp:TextBox>
</div>

<br />
<div style=" display:table">
<div style="display:table-cell;width:165px;float:left;">
<div class="table">
<div class="smalltitle" style="display:table-row">

<%= YourDay.Constants.Strings.WhoSee %>
</div>
<div style="display:table-row">
  <span class="lineForm">
    <asp:DropDownList ID="DropDownListWhoSee" runat="server" ClientIDMode="Static" DataTextField="Value" DataValueField="Key"
    onchange="wsc(this);"
    >
    </asp:DropDownList>
</span>
</div>
</div>
</div>

<div style="display:table-cell;width:138px;float:left;">
<div class="table">
<div class="smalltitle" style="display:table-row">

<%= YourDay.Constants.Strings.Budjet %>
</div>

<div style="display:table-row" class="budjet">
    <asp:TextBox ID="TextBoxBudjet" runat="server" autocomplete="off"
    onkeyup="cbud(this);"
    onpaste="cbud(this);"
    oninput="cbud(this);"
    onblur="cbs(this, bgood);"
    onfocus="cbud(this);"
    ></asp:TextBox>
    <%= YourDay.Constants.Strings.Currency %>
</div>
</div>
</div>
</div>
</div>
<br />



<div class="categoriesinfo" id="categoriesinfo" style="display:none;">

    <div class="smalltitle" style="display:table-row">
        <%= YourDay.Constants.Strings.EventCardSearchCategory %>
    </div>
    <br />
    <div style="display:table-row">
    <input type="hidden" id="selectedcategories" class="selectedcategories" runat="server" clientidmode="Static"/>


    

    <div id="selectedcategoriesc1" class="smalltitle" style="width:100%;"></div>
   <%-- <div id="selectedcategoriesc2" class="smalltitle column"></div>--%>
    </div>
    <div style="display:table-row">
        <img src="/Pict/Contractor/plusIcon.png" style="position:relative; top:2px" />
        <a href="#" onclick="ssc(); return false;">
            <%= YourDay.Constants.Strings.AddEventCardCategory %>
        </a>
    </div>
    <br />

     <div class="smalltitle" style="display:table-row">
        <%= YourDay.Constants.Strings.ShowPlacementFrom %> &nbsp;
         <asp:CheckBox ID="CheckBoxEA" runat="server" style="position:relative; top:2px;" /><%= YourDay.Constants.Strings.EventAgencyWhom %> &nbsp;
         <asp:CheckBox ID="CheckBoxC" runat="server"  style="position:relative; top:2px;" /><%= YourDay.Constants.Strings.ContractorsWhom %> &nbsp;
    </div>

    </div>
<br />
<div class="button">
    <asp:ImageButton ID="ImageButtonReady" runat="server" OnClientClick="savessc();" ClientIDMode="Static"
        ImageUrl="/Pict/EventCard/ready.png" onclick="ImageButtonReady_Click"
        style="opacity:0.5;filter: alpha(opacity=50);"
                   
         />
</div>
</div>
<div class="eventcardcreateblockbottom"></div>
<uc1:SubcategoriesList ID="SubcategoriesList1" runat="server" />

<div style="display:none;" id="repeaterItem" >

<div style="display:table; width:100%;" >
    
    <div class="column">
        <input id="subcategory{0}" onclick="ch(this);" type="checkbox" CHECKED="checked" value="{1}"/>
        {2}
    </div>
    <div class="column">
    
    <div class="column">
        <span style="position:relative; bottom:8px;">
            <%= YourDay.Constants.Strings.From %>
        </span>
        <span class="lineForm">
            <asp:DropDownList ID="DropDownListFromTimeCategory" runat="server" ClientIDMode="Static" name="totime" CssClass="dropdowntime">
            </asp:DropDownList>
        </span>
    </div>
    <div class="column">
        <span style="position:relative; bottom:8px;">
            <%= YourDay.Constants.Strings.To %>
        </span>
        <span class="lineForm">
            <asp:DropDownList ID="DropDownListToTimeCategory" runat="server" ClientIDMode="Static" name="totime" CssClass="dropdowntime">
            </asp:DropDownList>
        </span>
    </div>

    
    </div>

</div>

</div> 



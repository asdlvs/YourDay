function changeecstatus(cId, ecId, sId, sender) {
    if (sender != null && sender.value != null) {
        sendchangestosrv(cId, ecId, sId, sender.value);
    }
}

function sendchangestosrv(cId, ecId, sId, s) {
    YourDay.Site.WS.WS.ChangeEventCardCompanyState(cId, ecId, sId, s);
}

function sendmessage(ecId, rId, sender, popup, ctr) {
    var tbObject = document.getElementById(sender.id.replace('anchorSendMessage', 'TextBoxNewMessage'));
    var message = tbObject.value;
    YourDay.Site.WS.WS.WritePrivateMessageToEcFromContractor(ecId, rId, message, ctr,
    function (data) {
        if (popup) {

            getMessagesSuccess(data, true, sender);
            
        }
        else {
            sendmessageSuccess(data, sender);
        }
    },
    sendmessageFail, sender);
    tbObject.value = "";
    tbObject.disabled = true;
}

function sendmessageSuccess(data, sender) {
    if (data == null)
        return;
    else {
        var mbId = sender.id.replace("anchorSendMessage", "messagesitems");
        
        var messageBlock = document.getElementById(mbId);
        _fillMessageDivWithData(messageBlock.children[0], data[0]);
        _fillMessageDivWithData(messageBlock.children[1], data[1]);

        document.getElementById(sender.id.replace("anchorSendMessage", "TextBoxNewMessage")).disabled = false;

    }
}

function _fillMessageDivWithData(div, data) {
    if (div != null) {
        div.children[0].innerHTML = "<a href=\"" + data.U + "\">" + data.A + "</a>";
        div.children[1].innerHTML = data.M;
        div.children[2].innerHTML = data.T;
    }
}

function showMessageBox(sender, rpl) {
    var str = sender.id;
    var mb = document.getElementById(str.replace(rpl, "messagesBlock"));
    var img = str.replace(rpl, "arrow");
    var link = str.replace(rpl, "HyperLinkTitle");
    var pencil = str.replace(rpl, "anchorMessages");

    if (mb.style.display == "none" || mb.style.display == "") {
        mb.style.display = "table";
        document.getElementById(link).style.color = "#d7bf5e";
        document.getElementById(link).style.position = "relative";
        document.getElementById(link).style.right = "30px";
        document.getElementById(img).style.position = "relative";
        document.getElementById(img).style.right = "30px";
        document.getElementById(img).src = document.getElementById(img).src.replace("arrow", "arrowdown");
        document.getElementById(pencil).style.display = "none";
    }
    else {
        mb.style.display = "none";
        document.getElementById(img).src = document.getElementById(img).src.replace("arrowdown", "arrow");
        document.getElementById(link).style.color = "#a07d97";
        document.getElementById(link).style.position = "relative";
        document.getElementById(link).style.right = "0";
        document.getElementById(img).style.position = "relative";
        document.getElementById(img).style.right = "0";
        document.getElementById(pencil).style.display = "table-cell";
    }
}

function sendmessageFail(ex) {
    alert(ex.Message);
}

function getevents(y, m, d, c) {
    YourDay.Site.WS.WS.GetECList(y, m, d, c, function (data) {
        document.getElementById("events").innerHTML = data;
        if (c == null || c == 1) {
            document.getElementById("dateperionselected").innerHTML = " на " + d + "." + m + "." + y;
        }
        else {
            var date = new Date(y, m - 1, d);
            var date2 = new Date(date);
            date2.setDate(date.getDate() + c);
            document.getElementById("dateperionselected").innerHTML = " c " + d + "." + m + "." + y + " по " + date2.getDate() + "." + (date2.getMonth() + 1) + "." + date2.getFullYear();

        }
        //TODO: ХК
        renderddl();
        document.getElementById("dayfilter_1").style.color = "#a07d97";
        document.getElementById("dayfilter_1").style.textDecoration = "underline";
        document.getElementById("dayfilter_3").style.color = "#a07d97";
        document.getElementById("dayfilter_3").style.textDecoration = "underline";
        document.getElementById("dayfilter_3").onclick = function () { getevents(y,m,d,3);return false; };
        document.getElementById("dayfilter_7").style.color = "#a07d97";
        document.getElementById("dayfilter_7").style.textDecoration = "underline";
        document.getElementById("dayfilter_7").onclick = function () { getevents(y, m, d, 7); return false; };
        document.getElementById("dayfilter_" + c).style.color = "#FFFFFF";
        document.getElementById("dayfilter_" + c).style.textDecoration = "none";

    });
}

function renderddl() {
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
}

var hist = new Array();

function setHistoryPoint(u, ty, e, o, d, s, ta, i) {
    
        var hPoint = new Object();
        hPoint.u = u;
        hPoint.e = e;
        hPoint.o = o;
        hPoint.d = d;
        hPoint.ty = ty;
        hPoint.s = s;
        hPoint.ta = ta;
        //Костыль, чтобы при добавлении строки 12.12.2011 в 12:00, в заголовке фильтра находилась только дата
        var reg = /\d{2}.\d{2}.\d{4}/;
        if (reg.test(i)) {
            var newi = i.replace(/ в \d{2}:\d{2}/, "");
            hPoint.i = newi;
        }
        else {
            hPoint.i = i;
        }
        var backFilter = document.getElementById("currentFilterDel");
        backFilter.innerHTML = hPoint.i;
        backFilter.setAttribute("onclick", "getMessagesBack();return false;");
        backFilter.style.textDecoration = "underline";
        backFilter.style.cursor = "pointer";
        hist.push(hPoint);
    

}

function getMessagesBack() {
    showLoadingBlock();
    var hPoint = hist.pop();
    if (hPoint != null) {

        while (hPoint.sh == null) {
            hPoint = hist.pop();
        }

        if (hPoint != null) {
            YourDay.Site.WS.WS.GetMessages(hPoint.u, hPoint.ty, hPoint.e, hPoint.o, hPoint.d, hPoint.s, hPoint.ta, getMessagesSuccess);
            if (hist.length == 0) {
                setHistoryPoint(hPoint.u, hPoint.ty, hPoint.e, hPoint.o, hPoint.d, 0, 10, 'Нет фильтра');
                MakeBackButtonDisabled();
            }
            else {
                var backFilter = document.getElementById("currentFilterDel");
                backFilter.innerHTML = hPoint.i;
            }
        }
    }
}

function MakeBackButtonDisabled() {
    var backFilter = document.getElementById("currentFilterDel");
    backFilter.setAttribute("onclick", "return false;");
    backFilter.style.textDecoration = "none";
    backFilter.style.cursor = "default";
}
function getMessages(u, ty, e, o, d, s, ta, sender) {

    YourDay.Site.WS.WS.GetMessages(u, ty, e, o, d, s, ta, getMessagesSuccess);
    showLoadingBlock();
    var c = hist[hist.length - 1];
    if (c == null || c.u != u || c.e != e || c.ty != ty || c.o != o || c.d != d || c.s != s || c.ta != ta) {
        c.sh = true;
        setHistoryPoint(u, ty, e, o, d, s, ta, sender.innerHTML);
    }

}

function showLoadingBlock() {
    
   // document.getElementById("messagesdark").style.visibility = "visible";
}

function hideLoadingBlock() {
   /* var dark = document.createElement("div");
    dark.setAttribute("id", "messagesdark");
    dark.setAttribute("class", "messagesdark");
    document.getElementById("messages").appendChild(dark);
    document.getElementById("messagesdark").style.visibility = "hidden";*/
}



function getMessagesSuccess(data, inBegin, sender) {

    var messages = document.getElementById("messages");
    if (!inBegin) {
        messages.innerHTML = "";
    }
    /*var c = messages.children.length;
    for (var i = 0; i < c; i++) {
    messages.removeChild(messages.children[0]);
    }*/

    var c = data.length;
    for (var i = 0; i < c; i++) {
        var el = "<div class=\"oneTop\"></div><div class=\"one oneMiddle\" runat=\"server\" id=\"MessageBlock\" clientidmode=\"Predictable\">" +
            "<input type=\"hidden\" value=\"" + data[i].AR + "\" id=\"message_hf_\" + " + data[i].ID + " />" +
            "<div class=\"cb elem\">" +
               "<input type=\"checkbox\" "+ data[i].D + " " + data[i].C +" id=\"message_\" + " + data[i].ID + " />" +
            "</div>" +
            "<div class=\"avatar elem\">" +
                "<img src=\"" + data[i].IS + "\" alt=\"" + data[i].IA + "\" width=\"70px\" />" +
            "</div>" +
            "<div class=\"name elem\">" +
                "<a href=\"#\" onclick=\"" + data[i].AL + "\">" + data[i].A + "</a><br />" +
                "<span onclick=\"" + data[i].DL + "\" style=\"cursor:pointer;\">" +
                 data[i].DT + 
                "</span>" +
            "</div>" +
            "<div class=\"itself elem\">" +
                 "<a href=\"#\" onclick=\"" + data[i].ML + "\">" + data[i].MT + "</a><br />" +
                  data[i].M + 
            "</div>" +
        "</div><div class=\"oneMiddle answer\">"+
       "<a href=\"#\" onclick=\"showNewMessagePopup(this);return false;\" class=\"answerlink\" id=\"newmessage_show_popup_" + data[i].ID +"\">Ответить</a>"+
        "<div class=\"answerpositionblock\">"+
            "<div class=\"answertextblock\" id=\"newmessage_popup_" + data[i].ID +"\">"+
               data[i].CR + 
            "</div>"+
       " </div>"+
        "</div>"+
        "<div class=\"oneBottom\"></div>";
        if (!inBegin) {
            messages.innerHTML += el;
        }
        else {
            messages.innerHTML = el + messages.innerHTML;
            var tbObject = document.getElementById(sender.id.replace('anchorSendMessage', 'TextBoxNewMessage'));
            tbObject.disabled = false;
        }
    }
    hideLoadingBlock();
}

function selectCheckBoxes(w) {
    var messages = document.getElementById("messages");
    var c = messages.children.length;
    for (var i = 0; i < c; i++) {
        var hf = messages.children[i].children[0];
        if (hf != undefined) {
            var cbId = hf.id.replace("_hf", "");
            if (w == "all") {
                document.getElementById(cbId).checked = true;
            }
            else if (w == "new" && (hf.value == "false" || hf.value == "False")) {
                document.getElementById(cbId).checked = true;
            }
            else {
                document.getElementById(cbId).checked = false;
            }
        }
    }


}

function markMessagesAsAlreadyRead() {
    var arMessages = new Array();
    var cbArray = new Array();
    var hfArray = new Array();
    var messages = document.getElementById("messages");
    var c = messages.children.length;
    for (var i = 0; i < c; i++) {
        var hf = messages.children[i].children[0];
        if (hf != undefined) {
            var cb = document.getElementById(hf.id.replace("_hf", ""));

            if (cb.checked && !cb.disabled) {
                arMessages.push(cb.id);
                hfArray.push(hf)
                cbArray.push(cb);
            }
        }

    }
    if (arMessages == 0)
        return;
    YourDay.Site.WS.WS.SetMessagesAsAR(arMessages, function () {
        var c = hfArray.length;
        for (var i = 0; i < c; i++) {
            hfArray[i].value = "True";
        }
        c = cbArray.length;
        for (var i = 0; i < c; i++) {
            cbArray[i].checked = false;
        }
    });


}

var tbs = new Array();

var e1 = new Object();
e1.name = "TextBoxName";
e1.g = false;
tbs.push(e1);

var e2 = new Object();
e2.name = "TextBoxSurname";
e2.g = false;
tbs.push(e2);

//var e3 = new Object();
//e3.name = "TextBoxSpecialization";
//e3.g = false;
//tbs.push(e3);


function checkpi(on) {
    for (var i = 0; i < tbs.length; i++) {
        var el = document.getElementById(tbs[i].name);

        if (on) {
            if (el.value == "") {
                el.style.borderColor = "#FF0000";
            }
        }
        else {
            el.style.borderTop = "1px solid #3d3d3d";
            el.style.borderLeft = "1px solid #3d3d3d";
            el.style.borderBottom = "1px solid #ffffff";
            el.style.borderRight = "1px solid #ffffff";
        }

    }
}

function setgOnLoad() {
    for (var i = 0; i < tbs.length; i++) {
        var tb = document.getElementById(tbs[i].name);
        if(tb.value != "")
            tbs[i].g = true;
    }
}

function setg(sender) {
    for (var i = 0; i < tbs.length; i++) {
        if (sender.id == tbs[i].name) {
            if (sender.value != "") {
                tbs[i].g = true;
            }
            else {
                tbs[i].g = false;
            }

        }
         
       
    }


    var btnSave = document.getElementById("ImageButtonSave");
    var good = true;
    for (var i = 0; i < tbs.length; i++) {
        if (tbs[i].g == false) {
            good = false;
        }
    }
    if (good) {
        btnSave.style.opacity = 1;
        btnSave.removeAttribute("disabled");
    }
    else {
        btnSave.style.opacity = 0.5;
        btnSave.setAttribute("disabled", "disabled");
    }
}

function makesel(sender,f) {
    if (f) {
        sender.style.borderColor = "#96ab42";
    }
    else {
        sender.style.borderTop = "1px solid #3d3d3d";
        sender.style.borderLeft = "1px solid #3d3d3d";
        sender.style.borderBottom = "1px solid #ffffff";
        sender.style.borderRight = "1px solid #ffffff";
    }
}

function showNewMessagePopup(sender) {
    $(".answertextblock").css("visibility", "hidden");
    var sId = sender.id;
    var popupId = sender.id.replace("_show", "");
    var popup = document.getElementById(popupId);
    if (popup.style.visibility == "visible")
        popup.style.visibility = "hidden";
    else
        popup.style.visibility = "visible";
}

function hidemessagepopup(id) {
    document.getElementById("newmessage_popup_" + id).style.visibility = "hidden";
}



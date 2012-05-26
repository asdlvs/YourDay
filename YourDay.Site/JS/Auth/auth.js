
var ws = YourDay.Site.WS.WS;
var goodl;
var goodp;
function a(tb) {
    if (tb.value.length > 0) {
        var reg = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
        var match = reg.exec(tb.value);
        if (match) {
            YourDay.Site.WS.WS.CheckLoginForExistance(tb.value,
    function () {
        g(tb, 1);
    },
    function () {
        b(tb, "Такой e-mail уже зарегистрирован.", 1);
    });
        }
        else {
            b(tb, "", 1);
        }
    } else {
        ns(tb);
    }
}

function g(sender, l) {
    sender.style.borderColor = "#96ab42";
    if (l) {
        goodl = true;
        document.getElementById("LoginError").innerHTML = "";
    }
    else {
        goodp = true;
        document.getElementById(sender.id + "Error").innerHTML = "";
    }
    ok();
}

function b(sender, message, l) {
    sender.style.borderColor = "#FF0000";
    if (l) {
        goodl = false;
        document.getElementById("LoginError").innerHTML = message;
    }
    else {
        goodp = false;
        if (message) {
            document.getElementById(sender.id + "Error").innerHTML = message;
        }
    }
    ok();
}

function n(sender) {
    if (sender.value.length > 0)
    { a(sender); }
    else {
        sender.style.borderTop = "1px solid #3d3d3d";
        sender.style.borderLeft = "1px solid #3d3d3d";
        sender.style.borderBottom = "1px solid #ffffff";
        sender.style.borderRight = "1px solid #ffffff";
    }
}

function ns(sender) {
    sender.style.borderColor = "#96ab42";
}

function p(sender) {
    var p1 = document.getElementById("Password");
    var cp = document.getElementById("ConfirmPassword");

    var another;
    if (sender.id == p1.id)
    { another = cp; }
    else
    { another = p1; }

    g(sender);

    if (sender.value == another.value && sender.value.length > 5) {
        g(another); 
    }

    if (sender.value.length < 5 && another.value.length < 5) {
        b(sender, "Пароль должен быть длиннее.");
    }
    if (sender.value.length < 5) {
        b(sender);
    }

    if (another.value.length > 0 && sender.value != another.value) {
        b(sender); 
    }


}

function getLikeElements(tagName, attrName, attrValue) {
    var startSet;
    var endSet = new Array();
    if (tagName) {
        startSet = document.getElementsByTagName(tagName);
    } else {
        startSet = (document.all) ? document.all :
    document.getElementsByTagName("*");
    }
    if (attrName) {
        for (var i = 0; i < startSet.length; i++) {
            if (startSet[i].getAttribute(attrName)) {
                if (attrValue) {
                    if (startSet[i].getAttribute(attrName) == attrValue) {
                        endSet[endSet.length] = startSet[i];
                    }
                } else {
                    endSet[endSet.length] = startSet[i];
                }
            }
        }
    } else {
        endSet = startSet;
    }
    return endSet;
}

function sb(sender) {
    var c = document.getElementById("RadioButtonContractor");
    var su = document.getElementById("RadioButtonSimpleUser");
    var another;
    if (sender.id == c.id)
    { another = su; }
    else
    {another = c;}

    var e = getLikeElements("", "for", sender.id);
    e[0].style.fontWeight = "bold";
    var e2 = getLikeElements("", "for", another.id);
    e2[0].style.fontWeight = "normal";
}


function ok() {
    var snb = document.getElementById("StepNextButton");
    if(
    document.getElementById("Password").value.length > 0 &&
    document.getElementById("ConfirmPassword").value.length > 0 &&
    document.getElementById("UserName").value.length > 0 &&
    goodl == true && goodp == true
    )
    {
        snb.style.opacity = 1;
        snb.removeAttribute("disabled");
    }
    else
    {
        snb.style.opacity = 0.5;
        snb.setAttribute("disabled", "disabled");
    }

}

function h() {
    var block = document.getElementById("registrationblock");
    block.style.display = "none";
}

function ha() {
    var block = document.getElementById("authblock");
    block.style.display = "none";
   
    
}

function showregister() {
    var block = document.getElementById("registrationblock");
    block.style.display = "block";
}

function showlogin() {
    var block = document.getElementById("authblock");
    block.style.display = "block";
}


var auth = Sys.Services.AuthenticationService;
function login() {
       auth.login(
        $get('TextBoxEMail').value,
        $get('TextBoxPassword').value,
        $get('CheckBoxRememberMe').checked,
        null,
        null,
        loginsuccess,
        function (ex) { alert(ex.get_message()); });
   }

function logout(redirectUrl) {
    //$.cookie('.ASPXAUTH', '', { expires: -1 });
    //document.location = redirectUrl;
       auth.logout(redirectUrl, null, null, null);
   }

   function loginsuccess(data) {
       if (auth.get_isLoggedIn()) {
           ha();
           ws.GetTopMenuHtml(function (data) {
               var authmaindiv = document.getElementById("authmaindiv");
               authmaindiv.innerHTML = data;
           });
           anchorCreateEvent.onclick = function () { showcreateeventpopup(); return false; };
       }
       else {
           alert("---");
       }
   }

   function sendApproveMail()
   {
       ws.SendApprovedMail();
   }

   function sendCPMail()
   {
       var login = document.getElementById("TextBoxEMail").value;
       var reg = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
       var match = reg.exec(login);
       if (login == "" || login == undefined || !match)
       {
           document.getElementById("TextBoxEMail").style.borderColor = "#FF0000";
           document.getElementById("LabelEMail").innerHTML = "E-mail <span style=\"color:#FF0000\">(Укажите e-mail)</div>";
       }
       else
       {
           ws.SendChangePwdMail(login,
               function () { document.getElementById("divforgetpwd").innerHTML = "<span style=\"color:#00FF00\">Смотрите почту.</div>"; },
               function () { document.getElementById("LabelEMail").innerHTML = "E-mail <span style=\"color:#FF0000\">(Такой e-mail не зарегистрирован)</div>"; }
               );
           
       }
   }

   function clearLabelEMail() {
       document.getElementById("LabelEMail").innerHTML = "E-mail";
       document.getElementById("TextBoxEMail").style.borderTop = "1px solid #3d3d3d";
       document.getElementById("TextBoxEMail").style.borderLeft = "1px solid #3d3d3d";
       document.getElementById("TextBoxEMail").style.borderBottom = "1px solid #ffffff";
       document.getElementById("TextBoxEMail").style.borderRight = "1px solid #ffffff";
   }





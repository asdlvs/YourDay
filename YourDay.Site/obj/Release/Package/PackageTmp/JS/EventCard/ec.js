Array.prototype.remove = function (from, to) {
    var rest = this.slice((to || from) + 1 || this.length);
    this.length = from < 0 ? this.length + from : from;
    return this.push.apply(this, rest);
};

var subcategories = new Array();

function ch(sender) {
    if (sender.checked == true) {
        subcategories.push({ "Title": sender.title, "Id": sender.value });
        subcategories = subcategories.sort(
            function (a, b) {
                return a.Title.localeCompare(b.Title) 
                });
    }
    else {
        for (var i = 0; i < subcategories.length; i++) {
            if (subcategories[i].Id == sender.value) {
                subcategories.remove(i);
            }
        }
            
    }
}

function ccl() {
    var count = subcategories.length;
    var c1 = document.getElementById("selectedcategoriesc1");
    //var c2 = document.getElementById("selectedcategoriesc2");
    clear(c1);
    //clear(c2);
    if (count > 0) {
        c1.style.padding = "6px 0 10px 0";
        //c2.style.padding = "6px 0 10px 0";
    }
    else {
        c1.style.padding = "0 0 0 0";
        //c2.style.padding = "0 0 0 0";
    }
    for (var i = 0; i < count; i++) {


        var repeaterItem = document.getElementById("repeaterItem");
        var repeaterItemHtml = repeaterItem.innerHTML;
        repeaterItemHtml = repeaterItemHtml.replace("{0}", subcategories[i].Id);
        repeaterItemHtml = repeaterItemHtml.replace("{1}", subcategories[i].Id);
        repeaterItemHtml = repeaterItemHtml.replace("{2}", subcategories[i].Title);
        repeaterItemHtml = repeaterItemHtml.replace("{3}", subcategories[i].Id);
        repeaterItemHtml = repeaterItemHtml.replace("{4}", subcategories[i].Id);
        c1.innerHTML += repeaterItemHtml;

//        var div = document.createElement("div");
//        var cb = document.createElement("input");
//        cb.setAttribute("id", "subcategory" + subcategories[i].Id);
//        cb.setAttribute("type", "checkbox");
//        cb.setAttribute("checked", "checked");
//        cb.setAttribute("onclick", "ch(this);");
//        cb.setAttribute("value", subcategories[i].Id)
//        var txt = document.createTextNode(subcategories[i].Title);
//        div.appendChild(cb);
//        div.appendChild(txt)
//        c1.appendChild(div);

//        var divS = "<div>" + subcategories[i].Id + "</div>";
//        c2.innerHTML += divS;
//        if (i % 2 == 0) {
//            c1.appendChild(div);
//        }
//        else {
//            c2.appendChild(div);
//        }
    }

    document.getElementById("subcategoriesselect").style.display = "none";
}

function clear(control) {
    control.textContent = "";
    var count = control.children.length;
    for (var i = 0; i < count; i++) {
        control.removeChild(control.children[0]);
    }
}

function savessc() {
    var h = document.getElementById("selectedcategories");
    for (var i = 0; i < subcategories.length; i++) { 
    h.value += subcategories[i].Id + ";"
    }
}

function ssc() {
    var d = document.getElementById("subcategoriesselect");
    d.style.display = "block";
    checking(d);
}

function checking(control) {
    for (var i = 0; i < control.children.length; i++) {

        if (control.children[i].id != "") {

            for (var ii = 0; ii < subcategories.length; ii++) {
                if (control.children[i].id == "DataListSubcategories" + subcategories[ii].Id) {
                    control.children[i].checked = true;
                    break;
                }
                else {
                    control.children[i].checked = false;
                }
            }
        }
        checking(control.children[i]);
    }
}

var tgood = false;
var dgood = false;
var dategood = false;
var bgood = false;

function cect(sender, length, errorplace, error, checker) {
    if (sender.value.length < length) {
        ec_b(sender, checker, errorplace, error);
    }
    else {
        ec_g(sender, checker, errorplace);
    }
}

function cd(sender) { 
 var reg = /^\d{2}\.\d{2}\.\d{4}$/;
  var match = reg.exec(sender.value);
  if (match) {
      ec_g(sender, 'dategood');
  }
  else {
      ec_b(sender, 'dategood');
  }
}

function cbs(sender, checker, errorplace) {
    if (checker == true || sender.value.length == 0) {
        sender.style.borderTop = "1px solid #3d3d3d";
        sender.style.borderLeft = "1px solid #3d3d3d";
        sender.style.borderBottom = "1px solid #ffffff";
        sender.style.borderRight = "1px solid #ffffff";
        if (errorplace) {
            document.getElementById(errorplace).innerHTML = "";
        }
    }
}

function ec_g(sender, checker, errorplace) {
    sender.style.borderColor = "#96ab42";
    if (checker == 'tgood') {
        tgood = true;
    }
    if (checker == 'dgood') {
        dgood = true;
    }
    if (checker == 'bgood') {
        bgood = true;
    }
    if (checker == 'dategood') {
        dategood = true;
    }
    okec();
    if (errorplace) {
        document.getElementById(errorplace).innerHTML = "";
    }
}

function ec_b(sender, checker, errorplace, error) {
        sender.style.borderColor = "#FF0000";
        if (checker == 'tgood') {
            tgood = false;
        }
        if (checker == 'dgood') {
            dgood = false;
        }
        if (checker == 'bgood') {
            bgood = false;
        }
         if (checker == 'dategood') {
        dategood = false;
    }
    okec();
        if (errorplace && error) {
            document.getElementById(errorplace).style.color = "#FF0000";
            document.getElementById(errorplace).style.fontSize = "8pt";
            document.getElementById(errorplace).innerHTML = error;
        }
}

function cbud(sender) {
    var reg = /^\d{1,}$/;
    var match = reg.exec(sender.value);
    if (match && sender.value.length > 0) {
        ec_g(sender, 'bgood');
    }
    else {
        ec_b(sender, 'bgood');
    }
}


function wsc(sender) {
    var d = document.getElementById("categoriesinfo");
    if (sender.value == 1) {
        d.style.display = "none";
    }
    else {
        d.style.display = "";
    }
}

function okec() {
    var okec = document.getElementById("ImageButtonReady");
    if (
    tgood == true &&
    dgood == true &&
    bgood == true &&
    dategood == true
    ) {
        okec.style.opacity = 1;
        okec.removeAttribute("disabled");
    }
    else {
        okec.style.opacity = 0.5;
        okec.setAttribute("disabled", "disabled");
    }
}




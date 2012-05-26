function ContractorSelection() {

}
ContractorSelection.prototype.CreateEventCardCompany =
    function (cId, scId, add) {
        YourDay.Site.WS.WS.CreateEventCardCompany(cId, scId, add, function (data) {
            if (data.Code == null || data.Code == 0) {
                document.getElementById("c_s_message").innerHTML = "";
                document.getElementById("c_s_contractors").innerHTML = "";
                ContractorSelection.prototype.RenderBlock(data);
            }
            else {
                var text = data.Error;
                text += "<br /><a href=\"#\" onclick=\"AddToEC(" + cId + ", " + scId + ", true); return false;\">Добавить категорию</a>"
                document.getElementById("c_s_message").innerHTML = text;
            }

        })
    }

    ContractorSelection.prototype.RemoveEventCardCompany =
        function (cId, scId) {
            YourDay.Site.WS.WS.RemoveEventCardCompany(cId, scId, function (data) {
                document.getElementById("c_s_message").innerHTML = "";
                document.getElementById("c_s_contractors").innerHTML = "";
                ContractorSelection.prototype.RenderBlock(data);
            })
        }

   ContractorSelection.prototype.RenderBlock =
        function (data) {
            for (var i = 0; i < data.Cs.length; i++) {
                document.getElementById("c_s_contractors").innerHTML +=
                     "<div>"+
                        "<div style=\"display:table-cell;\">"+
                            "<img src=" + data.Cs[i].Image + " />"+
                            "<a  href=\"\" style=\"position:relative; bottom:10px; left:10px;\" >" + data.Cs[i].FullName + "</a>"+
                        "</div>"+
                        "<div style=\"display:table-cell;\">"+
                            "<a href=\"#\" onclick=\"RemoveFromEc(" + data.Cs[i].Id + "," + data.Cs[i].Sc + ");return false;\"><img src=\"#\" /></a>" +
                        "</div>"+
                    "</div>";

            }
        }
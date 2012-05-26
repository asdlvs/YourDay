function AddToEC(contractorId, categoryId, add) {
    var cs = new ContractorSelection();
    cs.CreateEventCardCompany(contractorId, categoryId, add);
}

function RemoveFromEc(contractorId, categoryId) {
    var cs = new ContractorSelection();
    cs.RemoveEventCardCompany(contractorId, categoryId);
}

function AddToFavourite(itemId, type) {
    var ws = YourDay.Site.WS.WS;
    ws.AddFavourites(itemId, type, function (data) { });
}

function SendMessage(contractorId, categoryId) {
    alert('SendMessage');
}

function LoadPrice(contractorId, categoryId) {
    alert('LoadPrice');
}



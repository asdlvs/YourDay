function AddToEC(contractorId, categoryId, add) {
    var cs = new ContractorSelection();
    cs.CreateEventCardCompany(contractorId, categoryId, add);
}

function RemoveFromEc(contractorId, categoryId) {
    var cs = new ContractorSelection();
    cs.RemoveEventCardCompany(contractorId, categoryId);
}

function AddToFavourite(contractorId, categoryId) {
    alert('AddToFavourite');
}

function SendMessage(contractorId, categoryId) {
    alert('SendMessage');
}

function LoadPrice(contractorId, categoryId) {
    alert('LoadPrice');
}



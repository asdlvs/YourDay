function Messenger(authorId, receiverId, type) {
    Messenger.prototype.AuthorId = authorId;
    Messenger.prototype.ReceiverId = receiverId;
    Messenger.prototype.Type = type;
}


Messenger.prototype.SendMessage = function (text) {
    alert(this.AuthorId);
}
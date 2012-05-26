<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CutImage.ascx.cs" Inherits="YourDay.Site.Controls.Common.CutImage" %>
<script type="text/javascript" src="/JS/Common/jquery.Jcrop.js"></script>
<link rel="stylesheet" type="text/css" href="/CSS/Jquery.UI/jquery.Jcrop.css" />

<asp:Panel runat="server" ID="PanelLoadFile">
    <asp:Image runat="server" ID="ImageCurrentAvatar" />
    <asp:FileUpload runat="server" ID="FileUploader" />
    <asp:LinkButton runat="server" ID="LinkButtonLoadImage" 
        OnClick="LinkButtonLoadImage_Click">
            Сохранить
    </asp:LinkButton>
    <asp:HiddenField runat="server" ID="HiddenFieldClientWidth" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="HiddenFieldClientHeight" ClientIDMode="Static" />
    <script type="text/javascript">
        document.getElementById('HiddenFieldClientWidth').value = screen.width;
        document.getElementById('HiddenFieldClientHeight').value = screen.height;
</script>
</asp:Panel>
<asp:Panel runat="server" ID="PanelCropFile">
    <script type="text/javascript">

        var x, y, x2, y2, w, h;
        jQuery(function ($) {
            var jcrop_api, boundx, boundy;
            // Create variables (in this scope) to hold the API and image size
            $('#target').Jcrop({
                onSelect: updatePreview,
                aspectRatio: 1
            }, function () {
                // Use the API to get the real image size
                var bounds = this.getBounds();
                boundx = bounds[0];
                boundy = bounds[1];
                // Store the API in the jcrop_api variable
                jcrop_api = this;
            });

            function updatePreview(c) {
                document.getElementById('HiddenFieldCoords').value = c.x + ',' +
                    c.y + ',' +
                    c.x2 + ',' +
                    c.y2;
               
            };

        });

      </script>
    <asp:Image runat="server" ClientIDMode="Static" ID="target" />
    <asp:LinkButton runat="server" ID="LinkButtonCropImage" 
        OnClick="LinkButtonCropImage_Click">Crop</asp:LinkButton>
    <asp:HiddenField runat="server" ID="HiddenFieldCoords" ClientIDMode="Static" />
</asp:Panel>

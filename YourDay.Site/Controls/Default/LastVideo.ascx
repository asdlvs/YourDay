<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LastVideo.ascx.cs" Inherits="YourDay.Site.Controls.Default.LastVideo" %>

<script src="/JS/Video/flowplayer-3.2.6.min.js" type="text/javascript"></script>
<div class="video">
<a 
	href="http://localhost:32976/Video/1.flv" 
	style="display:block;width:456px;height:333px;" 
	id="player">
</a>
<script language="JavaScript" type="text/javascript">
    flowplayer("player", "/JS/Video/flowplayer-3.2.7.swf",{
    clip: {
        autoPlay: false
    }
});
</script>

    

</div>
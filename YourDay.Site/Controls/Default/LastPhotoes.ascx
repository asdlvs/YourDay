<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LastPhotoes.ascx.cs" Inherits="YourDay.Site.Controls.Default.LastPhotoes" %>

<link href="/CSS/Slider.css" rel="stylesheet" type="text/css" />
<script src="/JS/Slider/jquery-easing-1.3.pack.js" type="text/javascript"></script>
<script src="/JS/Slider/jquery-easing-compatibility.1.2.pack.js" type="text/javascript"></script>
<script src="/JS/Slider/coda-slider.1.1.1.pack.js" type="text/javascript"></script>


<script type="text/javascript">

	    var theInt = null;
	    var $crosslink, $navthumb;
	    var curclicked = 0;

	    theInterval = function (cur) {
	        clearInterval(theInt);

	        if (typeof cur != 'undefined')
	            curclicked = cur;

	        $crosslink.removeClass("active-thumb");
	        $navthumb.eq(curclicked).parent().addClass("active-thumb");
	        $(".stripNav ul li a").eq(curclicked).trigger('click');

	        theInt = setInterval(function () {
	            $crosslink.removeClass("active-thumb");
	            $navthumb.eq(curclicked).parent().addClass("active-thumb");
	            $(".stripNav ul li a").eq(curclicked).trigger('click');
	            curclicked++;
	            if (6 == curclicked)
	                curclicked = 0;

	        }, 3000);
	    };

	    $(function () {

	        $("#main-photo-slider").codaSlider();

	        $navthumb = $(".nav-thumb");
	        $crosslink = $(".cross-link");

	        $navthumb
			.click(function () {
			    var $this = $(this);
			    theInterval($this.parent().attr('href').slice(1) - 1);
			    return false;
			});

	        theInterval();
	    });
	</script>

<%--
<div class="photo">
    <img src="/Images/test.png" />
</div>
<div class="description">
asd
</div>
--%>


<div class="bigphoto">
<div class="slider-wrap">
    <div id="main-photo-slider" class="csw">
		<div class="panelContainer">
        <asp:Repeater ID="RepeaterPhotoesPromo" runat="server">
            <ItemTemplate>
                <div class="panel" title="<%# Eval("Title") %>">
					<div class="wrapper">
						<img src="<%# Eval("Path") %>" alt="<%# Eval("Alt") %>" />
						<div class="photo-meta-data">
							<%# Eval("Description") %>
						</div>
					</div>
				</div>
            </ItemTemplate>
        </asp:Repeater>
        </div>
    </div>
    <br />
<%--    <a href="#1" class="cross-link active-thumb"><img src="images/tempphoto-1thumb.jpg" class="nav-thumb" alt="temp-thumb" /></a>--%>
		<div id="movers-row">
        <asp:Repeater ID="RepeaterPhotoesThumbs" runat="server">
        <ItemTemplate>
            <a href="<%# Eval("No") %>" class="cross-link"><img src="<%# Eval("Path") %>" class="nav-thumb" alt="temp-thumb" /></a>
        </ItemTemplate>
        </asp:Repeater>
        </div>
</div>
</div>

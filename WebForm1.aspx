<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="UnitedWay2017.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="https://www.kdmc.com/teamshirts/bootstrap/js/pace.js"></script>    
	<link rel="stylesheet" href="https://www.kdmc.com/teamshirts/bootstrap/css/preload-angle-theme.css" />
	<link href='https://fonts.googleapis.com/css?family=Bungee+Shade' rel='stylesheet' type='text/css'>
	<link rel="stylesheet" href="https://www.kdmc.com/teamshirts/bootstrap/css/reset.css"> <!-- CSS reset -->
	<link rel="stylesheet" href="https://www.kdmc.com/teamshirts/bootstrap/css/style.css"> <!-- Gem style -->
	<script src="https://www.kdmc.com/teamshirts/bootstrap/js/modernizr.js"></script> <!-- Modernizr -->
    <link rel="stylesheet" href="https://www.kdmc.com/teamshirts/bootstrap/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>	
	<title>Team Shirt Size Registration</title>	
	
<style>
#tabs
{
	display:none\9;
}
.ie10 #tabs
{
	display:block;
}
@media screen and (-ms-high-contrast: active), (-ms-high-contrast: none) {
	#tabs { display:block !important; }
}
</style>
</head>
<body>
    <form id="Form1" runat="server" novalidate>
	<header role="banner" style="text-align:center;">
		<div id="cd-logo" style="z-index:99;"></div>	
        <h1 class="title" style="margin:0em;">Team Shirt Size Registration</h1>  
		<div id="logout" class="dropdown" style="float:right; margin-right:5em; margin-top:1em;">
			<button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
				Hi, <%=strPrefName%>
				<span class="caret"></span>
			</button>
			<ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
			</ul>
		</div>    
	</header>		
	<!--[if lte IE 9]>
	<div class="lblwar">	
		<p class="myalert alert-info">It seems you are using an outdated browser that is no longer supported. Please upgrade your version of Internet Explorer or access this site from chrome, firefox or a smart mobile device.</p>
	</div>
	<![endif]-->
<div id="tabs" class="tabs" style="margin-top:50px;">
	<nav class="nav-tabs-responsive" > 
		<ul class="nav nav-tabs" role="tablist">
			<li><a href="#section-1" class="icon-cup"><span>What is Your Tee Shirt Size?</span></a></li>
		</ul>
	</nav>
    <div class="lblwar">			
        <asp:Label ID="lblDonated" Visible="false" runat="server" />
        <asp:Label ID="lblError" Visible="false" runat="server" />
    </div>
	<div class="content">
		<section id="section-1">        
			<div class="mediabox">
			&nbsp;
			</div>
			<div class="mediabox">
				<p>Please tell us what size you wear in a T-Shirt</p>

                    <p class="fieldset" >
                        <b>Choose size:</b>
						<asp:DropDownList ID="ddlShSize" CssClass="form-control" runat="server">                            
							<asp:ListItem Text="" Value="" />
							<asp:ListItem Text="Small" Value="Small" />
							<asp:ListItem Text="Medium" Value="Medium" />
							<asp:ListItem Text="Large" Value="Large" />
							<asp:ListItem Text="XL" Value="XL" />
							<asp:ListItem Text="2XL" Value="2XL" />
							<asp:ListItem Text="3XL" Value="3XL" />                        
							<asp:ListItem Text="4XL" Value="4XL" />                       
							<asp:ListItem Text="5XL" Value="5XL" />
						</asp:DropDownList>
					</p>
                <asp:Button ID="btnFleece" runat="server" type="button" CssClass="btn btn-primary" Text="ALL DONE!" OnClick="btnFleece_Click" />
			</div>
		</section>
	</div><!-- /content -->
</div><!-- /tabs -->

<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>    
<script src="https://www.kdmc.com/teamshirts/bootstrap/js/main.js"></script> <!-- Gem jQuery -->
<script type="text/javascript">

    ; (function (window) {

        'use strict';

        function extend(a, b) {
            for (var key in b) {
                if (b.hasOwnProperty(key)) {
                    a[key] = b[key];
                }
            }
            return a;
        }

        function CBPFWTabs(el, options) {
            this.el = el;
            this.options = extend({}, this.options);
            extend(this.options, options);
            this._init();
        }

        CBPFWTabs.prototype.options = {
            start: 0
        };

        CBPFWTabs.prototype._init = function () {
            // tabs elemes
            this.tabs = [].slice.call(this.el.querySelectorAll('nav > ul > li'));
            // content items
            this.items = [].slice.call(this.el.querySelectorAll('.content > section'));
            // current index
            this.current = -1;
            // show current content item
            this._show(<%=init%>);

            // init events
            this._initEvents();
        };



        CBPFWTabs.prototype._initEvents = function () {
            var self = this;
            this.tabs.forEach(function (tab, idx) {
                tab.addEventListener('click', function (ev) {
                    ev.preventDefault();
                    self._show(idx);
                });
            });
        };

        CBPFWTabs.prototype._show = function (idx) {
            if (this.current >= 0) {
                this.tabs[this.current].className = '';
                this.items[this.current].className = '';
            }
            // change current
            this.current = idx != undefined ? idx : this.options.start >= 0 && this.options.start < this.items.length ? this.options.start : 0;
            this.tabs[this.current].className = 'tab-current';
            this.items[this.current].className = 'content-current';
        };

        // add to global namespace
        window.CBPFWTabs = CBPFWTabs;

    })(window);
</script>
<script>
    $(document).ready(function () {
        $(".alert").fadeIn().delay(5000).fadeOut(2000);
        $('#custom').hide();
    });
    new CBPFWTabs(document.getElementById('tabs'));
</script>
    </form>
</body>
</html>

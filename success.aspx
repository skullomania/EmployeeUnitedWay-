<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="success.aspx.cs" Inherits="UnitedWay2017.success" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Cache-Control" content="no-cache" />
<meta http-equiv="Pragma" content="no-cache" />
<meta http-equiv="Expires" content="0" />
    <meta charset="UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="bootstrap/js/pace.js"></script>    
	<link rel="stylesheet" href="bootstrap/css/preload-angle-theme.css" />
	<link href='http://fonts.googleapis.com/css?family=Bangers' rel='stylesheet' type='text/css' />
	<link rel="stylesheet" href="bootstrap/css/reset.css" /> <!-- CSS reset -->
	<link rel="stylesheet" href="bootstrap/css/style.css" /> <!-- Gem style -->
	<script src="bootstrap/js/modernizr.js"></script> <!-- Modernizr -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>	     
  <link rel="stylesheet" href="http://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">   
	<title>The Power of U!</title>

    <script type="text/javascript">
        // It works without the History API, but will clutter up the history
        var history_api = typeof history.pushState !== 'undefined'

        // The previous page asks that it not be returned to
        if (location.hash == '#no-back') {
            // Push "#no-back" onto the history, making it the most recent "page"
            if (history_api) history.pushState(null, '', '#stay')
            else location.hash = '#stay'

            // When the back button is pressed, it will harmlessly change the url
            // hash from "#stay" to "#no-back", which triggers this function
            window.onhashchange = function () {
                // User tried to go back; warn user, rinse and repeat
                if (location.hash == '#no-back') {
                    alert("Your information has been submitted. Please close this page!")
                    if (history_api) history.pushState(null, '', '#stay')
                    else location.hash = '#stay'
                }
            }
        }
</script>

</head>
<body>
    <form id="form1" runat="server" novalidate>
        <header role="banner" style="text-align:center;">
		    <div id="cd-logo"><a href="#0"><img src="bootstrap/img/unitedlogo.png" alt="Logo"></a></div>		
            <h1 class="title" style="margin:0em;">King's Daughters United Way Campaign 2017</h1>                    
	    </header>
    <div id="tabs" class="tabs" style="margin-top:50px;">
        <nav class="nav-tabs-responsive" > 
		    <ul class="nav nav-tabs" role="tablist">
			    <li><a href="#section-1" class="icon-cup"><span>Thanks For Your Donation!</span></a></li>
		    </ul>
	    </nav>
    
        <div class="lblwar">
            <asp:Label ID="lblError" runat="server" />
        </div>
        
        <div class="content">
		    <section id="section-1">
			    
		    </section>		
	    </div><!-- /content -->
    </div><!-- /tabs -->
    
        <script src="bootstrap/js/main.js"></script> <!-- Gem jQuery -->
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
                    this._show();

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
            new CBPFWTabs(document.getElementById('tabs'));
        </script>
            
    </form>
</body>
</html>

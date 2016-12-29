<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="donateca.aspx.cs" Inherits="UnitedWay2017.donateca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

    $(function () {
        var availableTags = [ <%= SuggestionList %>];
        $("#<%= txtAgencies.ClientID %>").autocomplete({
            source: availableTags,
            minLength: 3
        });

    });
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
			    <li><a href="#section-1" class="icon-cup"><span>Where would you like to donate?</span></a></li>
		    </ul>
	    </nav>
    
        <div class="lblwar">
            <asp:Label ID="lblError" Visible="false" runat="server" />
        </div>
        
        <div class="content">
		    <section id="section-1">
			    <div class="mediabox">
				    <img src="bootstrap/img/uwlogo.jpg" alt="img01" />
			    </div>
			    <div class="mediabox">
                    <p class="fieldset">Is this your first time donating to United Way?
                        <asp:RadioButtonList ID="radFirstTime" runat="server">
                            <asp:ListItem Text="Yes" Value="Yes" />
                            <asp:ListItem Text="No" Value="No" />
                        </asp:RadioButtonList>	
                    </p>
                    <p class="fieldset">Choose an option to select donation method and enter password!
                        <asp:RadioButtonList ID="radCountyOrAgency" runat="server" AutoPostBack="True">
                            <asp:ListItem Text="Wherever Needed Most" Value="Most Needed" />
                            <asp:ListItem Text="Choose from a list of Counties" Value="County" />
                            <asp:ListItem Text="Help me find my Agency" Value="Agency" />
                        </asp:RadioButtonList>	
                    </p>
                    <asp:Panel ID="pnlNeededMost" Visible="false" runat="server">
                    </asp:Panel>                    
                    <asp:Panel ID="pnlCounty" Visible="false" runat="server">
                        <p class="fieldset">
                            <strong>Choose County:</strong>
                        </p> 
                        <p class="fieldset">
                            <asp:DropDownList ID="ddlCounties" CssClass="form-control" runat="server">
                                <asp:ListItem Text="" Value="" />
                                <asp:ListItem Text="Boyd" Value="Boyd" />
                                <asp:ListItem Text="Greenup" Value="Greenup" />
                                <asp:ListItem Text="Carter" Value="Carter" />
                                <asp:ListItem Text="Elliott" Value="Elliott" />
                                <asp:ListItem Text="Lawrence (KY)" Value="Lawrence (KY)" />
                                <asp:ListItem Text="Cabell-Wayne" Value="Cabell-Wayne" />
                                <asp:ListItem Text="Lawrence (OH)" Value="Lawrence (OH)" />
                                <asp:ListItem Text="Floyd" Value="Floyd" />
                                <asp:ListItem Text="Johnson" Value="Johnson" />
                                <asp:ListItem Text="Magoffin" Value="Magoffin" />
                                <asp:ListItem Text="Martin" Value="Martin" />
                                <asp:ListItem Text="Pike" Value="Pike" />
                                <asp:ListItem Text="Adams" Value="Adams" />
                                <asp:ListItem Text="Scioto" Value="Scioto" />
                                <asp:ListItem Text="Gallia" Value="Gallia" />
                            </asp:DropDownList>
                        </p>
                    </asp:Panel>
                    <asp:Panel ID="pnlAgency" Visible="false" runat="server">
                        <p class="fieldset">
                            <strong>Choose Agency:</strong>
                        </p> 
                        <p class="fieldset">
                            <asp:TextBox ID="txtAgencies" CssClass="form-control" runat="server" placeholder="Type 3 letters to begin!" />
                        </p>
                    </asp:Panel>                                        
                    <asp:Panel ID="pnlPassword" Visible="false" runat="server">                        
                        <p class="fieldset">
                            <strong>Please re-enter your password for verification</strong>
                        </p>         
                        <div class="cd-form">
                            <p class="fieldset">
				                <label class="image-replace cd-password" for="signin-password">Password</label>                      
                                <asp:TextBox ID="txtPassword" CssClass="full-width has-padding has-border" runat="server" type="password"  placeholder="Password" required/>
				                <a href="#0" class="hide-password">Show</a>
			                </p>
                        </div>
                        <asp:Button ID="btnNeededMost" CssClass="btn btn-primary" Visible="false" runat="server" Text="I'M ALL DONE !" OnClick="btnNeededMost_Click" />
                        <asp:Button ID="btnCounty" CssClass="btn btn-primary" Visible="false" runat="server" Text="I'M ALL DONE !" OnClick="btnCounty_Click" />
                        <asp:Button ID="btnAgency" CssClass="btn btn-primary" Visible="false" runat="server" Text="I'M ALL DONE !" OnClick="btnAgency_Click" />
                    </asp:Panel>
			    </div>
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
            $(document).ready(function () {
                $(".alert").fadeIn().delay(5000).fadeOut(2000);
            });
            new CBPFWTabs(document.getElementById('tabs'));
        </script>
            
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="UnitedWay2017._default" %>

<!doctype html>
<html lang="en" class="no-js">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="bootstrap/js/pace.js"></script>    
	<link rel="stylesheet" href="bootstrap/css/preload-angle-theme.css" />
	<link href='http://fonts.googleapis.com/css?family=Bangers' rel='stylesheet' type='text/css'>
	<link rel="stylesheet" href="bootstrap/css/reset.css"> <!-- CSS reset -->
	<link rel="stylesheet" href="bootstrap/css/style.css"> <!-- Gem style -->
	<script src="bootstrap/js/modernizr.js"></script> <!-- Modernizr -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>	
	<title>The Power of U!</title>
<style>
    #piec
    {
        position: fixed !important;
        bottom: 0px;
        margin: 0 auto;
        width: 310px;
        padding-top: 15px;        
        z-index: 1000;
    }
    
</style>

</head>
<body>
<form id="Form1" runat="server" novalidate>
	<header role="banner" style="text-align:center;">
		<div id="cd-logo"><a href="#0"><img src="bootstrap/img/unitedlogo.png" alt="Logo"></a></div>		
        <h1 class="title" style="margin:0em;">King's Daughters United Way Campaign 2017</h1>
	</header>		
	<!--[if lte IE 9]>
	<div class="lblwar">	
		<p class="myalert alert-info">It seems you are using an outdated browser that is no longer supported. Please upgrade your version of Internet Explorer or access this site from chrome, firefox or a smart mobile device.</p>
	</div>
	<![endif]-->
<div id="tabs" class="tabs" style="margin-top:50px;">
	<nav class="nav-tabs-responsive" > 
		<ul class="nav nav-tabs" role="tablist">
			<li><a href="#section-1" class="icon-cup"><span>$260 Contribution</span></a></li>
			<li><a href="#section-2" class="icon-food"><span>$130 Contribution</span></a></li>
			<li><a href="#section-3" class="icon-lab"><span>$25 Shirt Only</span></a></li>			
			<li><a href="#section-4" class="icon-lab"><span>Custom Contribution</span></a></li> 
		</ul>
	</nav>
    <div class="lblwar">			
        <asp:Label ID="lblDonated" Visible="false" runat="server" />
        <asp:Label ID="lblError" Visible="false" runat="server" />
    </div>    

	<div class="content">
		<section id="section-1">        
			<div class="mediabox">
				<img src="bootstrap/img/fleece.jpg" alt="img01" />
			</div>
			<div class="mediabox">
				<p>Pledge at least <strong>$10 a pay for 26 pay periods
				 </strong> and you’ll score a warm fleece jacket to keep you cozy for those times you’re not in superhero mode 
				 (it’s embroidered with the King’s Daughters logo, helping to maintain your secret identity).</p>
                <p class="fieldset">
                        <b>Choose type:</b>
						<asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server">
                            <asp:ListItem Text="" Value="" />
                            <asp:ListItem Text="Mens" Value="Mens" />
                            <asp:ListItem Text="Womens" Value="Womens" />
						</asp:DropDownList>
					</p>

                    <p class="fieldset" >
                        <b>Choose size:</b>
						<asp:DropDownList ID="ddlFSize" CssClass="form-control" runat="server">                            
                            <asp:ListItem Text="" Value="" />
                            <asp:ListItem Text="Small" Value="Small" />
                            <asp:ListItem Text="Medium" Value="Medium" />
                            <asp:ListItem Text="Large" Value="Large" />
                            <asp:ListItem Text="XL" Value="XL" />
                            <asp:ListItem Text="2XL" Value="2XL" />
                            <asp:ListItem Text="3XL" Value="3XL" />
						</asp:DropDownList>
					</p>
                <asp:Button ID="btnFleece" runat="server" type="button" CssClass="btn btn-primary" Text="CONTINUE WITH YOUR DONATION !" OnClick="btnFleece_Click" />
			</div>
		</section>
		<section id="section-2">
			<div class="mediabox">
				<img src="bootstrap/img/Long%20Sleeve.jpg" alt="img01" />
			</div>
			<div class="mediabox">
				<p>Pledge a minimum of <strong>$5 a pay for 26 pay periods</strong> and receive a specially designed long-sleeve T-shirt that proclaims your superhero status to the world!</p>
                <p class="fieldset">
                    <b>Choose size:</b>
					<asp:DropDownList ID="ddlLsSize" CssClass="form-control" runat="server">                            
                        <asp:ListItem Text="" Value="" />
                        <asp:ListItem Text="Small" Value="Small" />
                        <asp:ListItem Text="Medium" Value="Medium" />
                        <asp:ListItem Text="Large" Value="Large" />
                        <asp:ListItem Text="XL" Value="XL" />
                        <asp:ListItem Text="2XL" Value="2XL" />
                        <asp:ListItem Text="3XL" Value="3XL" />                        
                        <asp:ListItem Text="4XL" Value="4XL" />
					</asp:DropDownList>
                </p>
                <asp:Button ID="btnLongSleeve" runat="server" type="button" CssClass="btn btn-primary" Text="CONTINUE WITH YOUR DONATION !" OnClick="btnLongSleeve_Click" />
			</div>
		</section>
		<section id="section-3">
			<div class="mediabox">
				<img src="bootstrap/img/Short%20Sleeve.jpg" alt="img01" />
			</div>
			<div class="mediabox">
				<p>A <strong>one-time contribution of $25</strong> earns you a short-sleeve T-shirt, allowing you to show off those superhero biceps!</p>
                <p class="fieldset">
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
                <asp:Button ID="btnShortSleeve" runat="server" type="button" CssClass="btn btn-primary" Text="CONTINUE WITH YOUR DONATION !" OnClick="btnShortSleeve_Click" />
			</div>
		</section>
		<section id="section-4">            			
			<div class="mediabox">
				<img id="myImage" src="bootstrap/img/uwlogo.jpg" alt="img01" />
			</div>
            <div class="mediabox">
                <p class="fieldset">Choose Payment Type:
                    <asp:RadioButtonList ID="radPaymentType" runat="server" AutoPostBack="True">
                        <asp:ListItem Text="Payroll Deduction" Value="Payroll Deduction" />
                        <asp:ListItem Text="Check" Value="Check" />
                        <asp:ListItem Text="Cash" Value="Cash" />
                    </asp:RadioButtonList>
                </p>
            <asp:Panel ID="pnlPayroll" Visible="false" runat="server">	
                <p class="fieldset">
                    <b>How much would you like to give per pay?</b>
                    <asp:TextBox ID="txtPerPay" onchange="fill()" CssClass="form-control" runat="server" required MaxLength="6" />
                </p>
                <p class="fieldset">
                    <b>How many pay periods will you like to donate the above amount?</b>
                    <asp:TextBox ID="txtPayPeriods" CssClass="form-control" onchange="fill()" runat="server" required MaxLength="2" />
                </p>
                <p class="fieldset">                    
                    <span>
                    <b style="float:left;">Total: $</b>
                    <asp:TextBox runat="server" ID="txtAnnualPayroll" size="5" style="border:none; font-weight:700; float:left; font-size:large;"/><img src="bootstrap/img/mytb.png" style="float:left; width:87px; height:23px; margin-left:-87px;"  />
                    </span><br />
                </p>
                <p class="fieldset">
                    <span style="clear:both;">
                    <bdo style="color:red;">Note: </bdo>Deductions begin in January 2017.
                    </span>
				</p>
                <div id="custom">
                    <p style="font-weight:bold; color:green;">Congrats, your contribution qualifies you for that sweet reward on the left!</p>
                    <p class="fieldset">
                        <b id="CG">Choose type:</b>
						<asp:DropDownList ID="ddlCGender" CssClass="form-control" runat="server">
                            <asp:ListItem Text="" Value="" />
                            <asp:ListItem Text="Mens" Value="Mens" />
                            <asp:ListItem Text="Womens" Value="Womens" />
						</asp:DropDownList>
					</p>

                    <p class="fieldset" >
                        <b>Choose size:</b>
						<asp:DropDownList ID="ddlCSize" CssClass="form-control" runat="server">                            
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
                </div>
                <asp:Button ID="btnCustom" runat="server" type="button" CssClass="btn btn-primary" Text="CONTINUE WITH YOUR DONATION !" OnClick="btnCustom_Click" />
			</asp:Panel>            
            <asp:Panel ID="pnlCheck" Visible="false" runat="server">
                    <p><strong>If you would like to donate by check follow the steps below and click the button to let us know that you are sending your contribution:</strong></p>
                
                    <p><b>King's Daughters Ashland </b>- Mail check to:</p>
                    <ul class="kdmctext" style="margin-top:-10px;">
                        <li style="list-style-type:none;">Tammi Holbrook</li>
                        <li style="list-style-type:none;">Marketing/PR Department</li>
                        <li style="list-style-type:none;">King's Daughters Medical Center</li>
                        <li style="list-style-type:none;">2201 Lexington Ave.</li>
                        <li style="list-style-type:none;">Ashland, KY 41101</li>
                    </ul>
			        <p class="fieldset">&nbsp;</p>
			        <p><b>King's Daughters Ohio </b>- Mail check to:</p>
                    <ul class="kdmctext" style="margin-top:-10px;">
                        <li style="list-style-type:none;">Carrie Bennett</li>
                        <li style="list-style-type:none;">King's Daughters Medical Center Ohio</li>
                        <li style="list-style-type:none;">2001 Scioto Trail</li>
                        <li style="list-style-type:none;">Portsmouth, OH 45662</li>
                    </ul>
                    <p class="fieldset">&nbsp;</p>                
                    <asp:Button ID="btnCheck" runat="server" type="button" CssClass="btn btn-primary" Text="CONTINUE WITH YOUR DONATION !" OnClick="btnCheck_Click"/>
            </asp:Panel>
            <asp:Panel ID="pnlCash" Visible="false" runat="server">
                    <p><strong>For cash donations:</strong></p>
                    <p>Cash should be delivered in person (i.e. not mailed) to the marketing department located on the second 
                        floor of HR. KDMC Ohio Employees should take their cash to the the KDMC Ohio Training Center.</p>                
                    <asp:Button ID="btnCash" runat="server" type="button" CssClass="btn btn-primary" Text="CONTINUE WITH YOUR DONATION !" OnClick="btnCash_Click" />
            </asp:Panel>
            </div>
		</section>
	</div><!-- /content -->
</div><!-- /tabs -->
<div id="piec" style="right:0px;">
    <img src="bootstrap/img/btpie.png" />
</div>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>    
<script src="https://www.kdmc.com/KDUC2017/bootstrap/js/main.js"></script> <!-- Gem jQuery -->
    
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
<script type="text/javascript">

    function fill() {
        var txt8 = document.getElementById("txtPayPeriods").value;
        var txt9 = document.getElementById("txtPerPay").value;
        var total = txt8 * txt9;
        document.getElementById("txtAnnualPayroll").value = (total).toFixed(2);

        if (total <= 24) {
            $('#myImage').attr('src', 'bootstrap/img/uwlogo.jpg');
            $('#custom').hide();
        }
        if ((total > 24) && (total <= 129)) {
            $('#myImage').attr('src', 'bootstrap/img/Short Sleeve.jpg');
            $('#custom').show();
            $("#ddlCSize option[value='4XL']").hide();
            $("#ddlCSize option[value='5XL']").hide();
            $('#ddlCSize').append($("<option></option>").attr("value", "4XL").text("4XL"));
            $('#ddlCSize').append($("<option></option>").attr("value", "5XL").text("5XL"));
            $('#ddlCGender').hide();
            $('#CG').hide();
        }
        if ((total >= 130) && (total <= 259)) {
            $('#myImage').attr('src', 'bootstrap/img/Long Sleeve.jpg');
            $("#ddlCSize option[value='4XL']").hide();
            $("#ddlCSize option[value='5XL']").hide();
            $('#ddlCSize').append($("<option></option>").attr("value", "4XL").text("4XL"));
            $('#custom').show();
            $('#ddlCGender').hide();
            $('#CG').hide();
        }
        if (total >= 260) {
            $('#myImage').attr('src', 'bootstrap/img/Fleece.jpg');
            $("#ddlCSize option[value='4XL']").hide();
            $("#ddlCSize option[value='5XL']").hide();
            $('#custom').show();
            $('#ddlCGender').show();
            $('#CG').show();
        }

    }

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

        setInterval(function () {
            $("#piec").effect("shake");
        }, 5000);
    });
    new CBPFWTabs(document.getElementById('tabs'));

    $('#txtPerPay').bind('keyup paste', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });
    $('#txtPayPeriods').bind('keyup paste', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });
</script>    
</form>
</body>
</html>

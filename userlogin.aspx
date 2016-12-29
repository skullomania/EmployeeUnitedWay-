<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="UnitedWay2017.userlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta charset="UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<link href='http://fonts.googleapis.com/css?family=Bangers' rel='stylesheet' type='text/css' />
	<link rel="stylesheet" href="bootstrap/css/reset.css" /> <!-- CSS reset -->
	<link rel="stylesheet" href="bootstrap/css/style.css" /> <!-- Gem style -->
	<script src="bootstrap/js/modernizr.js"></script> <!-- Modernizr -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>	
	<title></title>  
    <style>
        body { 
			background: url('https://www.kdmc.com/KDUC2017/bootstrap/img/herobg.jpg') no-repeat center center fixed; 
			-webkit-background-size: cover;
			-moz-background-size: cover;
			-o-background-size: cover;
			background-size: cover;
		}
    </style>      
</head>
<body>
    <form id="form1" class="myBG" runat="server">
        <header role="banner" style="text-align:center;">
		    <div id="cd-logo"><a href="#0"><img src="bootstrap/img/unitedlogo.png" alt="Logo" /></a></div>		
            <h1 class="title" style="margin:0em;">King's Daughters United Way Campaign 2017</h1> 		 
		<div class="dropdown" style="float:right; margin-right:5em; margin-top:1em;">
          <button class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
            User Options
            <span class="caret"></span>
          </button>
          <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
            <li><a href="#">Logout</a></li>
          </ul>
        </div>                  
	    </header>

        <div class="lblwar">
            <asp:Label ID="lblNotInDB" Visible="false" runat="server" />
        </div>
        <div class="myContainer">            
            <div class="cd-form">
                <p class="fieldset">
				    <label class="image-replace cd-username" for="signin-username">Employee ID</label>
                    <asp:TextBox ID="txtUserID" CssClass="full-width has-padding has-border" runat="server" placeholder="Username" required/>
			    </p>
                    <asp:RequiredFieldValidator ID="reqUserID" runat="server" ControlToValidate="txtUserID" EnableClientScript="true"
                            ErrorMessage="- Employee ID is required<br />" SetFocusOnError="true" Display="Dynamic" CssClass="errorz" />

			    <p class="fieldset">
				    <label class="image-replace cd-password" for="signin-password">Password</label>                      
                    <asp:TextBox ID="txtPassword" CssClass="full-width has-padding has-border" runat="server" type="password"  placeholder="Password" required/>
				    <a href="#0" class="hide-password">Show</a>
			    </p>
                    <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="txtPassword" EnableClientScript="true" 
                Display="dynamic" SetFocusOnError="true" ErrorMessage="- Password is required<br />" CssClass="errorz" />
                <p class="fieldset">
                    <asp:Label ID="lblADError" runat="server" CssClass="errorz" Visible="False" />
                    <asp:Label ID="lblOrderAttemptTime" Visible="false" runat="server" />
					<asp:Button ID="btnLogin" runat="server" CssClass="full-width" Text="Login" OnClick="btnLogin_Click" />
				</p>                                 
            </div>
        </div>
        <div class="oval-thought">
            <p>If you always wanted to be a superhero, today is your day! Exercise the Power of You by making your pledge to the United Way. It’s easier, and more fun, than ever! Superheros need a little swag. After all, what is Superman without his cape? Wonder Woman without her lasso? </p> 
        </div>
    </form>    
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>    
<script src="bootstrap/js/main.js"></script> <!-- Gem jQuery -->
    <script>
        $(document).ready(function () {
            $(".alert").fadeIn().delay(5000).fadeOut(2000);
        });
    </script>
</body>
</html>

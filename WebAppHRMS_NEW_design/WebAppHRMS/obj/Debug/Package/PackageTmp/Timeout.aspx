<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Timeout.aspx.vb" Inherits="WebAppHRMS.Timeout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>

    <meta charset="utf-8">

    <link href='http://fonts.googleapis.com/css?family=Creepster|Audiowide' rel='stylesheet' type='text/css'>

    <style>
    	* {
    		margin: 0;
    		padding: 0;
    	}

    	body {
    		font-family: 'Audiowide', cursive, arial, helvetica, sans-serif;
    		background: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAYAAACNMs+9AAAAUElEQVQYV2NkYGAwBuKzQAwDID4IoIgxIikAMZE1oRiArBDdZBSNMIXoJiFbDZYDKcSmCOYimDuNSVKIzRNYrUYOFuQgweoZbIoxgoeoAAcAEckW11HVTfcAAAAASUVORK5CYII=) repeat;
    		background-color: antiquewhite;
    		color: white;
    		font-size: 18px;
    		padding-bottom: 20px;
    	}

    	.error-code {
    		font-family: 'Creepster', cursive, arial, helvetica, sans-serif;
    		font-size: 200px;
    		color: white;
    		color: rgba(255, 255, 255, 0.98);
    		width: 50%;
    		text-align: right;
    		margin-top: 5%;
    		text-shadow: 5px 5px hsl(0, 0%, 25%);
    		float: left;
    	}

    	.not-found {
    		width: 47%;
    		float: right;
    		margin-top: 5%;
    		font-size: 50px;
    		color: white;
    		text-shadow: 2px 2px 5px hsl(0, 0%, 61%);
    		padding-top: 70px;
    	}

    	.clear {
    		float: none;
    		clear: both;
    	}

    	.content {
    		text-align: center;
    		line-height: 30px;
    	}

    	input[type=text] {
    		border: hsl(247, 89%, 72%) solid 1px;
    		outline: none;
    		padding: 5px 3px;
    		font-size: 16px;
    		border-radius: 8px;
    	}

    	a {
    		text-decoration: none;
    		color: #9ECDFF;
    		text-shadow: 0px 0px 2px white;
    	}

    		a:hover {
    			color: white;
    		}






    	/* Center and scale the image nicely */
    	background-position: center;
    	background-repeat: no-repeat;
    	background-size: cover;
    	}
    </style>

    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
               setTimeout("preventBack()", 0);
               window.onunload = function () { null };
    </script>

</head>

<body style="background-repeat: no-repeat; background-size: 100%">

    <form id="form1" runat="server">

        <div align="center" style="font-family: Arial; color: darkred; padding-top: 300px;">
            <br />
            YOU HAVE SUCCESSFULLY LOGGED OUT     
                <br />
        </div>

        <div align="center">
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server"
                OnClick="LinkButton1_Click" ForeColor="darkred">LOGIN</asp:LinkButton><br />

        </div>

    </form>

</body>

</html>

<%@ Page MasterPageFile="dp.master" Language="VB" AutoEventWireup="false" CodeBehind="repo.aspx.vb" Inherits="WebAppHRMS.leave_leave_apply_report_16d3b1138297" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">
<html>
<head><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />
<link rel="stylesheet" type="text/css" href="style.css"/>
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript" for="window" event="onload">
        /*return window_onload()*/
        window.onload = callback;
        function callback() {
            return window_onload();
        }

    </script>
  <script type="text/javascript">

function window_onload()
{debugger;
document.getElementById("jio").innerHTML = "<img src='esp.gif' alt='gif image' />";
     ToServer(1,1);
     return false;
}

function FromServer(arg,context)
{   debugger;
//var args=arg.split('@');
   document.getElementById("jio").innerHTML = arg; 
}

function passpage(code,pin)
{   debugger;
window.open("masterpiece.aspx?code="+code+"&pin="+pin,"_self");
}

function passpage1(code)
{   debugger;
window.open("allow_split.aspx?code="+code,"_self");
}

function passpage2(code)
{   debugger;
window.open("tlmgr.aspx?code="+code,"_self");
}
</script>
</head>
<body>
<asp:Button ID="mybut1" style="background-color:#500; height:auto ;width:auto; color:White ;" Text="Export To Excel" runat="server" /><br/><br/><br/><br/><br/>
    <div id="jio" style ="text-align:center;" class="avoid">

    </div>
</body>
</html>
</asp:Content>
<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="date_wise_report.aspx.vb" Inherits="WebAppHRMS.Emp_Master_Data_date_wise_report_2bcaa7b19674" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
        <meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />
        <link rel="stylesheet" type="text/css" href="style.css" />
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>

        <script type="text/javascript">
    window.onload = function() {
        window_onload();
        };
    function btn_exit_onclick() {
        window.open('emp_report.aspx', '_self');
        }

    function window_onload() {
        debugger;
        document.getElementById("jio").innerHTML = "<img src='esp.gif' alt='gif image' />";
        ToServer(1, 1);
        return false;
    }

    function FromServer(arg, context) {
        debugger;
        document.getElementById("jio").innerHTML = arg; 
    }

    function passpage(code, pin) {
        debugger;
        window.open("masterpiece.aspx?code=" + code + "&pin=" + pin, "_self");
    }

    function passpage1(code) {
        debugger;
        window.open("allow_split.aspx?code=" + code, "_self");
    }

    function passpage2(code) {
        debugger;
        window.open("tlmgr.aspx?code=" + code, "_self");
    }
        </script>
    </head>
    <body>
        <asp:Button ID="mybut1" Style="background-color: #500; height: auto; width: auto; color: White;" Text="Export To Excel" runat="server" />
        <input id="btn_exit" type="button" value="EXIT" style="background-color: #500; height: auto; width: auto; color: White;" onclick="return btn_exit_onclick()" /><br />
        <br />
        <br />
        <br />
        <br />
        <div id="jio" style="text-align: center;" class="avoid">
        </div>
    </body>
    </html>
</asp:Content>

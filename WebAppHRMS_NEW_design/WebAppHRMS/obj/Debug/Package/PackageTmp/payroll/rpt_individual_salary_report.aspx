<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rpt_individual_salary_report.aspx.vb" Inherits="WebAppHRMS.salary_report_rpt_individual_salary_report_c2017cea1504" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <script type="text/javascript">
        function startTime() {
            var today = new Date();
            var h = today.getHours();
            var m = today.getMinutes();
            var s = today.getSeconds();
            var dat;

            if (h > 12) { dat = "PM"; }
            else if (h < 12) { dat = "AM"; }
            else if (h == 12 && m > 0) { dat = "PM"; }
            if (h == 0) { h = 12; }
            if (h > 12) { h = h - 12; }

            // add a zero in front of numbers<10
            m = checkTime(m);
            s = checkTime(s);
            document.getElementById('txt').innerHTML = "TIME : " + h + ":" + m + ":" + s + " " + dat;
            t = setTimeout('startTime()', 500);
        }

        function checkTime(i) {
            if (i < 10) {
                i = "0" + i;
            }
            return i;
        }
        function Cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }

    </script>

    <title>Untitled Page</title>
</head>
<body onload="startTime()">
    <form id="form1" runat="server">
        <div style="text-align: left">
            <br />
            <input id="Cmd_exit" style="width: 99px" type="button" value="EXIT" onclick="return Cmd_exit_onclick()" />

            <asp:Panel ID="Panel1" runat="server" Height="45px" Width="725px" Style="margin: 0 auto; text-align: center; display: flex; justify-content: center;">
            </asp:Panel>
            &nbsp;&nbsp;
        </div>
    </form>
</body>
</html>

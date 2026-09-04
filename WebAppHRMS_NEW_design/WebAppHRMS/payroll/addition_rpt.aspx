<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="addition_rpt.aspx.vb" Inherits="WebAppHRMS.payroll_addition_rpt_fa5d9b5d4831" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

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
    </script>
    <title>Untitled Page</title>
</head>
<body onload="startTime()">
    <form id="form1" runat="server">
        <div style="text-align: center">
            &nbsp;<asp:Panel ID="Panel1" runat="server" Height="270px" Width="538px" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" Style="margin: 0 auto; text-align: center; display: flex; justify-content: center;">
            </asp:Panel>
            <br />
            <br />

        </div>
    </form>
</body>
</html>

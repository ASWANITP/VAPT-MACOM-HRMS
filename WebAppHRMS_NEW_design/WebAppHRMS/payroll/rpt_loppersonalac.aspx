<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rpt_loppersonalac.aspx.vb" Inherits="WebAppHRMS.lop_to_personal_account_report_rpt_loppersonalac_650299a31659" %>

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
        function Submit1_onclick() {
            window.open('../home.aspx', '_self');
        }

    </script>
    <title>Untitled Page</title>
</head>
<body onload="startTime()">
    <form id="form1" runat="server">
        <div style="text-align: center">
            <input id="Submit1" type="submit" value="EXIT" onclick="return Submit1_onclick()" /><br />
            <asp:Panel ID="Panel1" runat="server" Height="43px" Width="725px" BorderColor="Red" BorderStyle="Solid" BorderWidth="1px">
            </asp:Panel>
            &nbsp;
        </div>
    </form>
</body>
</html>

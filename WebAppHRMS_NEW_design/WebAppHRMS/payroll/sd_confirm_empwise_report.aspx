<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="sd_confirm_empwise_report.aspx.vb" Inherits="WebAppHRMS.SD_CONFIRM_REPORT_sd_confirm_empwise_report_373969907572" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>SD: Confirmed Employeewise Report</title>
</head>
<script language="javascript"> 
    function startTime() {
        var today = new Date();
        var h = today.getHours();
        var m = today.getMinutes();
        var s = today.getSeconds();
        // add a zero in front of numbers<10
        if (h > 12) {
            var a = "PM";
        }
        else {
            a = "AM";
        }
        h = checkhour(h)
        m = checkTime(m);
        s = checkTime(s);

        document.getElementById('txt').innerHTML = h + ":" + m + ":" + s + a;
        t = setTimeout('startTime()', 500);
    }

    function checkTime(i) {
        if (i < 10) {
            i = "0" + i;
        }

        return i;
    }

    function checkhour(i) {
        if (i > 12) {
            i = i - 12;
            if (i < 10) {
                i = "0" + i;
            }
        }

        return i;
    }
</script>
<body onload="startTime()">
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Panel ID="Panel_Sd_Empwise" runat="server" Height="50px" Width="425px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
            </asp:Panel>

        </div>
    </form>
</body>
</html>

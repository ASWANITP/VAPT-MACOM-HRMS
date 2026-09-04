<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="all_inc_empwise_report.aspx.vb" Inherits="WebAppHRMS.all_inc_empwise_report_65556dd39245" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Empwise All,incentives and others</title>
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
    function Button1_onclick() {
        window.open("../home.aspx", '_self');
    }
    function demo() {
        document.getElementById('Button1').style.display = 'none'
        document.getElementById('submit').style.display = 'none'
        window.print();
        document.getElementById('Button1').style.display = 'inline'
        document.getElementById('submit').style.display = 'inline'
    }
</script>
<body onload="startTime()">
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Panel ID="Panel_SecondReport" runat="server" BorderColor="#404040" BorderStyle="Solid"
                BorderWidth="1px" Height="50px" Width="425px">
            </asp:Panel>
            <input id="submit" style="width: 81px" type="button" value="Print" onclick="return demo()" />
            <input id="Button1" style="width: 77px" type="button" value="Exit" onclick="return Button1_onclick()" />

        </div>
    </form>
</body>
</html>

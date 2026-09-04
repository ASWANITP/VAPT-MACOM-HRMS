<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="lop_cancel_report.aspx.vb" Inherits="WebAppHRMS.lop_cancel_report_e96a1db96427" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>my lop cancel report</title>
</head>
<script language="javascript" type="text/javascript"> 
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

<body onload="startTime()" style="text-align: center">
    <form id="form1" runat="server">









        <div style="text-align: center">
            <%--<div style="text-align: center">
            &nbsp;<table >
                <tr >
                 
                    <td style="width: 100px; text-align: center">
            <input id="Button1" style="width: 105px" type="button" value="Exit" onclick="return Button1_onclick()" /></td>
                </tr>
            </table>
        </div>--%>
            <div style="text-align: center">
                &nbsp;
  <table style="margin: 0 auto;">
      <tr>
          <%--  <td style="width: 100px; text-align: right">
      <input type="button" style="width: 113px" value="Print" id="submit" onclick="return demo()"/></td>--%>
          <td style="width: 100px; text-align: center">
              <input id="Button1" style="width: 105px" type="button" value="Exit" onclick="return Button1_onclick()" />
          </td>
      </tr>
  </table>
            </div>

            <asp:Panel ID="PanelHoNSS" runat="server" Width="90%" Style="margin: 0 auto; text-align: center; display: flex; justify-content: center;">
            </asp:Panel>

        </div>
    </form>


</body>
</html>


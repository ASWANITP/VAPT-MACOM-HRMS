<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="wholerep.aspx.vb" Inherits="WebAppHRMS.salary_report_sal_wage_rpt_4cd638817906" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style>
        div {
            margin: 0 auto;
        }
    </style>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.11.2.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
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
        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }


        function fnExcelReport() {
            debugger;
            document.getElementById("<%=bt1.ClientID %>").click();
        }

        function Openform1(Emp) {

            window.open("download.aspx?Emp_ID=" + Emp + "&Stat=" + 1 + "", "_self")

        }
        function Openform2(Emp) {

            window.open("download.aspx?Emp_ID=" + Emp + "&Stat=" + 2 + "", "_self")

        }

    </script>

    <title>Untitled Page</title>
</head>
<body onload="startTime()">
    <form id="form1" runat="server">
        <div id="divsta" style="text-align: right; background-color: #ffffff;">
            <br />
            <asp:Panel ID="Panel1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="0px">
                <%--<asp:Button ID="Button1" runat="server" Text="Download"  />
           <asp:Button ID="Button2" runat="server" Text="Download"  />--%>
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </asp:Panel>

            <div style="text-align: LEFT">
                <asp:Panel ID="Panel2" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="0px">
                </asp:Panel>
                <br />
                <br />
                <%--<input id="cmd_exit" style="width: 87px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" />--%>
            </div>
            <iframe id="dummyFrame" style="display: none"></iframe>
        </div>
        <input style="width: 10.01px; height: 10px; display: none;" type="button" id="bt1" value="exp" runat="server" />
    </form>
</body>
</html>


<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="br_Payroll_Transfer_rpt.aspx.vb" Inherits="WebAppHRMS.Payroll_Transfer_476aa3947609" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <style>
        div {
            margin: 0 auto;
        }
    </style>
    <title>TRANSFER REPORT</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function Button2_onclick() {
            window.open("../../home.aspx", '_self');
        }
        function demo() {
            document.getElementById('Button2').style.display = 'none'
            document.getElementById('Submit1').style.display = 'none'
            window.print();
            document.getElementById('Button2').style.display = 'inline'
            document.getElementById('Submit1').style.display = 'inline'
        }
    </script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="708px">
            </asp:Panel>

            <asp:Panel ID="Panel2" runat="server" Height="50px" Width="651px">
            </asp:Panel>

        </div>

        <div style="left: 50%; text-align: center; margin-top: 750px;">
            <input id="Submit1" style="width: 86px" type="submit" onclick="return demo()" value="PRINT" />
            <input id="Button2" style="width: 83px" type="button" onclick="return Button2_onclick()" value="EXIT" />
        </div>

    </form>
</body>
</html>

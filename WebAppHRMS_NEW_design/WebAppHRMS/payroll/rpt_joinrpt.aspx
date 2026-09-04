<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rpt_joinrpt.aspx.vb" Inherits="WebAppHRMS.joinig_report_rpt_joinrpt_9890d8984246" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Untitled Page</title>
    <style>
        div {
            margin: 0 auto;
        }
    </style>
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function cmd_back_onclick() {
            window.open('joinrpt.aspx', '_self');
        }

        // ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <input id="cmd_back" type="button" value="BACK" onclick="return cmd_back_onclick()" /><br />
            <asp:Panel ID="Panel1" runat="server" Height="48px" Width="749px">
            </asp:Panel>

        </div>
    </form>
</body>
</html>

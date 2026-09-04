<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rpt_branchwise_sal_otherded.aspx.vb" Inherits="WebAppHRMS.salary_consolidated_report_rpt_branchwise_sal_otherded_8a9b4e382487" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">

        function Cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <input id="Cmd_exit" style="width: 91px" type="button" value="EXIT" onclick="return Cmd_exit_onclick()" /><br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="49px" Width="725px">
            </asp:Panel>
            &nbsp;
        </div>
    </form>
</body>
</html>

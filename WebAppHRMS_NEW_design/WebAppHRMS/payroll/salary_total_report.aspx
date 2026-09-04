<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="salary_total_report.aspx.vb" Inherits="WebAppHRMS.Salary_Total_Report_salary_total_report_dec35be37771" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Salary Branchwise Total Report</title>
    <script language="javascript" type="text/javascript">

        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <input id="cmd_exit" style="font-weight: normal; width: 90px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /><br />
            <asp:Panel ID="Panel_Salary_Total" runat="server" Height="45px" Width="775px">
            </asp:Panel>

        </div>
    </form>
</body>
</html>

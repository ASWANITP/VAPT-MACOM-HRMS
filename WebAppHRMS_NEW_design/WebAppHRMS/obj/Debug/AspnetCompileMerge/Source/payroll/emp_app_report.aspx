<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="emp_app_report.aspx.vb" Inherits="WebAppHRMS.Employee_status_emp_app_report_ffd85f976419" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function cmd_exit_onclick() {
window.open('../home.aspx','_self');
}

function cmd_back_onclick() {
window.open('emp_status_Select.aspx','_self');

}

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <input id="cmd_exit" style="width: 74px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" />
        <input id="cmd_back" type="button" value="BACK" onclick="return cmd_back_onclick()" />
        <asp:Panel ID="Panel1" runat="server" Height="48px" Width="725px">
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>

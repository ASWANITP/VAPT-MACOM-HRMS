<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="rpt_empserach.aspx.vb" Inherits="WebAppHRMS.employee_search_rpt_empserach_6b6db7e74774" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">

        function cmd_back_onclick() {
            window.open('empsearch.aspx', '_self')
        }

    </script>
</head>
<body>

    <form id="form1" runat="server">
        <div style="text-align: center">
            <input id="cmd_back" type="button" value="BACK" onclick="return cmd_back_onclick()" /><br />
            <asp:Panel ID="Panel1" runat="server" Height="47px" Width="750px">
            </asp:Panel>
            &nbsp;
        </div>
    </form>
</body>
</html>

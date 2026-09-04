<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="salloplive.aspx.vb" Inherits="WebAppHRMS.salloplive_a11a9a7e8762" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>salary Long Leave Report</title>
    <script language="javascript" type="text/javascript">

        function cmd_exit_onclick() {
            window.open('../home.aspx', '_self');
        }

</script>
</head>
<body>
    <form id="form1" runat="server">

        <div style="text-align: left">
            &nbsp;<input id="cmd_exit" style="vertical-align: middle; width: 62px; text-align: center"
                type="button" value="EXIT" onclick="return cmd_exit_onclick()" />
            <asp:Panel ID="Pan_Sal_Long_Leave" runat="server" Width="725px">
            </asp:Panel>

        </div>
    </form>
</body>
</html>

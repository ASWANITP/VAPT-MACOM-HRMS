<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="TAloplive3.aspx.vb" Inherits="WebAppHRMS.TAloplive3_3b83237d2110" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>salary Long Leave Report</title>
    <script language="javascript" type="text/javascript">

        function cmd_back_onclick() {
            window.open('TA_lop_live3.aspx', '_self');
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div style="text-align: center">
            &nbsp;
        <input id="cmd_back" type="button" value="BACK" onclick="return cmd_back_onclick()" />
            <asp:Panel ID="Pan_Sal_Long_Leave" runat="server" Width="725px">
            </asp:Panel>

        </div>
    </form>
</body>
</html>

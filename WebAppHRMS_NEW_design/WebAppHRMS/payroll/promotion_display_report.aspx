<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="promotion_display_report.aspx.vb" Inherits="WebAppHRMS.promotiondetails_promotion_display_report_26bc35d17651" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">

        function cmd_back_onclick() {
            window.open('promotion_report.aspx', '_self')
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Panel ID="Panel1" runat="server" Width="656px">
            </asp:Panel>
            <br />
            &nbsp;<input id="cmd_back" style="height: 22px" type="button" value="BACK" onclick="return cmd_back_onclick()" />
        </div>
    </form>
</body>
</html>

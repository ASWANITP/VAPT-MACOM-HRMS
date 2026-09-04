<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="~/HRM/longleavereport.aspx.vb" Inherits="WebAppHRMS.specificempattend_individualreport_3ffc5efa8526" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Employee Report</title>
</head>
<script language="javascript" type="text/javascript">

    function Button1_onclick() {
        window.open("../../home.aspx", '_self');
    }
    function demo() {
        window.open("long_leave_rep.aspx", '_self');
    }
</script>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" style="width: 113px" value="Back" id="submit" onclick="return demo()" />
            <input id="Button1" style="width: 105px" type="button" value="Exit" onclick="return Button1_onclick()" />
            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="713px">
            </asp:Panel>
        </div>
    </form>
</body>
</html>

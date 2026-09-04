<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="leave_rpt.aspx.vb" Inherits="WebAppHRMS.leave_leave_rpt_db6829b44502" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() {
window.open('leave_sele.aspx','_self');
}

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:Panel ID="pnl_leav" runat="server" Height="50px" Width="850px">
        </asp:Panel>
        <br />
        <br />
        <br />
        <input id="Button1" type="button" value="BACK" onclick="return Button1_onclick()" /></div>
    </form>
</body>
</html>

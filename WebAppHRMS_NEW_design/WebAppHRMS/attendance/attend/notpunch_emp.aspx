<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="notpunch_emp.aspx.vb" Inherits="WebAppHRMS.attend_attend_emp_5a3dba757050" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
// <!CDATA[
function Button1_onclick() {
window.open("../../home.aspx",'_self')
}
function demo()
{
 document.getElementById('Button1').style.display='none'
 document.getElementById('submit').style.display='none'
 window.print();
 document.getElementById('Button1').style.display='inline'
 document.getElementById('submit').style.display='inline'
}
// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <asp:Panel ID="pnl_attedemp" runat="server" Height="50px" Width="794px">
        </asp:Panel>
        <input id="submit" style="width: 64px" type="button" value="Print"  onclick="return demo()"/>
        <input id="Button1" style="width: 68px" type="button" value="Exit" onclick="return Button1_onclick()" /></div>
    </form>
</body>
</html>

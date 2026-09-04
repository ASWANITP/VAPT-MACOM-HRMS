<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="view_leave_rpt.aspx.vb" Inherits="WebAppHRMS.Leave_Details_view_leave_rpt_33e25c207021" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Leave Details Report</title>
    <script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() 
{
  window.open("../home.aspx",'_self');
}
function demo()
{
 document.getElementById('Button1').style.display='none'
 document.getElementById('submit').style.display='none'
 window.print();
 document.getElementById('Button1').style.display='inline'
 document.getElementById('submit').style.display='inline'
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    <input type="button"  style="width: 113px" value="Print" id="submit"  onclick="return demo()"/>
            <input id="Button1" style="width: 105px" type="button" value="Exit" onclick="return Button1_onclick()" />
        <asp:Panel ID="Panel_Leave" runat="server" Height="50px" Width="725px">
        </asp:Panel>
        &nbsp;
    
    </div>
    </form>
</body>
</html>

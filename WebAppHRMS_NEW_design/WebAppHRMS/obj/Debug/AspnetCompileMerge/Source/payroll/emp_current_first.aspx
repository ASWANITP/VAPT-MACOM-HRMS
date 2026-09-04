<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="emp_current_first.aspx.vb" Inherits="WebAppHRMS.emp_current_first_ce9e295e1743" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Current Details</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() 
{
 window.open('../home.aspx','_self')
}

// ]]>
</script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel_Curr_detls" runat="server" Height="50px" Width="605px">
        </asp:Panel>
        <br />
        <input id="Button1" style="width: 75px" type="button" value="Exit" onclick="return Button1_onclick()" />
    
    </div>
    </form>
</body>
</html>

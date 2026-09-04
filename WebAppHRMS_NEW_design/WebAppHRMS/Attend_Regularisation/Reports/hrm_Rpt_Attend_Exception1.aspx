<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="hrm_Rpt_Attend_Exception1.aspx.vb" Inherits="WebAppHRMS.AnyTimePunching_New_Reports_hrm_Rpt_Attend_Exception1_900268313271" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() 
{
 window.open('../../home.aspx','_self')
}

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <asp:Panel ID="Panel1" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
            Width="50%">
        </asp:Panel>
        <br />
        <input id="Button2" onclick="history.go(-1)" type="button" value="Go Back" />&nbsp;
        <input id="Button1" style="width: 72px; height: 25px" type="button" value="Exit" onclick="return Button1_onclick()" /></div>
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="PunchingReport.aspx.vb" Inherits="WebAppHRMS.HRM_Reports_PunchingReport_c60fae561597" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function btnExit_onclick() 
{
    window.open("../home.aspx","_self")
}

// ]]>
</script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="865px">
        </asp:Panel>
        <br />
        <input id="btnExit" style="cursor: hand; font-family: 'Courier New'" type="button"
            value="Exit" onclick="return btnExit_onclick()" />
    
    </div>
    </form>
</body>
</html>

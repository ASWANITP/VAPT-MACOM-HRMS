<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="HRM_RPT_BH_ABH_NotPunch3.aspx.vb" Inherits="WebAppHRMS.HRM_SECURITY_HRM_RPT_BH_ABH_NotPunch3_baedd9008843" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() 
{
window.open('../home.aspx','_self')
}
function nextpage(areid,BrID)
    {  //debugger;
        window.open("HRM_RPT_BH_ABH_NotPunch4.aspx?id="+areid+"&BrID="+BrID+"","_self")
    }
// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="50%">
        </asp:Panel>
        <br />
        <input id="Button2" onclick="history.go(-1)" style="width: 74px" type="button" value="Back" />
        <input id="Button1" style="width: 63px" type="button" value="Exit" onclick="return Button1_onclick()" />&nbsp;</div>
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="RPT_EncashmentSal.aspx.vb" Inherits="WebAppHRMS.ENCASHMENT_RPT_EncashmentSal_2a9790de1805" %>

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

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <asp:Panel ID="Panel1" runat="server" BackColor="White" BorderColor="Red" BorderWidth="1px"
            Font-Names="Times New Roman" Font-Size="Medium" Height="50px" Width="70%">
        </asp:Panel>
        <br />
        <input id="Button1" style="font-size: 12pt; width: 69px; font-family: 'Times New Roman';
            height: 28px" type="button" value="Exit" onclick="return Button1_onclick()" />&nbsp;</div>
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="hrm_Rpt_Leave_Cancel1.aspx.vb" Inherits="WebAppHRMS.new_leave_hrm_Rpt_Leave_Cancel1_f5f4e9b03679" %>

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
        <asp:Panel ID="Panel1" runat="server" Width="50%" BorderColor="Red" BorderWidth="1px">
        </asp:Panel>
        <br />
        <input id="Button2" onclick="history.go(-1)" style="font-size: 12pt; font-family: 'Times New Roman'"
            type="button" value="Go Back" />
        &nbsp;&nbsp;
        <input id="Button1" style="font-weight: normal; font-size: 12pt; width: 74px; font-family: 'Times New Roman'"
            type="button" value="Exit" onclick="return Button1_onclick()" /></div>
    </form>
</body>
</html>

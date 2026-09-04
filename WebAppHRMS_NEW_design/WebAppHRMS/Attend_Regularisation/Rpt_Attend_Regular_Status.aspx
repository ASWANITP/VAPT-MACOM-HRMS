<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Rpt_Attend_Regular_Status.aspx.vb" Inherits="WebAppHRMS.Attend_Regularisation_No_Date_check__Attend_Regularisation_Rpt_Attend_Regular_Status_389c864d1430" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function Exit_onclick() 
{
 window.open('../home.aspx','_self')
}
// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <asp:Panel ID="Panel1" runat="server" Width="50%">
        </asp:Panel>
        <br />
        <input id="Button2" onclick="history.go(-1)" type="button" value="Go Back" />&nbsp;
        <input id="Exit" style="width: 81px" type="button" value="Exit" onclick="return Exit_onclick()" /></div>
    </form>
</body>
</html>

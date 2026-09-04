<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="sal_wage_rpt.aspx.vb" Inherits="WebAppHRMS.salary_report_sal_wage_rpt_34b2f95f1868" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
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
    <div style="text-align: center; background-color: #ffffff;">
        <br />
        <asp:Panel ID="Panel1" runat="server" Height="2px" Width="100%" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
        </asp:Panel>
        <br />
        &nbsp; &nbsp;&nbsp;
        <br />
        <div style="text-align: center">
            <asp:Panel ID="Panel2" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                Height="37px" Width="533px">
            </asp:Panel>
            &nbsp;
            <input type="button"  style="width: 113px" value="Print" id="submit"  onclick="return demo()"/>
            <input id="Button1" style="width: 105px" type="button" value="Exit" onclick="return Button1_onclick()" /></div>
        </div>
    </form>
</body>
</html>

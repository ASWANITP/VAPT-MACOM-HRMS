<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="promo_report.aspx.vb" Inherits="WebAppHRMS.promotiondetails_promotion_display_report_98a695785275" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
 <title>Employee Promotion Report</title>
<script language="javascript" type="text/javascript">
function cmd_back_onclick() 
{
   window.close();
}
function cmdPrint_onclick() 
{  
    document.getElementById('cmdPrint').style.display='none';
    document.getElementById('cmd_back').style.display='none';
    window.print();
    document.getElementById('cmdPrint').style.display='inline';
    document.getElementById('cmd_back').style.display='inline';
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <asp:Panel ID="Panel1" runat="server" Width="85%" style="font-family: 'Bookman Old Style'">
        </asp:Panel>
        <div style="text-align: center">
            <table style="width: 114px">
                <tr>
                    <td style="width: 100px">
                        <input id="cmdPrint" style="height: 22px; width: 63px; cursor: hand; font-family: 'Bookman Old Style';" type="button" value="Print" onclick="return cmdPrint_onclick()" /></td>
                    <td style="width: 100px">
                        <input id="cmd_back" style="height: 22px; width: 63px; cursor: hand; font-family: 'Bookman Old Style';" type="button" value="Close" onclick="return cmd_back_onclick()" /></td>
                </tr>
            </table>
        </div>
        &nbsp;<br />
        &nbsp;</div>
    </form>
</body>
</html>

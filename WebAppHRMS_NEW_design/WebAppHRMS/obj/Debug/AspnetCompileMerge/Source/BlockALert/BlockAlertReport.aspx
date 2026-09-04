<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="BlockAlertReport.aspx.vb" Inherits="WebAppHRMS.BlockALert_BlockAlertReport_7b62b1403635" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Todays Punching Blocks and Alerts</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function cmd_Exit_onclick() 
{
   window.open('../home.aspx','_self');
}
function demo()
{
     document.getElementById('cmd_Print').style.display='none';
     document.getElementById('cmd_Exit').style.display='none';
     window.print();
     document.getElementById('cmd_Print').style.display='inline';
     document.getElementById('cmd_Exit').style.display='inline';
}
// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <%--<asp:Panel ID="panelPunchReport" runat="server" Height="50px" Style="font-family: 'Bookman Old Style'"
            Width="70%">
        </asp:Panel>--%>
        <asp:Panel ID="panelPunchReport" runat="server" Height="50px" Width="70%" 
    Style="font-family: 'Bookman Old Style'; margin: 0 auto; text-align: center; display: flex; justify-content: center;">
</asp:Panel>

        <div style="text-align: center">
            <table style="width: 10% ; bottom: 345px; left: 45%;position:fixed;">
                <tr>
                    <td style="width: 100px">
                        <input id="cmd_Print" onclick="return demo()" style="width: 67px; cursor: hand; font-family: 'Courier New'"
                            type="button" value="Print" /></td>
                    <td style="width: 100px">
                        <input id="cmd_Exit" style="width: 67px; cursor: hand;
                            font-family: 'Courier New'" type="button" value="Exit" onclick="return cmd_Exit_onclick()" /></td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>

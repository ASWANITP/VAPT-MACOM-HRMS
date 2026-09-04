<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="fixed_ta_report.aspx.vb" Inherits="WebAppHRMS.Fixed_TA_New_fixed_ta_report_a037239f8934" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fixed TA Report</title>

    <style>
        div {
            margin: 0 auto;
        }
    </style>
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
<body style="text-align: center">
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Panel ID="panel_FixedTA" runat="server" Height="50px" Style="font-family: 'Courier New'">
            </asp:Panel>

        </div>
        <div style="text-align: center">
            <table style="width: 124px">
                <tr>
                    <td style="width: 100px; text-align: right">
                        <input id="cmd_Print" onclick="return demo()" style="cursor: hand; font-family: 'Courier New'" type="button"
                            value="Print" /></td>
                    <td style="width: 100px; text-align: left">
                        <input id="cmd_Exit" style="cursor: hand; font-family: 'Courier New'; width: 61px;" type="button"
                            value="Exit" onclick="return cmd_Exit_onclick()" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

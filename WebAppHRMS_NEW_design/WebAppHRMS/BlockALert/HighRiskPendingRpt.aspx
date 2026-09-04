<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="HighRiskPendingRpt.aspx.vb" Inherits="WebAppHRMS.BlockALert_HighRiskPendingRpt_f667e4fe7420" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>High Risk Not Update Report</title>
    <script language="javascript" type="text/javascript">
        function cmd_Exit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function demo() {
            document.getElementById('cmd_Print').style.display = 'none';
            document.getElementById('cmd_Exit').style.display = 'none';
            window.print();
            document.getElementById('cmd_Print').style.display = 'inline';
            document.getElementById('cmd_Exit').style.display = 'inline';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Panel ID="pan_HighRisk" runat="server" Height="50px" Width="80%" Style="font-family: 'Bookman Old Style'">
            </asp:Panel>
            <div style="text-align: center">
                <table style="width: 126px">
                    <tr>
                        <td style="width: 100px; text-align: right">
                            <input id="cmd_Print" onclick="return demo()" style="width: 67px; cursor: hand; font-family: 'Courier New'"
                                type="button" value="Print" /></td>
                        <td style="width: 100px; text-align: left">
                            <input id="cmd_Exit" style="width: 67px; cursor: hand; font-family: 'Courier New'"
                                type="button" value="Exit" onclick="return cmd_Exit_onclick()" /></td>
                    </tr>
                </table>
            </div>
            <div style="text-align: center">
                <table style="width: 590px">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label1" runat="server" Style="font-family: 'Bookman Old Style'" Width="586px"></asp:Label></td>
                    </tr>
                </table>
            </div>

        </div>
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="increment_report.aspx.vb" Inherits="WebAppHRMS.payroll_Posting_increment_report_e1522ac71324" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Increment Report</title>
    <script type="text/javascript">

        function Button2_onclick() {
            window.close();
        }

        function Button1_onclick() {
            document.getElementById('Button1').style.display = 'none'
            document.getElementById('Button2').style.display = 'none'
            window.print();
            document.getElementById('Button1').style.display = 'inline'
            document.getElementById('Button2').style.display = 'inline'
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Panel ID="Panel1" runat="server" Width="727px">
            </asp:Panel>
            <div style="text-align: center">
                <table style="width: 94px">
                    <tr>
                        <td style="width: 100px">

                            <input id="Button1" style="width: 57px; cursor: hand; font-family: 'Bookman Old Style';" type="button" value="Print" onclick="return Button1_onclick()" /></td>
                        <td style="width: 100px">

                            <input id="Button2" style="width: 57px; cursor: hand; font-family: 'Bookman Old Style';" type="button" value="Close" onclick="return Button2_onclick()" /></td>
                    </tr>
                </table>
            </div>
            <br />
            &nbsp;
        </div>
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="allo_inc_firstreport.aspx.vb" Inherits="WebAppHRMS.allo_inc_firstreport_3e57fe0e3541" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Allowances Incentives Report</title>
    <script language="javascript" type="text/javascript">

        function Button1_onclick() {
            window.open("../home.aspx", '_self');
        }
        function demo() {
            document.getElementById('Button1').style.display = 'none'
            document.getElementById('submit').style.display = 'none'
            window.print();
            document.getElementById('Button1').style.display = 'inline'
            document.getElementById('submit').style.display = 'inline'
        }
        // ]]>
    </script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel_First" runat="server" Height="50px" Width="625px">
            </asp:Panel>
            <input id="submit" style="width: 91px" type="button" value="Print" onclick="return demo()" />
            <input id="Button1" style="width: 87px" type="button" value="Exit" onclick="return Button1_onclick()" />
        </div>
    </form>
</body>
</html>

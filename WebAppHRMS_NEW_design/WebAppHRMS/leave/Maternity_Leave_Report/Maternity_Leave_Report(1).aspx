<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Maternity_Leave_Report(1).aspx.vb" Inherits="WebAppHRMS.Referral_Incentive_Referral_Report_d7fedeed3757" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        //function Button1_onclick() 
        //{
        //  window.open("../../home.aspx",'_self');
        //}

        function demo() {
            document.getElementById('Button2').style.display = 'none'
            document.getElementById('Button1).style.display='none'
 window.print();
            document.getElementById('Button2').style.display = 'inline'
            document.getElementById('Button1').style.display = 'inline'
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Print" Width="58px" />
            &nbsp; &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Exit" Width="61px" />
        </div>
        <asp:Panel ID="Panel1" runat="server" Height="67px" Width="932px">
        </asp:Panel>
    </form>
</body>
</html>

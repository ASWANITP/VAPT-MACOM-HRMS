<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Mater_report.aspx.vb" Inherits="WebAppHRMS.salaryreport_wage_slip_report_ea6c54d86839" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <asp:Button ID="fbtn" runat="server" Text="SAVE TO EXCEL" /><asp:GridView ID="GridView2"
                runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>

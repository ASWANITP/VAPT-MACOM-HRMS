<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="wage_slip_report_ol_macom.aspx.vb" Inherits="WebAppHRMS.salaryreport_wage_slip_report_560a62de8808" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>

    <form id="form1" runat="server">

        <div style="text-align: center;">
            <asp:Panel ID="Panel1" runat="server" Width="604px">
                <input type="button" style="width: 113px" value="Print" id="Button1" runat="server" onclick="window.print()" />
                <%--  <asp:Button ID="Button1" Font-Bold="true" runat="server" Text="Print" />--%>
            </asp:Panel>
        </div>
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="sal_indivi_HO_all_report.aspx.vb" Inherits="WebAppHRMS.Salary_Individ_Ho_statement_sal_indivi_HO_all_report_5cdbde592029" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Register Of Wages</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function cmd_back_onclick() {
window.open('sal_individ_HO_select.aspx','_self');
}

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
    <input id="cmd_back" type="button" value="BACK" onclick="return cmd_back_onclick()" />
        <br />
        <asp:Panel ID="Panel_Sal_HO" runat="server" Height="50px" Width="1800 px">
        </asp:Panel>
        </div>
    </form>
</body>
</html>

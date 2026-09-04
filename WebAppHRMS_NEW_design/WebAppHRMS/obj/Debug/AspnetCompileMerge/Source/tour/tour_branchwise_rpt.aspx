<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="tour_branchwise_rpt.aspx.vb" Inherits="WebAppHRMS.Tour_Report_Brwise_tour_branchwise_rpt_09dfe71b3601" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<style media=print>  .hide_print {display: none;} </style>
    <title>Employee Tour Report</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function btnExit_onclick() {
window.open('tour_branchwise_rptselect.aspx','_self');
}

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span class="hide_print">
        <input id="btnExit" type="button" value="<< BACK" onclick="return btnExit_onclick()" />
        </span>
        <asp:Panel ID="Panel_Emp_Tour" runat="server" Height="50px" Width="125px">
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>

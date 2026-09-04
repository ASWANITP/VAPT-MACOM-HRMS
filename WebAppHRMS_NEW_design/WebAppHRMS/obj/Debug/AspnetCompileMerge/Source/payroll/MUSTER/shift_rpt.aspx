<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="shift_rpt.aspx.vb" Inherits="WebAppHRMS.leave_leave_rpt_977aeed57607" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() {
window.open('../../home.aspx','_self');
}

// ]]>
function PrintPanel() {debugger;
            var panel = document.getElementById("<%=pnl_leav.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
//            printWindow.document.write('<html><head>');
//            printWindow.document.write('</head><body >');
//            printWindow.document.write(panel.innerHTML);
//            printWindow.document.write('</body></html>');
var ajil='<html><head></head><body>'+panel.innerHTML+'</body></html>';
ajil=ajil.replace("\n","")
ajil=ajil.replace("\r","")
            printWindow.document.write(ajil);
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 10);
            return false;
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center;">
        <br />
        <asp:Panel ID="pnl_leav" BorderStyle="Inset" runat="server" >
        </asp:Panel>
        <input id="Button1" type="button" value="Print" onclick="return PrintPanel()" />&nbsp;<input id="Button2" type="button" value="Exit" onclick="return Button1_onclick()" /></div>
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="PresentReportD.aspx.vb" Inherits="WebAppHRMS.Attendence_Report_PresentReportD_31d5029f6985" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <script type="text/javascript">
    function next(did,frdate)
{

window.open('PresentReportA.aspx?divid='+did+'&fdate='+frdate,'_self');

}
function Button1_onclick() 
{
  window.open("../../home.aspx",'_self');
}
function demo()
{
 document.getElementById('Button1').style.display='none'
 document.getElementById('submit').style.display='none'
 window.print();
 document.getElementById('Button1').style.display='inline'
 document.getElementById('submit').style.display='inline'
}    
    </script>
    <div style="text-align: left">
 <input type="button"  style="width: 113px" value="Print" id="submit"  onclick="return demo()"/>
            <input id="Button1" style="width: 105px" type="button" value="Exit" onclick="return Button1_onclick()" />
        <asp:Panel ID="Panel_report" runat="server" Height="50px" Width="80%" Wrap="False">
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>

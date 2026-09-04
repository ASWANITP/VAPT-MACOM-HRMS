<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="hrm_compulsary_reportrpt.aspx.vb" Inherits="WebAppHRMS.hrm_compulsary_reportrpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>REGULARISATION REPORT</title>
<script type="text/javascript">

function Button1_onclick() 
{
    /*window.open("../../home.aspx",'_self');*/
    window.open("hrm_compulsaryleave_report.aspx",'_self');
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
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
     
       <div style="display: flex; justify-content: center;">
    <asp:Panel ID="Panel_report" runat="server" Width="80%" style="height:auto;">
          <asp:Literal ID="litTitle" runat="server" />
        <asp:Literal ID="litHeader" runat="server" />

    </asp:Panel>
</div>
        <br/>
                    <input type="button"  style="width: 113px" value="Print" id="submit"  onclick="return demo()"/>
<input id="Button1" style="width: 105px" type="button" value="Exit" onclick="return Button1_onclick()" />
        <asp:Button ID="btnExportExcel" runat="server" Text="Export to Excel" OnClick="btnExportExcel_Click" />

         </div>
    </form>
</body>
</html>


<%@ Page Language="VB" AutoEventWireup="false"  MasterPageFile="~/edp.master" CodeBehind="ta_allowa_bulk.aspx.vb" Inherits="WebAppHRMS.bulk_upload_ta_allowa_bulk_235ee2944607" %>
<%--
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
--%>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
</asp:ScriptManager>
<script language="javascript" type="text/javascript">
// <!CDATA[
function UploadFile(fileUpload) {
        if (fileUpload.value != '') {
            document.getElementById("<%=bt1.ClientID %>").click();
        }
    }
function Button2_onclick() {
window.open('../home.aspx','_self');
}
function van() 
{
alert ("Please select date from calendar! ")
  return false;
}
// ]]>
</script>
<script src="~/script/jquery.min.js" type="text/javascript"></script>
<script src="~/script/jquery-1.8.2.js" type="text/javascript"></script>
<script src="http://code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js"></script>
<script type="text/javascript">             //Default.aspx
   function DeleteKartItems() 
   {     
   debugger;
  
         $.ajax({
         type: "POST",
         url: './upexcel.aspx/DeleteItem',
         data: "",
         contentType: "application/json; charset=utf-8",
         dataType: "json",
         success: function (msg) {
            alert("Total Sum Of Your Excel is"+" "+msg);
         },
         error: function (e) {
            alert("Something Went Wrong.Couldn't Open Your Excel Attached.Try After Sometime.");
         }
     });

   }
</script>
<script type="text/javascript">
          function showImage()
          {
              document.getElementById("image").style.display="inline";
              document.getElementById("image").src = 'http://localhost:54411/HRM_LOCAL/gifs/tooltip.png';
          }
           function hideImage()
          {
              document.getElementById("image").style.display="none";
              document.getElementById("image").src = '';
          }
   </script>

       <div style="border: 1px solid black; padding: 20px; width: 620px; margin: auto;text-align: center;">
<table border="1" style="border-collapse: collapse; width: 600px; margin: auto;">
            <tr>
                <td colspan="4" style="width: 550px; height: 20px;">
                    <strong style="font-size: 20px;">BULK-EXCEL TA UPDATION<br /></strong>
                    
                    
            </tr>
            
<tr>
                <td colspan="4" style="width: 550px"><br /><br />
                <input style="width :0.01px;height:0px;color:#faebd7 ;border-color:#faebd7 ;background-color: #faebd7;float:right;display:none ;" type="button" id="bt1" runat="server" />
                    
                     <B style="margin-left:4px;"> SELECT ALLOWANCE/TA :</B>&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Width="200px">
                    </asp:DropDownList><br />
                    
<%--                    <asp:LinkButton ID="LinkButton1" runat="server" OnMouseOver="showImage();" OnMouseOut="hideImage();">VIEW FORMAT</asp:LinkButton>
        <img src="" id="image" alt="" width="216px" height="275px" style="display:none;" align="right"/>--%>
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Download Excel Format" /><br />
                    <form method ="post" action="">
                    <br />
                      <B>BROWSE FOR FILE<B/>&nbsp;<br /><br />
                    <%--<asp:FileUpload ID="FileUpload1" onchange="return DeleteKartItems()" accept="application/vnd.ms-excel,application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" runat="server"/><br />--%>
                    <asp:FileUpload ID="FileUpload1" accept="application/vnd.ms-excel,application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" runat="server" Visible="true" Width="192px" style="margin-left: 33px;"/><br />
                    <br />
                    <br />
                   
                    <input type="hidden" runat ="server" id="hids" />
              <asp:HiddenField ID="hid" Value ="0" runat ="server" />
                          &nbsp;
                          <B>TOTAL AMOUNT :</B>
                    <asp:TextBox ID="TextBox1" runat="server" style="width: 254px;"></asp:TextBox><br />
                    <br />
                    <%--<asp:Button ID="cmd_confirm" OnClientClick ="return confirm_meth()" runat="server" Text="UPLOAD EXCEL" /><br />--%>
                    <asp:Button ID="cmd_confirm" runat="server" Text="UPLOAD EXCEL" Width="150px" style="text-align:center;" />
                          <%--<asp:Button ID="Button2" runat="server" Text="UPLOAD EXCEL" />--%><br /><br />
                          
                            <asp:Button ID="Button2" runat="server" Text="EXIT" Width="150px" /><br />
                          
                     </form>
                    </td>
            </tr>
            <tr>
                <td colspan="4" style="width: 550px">
                </td>
                
            </tr>
            
        </table>
        
    </div>
    <div id="divResult"></div>
</asp:Content>


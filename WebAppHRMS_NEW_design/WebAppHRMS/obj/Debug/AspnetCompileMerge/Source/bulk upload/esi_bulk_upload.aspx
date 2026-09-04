<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="esi_bulk_upload.aspx.vb"
    Inherits="bulk_upload_esi_bulk_upload_00f340a49990" Title="Untitled Page" %>
    
   
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

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
  
    function storeFilePath() {
        var fileUpload = document.getElementById('<%= FileUpload1.ClientID %>');
        var filePath = fileUpload.value;
        document.getElementById('<%= hid.ClientID %>').value = filePath;
    }

</script>



    <%--<div style="text-align: center">
        <table border="1" style="border-collapse: collapse; width: 600px; margin: auto;">--%>
    <div style="border: 1px solid black; padding: 20px; width: 620px; margin: auto;text-align: center;">
    <table border="1" style="border-collapse: collapse; width: 600px; margin: auto;">
            <tr>
                <td colspan="4" style="width: 550px; height: 20px;">
                   <strong style="font-size: 20px;">BULK-EXCEL ESI UPDATION<br /></strong>

                </td>
            </tr>
            <tr>
                <td colspan="4" style="width: 550px">
                    <input style="width: 0.01px; height: 0px; color: black; border-color: black;
                        background-color: #faebd7; float: right; display: none;" type="button" id="bt1"
                        runat="server" />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Download Excel Format" /><br />
                   <br />
                    <%--<form method="post" action="">
                        <br />--%>
                        <b>BROWSE FOR FILE</b>&nbsp;<br /><br />
                        <%--<asp:FileUpload ID="FileUpload1" onchange="return DeleteKartItems()" accept="application/vnd.ms-excel,application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" runat="server"/><br />--%>
                        <asp:FileUpload ID="FileUpload1" accept="application/vnd.ms-excel,application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" runat="server" style="text-align:center;margin-left: 98px;" /><br /><br /><br />
                       
                     
   
                        
                 <input type="hidden" runat ="server" id="hids" />
              <asp:HiddenField ID="hid" Value ="0" runat ="server" />
                        
                        <%--<asp:Button ID="cmd_confirm" OnClientClick ="return confirm_meth()" runat="server" Text="UPLOAD EXCEL" /><br />--%>
                        <asp:Button ID="cmd_confirm" runat="server" Text="UPLOAD EXCEL" Width="150px" />
                        <%--<asp:Button ID="Button2" runat="server" Text="UPLOAD EXCEL" />--%>
                          <asp:Button ID="Button2" runat="server" Text="EXIT" Width="150px" /><br />
                        <br />
                    <%--</form>--%>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="width: 550px">
                </td>
            </tr>
        </table>
    </div>
    <div id="divResult">
    </div>
</asp:Content>

<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_attend_request.aspx.vb" Inherits="WebAppHRMS.Attend_Regularisation_hrm_attend_request_3bce0db25678" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont = master_no.split("txt")
function Button2_onclick() 
{
window.open('../home.aspx','_self')
}
function CheckLength(Control,MaxNum)
{      
     if(Control.value.length<=MaxNum)
       {return true;}
     else
     {alert("Only "+MaxNum+" Characters Allowed...!!!");
     return false;
     }
}
function textupper(name)
{
    document.getElementById(cont[0]+name).value=document.getElementById(cont[0]+name).value.toUpperCase();
    return true;
} 



function isNumberKey()
{ //debugger;
 var charcode = (event.which) ? event.which : event.keyCode 
 
    if (charcode > 31 && (charcode < 48 || charcode > 57  ))
  {
    return false;
  } 
    else
     return true;  
 
     
} 
// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 384px; height: 90px">
            <caption>
                <span style="color: #660033"><strong>ATTENDANCE REGULARISATION REQUEST FORM<br />
                </strong><span style="color: #000000">Please Contact HO for Complaint Registration<br />
                    &nbsp;Auditors Not Enter Complaint number<br />
                </span></span></caption>
            <tr>
                <td colspan="2" style="text-align: left">
                    Date</td>
                <td colspan="2">
                    <asp:TextBox ID="txt_Date" runat="server" Width="257px" Font-Names="Times New Roman" Font-Size="Medium" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    Request Reason</td>
                <td colspan="2">
                    <asp:TextBox ID="txt_Reason" runat="server" onkeypress="return CheckLength(this,'150')" onkeyup="return textupper('txt_Reason')"  Width="257px" Font-Names="Times New Roman" Font-Size="Medium"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left">
                    Hard&nbsp;Ware&nbsp;Complaint&nbsp;Number</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_Complaint" runat="server" Width="257px" MaxLength="13"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btn_Confirm" runat="server" Text="Confirm" Font-Names="Times New Roman" Font-Size="Medium" />
                    <input id="Button2" type="button" value="Exit" style="font-size: 12pt; width: 68px; font-family: 'Times New Roman'" onclick="return Button2_onclick()" /></td>
            </tr>
        </table>
    </div>
    &nbsp;&nbsp;
    <br />
    <div style="text-align: center">
        &nbsp;</div>
</asp:Content>


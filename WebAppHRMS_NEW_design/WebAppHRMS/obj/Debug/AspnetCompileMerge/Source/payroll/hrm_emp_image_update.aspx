<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_emp_image_update.aspx.vb" Inherits="WebAppHRMS.emp_image_hrm_emp_image_update_f0c39c838043" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont = cont_name.split("txt");
function cmd_exit_onclick() {
window.open('../home.aspx','_self');
}
function isNumberKey(a)
{
    if(isNaN(document.getElementById(cont[0]+a).value))
    {
      document.getElementById(cont[0]+a).value='';
      return false;
    } 
    else
     return true;  
}
function checkbeforeconfirm()
{
    if((parseInt(document.getElementById(cont[0]+'txt_marks').value)=='')||(parseInt(document.getElementById(cont[0]+'txt_marks').value)=='')) 
    {
        alert('please enter marks');
        return false;
    }
    if(parseInt(document.getElementById(cont[0]+'txt_marks').value)>parseInt(document.getElementById(cont[0]+'txt_total').value))
    {
        alert('please check marks entered');
        return false;
    }
}
function cmd_image_onclick() 
{
  //  arr=document.getElementById(cont[0]+"cmb_leave").value.split("*") ;  
  
    window.open('view_emp_photo.aspx?empcode=' + document.getElementById(cont[0]+"hid3").value + ' @2','_self');

}

function Button1_onclick() {
window.open('../home.aspx','_self');
}

// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 624px">
            <tr>
                <td colspan="3" style="height: 43px; text-align: center">
                    <strong><span style="font-size: 14pt; text-decoration: underline">Employee Photo And
                        Certificate Updation</span></strong></td>
            </tr>
            <tr>
                <td style="width: 353px; text-align: left">
                    Select Employee :
                </td>
                <td style="width: 182px; text-align: left">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                <td style="width: 100px; text-align: left">
                    <asp:Button ID="btn_Ok" runat="server" Text="OK" Width="63px" /></td>
            </tr>
            <tr>
                <td style="width: 353px; text-align: left">
                    Qualification Category :</td>
                <td colspan="2" style="text-align: left">
                    <input id="txt_category" size="20" style="width: 377px" type="text" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 353px; text-align: left; height: 28px;">
                    Qualification:
                </td>
                <td colspan="2" style="text-align: left; height: 28px;">
                    <input id="txt_qualification" size="20" style="width: 377px" type="text" runat="server" /></td>
            </tr>
            <tr>
                <td style="width: 353px; text-align: left">
                    Marks Obtained :
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_marks" runat="server" onblur="return isNumberKey('txt_marks')" onkeypress="return isNumberKey('txt_marks')" MaxLength="4" Width="59px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 353px; text-align: left">
                    Total Marks :
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_total"  onblur="return isNumberKey('txt_marks')" onkeypress="return isNumberKey('txt_total')" runat="server" MaxLength="4" Width="59px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 353px; text-align: left">
                    Photo :
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="378px" /></td>
            </tr>
            <tr>
                <td style="width: 353px; text-align: left">
                    Final
                    Certificate&nbsp; :</td>
                <td colspan="2" style="text-align: left">
                    <asp:FileUpload ID="FileUpload2" runat="server" Width="380px" /></td>
            </tr>
            <tr>
                <td style="width: 353px; text-align: right">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" OnClientClick="return checkbeforeconfirm()" /></td>
                <td style="width: 182px; text-align: right">
                </td>
                <td style="width: 100px; text-align: left">
                    <input id="Button1" type="button" value="EXIT" onclick="return Button1_onclick()" style="width: 62px" /></td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center">
                    <span style="color: #ff0000">* If any change found in last qualification ,please contact
                        HRM</span></td>
            </tr>
        </table>
        <input id="hid1" runat="server" type="hidden" />
        <input id="hid2" runat="server" type="hidden" />
        <input id="hid3" runat="server" type="hidden" /><br />
        &nbsp;</div>
</asp:Content>


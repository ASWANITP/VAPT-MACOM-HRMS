<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="editstaffnormreq.aspx.vb" Inherits="WebAppHRMS.edit_staff_norms_req_editstaffnormreq_611a2cea2172" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont_name=header.split("txt")

function Button1_onclick() 
{
window.open('../../home.aspx','_self');
}
function checknum(e)
{
  
    var v
    v=document.getElementById(cont_name[0]+"txt_req").value
    var iKeyCode = 0; 
    iKeyCode = window.event.keyCode; 
    if (isNaN(v) || iKeyCode==32)
    {
        document.getElementById(cont_name[0]+"txt_req").value=""
        document.getElementById(cont_name[0]+"txt_req").focus()
        return false;
    }  
            

}
// ]]>
</script>

    <br />
    <br />
    <br />
    <div style="text-align: center">
        <table border="1" style="width: 384px; height: 82px">
            <tr>
                <td colspan="2" style="text-align: center">
                    <span style="color: #ff0000"><span style="text-decoration: underline"><strong>EDIT STAFF
                        NORM HO REQUIREMENT<br />
                    </strong></span>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </span>
                </td>
            </tr>
            <tr>
                <td style="width: 177px; text-align: right">
                    Department : &nbsp;
                </td>
                <td style="width: 100px">
                    <asp:DropDownList ID="cmb_dep" runat="server" AutoPostBack="True" Width="192px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 177px; text-align: right">
                    &nbsp;
                    Requirement :&nbsp;
                </td>
                <td style="width: 100px; text-align: left;">
                    <asp:TextBox ID="txt_req" runat="server" Width="139px" MaxLength="3"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 177px; text-align: right">
                    &nbsp;<asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                <td style="width: 100px; text-align: left;">
                    <input id="Button1" style="width: 84px" type="button" value="EXIT" onclick="return Button1_onclick()" /></td>
            </tr>
        </table>
    </div>
    <br />
    &nbsp;
    <br />
</asp:Content>


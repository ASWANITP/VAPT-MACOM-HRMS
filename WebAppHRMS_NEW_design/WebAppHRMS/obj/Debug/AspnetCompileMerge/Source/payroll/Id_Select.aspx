<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Id_Select.aspx.vb" Inherits="WebAppHRMS.ins_date_sel_08faea999934" title="Date Selection" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ mastertype VirtualPath ="~/edp.master"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
var cont_name = header.split('cmb');

function Button2_onclick()
{
debugger;
window.open('../home.aspx','_self'); }


function Button1_onclick() 
{ debugger;
       var ind = document.getElementById(cont_name[0]+"cmb_firm").value;
       if (ind==0)
       {
       alert("Please choose ID...!!");
       return false;
       } 
//   window.open('req_report.aspx?IDV='+ind+'','_self')

}

</script>

    <div style="text-align: center;">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
       
        <table border="1" style="width: 32%; margin:0 auto;" class ="maintable" >
            <tr class="groupheader">
                <td colspan="4" style="text-align: center; height: 21px;">
                    <strong>
                    &nbsp;RESOURCE REQUISITION CONFIRMATION</strong></td>
            </tr>
           
            <tr>
                <td style="width:42%; text-align=left">
                    <asp:Label ID="Label1" runat="server" Text="Firm" Width="144px"></asp:Label>
                </td>
                <td style="text-align: left;" colspan="3">
                    <asp:DropDownList ID="cmb_firm" runat="server" Width="200px">
                    </asp:DropDownList>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 42%">
                </td>
                <td style="text-align: left" colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                <input id="Button1" class ="bttn_design"  type="button"
                    value="VIEW" onclientclick ="return Button1_onclick()" runat="server" />
                <input id="btn_exit"  class ="bttn_design" type="button"
                    value="EXIT" onclick="return Button2_onclick()" /></td>
            </tr>
        </table>
        </div>
    <%--</div>--%>
</asp:Content>


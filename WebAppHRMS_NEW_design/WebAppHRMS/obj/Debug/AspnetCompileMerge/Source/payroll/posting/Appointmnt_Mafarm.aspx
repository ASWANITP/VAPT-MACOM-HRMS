<%--<%@ Page Language="VB" asterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Appointmnt_Mafarm.aspx.vb" Inherits="Payroll_Appointmnt_Mafarm_917b8fda7921" %>--%>

<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Appointmnt_Mafarm.aspx.vb" Inherits="WebAppHRMS.Payroll_Appointmnt_Mafarm_917b8fda7921" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont_name=header.split("txt")

function cmd_exit_onclick() {
window.open('../home.aspx','_self');
}

function upperconverter1()
{
    document.getElementById(cont_name[0]+"txt_confirm").value=document.getElementById(cont_name[0]+"txt_confirm").value.toUpperCase();
  }
   function upperconverter2()
{
    document.getElementById(cont_name[0]+"txt_designation").value=document.getElementById(cont_name[0]+"txt_designation").value.toUpperCase();
}
function upperconverter3()
{
    document.getElementById(cont_name[0]+"txt_lmark").value=document.getElementById(cont_name[0]+"txt_lmark").value.toUpperCase();
}
function upperconverter4()
{
    document.getElementById(cont_name[0]+"txt_idno").value=document.getElementById(cont_name[0]+"txt_idno").value.toUpperCase();

}



function TABLE1_onclick() {

}

// ]]>
</script>

    <br />
   <DIV style="TEXT-ALIGN: center">
    <asp:ScriptManager id="ScriptManager2" runat="server">
    </asp:ScriptManager>
                <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="cmb_code">
                </cc1:ListSearchExtender>
            <table border="1" style="width: 453px; height: 34px">
                <tr style ="height: 10px;">
            <td style="width: 180px;height: 10px; text-align: right">
                Select Employee Code :</td>
            <td style="width: 100px">
                <asp:DropDownList ID="cmb_code" runat="server" Height="20px" Width="262px" autocomplete="off" ondrop="false" onkeydown="return false" onpaste="false">
                </asp:DropDownList>&nbsp;
            </td>
        </tr>
                <tr>
                    <td style="width: 180px; text-align: right">
                        Date :</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txt_dt" runat="server" autocomplete="off" ondrop="false" onkeydown="return false" onpaste="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 180px; text-align: right">
                        Select Join Date :</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="Txtjoin" runat="server" autocomplete="off" ondrop="false" onkeydown="return false" onpaste="false"></asp:TextBox></td>
                          <cc1:CalendarExtender id="CalendarExtender2" runat="server" TargetControlID="Txtjoin" BehaviorID="ctl20_CalendarExtender4" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                </tr>
    </table>
       <br />
        <table border="1">
            <tr>
                <td style="width: 100px; height: 28px;">
                    <asp:Button ID="cmd_appletter" runat="server" Text="Appointment Letter" Width="150px" style="cursor: hand" /></td>
                <td style="width: 100px; height: 28px;">
                    <input id="cmd_exit" style="width: 108px; cursor: hand;" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
            </tr>
        </table>
       &nbsp; &nbsp;
    <br />
    <div style="text-align: center">
        &nbsp;</div>
    <br />
  
    <br />
    <div style="text-align: center">
        &nbsp;</div>
    <br />
    </div>
</asp:Content>

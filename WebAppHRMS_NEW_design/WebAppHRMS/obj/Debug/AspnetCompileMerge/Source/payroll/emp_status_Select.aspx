<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false"   EnableEventValidation="false"  CodeBehind="emp_status_Select.aspx.vb" Inherits="WebAppHRMS.Employee_status_emp_status_Select_6650cc1a6925" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont=loanno.split("cmb")
function cmd_exit_onclick() {
window.open('../home.aspx','_self');
}
function rdbcheck()
{
    if (document.getElementById("rdb_firm").checked==true)
    {
        document.getElementById("rdb_department").checked=false;
        document.getElementById("rdb_all").checked=false;
        document.getElementById(cont[0]+"Hidden1").value=1;
        document.getElementById("row3").style.display="inline";
        call_server("1*" + document.getElementById(cont[0]+"Hidden1").value,1);

    }
    if (document.getElementById("rdb_department").checked==true)
    {
        document.getElementById("rdb_firm").checked=false;
        document.getElementById("rdb_all").checked=false;
        document.getElementById(cont[0]+"Hidden1").value=2;
        document.getElementById("row3").style.display="inline";
        call_server("2*" + document.getElementById(cont[0]+"Hidden1").value,2);

    }
    if (  document.getElementById("rdb_all").checked==true) 
    {
        document.getElementById("rdb_firm").checked=false;
        document.getElementById("rdb_department").checked=false;
        document.getElementById(cont[0]+"Hidden1").value=3;
        document.getElementById(cont[0]+"Hidden2").value=0;
        document.getElementById("row3").style.display="none";
    }
    
}
function call_receiver(arg,context)
{
    document.getElementById(cont[0]+"cmb_firm").options.length=0;
    var lima=arg.split("$");

    for (a=0;a<lima.length;a++)
    {   
        var cols=lima[a].split("-");
        var option1   = document.createElement("OPTION");
        option1.value = cols[0];
        option1.text  = cols[1];
        document.getElementById(cont[0]+"cmb_firm").add(option1);
    }    
}

function combochange()
{
    document.getElementById(cont[0]+"Hidden2").value=document.getElementById(cont[0]+"cmb_firm").value;
   
}

function date(a)
{
  alert('Please select date from Calendar!!');
  document.getElementById(cont[0]+a).value="";
  document.getElementById(cont[0]+a).focus();
  return false;
}

function showrow()
{
     document.getElementById(cont[0]+"Hidden3").balue=document.getElementById(cont[0]+'cmb_report').value;
    if (document.getElementById(cont[0]+'cmb_report').value==1)  
    {
        document.getElementById("row1").style.display="inline";
        document.getElementById("row2").style.display="none"; 
        document.getElementById("row3").style.display="inline";

    }
    else if (document.getElementById(cont[0]+'cmb_report').value==3)  
    {
        document.getElementById("row2").style.display="inline";
        document.getElementById("row1").style.display="none"; 
        document.getElementById("row3").style.display="inline";

    }
    else
    {
       document.getElementById("row1").style.display="none"; 
       document.getElementById("row2").style.display="none"; 
       document.getElementById("row3").style.display="none";

    }
}

// ]]>
</script>

    <div style="text-align: center">
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <table border="1" style="width: 485px">
            <tr>
                <td style="width: 256px; text-align: left">
                    Select Report Type:
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="cmb_report" runat="server" Width="202px" onchange="return showrow()">
                        <asp:ListItem Value="1">Appointed</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 256px; text-align: left">
                    Select Employee Type :
                </td>
                <td style="width: 100px; text-align: left;"><asp:DropDownList ID="cmb_type" runat="server" Width="202px">
                    <asp:ListItem Value="3">All</asp:ListItem>
                    <asp:ListItem Value="2">Outsource</asp:ListItem>
                    <asp:ListItem Value="1">Regular</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            <tr  id="row1" >
                <td style="width: 256px; text-align: left">
                    Select Joining Type :
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="cmb_joining" runat="server" Width="202px">
                        <asp:ListItem Value="1">All</asp:ListItem>
                        <asp:ListItem Value="2">Newly Joined</asp:ListItem>
                        <asp:ListItem Value="3">Regularised</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr id="row2"  style="display:none">
                <td style="width: 256px; text-align: left">
                    Report&nbsp;With&nbsp;Enter&nbsp;dt/&nbsp;Disontinue&nbsp;Date :
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="cmb_disdt" runat="server" Width="202px">
                        <asp:ListItem Value="2">Enter Date</asp:ListItem>
                        <asp:ListItem Value="1">Discontinue Date</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2">
                    <table>
                        <tr>
                            <td colspan="2">
                                <input id="rdb_all" name="g" type="radio"  onclick="return rdbcheck()" checked="CHECKED" />All &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                            <td colspan="2">
                                <input id="rdb_firm" name="g" type="radio"  onclick="return rdbcheck()" />Firm wise &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                            <td colspan="2" style="width: 124px">
                    <input id="rdb_department" name="g" type="radio" onclick="return rdbcheck()" />Designtaion&nbsp;wise&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 256px">
                    </td>
                <td style="width: 100px">
                    </td>
            </tr>
            <tr id="row3" style="display:none">
                <td style="width: 256px; height: 23px; text-align: left">
                    Select Firm / Designation :
                </td>
                <td style="width: 100px; height: 23px; text-align: left">
                    <asp:DropDownList ID="cmb_firm" runat="server" Width="278px" onchange="return combochange()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 256px; text-align: left">
                    From Date :
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="txt_fromdt" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 256px; text-align: left">
                    To Date :
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="txt_todt" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 256px; text-align: right;">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                <td style="width: 100px; text-align: left;">
                    &nbsp;
                    <input id="cmd_exit" style="width: 78px" type="button" value="EXIT" onclick="return cmd_exit_onclick()" /></td>
            </tr>
        </table>
    </div>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_fromdt">
                    </cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                        TargetControlID="txt_todt">
                    </cc1:CalendarExtender>
    <input id="Hidden1" type="hidden" runat="server" />
    <input id="Hidden2" runat="server" type="hidden" />
    <input id="Hidden3" runat="server" type="hidden" />
</asp:Content>


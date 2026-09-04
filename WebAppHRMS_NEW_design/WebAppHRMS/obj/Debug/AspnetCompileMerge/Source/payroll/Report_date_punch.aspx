<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Report_date_punch.aspx.vb" Inherits="WebAppHRMS.november_Report_Report_date_punch_ad250a3c2696" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[



var cs = cont_name.split("Txt");

function alle()
{
if (document.getElementById(cs[0]+"Chk_All").checked==true) 
{
document.getElementById(cs[0]+"Chk_Bh").checked=false;
document.getElementById(cs[0]+"Chk_Abh").checked=false;


}
}
function bhe()
{
if (document.getElementById(cs[0]+"Chk_Bh").checked==true) 
{
document.getElementById(cs[0]+"Chk_All").checked=false;
document.getElementById(cs[0]+"Chk_Abh").checked=false;

}
}
function abhe()
{
if (document.getElementById(cs[0]+"Chk_Abh").checked==true) 
{                                                                                          
document.getElementById(cs[0]+"Chk_Bh").checked=false;
document.getElementById(cs[0]+"Chk_All").checked=false;

}
}
function clr(b)
{
 alert("please select date from calender");
 document.getElementById(cs[0]+b).value="";
 return false;
}


function Cmd_exit_onclick() {
window.open('../home.aspx','_self');
}

// ]]>
</script>

    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4">
                    NOT PUNCH IN REPORTING DATE<asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy"
                        targetcontrolid="Txt_fdt"></cc1:calendarextender>
                    <cc1:calendarextender id="CalendarExtender2" runat="server" format="dd/MMM/yyyy"
                        targetcontrolid="Txt_tdt"></cc1:calendarextender>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div style="text-align: center">
                        <table style="width: 416px">
                            <tr>
                                <td style="width: 100px">
                                    <asp:CheckBox ID="Chk_All" onclick="alle()" runat="server" Text="ALL" /></td>
                                <td style="width: 100px">
                                    <asp:CheckBox ID="Chk_Bh" onclick="bhe()" runat="server" Text="BH" /></td>
                                <td style="width: 100px">
                                    <asp:CheckBox ID="Chk_Abh" onclick="abhe()" runat="server" Text="ABH" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 23px">
                    FROM DATE</td>
                <td style="width: 100px; height: 23px; text-align: left">
                    <asp:TextBox ID="Txt_fdt" onkeyPress="return clr('Txt_fdt')" runat="server"></asp:TextBox></td>
                <td style="width: 100px; height: 23px">
                    TO DATE</td>
                <td style="width: 100px; height: 23px; text-align: left">
                    <asp:TextBox ID="Txt_tdt" onkeyPress="return clr('Txt_tdt')" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <table>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                                <asp:Button ID="Cmd_confirm" runat="server" Text="CONFIRM" /></td>
                            <td style="width: 100px">
                                <input id="Cmd_exit" style="width: 101px" type="button" value="EXIT" onclick="return Cmd_exit_onclick()" /></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


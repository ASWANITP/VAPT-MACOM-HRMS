<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Earlygoing_enquiry.aspx.vb" Inherits="WebAppHRMS.Lima_Leave_leave_enquiry_5f2a6a2c6074" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">

<script language="javascript" type="text/javascript">
// <!CDATA[
var cont=loanno.split("txt");

function datafill()
{
    document.getElementById(cont[0]+"txt_fromdt").value='';
    document.getElementById(cont[0]+"txt_todt").value='';
    document.getElementById(cont[0]+"txt_type").value='';
    //document.getElementById(cont[0]+"txt_reason").value='';
    document.getElementById(cont[0]+"txt_result").value='';
    
    document.getElementById(cont[0]+"hid_leaveseq").value=document.getElementById(cont[0]+"cmb_leave").value;
    if (document.getElementById(cont[0]+"hid_leaveseq").value!=0)
    {
     var x=document.getElementById(cont[0]+"cmb_leave")
    disp(x.options[x.selectedIndex].text)
    }    
}
function disp(arg)
{
    var lima=arg.split("-")
    document.getElementById(cont[0]+"txt_fromdt").value=lima[0];
    document.getElementById(cont[0]+"txt_todt").value=lima[1];
    document.getElementById(cont[0]+"txt_type").value=lima[2];
   // document.getElementById(cont[0]+"txt_reason").value=lima[3];
}

function checkbeforeconfirm()
{
     if (document.getElementById(cont[0]+"hid_leaveseq").value!=0)
    {
       document.getElementById("row1").style.display="inline";
    }   
    else
    {
        document.getElementById("row1").style.display="none";
    } 
}
function cmd_Exit_onclick() 
{
    window.open('../home.aspx','_self');
}

// ]]>
</script>

    <br />
    <div style="text-align: center">
        <table border="1">
            <tr>
                <td style="width: 123px; text-align: left">
                    Select Earlygoing :
                </td>
                <td style="width: 100px; text-align: left">
                    <asp:DropDownList ID="cmb_leave" runat="server" onchange="return datafill()" Width="530px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 123px; text-align: left">
                    Employee Code&nbsp; :</td>
                <td style="width: 100px; text-align: left">
                    <input id="txt_fromdt" runat="server" type="text" /></td>
            </tr>
            <tr>
                <td style="width: 123px; text-align: left">
                    Earlygoing Date :
                </td>
                <td style="width: 100px; text-align: left">
                    <input id="txt_todt" runat="server" type="text" /></td>
            </tr>
            <tr>
                <td style="width: 123px; text-align: left">
                    Earlygoing Reason :
                </td>
                <td style="width: 100px; text-align: left">
                    <input id="txt_type" runat="server" type="text" /></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 1px; text-align: center">
                    <div style="text-align: center">
                        <br />
                        <table>
                            <tr>
                                <td style="width: 100px; text-align: right">
                                    <asp:Button ID="txt_confirm" runat="server" Text="Confirm" Font-Bold="True" Height="27px" Width="88px" /></td>
                                <td style="width: 100px; text-align: left">
                                    <input id="cmd_Exit" style="width: 68px; font-weight: bold; height: 27px;" type="button" value="Exit" onclick="return cmd_Exit_onclick()" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr >
                <td colspan="2" style="height: 23px">
                    <div style="text-align: center">
                        <asp:TextBox ID="txt_result" runat="server" Height="66px" ReadOnly="True" Style="font-weight: bold;
                            font-size: 13pt; vertical-align: middle; color: #ff0066; background-color: #ffeaff;
                            text-align: center; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none;" Width="649px"></asp:TextBox>&nbsp;</div>
                </td>
            </tr>
        </table>
        <br />
        <input id="hid_leaveseq" type="hidden" runat="server" /><br />
    </div>
</asp:Content>


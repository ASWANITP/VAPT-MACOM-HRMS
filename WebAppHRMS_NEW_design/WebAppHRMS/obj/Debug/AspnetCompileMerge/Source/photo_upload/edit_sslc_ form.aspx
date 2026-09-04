<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="edit_sslc_ form.aspx.vb" Inherits="WebAppHRMS.vipin_forms_edit_sslc_form_5e6904ba1486" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
var con=header.split('txt');
function DateFCheck()
{
   alert('Please Select date Using Calendar..!!');
   document.getElementById(con[0]+"txtDate").value ="";
   return false;
}


function OnConfClick()
{
   
    if(document.getElementById(con[0]+"txtsslc").value=="")
    {
        alert("Please type Correct SSLC Number..!");
        document.getElementById(con[0]+"txtsslc").focus();
        return false;
    }
    if(document.getElementById(con[0]+"txtDate").value=="")
    {
        alert("Please Select Birth Date...!");
        document.getElementById(con[0]+"txtDate").focus();
        return false;
    }
} 
</script>

    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                <div style="text-align: center">
                    <div style="text-align: center">
                        <table border="1">
                            <caption>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                                
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate">
                                </cc1:CalendarExtender>
                            </caption>
                            <tr>
                                <td style="width: 175px; height: 23px">
                                    Select Employee</td>
                                <td style="width: 100px; height: 23px">
                                </td>
                                <td style="width: 109px; height: 23px">
                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="252px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Panel ID="Panel1" runat="server">
                                        <div style="text-align: center">
                                            <table border="1" style="width: 412px">
                                                <caption>
                                                    SSLC NUMBER AND DATE OF BIRTH</caption>
                                                <tr>
                                                    <td style="width: 100px">
                                                        SSLC NUMBER</td>
                                                    <td colspan="2">
                                                        DATE OF BIRTH</td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; height: 28px;">
                                                        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox></td>
                                                    <td colspan="2" style="height: 28px">
                                                        <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" Width="181px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 175px">
                                    Enter sslc number</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtsslc" runat="server" Width="181px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 175px; height: 28px">
                                    Select Date of Birth</td>
                                <td colspan="2" style="height: 28px">
                                    <asp:TextBox ID="txtDate" runat="server" Width="179px" onkeyup="DateFCheck()" ></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 175px">
                                </td>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 109px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 175px; height: 15px">
                                    <asp:Button ID="Button1" runat="server" Text="Confirm" Width="99px" OnClientClick="return OnConfClick()" /></td>
                                <td style="width: 100px; height: 15px">
                                </td>
                                <td style="width: 109px; height: 15px">
                                    <asp:Button ID="Button2" runat="server" Text="Exit" Width="97px" /></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


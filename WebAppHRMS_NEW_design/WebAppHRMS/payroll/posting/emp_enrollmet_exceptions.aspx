<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="emp_enrollmet_exceptions.aspx.vb" Inherits="WebAppHRMS.payroll_posting_emp_enrollmet_exceptions_9cbf8cdb7483" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
    // <!CDATA[

var cont=loanno.split("txt")

function cmd_exit_onclick() 
{
    window.open('../../home.aspx','_self');
}

function datafill()
{
    document.getElementById(cont[0]+"hid1").value=document.getElementById(cont[0]+"cmb_appno").value;
    call_server("1$" + document.getElementById(cont[0]+"hid1").value,1);
}

function call_receiver(arg)
{
    var ap;
    ap=arg.split("#")
    document.getElementById(cont[0]+"txt_name").value=ap[0];
    document.getElementById(cont[0]+"txdt_address").value=ap[1];
    document.getElementById(cont[0]+"txt_dob").value=sp[2];
    document.getElementById(cont[0]+"txt_sslc").value=sp[3];
    if( sp[4]==2)
    {
        document.getElementById(cont[0]+"txt_rejoining").value='YES';
    }
    else
    {
        document.getElementById(cont[0]+"txt_rejoining").value='NO';
    }
    document.getElementById(cont[0]+"txt_post").value=sp[5];
}

// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 640px">
            <tr>
                <td style="width: 166px; height: 36px;">
                    Select Application No :
                </td>
                <td style="width: 100px; text-align: left; height: 36px;">
                    <asp:DropDownList ID="cmb_appno" runat="server" Width="476px" onchange="return datafill()">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 166px; text-align: left;">
                    Name :
                </td>
                <td style="width: 100px; text-align: left;">
                    <input id="txt_name" runat="server" readonly="readonly" style="width: 467px" type="text" /></td>
            </tr>
            <tr>
                <td style="width: 166px; text-align: left;">
                    Permanant address:</td>
                <td style="width: 100px; text-align: left;">
                    <input id="txt_address" runat="server" readonly="readonly" style="width: 467px; height: 19px"
                        type="text" /></td>
            </tr>
            <tr>
                <td style="width: 166px; text-align: left;">
                    Date Of Birth :
                </td>
                <td style="width: 100px; text-align: left;">
                    <input id="txt_dob" runat="server" readonly="readonly" type="text" /></td>
            </tr>
            <tr>
                <td style="width: 166px; text-align: left; height: 20px;">
                    Age :
                </td>
                <td style="width: 100px; height: 20px; text-align: left;">
                    <input id="txt_age" runat="server" readonly="readonly" type="text" /></td>
            </tr>
            <tr>
                <td style="width: 166px; text-align: left;">
                    SSLC No :
                </td>
                <td style="width: 100px; text-align: left;">
                    <input id="txt_sslc" runat="server" readonly="readonly" style="width: 251px" type="text" /></td>
            </tr>
            <tr>
                <td style="width: 166px; height: 17px; text-align: left">
                    Rejoining :
                </td>
                <td style="width: 100px; height: 17px; text-align: left;">
                    <input id="txt_rejoining" runat="server" readonly="readonly" type="text" /></td>
            </tr>
            <tr>
                <td style="width: 166px; height: 17px; text-align: left;">
                    Post Offered :
                </td>
                <td style="width: 100px; height: 17px; text-align: left;">
                    <input id="txt_post" runat="server" readonly="readonly" style="width: 467px" type="text" /></td>
            </tr>
            <tr>
                <td style="width: 166px; text-align: right;">
                    <asp:Button ID="cmd_confirm" runat="server" Text="Confirm" /></td>
                <td style="width: 100px; text-align: left;">
                    <input id="cmd_exit" style="width: 74px" type="button" value="Exit" onclick="return cmd_exit_onclick()" /></td>
            </tr>
        </table>
    </div>
    <input id="hid1" type="hidden" runat="server" />
</asp:Content>


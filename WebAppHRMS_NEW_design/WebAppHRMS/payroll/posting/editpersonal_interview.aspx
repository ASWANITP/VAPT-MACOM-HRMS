<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="editpersonal_interview.aspx.vb" Inherits="WebAppHRMS.edit_interview_details_editpersonal_interview_38847f0f8765" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
var cont_name=header.split("txt")

// <!CDATA[

function cmd_exit_onclick() {
window.open('../../home.aspx','_self');
}

function upperconverter1()
{
    document.getElementById(cont_name[0]+"txt_house1").value=document.getElementById(cont_name[0]+"txt_house1").value.toUpperCase();
  }
   function upperconverter2()
{
    document.getElementById(cont_name[0]+"txt_house2").value=document.getElementById(cont_name[0]+"txt_house2").value.toUpperCase();
}
function upperconverter3()
{
    document.getElementById(cont_name[0]+"txt_lmark").value=document.getElementById(cont_name[0]+"txt_lmark").value.toUpperCase();
}
function upperconverter4()
{
    document.getElementById(cont_name[0]+"txt_idno").value=document.getElementById(cont_name[0]+"txt_idno").value.toUpperCase();

}
  

// ]]>
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 937px; height: 235px" border="1">
                <tbody>
                    <tr>
                        <td style="height: 26px; text-align: right" colspan="2"><span style="font-size: 13pt">Select Application No :</span> </td>
                        <td style="height: 26px; text-align: left" colspan="2">
                            <asp:DropDownList ID="cmb_appno" runat="server" Width="366px" __designer:wfdid="w6" AutoPostBack="True"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 186px; height: 28px; text-align: left">Name :</td>
                        <td style="height: 28px; text-align: left" colspan="3">
                            <asp:TextBox ID="txt_name" runat="server" Width="374px" BackColor="Ivory" ForeColor="Red" Font-Bold="True" __designer:wfdid="w7" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 186px; height: 216px; text-align: left">Address : </td>
                        <td style="height: 216px; text-align: left" colspan="3">
                            <div style="text-align: left">
                                <div style="text-align: left">&nbsp;</div>
                            </div>
                            <div style="text-align: left">
                                <div style="text-align: left">
                                    <table style="width: 764px; height: 143px" border="1">
                                        <tbody>
                                            <tr>
                                                <td style="height: 23px; text-align: center" colspan="2">Permanant</td>
                                                <td style="height: 23px; text-align: center" colspan="2">Present</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 96px; height: 28px">House Name : </td>
                                                <td style="width: 102px; height: 28px">
                                                    <asp:TextBox ID="txt_house1" runat="server" Width="264px" __designer:wfdid="w8" AutoPostBack="True"></asp:TextBox></td>
                                                <td style="width: 88px; height: 28px">House Name : </td>
                                                <td style="width: 100px; height: 28px">
                                                    <asp:TextBox ID="txt_house2" runat="server" Width="252px" __designer:wfdid="w9" AutoPostBack="True"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 96px">State : </td>
                                                <td style="width: 102px">
                                                    <asp:DropDownList ID="cmb_state1" runat="server" Width="210px" __designer:wfdid="w10" AutoPostBack="True">
                                                    </asp:DropDownList></td>
                                                <td style="width: 88px">State : </td>
                                                <td style="width: 100px">
                                                    <asp:DropDownList ID="cmb_state2" runat="server" Width="210px" __designer:wfdid="w11" AutoPostBack="True">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 96px; height: 26px">District :</td>
                                                <td style="width: 102px; height: 26px">
                                                    <asp:DropDownList ID="cmb_district1" runat="server" Width="210px" __designer:wfdid="w12" AutoPostBack="True">
                                                    </asp:DropDownList></td>
                                                <td style="width: 88px; height: 26px">District :</td>
                                                <td style="width: 100px; height: 26px">
                                                    <asp:DropDownList ID="cmb_district2" runat="server" Width="210px" __designer:wfdid="w13" AutoPostBack="True">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 96px">Post : </td>
                                                <td style="width: 102px">
                                                    <asp:DropDownList ID="cmb_post1" runat="server" Width="210px" __designer:wfdid="w14" AutoPostBack="True">
                                                    </asp:DropDownList></td>
                                                <td style="width: 88px">Post : </td>
                                                <td style="width: 100px">
                                                    <asp:DropDownList ID="cmb_post2" runat="server" Width="210px" __designer:wfdid="w15" AutoPostBack="True">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 96px; height: 28px">PIN : </td>
                                                <td style="width: 102px; height: 28px">
                                                    <asp:TextBox ID="txt_pin1" runat="server" Width="202px" __designer:wfdid="w16" ReadOnly="True"></asp:TextBox></td>
                                                <td style="width: 88px; height: 28px">PIN : </td>
                                                <td style="width: 100px; height: 28px">
                                                    <asp:TextBox ID="txt_pin2" runat="server" Width="202px" __designer:wfdid="w17" ReadOnly="True"></asp:TextBox></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <asp:CheckBox ID="chk_same" runat="server" Width="405px" Text="Present Address Same As Permanant Address" Font-Bold="True" __designer:wfdid="w18" AutoPostBack="True"></asp:CheckBox></td>
                    </tr>
                    <tr>
                        <td style="width: 186px; text-align: left">Land Mark :</td>
                        <td style="text-align: left" colspan="3">
                            <asp:TextBox ID="txt_lmark" runat="server" Width="756px" __designer:wfdid="w19" AutoPostBack="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 186px; height: 13px; text-align: left">Phone No. (Residence) : </td>
                        <td style="width: 392px; height: 13px; text-align: left">
                            <table border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 48px">
                                            <asp:CheckBox ID="Chk_pp" runat="server" Width="50px" Text=" PP" __designer:wfdid="w20"></asp:CheckBox></td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="txt_phone" runat="server" Width="155px" __designer:wfdid="w21"></asp:TextBox></td>
                                    </tr>
                                </tbody>
                            </table>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" __designer:wfdid="w22" ControlToValidate="txt_phone" EnableTheming="True" ErrorMessage="Please Enter Correctly" ValidationExpression='^([0-9"-"\s])*$'></asp:RegularExpressionValidator></td>
                        <td style="width: 56px; height: 13px; text-align: left">Contact No :&nbsp;&nbsp;</td>
                        <td style="width: 100px; height: 13px; text-align: left">
                            <asp:TextBox ID="txt_contact" runat="server" __designer:wfdid="w23"></asp:TextBox><br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Width="155px" __designer:wfdid="w24" ControlToValidate="txt_contact" ErrorMessage="Please Enter Correctly" ValidationExpression='^([0-9"-"\s])*$'></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 186px; height: 23px; text-align: left">Email :<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" __designer:wfdid="w25" ControlToValidate="txt_email" ErrorMessage="Please Enter Correctly" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                        <td style="width: 392px; height: 23px; text-align: left">
                            <asp:TextBox ID="txt_email" runat="server" Width="211px" __designer:wfdid="w26"></asp:TextBox><span style="font-size: 1pt">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></td>
                        <td style="width: 56px; height: 23px; text-align: left">Blood Group :</td>
                        <td style="width: 100px; height: 23px; text-align: left">
                            <asp:DropDownList ID="cmb_bg" runat="server" Width="154px" __designer:wfdid="w27" AutoPostBack="True"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="width: 186px; text-align: left">ID Proof :</td>
                        <td style="width: 392px; text-align: left">
                            <asp:DropDownList ID="cmb_idproof" runat="server" Width="218px" __designer:wfdid="w28" AutoPostBack="True"></asp:DropDownList></td>
                        <td style="width: 56px; text-align: left">ID No : </td>
                        <td style="width: 100px; text-align: left">
                            <asp:TextBox ID="txt_idno" runat="server" __designer:wfdid="w29"></asp:TextBox></td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <div style="text-align: center">
        &nbsp;&nbsp;<asp:Button ID="cmd_confirm" runat="server" Text="EDIT"
            Width="82px" Style="cursor: hand" />&nbsp;
          <input id="cmd_exit" onclick="return cmd_exit_onclick()" style="width: 78px; cursor: hand;" type="button"
              value="EXIT" /><br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    <div style="text-align: center">
        &nbsp;<br />
        <br />
        <br />
        <br />
        &nbsp;
    </div>
</asp:Content>


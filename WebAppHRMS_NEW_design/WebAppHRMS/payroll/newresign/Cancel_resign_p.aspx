<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/edp.master" CodeBehind="Cancel_resign_p.aspx.vb" Inherits="WebAppHRMS.MANJEWEL_RESIG_CAN_Cancel_resign_p_0a80d2df2578" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
// <!CDATA[

function Button2_onclick() {
window.open('../../home.aspx','_self');
}
function van() 
{
alert ("Please select date from calendar! ")
  return false;
}
// ]]>
    </script>

    &nbsp;<div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4">
                    <strong>CANCEL RESIGNATION<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    </strong>&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">--%>
                    <contenttemplate>
                        <table border="1">
                            <tbody>
                                <tr>
                                    <td style="width: 2773px; text-align: left"><strong>Select&nbsp;Employee</strong></td>
                                    <td style="text-align: left" colspan="3">
                                        <asp:DropDownList ID="cmb_emp" runat="server" Width="582px" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left" colspan="2"><strong>Employee&nbsp;Code :</strong>
                                        <asp:Label ID="lbl_code" runat="server" Width="148px" Text="No Empoyee" ForeColor="Navy"></asp:Label></td>
                                    <td style="width: 392px; text-align: left" colspan="2"><strong>Employee&nbsp;Name :</strong>&nbsp;
                                        <asp:Label ID="lbl_name" runat="server" Width="226px" Text="No Employee" ForeColor="Navy"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 2773px; text-align: left"><strong>Resigning&nbsp;Date</strong></td>
                                    <td style="width: 106px">
                                        <asp:TextBox ID="Txt_rsdt" runat="server" ReadOnly="True"></asp:TextBox></td>
                                    <td style="width: 292px" colspan="2"><strong>Applied&nbsp;Date :</strong>&nbsp;
                                        <asp:Label ID="Labelapp" runat="server" Width="226px" Text="--" ForeColor="Navy"></asp:Label>
                                    </td>
                                    <td style="width: 392px" colspan="2">&nbsp;&nbsp; </td>
                                </tr>
                                <tr>
                                    <td style="width: 2773px; text-align: left"><strong>Reason&nbsp;for&nbsp;Resigning</strong></td>
                                    <td style="text-align: left" colspan="3">
                                        <asp:TextBox ID="Txt_rea" runat="server" Width="571px" ForeColor="Navy" Height="22px" ReadOnly="True" TextMode="singleLine"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 2773px; height: 23px; text-align: left"><strong>Relieving&nbsp;Date</strong></td>
                                    <td style="width: 106px; height: 23px">
                                        <asp:TextBox ID="Txt_rdt" onkeypress="return van()" runat="server" ReadOnly="True"></asp:TextBox></td>
                                    <td style="width: 392px; height: 23px" colspan="2">
                                        <cc1:CalendarExtender TargetControlID="txt_rdt" runat="server" ID="datetime"></cc1:CalendarExtender>
                                        &nbsp; </td>
                                </tr>
                            </tbody>
                        </table>
                        <%--<cc1:ListSearchExtender id="ListSearchExtender1" runat="server" TargetControlID="cmb_emp">
                    </cc1:ListSearchExtender>--%>&nbsp; &nbsp;
                    </contenttemplate>
                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                    <%--</asp:UpdatePanel>--%></td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td style="width: 160px">&nbsp;
                </td>
                <td style="width: 79px; text-align: center;">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                <td style="width: 122px">
                    <input id="Button2" type="button" value="EXIT" onclick="return Button2_onclick()" style="width: 88px" /></td>
                <td style="width: 128px">&nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


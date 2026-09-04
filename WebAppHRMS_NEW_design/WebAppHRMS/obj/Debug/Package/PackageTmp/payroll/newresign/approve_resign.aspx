<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="approve_resign.aspx.vb" Inherits="WebAppHRMS.new_approve_resign_3ee36c041115" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function Button2_onclick() {
            window.open('../home.aspx', '_self');
        }
        function van() {
            alert("Please select date from calendar! ")
            return false;
        }
        // ]]>
    </script>

    <div style="text-align: center">
        `<table border="1">
            <tr>
                <td colspan="4">
                    <strong>APPROVE RESIGNATION<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    </strong>&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table border="1">
                                <tbody>
                                    <tr>
                                        <td style="width: 2773px; text-align: left"><strong>Select&nbsp;Employee</strong></td>
                                        <td style="text-align: left" colspan="3">
                                            <asp:DropDownList ID="cmb_emp" runat="server" Width="582px" AutoPostBack="True">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 32px; text-align: left" colspan="4">
                                            <table border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="height: 23px; text-align: left" colspan="2"><strong>Employee&nbsp;Code :</strong>
                                                            <asp:Label ID="lbl_code" runat="server" Width="148px" Text="No Empoyee" ForeColor="Navy" __designer:wfdid="w1"></asp:Label></td>
                                                        <td style="width: 392px; height: 23px; text-align: left" colspan="2"><strong>Employee&nbsp;Name :</strong>&nbsp;
                                                            <asp:Label ID="lbl_name" runat="server" Width="274px" Text="No Employee" ForeColor="Navy" __designer:wfdid="w2"></asp:Label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            &nbsp;&nbsp; </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 2773px; text-align: left"><strong>Resigning&nbsp;Date</strong></td>
                                        <td style="text-align: left" colspan="3">
                                            <asp:TextBox ID="Txt_rsdt" runat="server" __designer:wfdid="w3" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 2773px; text-align: left"><strong>Reason&nbsp;for&nbsp;Resigning</strong></td>
                                        <td style="text-align: left" colspan="3">
                                            <asp:TextBox ID="Txt_rea" runat="server" Width="571px" ForeColor="MediumBlue" Height="58px" ReadOnly="True" MaxLength="150" TextMode="singleLine"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 2773px; height: 23px; text-align: left"><strong>Select&nbsp;Relieving&nbsp;Date</strong></td>
                                        <td style="height: 23px; text-align: left" colspan="3">
                                            <asp:TextBox ID="Txt_rdt" onkeypress="return van()" runat="server" AutoPostBack="True" __designer:wfdid="w4"></asp:TextBox>
                                            <asp:Label ID="lbl1" runat="server" Width="580px" __designer:wfdid="w1"></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" __designer:dtid="844424930131976" __designer:wfdid="w8" Format="dd/MMM/yyyy" TargetControlID="Txt_rdt"></cc1:CalendarExtender>
                            &nbsp;&nbsp;&nbsp; 
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 23px">
                    <table border="0">
                        <tr>
                            <td style="width: 160px">&nbsp;&nbsp;
                    <input id="cmd_att" runat="server" type="button" value="View Attachment" /></td>
                            <td style="width: 79px; text-align: center;">
                                <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                            <td style="width: 122px; text-align: center;">
                                <input id="Button2" type="button" value="EXIT" onclick="return Button2_onclick()" style="width: 88px" /></td>
                            <td style="width: 128px">&nbsp;
                            </td>
                        </tr>
                    </table>
                    &nbsp; &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


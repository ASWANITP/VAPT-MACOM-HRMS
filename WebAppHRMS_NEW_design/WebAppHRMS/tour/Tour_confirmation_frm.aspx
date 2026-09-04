<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Tour_confirmation_frm.aspx.vb" Inherits="WebAppHRMS.TOUR_Tour_confirmation_frm_15d3fa521629" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script type="text/javascript">


        function exit() {
            //alert("Closing");
            window.open('../home.aspx', '_self');

        }

    </script>

    &nbsp;<br />
    <div style="text-align: center">
        &nbsp;<table border="1">
            <tr>
                <td>
                    <asp:Label ID="lbl_head" runat="server" Font-Bold="True" Text="TOUR CONFIRMATION AND CANCELLATION FORM"
                        Width="450px" BackColor="#FF8080"></asp:Label>
                    &nbsp; &nbsp; 
                    <br />
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table width="750" border="1">
                                <tbody>
                                    <tr>
                                        <td style="width: 100px; height: 9px; text-align: left">Slect&nbsp;Employee</td>
                                        <td style="height: 9px; text-align: left" colspan="3">
                                            <asp:DropDownList ID="cmb_ecode" runat="server" Width="600px" BackColor="OldLace" OnSelectedIndexChanged="cmb_ecode_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w4">
                                            </asp:DropDownList>
                                            <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" __designer:wfdid="w56" PromptText TargetControlID="cmb_ecode"></cc1:ListSearchExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 47px; text-align: left">Employee&nbsp;Name</td>
                                        <td style="width: 100px; height: 47px; text-align: left">
                                            <asp:TextBox ID="txt_name" runat="server" Width="227px" BackColor="OldLace" __designer:wfdid="w5" ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 100px; height: 47px; text-align: left">Duration</td>
                                        <td style="width: 100px; height: 47px; text-align: left">&nbsp;<asp:TextBox ID="txt_duration" runat="server" Width="225px" BackColor="OldLace" __designer:wfdid="w6" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 23px; text-align: left">Apply&nbsp;date</td>
                                        <td style="width: 100px; height: 23px; text-align: left">
                                            <asp:TextBox ID="txt_applydate" runat="server" Width="227px" BackColor="OldLace" __designer:wfdid="w7" ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 100px; height: 23px; text-align: left">Designation</td>
                                        <td style="width: 100px; height: 23px; text-align: left">
                                            <asp:TextBox ID="txt_designation" runat="server" Width="227px" BackColor="OldLace" __designer:wfdid="w8" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 23px; text-align: left">Tour&nbsp;Place</td>
                                        <td style="width: 100px; height: 23px; text-align: left">
                                            <asp:TextBox ID="txt_place" runat="server" Width="227px" BackColor="OldLace" __designer:wfdid="w9" ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 100px; height: 23px; text-align: left">Tour&nbsp;Purpose</td>
                                        <td style="width: 100px; height: 23px; text-align: left">
                                            <asp:TextBox ID="txt_purpose" runat="server" Width="227px" BackColor="OldLace" __designer:wfdid="w10" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left" colspan="2">Recommended&nbsp;By</td>
                                        <td style="text-align: center" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="txt_recomended" runat="server" Width="229px" BackColor="OldLace" __designer:wfdid="w11"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 22px" colspan="4">
                                            <asp:Label ID="lbl_message" runat="server" Width="728px" ForeColor="Red" Font-Size="Large" Height="16px" __designer:wfdid="w12"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 57px" colspan="4">
                                            <table style="width: 100%" border="1">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <asp:Button ID="cmd_confirm" OnClick="cmd_confirm_Click" runat="server" Width="119px" Text="CONFIRM" Font-Bold="True" __designer:wfdid="w13"></asp:Button></td>
                                                        <td style="width: 100px"></td>
                                                        <td colspan="2">
                                                            <asp:Button ID="cmd_Exit" OnClick="cmd_Exit_Click" runat="server" Width="169px" Text="EXIT" Font-Bold="True" __designer:wfdid="w14"></asp:Button></td>
                                                        <td style="width: 100px"></td>
                                                        <td style="width: 84px">
                                                            <asp:Button ID="Cmd_cancel" OnClick="Cmd_cancel_Click" runat="server" Width="165px" Text="CANCEL" Font-Bold="True" __designer:wfdid="w15"></asp:Button></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <input id="hidd_ecode" runat="server" type="hidden" /></td>
            </tr>
            <tr>
                <td style="height: 99px">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Timer ID="Timer1" runat="server" __designer:wfdid="w71" Interval="1000"></asp:Timer>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    </div>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;
    <br />
    <br />
    <div style="text-align: center">
        <div style="text-align: center">
            &nbsp;
        </div>
    </div>
    <br />
    &nbsp;&nbsp;<br />
    &nbsp; &nbsp;
    <br />
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Leave_Cancel.aspx.vb" Inherits="WebAppHRMS.Deepak_Leave_Cancel_70db02a15227" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="text-align: center">
        <table border="0">
            <tr>
                <td style="width: 100px">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table border="1">
                                <tbody>
                                    <tr>
                                        <td style="text-align: center" colspan="4"><strong><span style="color: darkblue; text-decoration: underline">LEAVE&nbsp; CANCELATION</span></strong></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center" colspan="4">
                                            <asp:Label Style="position: static" ID="lbl_message" runat="server" Width="806px" ForeColor="Red" Font-Bold="True" Height="27px" Font-Italic="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 151px; text-align: left"><span style="color: darkblue">EmployeeCode</span></td>
                                        <td style="width: 128px">
                                            <asp:TextBox ID="txt_ecode" runat="server" Width="152px" BackColor="OldLace" AutoPostBack="True" OnTextChanged="txt_ecode_TextChanged" ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 154px; text-align: left"><span style="color: darkblue">Name</span></td>
                                        <td style="width: 105px">
                                            <asp:TextBox ID="txt_name" runat="server" Width="352px" BackColor="OldLace" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 151px; text-align: left"><span style="color: darkblue">Leave Type</span></td>
                                        <td style="width: 128px">
                                            <asp:TextBox ID="txt_leavetype" runat="server" BackColor="OldLace" ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 154px; text-align: left"><span style="color: darkblue">Leave ApplyDate</span></td>
                                        <td style="width: 105px">
                                            <asp:TextBox ID="txt_applydate" runat="server" BackColor="OldLace" ReadOnly="True"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 151px; text-align: left"><span style="color: darkblue">Leave From</span></td>
                                        <td style="width: 128px">
                                            <asp:TextBox ID="txt_leavefrom" runat="server" BackColor="OldLace" ReadOnly="True"></asp:TextBox></td>
                                        <td style="width: 154px; text-align: left"><span style="color: darkblue">Leave To</span></td>
                                        <td style="width: 105px; text-align: left">
                                            <asp:TextBox ID="txt_leaveto" runat="server" BackColor="OldLace" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 151px; height: 3px; text-align: left"><span style="color: darkblue">Reason&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                        <td style="height: 3px; text-align: left" colspan="3">
                                            <table style="position: static" border="1">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 100px; height: 12px">
                                                            <asp:TextBox Style="position: static" ID="txt_reason" runat="server" Width="280px" BackColor="OldLace" ReadOnly="True" __designer:wfdid="w3"></asp:TextBox></td>
                                                        <td style="width: 107px; height: 12px"><span style="color: darkblue">No of Days</span></td>
                                                        <td style="width: 100px; height: 12px">
                                                            <asp:TextBox Style="position: static" ID="txt_nofdays" runat="server" Width="40px" BackColor="OldLace" ForeColor="Black" ReadOnly="True" __designer:wfdid="w5"></asp:TextBox></td>
                                                        <td style="width: 100px; height: 12px">
                                                            <asp:Button Style="position: static" ID="cmd_back" OnClick="cmd_back_Click" runat="server" Width="76px" Text=" <<" ForeColor="DarkBlue" Font-Bold="True" Height="24px" __designer:wfdid="w10"></asp:Button></td>
                                                        <td style="width: 100px; height: 12px">
                                                            <asp:Button Style="position: static" ID="cmd_next" OnClick="cmd_next_Click" runat="server" Width="76px" Text=" >>" ForeColor="DarkBlue" Font-Bold="True" __designer:wfdid="w6"></asp:Button></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left" colspan="4">
                                            <asp:TextBox Style="position: static" ID="txt_hid" runat="server" Width="39px" __designer:wfdid="w7" Visible="False">0</asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button Style="position: static" ID="Button3" OnClick="Button3_Click" runat="server" Text="CLICK TO CANCEL" ForeColor="DarkBlue" Font-Bold="True" __designer:wfdid="w8"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button Style="position: static" ID="Button1" OnClick="Button1_Click" runat="server" Width="81px" Text="EXIT" ForeColor="DarkBlue" Font-Bold="True" __designer:wfdid="w9"></asp:Button></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center" colspan="4">&nbsp;</td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    &nbsp;
</asp:Content>


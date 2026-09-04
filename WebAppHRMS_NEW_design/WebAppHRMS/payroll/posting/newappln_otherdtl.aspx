<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="newappln_otherdtl.aspx.vb" Inherits="WebAppHRMS.payroll_Posting_newappln_otherdtl_e872bd665844" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <table align="center" border="1">
        <tr>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center">
                <asp:UpdatePanel ID="upnl_appln" runat="server">
                    <ContentTemplate>
                        &nbsp;<asp:Label ID="lbl_err" runat="server" Width="206px" text-align="center"></asp:Label>
                        <table align="center" border="1" style="width: 784px">
                            <tr>
                                <td style="width: 312px">Application No</td>
                                <td style="width: 120px">
                                    <asp:TextBox ID="txt_applnno" runat="server" AutoPostBack="True" OnTextChanged="txt_applnno_TextChanged"
                                        Width="174px"></asp:TextBox></td>
                                <td style="width: 299px">Candidate Name</td>
                                <td colspan="2">
                                    <asp:TextBox ID="txt_cname" runat="server" Width="194px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="3">Specify relatives, if any ,employed in Manappuram Group</td>
            <td style="text-align: center;" colspan="3">
                <asp:CheckBox ID="chk_relative" runat="server" AutoPostBack="True" /></td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center">
                <asp:UpdatePanel ID="upnl_emp" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="1" style="width: 784px">
                            <tr>
                                <td style="width: 144px; text-align: left">Employee Name</td>
                                <td style="width: 100px; text-align: left">
                                    <asp:TextBox ID="txt_empname" runat="server" Width="256px"></asp:TextBox></td>
                                <td style="width: 117px; text-align: left">Relation</td>
                                <td style="width: 102px; text-align: left">
                                    <asp:TextBox ID="txt_emprel" runat="server" Width="234px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="chk_relative" EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="3">Specify relationship with Directors,if any</td>
            <td colspan="3" style="text-align: center">
                <asp:CheckBox ID="chk_dir" runat="server" AutoPostBack="True" /></td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center">
                <asp:UpdatePanel ID="upnl_dir" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="1" style="width: 777px">
                            <tr>
                                <td style="width: 144px; text-align: left">Director Name</td>
                                <td style="width: 100px; text-align: left">
                                    <asp:TextBox ID="txt_dirname" runat="server" Width="241px"></asp:TextBox></td>
                                <td style="width: 117px; text-align: left">Relation</td>
                                <td style="width: 102px; text-align: left">
                                    <asp:TextBox ID="txt_dirprel" runat="server" Width="233px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="chk_dir" EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 100px"></td>
            <td colspan="3" style="text-align: center">Referance Details <span style="color: #ff0033">*</span></td>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td style="width: 100px">Name 1</td>
            <td colspan="2">
                <asp:TextBox ID="txt_refname1" runat="server" Width="233px"></asp:TextBox></td>
            <td style="width: 100px">Name 2</td>
            <td colspan="2">
                <asp:TextBox ID="txt_refname2" runat="server" Width="233px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">Address1</td>
            <td colspan="2">
                <asp:TextBox ID="txt_refadd1" runat="server" MaxLength="50" Width="233px"></asp:TextBox></td>
            <td style="width: 100px">Address2</td>
            <td colspan="2">
                <asp:TextBox ID="txt_refadd2" runat="server" MaxLength="50" Width="233px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">Phone1</td>
            <td colspan="2">
                <asp:TextBox ID="txt_refph1" runat="server" MaxLength="50" Width="233px"></asp:TextBox></td>
            <td style="width: 100px">Phone2</td>
            <td colspan="2">
                <asp:TextBox ID="txt_refph2" runat="server" MaxLength="50" Width="233px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">Any&nbsp;Other&nbsp;Details
            </td>
            <td colspan="5">
                <asp:TextBox ID="txt_otherdtl" runat="server" Width="640px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">&nbsp;<asp:Button ID="cmd_confirm" runat="server" Text="Confirm" /></td>
            <td colspan="3" style="text-align: center">
                <asp:Button ID="cmd_exit" runat="server" Text="Exit" Width="67px" /></td>
        </tr>
    </table>
</asp:Content>


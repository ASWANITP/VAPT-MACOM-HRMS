<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="update_superior.aspx.vb" Inherits="WebAppHRMS.payroll_update_superior_b8309cc24577" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    <table align="center" border="1">
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td style="height: 21px;" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table align="center" style="width: 566px" border="1">
                            <tr>
                                <td style="text-align: center;" colspan="4">
                                </td>
                            </tr>
                            <%--<tr>
                                <td style="text-align: center;" colspan="4">
                                    <asp:RadioButton ID="rd_ho" runat="server" AutoPostBack="True" Checked="True" GroupName="ar"
                                        OnCheckedChanged="rd_ho_CheckedChanged" Text="HO" Visible="False" />
                                    <asp:RadioButton ID="rd_branch" runat="server" AutoPostBack="True" GroupName="ar"
                                        OnCheckedChanged="rd_branch_CheckedChanged" Text="Branch" Visible="False" /></td>
                            </tr>--%>
                            <tr>
                                <td style="width: 119px">
                                    <asp:Label ID="lbl_section" runat="server" Width="198px"></asp:Label></td>
                                <td style="width: 99px">
                                    <asp:DropDownList ID="cmb_section" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmb_section_SelectedIndexChanged"
                                        Width="235px">
                                    </asp:DropDownList></td>
                                <td style="width: 100px">
                                    <asp:Label ID="lbl_superior" runat="server" Width="185px"></asp:Label></td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="cmb_employ" runat="server" Width="236px">
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" >
                <asp:Button ID="cmd_confirm" runat="server" Text="Confirm" Width="71px" /></td>
            <td style="text-align: center" >
                <asp:Button ID="cmd_exit" runat="server" Text="Exit" Width="74px" /></td>
        </tr>
    </table>
</asp:Content>


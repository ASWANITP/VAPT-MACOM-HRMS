<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="PunchFrmAO.aspx.vb" Inherits="WebAppHRMS.PunchFrm_AO_PunchFrmAO_f6d41b6d3321" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function Button2_onclick() {
            window.open('../Home.aspx', '_self')
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <span style="font-size: 14pt; color: #ff0000"><strong>
            <br />
            <span style="font-size: 16pt">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                PUNCH FROM AO</span></strong></span><br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="border-left-color: #ffcccc; border-bottom-color: #ffcccc; width: 334px; border-top-style: solid; border-top-color: #ffcccc; border-right-style: solid; border-left-style: solid; border-right-color: #ffcccc; border-bottom-style: solid">
                    <tbody>
                        <tr>
                            <td style="width: 625px; text-align: right"><strong>Branch</strong></td>
                            <td style="width: 298px">
                                <asp:DropDownList ID="drp_branch" runat="server" Width="221px" Height="22px" AutoPostBack="True"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 625px; text-align: right"><strong>Employees</strong></td>
                            <td style="width: 298px">
                                <asp:ListBox ID="lst_emp" runat="server" Width="223px" AutoPostBack="True"></asp:ListBox></td>
                        </tr>
                        <tr>
                            <td style="width: 625px; text-align: right"><strong>Employee</strong></td>
                            <td style="width: 298px">
                                <asp:Label ID="Label1" runat="server" Width="222px" Text="---------------------" ForeColor="#FF0033" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 625px; text-align: right"><strong>Shift</strong></td>
                            <td style="width: 298px">
                                <asp:Label ID="Lbl_shift" runat="server" Width="222px" Text="---------------------" ForeColor="#FF0000" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 625px; text-align: right"><strong>Update Time</strong></td>
                            <td style="width: 298px; text-align: center">
                                <asp:TextBox ID="txt_frm_shft" runat="server" Width="61px" Font-Bold="True"></asp:TextBox>
                                &nbsp;<span style="color: #ff0000">(24H clock)
                                    <br />
                                    <strong><span>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" MaskType="Time" Mask="99:99:99" TargetControlID="txt_frm_shft" __designer:wfdid="w11"></cc1:MaskedEditExtender>
                                    </span></strong></span>
                                <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" __designer:wfdid="w12" InvalidValueMessage="Invalid Time" ControlToValidate="txt_frm_shft" ControlExtender="MaskedEditExtender1"></cc1:MaskedEditValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 625px; text-align: right"></td>
                            <td style="width: 298px; text-align: center">&nbsp;</td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="text-align: center">
            <table style="width: 338px">
                <tr>
                    <td style="background-color: #ffcccc" colspan="2">
                        <input id="Button2" style="width: 98px; font-weight: bold;" type="button" value="EXIT" onclick="return Button2_onclick()" />
                        <asp:Button ID="Button1" runat="server" Font-Bold="True" Height="23px" Text="UPDATE"
                            Width="105px" /></td>
                </tr>
            </table>
        </div>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp;
        <br />
    </div>
    &nbsp;
    <br />
    <br />
</asp:Content>


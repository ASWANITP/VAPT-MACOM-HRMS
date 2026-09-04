<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="rec_resign_mac.aspx.vb" Inherits="WebAppHRMS.new_approve_resign_7506ce352995" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

function Button2_onclick() {
window.open('../../home.aspx','_self');
}

    </script>

    <div style="text-align: center">
        `<table border="1">
            <tr>
                <td colspan="4">
                    <strong>RECOMMEND RESIGNATION<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    </strong>
                </td>
            </tr>
            <tr>
                <td colspan="46">&nbsp;&nbsp;
                    
                    <asp:RadioButton GroupName="S1" Checked="true" ID="RadioButton4" OnCheckedChanged="RadioButton4_CheckedChanged" AutoPostBack="true" runat="server" Text="Recommend by TECH LEAD" />
                    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:RadioButton ID="RadioButton5" GroupName="S1" OnCheckedChanged="RadioButton5_CheckedChanged" AutoPostBack="true" runat="server" Text="Recommend by DEPARTMENT HEAD" />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 214px">

                    <table border="1">
                        <tbody>
                            <tr>
                                <td style="width: 2773px; text-align: left"><strong>Select&nbsp;Employee</strong></td>
                                <td style="text-align: left" colspan="3">
                                    <asp:DropDownList ID="drop" AutoPostBack="true" OnSelectedIndexChanged="drop_SelectedIndexChanged" runat="server">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="height: 32px; text-align: left" colspan="4">
                                    <table border="0">
                                        <tbody>
                                            <tr>
                                                <td style="height: 23px; text-align: left" colspan="2">
                                                    <strong>Employee&nbsp;Code :</strong>
                                                    <asp:Label ID="lbl_code" runat="server" Width="148px" Text="No Empoyee" ForeColor="Navy"></asp:Label></td>
                                                <td style="width: 392px; height: 23px; text-align: left" colspan="2"><strong>Employee&nbsp;Name :</strong>&nbsp;
                                                    <asp:Label ID="lbl_name" runat="server" Width="274px" Text="No Employee" ForeColor="Navy"></asp:Label></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    &nbsp;&nbsp; 
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2773px; height: 23px; text-align: left"><strong>Relieving&nbsp;Date</strong></td>
                                <td style="height: 23px; text-align: left" colspan="3">
                                    <asp:TextBox ID="Txt_rdt" ReadOnly="true" runat="server" AutoPostBack="True"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 2773px; text-align: left"><strong>Reason&nbsp;for&nbsp;Resigning</strong></td>
                                <td style="text-align: left" colspan="3">
                                    <asp:TextBox ID="Txt_rea" runat="server" Width="571px" ForeColor="MediumBlue" TextMode="MultiLine" Wrap="True" Height="58px" ReadOnly="True" MaxLength="150"></asp:TextBox></td>
                            </tr>
                        </tbody>
                    </table>

                </td>
            </tr>
            <tr style="text-align: center;">
                <td colspan="4" style="height: 23px">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <table border="0">
                        <tr>
                            <td style="width: 79px; text-align: center; height: 24px;">
                                <asp:HiddenField ID="myhid" runat="server" />
                                &nbsp;<br />

                                <input id="cmd_att" runat="server" type="button" value="View Attachment" /><br />
                                &nbsp;</td>
                            <td style="width: 122px; text-align: center; height: 24px;">
                                <asp:Button ID="cmd_confirm" runat="server" Text="RECOMMEND" Style="width: 105px" Height="22px" Width="97px" /></td>
                            <td style="width: 122px; text-align: center; height: 24px;">
                                <input id="Button2" type="button" value="EXIT" onclick="return Button2_onclick()" style="width: 88px" /></td>

                        </tr>
                    </table>
                    &nbsp; &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


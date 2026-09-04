<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="rec_resign_mac.aspx.vb" Inherits="WebAppHRMS.new_approve_resign_7506ce352995" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">

function Button2_onclick() {
window.open('../../home.aspx','_self');
}

</script>

    <div style="text-align: center">
        `<table border="1">
            <tr>
                <td colspan="4">
                    <strong>RECOMMEND RESIGNATION<asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager></strong>
                </td>
            </tr>
                        <tr>
                <td colspan="46">
                    &nbsp;&nbsp;
                    
                    <asp:RadioButton GroupName="S1" Checked="true" ID="RadioButton4" OnCheckedChanged ="RadioButton4_CheckedChanged" AutoPostBack ="true" runat="server" Text="Recommend by TECH LEAD" />
                    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:RadioButton ID="RadioButton5" GroupName="S1" OnCheckedChanged ="RadioButton5_CheckedChanged" AutoPostBack ="true"  runat="server" Text="Recommend by DEPARTMENT HEAD" />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 214px">
                    
<TABLE border="1">
<TBODY>
<TR>
<TD style="WIDTH: 2773px; TEXT-ALIGN: left"><STRONG>Select&nbsp;Employee</STRONG></TD>
<TD style="TEXT-ALIGN: left" colSpan=3>
    <asp:DropDownList ID="drop" AutoPostBack ="true" OnSelectedIndexChanged ="drop_SelectedIndexChanged"  runat="server">
    </asp:DropDownList></TD>
</TR>
<TR>
<TD style="HEIGHT: 32px; TEXT-ALIGN: left" colSpan=4>
<TABLE border=0>
<TBODY>
<TR>
<TD style="HEIGHT: 23px; TEXT-ALIGN: left" colSpan=2>
<STRONG>Employee&nbsp;Code :</STRONG> <asp:Label id="lbl_code" runat="server" Width="148px" Text="No Empoyee" ForeColor="Navy"></asp:Label></TD>
<TD style="WIDTH: 392px; HEIGHT: 23px; TEXT-ALIGN: left" colSpan=2><STRONG>Employee&nbsp;Name :</STRONG>&nbsp; <asp:Label id="lbl_name" runat="server" Width="274px" Text="No Employee" ForeColor="Navy"></asp:Label></TD>
</TR>
</TBODY>
</TABLE>&nbsp;&nbsp; 
</TD></TR><TR><TD style="WIDTH: 2773px; HEIGHT: 23px; TEXT-ALIGN: left"><STRONG>Relieving&nbsp;Date</STRONG></TD><TD style="HEIGHT: 23px; TEXT-ALIGN: left" colSpan=3><asp:TextBox id="Txt_rdt" ReadOnly ="true" runat="server" AutoPostBack="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 2773px; TEXT-ALIGN: left"><STRONG>Reason&nbsp;for&nbsp;Resigning</STRONG></TD><TD style="TEXT-ALIGN: left" colSpan=3><asp:TextBox id="Txt_rea" runat="server" Width="571px" ForeColor="MediumBlue" TextMode="MultiLine" Wrap="True" Height="58px" ReadOnly="True" MaxLength="150"></asp:TextBox></TD></TR></TBODY></TABLE>

                    </TD>
            </tr>
            <tr style ="text-align :center ;">
                <td colspan="4" style="height: 23px">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <table border="0">
                    <tr>
                <td style="width: 79px; text-align: center; height: 24px;">
                <asp:HiddenField ID="myhid" runat ="server" />
                    &nbsp;<br />
                    
                    <input id="cmd_att" runat="server" type="button" value="View Attachment" /><br />
                    &nbsp;</td>
                <td style="width: 122px; text-align: center; height: 24px;">
                    <asp:Button ID="cmd_confirm" runat="server" Text="RECOMMEND" style="width: 105px" Height="22px" Width="97px" /></td>
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


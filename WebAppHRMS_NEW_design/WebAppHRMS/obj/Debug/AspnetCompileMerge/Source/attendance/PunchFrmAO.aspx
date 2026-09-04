<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="PunchFrmAO.aspx.vb" Inherits="WebAppHRMS.PunchFrm_AO_PunchFrmAO_f6d41b6d3321" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button2_onclick() {
window.open('../Home.aspx','_self')
}

// ]]>
</script>

    <div style="text-align: center">
        <span style="font-size: 14pt; color: #ff0000"><strong>
            <br />
            <span style="font-size: 16pt">
                <asp:ScriptManager id="ScriptManager1" runat="server">
                </asp:ScriptManager>
                PUNCH FROM AO</span></strong></span><br />
        <br />
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<TABLE style="BORDER-LEFT-COLOR: #ffcccc; BORDER-BOTTOM-COLOR: #ffcccc; WIDTH: 334px; BORDER-TOP-STYLE: solid; BORDER-TOP-COLOR: #ffcccc; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-RIGHT-COLOR: #ffcccc; BORDER-BOTTOM-STYLE: solid"><TBODY><TR><TD style="WIDTH: 625px; TEXT-ALIGN: right"><STRONG>Branch</STRONG></TD><TD style="WIDTH: 298px"><asp:DropDownList id="drp_branch" runat="server" Width="221px" Height="22px" AutoPostBack="True"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 625px; TEXT-ALIGN: right"><STRONG>Employees</STRONG></TD><TD style="WIDTH: 298px"><asp:ListBox id="lst_emp" runat="server" Width="223px" AutoPostBack="True"></asp:ListBox></TD></TR><TR><TD style="WIDTH: 625px; TEXT-ALIGN: right"><STRONG>Employee</STRONG></TD><TD style="WIDTH: 298px"><asp:Label id="Label1" runat="server" Width="222px" Text="---------------------" ForeColor="#FF0033" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 625px; TEXT-ALIGN: right"><STRONG>Shift</STRONG></TD><TD style="WIDTH: 298px"><asp:Label id="Lbl_shift" runat="server" Width="222px" Text="---------------------" ForeColor="#FF0000" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 625px; TEXT-ALIGN: right"><STRONG>Update Time</STRONG></TD><TD style="WIDTH: 298px; TEXT-ALIGN: center"><asp:TextBox id="txt_frm_shft" runat="server" Width="61px" Font-Bold="True"></asp:TextBox> &nbsp;<SPAN style="COLOR: #ff0000">(24H clock) <BR /><STRONG><SPAN><cc1:MaskedEditExtender id="MaskedEditExtender1" runat="server" MaskType="Time" Mask="99:99:99" TargetControlID="txt_frm_shft" __designer:wfdid="w11"></cc1:MaskedEditExtender></SPAN></STRONG></SPAN><cc1:MaskedEditValidator id="MaskedEditValidator1" runat="server" __designer:wfdid="w12" InvalidValueMessage="Invalid Time" ControlToValidate="txt_frm_shft" ControlExtender="MaskedEditExtender1"></cc1:MaskedEditValidator></TD></TR><TR><TD style="WIDTH: 625px; TEXT-ALIGN: right"></TD><TD style="WIDTH: 298px; TEXT-ALIGN: center">&nbsp;</TD></TR></TBODY></TABLE>
</contenttemplate>
        </asp:UpdatePanel><div style="text-align: center">
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


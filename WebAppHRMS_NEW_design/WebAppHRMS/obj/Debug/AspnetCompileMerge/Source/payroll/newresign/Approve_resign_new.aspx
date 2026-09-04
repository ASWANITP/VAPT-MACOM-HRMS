<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/edp.master" CodeBehind="Approve_resign_new.aspx.vb" Inherits="WebAppHRMS.New_folder__3_Approve_resign_new_723f2d942842" %>




<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button2_onclick() {
window.open('../../home.aspx','_self');
}
//function van() 
//{
// debugger;
//  alert("Select Date From Calender");
//  document.getElementById("Txt_rdt").value=" ";
//    return false;

//}
// ]]>
</script>

    &nbsp;<div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4">
                    <strong>APPROVE RESIGNATION<asp:ScriptManager id="ScriptManager1" runat="server"></asp:ScriptManager></strong>&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">--%>
                        <contenttemplate>
<TABLE border=1><TBODY><TR><TD style="WIDTH: 2773px; TEXT-ALIGN: left"><STRONG>Select&nbsp;Employee</STRONG></TD><TD style="TEXT-ALIGN: left" colSpan=3><asp:DropDownList id="cmb_emp" runat="server" Width="582px" AutoPostBack="True">
                    </asp:DropDownList></TD></TR><TR><TD style="TEXT-ALIGN: left" colSpan=2><STRONG>Employee&nbsp;Code :</STRONG> <asp:Label id="lbl_code" runat="server" Width="148px" Text="No Empoyee" ForeColor="Navy"></asp:Label></TD><TD style="WIDTH: 392px; TEXT-ALIGN: left" colSpan=2><STRONG>Employee&nbsp;Name :</STRONG>&nbsp; <asp:Label id="lbl_name" runat="server" Width="226px" Text="No Employee" ForeColor="Navy"></asp:Label></TD></TR><TR><TD style="WIDTH: 2773px; TEXT-ALIGN: left"><STRONG>Resigning&nbsp;Date</STRONG></TD><TD style="WIDTH: 106px"><asp:TextBox id="Txt_rsdt" runat="server" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 392px" colSpan=2>&nbsp;&nbsp; </TD></TR><TR><TD style="WIDTH: 2773px; TEXT-ALIGN: left"><STRONG>Reason&nbsp;for&nbsp;Resigning</STRONG></TD><TD style="TEXT-ALIGN: left" colSpan=3><asp:TextBox id="Txt_rea" runat="server" Width="571px" ForeColor="Navy" Height="22px" ReadOnly="True" TextMode="singleLine"></asp:TextBox></TD></TR>
                    <TR><TD style="WIDTH: 2773px; HEIGHT: 23px; TEXT-ALIGN: left"><STRONG>Relieving&nbsp;Date</STRONG></TD><TD style="WIDTH: 106px; HEIGHT: 23px"><asp:TextBox id="Txt_rdt" ReadOnly="True" runat="server"></asp:TextBox></TD><TD style="WIDTH: 392px; HEIGHT: 23px" colSpan=2>
<%--<cc1:CalendarExtender TargetControlID="txt_rdt" runat="server" ID="datetime"></cc1:CalendarExtender>--%>
    &nbsp; </TD></TR>
   <TD><TR><TD style="WIDTH: 2773px; TEXT-ALIGN: left; height: 26px;"><STRONG>Remarks</STRONG></TD>
   <td colspan="3"><asp:TextBox id="Text_remar" width="577px" runat="server"></asp:TextBox></td>
   </TR></TD> 
    </TBODY>
    
    </TABLE><%--<cc1:ListSearchExtender id="ListSearchExtender1" runat="server" TargetControlID="cmb_emp">
                    </cc1:ListSearchExtender>--%>&nbsp; &nbsp;
</contenttemplate>
                    <%--</asp:UpdatePanel>--%>
                    
                    
                    
                    </td>
            </tr>
            <tr>
                <td colspan="4">
                </td>
            </tr>
            <tr>
                <td style="width: 160px">
                    &nbsp;
                </td>
                <td style="width: 79px; text-align: center;">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                <td style="width: 122px">
                    <input id="Button2" type="button" value="EXIT" onclick="return Button2_onclick()" style="width: 88px" /></td>
                <td style="width: 128px">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

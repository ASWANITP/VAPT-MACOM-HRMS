<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="appln_conf.aspx.vb" Inherits="WebAppHRMS.payroll_Posting_appln_conf_dc38b86b2612" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>


<script language="javascript" type="text/javascript">
function check_dt()
{
 alert("Select Date From Calender");
 return false;
}
function window_onload() 
{
    
}

</script>
    <table align="center" border="1" style="width: 674px" >
        <tr>
            <td style="height: 23px; text-align: center;" colspan="2">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
                                    &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 17px;" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
<TABLE style="WIDTH: 708px" align=center border=1><TBODY><TR><TD style="TEXT-ALIGN: center" colSpan=4><asp:Label id="lbl_msg" runat="server" Width="208px"></asp:Label></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=4><cc1:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="txt_dt" Format="dd/MMM/yyyy">
                                    </cc1:CalendarExtender> Interview Details</TD></TR><TR><TD colSpan=2>Application No &amp; Candidate Name</TD><TD colSpan=2><asp:DropDownList id="cmb_appln" runat="server" Width="357px"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 104px">Interviewed By</TD><TD><asp:TextBox id="txt_intvwid" runat="server" Width="160px" AutoPostBack="True"></asp:TextBox></TD><TD>Name</TD><TD><asp:TextBox id="txt_intvwname" runat="server" Width="160px" ReadOnly="True"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 104px">Interviewed At</TD><TD style="WIDTH: 100px"><asp:DropDownList id="cmb_place" runat="server" Width="165px">
                                    </asp:DropDownList></TD><TD style="WIDTH: 100px">Post Offered</TD><TD style="WIDTH: 100px"><asp:DropDownList id="cmb_post" runat="server" Width="304px"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 104px">Interview Date</TD><TD style="WIDTH: 100px"><asp:TextBox id="txt_dt" onkeypress="return check_dt()" runat="server" Width="160px" AutoPostBack="True" OnTextChanged="txt_dt_TextChanged"></asp:TextBox></TD><TD style="WIDTH: 100px">Status</TD><TD style="WIDTH: 100px"><asp:DropDownList id="cmb_status" runat="server" Width="165px">
                                        <asp:ListItem Value="1">CLEARED</asp:ListItem>
                                        <asp:ListItem Value="2">PENDING</asp:ListItem>
                                        <asp:ListItem Value="0">REJECTED</asp:ListItem>
                                    </asp:DropDownList></TD></TR></TBODY></TABLE>
</ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 28px" ><asp:Button ID="cmd_confirm" runat="server" Text="Confirm" />
                </td>
            <td align="center" style="height: 28px"  ><asp:Button ID="cmd_exit" runat="server" Text="Exit" Width="68px" />
                </td>
            </tr>
    </table>
</asp:Content>


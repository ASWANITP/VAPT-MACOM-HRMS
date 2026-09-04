<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Pay_ Leave_cancel.aspx.vb" Inherits="WebAppHRMS.Payroll_LeaveUpdation_1dc57b007771" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
// <!CDATA[
var cs = cont_name.split("txt")
var max=9999
//function btn_exit_onclick() {
// window.open ('../home.aspx','_self');
//}
function btn_ok()
{
    if(document.getElementById(cs[0]+"txt_id").value =="")
        {
        alert('You Should Enter employee Id!!');
            document.getElementById(cs[0]+"txt_id").focus;
            return false
        }
   if(document.getElementById(cs[0]+"txt_id").value <max)
        {
        alert('You Should Enter Valid Employee Code(Minimum 5 digits)!!!');
            document.getElementById(cs[0]+"txt_id").focus;
            return false
        }
        
}

function btn_onclick()
{
  if(document.getElementById(cs[0]+"txt_id").value =="")
       {
            alert('You Should Enter employee Id!!');
            document.getElementById(cs[0]+"txt_id").focus;
            return false
        }
        if(document.getElementById(cs[0]+"ddl_leave").value =="999xxx")
        {
        alert('Nothing To Update!!');
            document.getElementById(cs[0]+"txt_id").value="";
            return false
        }
//   if(document.getElementById(cs[0]+"hf_eid").value==document.getElementById(cs[0]+"txt_id").value)
//        {
//            alert('You Should Enter Valid employee Id!!');
//            document.getElementById(cs[0]+"txt_id").value=""
//            document.getElementById(cs[0]+"txt_id").focus
//            return false
//        }
}
function Button1_onclick() 
{
 window.open ('../home.aspx','_self');
}

// ]]>
    </script>

    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                <br />
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                    TargetControlID="txt_id"></cc1:FilteredTextBoxExtender>
                <asp:HiddenField ID="hf_eid" runat="server" />
                <br />
                <div style="text-align: center">
                    <table border="1" style="width: 503px">
                        <tr>
                            <td style="width: 129px; text-align: center">
                                <strong><span style="font-family: Courier New">Employee&nbsp;Code</span></strong></td>
                            <td style="width: 108px">
                                <asp:TextBox ID="txt_id" runat="server" Width="159px" MaxLength="6" Height="15px"></asp:TextBox></td>
                            <td style="width: 226px; text-align: left;">
                                <asp:Button ID="btn_ok" runat="server" Text="Check >>" Width="135px" Font-Bold="True" Font-Names="Courier New" /></td>
                            <td style="width: 151px; text-align: left">
                                <input id="Button1" style="width: 44px" type="button" value="Exit" onclick="return Button1_onclick()" /></td>
                        </tr>
                    </table>
                </div>
                <div style="text-align: center">
                    <table id="TABLE2" runat="server" border="1" style="width: 506px">
                        <tr>
                            <td style="width: 130px; text-align: center">
                                <strong><span style="font-family: Courier New">Name</span></strong></td>
                            <td colspan="2" style="width: 308px">
                                <asp:Label ID="lbl_name" runat="server" Width="222px" Font-Bold="True" Font-Names="Courier New"></asp:Label></td>
                        </tr>
                    </table>
                    <br />
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div style="text-align: center">
                        <table border="1">
                            <tr>
                                <td colspan="4">
                                    <strong><span style="font-family: Courier New">Leave Taken</span></strong></td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <strong><span style="font-family: Courier New">Select&nbsp;Leave&nbsp;Taken</span></strong></td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddl_leave" runat="server" Width="378px" AutoPostBack="True" Height="21px"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td colspan="1" style="text-align: right">
                                    <span style="font-family: Courier New">From</span></td>
                                <td colspan="1" style="width: 147px; text-align: left">
                                    <asp:Label ID="lbl_frm" runat="server" Width="141px" Font-Bold="False" Font-Names="Courier New"></asp:Label></td>
                                <td colspan="1" style="width: 22px; text-align: right">
                                    <span style="font-family: Courier New">To</span></td>
                                <td colspan="4" style="text-align: left">
                                    <asp:Label ID="lbl_to" runat="server" Font-Bold="False" Width="162px" Font-Names="Courier New"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="1" style="text-align: right; height: 23px;">
                                    <span style="font-family: Courier New">No of&nbsp;Days</span></td>
                                <td colspan="1" style="width: 147px; text-align: left; height: 23px;">
                                    <asp:Label ID="lbl_days" runat="server" Width="145px" Font-Bold="False" Font-Names="Courier New"></asp:Label></td>
                                <td colspan="1" style="width: 22px; text-align: right; height: 23px;">
                                    <span style="font-family: Courier New">Type</span></td>
                                <td colspan="4" style="text-align: left; height: 23px;">
                                    <asp:Label ID="lbl_type" runat="server" Font-Bold="False" Width="162px" Font-Names="Courier New"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <span style="font-family: Courier New">
                                        <strong>Leave&nbsp;Cancellation </strong>
                                        <br />
                                    </span>
                                    <asp:Label ID="lbl_err" runat="server" Width="562px" ForeColor="Red" Font-Bold="True" Font-Names="Courier New"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; text-align: center">
                                    <strong>&nbsp;<span style="font-family: Courier New">From Date</span></strong></td>
                                <td style="width: 147px">
                                    <asp:DropDownList ID="ddl_frm" runat="server" Width="148px" AutoPostBack="True" OnSelectedIndexChanged="ddl_frm_SelectedIndexChanged1" Font-Bold="False"></asp:DropDownList></td>
                                <td style="width: 22px; text-align: center">
                                    <strong><span style="font-family: Courier New">To&nbsp;</span></strong></td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="ddl_to" runat="server" Width="142px" AutoPostBack="True"></asp:DropDownList></td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="text-align: center">
            <div style="text-align: center">
                <div style="text-align: center">
                    <table border="1" id="TABLE1" runat="server">
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btn_confirm" runat="server" Text="Confirm" Width="88px" Font-Bold="False" Font-Names="Courier New" /></td>
                        </tr>
                    </table>
                </div>
            </div>
            <br />
        </div>
        <br />
    </div>
</asp:Content>


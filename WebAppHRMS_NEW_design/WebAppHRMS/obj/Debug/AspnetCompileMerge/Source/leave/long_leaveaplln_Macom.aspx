<%--<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="long_leaveaplln_Macom.aspx.vb" Inherits="leave_long_leaveaplln_Macom_6652e24f3947" title="Untitled Page" %>--%>
<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="long_leaveaplln_Macom.aspx.vb" Inherits="WebAppHRMS.leave_long_leaveaplln_Macom_6652e24f3947" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont=cont_name.split("txt")
function check_null()
{
 //alert("in")
 if((document.getElementById(cont[0]+"chk_lngleave").checked)==false)
  { 
    if((document.getElementById(cont[0]+"chk_maternity").checked)==false)
     {
       if((document.getElementById(cont[0]+"Chkaddwork").checked)==false)
       {
         if((document.getElementById(cont[0]+"Chkdltwrk").checked)==false)
         {
       alert("Please Select Any CheckBox")
       return false;
       }
       }
     }
  }
  
   if((document.getElementById(cont[0]+"chk_lngleave").checked)==true)
  { 
    if((document.getElementById(cont[0]+"chk_maternity").checked)==true)
     {
         if((document.getElementById(cont[0]+"Chkaddwork").checked)==true)
         {
             if((document.getElementById(cont[0]+"Chkdltwrk").checked)==true)
             {
       alert("Check Only one at a Time")
       return false;
       }
       }
     }
  }
  
  if((document.getElementById(cont[0]+"txt_fromdt").value)=="")
    {
       alert("From date is null")
       return false;
    } 
     if((document.getElementById(cont[0]+"txt_remarks").value)=="")
     {
       alert("Remark is null")
       return false;
     }   
}

function from_dt()
{
 alert("Select Date From Calender")
 return false;
}

</script>
    <table align="center" border="1" style="border:unset;">
        <tr>
            <td colspan="2" style="text-align: center">
                <strong>LONG LEAVE<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager><cc1:ListSearchExtender ID="ListSearchExtender1" runat="server"
                    TargetControlID="cmb_emp">
                </cc1:ListSearchExtender>
                </strong>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Width="403px"></asp:Label>&nbsp;<table style="width: 516px" border="1">
        <tr>
            <td style="width: 100px; text-align: left;">
                Employee</td>
            <td colspan="3">
                <asp:DropDownList ID="cmb_emp" runat="server" AutoPostBack="True" Width="423px" OnSelectedIndexChanged="cmb_emp_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: left;">
                Designation</td>
            <td style="width: 100px">
                <asp:TextBox ID="txt_desig" runat="server" Width="156px"></asp:TextBox></td>
            <td style="width: 100px; text-align: left;">
                Post Offered</td>
            <td style="width: 100px">
                <asp:TextBox ID="txt_post" runat="server" Width="157px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: left;">
                Location</td>
            <td style="width: 100px">
                <asp:TextBox ID="txt_loc" runat="server" Width="157px"></asp:TextBox></td>
            <td style="width: 100px; text-align: left;">
                Department</td>
            <td style="width: 100px">
                <asp:TextBox ID="txt_dep" runat="server" Width="158px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:CheckBox ID="chk_lngleave" Autopostback="true" runat="server" Text="Long Leave" /></td>
            <td colspan="2" style="text-align: center">
                <asp:CheckBox ID="chk_maternity" Autopostback="true" runat="server" Text="Maternity" /></td>
        </tr>
         <tr style="display:none;">
            <td colspan="2" style="text-align: center">
                <asp:CheckBox ID="Chkaddwork" Autopostback="true" runat="server" Text=" Add WFH" /></td>
            <td colspan="2" style="text-align: center">
                <asp:CheckBox ID="Chkdltwrk" Autopostback="true" runat="server" Text="Delete WFH" /></td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: left;">
                From Date</td>
            <td style="width: 100px">
                <asp:TextBox ID="txt_fromdt" runat="server" Width="157px" MaxLength="20" onkeypress="return from_dt()"></asp:TextBox></td>
           <td style="width: 100px; text-align: left; display:none;">
                Return Date</td>
            <td style="width: 100px; display:none;">
                <asp:TextBox ID="Txt_todt" runat="server" Width="157px" MaxLength="20" onkeypress="return from_dt()"></asp:TextBox></td>
                
        </tr>
                    <tr>
                        <td style="width: 100px; text-align: left">
                Remarks</td>
                        <td colspan="3" style="text-align: left">
                <asp:TextBox ID="txt_remarks" runat="server" Width="416px" MaxLength="60"></asp:TextBox></td>
                    </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
                    <table border="1" style="width: 504px">
                        <tr>
                            <td style="width: 230px; text-align: left">
                                Return Date</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txt_returndt" runat="server" Width="220px" MaxLength="20" onkeypress="return from_dt()"></asp:TextBox></td>
                        </tr>
                    </table>
                </asp:Panel>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                    TargetControlID="txt_fromdt">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                    TargetControlID="txt_returndt">
                </cc1:CalendarExtender>
                   <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MMM/yyyy"
                    TargetControlID="Txt_todt">
                </cc1:CalendarExtender>
            </td>
        </tr>
    </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center;">
                <asp:Button ID="cmd_confirm" runat="server" Text="SAVE" OnClientClick="return check_null()" /></td>
            <td style="text-align: center;">
                <asp:Button ID="cmd_exit" runat="server" Text="EXIT" Width="62px" /></td>
        </tr>
    </table>
</asp:Content>


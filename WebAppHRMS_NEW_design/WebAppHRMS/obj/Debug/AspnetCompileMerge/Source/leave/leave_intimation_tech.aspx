<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="leave_intimation_tech.aspx.vb" Inherits="WebAppHRMS.Payroll_leave_intimation_leave_intimation_tech_7fa78bdc8899" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
var con = cont_name.split("txt");
function hiderow()
{
debugger;

    if (document.getElementById(con[0]+"cmb_type").value==1)
    {
      document.getElementById("row3").style.display='inline';
      }
       if (document.getElementById(con[0]+"cmb_type").value==2)   
    {
        document.getElementById("row3").style.display='none';
        }
        }
        
</script>

    
    <div style="text-align: center">
    <table border="1" style="margin: 0px auto">
    <tr>
      <td colspan="4"style="width: 780px; height: 41px; text-align: center">
      <strong><span style="font-weight: bold; font-size: 15pt; color: #cc0099; font-family: 'Courier New';
      text-decoration: underline"><span style="color: #cc0000"><span style="font-family: Agency FB">
      <span style="font-size: 16pt"><strong><span style="text-decoration: underline">LEAVE &nbsp; INTIMATION
      &nbsp;</span></strong></span></span></span> 
          <br /><asp:ScriptManager id="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    <cc1:calendarextender id="CalendarExtender1" runat="server" Format="dd/MMM/yyyy" TargetControlID="Txt_fdt"></cc1:calendarextender>
      </span></strong>
     </td>
     
   </tr>
            
  
   <tr style="font-size: 12pt">
      <td colspan="4" style="width: 780px; height: 37px; text-align: center">
       <div style="text-align: center">
        <table style="width: 748px">
   <tr>
      <td style="width: 100px; text-align: left; height: 24px;">
       <strong>Select Date</strong></td>
      
        <td style="text-align: left; height: 27px;" colspan="3">
                            <%--<input id="Txt_fdt" runat="server" Autopostback="True"style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'; width: 217px;" type="text" readonly="readOnly" />--%>
                            <asp:TextBox ID="Txt_fdt"  runat="server" Width="147px"  Autopostback="True" Font-Size="Small" style="font-weight: normal; font-size: 11pt; font-family: 'Courier New'"></asp:TextBox>
                            <span style="font-size: 11pt; font-weight: normal; font-family: 'Courier New';"></span></td>
  </tr>
    </table>
     </div>
     </td>
      </tr>
      
   
            
   <tr style="font-size: 12pt">
      <td colspan="4" style="width: 780px; height: 37px; text-align: center">
       <div style="text-align: center">
        <table style="width: 748px">
   <tr>
      <td style="width: 100px; text-align: left; height: 24px;">
       <strong>Select Employee</strong></td>
       <td style="width: 100px; text-align: left; height: 24px;">
       <asp:DropDownList ID="ddl_emp" runat="server" AutoPostBack="True" BackColor="AliceBlue"    Width="606px">
      </asp:DropDownList></td>
  </tr>
    </table>
     </div>
     </td>
      </tr>
      
      
      
    <tr style="font-size: 12pt">
      <td colspan="4" style="width: 780px; height: 37px; text-align: center">
       <div style="text-align: center">
        <table style="width: 748px">  
      
   <tr>
     <td style="width: 100px; text-align: left; height: 24px;"><strong>  Select Status </strong></td>
      <td colspan="2" style="text-align: left">
     <asp:DropDownList ID="cmb_type" runat="server" Width="281px" onchange="return hiderow()">
           <asp:ListItem Value="0">------SELECT TYPE------</asp:ListItem>
           <asp:ListItem Value="1">INFORMED</asp:ListItem>
            <asp:ListItem Value="2">NOT INFORMED</asp:ListItem>
           </asp:DropDownList></td>
           </tr>
    </table>
     </div></td></tr>
     
      <tr style="font-size: 12pt">
      <td colspan="4" style="width: 780px; height: 37px; text-align: center">
       <div style="text-align: center">
        <table style="width: 748px">  
 <tr id="row3">
        <td style="width: 100px; text-align: left; height: 24px;"><strong>  Remarks </strong> </td>
       <td colspan="2" style="text-align: left; height: 28px;">
         <input id="txt_remarks" runat="server" maxlength="50" style="width: 281px; text-transform: uppercase;" type="text"  /></td>
    </tr></table></div></td>
    </tr>
          
  
             
  <tr>
     <td colspan="4" style="width: 780px; height: 37px; text-align: center">
      <asp:Button ID="btnConfirm" runat="server" Width="88px" Text="CONFIRM" />
       <asp:Button ID="btnExit" runat="server" Width="88px"  Text="EXIT" />      
      </td>
  </tr> </table>
     </div>
      
</asp:Content>
               
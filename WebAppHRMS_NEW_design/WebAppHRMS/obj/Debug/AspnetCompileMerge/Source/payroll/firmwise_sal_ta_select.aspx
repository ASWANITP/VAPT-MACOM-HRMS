<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="firmwise_sal_ta_select.aspx.vb" Inherits="WebAppHRMS.Firmwise_Salary_TA_firmwise_sal_ta_select_0ceb5ab79495" title="Firmwise:Salary And TA" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[
var cont_name=sal.split('Cmb');

function Cmd_Exit_onclick() 
{
 window.open('../home.aspx','_self');
}

function Check_Salary_onclick() 
{
 if((document.getElementById (cont_name[0]+"Check_Salary").checked==true)&&(document.getElementById (cont_name[0]+"Check_Incentive").checked==true))
 {
  
  document.getElementById (cont_name[0]+"Hid_Type").value=3;    //both
  
 }
 if((document.getElementById (cont_name[0]+"Check_Salary").checked==true)&&(document.getElementById (cont_name[0]+"Check_Incentive").checked==false))
 {
  
  document.getElementById (cont_name[0]+"Hid_Type").value=1;   //salary only
  
 }
 if((document.getElementById (cont_name[0]+"Check_Salary").checked==false)&&(document.getElementById (cont_name[0]+"Check_Incentive").checked==true))
 {
  
  document.getElementById (cont_name[0]+"Hid_Type").value=2;   //ta only
  
 }
 if((document.getElementById (cont_name[0]+"Check_Salary").checked==false)&&(document.getElementById (cont_name[0]+"Check_Incentive").checked==false))
 {
  
  document.getElementById (cont_name[0]+"Hid_Type").value=0;   //both
  
 }
}

function Check_Incentive_onclick() 
{
 if((document.getElementById (cont_name[0]+"Check_Salary").checked==true)&&(document.getElementById (cont_name[0]+"Check_Incentive").checked==true))
 {
   document.getElementById (cont_name[0]+"Hid_Type").value=3;    //both
   
 }
 if((document.getElementById (cont_name[0]+"Check_Salary").checked==true)&&(document.getElementById (cont_name[0]+"Check_Incentive").checked==false))
 {
    document.getElementById (cont_name[0]+"Hid_Type").value=1;   //salary only
    
 }
 if((document.getElementById (cont_name[0]+"Check_Salary").checked==false)&&(document.getElementById (cont_name[0]+"Check_Incentive").checked==true))
 {
   document.getElementById (cont_name[0]+"Hid_Type").value=2;   //ta only
   
 }
 if((document.getElementById (cont_name[0]+"Check_Salary").checked==false)&&(document.getElementById (cont_name[0]+"Check_Incentive").checked==false))
 {
   document.getElementById (cont_name[0]+"Hid_Type").value=0;   //both
   
 }
}
/////////////////////////////////////////////////

function cliclick()
{
 if((document.getElementById (cont_name[0]+"Check_Salary").checked==false)&&(document.getElementById (cont_name[0]+"Check_Incentive").checked==false))
 {
  alert('Please Select Salary or Incentives or Both By Ticking White Boxes and then CONFIRM !!');
  return false;
 }
}

function init()
{
 if((document.getElementById (cont_name[0]+"Check_Salary").checked==true)&&(document.getElementById (cont_name[0]+"Check_Incentive").checked==true))
 {
   document.getElementById (cont_name[0]+"Hid_Type").value=3;    //both
 }
 if((document.getElementById (cont_name[0]+"Check_Salary").checked==true)&&(document.getElementById (cont_name[0]+"Check_Incentive").checked==false))
 {
    document.getElementById (cont_name[0]+"Hid_Type").value=1;   //salary only
 }
 if((document.getElementById (cont_name[0]+"Check_Salary").checked==false)&&(document.getElementById (cont_name[0]+"Check_Incentive").checked==true))
 {
   document.getElementById (cont_name[0]+"Hid_Type").value=2;   //ta only
 }
 if((document.getElementById (cont_name[0]+"Check_Salary").checked==false)&&(document.getElementById (cont_name[0]+"Check_Incentive").checked==false))
 {
   document.getElementById (cont_name[0]+"Hid_Type").value=0;   //both
 }
}
window.onload=init;
// ]]>
</script>

    <div style="text-align: center">
        <br />
        <br />
        <asp:HiddenField ID="Hid_Type" runat="server" Value="0" />
        <div style="text-align: center">
            <table border="1">
                <tr>
                    <td style="width: 100px">
                        <table style="width: 223px">
                            <tr>
                                <td style="width: 32px; height: 22px">
                                    <input id="Check_Salary"  type="checkbox" onclick="return Check_Salary_onclick()" runat="server" style="cursor: hand" /></td>
                                <td style="width: 110px; height: 22px; text-align: left;">
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Tick For Salary" Width="158px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 32px; height: 22px">
                                    <input id="Check_Incentive" type="checkbox" onclick="return Check_Incentive_onclick()" runat="server" style="cursor: hand" /></td>
                                <td style="width: 110px; height: 22px; text-align: left;">
                                    <asp:Label ID="Label2" runat="server" Text="Tick For Incentives" Width="159px" Font-Bold="True"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 100px; text-align: left">
                            <table>
                                <tr>
                                    <td style="width: 142646px">
                                        <asp:Label ID="Label3" runat="server" Text="Select Firm    :" Width="114px" Font-Bold="True"></asp:Label></td>
                                    <td colspan="2">
                                    <asp:DropDownList ID="Cmb_Firm" runat="server" Width="158px" style="cursor: hand">
                                    </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="width: 142646px">
                                    </td>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 142646px">
                                    </td>
                                    <td style="width: 100px">
                                    <input id="Cmd_Exit" type="button" value="EXIT" style="width: 73px; cursor: hand;" onclick="return Cmd_Exit_onclick()" /></td>
                                    <td style="width: 100px">
                                    <asp:Button ID="Cmd_Confirm" OnClientClick="return cliclick()" runat="server" Text="CONFIRM" Width="74px" style="cursor: hand" ToolTip="Click To get Report" /></td>
                                </tr>
                            </table>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <br />
        <br />
    </div>
</asp:Content>


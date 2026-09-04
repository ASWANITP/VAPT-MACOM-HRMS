<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="discipline.aspx.vb" Inherits="WebAppHRMS.EMPLOYEE_DISIPLINARY_ACTION_DISCLIPINE_cc6a94021107" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
// <!CDATA[

var cont=header.split('txt');

function btn_exit_onclick()
 {

 window.open('../../home.aspx','_self');

}
function NumericCheck()
{
    var charcode = (event.which) ? event.which : event.keyCode
    if ( (charcode<46 || charcode>57))
    {
       window.event.cancelBubble = true;
       window.event.keyCode = 0;
       return false;
    }
}

function txt_empcodeonchange()
{
var emp=document.getElementById(cont[0]+"txt_empcode").value;
 if(emp=="")
 {
 alert("Enter the Emp Code...! ");
 return false;
  }
  else
  {
  toserver("1#"+emp,1);
  }
}

function fromserver(arg,context)
{
switch (context)
{
  case 1:
        var data=arg.split('$')
        document.getElementById(cont[0]+"txt_empname").value=data[0];
        document.getElementById(cont[0]+"txt_designation").value=data[1];
        document.getElementById(cont[0]+"txt_department").value=data[2];
        document.getElementById(cont[0]+"txt_branchname").value=data[3];
//       document.getElementById(cont[0]+"hdnvalue").value=data[4]+"!"+data[5]+data[6]+data[7];
        
        break;
        }
}

// ]]>
    </script>

    <div style="text-align: center">
        <div style="text-align: center">
            <table border="1">
                <caption>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_frmdate"></cc1:CalendarExtender>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_todate"></cc1:CalendarExtender>
                </caption>
                <tr>
                    <td colspan="2" style="height: 28px">Enter Employee Code</td>
                    <td style="width: 149px; height: 28px"></td>
                    <td colspan="2" style="width: 171px; height: 28px">
                        <asp:TextBox ID="txt_empcode" runat="server" Width="249px" BackColor="White" BorderColor="#E0E0E0" BorderStyle="Ridge"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 28px">EmployeeName</td>
                    <td style="width: 149px; height: 28px;"></td>
                    <td colspan="2" style="width: 171px; height: 28px;">
                        <asp:TextBox ID="txt_empname" runat="server" Width="247px" Enabled="False" BorderColor="#E0E0E0" BorderStyle="Ridge"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 37px">Designation</td>
                    <td style="width: 149px; height: 37px"></td>
                    <td colspan="2" style="width: 171px; height: 37px">
                        <asp:TextBox ID="txt_designation" runat="server" Width="247px" BorderColor="#E0E0E0" BorderStyle="Ridge" Font-Overline="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 28px">Department</td>
                    <td style="width: 149px; height: 28px"></td>
                    <td colspan="2" style="width: 171px; height: 28px">
                        <asp:TextBox ID="txt_department" runat="server" Width="249px" BorderColor="#E0E0E0" BorderStyle="Ridge"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 28px">Branchname</td>
                    <td style="width: 149px; height: 28px;"></td>
                    <td colspan="2" style="width: 171px; height: 28px;">
                        <asp:TextBox ID="txt_branchname" runat="server" Width="249px" BorderColor="#E0E0E0" BorderStyle="Ridge"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 26px">Disciplinary Action Taken By</td>
                    <td style="width: 149px; height: 26px;"></td>
                    <td colspan="2" style="width: 171px; height: 26px;">
                        <asp:DropDownList ID="drpdwn_discpl_tkn_by" runat="server" Width="254px" AppendDataBoundItems="True" Font-Bold="False" Font-Size="Smaller" ForeColor="Black" Font-Overline="False" Font-Strikeout="False">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 26px">Select Disciplinary Action Type</td>
                    <td style="width: 149px; height: 26px;"></td>
                    <td colspan="2" style="width: 171px; height: 26px;">
                        <asp:DropDownList ID="drpdwn_discpl_type" runat="server" Width="256px" ForeColor="Black">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 18px">Period For Disciplinary Action Taken</td>
                    <td style="width: 149px; height: 18px"></td>
                    <td colspan="2" style="width: 171px; height: 18px">
                        <asp:Panel ID="Panel1" runat="server">
                            <table style="width: 256px">
                                <tr>
                                    <td style="width: 100px; height: 7px">From</td>
                                    <td style="width: 96px; height: 7px">
                                        <asp:TextBox ID="txt_frmdate" runat="server" Width="79px" Height="18px" BorderStyle="Dotted"></asp:TextBox>
                                    </td>
                                    <td style="width: 100px; height: 7px">To</td>
                                    <td style="width: 100px; height: 7px">
                                        <asp:TextBox ID="txt_todate" runat="server" Width="73px" BorderStyle="Dotted"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 23px">
                        <asp:Button ID="btn_confirm" runat="server" Height="44px" Text="Confirm" Width="119px" BorderStyle="Dotted" />
                    </td>
                    <td style="width: 149px; height: 23px"></td>
                    <td colspan="2" style="width: 171px; height: 23px">
                        <input id="btn_exit" style="width: 99px; height: 47px" type="button" value="Exit" onclick="return btn_exit_onclick()" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_Punch_Regular_Form.aspx.vb" Inherits="WebAppHRMS.AnyTimePunching_New_hrm_Punch_Regular_Form_96f032a98813" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button2_onclick() 
{
  window.open('../home.aspx','_self')
}
var cont = master_no.split("rdb")
function ALL_LATE()
{
  if (document.getElementById(cont[0]+"rdb_All").checked==true)
  {
    window.open("hrm_attend_request.aspx","_self");
    return true;
   
  }
}

function INDI_LATE()
{
  if (document.getElementById(cont[0]+"rdb_Indi").checked==true)
  {
    window.open("hrm_AnyTimePunching.aspx","_self");
    return true;
   
  }
}

function NONMARKING()
{
  if (document.getElementById(cont[0]+"rdb_Nonmarking").checked==true)
  {
    window.open("hrm_Punch_request.aspx","_self");
    return true;
   
  }
}



// ]]>
</script>

    <div style="text-align: center">
        <table border="1" style="width: 530px; height: 138px">
            <tr>
                <td colspan="3" style="height: 26px">
                    <strong><span style="font-size: 14pt; color: #cc3300; text-decoration: underline">Punch
                        Regularisation Request</span></strong></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:RadioButton ID="rdb_All" runat="server" Font-Bold="False" ForeColor="#000040"
                        Text="All Employees Late" Width="163px" GroupName="a" /></td>
                <td style="width: 100px">
                    <asp:RadioButton ID="rdb_Indi" runat="server" ForeColor="#000040" Text="Individual Late"
                        Width="156px" GroupName="a" /></td>
                <td style="width: 100px">
                    <asp:RadioButton ID="rdb_Nonmarking" runat="server" ForeColor="#000040" Text="Non Marking"
                        Width="135px" GroupName="a" /></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 15px">
                    &nbsp;
                    <input id="Button2" style="font-size: 12pt; width: 102px; font-family: 'Times New Roman'"
                        type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
            </tr>
        </table>
    </div>
    <br />
</asp:Content>


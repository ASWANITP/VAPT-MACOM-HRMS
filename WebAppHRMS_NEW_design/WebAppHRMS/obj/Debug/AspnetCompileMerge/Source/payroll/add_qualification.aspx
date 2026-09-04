<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="add_qualification.aspx.vb" Inherits="WebAppHRMS.Add_Qualification_add_qualification_e63994605043" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function cmd_exit_onclick() {
        window.open('../home.aspx','_self');
}

// ]]>
</script>
 <div style="text-align: center">
     <br />
     <br />
    <table style="text-align:center";"width: 472px" >
        <tr>
            <td style="width: 171px; height: 21px">
                Select Category</td>
            <td style="width: 101px; height: 21px; text-align: left">
                <asp:DropDownList ID="cmb_category" runat="server" Width="444px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 171px">
                Enter Qualifciation :
            </td>
            <td style="width: 101px; text-align: left">
                <asp:TextBox ID="txt_qualification" runat="server" Width="440px" MaxLength="100"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="4">
          <div style="text-align: center;">
              <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="74px" />
              &nbsp;&nbsp;
  <input id="cmd_exit" style="width: 76px;" type="button" value="EXIT" onclick="return cmd_exit_onclick()" />
          </div>
      </td>

        </tr>
    </table>
    </div>
</asp:Content>


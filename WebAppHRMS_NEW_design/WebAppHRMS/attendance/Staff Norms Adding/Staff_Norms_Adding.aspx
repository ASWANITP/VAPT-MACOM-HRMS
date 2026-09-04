<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/edp.master" CodeBehind="Staff_Norms_Adding.aspx.vb"
    Inherits="Staff_Norms_Staff_Norms_Adding_bc84d0cd8953" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

   <script type="text/javascript">
      //for not allowing 0 norms
       function validateInput(element, evt)
       {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        var currentValue = element.value;

        if (currentValue.length === 0 && charCode === 48) {
            alert("Cannot enter '0' norms");
            setTimeout(function() {
                element.value = ''; 
            }, 10);
            evt.preventDefault();
            return false;
        } else if (charCode < 48 || charCode > 57) {
            alert("Please enter numbers only");
            setTimeout(function() {
                element.value = ''; 
            }, 10);
            evt.preventDefault();
            return false;
        }

        return true;
    }
</script>




    <div style="text-align: center">
        &nbsp;&nbsp;
        <table style="width: 416px; height: 136px" border="2">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl_hd" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Maroon"
                        Text="STAFF NORMS" Width="416px"></asp:Label><br />
                </td>
            </tr>
            <tr>
                <td style="width: 204px">
                    <asp:Label ID="lbl_Requirement" runat="server" Font-Bold="True" Text="REQUIREMENT"
                        Width="224px"></asp:Label>
                </td>
                <td style="width: 441px; text-align: left;">
                    <asp:TextBox ID="txt_Requirement" runat="server" Width="304px" MaxLength="5" onkeypress="return validateInput(this, event)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 204px">
                    <asp:Label ID="LBL_Department" runat="server" Font-Bold="True" Text="SELECT DEPARTMENT"
                        Width="224px"></asp:Label>
                </td>
                <td style="width: 441px; text-align: left;">
                    <asp:DropDownList ID="cmb_department" runat="server" Width="312px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <%--<tr>
                <td style="width: 204px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="SELECT BRANCH/FIELD"
                        Width="224px"></asp:Label>
                </td>
                <td style="width: 441px; text-align: left;">
                    <asp:DropDownList ID="cmb_branchfield" runat="server" Width="312px" AutoPostBack="True">
                        <asp:ListItem Text="----------Select--------" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Branch" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Field" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>--%>
            <tr>
                <td style="width: 204px">
                    <asp:Label ID="lbl_short" runat="server" Font-Bold="True" Text="SHORT" Width="224px"></asp:Label>
                </td>
                <td style="width: 441px; text-align: left;">
                    <asp:TextBox ID="txt_short" runat="server" Width="304px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 204px">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="EXCESS" Width="224px"></asp:Label>
                </td>
                <td style="width: 441px; text-align: left;">
                    <asp:TextBox ID="txt_excess" runat="server" Width="304px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 204px">
                    <asp:Label ID="lbl_Actual" runat="server" Font-Bold="True" Text="ACTUAL" Width="224px"></asp:Label>
                </td>
                <td style="width: 441px; text-align: left;">
                    <asp:TextBox ID="txt_ActualCount" runat="server" Width="304px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 204px">
                </td>
                <td style="width: 441px; text-align: left">
                </td>
            </tr>
        </table>
        <asp:Button ID="btn_conf" runat="server" Text="Confirm" Width="75px" OnClick="btn_conf_Click"
            Font-Bold="True" />
        <asp:Button ID="cmb_exit" runat="server" Text="Exit" Width="75px" OnClick="cmb_exit_Click"
            Font-Bold="True" />
    </div>
</asp:Content>

<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="PancardApproval.aspx.vb" Inherits="WebAppHRMS.PancardApproval_be8aeb5e2729" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">


    <script type="text/javascript">

        function fill_res() {
            var arg;
            arg = 9 + "$" + document.getElementById(cont[0] + "DropDownList1").value;
            sub_call_server(arg, 2);
        }
    </script>


    <%--<div style="text-align: center">
                    &nbsp;</div>--%>



    <div style="text-align: center">
        <table border="1" style="width: 656px; height: 72px; margin: 0 auto;">
            <tr>
                <td colspan="4" style="height: 34px">
                    <strong><span style="font-size: 14pt; color: #990099; font-family: Courier New; text-decoration: underline;">PANCARD APPROVAL </span></strong>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Employee Code & Name</span>
                </td>


                <td style="width: 100px; height: 7px; text-align: left">
                    <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server" AutoPostBack="True" Width="304px" Height="26px">
                        <%--<asp:ListItem Text="Option 1" Value="1"></asp:ListItem>
                           <asp:ListItem Text="Option 2" Value="2"></asp:ListItem>
                           <asp:ListItem Text="Option 3" Value="3"></asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>


            <tr>
                <td style="width: 90px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Old PAN Card Number</span>
                </td>
                <td colspan="3" style="width: 60px; height: 7px; text-align: center;">
                    <asp:TextBox ID="txt_oldpan" Style="width: 300px; font-family: 'Courier New';" type="text"
                        runat="server" ReadOnly="true" />


                </td>

            </tr>








            <tr>
                <td style="width: 90px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Updated PAN Card Number</span>
                </td>
                <td colspan="3" style="width: 60px; height: 7px; text-align: center;">
                    <asp:TextBox ID="txt_pan" Style="width: 300px; font-family: 'Courier New';" type="text"
                        runat="server" ReadOnly="true" />


                </td>

            </tr>

            <tr>
                <%--<td colspan="4" style="width: 100%; height: 7px; text-align: center">
                 <asp:Panel ID="mypanel" runat="server">
                    <span style="font-size: 11pt; font-family: Courier New">BROWSE : </span>
                    <asp:FileUpload ID="Upload" runat="server" />
                          <asp:Button ID="btnUpload" runat="server" Text="Upload" />

      <asp:Label foreColor="red" ID="lblError" runat="server" Visible="false" />
      </asp:Panel>
                    </td>--%>
            </tr>
            <tr>
                <td colspan="5" style="text-align: center; height: 50px;">


                    <asp:Button ID="btnview" runat="server" Text="VIEW" Width="140px" Height="25px" Style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" />&nbsp;
                    
                    <asp:Button ID="btnapprove" runat="server" Text="APPROVE" Width="140px" Height="25px" Style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" />&nbsp;
                    
                       <asp:Button ID="btnreject" runat="server" Text="REJECT" Width="140px" Height="25px" Style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" />&nbsp;
                    
                    <asp:Button ID="btnext" runat="server" Text="Exit" Width="140px" Height="25px" Style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" />&nbsp;
                    
                    
                    
                </td>
            </tr>
        </table>
    </div>











</asp:Content>


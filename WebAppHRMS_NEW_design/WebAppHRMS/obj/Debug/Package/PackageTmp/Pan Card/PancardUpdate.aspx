<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="PancardUpdate.aspx.vb" Inherits="WebAppHRMS.PancardUpdate_6286795c1835" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">


    <script type="text/javascript">

        function fill_res() {
            var arg;
            arg = 9 + "$" + document.getElementById(cont[0] + "DropDownList1").value;
            sub_call_server(arg, 2);
        }


        function enableEdit() {
            var newRow = document.getElementById("newPanRow");
            newRow.style.display = "table-row";
        }




    </script>

    <div style="text-align: center">
        <table border="1" style="width: 500px; height: 72px; margin: 0 auto;">
            <tr>
                <td colspan="6" style="height: 34px">
                    <strong><span style="font-size: 14pt; color: #990099; font-family: Courier New; text-decoration: underline;">PANCARD UPDATION </span></strong>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Employee Code</span>
                </td>
                <td style="width: 100px; height: 7px; text-align: center;">

                    <asp:TextBox ID="txt_ecode" ReadOnly="True" runat="server" Style="width: 260px; font-family: 'Courier New';" />

                </td>

            </tr>

            <tr>
                <td style="width: 100px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Employee Name</span>
                </td>
                <td style="width: 100px; height: 7px; text-align: center;">

                    <asp:TextBox ID="txt_ename" ReadOnly="True" runat="server" Style="width: 260px; font-family: 'Courier New';" />

                </td>

            </tr>


            <tr>
                <td colspan="1" style="width: 100px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">PAN card No.</span>
                </td>
                <td colspan="1" style="width: 80px; height: 7px; text-align: center;">

                    <asp:TextBox ID="txt_pan" ReadOnly="True" runat="server" Style="width: 260px; font-family: 'Courier New';" />



                    <%--<asp:Button ID="btnedt" runat="server" Text="Add" Width="40px" height="22px" style="font-family: 'Courier New'" BackColor="Gainsboro" 
                    Font-Bold="True" OnClientClick="enableEdit(); return false;"  />--%>

                    <asp:Button ID="btnedt" runat="server" Text="Add" Width="140px" Height="25px" Style="font-family: 'Courier New'"
                        BackColor="Gainsboro" Font-Bold="True" OnClientClick="enableEdit(); return false;" />

                </td>
            </tr>
            <tr id="newPanRow" style="display: none;">
                <td style="width: 106px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Enter PAN Card No.</span>
                </td>
                <td colspan="3" style="width: 100px; height: 7px; text-align: center;">

                    <asp:TextBox ID="new_txt_pan" ReadOnly="false" MaxLength="10" runat="server" Style="width: 260px; font-family: 'Courier New';" />

                </td>

            </tr>
            <tr>

                <td style="width: 106px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Upload File</span>
                </td>
                <%--<td colspan="3" style="width: 100px; height: 7px; text-align: center;">
                    <asp:FileUpload ID="Upload" runat="server" Width="356px"  />
                </td>--%>
                <td colspan="3" style="width: 100px; height: 7px; text-align: center;">
                    <div style="width: 100%; display: flex; justify-content: center; margin-left: 45px;">
                        <asp:FileUpload ID="Upload" runat="server" Width="356px" />
                    </div>
                </td>

            </tr>
            <tr>
                <td colspan="5" style="text-align: center; height: 50px;">


                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="140px" Height="25px" Style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" />&nbsp;
                    
                    <asp:Button ID="cmd_exit" runat="server" Text="EXIT" Width="140px" Height="25px" Style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" />&nbsp;
                    
                    
                    
                </td>
            </tr>
        </table>
    </div>











</asp:Content>


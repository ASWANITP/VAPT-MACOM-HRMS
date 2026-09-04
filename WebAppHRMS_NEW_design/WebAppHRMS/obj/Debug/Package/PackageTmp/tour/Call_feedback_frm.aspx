<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Call_feedback_frm.aspx.vb" Inherits="WebAppHRMS.tour_Call_feedback_frm_4947bfe85815" %>

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




        function convertToUpperCase(textBox) {
            // Get the current cursor position
            var startPos = textBox.selectionStart;

            // Convert the text to uppercase
            textBox.value = textBox.value.toUpperCase();

            // Restore the cursor position
            textBox.setSelectionRange(startPos, startPos);
        }
    </script>


    <%--<div style="text-align: center">
                    &nbsp;</div>--%>
    <div style="text-align: center">
        <table border="1" style="width: 656px; height: 72px; margin: 0 auto;">
            <tr>
                <td colspan="6" style="height: 34px">
                    <strong><span style="font-size: 14pt; color: #990099; font-family: Courier New; text-decoration: underline;">CALL FEEDBACK FORM </span></strong>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Employee Code</span>
                </td>
                <td style="width: 100px; height: 7px; text-align: center;">
                    <%--<input id="txt_ecode" style="width: 260px; font-family: 'Courier New';" type="text"
                        runat="server" readonly="readonly" />--%>

                    <asp:TextBox ID="txt_ecode" ReadOnly="True" runat="server" Style="width: 260px; font-family: 'Courier New';" />

                </td>

            </tr>

            <tr>
                <td style="width: 100px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Employee Name</span>
                </td>
                <td style="width: 100px; height: 7px; text-align: center;">
                    <%--<input id="txt_ecode" style="width: 260px; font-family: 'Courier New';" type="text"
                        runat="server" readonly="readonly" />--%>

                    <asp:TextBox ID="txt_ename" ReadOnly="True" runat="server" Style="width: 260px; font-family: 'Courier New';" />

                </td>

            </tr>
            <tr>
                <td style="width: 100px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">SR TICKET NO</span>
                </td>
                <td colspan="1" style="width: 80px; height: 7px; text-align: center;">
                    <%--<input id="txt_pan" style="width: 260px; font-family: 'Courier New';" type="text"
                        runat="server" readonly="readonly" />--%>

                    <asp:TextBox ID="sr_tckt" ReadOnly="False" runat="server" Style="width: 260px; font-family: 'Courier New';" />


                </td>

                <%--    <td>
                    
                    <asp:Button ID="btnedt" runat="server" Text="Add" Width="40px" height="22px" style="font-family: 'Courier New'" BackColor="Gainsboro" Font-Bold="True" OnClientClick="enableEdit(); return false;"  />&nbsp;
                    
                    
                    
                    
                </td>--%>
            </tr>
            <%-- <tr id="newPanRow" style="display:none;">
                <td style="width: 106px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Enter PAN Card Number</span>
                </td>
              <td colspan="3" style="width: 100px; height: 7px; text-align: center;">--%>
            <%-- <input id="new_txt_pan" style="width: 260px; font-family: 'Courier New'"  type="text" />--%>
            <%--
               <asp:TextBox ID="new_txt_pan" ReadOnly="false" MaxLength="10" onkeyup="convertToUpperCase(this)" runat="server" style="width: 260px; font-family: 'Courier New';"/>
              
                </td>--%>



            <%--      
            </tr>--%>
            <tr>
                <%--<td colspan="4" style="width: 100%; height: 7px; text-align: center">
                 <asp:Panel ID="mypanel" runat="server">
                    <span style="font-size: 11pt; font-family: Courier New">BROWSE : </span>
                    <asp:FileUpload ID="Upload" runat="server" />
                          <asp:Button ID="btnUpload" runat="server" Text="Upload" />

      <asp:Label foreColor="red" ID="lblError" runat="server" Visible="false" />
      </asp:Panel>
                    </td>--%>
                <td style="width: 106px; height: 7px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Upload File</span>
                </td>
                <td colspan="3" style="width: 100px; height: 7px; text-align: center;">
                    <asp:FileUpload ID="Upload" runat="server" Width="356px" />
                </td>
                <%-- <td style="width: 25%; height: 7px; text-align: center;">
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" Width="101px" />
                </td>--%>
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

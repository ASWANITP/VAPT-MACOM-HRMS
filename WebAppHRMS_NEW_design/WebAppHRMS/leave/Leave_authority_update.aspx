<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Leave_authority_update.aspx.vb" EnableEventValidation="false" Inherits="WebAppHRMS.Leave_authority_update_92d2c3028449" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script type="text/javascript">
        function isNumberKey(event) {
            var charcode = (event.which) ? event.which : event.keyCode
            if (charcode > 31 && (charcode < 48 || charcode > 57)) return false;
            else return true;
        }

        function blockSpecialChar(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k >= 48 && k <= 57));
        }

        function Button1_onclick() {
            window.open('../home.aspx', '_self');
        }


    </script>
    <div style="text-align: center">
        <table border="1" style="width: 63px; height: 1px">
            <tr>
                <td colspan="3" style="height: 19px">
                    <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="13pt" Text="Add / Modify Sanction authority"></asp:Label><br />
                </td>
            </tr>
            <tr>
                <td style="width: 243px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Leave Type</span></td>
                <td colspan="2" style="height: 1px; width: 412px; text-align: left;">
                    <asp:DropDownList ID="cmb_leaveype" runat="server" Width="350px" Font-Bold="False" Style="font-size: 11pt; font-family: 'Courier New'" AutoPostBack="True" BackColor="White">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 243px; text-align: left; height: 22px;">
                    <span style="font-size: 11pt; font-family: Courier New">Post</span></td>
                <td colspan="2" style="height: 22px; width: 412px; text-align: left;">
                    <asp:DropDownList ID="cmb_post" runat="server" Width="350px" Font-Bold="False" Style="font-size: 11pt; font-family: 'Courier New'" AutoPostBack="True" BackColor="White">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 243px; height: 1px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Branch</span></td>
                <td colspan="2" style="height: 1px; width: 412px; text-align: left;">
                    <asp:DropDownList ID="cmbBranch" runat="server" Width="350px" Font-Bold="False" Style="font-size: 11pt; font-family: 'Courier New'" Enabled="False">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 243px; height: 1px; text-align: left">
                    <span style="font-size: 10pt; font-family: Courier New">Department</span></td>
                <td colspan="2" style="height: 1px; text-align: left; width: 412px;">
                    <asp:DropDownList ID="cmb_department" runat="server" Width="350px" Font-Bold="False" Style="font-size: 11pt; font-family: 'Courier New'" Enabled="False">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 243px; text-align: left; height: 17px;">
                    <span style="font-size: 11pt; font-family: Courier New"></span></td>
                <td colspan="2" style="text-align: left; height: 17px; width: 412px;"></td>
            </tr>
            <tr id='row1'>
                <td style="width: 243px; height: 17px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">First Recommend</span></td>
                <td colspan="2" style="height: 17px; text-align: left; width: 412px;">
                    <asp:TextBox ID="txtRec1" runat="server" MaxLength="6" onkeypress="return blockSpecialChar(event)" AutoPostBack="True"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Label ID="lblrec1" runat="server"></asp:Label></td>
            </tr>
            <tr id='row2'>
                <td style="width: 243px; height: 17px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New" class="Recommend">Second Recommend</span></td>
                <td colspan="2" style="height: 17px; text-align: left; width: 412px;">
                    <asp:TextBox ID="txtRec2" runat="server" MaxLength="6" onkeypress="return blockSpecialChar(event)" AutoPostBack="True"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Label ID="lblrec2" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 243px; height: 17px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New">Sanction</span></td>
                <td colspan="2" style="height: 17px; text-align: left; width: 412px;">
                    <asp:TextBox ID="txtSanc" runat="server" MaxLength="6" onkeypress="return blockSpecialChar(event)" AutoPostBack="True"></asp:TextBox>
                    &nbsp;&nbsp;
                    <asp:Label ID="lblsanc" runat="server"></asp:Label></td>
            </tr>
            <%-- <tr>
                    <td style="width: 187px; height: 15px; text-align: left;">
                        <span style="font-size: 11pt; font-family: Courier New; color: #3300ff;">Leave&nbsp;</span></td>
                    <td style="width: 100px; height: 15px;">
                        </td>
                    <td style="width: 122px; height: 15px;" colspan="2">
                        <span style="font-size: 11pt; font-family: Courier New; color: #3300ff;">Leave&nbsp;</span></td>
                <td style="width: 100px; height: 15px; font-size: 12pt;">
                    </td>
            </tr>
            <tr>
                <td style="width: 187px; height: 15px; text-align: left">
                    <span style="font-size: 11pt; font-family: Courier New"><span style="color: #3300ff">
                        </span> </span>
                </td>
                <td style="width: 100px; height: 15px; text-align: left">
                    <asp:TextBox ID="txt_req_days1" runat="server" BackColor="MintCream" Font-Names="Courier New"
                        ForeColor="Blue" ReadOnly="True" Width="155px"></asp:TextBox></td>
                <td colspan="2" style="width: 122px; height: 15px">
                    &nbsp;
                </td>
                <td style="font-size: 12pt; width: 100px; height: 15px">
                    &nbsp;
                </td>
            </tr>--%>
            <tr>
                <td style="width: 243px; height: 17px; text-align: left"></td>
                <td colspan="2" style="height: 17px; text-align: left; width: 412px;"></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 1px; text-align: center">
                    <div style="text-align: center">
                        <table border="0" style="width: 386px; height: 37px">
                            <tr>
                                <td colspan="2" style="height: 31px"></td>
                                <td style="width: 100px; height: 31px;">
                                    <asp:Button ID="btnConfirm" runat="server" Height="28px" Text="Confirm" Width="96px" /></td>
                                <td style="width: 100px; height: 31px;">
                                    <asp:Button ID="btnReset" runat="server" Height="28px" Text="Reset" Width="96px" /></td>
                                <td style="width: 100px; height: 31px;">
                                    <input id="Button1" onclick="return Button1_onclick()" style="width: 96px; height: 28px"
                                        type="button" value="Exit" /></td>
                            </tr>
                        </table>
                    </div>
                    <asp:Label ID="Label1" runat="server" Width="574px" ForeColor="Maroon"></asp:Label></td>
            </tr>
        </table>
        <div style="text-align: center">
            <br />
            <asp:Label ID="lblheading" runat="server" Font-Bold="True" Font-Size="13pt" Text="Leave Sanction Authority List" Height="24px"></asp:Label><br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="10pt">
                <Columns>
                    <asp:BoundField DataField="Slno" HeaderText="Slno" />
                    <asp:BoundField DataField="Post" HeaderText="Post">
                        <ControlStyle Width="225px" />
                        <ItemStyle HorizontalAlign="Left" Width="225px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="leave_type" HeaderText="Leave Type" Visible="False" />
                    <asp:BoundField DataField="Days_From" HeaderText="Days From" />
                    <asp:BoundField DataField="Days_To" HeaderText="Days To" />
                    <asp:BoundField DataField="Branch" HeaderText="Branch">
                        <ControlStyle Width="200px" />
                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="First_Recommend" HeaderText="First Recommend" />
                    <asp:BoundField DataField="Second_Recommend" HeaderText="Second Recommend" />
                    <asp:BoundField DataField="sanction" HeaderText="Sanction" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <RowStyle ForeColor="#000066" />
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
            &nbsp;
            &nbsp; &nbsp; &nbsp;
            <asp:TextBox ID="txtSelect" runat="server" Visible="False" Width="1px"></asp:TextBox>
        </div>
        &nbsp; &nbsp; &nbsp;&nbsp;
    </div>
</asp:Content>


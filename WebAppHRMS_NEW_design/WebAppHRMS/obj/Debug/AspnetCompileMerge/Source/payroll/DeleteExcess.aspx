<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="DeleteExcess.aspx.vb" Inherits="WebAppHRMS.leave_DeleteExcess_4cbca43e9365" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button3_onclick() {
window.open ('../home.aspx','_self');
}
function isNumberKey(event)
{
    var charcode = (event.which) ? event.which : event.keyCode
    if (charcode > 31 && (charcode < 48 || charcode > 57  ))  return false;
    else                                                      return true; 
} 

// ]]>
</script>

    <div style="text-align: center">
        <table border="1">
            <tr>
                <td align="center" colspan="2" style="font-weight: bold">
                    Delete Excess Allowance &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" >
                </td>
                <td >
                </td>
            </tr>
            <tr>
                <td  align="right">
                    Select Allowance</td>
                <td align="left" >
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="254px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" >
                    Employee Code</td>
                <td align="left" >
                    <asp:TextBox ID="txt_empcode" runat="server" MaxLength="7" Width="175px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="Button2" runat="server" Text="Show" /></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="43px" DataKeyNames="tablenm,all_id">
                        <Columns>
                            <asp:BoundField DataField="all_name" HeaderText="Allowance">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Employee Code" DataField="emp_code" >
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Employee Name" DataField="emp_name" >
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="amount" HeaderText="Amount">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Delete">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="tablenm" HeaderText="Table" Visible="False" />
                            <asp:BoundField DataField="all_id" HeaderText="All_id" Visible="False" />
                        </Columns>
                    </asp:GridView>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td  align="center" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Confirm" />
                    <input id="Button3" type="button" value="Exit" onclick="return Button3_onclick()" style="width: 66px" /></td>
            </tr>
        </table>
    </div>
</asp:Content>


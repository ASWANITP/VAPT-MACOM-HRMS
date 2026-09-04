<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="new_block_employ_first.aspx.vb" Inherits="WebAppHRMS.new_punch_bloc_rpt_new_block_employ_844ec3658338" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[


function Reset1_onclick() {
window.open('../home.aspx','_self');
}

// ]]>
</script>

    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                <table border="1" style="position: relative; left: 3px; width: 518px; top: 2px; height: 12px;">
                    <caption>
                        <asp:ScriptManager id="ScriptManager1" runat="server">
                        </asp:ScriptManager><strong><span style="font-size: 16pt"><cc1:CalendarExtender ID="CalendarExtender1"
                            runat="server" Format="dd/MMM/yyyy" TargetControlID="txt_month">
                        </cc1:CalendarExtender>
                            &nbsp;
                            Individual Punching Block
                            Report</span></strong></caption>
                    <tr>
                        <td colspan="1" style="height: 1px">
                            <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;Enter Your Employee Code&nbsp;</strong></td>
                        <td style="width: 100px; height: 1px; text-align: left">
                            <asp:TextBox ID="txt_month" runat="server" Style="position: relative; left: 1px; top: 34px;" Width="161px" Height="18px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="height: 2px">
                            <strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp;&nbsp; &nbsp; Enter the date of month &nbsp;</strong></td>
                        <td style="width: 100px; text-align: left; height: 2px;">
                            <asp:TextBox ID="emp_txt" runat="server" Style="position: relative; top: -33px; left: 0px;" Width="161px" Height="20px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="height: 2px;" colspan="2">
                            <asp:Button ID="Button1" runat="server" Style="left: 34px; position: relative; top: 0px"
                                Text="Confirm" Height="25px" />
                            &nbsp; &nbsp; &nbsp;
                            <input id="Reset1" style="position: relative; left: 9px; width: 55px; top: 0px;" type="reset" value="Exit" onclick="return Reset1_onclick()" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>


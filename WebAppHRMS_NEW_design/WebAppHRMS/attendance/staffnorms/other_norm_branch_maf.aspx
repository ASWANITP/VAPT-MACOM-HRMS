<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="other_norm_branch_maf.aspx.vb" Inherits="WebAppHRMS.audit_staffnorm_audit_norm_cf88f00a9584" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function btn_exit_onclick() {
            window.open('../../home.aspx', '_self');

        }
        function NumericCheck() {
            var charcode = (event.which) ? event.which : event.keyCode
            if ((charcode < 46 || charcode > 57)) {
                window.event.cancelBubble = true;
                window.event.keyCode = 0;
                return false;
            }
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                <table border="1">
                    <caption>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </caption>
                    <tr>
                        <td colspan="2">SELECT BRANCH</td>
                        <td style="text-align: left;" colspan="3">
                            <asp:DropDownList ID="drpdwn_region" runat="server" Width="422px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                        <td colspan="3">
                            <asp:Button ID="btn_confirm" runat="server" Text="CONFIRM" Width="123px" />
                            <input id="btn_exit" style="width: 120px" type="button" value="EXIT" onclick="return btn_exit_onclick()" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Photo_report_select.aspx.vb" Inherits="WebAppHRMS.Honey_Photo_upload_Photo_report_select_fb07c3931947" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">



    <script language="javascript" type="text/javascript">

        var con = header.split('txt');
        function DateFCheck() {
            alert('Please Select date Using Calendar..!!');
            document.getElementById(con[0] + "txt_frdt").value = "";
            return false;
        }
        function DateTCheck() {
            alert('Please Select date Using Calendar..!!');
            document.getElementById(con[0] + "txt_todt").value = "";
            return false;
        }

        function OnConfClick() {

            if (document.getElementById(con[0] + "txt_frdt").value == "") {
                alert("Please select from date..!");
                document.getElementById(con[0] + "txtsslc").focus();
                return false;
            }
            if (document.getElementById(con[0] + "txt_todt").value == "") {
                alert("Please Select TO Date...!");
                document.getElementById(con[0] + "txtDate").focus();
                return false;
            }
        }

    </script>



    <div style="text-align: center">
        <table border="1">
            <caption>
                <strong>PHOTO VARIFIED REPORT<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                </strong>
            </caption>
            <tr>
                <td style="width: 100px; height: 13px">From Date</td>
                <td style="width: 100px; height: 13px">
                    <asp:Panel ID="Panel1" runat="server" Height="20px" Width="125px">
                        <asp:TextBox ID="txt_frdt" runat="server" onkeyup="DateFCheck()"></asp:TextBox>
                    </asp:Panel>
                </td>
                <td style="width: 100px; height: 13px">TO Date</td>
                <td style="width: 100px; height: 13px">
                    <asp:Panel ID="Panel2" runat="server" Height="20px" Width="125px">
                        <asp:TextBox ID="txt_todt" runat="server" onkeyup="DateTCheck()"></asp:TextBox>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width: 100px"></td>
                <td style="width: 100px">
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_frdt" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                </td>
                <td style="width: 100px"></td>
                <td style="width: 100px">
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_todt" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 34px"></td>
                <td style="width: 100px; height: 34px">
                    <asp:Button ID="btn_confirm" runat="server" Height="31px" Text="Confirm" Width="145px" OnClientClick="return OnConfClick()" /></td>
                <td style="width: 100px; height: 34px"></td>
                <td style="width: 100px; height: 34px">
                    <asp:Button ID="btn_Exit" runat="server" Height="31px" Text="Exit" Width="139px" Font-Bold="True" /></td>
            </tr>
        </table>
    </div>
</asp:Content>


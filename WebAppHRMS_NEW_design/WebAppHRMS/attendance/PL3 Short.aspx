<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="PL3 Short.aspx.vb" Inherits="WebAppHRMS.HRM_PL3_Short_28f326cb8942" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        var cont_name = header_txt.split('txt');

        function onConfClick() {
            if (document.getElementById(cont_name[0] + "txtdate").value == "") {
                alert('Please Select Date...!!');
                document.getElementById(cont_name[0] + "txtdate").focus();
                return false;
            }
        }

        function checkValue() {
            if (cal._selectedDate > new Date()) {
                alert("Please select a earlier day!");
                cal.show();
            }
        }

        function checkDate(sender, args) {

            if (sender._selectedDate >= new Date())
            //          and (sender._selectedDate = new Date())
            {
                alert("You cannot select a day Future than today!");

                //                sender._selectedDate = new Date();
                // set the date back to the current date
                //                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
                document.getElementById(cont_name[0] + "txtdate").value = "";
            }
        }

        var cal;
        function pageLoad() {
            cal = $find("<%=CalendarExtender1.ClientID%>");
            cal.add_hidden(checkValue);
        }
    </script>
    <div style="text-align: center">
        <table style="width: 60%; position: relative">
            <tr>
                <td style="width: 20%"></td>
                <td style="width: 20%; font-weight: bold; color: black; font-style: normal; font-family: 'Times New Roman'; font-variant: normal; text-decoration: none;">DEPARTMENT SHORT</td>
                <td style="width: 20%"></td>
            </tr>
            <tr>
                <td style="width: 20%; font-weight: bold; font-family: 'Times New Roman'; height: 8px;"></td>
                <td style="width: 20%; height: 8px;"></td>
                <td style="width: 20%; height: 8px;"></td>
            </tr>
            <tr>
                <td style="width: 20%; font-weight: bold; font-family: 'Times New Roman'; height: 26px;">From Date</td>
                <td style="width: 20%; height: 26px;">
                    <asp:TextBox ID="txtdate" runat="server" Style="position: relative" Width="95%"></asp:TextBox></td>
                <td style="width: 20%; height: 26px;">
                    <asp:Button ID="btnconfrm" runat="server" Style="position: relative; font-weight: bold; left: -86px; top: 0px;" Text="CONFIRM" OnClientClick="return onConfClick()" /></td>
            </tr>
            <tr>
                <td colspan="3"></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 21px"></td>
            </tr>
        </table>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdate" Format="dd/MMM/yyyy" OnClientDateSelectionChanged="checkDate"></cc1:CalendarExtender>
</asp:Content>


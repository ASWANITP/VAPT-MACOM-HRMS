<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Update_NewBranch_Date.aspx.vb" Inherits="WebAppHRMS.EXTRAFORMS_Update_NewBranch_Date_f1df9c845687" Title="Untitled Page" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">

        var cont = loanno.split('txt')
        function Button2_onclick() { window.open('../home.aspx', '_self'); }
        function OnkeyUpChqDate(Control) {
            alert("Select Date from Calender ..!!!!");
            document.getElementById(cont[0] + "txt_Date").value = ""
            return false
        }

        function OnClickRadioConfirm() {
            document.getElementById(cont[0] + "rbt_Tendative").checked = false;
            document.getElementById(cont[0] + "rbt_Confirmation").checked = true;
            document.getElementById(cont[0] + "txt_Date").value = ""
            document.getElementById(cont[0] + "lblDate").innerHTML = "Confirmation"
            var Status = "-22";
            ToServer(Status + "#" + 1, 1)
        }

        function OnClickRadioTendative() {
            document.getElementById(cont[0] + "rbt_Tendative").checked = true;
            document.getElementById(cont[0] + "rbt_Confirmation").checked = false;
            document.getElementById(cont[0] + "txt_Date").value = ""
            document.getElementById(cont[0] + "lblDate").innerHTML = "Tendative"
            var Status = "-11";
            ToServer(Status + "#" + 1, 1)
        }
        function OnClickConfirm() {
            var EffDate = document.getElementById(cont[0] + "txt_Date").value;
            var OldId = document.getElementById(cont[0] + "cmb_Branch").value;
            if (document.getElementById(cont[0] + "rbt_Tendative").checked == true)
                Status = 1;
            if (document.getElementById(cont[0] + "rbt_Confirmation").checked == true)
                Status = 2;

            if (EffDate == "") { alert("Select Date from Calender ..!!!"); document.getElementById(cont[0] + "txt_Date").focus(); return false; }
            if (document.getElementById(cont[0] + "cmb_Branch").options.length == 0) { alert("No Branch to Confirm..!!!"); return false; }
            ToData = EffDate + "%" + OldId + "%" + Status;
            ToServer(ToData + "#" + 2, 2)
        }



        function FromServer(arg, context) {
            var Data = arg.split("@")
            switch (context) {
                case 1:

                    document.getElementById(cont[0] + "cmb_Branch").options.length = 0;
                    if (Data[0] == "") { alert("No Branch ..!!!"); return false }
                    ComboFill(Data[0], "cmb_Branch");
                    break;
                case 2:
                    alert(arg)
                    window.open('Update_NewBranch_Date.aspx', '_self');
                    break;
            }
        }

        function ComboFill(Data, ComboName) {
            if (Data[0] == '') return;
            var rows = Data.split("█");
            for (a = 0; a < rows.length; a++) {
                var cols = rows[a].split("$");
                var option1 = document.createElement("OPTION");
                option1.value = cols[0];
                option1.text = cols[1];
                document.getElementById(cont[0] + ComboName).add(option1);
            }
        }
    </script>

    <div style="text-align: center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="width: 60%">
            <tr>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td style="width: 20%; text-align: right;">
                    <asp:RadioButton ID="rbt_Tendative" Text="Tendative" runat="server" Width="131px" /></td>
                <td style="width: 20%; text-align: left;">
                    <asp:RadioButton ID="rbt_Confirmation" Text="Cofirmation" runat="server" Width="131px" />
                &nbsp;
            </tr>
            <tr>
                <td style="width: 20%">Select Branch</td>
                <td style="width: 20%">
                    <asp:DropDownList ID="cmb_Branch" runat="server" Width="188px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 20%">
                    <asp:Label ID="lblDate" runat="server" Width="56px"></asp:Label>&nbsp; Date</td>
                <td style="width: 20%">
                    <asp:TextBox ID="txt_Date" runat="server" Width="181px" MaxLength="11"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 28px;" colspan="2">
                    <input id="btnUpdate" type="button" value="Update" onclick="OnClickConfirm()" />
                    <input id="Button2" style="width: 62px" type="button" value="Exit" onclick="return Button2_onclick()" /></td>
            </tr>
        </table>
        <div style="text-align: left">
            <asp:HiddenField ID="hdn_sysdate" runat="server" />
            &nbsp;&nbsp;<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                TargetControlID="txt_Date"></cc1:CalendarExtender>
        </div>
    </div>
</asp:Content>


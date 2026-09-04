<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Dep_Head_Updation.aspx.vb" Inherits="WebAppHRMS.pl3_Dep_Head_Updation_97e1dc308577" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var cont = master_no.split("txt")

        function Button2_onclick() {
            window.open('../home.aspx', '_self')
        }
        function FillSubDepartment() {
            data = document.getElementById(cont[0] + "cmb_Major").value;
            data = data + "%" + 222;
            ToServer(data + "#" + 1, 1);
        }
        function FillDepHead() {
            data = document.getElementById(cont[0] + "cmb_Sub").value;
            data = data + "%" + 999;
            ToServer(data + "#" + 2, 2);
        }
        function FillNewHeadName() {
            //      if(document.getElementById(cont[0]+"txt_NewHead").value=="" || document.getElementById(cont[0]+"txt_NewHead").value<10000)
            //      {
            //       alert("Enter Correct Employee Code");
            //       document.getElementById(cont[0]+"txt_NewHead").focus();
            //       return false;
            //      }
            data = document.getElementById(cont[0] + "txt_NewHead").value;
            data = data + "%" + 888;
            ToServer(data + "#" + 3, 3);
        }
        function ComboFill(Data, ComboName) {
            if (Data[0] == '') return;

            var rows = Data.split("*");
            for (a = 0; a < rows.length; a++) {
                var cols = rows[a].split("$");
                var option1 = document.createElement("OPTION");
                option1.value = cols[0];
                option1.text = cols[1];
                document.getElementById(cont[0] + ComboName).add(option1);
            }

        }

        function FromServer(arg, context) {
            var Data = arg.split("@");
            //debugger;  
            switch (context) {

                case 1:
                    document.getElementById(cont[0] + "cmb_Sub").options.length = 0;
                    if (Data[0] == "") { alert("No Details ..!!!"); return false; }
                    ComboFill(Data[0], "cmb_Sub");
                    document.getElementById(cont[0] + "txt_DepHead").value = Data[1];
                    break;


                case 2:

                    document.getElementById(cont[0] + "txt_DepHead").value = Data[0];
                    break;

                case 3:
                    if (Data[0] == "") { alert("No Such Employee...!!!"); return false; }
                    document.getElementById(cont[0] + "txt_Name").value = Data[0];
                    break;

                case 4:
                    alert(arg);
                    window.open('Dep_Head_Updation.aspx?key=175', '_self');
                    break;

            }
        }


        function OnClickConfirm() {

            //debugger;

            if (document.getElementById(cont[0] + "txt_NewHead").value == "" || document.getElementById(cont[0] + "txt_NewHead").value < 10000) {
                alert("Enter New Head...!!!");
                document.getElementById(cont[0] + "txt_NewHead").focus();
                return false;
            }
            if (document.getElementById(cont[0] + "cmb_Major").value == 0 || document.getElementById(cont[0] + "cmb_Sub").value == 0) {
                alert("Select Department...!!!");
                return false;
            }
            if (document.getElementById(cont[0] + "txt_Name").value == "") {
                alert("Enter Correct Employee Code...!!!");
                return false;
            }
            var depid = document.getElementById(cont[0] + "cmb_Sub").value;
            var headid = document.getElementById(cont[0] + "txt_NewHead").value;
            ToData = depid + "%" + headid;
            ToServer(ToData + "#" + 4, 4)
        }
        function isNumberKey(ids) {
            var charcode = (event.which) ? event.which : event.keyCode
            if (ids == 3) {
                if (charcode > 31 && (charcode < 48 || charcode > 57)) {
                    return false;
                }
                else
                    return true;
            }

        }
        // ]]>
    </script>

    <div style="text-align: center">
        <table border="1" style="width: 49%; height: 104px;">
            <tr>
                <td colspan="2">&nbsp;Major&nbsp;Department</td>
                <td style="text-align: left;" colspan="2">
                    <asp:DropDownList ID="cmb_Major" runat="server" onchange="FillSubDepartment()" Width="272px" Font-Names="Times New Roman" Font-Size="Medium">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;Sub&nbsp;Department</td>
                <td colspan="2">
                    <asp:DropDownList ID="cmb_Sub" runat="server" onchange="FillDepHead()" Width="272px" Font-Names="Times New Roman" Font-Size="Medium">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2">Current&nbsp;Department&nbsp;Head</td>
                <td style="text-align: left;" colspan="2">
                    <asp:TextBox ID="txt_DepHead" runat="server" Width="264px" Font-Names="Times New Roman" Font-Size="Medium" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">Enter&nbsp;Emp&nbsp;Code&nbsp;of&nbsp;New&nbsp;Head</td>
                <td colspan="2">
                    <asp:TextBox ID="txt_NewHead" runat="server" onkeypress="return isNumberKey(3)" onblur="FillNewHeadName()" Width="264px" Font-Names="Times New Roman" Font-Size="Medium" MaxLength="6"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">New Head Name</td>
                <td colspan="2">
                    <asp:TextBox ID="txt_Name" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                        ReadOnly="True" Width="264px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <input id="btn_Confirm" onclick="return OnClickConfirm()"
                        style="font-size: 12pt; font-family: 'Times New Roman'" type="button"
                        value="Confirm" />
                    <input id="Button2" style="font-size: 12pt; width: 72px; font-family: 'Times New Roman'"
                        type="button" value="Exit" onclick="return Button2_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 10%"></td>
                <td style="width: 10%"></td>
                <td style="width: 10%"></td>
                <td style="width: 10%"></td>
            </tr>
        </table>
    </div>
</asp:Content>


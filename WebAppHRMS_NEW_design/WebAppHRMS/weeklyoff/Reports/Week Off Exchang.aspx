<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Week Off Exchang.aspx.vb" Inherits="WebAppHRMS.HRM_Week_Off_Exchang_d85b5c4b8123" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">
        var con = header.split('ddl');

        function btnExit_onclick() {
            window.open("../../home.aspx", "_self");
        }

        function ddlOnchange() {
            document.getElementById(con[0] + "hiddn1").value = document.getElementById(con[0] + "ddlbranch").value;
        }

        function OnconfClick() {
            if (document.getElementById(con[0] + "ddlbranch").value == -1) {
                alert("Please Select the Branch Name");
                document.getElementById(con[0] + "ddlbranch").focus();
                return false;
            }
        }
    </script>
    <div style="text-align: center">
        <div style="text-align: center">
            <div style="text-align: center">
                <asp:HiddenField ID="hiddn1" runat="server" />
                &nbsp;<table border="1" style="width: 60%; position: relative; left: 0px; top: -6px;">
                    <tr>
                        <td style="width: 30%">Branch Name</td>
                        <td style="width: 30%">
                            <asp:DropDownList ID="ddlbranch" runat="server" Style="position: relative; left: -6px; top: 0px;" Width="95%" onchange="ddlOnchange()" AppendDataBoundItems="True">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 23px"></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="BtnConfirm" runat="server" Style="left: -19px; position: relative; top: 0px"
                                Text="CONFIRM" Width="72px" OnClientClick="OnconfClick()" />
                            <input id="btnExit" style="width: 72px; position: relative; height: 24px" type="button"
                                value="EXIT" onclick="btnExit_onclick()" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>


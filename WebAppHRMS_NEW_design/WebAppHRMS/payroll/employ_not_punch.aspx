<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="employ_not_punch.aspx.vb" Inherits="WebAppHRMS.november_employ_not_punch_f0468b649893" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">
        var cont_name = sal.split('Txt');
        function change(a) {
            var str = document.getElementById(cont_name[0] + a).value;
            if (isNaN(str)) {
                document.getElementById(cont_name[0] + a).value = "";
                document.getElementById(cont_name[0] + a).focus;
                return false;
            }

        }



        function Button1_onclick() {
            window.open('../home.aspx', '_self');

        }
        function load() {

            if (document.getElementById(cont_name[0] + "chk_all").checked == true) {
                //document.getElementById(cont_name[0]+"chk_abh").checked=false
                tr_br.style.display = "none";
                //document.getElementById(cont_name[0]+"chk_bh").checked=false
            }
            if (document.getElementById(cont_name[0] + "chk_all").checked == false) {
                tr_br.style.display = "inline";
            }
        }

        function bh() {

            if (document.getElementById(cont_name[0] + "chk_bh").checked == true) {
                document.getElementById(cont_name[0] + "chk_abh").checked = false
                //document.getElementById(cont_name[0]+"chk_all").checked=false

            }
            //if(document.getElementById(cont_name[0]+"chk_bh").checked==false)
            //{
            //document.getElementById(cont_name[0]+"chk_abh").checked=true

            //}
        }
        function abh() {
            if (document.getElementById(cont_name[0] + 'chk_abh').checked == true) {
                document.getElementById(cont_name[0] + 'chk_bh').checked = false
                //document.getElementById(cont_name[0]+"chk_all").checked=false
            }
            //if(document.getElementById(cont_name[0]+"chk_abh").checked==false)
            //{
            //document.getElementById(cont_name[0]+"chk_bh").checked=true

            //}
        }


        // ]]>
    </script>

    <div style="text-align: center">
        <table border="1">
            <tr>
                <td colspan="4">
                    <strong><span style="font-size: 14pt">NOT PUNCH EMPLOYEE<asp:ScriptManager ID="ScriptManager1"
                        runat="server">
                    </asp:ScriptManager>
                    </span></strong>
                </td>
            </tr>
            <tr id="tr_br">
                <td colspan="2" style="width: 267px">SELECT BRANCH</td>
                <td colspan="2" style="text-align: left">
                    <asp:DropDownList ID="cmb_branch" runat="server" Width="274px">
                    </asp:DropDownList></td>
            </tr>
            <tr style="display: none">
                <td colspan="4">SELECT ALL BRANCH &nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="chk_all" onclick="load()" runat="server" /></td>
            </tr>
            <tr style="display: none">
                <td colspan="4" style="height: 49px">
                    <div style="text-align: center">
                        <table style="display: none">
                            <tr style="display: none">
                                <td style="width: 227px">
                                    <span style="color: #0000cc">SELECT BH/ABH</span></td>
                                <td style="width: 100px">
                                    <asp:CheckBox ID="chk_bh" onclick="bh()" runat="server" Height="10px" Text="BH" Width="57px" />
                                </td>
                                <td style="width: 100px">
                                    <asp:CheckBox ID="chk_abh" onclick="abh()" runat="server" Height="15px" Text="ABH" Width="65px" /></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="width: 267px">ENTER LIMIT</td>
                <td style="text-align: left;" colspan="2">
                    <asp:TextBox ID="Txt_lmt" onkeyup="return change('Txt_lmt')" runat="server" MaxLength="3" Width="69px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td colspan="2" style="width: 267px">
                    <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" Width="163px" /></td>
                <td colspan="2">
                    <input id="Button1" onclick="return Button1_onclick()" style="width: 163px" type="button" value="EXIT" /></td>
            </tr>
        </table>
    </div>
</asp:Content>


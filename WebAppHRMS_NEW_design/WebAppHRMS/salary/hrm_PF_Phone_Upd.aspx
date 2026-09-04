<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="hrm_PF_Phone_Upd.aspx.vb" Inherits="WebAppHRMS.EXTRAFORMS_hrm_PF_Phone_Upd_0e3a51387957" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript" for="window" event="onload">
        return window_onload()
    </script>

    <script language="javascript" type="text/javascript">

        function Button2_onclick() {
            window.open('../home.aspx', '_self')
        }
        var cont = master_no.split("hid");
        function disp() {

            //debugger;
            var st, st1, st2, st3, ar, ar1, tot;
            var amt = 0;
            var days = 0;
            var count = 0;
            st1 = "";
            st = "";
            tot = "";
            if (document.getElementById(cont[0] + "Hidden1").value == "") {
                document.getElementById("panel_row").style.display = "none";
                document.getElementById(cont[0] + "Panel1").innerHTML = "";
                return;
            }
            st2 = document.getElementById(cont[0] + "Hidden1").value.split("!");
            ar = st2.length - 1;
            if (document.getElementById(cont[0] + "Hidden1").value != "") {
                for (i = 0; i < ar; i++) {

                    st3 = st2[i].split("*");                                                                                                                                                                                        //onclick=checkallfunction() id=chkall name=txt_all />CHECK ALL" onclick=chek('chk_"+i+"')<a href=javascript:chkk('" + i + "')>
                    st1 = st1 + "<tr  bgcolor='MistyRose'><td><small>" + st3[0] + "</td><td><small>" + st3[1] + "</td><td><small>" + st3[2] + "</td><td><small>" + st3[3] + "</td><td><small>" + st3[4] + "</td></tr>"
                    if (st3[5] != "") {

                        document.getElementById(cont[0] + "txt_Phone").value = st3[5];
                        document.getElementById(cont[0] + "txt_Phone").disabled = true;

                    }
                }
                st = st + "<table id='mytable' border=1 width='100%'><tr  bgcolor='#CCDDEE' style='font-size:85%'><td><b>BRANCH</b></td><td><b>&nbsp;EMP&nbsp;CODE&nbsp;</b></td><td><b>&nbsp;&nbsp;EMP&nbsp;NAME&nbsp;&nbsp;</b></td><td><b>&nbsp;&nbsp;DESIGNATION&nbsp;&nbsp;</b></td><td><b>&nbsp;&nbsp;JOIN&nbsp;DATE&nbsp;&nbsp;</b></td></tr>"
                st1 = st + st1 + tot + "</table>"
                document.getElementById("panel_row").style.display = "inline";
            }
            document.getElementById(cont[0] + "Panel1").innerHTML = st1;
        }
        function window_onload() {
            if (document.getElementById(cont[0] + "Hidden3").value != "") {

                document.getElementById(cont[0] + "Hidden1").value = document.getElementById(cont[0] + "Hidden3").value;
                disp();
            }
            else { alert("No Details!!!"); window.open('../home.aspx', '_self'); return false; }
        }
        function FromServer(arg, context) {
            //debugger;
            var Data = arg.split("@")
            switch (context) {
                case 1:
                    alert(arg);
                    window.open('../home.aspx', '_self');
                    break;
            }
        }

        function isNumberKey() {
            var charcode = (event.which) ? event.which : event.keyCode

            if (charcode > 31 && (charcode < 48 || charcode > 57)) {
                return false;
            }
            else
                return true;
        }


        // ]]>
    </script>

    <div style="text-align: center">
        <input id="hid_Usr" runat="server" type="hidden" />
        <table border="1" style="width: 40%">
            <tr id="panel_row" style="display: none">
                <td colspan="4">
                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">Enter&nbsp;Phone&nbsp;Number(&nbsp;Land&nbsp;Line)</td>
                <td style="text-align: left;" colspan="2">
                    <asp:TextBox ID="txt_Phone" runat="server" onkeypress="return isNumberKey()" Width="221px" MaxLength="13"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">Enter Mobile Number</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txt_mobile" runat="server" MaxLength="15" Width="221px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="Button1" runat="server" Font-Names="Times New Roman" Font-Size="Medium"
                        Text="CONFIRM" />
                    &nbsp;
                    <input id="Button2" style="font-size: 12pt; width: 100px; font-family: 'Times New Roman'"
                        type="button" value="EXIT" onclick="return Button2_onclick()" /></td>
            </tr>
            <tr>
                <td style="width: 10%"></td>
                <td style="width: 10%"></td>
                <td style="width: 10%"></td>
                <td style="width: 10%"></td>
            </tr>
        </table>
    </div>
    <input id="hid_br" runat="server" style="width: 6px" type="hidden" />
    <asp:HiddenField ID="Hidden3" runat="server" />
    <asp:HiddenField ID="Hidden1" runat="server" />
</asp:Content>


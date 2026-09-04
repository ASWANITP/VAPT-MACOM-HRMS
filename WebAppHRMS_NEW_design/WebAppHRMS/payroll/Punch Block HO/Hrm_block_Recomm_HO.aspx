<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Hrm_block_Recomm_HO.aspx.vb" Inherits="WebAppHRMS.HRM_Block_Rel_Req___HO_Hrm_block_Recomm_HO_706c71609896" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">


    <script language="javascript" type="text/javascript">
        // <!CDATA[
        var con = header.split('ddl');

        function btnExit_onclick() {
            window.open("../../home.aspx", "_self");
        }

        function FillEmployDetails() {
            if (document.getElementById(con[0] + "ddlEcode").value == -1) {
                document.getElementById("row1").style.display = "none";
            }
            else {
                document.getElementById("row1").style.display = "inline";
                data = document.getElementById(con[0] + "ddlEcode").value;
                var kk = document.getElementById(con[0] + "ddlEcode").options[document.getElementById(con[0] + "ddlEcode").selectedIndex].text
                Dt = kk.split("--")
                //         alert(Dt);
                ReqDt = Dt[3];
                stat = Dt[2];
                ecod = Dt[0];
                bid = Dt[4];
                document.getElementById(con[0] + "hdnReqDt").value = ReqDt;
                //         alert(Reqdt);
                document.getElementById(con[0] + "hdnBlockId").value = bid;
                document.getElementById(con[0] + "hdnStat").value = stat;
                //         alert(stat);
                document.getElementById(con[0] + "hdnEcode").value = document.getElementById(con[0] + "ddlEcode").value;
                document.getElementById(con[0] + "hdnEcode").value = ecod;
                callserver("1$" + document.getElementById(con[0] + "hdnReqDt").value + "$" + document.getElementById(con[0] + "ddlEcode").value + "$" + document.getElementById(con[0] + "hdnStat").value + "$" + document.getElementById(con[0] + "hdnBlockId").value, 1);
            }
        }
        function call_receiver(arg, context) {// debugger;
            var Data = arg.split("@")
            switch (context) {
                case 1:

                    if (document.getElementById(con[0] + "ddlEcode").value == -1) {
                        document.getElementById("row1").style.display = "none";
                        return false;
                    }
                    else {
                        document.getElementById(con[0] + "hdnDataDis").value = Data[0];
                        disp();

                    }
                    break;
            }
        }
        function disp() {
            var st, st1, st2, st3, ar, ar1, tot;
            var amt = 0;
            var days = 0;
            st1 = "";
            st = "";
            tot = "";
            if (document.getElementById(con[0] + "hdnDataDis").value == "") {
                document.getElementById(con[0] + "Panel1").innerHTML = "";
                document.getElementById("row1").style.display = "none";
                return;
            }
            st2 = document.getElementById(con[0] + "hdnDataDis").value.split("!")
            ar = st2.length - 1;
            //    alert(st2);
            if (document.getElementById(con[0] + "hdnDataDis").value != "") {
                for (k = 0; k < ar; k++) {
                    st3 = st2[k].split("*")
                    //            alert(st3);
                    st1 = st1 + "<tr><td><small>" + st3[0] + "</td><td><small>" + st3[1] + "</td><td><small>" + st3[2] + "</td><td><small>" + st3[3] + "</td><td><small>" + st3[4] + "</td><td><small>" + st3[5] + "</td><td><small>" + st3[6] + "</td><td><input type='checkbox' id='chkm_" + k + "' name='txtm_" + k + "'></td><td><input type='textbox' id='txt_" + k + "' name='txt_" + k + "' style='text-transform:capitalize' maxlength='100'></td></tr>"
                }
                st = st + "<table id='mytable' border='1'  width='100%' ><tr ><td><small><b>EMP&nbsp;CODE</b></td><td><small><b>&nbsp;&nbsp;&nbsp;EMP&nbsp;NAME&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;Branch&nbsp;&nbsp;&nbsp;</b></td><td><small><b>&nbsp;Post&nbsp;&nbsp; </b></td><td><small><b>&nbsp;&nbsp;Block Type&nbsp;&nbsp;</b></td><td><small><b>&nbsp;&nbsp;Reson For Request&nbsp;&nbsp;</b></td><td><small><b>&nbsp;Reqested Date&nbsp;</b></td><td><small><b>Mark If Recccom/Sanction Only</b></td><td><small><b>Remarks</b></td></tr>"
                st1 = st + st1 + tot + "</table>"
            }
            else {
                st1 = st + "</table>";
            }
            document.getElementById("row1").style.display = "inline";
            document.getElementById(con[0] + "Panel1").innerHTML = st1;
        }

        function OnConfClick() {//debugger;
            if (document.getElementById(con[0] + "ddlEcode").value == -1) {
                alert("Select Employee....!!!");
                document.getElementById(con[0] + "ddlEcode").focus();
                return false;
            }
            if (document.getElementById(con[0] + "hdnDataDis").value == "") {
                alert("There is No Employees To Recommend...!");
                document.getElementById(con[0] + "ddlEcode").focus();
                return false;
            }
            if (document.getElementById(con[0] + "hdnDataDis").value != "") {
                var st3 = "";
                st2 = document.getElementById(con[0] + "hdnDataDis").value.split("!")
                ar = st2.length
                for (i = 0; i < ar - 1; i++) {
                    st3 = st2[i].split("*")
                    var Regular = "T";
                    if (document.getElementById("chkm_" + i + "").checked == false) {
                        Regular = "F";
                    }
                    //         else
                    //         {
                    //            document.getElementById(con[0]+"hdnBlockId").value+= st3[7]+ "*";
                    //         }

                    if (document.getElementById("txt_" + i + "").value == "") {
                        alert("Please Enter Remarks ");
                        document.getElementById(con[0] + "hdnBlockId").value = "";
                        document.getElementById(con[0] + "hdnDataSend").value = "";
                        document.getElementById("txt_" + i + "").focus();
                        return false;
                    }

                    if (document.getElementById("txt_" + i + "").value == "") Remarks = "NIL";
                    else {
                        Remarks = document.getElementById("txt_" + i + "").value;
                    }



                    document.getElementById(con[0] + "hdnDataSend").value += st3[0] + "^" + st3[6] + "^" + st3[7] + "^" + Regular + "^" + Remarks + "!";
                }
            }
        }

        function window_onload() {
            document.getElementById("row1").style.display = "none";
            document.getElementById(con[0] + "hdnDataSend").value = "";
            document.getElementById(con[0] + "hdnReqDt").value = "";
            document.getElementById(con[0] + "hdnDataDis").value = "";
            document.getElementById(con[0] + "hdnEcode").value = "";
            document.getElementById(con[0] + "hdnBlockId").value = "";
        }
        // ]]>
    </script>

    <asp:HiddenField ID="hdnReqDt" runat="server" />
    <asp:HiddenField ID="hdnEcode" runat="server" />
    <asp:HiddenField ID="hdnDataDis" runat="server" />
    <asp:HiddenField ID="hdnStat" runat="server" />
    <asp:HiddenField ID="hdnDataSend" runat="server" />
    <asp:HiddenField ID="hdnBlockId" runat="server" />
    <table border="1" style="width: 80%; position: relative; left: 144px; top: 0px;">
        <tr>
            <td colspan="2" style="text-align: left">Select Employee To Recommend
            </td>
            <td colspan="2" style="text-align: left">
                <asp:DropDownList ID="ddlEcode" runat="server" onchange="FillEmployDetails()" Width="97%">
                </asp:DropDownList></td>
        </tr>
        <tr id="row1">
            <td colspan="4">
                <asp:Panel ID="Panel1" runat="server" Height="0px" Width="100%">
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">&nbsp;
                <asp:Button ID="btnSanction" runat="server" Height="24px" OnClientClick="return OnConfClick()"
                    Text="SANCTION" Width="88px" Style="left: 0px; top: 0px" /><asp:Button ID="btnConfirm" runat="server" Height="24px" OnClientClick="return OnConfClick()"
                        Text="REJECT" Width="88px" Style="left: 0px; top: 0px" />
                <input id="btnExit" onclick="return btnExit_onclick()" style="width: 88px; height: 24px; left: 0px; position: relative; top: 0px;"
                    type="button" value="EXIT" /></td>
        </tr>
        <tr>
            <td style="width: 15%"></td>
            <td style="width: 15%"></td>
            <td style="width: 15%"></td>
            <td style="width: 15%"></td>
        </tr>
    </table>

</asp:Content>


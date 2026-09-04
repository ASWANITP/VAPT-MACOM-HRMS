<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="tour_new _applied_sattus.aspx.vb" Inherits="WebAppHRMS.tour_status_report_tour_new__applied_sattus_b2d206c26631" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">

        function Reset1_onclick() {
            window.open('../home.aspx', '_self');
        }

        //function isnan()
        //    {
//        var b=document.getElementById('<%=txt_emp.ClientID%>').value;
        //        if(isNaN(b))
        //        {
        //           alert('Please Enter  in digits..!!');
//            document.getElementById('<%=txt_emp.ClientID%>').value= "";
        //                                
        //            return false;
        //        }
        //}


        var con = header.split('txt');

        function isNumeric() {
            if (isNaN(document.getElementById(con[0] + "txt_emp").value)) {
                alert('Please Enter  in digits..!!');
                document.getElementById(con[0] + "txt_emp").value = "";
                document.getElementById(con[0] + "txt_name").value = "";
                return false;
            }
//var b=document.getElementById('<%=txt_emp.ClientID%>').value;
    // if(isNaN(b))
    //  alert('Please Enter  in digits..!!');
    //  
//  document.getElementById('<%=txt_emp.ClientID%>').value= "";
            //  
            //   return false;
        }

        function detailDisplay() {
            if (isNaN(document.getElementById(con[0] + "txt_emp").value)) {
                document.getElementById(con[0] + "txt_emp").value = "";
                document.getElementById(con[0] + "txt_name").value = "";
                document.getElementById(con[0] + "txt_emp").focus();
                return false;
            }
            if (document.getElementById(con[0] + "txt_emp").value == "") {
                document.getElementById(con[0] + "txt_name").value = "";
                document.getElementById(con[0] + "txt_emp").focus();
                return false;
            }
            else {
                callserver("1$" + document.getElementById(con[0] + "txt_emp").value, 1);
            }
        }
        function call_receiver(arg, context) {
            switch (context) {
                case 1:
                    {
                        var accdtl = arg.split("*");
                        if (accdtl == "") {
                            alert("Please Select valid Employee Code");
                            document.getElementById(con[0] + "txt_emp").value = "";
                            document.getElementById(con[0] + "txt_name").value = "";
                            document.getElementById(con[0] + "txt_emp").focus();
                            return false;
                        }
                        else {
                            document.getElementById(con[0] + "txt_name").value = accdtl[0];
                        }
                        break;
                    }
            }
        }
        function ConfirmOnClick() {
            if (document.getElementById(con[0] + "txt_emp").value == "") {
                alert("Enter Employee Code.....!!!");
                document.getElementById(con[0] + "txt_emp").focus();
                return false;
            }
        }

        // ]]>
    </script>

    <div style="text-align: center">
        <div style="text-align: center">
            <table border="1" style="left: -7px; width: 699px; position: relative; top: 2px">
                <caption>
                    <strong><span style="font-size: 16pt">
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MMM/yyyy"
                            TargetControlID="txt_frdt"></cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MMM/yyyy"
                            TargetControlID="txt_todt"></cc1:CalendarExtender>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; Status Report</span></strong></caption>
                <tr>
                    <td style="width: 177px">Enter Your Employee Code</td>
                    <td style="width: 120px">
                        <asp:TextBox ID="txt_emp" onblur="detailDisplay()" onkeypress="isNumeric()" runat="server" Style="position: relative" Width="125px" MaxLength="6"></asp:TextBox></td>
                    <td style="width: 139px">Employee name</td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txt_name" runat="server" Style="position: relative"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 177px; height: 28px">Tour From Date</td>
                    <td style="width: 120px; height: 28px">
                        <asp:TextBox ID="txt_frdt" runat="server" Style="position: relative" Width="125px"></asp:TextBox></td>
                    <td style="width: 139px; height: 28px">Tour to Date</td>
                    <td style="width: 100px; height: 28px">
                        <asp:TextBox ID="txt_todt" runat="server" Style="position: relative"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 28px">
                        <asp:Button ID="Button1" OnClientClick=" return ConfirmOnClick()" runat="server" Style="left: 95px; position: relative; top: 3px"
                            Text="Confirm" Width="58px" />
                        <input id="Reset1" style="left: 95px; width: 60px; position: relative; top: 4px"
                            type="reset" value="Exit" onclick="return Reset1_onclick()" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>


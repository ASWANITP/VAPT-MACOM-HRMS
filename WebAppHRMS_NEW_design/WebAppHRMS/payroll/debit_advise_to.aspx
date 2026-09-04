<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="debit_advise_to.aspx.vb" Inherits="WebAppHRMS.RD_and_change_bank_rd_change_bank_05dfcc851708" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <script language="javascript" type="text/javascript">


        var cont = loanno.split('Txt');
        function Cmd_Exit_onclick() {
            window.open('../home.aspx', '_self');
        }

        function fill1() {
            if (document.getElementById(cont[0] + "Txt_EmpCode").value == "") {
                alert('Please Enter a Valid Employee Code!!');
                document.getElementById(cont[0] + "Txt_EmpName").value = "";
                document.getElementById(cont[0] + "Txt_Designation").value = "";
                document.getElementById(cont[0] + "Txt_Department").value = "";
                document.getElementById(cont[0] + "Txt_Branch").value = "";
                document.getElementById(cont[0] + "Txt_Post").value = "";
                document.getElementById(cont[0] + "Txt_Salary").value = "";
                document.getElementById(cont[0] + "Txt_Incentives").value = "";
                rbranch.style.display = "none";
                //    document.getElementById(cont[0]+"Txt_CurrStatus").value="";
                //    document.getElementById(cont[0]+"Txt_RDNo").value="";
                return false;
            }
            if (document.getElementById(cont[0] + "Txt_EmpCode").value != "") {
                sub_call_server(document.getElementById(cont[0] + "Txt_EmpCode").value);
            }
        }
        function okeyup() {
            var st;
            st = document.getElementById(cont[0] + "Txt_EmpCode").value;
            if (isNaN(st)) {
                alert('Please Enter a Valid Employee Code!!');
                document.getElementById(cont[0] + "Txt_EmpCode").value = "";
                document.getElementById(cont[0] + "Txt_EmpCode").focus();
                return false;
            }
        }

        function sub_call_receiver(arg1) {

            var arg2;
            arg2 = arg1.split("@");
            if (arg2[0] != "$") {
                var arg3 = arg2[0].split("*");
                document.getElementById(cont[0] + "Txt_EmpName").value = arg3[1];
                document.getElementById(cont[0] + "Txt_Designation").value = arg3[2];
                document.getElementById(cont[0] + "Txt_Department").value = arg3[3];
                document.getElementById(cont[0] + "Txt_Branch").value = arg3[4];
                document.getElementById(cont[0] + "Txt_Post").value = arg3[5];
                document.getElementById(cont[0] + "Txt_Salary").value = arg3[6];
                document.getElementById(cont[0] + "Txt_Incentives").value = arg3[7];
                document.getElementById(cont[0] + "Cmb_Branch").value = 0;
                rbranch.style.display = "inline";
                // document.getElementById(cont[0]+"Txt_CurrStatus").value=arg3[6];
                // if((arg3[7])!=0)
                //  {
                //   document.getElementById(cont[0]+"Txt_RDNo").value=arg3[7];
                //  }
                //  if((arg3[7])==0)
                //  {
                //   document.getElementById(cont[0]+"Txt_RDNo").value='No RD Number';
                //  }
                //  b1.style.display="inline"; 
                //  b2.style.display="inline"; 
                //  b3.style.display="inline"; 
                //  b4.style.display="inline"; 
                //  b5.style.display="inline"; 
                //  document.getElementById(cont[0]+"Txt_DepoAmt").value="";
                //  document.getElementById(cont[0]+"Txt_BankAccNo").value="";
                //  document.getElementById(cont[0]+"Txt_DepoNo").value="";
                //  document.getElementById(cont[0]+"Txt_DepoDate").value=""
                //  document.getElementById(cont[0]+"Txt_MatDate").value=""
                document.getElementById(cont[0] + "Cmd_Confirm").disabled = false;
            }
            if (arg2[0] == "$") {
                alert('No such Employee!!');
                document.getElementById(cont[0] + "Txt_EmpCode").value = "";
                document.getElementById(cont[0] + "Txt_EmpName").value = "";
                document.getElementById(cont[0] + "Txt_Designation").value = "";
                document.getElementById(cont[0] + "Txt_Department").value = "";
                document.getElementById(cont[0] + "Txt_Branch").value = "";
                document.getElementById(cont[0] + "Txt_Post").value = "";
                document.getElementById(cont[0] + "Txt_Salary").value = "";
                document.getElementById(cont[0] + "Txt_Incentives").value = "";
                // document.getElementById(cont[0]+"Txt_CurrStatus").value="";
                // document.getElementById(cont[0]+"Txt_RDNo").value="";
                document.getElementById(cont[0] + "Txt_EmpCode").focus();
                // rbranch.style.display="inline";
                // b1.style.display="none"; 
                //  b2.style.display="none";
                //  b3.style.display="none";
                //  b4.style.display="none";
                //  b5.style.display="none";
                document.getElementById(cont[0] + "Cmd_Confirm").disabled = true;
            }
            if (arg2[0] == "$1") {
                rbranch.style.display = "none";
                document.getElementById(cont[0] + "Txt_EmpCode").value = "";
                document.getElementById(cont[0] + "Txt_EmpName").value = "";
                document.getElementById(cont[0] + "Txt_Designation").value = "";
                document.getElementById(cont[0] + "Txt_Department").value = "";
                document.getElementById(cont[0] + "Txt_Branch").value = "";
                document.getElementById(cont[0] + "Txt_Post").value = "";
                document.getElementById(cont[0] + "Txt_Salary").value = "";
                document.getElementById(cont[0] + "Txt_Incentives").value = "";
                alert('This Employee Salary/Incentives Cannot be Transferred!!');

                // document.getElementById(cont[0]+"Txt_CurrStatus").value="";
                // document.getElementById(cont[0]+"Txt_RDNo").value="";
                document.getElementById(cont[0] + "Txt_EmpCode").focus();
                // rbranch.style.display="inline";
                // b1.style.display="none"; 
                //  b2.style.display="none";
                //  b3.style.display="none";
                //  b4.style.display="none";
                //  b5.style.display="none";
                document.getElementById(cont[0] + "Cmd_Confirm").disabled = true;
            }
            if (arg2[0] == "$2") {
                rbranch.style.display = "none";
                document.getElementById(cont[0] + "Txt_EmpCode").value = "";
                document.getElementById(cont[0] + "Txt_EmpName").value = "";
                document.getElementById(cont[0] + "Txt_Designation").value = "";
                document.getElementById(cont[0] + "Txt_Department").value = "";
                document.getElementById(cont[0] + "Txt_Branch").value = "";
                document.getElementById(cont[0] + "Txt_Post").value = "";
                document.getElementById(cont[0] + "Txt_Salary").value = "";
                document.getElementById(cont[0] + "Txt_Incentives").value = "";
                alert('Please Contact EDP!!');
                document.getElementById(cont[0] + "Txt_EmpCode").focus();
                document.getElementById(cont[0] + "Cmd_Confirm").disabled = true;
            }
        }

        function cliclick() {
            // if(document.getElementById(cont[0]+"Txt_BankAccNo").value=="")
            // {
            //  alert('Please Enter Bank Account Number!!');
            //  document.getElementById(cont[0]+"Txt_BankAccNo").focus();
            //  return false;
            // }
            // if(document.getElementById(cont[0]+"Txt_DepoNo").value=="")
            // {
            //  alert('Please Enter Deposit Number!!');
            //  document.getElementById(cont[0]+"Txt_DepoNo").focus();
            //  return false;
            // }
            // if(document.getElementById(cont[0]+"Txt_DepoAmt").value=="")
            // {
            //  alert('Please Enter Deposit Amount!!');
            //  document.getElementById(cont[0]+"Txt_DepoAmt").focus();
            //  return false;
            // }
            // if(document.getElementById(cont[0]+"Txt_DepoDate").value=="")
            // {
            //  alert('Please Enter Deposit Date!!');
            //  document.getElementById(cont[0]+"Txt_DepoDate").focus();
            //  return false;
            // }
            // if(document.getElementById(cont[0]+"Txt_MatDate").value=="")
            // {
            //  alert('Please Enter Maturity Date!!');
            //  document.getElementById(cont[0]+"Txt_MatDate").focus();
            //  return false;
            // }
        }
        //function Txt_BankAccNo_onChange()
        //{
        //// if(document.getElementById(cont[0]+"Txt_CurrStatus").value=="RESIGNED")
        //// {
        ////  var answer = confirm("This Employee is now Resigned..Are You Sure to continue?")
        ////	if (answer){
        ////		alert('Ok You can Continue!!');
        ////		}
        ////	else{
        ////		alert('Ok..You Can Check Another Or Go back !');
        //		document.getElementById(cont[0]+"Txt_EmpCode").value="";
        //        document.getElementById(cont[0]+"Txt_EmpName").value="";
        //        document.getElementById(cont[0]+"Txt_Designation").value="";
        //        document.getElementById(cont[0]+"Txt_Department").value="";
        //        document.getElementById(cont[0]+"Txt_Branch").value="";
        //        document.getElementById(cont[0]+"Txt_Post").value="";
        ////        document.getElementById(cont[0]+"Txt_CurrStatus").value="";
        ////        document.getElementById(cont[0]+"Txt_RDNo").value="";
        //        document.getElementById(cont[0]+"Txt_EmpCode").focus();
        ////        b1.style.display="none"; 
        ////        b2.style.display="none";
        ////        b3.style.display="none";
        ////        b4.style.display="none";
        ////        b5.style.display="none";
        //        document.getElementById(cont[0]+"Cmd_Confirm").disabled=true;
        //		return false;
        ////	    }
        // }
        ////  if(document.getElementById(cont[0]+"Txt_CurrStatus").value=="TERMINATED")
        //// {
        ////  var answer = confirm("This Employee is now Terminated (or Regularised)..Are You Sure to continue?")
        ////	if (answer){
        ////		alert('Ok You can Continue!!');
        ////		}
        ////	else{
        ////		    alert('Ok..You Can Check Another Or Go back !');
        ////		    document.getElementById(cont[0]+"Txt_EmpCode").value="";
        ////            document.getElementById(cont[0]+"Txt_EmpName").value="";
        ////            document.getElementById(cont[0]+"Txt_Designation").value="";
        ////            document.getElementById(cont[0]+"Txt_Department").value="";
        ////            document.getElementById(cont[0]+"Txt_Branch").value="";
        ////            document.getElementById(cont[0]+"Txt_Post").value="";
        //////            document.getElementById(cont[0]+"Txt_CurrStatus").value="";
        //////            document.getElementById(cont[0]+"Txt_RDNo").value="";
        ////            document.getElementById(cont[0]+"Txt_EmpCode").focus();
        //////            b1.style.display="none"; 
        //////            b2.style.display="none";
        //////            b3.style.display="none";
        //////            b4.style.display="none";
        //////            b5.style.display="none";
        ////            document.getElementById(cont[0]+"Cmd_Confirm").disabled=true;
        ////		    return false;
        ////	    }
        // }
        //  if(document.getElementById(cont[0]+"Txt_CurrStatus").value=="SUSPENDED")
        // {
        //  var answer = confirm("This Employee is now in Suspension..Are You Sure to continue?")
        //	if (answer){
        //		alert('Ok You can Continue!!');
        //		}
        //	else{
        //		    alert('Ok..You Can Check Another Or Go back !');
        //		    document.getElementById(cont[0]+"Txt_EmpCode").value="";
        //            document.getElementById(cont[0]+"Txt_EmpName").value="";
        //            document.getElementById(cont[0]+"Txt_Designation").value="";
        //            document.getElementById(cont[0]+"Txt_Department").value="";
        //            document.getElementById(cont[0]+"Txt_Branch").value="";
        //            document.getElementById(cont[0]+"Txt_Post").value="";
        ////            document.getElementById(cont[0]+"Txt_CurrStatus").value="";
        ////            document.getElementById(cont[0]+"Txt_RDNo").value="";
        //            document.getElementById(cont[0]+"Txt_EmpCode").focus();
        ////            b1.style.display="none"; 
        ////            b2.style.display="none";
        ////            b3.style.display="none";
        ////            b4.style.display="none";
        ////            b5.style.display="none";
        //            document.getElementById(cont[0]+"Cmd_Confirm").disabled=true;
        //		    return false;
        //	    }
        // }
        // if(document.getElementById(cont[0]+"Txt_CurrStatus").value=="LONG LEAVE")
        // {
        //  var answer = confirm("This Employee is now in Long Leave..Are You Sure to continue?")
        //	if (answer)
        //	    {
        //		    alert('Ok You can Continue!!');
        //		}
        //	else{
        //		    alert('Ok..You Can Check Another Or Go back !');
        //		    document.getElementById(cont[0]+"Txt_EmpCode").value="";
        //            document.getElementById(cont[0]+"Txt_EmpName").value="";
        //            document.getElementById(cont[0]+"Txt_Designation").value="";
        //            document.getElementById(cont[0]+"Txt_Department").value="";
        //            document.getElementById(cont[0]+"Txt_Branch").value="";
        //            document.getElementById(cont[0]+"Txt_Post").value="";
        ////            document.getElementById(cont[0]+"Txt_CurrStatus").value="";
        ////            document.getElementById(cont[0]+"Txt_RDNo").value="";
        //            document.getElementById(cont[0]+"Txt_EmpCode").focus();
        ////            b1.style.display="none"; 
        ////            b2.style.display="none";
        ////            b3.style.display="none";
        ////            b4.style.display="none";
        ////            b5.style.display="none";
        //            document.getElementById(cont[0]+"Cmd_Confirm").disabled=true;
        //		    return false;
        //	    }
        // }
        // if(document.getElementById(cont[0]+"Txt_CurrStatus").value=="MATERNITY")
        // {
        //  var answer = confirm("This Employee is now in Maternity Leave..Are You Sure to continue?")
        //	if (answer)
        //	    {
        //		  alert('Ok You can Continue!!');
        //		}
        //	else{
        //		    alert('Ok..You Can Check Another Or Go back !');
        //		    document.getElementById(cont[0]+"Txt_EmpCode").value="";
        //            document.getElementById(cont[0]+"Txt_EmpName").value="";
        //            document.getElementById(cont[0]+"Txt_Designation").value="";
        //            document.getElementById(cont[0]+"Txt_Department").value="";
        //            document.getElementById(cont[0]+"Txt_Branch").value="";
        //            document.getElementById(cont[0]+"Txt_Post").value="";
        ////            document.getElementById(cont[0]+"Txt_CurrStatus").value="";
        ////            document.getElementById(cont[0]+"Txt_RDNo").value="";
        //            document.getElementById(cont[0]+"Txt_EmpCode").focus();
        //            b1.style.display="none"; 
        //            b2.style.display="none";
        //            b3.style.display="none";
        //            b4.style.display="none";
        //            b5.style.display="none";
        //            document.getElementById(cont[0]+"Cmd_Confirm").disabled=true;
        //		    return false;
        //	    }
        // }
        //}
        function init() {
            document.getElementById(cont[0] + "Txt_EmpCode").value = "";
            document.getElementById(cont[0] + "Txt_EmpCode").focus();
            document.getElementById(cont[0] + "Cmd_Confirm").disabled = true;
        }
        window.onload = init;

        // ]]>
    </script>

    <div style="text-align: center">
        <div style="text-align: center">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            &nbsp;&nbsp;<br />
        </div>
    </div>
    <div style="text-align: center">
        <table border="1" style="width: 726px; height: 150px">
            <tr>
                <td colspan="4" style="text-align: center">
                    <strong><span style="text-decoration: underline">Select Employee</span></strong></td>
            </tr>
            <tr>
                <td style="width: 965px; text-align: left">
                    <strong>Employee Code:</strong></td>
                <td style="width: 71px; text-align: left">
                    <asp:TextBox ID="Txt_EmpCode" onkeyup="return okeyup()" runat="server" Width="119px" MaxLength="5"></asp:TextBox></td>
                <td style="width: 639px; text-align: left">
                    <strong>Name:</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="Txt_EmpName" runat="server" ReadOnly="True" Width="207px" Style="cursor: hand"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 965px; text-align: left">
                    <strong>Branch:</strong></td>
                <td style="width: 71px; text-align: left">
                    <asp:TextBox ID="Txt_Branch" runat="server" Width="207px" ReadOnly="True" Style="cursor: hand"></asp:TextBox></td>
                <td style="width: 639px; text-align: left">
                    <strong>Designation:</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="Txt_Designation" runat="server" Width="207px" ReadOnly="True" Style="cursor: hand"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 965px; text-align: left">
                    <strong>Department:</strong></td>
                <td style="width: 71px; text-align: left">
                    <asp:TextBox ID="Txt_Department" runat="server" Width="207px" ReadOnly="True" Style="cursor: hand"></asp:TextBox></td>
                <td style="width: 639px; text-align: left">
                    <strong>Post:</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="Txt_Post" runat="server" Width="207px" ReadOnly="True" Style="cursor: hand"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 965px; text-align: left">
                    <strong>Total Salary:</strong></td>
                <td style="width: 71px; text-align: left">
                    <asp:TextBox ID="Txt_Salary" runat="server" Height="16px" ReadOnly="True" Style="cursor: hand"></asp:TextBox></td>
                <td style="width: 639px; text-align: left">
                    <strong>Total Incentives:</strong></td>
                <td style="width: 100px; text-align: left">
                    <asp:TextBox ID="Txt_Incentives" runat="server" ReadOnly="True" Style="cursor: hand"></asp:TextBox></td>
            </tr>
            <tr id="rbranch" style="display: none">
                <td style="text-align: left" colspan="2">
                    <strong>Select Branch To Send Salary And/Or Incentives :</strong></td>
                <td style="text-align: left" colspan="2">
                    <asp:DropDownList ID="Cmb_Branch" runat="server" Width="284px">
                    </asp:DropDownList></td>
            </tr>
        </table>
        <div style="text-align: center">
            <table border="1" style="width: 118px; height: 34px">
                <tr>
                    <td style="width: 100px; text-align: right">
                        <input id="Cmd_Exit" type="button" value="EXIT" style="width: 92px; cursor: hand;" onclick="return Cmd_Exit_onclick()" tabindex="7" /></td>
                    <td style="width: 100px; text-align: left">
                        <asp:Button ID="Cmd_Confirm" OnClientClick="return cliclick()" runat="server" Text="CONFIRM" Style="cursor: hand" TabIndex="8" /></td>
                </tr>
            </table>
        </div>
        &nbsp;
        <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="Cmb_Branch">
        </cc1:ListSearchExtender>
        <br />
        <br />
    </div>
</asp:Content>


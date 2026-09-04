
<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/edp.master"  CodeBehind="hrm_dept_post_des_approve.aspx.vb" Inherits="WebAppHRMS.hrm_dept_post_des_approve" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
   
    <script language="javascript" type="text/javascript" for="window" event="onload">
        window.onload = callback();
        function callback() {
            return window_onload();
        }
    </script>

    <script language="javascript" type="text/javascript">
        var cont_name = header.split('ddl');
       
        function window_onload() {
           // alert(cont_name[0]);
            document.getElementById(cont_name[0] + "rdDept").checked = true;
            document.getElementById(cont_name[0] + "lblFirst").innerHTML = "Select New Department";
            document.getElementById(cont_name[0] + "lblSecond").innerHTML = "Main Department";
            document.getElementById(cont_name[0] + "ddlMainDept").style.display = 'inline';
            document.getElementById(cont_name[0] + "txtdpd").style.display = 'inline';

            }

        function ConfirmOnClick() {
            if (document.getElementById(cont_name[0] + "rdDept").checked == true) {

                if (document.getElementById(cont_name[0] + "ddlMainDept").value == n) {
                    alert("Please Select Department.....!");
                    return false;
                }
            }
            if (document.getElementById(cont_name[0] + "rdPost").checked == true) {

                if (document.getElementById(cont_name[0] + "ddlMainDept").value == 0) {
                    alert("Please Select Post.....!");
                    return false;
                }
            }
            if (document.getElementById(cont_name[0] + "rdDes").checked == true) {
                if (document.getElementById(cont_name[0] + "ddlMainDept").value == 0) {
                    alert("Please Select Designation.....!");
                    return false;
                }
            }

        }
        function RejectOnClick() {
            if (document.getElementById(cont_name[0] + "rdDept").checked == true) {

                if (document.getElementById(cont_name[0] + "ddlMainDept").value == n) {
                    alert("Please Select Department.....!");
                    return false;
                }
            }
            if (document.getElementById(cont_name[0] + "rdPost").checked == true) {

                if (document.getElementById(cont_name[0] + "ddlMainDept").value == 0) {
                    alert("Please Select Post.....!");
                    return false;
                }
            }
            if (document.getElementById(cont_name[0] + "rdDes").checked == true) {
                if (document.getElementById(cont_name[0] + "ddlMainDept").value == 0) {
                    alert("Please Select Designation.....!");
                    return false;
                }
            }

        }
        function btnExit_onclick() {
            window.open('../home.aspx', '_self');
        }

    </script>
    <div style="text-align: center">
    <div style="text-align: center">
        <table border="1" style="width: 60%">
            <tr>
                <td style="width: 20%; height: 25px">
                    <asp:RadioButton ID="rdDept" runat="server" AutoPostBack="true" OnCheckedChanged="rdDept_CheckedChanged" Checked="true" Text="Department"  GroupName="dpd" /></td>
                <td style="width: 20%; height: 25px">
                    <asp:RadioButton ID="rdPost" runat="server" AutoPostBack="true" OnCheckedChanged="rdPost_CheckedChanged" GroupName="dpd" Text="Post"  Width="123px" /></td>
                <td style="width: 20%; height: 25px">
                    <asp:RadioButton ID="rdDes" runat="server" AutoPostBack="true" OnCheckedChanged="rdDes_CheckedChanged" GroupName="dpd" Text="Designation" /></td>
            </tr>
            <tr>
                <td style="width: 20%; height: 25px">
                    <asp:Label ID="lblFirst" runat="server" Width="179px"></asp:Label></td>
                <td style="height: 25px; text-align: left;" colspan="2">
                    <asp:DropDownList ID="ddlMainDept" runat="server" AutoPostBack ="true" Width="226px">
                    </asp:DropDownList>
                 
            </tr>
            <tr>
                <td style="width: 20%; height: 25px">
                    <asp:Label ID="lblSecond" runat="server" Width="176px"></asp:Label></td>
                <td style="height: 25px; text-align: left;" colspan="2">
                    <asp:TextBox ID="txtdpd" readonly="true" runat="server" Width="221px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 35px" colspan="3">
                    <asp:Button ID="btnConfirm" runat="server" Text="APPROVE" Height="35px"  />
                     <asp:Button ID="btnReject" runat="server" Text="REJECT" Height="35px" />
                    <input id="btnExit" type="button" value="EXIT" style="width: 88px; height: 35px" onclick="return btnExit_onclick()" /></td>
            </tr>
        </table>
    </div>
</div>
</asp:Content>

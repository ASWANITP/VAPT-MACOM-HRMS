<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Emp_Photo_Upload.aspx.vb" Inherits="WebAppHRMS.HRM_Emp_Photo_Upload_3c997e341915" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function btnExit_onclick() 
{
 window.open("../home.aspx","_self");
}

// ]]>
</script>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">--%>
    <table border="2" style="width: 51%;height: 240px">
     <tr>
                <td colspan="6" style="height: 23px; width: 600px " align="center">
                    <strong><span style="font-size: 14pt; color: #660000 ">UPLOAD NEW PHOTO</span></strong></td>
            </tr>
        <tr>
            <td style="width: 37%; height: 5px">
                Employee Code</td>
            <td style="width:14%; height: 5px">
                <asp:TextBox ID="txtecode" runat="server" ReadOnly="True" Style="left: 0px; position: relative;
                    top: 0px" Width="240px"></asp:TextBox></td>
            <td style="width: 14%; height: 5px">
                Employee Name</td>
            <td style="width:14%; height: 5px">
                <asp:TextBox ID="txtename" runat="server" Style="position: relative" Width="240px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width:37%; height: 3px">
                Branch</td>
            <td style="width: 14%; height: 3px">
                <asp:TextBox ID="txtbranch" runat="server" ReadOnly="True" Style="left: 0px; position: relative;
                    top: 0px" Width="240px"></asp:TextBox></td>
            <td style="width:14%; height: 3px">
                Designation</td>
            <td style="width:14%; height: 3px">
                <asp:TextBox ID="txtdes" runat="server" ReadOnly="True" Style="left: 0px; position: relative;
                    top: 0px" Width="240px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width:37%; height: 10px">
                Department</td>
            <td style="width: 14%; height: 10px">
                <asp:TextBox ID="txtdep" runat="server" ReadOnly="True" Style="left: 0px; position: relative;
                    top: 0px" Width="240px"></asp:TextBox></td>
            <td style="width:14%; height: 10px">
                Post</td>
            <td style="width:14%; height: 10px">
                <asp:TextBox ID="txtpost" runat="server" ReadOnly="True" Style="left: 0px; position: relative;
                    top: 0px" Width="240px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width:37%; height: 9px">
                Join Date</td>
            <td style="width: 14%; height: 9px">
                <asp:TextBox ID="txtjdate" runat="server" Style="left: 0px; position: relative; top: 0px"
                    Width="240px" ReadOnly="True"></asp:TextBox></td>
            <td style="width:14%; height: 9px">
                Upload Date</td>
            <td style="width: 14%; height: 9px">
                <asp:TextBox ID="txtdate" runat="server" ReadOnly="True" Style="left: 0px; position: relative;
                    top: 0px" Width="240px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="8">
                <strong>EMPLOYEE PHOTO UPLOAD</strong></td>
        </tr>
        <tr>
            <td style="width: 37%; height: 6px">
                Employee Photo</td>
            <td colspan="5" style="height: 6px; text-align: left">
                <asp:FileUpload ID="Emp_support1" runat="server" BackColor="GhostWhite" Style="left: 80px;
                    position: relative; top: 0px" Width="440px" /></td>
        </tr>
        <tr>
            <td id="TD1" colspan="4">
                <asp:Button ID="btnConfrm" runat="server" Style="left: 208px; position: relative;
                    top: 32px" Text="CONFIRM" /><input id="btnExit" onclick="return btnExit_onclick()"
                        style="left: 208px; width: 88px; position: relative; top: 32px; height: 24px"
                        type="button" value="EXIT" /></td>
        </tr>
        <tr>
            <td colspan="4" style="height: 50px">
            </td>
        </tr>
    </table>
</asp:Content>


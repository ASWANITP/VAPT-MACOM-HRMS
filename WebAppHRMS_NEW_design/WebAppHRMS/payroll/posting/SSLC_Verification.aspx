<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="SSLC_Verification.aspx.vb" Inherits="WebAppHRMS.payroll_Posting_SSLC_Verification_613d0fe47962" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">
        var cont = header.split("txt")

        function bttnReject_onclick() {

            var Remarks = document.getElementById(cont[0] + "txt_Remarks").value;
            var PendingApp = document.getElementById(cont[0] + "DDLPendApprov").value;

            if (PendingApp == 0) { alert("Please Select One Employee !"); document.getElementById(cont[0] + "DDLPendApprov").focus(); return false; }

            if (Remarks == "") { alert("Please Enter the Reason for Rejecting !"); document.getElementById(cont[0] + "txt_Remarks").focus(); return false; }

        }

        function Request_Onclick() {
            var PendingApp = document.getElementById(cont[0] + "DDLPendApprov").value;
            var Remarks = document.getElementById(cont[0] + "txt_Remarks").value;

            if (PendingApp == 0) { alert("Please Select One Employee !"); document.getElementById(cont[0] + "DDLPendApprov").focus(); return false; }

            if (Remarks == "") { alert("Please Enter theRemarks !"); document.getElementById(cont[0] + "txt_Remarks").focus(); return false; }


        }
    </script>

    <%-- <asp:UpdatePanel runat="Server" ID="upanel">
 <ContentTemplate>--%>
    <table border="1" style="width: 606px;" align="center">
        <tr>
        </tr>
        <tr id="row1">
            <td colspan="2" style="height: 10px; text-align: left">Pending Approvals :</td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:DropDownList ID="DDLPendApprov" runat="server" Style="width: 198px" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DDLPendApprov_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <%--  <tr id ="row2" >        
            <td colspan="2" style="height: 10px; text-align: left">
                Application No :
                </td>            
                
                <td colspan="2" style="height: 10px; text-align: left">
                <asp:TextBox ID="txt_Applno" runat="server" TextMode="SingleLine" width="162px" Enabled="False" ></asp:TextBox>
                </td>
        </tr>--%>
        <tr id="row3">

            <td colspan="2" style="height: 10px; text-align: left">Employee Name :
            </td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:TextBox ID="txt_Name" runat="server" TextMode="SingleLine" Width="191px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr id="row4">

            <td colspan="2" style="height: 10px; text-align: left">Employee Code :
            </td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:TextBox ID="txt_emp_code" runat="server" TextMode="SingleLine" Width="191px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr id="row5">

            <td colspan="2" style="height: 10px; text-align: left">SSLC Certificate No :
            </td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:TextBox ID="txt_SSLC_No" runat="server" TextMode="SingleLine" Width="191px" Enabled="False"></asp:TextBox>

            </td>
        </tr>

        <tr id="row6">

            <td colspan="2" style="height: 10px; text-align: left">Year of Passing :
            </td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:DropDownList ID="DDL_year_Pass" runat="server" Width="198px" Enabled="False">
                    <asp:ListItem Text="--Select One--" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr id="row7">

            <td colspan="2" style="height: 10px; text-align: left">State :
            </td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:DropDownList ID="DDL_State_Pas" runat="server" Width="198px" Enabled="False">
                    <asp:ListItem Text="--Select One--" Value="0"></asp:ListItem>
                </asp:DropDownList>

            </td>
        </tr>

        <tr id="row8">

            <td colspan="2" style="height: 10px; text-align: left"></td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:LinkButton ID="lnk_view_Cert" runat="server" Text="View Certificate" OnClientClick="javascript:window.open('SSLC_Img_Certificate.aspx','Image','left=250px, top=245px, width=800px, status=no, resizable=yes');return false;"></asp:LinkButton>
            </td>
        </tr>

        <tr id="row9">

            <td colspan="2" style="height: 10px; text-align: left">Remarks (if  any) :
            </td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:TextBox ID="txt_Remarks" runat="server" Text="" TextMode="MultiLine" Width="191px"></asp:TextBox>
            </td>
        </tr>

        <tr id="row10">

            <td colspan="2" style="height: 10px; text-align: center">
                <asp:Button ID="bttn_Approve" runat="server" Text="Approve" />
            </td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:Button ID="bttn_Reject" runat="server" Text="Reject" />
            </td>
        </tr>

    </table>
    <%--</ContentTemplate>
 </asp:UpdatePanel> --%>
</asp:Content>

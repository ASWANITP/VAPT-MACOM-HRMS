<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="SSLC_Updation.aspx.vb" Inherits="WebAppHRMS.payroll_Posting_SSLC_Updation_a6f1e0b73524" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">
        var cont = header.split("txt")
        //function btnExit_onclick() {  window.open('/EMIMenu.aspx','_self'); }
        function btnExit_onclick() { window.open('../../home.aspx', '_self'); }
        function Request_Onclick() {

   //var SSLNO  = document.getElementById('<%=Me.txt_SSLC_NO.ClientID%>').value;
            var SSLCNO = document.getElementById(cont[0] + "txt_SSLC_NO").value;
            var SSLCYR = document.getElementById(cont[0] + "DDL_year_Pass").value;
            var SSLCST = document.getElementById(cont[0] + "DDL_State_Pas").value;

            if (SSLCNO == "") { alert("Enter the SSLC Certificate No !"); document.getElementById(cont[0] + "txt_SSLC_NO").focus(); return false; }

            if (SSLCYR == 0) { alert("Please Select the Year of Passing !"); document.getElementById(cont[0] + "DDL_year_Pass").focus(); return false; }

            if (SSLCST == 0) { alert("Pleae Select the State of Passing !"); document.getElementById(cont[0] + "DDL_State_Pas").focus(); return false; }


            if (document.getElementById(cont[0] + "FUploadCert").value == "") {
                alert("Please Upload Your Scanned Copy of SSLC Certificate..!");
                document.getElementById(cont[0] + "FUploadCert").focus();
                return false;
            }
            if (document.getElementById(cont[0] + "FUploadCert").value != "") {
                //if (FutureDateControl()==false )  return false;
                var Control_1 = document.getElementById(cont[0] + "FUploadCert")

                if (FileExtensions(Control_1) == false) return false;
            }
        }


        //function FileExtensions(Control)
        //{

        //   var ctrlUpload = Control
        //   //var extensionList = new Array(".jpg", ".png", ".jpeg", ".gif", ".bmp", ".img", ".docx");
        //   var extensionList = new Array(".jpeg", ".bmp", ".jpg", ".gif");
        //   //var extension = ctrlUpload.value.slice(ctrlUpload.value.indexOf(".")).toLowerCase();
        //   var extension = ctrlUpload.value.slice(ctrlUpload.value.lastIndexOf(".")).toLowerCase();
        //     for (var i = 0; i < extensionList.length; i++)
        //        {
        //            if (extensionList[i] == extension)
        //            {
        //              
        //              if(A(ctrlUpload))  
        //              {
        //              return true;
        //              }
        //              else
        //              return false;
        //            }
        //        }
        //        alert("Please upload only Image Files,For Example:\n"+extensionList.join(","));
        //        ctrlUpload.focus();
        //        return false;  
        //}

        // function A(a)
        // {
        //var oas = new ActiveXObject("Scripting.FileSystemObject"); 
        //var d = a.value;
        // var e = oas.getFile(d);
        // var f = e.size;
        //if(f > 50000 )
        //{
        //alert("Please reduce files size to below 50 kb");
        //return false;
        //}
        //return true;
        //}

        function FileExtensions(Control) {

            var ctrlUpload = Control
            //var extensionList = new Array(".jpg", ".png", ".jpeg", ".gif", ".bmp", ".img", ".docx");
            var extensionList = new Array(".jpg", ".jpeg", ".gif", ".bmp");
            //var extension = ctrlUpload.value.slice(ctrlUpload.value.indexOf(".")).toLowerCase();
            var extension = ctrlUpload.value.slice(ctrlUpload.value.lastIndexOf(".")).toLowerCase();
            for (var i = 0; i < extensionList.length; i++) {
                if (extensionList[i] == extension) {

                    if (A(ctrlUpload)) {
                        return true;
                    }
                    else
                        return false;
                }
            }
            alert("Please upload only Image Files,For Example:\n" + extensionList.join(","));
            ctrlUpload.focus();
            return false;
        }

        function A(a) {
            var oas = new ActiveXObject("Scripting.FileSystemObject");
            var d = a.value;
            var e = oas.getFile(d);
            var f = e.size;
            if (f > 512000) {
                alert("Please reduce files size to below 500 kb");
                return false;
            }
            return true;
        }





    </script>

    <%-- <asp:UpdatePanel runat="Server" ID="upanel">
 <ContentTemplate>--%>
    <table border="1" style="width: 606px;" align="center">
        <tr>
        </tr>

        <tr id="row2">
            <td colspan="2" style="height: 10px; text-align: left">Employee Code :
            </td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:TextBox ID="txt_EmpCode" runat="server" TextMode="SingleLine" Width="162px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr id="row3">

            <td colspan="2" style="height: 10px; text-align: left">Employee Name :
            </td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:TextBox ID="txt_Name" runat="server" TextMode="SingleLine" Width="162px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr id="row5">

            <td colspan="2" style="height: 10px; text-align: left">SSLC Certificate No :
            </td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:TextBox ID="txt_SSLC_No" runat="server" TextMode="SingleLine" Width="162px"></asp:TextBox>

            </td>
        </tr>

        <tr id="row6">

            <td colspan="2" style="height: 10px; text-align: left">Year of Passing :
            </td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:DropDownList ID="DDL_year_Pass" runat="server" Width="170px">
                    <asp:ListItem Text="--Select One--" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr id="row7">

            <td colspan="2" style="height: 10px; text-align: left">State of Passing:
            </td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:DropDownList ID="DDL_State_Pas" runat="server" Width="170px">
                    <asp:ListItem Text="--Select One--" Value="0"></asp:ListItem>
                </asp:DropDownList>

            </td>
        </tr>

        <tr>
            <td colspan="2" style="height: 10px; text-align: left">
                <asp:Label ID="lbl_Certificate" runat="server" Text="Upload Certificate"></asp:Label><span style="color: #ff3300">* :&nbsp; </span>
            </td>
            <td colspan="2" style="height: 10px; text-align: left">

                <asp:FileUpload ID="FUploadCert" runat="server" Width="260px" Height="23px" />
            </td>
        </tr>

        <tr>
            <td colspan="2" style="height: 10px; text-align: left"></td>
            <td colspan="2" style="height: 10px; text-align: left">
                <asp:Label ID="lbl_Note" runat="server" Text="* Note: File Size should be less than 500 KB" ForeColor="red"></asp:Label>
            </td>
            <td style="text-align: left;" colspan="2"></td>
        </tr>

        <tr id="row9">

            <td colspan="2" style="height: 10px; text-align: left">Remarks (if  any) :
            </td>

            <td colspan="2" style="height: 10px; text-align: left">
                <asp:TextBox ID="txt_Remarks" runat="server" Text="" TextMode="MultiLine" Width="162px" Enabled="False"></asp:TextBox>
            </td>
        </tr>

        <tr id="row10">

            <td colspan="2" style="height: 10px; text-align: right">
                <asp:Button ID="bttn_Submit" runat="server" Text="Submit" />
            </td>

            <td colspan="2" style="height: 10px; text-align: left">
                <input id="btnExit" type="button" value="EXIT" onclick="return btnExit_onclick()" />
            </td>
        </tr>

    </table>
    <%--</ContentTemplate>
 </asp:UpdatePanel>--%>
</asp:Content>


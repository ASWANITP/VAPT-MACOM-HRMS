<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/edp.Master" CodeBehind="Acc_file_Request.aspx.vb" Inherits="WebAppHRMS.Acc_file_Request" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="server">
         <style>
/* ── Container Styling ───────────────────────────────────────────────────── */
#tblApprenticeForm {
  /* gradient background + rounded corners + drop shadow */
  /*background: linear-gradient(to right, #E0BBE4, #C3D9EF);
  border-radius: 12px;
  box-shadow: 0 6px 15px rgba(0,0,0,0.1);*/

  box-shadow: 0 4px 12px rgba(0,0,0,0.08);
  border-radius: 12px;
  background: linear-gradient(to right, #b3cde0, #f0f8ff);

  /* table settings */
  width: 100%;              /* full width of its wrapper */
  border-collapse: collapse;
  margin: 30px auto;        /* center + breathing room */
  padding: 20px;            /* this only works on display:block tables */
  display: block;           /* make padding on table work */
  box-sizing: border-box;
}

/* ── Cell & Label Layout ───────────────────────────────────────────────── */
#tblApprenticeForm td {
  padding: 10px;
  vertical-align: middle;
}
#tblApprenticeForm td label,
#tblApprenticeForm td .aspNetLabel {
  display: block;
  font-weight: bold;
  color: #2F4F6F;
  text-align: right;
  padding-right: 10px;
}

/* ── Inputs & Selects ───────────────────────────────────────────────────── */
#tblApprenticeForm input[type="text"],
#tblApprenticeForm select,
#tblApprenticeForm .aspNetTextBox {
  width: 100%;
  padding: 8px 10px;
  font-size: 15px;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}
#tblApprenticeForm input[readonly] {
  background-color: #f5f5f5;
}



/* ── Section Headers (row9) ─────────────────────────────────────────────── */
#tblApprenticeForm tr[id^="row9"] td {
  border-top: 1px solid #ccc;
  padding-top: 15px;
  font-weight: bold;
  color: #2F4F6F;
  text-align: center;
  height:100%;
}

/* ── Buttons ───────────────────────────────────────────────────────────── */
#tblApprenticeForm input[type="button"],
#tblApprenticeForm input[type="submit"],
#tblApprenticeForm button,
#tblApprenticeForm .aspNetButton {
  padding: 10px 25px;
  font-size: 16px;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  background-color: #2F4F6F;
  color: #fff;
  transition: background-color .3s ease;
}
#tblApprenticeForm input[type="button"]:hover,
#tblApprenticeForm input[type="submit"]:hover,
#tblApprenticeForm button:hover,
#tblApprenticeForm .aspNetButton:hover {
  background-color: #1c5fc0;
}
</style>

    <script>
        function Button1_onclick() {
            window.open('../home.aspx', '_self')
        }

        function storeFilePath() {
            var fileUpload = document.getElementById('<%= FileUpload1.ClientID %>');
var filePath = fileUpload.value;
            document.getElementById('<%= hid1.ClientID %>').value = filePath;
        }
        

        function isAlphabetKey(evt) {
            var charCode = evt.which ? evt.which : evt.keyCode;
            // Allow only alphabets (65-90 uppercase, 97-122 lowercase, space - 32)
            if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122) || charCode === 32) {
                return true;
            }
            return false;
        }

       
    </script>
    <script type="text/javascript">
        function validateForm() {
            if (document.getElementById('<%= files_nos.ClientID %>').value.trim() === "") {
            alert("please fill file number");
            return false;
        }

        if (document.getElementById('<%= purpose.ClientID %>').value.trim() === "") {
            alert("please fill purpose");
            return false;
        }

        var ddl = document.getElementById('<%= cmb_dep.ClientID %>');
        if (ddl.value.trim() === "" || ddl.value.indexOf("Select") !== -1) {
                alert("please select receiver name");
                return false;
        }


        if (document.getElementById('<%= FileUpload1.ClientID %>').value.trim() === "") {
            alert("please upload file");
            return false;
        }

        if (document.getElementById('<%= remark.ClientID %>').value.trim() === "") {
                alert("please fill remark");
                return false;
            }

            return true; 
        }
    </script>

       <div style="text-align: center">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--<cc1:calendarextender id="CalendarExtender1" runat="server" format="dd/MMM/yyyy" targetcontrolid="txt_jodt"></cc1:calendarextender>--%>
    <asp:HiddenField ID="hdn_sysdate" runat="server" />
 
           <asp:Label ID="lbl_err" runat="server" Height="24px" Width="642px" Font-Bold="True" Font-Size="Larger" ForeColor="Red"></asp:Label><br />
    <table id="tblApprenticeForm" style="width: 1000px;">
        <tr>
            <td colspan="3" style="text-align: right">File Name:</td>
            <td colspan="3" style="text-align: left">
                <input id="files_nos" style="width: 241px"  type="text" runat="server" maxlength="100" />
            </td>
        </tr>
        <tr>
             <td style="height: 23px;text-align:left;">Requester Name</td>
 <td colspan="2" style="height: 23px; text-align: left">
     <input id="req_name" runat="server" style="width: 241px" type="text" readonly="readOnly" /></td>
           
             <td style="width: 5762px; text-align: left">Department Name</td>
<td style="text-align: left" colspan="2">
    <input id="dep_name"  runat="server" style="width: 250px" type="text" maxlength="2" readonly="readonly" /></td>
        </tr>
        <tr>
              
            <td style="width: 5762px; text-align: left">Purpose</td>
            <td style="text-align: left" colspan="2">
                <input id="purpose" runat="server" onkeypress =" return isAlphabetKey(event);" style="width: 250px" type="text" maxlength="50"  /></td>

            <td style="width: 154px; text-align: left">Receiver Name </td>
            <td colspan="2" style="text-align: left">
                <asp:DropDownList ID="cmb_dep" runat="server" Width="250px">
    <asp:ListItem Text="-- Select Receiver --" Value=""></asp:ListItem>
</asp:DropDownList>
</td>
           
        </tr>
         
        <tr>
           <td style="width: 5762px; text-align: left">Upload File</td>
<td style="text-align: left" colspan="2"><asp:FileUpload ID="FileUpload1"  runat="server" Style="text-align: center;" /><br />
</td>

             <td style="width: 154px; text-align: left">Remarks </td>
 <td colspan="2" style="text-align: left">
     <input id="remark" runat="server" style="width: 250px" type="text" maxlength="100"  /></td>
        </tr>

        
        <tr>
            <td style="width: 154px; height: 14px; text-align: left">&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
            <td colspan="2" style="height: 14px; text-align: right">
                <asp:Button ID="cmd_confirm" OnClientClick="return validateForm();"  runat="server"  Text="CONFIRM" style="width:130px; height:32px;"  /></td>
            <td style=" height: 14px; text-align: right">
                <input id="Button1" type="button" value="EXIT" onclick="return Button1_onclick()" style="width:130px; height:32px;" /></td>
            <td style="height: 14px; text-align: left" colspan="2">&nbsp;&nbsp;
            </td>
        </tr>

    </table>

    <input id="hid1" runat="server" style="width: 11px" type="hidden" />
    <input id="hid2" runat="server" style="width: 11px" type="hidden" />
    <input id="hid_da" runat="server" style="width: 11px" type="hidden" />
    <input id="hid_appln_no" runat="server" style="width: 11px" type="hidden" />
    <br />

    <input id="hid_datas" runat="server" style="width: 11px" type="hidden" />
    <input id="hid_others" runat="server" style="width: 11px" type="hidden" />


</div>
</asp:Content>
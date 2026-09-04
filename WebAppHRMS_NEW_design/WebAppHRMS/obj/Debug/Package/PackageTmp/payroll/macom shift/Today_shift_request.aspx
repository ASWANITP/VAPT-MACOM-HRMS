<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/edp.master" CodeBehind="Today_shift_request.aspx.vb" Inherits="WebAppHRMS.Today_shift_request" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

   

    <style>
        .shiftFormContainer {
            max-width: 600px;
            margin: 20px auto;
            padding: 15px;
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            grid-row-gap: 12px;
            grid-column-gap: 16px;
            background: linear-gradient(to right, #b3cde0, #f0f8ff);
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.08);
            box-sizing: border-box;
        }

        .scrTextBox,
        select {
            width: 100%;
            padding: 6px 8px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        .scrTextBox[readonly] {
            background-color: #f5f5f5;
        }

        .formField,
        .datePickerWrapper {
            display: flex;
            flex-direction: column;
        }

        .formField label,
        .datePickerWrapper label {
            font-weight: bold;
            color: #2F4F6F;
            margin-bottom: 4px;
        }

        .remarksField {
            grid-column: 1 / span 2;
        }

        .buttonRow {
            grid-column: 1 / span 2;
            display: flex;
            justify-content: center;
            align-items: center;
            gap: 20px;
            margin-top: 8px;
            padding-top: 10px;
            width: 100%;
        }

        .scrButton {
            padding: 10px 30px;
            font-size: 14px;
            border: none;
            border-radius: 6px;
            background-color: #2F4F6F;
            color: #fff;
            cursor: pointer;
            transition: background-color .3s ease;
            min-width: 120px;            
            text-align: center;
        }

        .scrButton:hover {
            background-color: #1c5fc0;
        }

        .scrLabel {
            font-size: 14px;
            color: #2F4F6F;
            font-weight: bold;
            text-align: center;
            grid-column: 1 / span 2;
            margin-top: 8px;
        }

        .calendarPopup {
    background-color: white !important; 
    border: 1px solid #ccc;            
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.2); 
    z-index: 1000;                   

        }


    </style>


    <div class="shiftFormContainer">
       <!-- Employee Code Dropdown -->
     <div class="formField">
         <label for="ddlEmpCode">Employee Code</label>
         <asp:DropDownList ID="ddlEmpCode" runat="server" CssClass="scrTextBox" AutoPostBack="true" OnSelectedIndexChanged="ddlEmpCode_SelectedIndexChanged" />
    </div>

        <!-- Employee Name -->
        <div class="formField">
             <label for="txtEmployeeName">Employee Name</label>
                <asp:TextBox ID="Emp_name" runat="server" CssClass="scrTextBox" />
        </div>

        <!-- Department -->
        <div class="formField">
            <label for="txtDepartment">Department</label>
                <asp:TextBox ID="Emp_dep" runat="server" CssClass="scrTextBox" />
        </div>


             <!-- Current Shift -->
            <div class="formField">
                 <label for="txtCurrentshift">CurrentShift</label>
                    <asp:TextBox ID="shift_name" runat="server" CssClass="scrTextBox" />
            </div>


        <!-- Shift Selection -->
                <div class="formField">
    <label for="ddlShiftSelection">Shift Selection</label>
    <asp:DropDownList ID="ddlShiftSelection" runat="server" CssClass="scrTextBox" AutoPostBack="True">
    </asp:DropDownList>
                </div>


        <!-- Date of Shift Change -->
        <div class="datePickerWrapper">
           <label for="txtShiftChangeDate">Date of Shift Change</label>
               <asp:TextBox ID="txtShiftChangeDate" runat="server" CssClass="scrTextBox" ClientIDMode="Static"/>
<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtShiftChangeDate" Format="MM/dd/yyyy" CssClass="calendarPopup" PopupPosition= "Bottomright"  />
        </div>


        <!-- Remarks -->
        <div class="remarksField formField">
            <label for="txtRemarks">Remarks</label>
            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Rows="2"
                CssClass="scrTextBox" Style="height:60px;" onkeypress="onlyAlphabets(event)" />
        </div>

        <!-- Buttons -->
        <div class="buttonRow">
            <asp:Button ID="btnRequest" runat="server" Text="REQUEST"
                CssClass="scrButton" OnClick="btnRequest_Click" />
            <asp:Button ID="btnExit" runat="server" Text="EXIT"
                CssClass="scrButton" OnClientClick="window.location.href='../../home.aspx'; return false;" />
        </div>

    </div>

     <script>
         function validateDateInput(el) {
             const sd = new Date(el.value);
             const td = new Date();
             sd.setHours(0, 0, 0, 0);
             td.setHours(0, 0, 0, 0);

             if (sd.getTime() !== td.getTime()) {
                 alert("Please select Today's date.");
                 el.value = "";
             }
         }

         const dateInput = document.getElementById('txtShiftChangeDate');
         dateInput.addEventListener('input', () => validateDateInput(dateInput));
         dateInput.addEventListener('change', () => validateDateInput(dateInput));
     </script>

</asp:Content>

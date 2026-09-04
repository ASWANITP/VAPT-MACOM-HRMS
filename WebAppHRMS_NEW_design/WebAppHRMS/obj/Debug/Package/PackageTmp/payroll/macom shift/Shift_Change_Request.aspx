<%@ Page Language="vb" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Shift_Change_Request.aspx.vb" Inherits="WebAppHRMS.Shift_Change_Request" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <style>
        /* ── Outer Container as 2-col Grid ───────────────────────────────────── */
        #shiftFormContainer {
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

        /* ── Inputs & Selects (global) ───────────────────────────────────────── */
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

        /* ── Field Wrappers ───────────────────────────────────────────────────── */
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

        /* ── Remarks spans both columns ───────────────────────────────────────── */
        .remarksField {
            grid-column: 1 / span 2;
        }

        /* ── Buttons row spans both columns ──────────────────────────────────── */
        .buttonRow {
            grid-column: 1 / span 2;
            display: flex;
            justify-content: center;
            gap: 12px;
            margin-top: 8px;
        }

        /* ── Buttons & Message Label ─────────────────────────────────────────── */
        .scrButton {
            padding: 8px 20px;
            font-size: 14px;
            border: none;
            border-radius: 6px;
            background-color: #2F4F6F;
            color: #fff;
            cursor: pointer;
            transition: background-color .3s ease;
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
    </style>

    <div id="shiftFormContainer">
        <!-- Name -->
        <div class="formField">
            <label for="<%= txtName.ClientID %>">Name</label>
            <asp:TextBox ID="txtName" runat="server"
                ReadOnly="true" CssClass="scrTextBox" />
        </div>

        <!-- Employee Code -->
        <div class="formField">
            <label for="<%= txtEmpCode.ClientID %>">Employee Code</label>
            <asp:TextBox ID="txtEmpCode" runat="server"
                ReadOnly="true" CssClass="scrTextBox" />
        </div>

        <!-- Current Shift -->
        <div class="formField">
            <label for="<%= txtCurrentShift.ClientID %>">Current Shift</label>
            <asp:TextBox ID="txtCurrentShift" runat="server"
                ReadOnly="true" CssClass="scrTextBox" />
        </div>

        <!-- New Shift -->
        <div class="formField">
            <label for="<%= ddlNewShift.ClientID %>">New Shift</label>
            <asp:DropDownList ID="ddlNewShift" runat="server" CssClass="scrTextBox" />
        </div>

        <!-- Department -->
        <div class="formField">
            <label for="<%= txtDepartment.ClientID %>">Department</label>
            <asp:TextBox ID="txtDepartment" runat="server"
                ReadOnly="true" CssClass="scrTextBox" />
        </div>

        <!-- Requested Date (auto-filled with today, no picker) -->
        <div class="formField">
            <label for="<%= txtRequestedDate.ClientID %>">Requested Date</label>
            <asp:TextBox ID="txtRequestedDate" runat="server"
                CssClass="scrTextBox"
                ReadOnly="true" />
        </div>

        <!-- Effective Date -->

        <div class="datePickerWrapper">
            <label for="txtEffectiveDate">Effective Date</label>
            <input type="date" id="txtEffectiveDate" runat="server" name="txtEffectiveDate" class="scrTextBox" style="width: 100%; " ClientIDMode="Static"  />

        </div>

        <!-- Remarks (full width) -->
        <div class="remarksField formField">
            <label for="<%= txtRemarks.ClientID %>">Remarks</label>
            <asp:TextBox ID="txtRemarks" runat="server"
                TextMode="MultiLine" Rows="2"
                CssClass="scrTextBox"
                Style="height: 60px;" />
        </div>

        <!-- Buttons -->
        <div class="buttonRow">
            <asp:Button ID="btnSubmit" runat="server"
                Text="Submit Request"
                CssClass="scrButton"
                OnClick="btnSubmit_Click"
                OnClientClick="return btnSub_Click();" />
            <button id="btnExit" type="button"
                class="scrButton"
                style="width: 150px;"
                onclick="btnExit_Click()">
                EXIT</button>
        </div>

        <!-- Status Message -->
        <asp:Label ID="lblMessage" runat="server" CssClass="scrLabel" />
    </div>

    <script type="text/javascript">
        function btnExit_Click() {
            window.location.href = '../../home.aspx';
        }

        function btnSub_Click() {
            if (document.getElementById('<%= txtEffectiveDate.ClientID %>').value === "") {
              alert("please select the effective date");
              return false;
          }
          if (document.getElementById('<%= ddlNewShift.ClientID %>').value === "-1") {
                alert("please select the new shift");
                return false;
            }
            else {
                return true;
            }
        }

        function validateDateInput(inputElement) {
            const selectedDate = new Date(inputElement.value);
            const today = new Date();

            // Clear time portion for accurate comparison
            selectedDate.setHours(0, 0, 0, 0);
            today.setHours(0, 0, 0, 0);

            if (selectedDate <= today) {
                alert("Please select a future date.");
                inputElement.value = ""; // Optionally clear the invalid input
            }
        }

        // Attach to one or more inputs
        const dateInput = document.getElementById('txtEffectiveDate');
        dateInput.addEventListener('input', () => validateDateInput(dateInput));


    </script>
</asp:Content>

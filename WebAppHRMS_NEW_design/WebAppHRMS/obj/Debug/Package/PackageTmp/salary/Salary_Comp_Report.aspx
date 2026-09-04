<%@ Page Language="vb" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Salary_Comp_Report.aspx.vb" Inherits="WebAppHRMS.Salary_Comp_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <script type="text/javascript">


        function Button2_Click() {
            window.open("../home.aspx", "_self");
        }

        <%--function btnSub_Click() {
            if (document.getElementById('<%= txtFromMonth.ClientID %>').value === "") {
                alert("please select the from month");
                return false;
            }
            if (document.getElementById('<%= txtToMonth.ClientID %>').value === "") {
                alert("please select the to month");
                return false;
            }
            return true;
        }--%>
        function btnSub_Click() {
            var fromVal = document.getElementById('<%= txtFromMonth.ClientID %>').value;
            var toVal = document.getElementById('<%= txtToMonth.ClientID %>').value;

            if (fromVal === "") {
                alert("Please select the From Month");
                return false;
            }
            if (toVal === "") {
                alert("Please select the To Month");
                return false;
            }

            if (fromVal === toVal) {
                alert("From Month and To Month cannot be the same.");
                return false;
            }
            // Parse yyyy-MM into Date objects (set to first day of month)
            var fromDate = new Date(fromVal + "-01");
            var toDate = new Date(toVal + "-01");

            // Current month start
            var today = new Date();
            var currentMonthStart = new Date(today.getFullYear(), today.getMonth(), 1);

            // If either selected month is current or future
            if (fromDate >= currentMonthStart || toDate >= currentMonthStart) {
                alert("You cannot select the current month or a future month.");
                return false;
            }
            

            return true;
        }

    </script>

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
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.08);
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
            position: relative;

        }
       

            .scrTextBox[readonly] {
                background-color: #f5f5f5;
            }

            .scrTextBox::-webkit-calendar-picker-indicator {
                position: absolute;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                color: transparent;
                background: transparent;
                cursor: pointer;
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

        /* ── Heading spans both columns ──────────────────────────────────────── */
        .scrLabel {
            font-size: 16px;
            color: #2F4F6F;
            font-weight: bold;
            text-align: center;
            grid-column: 1 / span 2;
            margin-bottom: 12px;
        }

        /* ── Buttons row spans both columns ──────────────────────────────────── */
        .buttonRow {
            grid-column: 1 / span 2;
            display: flex;
            justify-content: center;
            gap: 12px;
            margin-top: 8px;
        }

        /* ── Buttons ──────────────────────────────────────────────────────────── */
        .scrButton {
            padding: 8px 20px;
            font-size: 14px;
            border: none;
            border-radius: 6px;
            background-color: #2F4F6F;
            color: #fff;
            cursor: pointer;
            width: 120px;
            text-align: center;
            transition: background-color 0.3s ease;
        }

            .scrButton:hover {
                background-color: #1c5fc0;
            }

        .monthBox {
            width: 150px; /* adjust as needed */
        }

       
    </style>


    <div id="shiftFormContainer">
        <span class="scrLabel">SALARY COMPARISON REPORT
     </span>

        <div class="datePickerWrapper">
            <label for="<%= txtFromMonth.ClientID %>">FROM MONTH</label>
            <input
                type="month"
                id="txtFromMonth"
                runat="server"
                class="scrTextBox" />
        </div>

        <div class="datePickerWrapper">
            <label for="<%= txtToMonth.ClientID %>">TO MONTH</label>
            <input
                type="month"
                id="txtToMonth"
                runat="server"
                class="scrTextBox" />
        </div>

        <div class="buttonRow">
            <asp:Button
                ID="Button1"
                runat="server"
                CssClass="scrButton"
                Text="COMPARE"
                OnClientClick="return btnSub_Click();" />
            <asp:Button
                ID="Button2"
                runat="server"
                CssClass="scrButton"
                Text="EXIT"
                OnClientClick="Button2_Click(); return false;" />
        </div>
    </div>

</asp:Content>

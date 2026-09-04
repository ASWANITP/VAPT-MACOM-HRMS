<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/edp.master" CodeBehind="TL_oneday_repo.aspx.vb" Inherits="WebAppHRMS.TL_oneday_repo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <script type="text/javascript">
        //function correct(a, e) {
        //    document.getElementById("ctl00_cph_edp_" + a).value = "";
        //    document.getElementById("ctl00_cph_edp_" + a).focus();
        //}

        function Button2_Click() {
            window.open("../../home.aspx", "_self");
        }

        function btnSub_Click() {
            if (document.getElementById('<%= txtFromDate.ClientID %>').value === "") {
                alert("please select the from date");
                return false;
            }
            if (document.getElementById('<%= txtToDate.ClientID %>').value === "") {
                alert("please select the to date");
                return false;
            }
            else {
                return true;
            }
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
        position: relative;  /* positioning context for calendar overlay */
    }

    .scrTextBox[readonly] {
        background-color: #f5f5f5;
    }

    /* ── Stretch the native calendar icon overlay ─────────────────────────── */
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
        transition: background-color 0.3s ease;
    }

    .scrButton:hover {
        background-color: #1c5fc0;
    }
</style>

<div id="shiftFormContainer">
    <span class="scrLabel">
       TEAM LEAD RECOMMEND ONEDAY SHIFT REPORT
    </span>

    <div class="datePickerWrapper">
        <label for="<%= txtFromDate.ClientID %>">FROM DATE</label>
        <input
            type="date"
            id="txtFromDate"
            runat="server"
            class="scrTextBox" />
    </div>

    <div class="datePickerWrapper">
        <label for="<%= txtToDate.ClientID %>">TO DATE</label>
        <input
            type="date"
            id="txtToDate"
            runat="server"
            class="scrTextBox" />
    </div>

    <div class="buttonRow">
        <asp:Button
            ID="Button1"
            runat="server"
            CssClass="scrButton"
            Text="CONFIRM"
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
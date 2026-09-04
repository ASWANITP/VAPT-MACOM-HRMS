<%@ Page Language="vb" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Shift_Sanction_Dephead.aspx.vb" Inherits="WebAppHRMS.Shift_Sanction_Dephead" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <style>
        /* ── Outer Container ───────────────────────────────────────────────────── */
        #shiftApprovalFormContainer {
            max-width: 600px;
            margin: 20px auto;
            padding: 15px;
            background: linear-gradient(to right, #b3cde0, #f0f8ff); /* soft blue fade */
            border-radius: 12px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.08);
            box-sizing: border-box;
        }

        /* ── Table Layout ──────────────────────────────────────────────────────── */
        #tblShiftApproval {
            width: 100%;
            border-collapse: collapse;
            table-layout: fixed;
        }

            #tblShiftApproval td {
                width: 50%;
                padding: 8px;
                vertical-align: top;
            }

        /* ── Centered First Row & Odd Items ─────────────────────────────────── */
        .scrCenterCell {
            text-align: center;
            padding-bottom: 12px;
        }

            .scrCenterCell label {
                display: block;
                font-weight: bold;
                color: #2F4F6F;
                margin-bottom: 6px;
            }

        /* ── Labels ─────────────────────────────────────────────────────────── */
        #tblShiftApproval label {
            display: block;
            font-weight: bold;
            color: #2F4F6F;
            margin-bottom: 4px;
            text-align: left;
        }

        /* ── Inputs & Selects ───────────────────────────────────────────────── */
        .scrTextBox,
        #tblShiftApproval select {
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

        /* ── Buttons & Messages ─────────────────────────────────────────────── */
        .scrButtonCell {
            text-align: center;
            padding-top: 12px;
        }

        .scrButton {
            padding: 8px 20px;
            font-size: 14px;
            border: none;
            border-radius: 6px;
            background-color: #2F4F6F;
            color: #fff;
            cursor: pointer;
            transition: background-color .3s ease;
            margin: 0 5px;
        }

            .scrButton:hover {
                background-color: #1c5fc0;
            }

        .scrLabel {
            font-size: 14px;
            color: green;
            margin-top: 10px;
            display: block;
        }
    </style>

    <div id="shiftApprovalFormContainer">
        <table id="tblShiftApproval">
            <!-- Centered employee selector -->
            <tr>
                <td colspan="2" class="scrCenterCell">
                    <label for="<%= ddlEmployee.ClientID %>">Select Employee</label>
                    <asp:DropDownList
                        ID="ddlEmployee"
                        runat="server"
                        CssClass="scrTextBox"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged" />
                </td>
            </tr>

            <!-- Employee code & name -->
            <tr>
                <td>
                    <label for="<%= txtEmpCode.ClientID %>">Employee Code</label>
                    <asp:TextBox
                        ID="txtEmpCode"
                        runat="server"
                        ReadOnly="true"
                        CssClass="scrTextBox" />
                </td>
                <td>
                    <label for="<%= txtName.ClientID %>">Name</label>
                    <asp:TextBox
                        ID="txtName"
                        runat="server"
                        ReadOnly="true"
                        CssClass="scrTextBox" />
                </td>
            </tr>

            <!-- Manager name & old shift -->
            <tr>
                <td>
                    <label for="<%= txtManagerName.ClientID %>">First Line Manager</label>
                    <asp:TextBox
                        ID="txtManagerName"
                        runat="server"
                        ReadOnly="true"
                        CssClass="scrTextBox" />
                </td>
                <td>
                    <label for="<%= txtOldShift.ClientID %>">Old Shift</label>
                    <asp:TextBox
                        ID="txtOldShift"
                        runat="server"
                        ReadOnly="true"
                        CssClass="scrTextBox" />
                </td>
            </tr>

            <!-- Requested shift & effective date -->
            <tr>
                <td>
                    <label for="<%= ddlRequestedShift.ClientID %>">Requested Shift</label>
                    <asp:TextBox ID="ddlRequestedShift" runat="server"
                        ReadOnly="true" CssClass="scrTextBox" />
                </td>
                <td>
                    <label for="<%= txtEffectiveDate.ClientID %>">Effective Date</label>
                    <asp:TextBox
                        ID="txtEffectiveDate"
                        runat="server"
                        CssClass="scrTextBox" />
                    <cc1:CalendarExtender
                        ID="ceEffectiveDate"
                        runat="server"
                        TargetControlID="txtEffectiveDate"
                        Format="dd-MM-yyyy" />
                </td>
            </tr>

            <!-- Remarks (odd item centered) -->
            <tr>
                <td colspan="2" class="scrCenterCell">
                    <label for="<%= txtRemarks.ClientID %>">Remarks</label>
                    <asp:TextBox
                        ID="txtRemarks"
                        runat="server"
                        TextMode="MultiLine"
                        Rows="2"
                        CssClass="scrTextBox"
                        Style="height: 60px;" />
                </td>
            </tr>

            <!-- Recommend, Reject & Exit buttons -->
            <tr>
                <td colspan="2" class="scrButtonCell">
                    <asp:Button
                        ID="btnRecommend"
                        runat="server"
                        Text="Recommend"
                        CssClass="scrButton"
                        OnClick="btnRecommend_Click" />
                    <asp:Button
                        ID="btnReject"
                        runat="server"
                        Text="Reject"
                        CssClass="scrButton"
                        OnClick="btnReject_Click" />
                    <button id="btnExit" type="button"
                        class="scrButton"
                        onclick="btnExit_Click()">
                        EXIT</button>
                </td>
            </tr>

            <!-- Feedback message -->
            <tr>
                <td colspan="2" class="scrButtonCell">
                    <asp:Label
                        ID="lblMessage"
                        runat="server"
                        CssClass="scrLabel" />
                </td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        function btnExit_Click() {
            window.open('../../home.aspx', '_self');
        }
    </script>
</asp:Content>

<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="School_Holiday.aspx.vb" Inherits="WebAppHRMS.macom_shift_change_School_Holiday_4dda2a571831" %>

<%@ MasterType VirtualPath="~/edp.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        var cs = cont_name.split("txt")
        function btn_exit_onclick() {
            window.open('../home.aspx', '_self');
        }
        function date_enter() {
            alert('Please Enter Date using Calendar.Please Click Respective box for Calendar!!')
            document.getElementById(cs[0] + "txt_dt").value = ""
            document.getElementById(cs[0] + "txt_dt").focus;
        }
        function btn_onclick() {
            if (document.getElementById(cs[0] + "txt_dt").value == "") {
                alert('Fill Date Field .Please Click Respective box for Calendar!!')
                document.getElementById(cs[0] + "txt_dt").value = ""
                document.getElementById(cs[0] + "txt_dt").focus;
                return false;
            }
            var emp_id = document.getElementById(cs[0] + "txt_dt").value;
            var i = 0;
            for (i = 0; i < document.getElementById(cs[0] + "ListBox_date").options.length; i++) {
                var sele_id = document.getElementById(cs[0] + "ListBox_date").options(i).value;
                if (emp_id == sele_id) {
                    alert("This Date Is Already Declared As Holiday")
                    document.getElementById(cs[0] + "txt_dt").focus;
                    return false;
                }
            }
        }

    </script>
    <div style="text-align: center">
        <div style="text-align: center">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div style="text-align: center">
                        <table style="width: 70%" border="1">
                            <tbody>
                                <tr>
                                    <td style="width: 50%">Select&nbsp;State</td>
                                    <td style="width: 50%">
                                        <asp:DropDownList ID="DDL_state" runat="server" Width="238px" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td colspan="2"><strong>Already&nbsp;Declared&nbsp;Holidays</strong></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:ListBox ID="ListBox_date" runat="server" Width="224px" ForeColor="Red" Height="89px" AutoPostBack="True" Enabled="False"></asp:ListBox></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div style="text-align: center">
                <table border="1" style="width: 70%">
                    <tr>
                        <td style="width: 50%">Holiday&nbsp;Date</td>
                        <td style="width: 50%">
                            <asp:TextBox ID="txt_dt" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
        </div>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy" TargetControlID="txt_dt"></cc1:CalendarExtender>
        <div style="text-align: center">
            <table border="1" style="width: 20%">
                <tr>
                    <td style="width: 50%">
                        <asp:Button ID="btn_submit" runat="server" Text="SUBMIT" /></td>
                    <td style="width: 50%">
                        <input id="btn_exit" style="width: 88px" type="button" value="EXIT" onclick="return btn_exit_onclick()" /></td>
                </tr>
            </table>
        </div>
        <br />
    </div>
</asp:Content>


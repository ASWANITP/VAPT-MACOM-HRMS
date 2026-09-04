<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Service_Record_Form_All_Employees.aspx.vb" Inherits="WebAppHRMS.Service_Record_Form_adc19a5c6704" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<center>
    <span style="font-size: 14pt"><span><span style="text-decoration: underline"><strong>
        ..SERVICE RECORD..<br />
    </strong></span>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        &nbsp;&nbsp;<br />
    </span><span style="font-size: 9pt">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp;</span></span>
            </center>
    <center>
        <table>
            <tr>
                <td style="width: 201px">
                    Select Employee Range:&nbsp;</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_emp1" runat="server"></asp:TextBox></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txt_emp2" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 201px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 201px; height: 26px">
                    <span style="font-size: 9pt">Click here to view Service Record &nbsp;
        &nbsp; </span>
                </td>
                <td style="width: 100px; height: 26px">
                    <asp:Button ID="Button1" runat="server"
            Text="Service Record" /></td>
                <td style="width: 100px; height: 26px">
                </td>
            </tr>
        </table>
    </center>
</asp:Content>


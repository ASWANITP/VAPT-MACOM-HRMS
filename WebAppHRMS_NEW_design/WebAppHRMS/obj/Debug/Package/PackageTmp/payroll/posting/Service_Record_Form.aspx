<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Service_Record_Form.aspx.vb" Inherits="WebAppHRMS.Service_Record_Form_adc19a5c7319" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <center>
        <span style="font-size: 14pt"><span><span style="text-decoration: underline"><strong>..SERVICE RECORD..<br />
        </strong></span>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="DropDownList1">
            </cc1:ListSearchExtender>
            <br />
        </span><span style="font-size: 9pt">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp;</span></span>
    </center>
    <center>
        <table>
            <tr>
                <td style="width: 201px">Select Employee :&nbsp;</td>
                <td style="width: 100px">
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="328px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 201px"></td>
                <td style="width: 100px"></td>
            </tr>
            <tr>
                <td style="width: 201px; height: 26px">
                    <span style="font-size: 9pt">Click here to view Service Record. &nbsp;
        &nbsp; </span>
                </td>
                <td style="width: 100px; height: 26px">
                    <asp:Button ID="Button1" runat="server"
                        Text="Service Record" /></td>
            </tr>
        </table>
    </center>
</asp:Content>


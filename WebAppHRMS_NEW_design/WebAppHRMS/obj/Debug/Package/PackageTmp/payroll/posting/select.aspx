<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="select.aspx.vb" Inherits="WebAppHRMS.Application_select_219125167630" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">
    <script language="javascript" type="text/javascript">
        // <!CDATA[

        function TABLE1_onclick() {

        }

        function Button1_onclick() {
            window.open("../../home.aspx", '_self');
        }

        // ]]>
    </script>

    <div style="text-align: center">
        &nbsp;
        <table border="1">
            <tr>
                <td colspan="2">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <table id="TABLE1" border="1" onclick="return TABLE1_onclick()"
                        style="width: 491px">
                        <tr>
                            <td colspan="4" style="text-align: center">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 1118px">
                                <strong>SelectCandidate :</strong></td>
                            <td colspan="3">
                                <asp:DropDownList ID="DropDownCandidate" runat="server" Width="348px">
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="BtnFind" runat="server" OnClick="BtnFind_Click" Text="Search" Width="121px" />
                    <input id="Button1" style="width: 127px" type="button" value="Exit" onclick="return Button1_onclick()" /></td>
            </tr>
        </table>
        &nbsp;
        &nbsp;&nbsp;
    </div>
    <cc1:ListSearchExtender ID="ListSearchExtender1" runat="server" TargetControlID="DropDownCandidate"></cc1:ListSearchExtender>
    <br />
    <br />
    <br />
    <div style="text-align: center">
        &nbsp;
    </div>
    <br />
</asp:Content>


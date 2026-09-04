<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="jewel_exp.aspx.vb" Inherits="WebAppHRMS.jwellary_reports_jewel_exp_91c29d5c2707" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Reset1_onclick() {
window.open("../../home.aspx","_self");
}

// ]]>
</script>

    <div style="text-align: center">
        <div style="text-align: center">
            <table border="1" style="width: 374px">
                <caption>
                    <span style="color: buttontext"><strong>JEWELLARY</strong> <strong>EMPLOYEEE</strong>
                        <strong>EXPERIENCE</strong></span></caption>
                <tr>
                    <td style="width: 148px">
                        <asp:RadioButton ID="rb_1" runat="server" GroupName="exp" Text="H.O EMPLOYEES" Width="154px" /></td>
                    <td style="width: 152px">
                        <asp:RadioButton ID="rb_2" runat="server" GroupName="exp" Text="BRANCH EMPLYEES" Width="180px" /></td>
                </tr>
                <tr>
                    <td style="width: 148px">
                    </td>
                    <td style="width: 152px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td style="width: 148px; text-align: right">
                        <asp:Button ID="Button1" runat="server" Text="CONFIRM" Width="101px" /></td>
                    <td style="width: 152px; text-align: left">
                        <input id="Reset1" style="width: 97px" type="reset" value="EXIT" onclick="return Reset1_onclick()" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>


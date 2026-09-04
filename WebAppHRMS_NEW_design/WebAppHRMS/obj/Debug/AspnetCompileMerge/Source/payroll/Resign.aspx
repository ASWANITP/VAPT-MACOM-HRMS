<%@ Page Language="VB" MasterPageFile="~/edp.master" AutoEventWireup="false" CodeBehind="Resign.aspx.vb" Inherits="WebAppHRMS.HRM_Resign_8adb8e3f9423" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/edp.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">

<script language="javascript" type="text/javascript">
// <!CDATA[
var con=header.split('ddl');

function btnExit_onclick() 
{
    window.open("../home.aspx","_self");
}
function ddlOnchange()
{
    document.getElementById(con[0]+"hiddn").value=document.getElementById(con[0]+"ddlPost").value;
}
function OnconfClick()
{
    if (document.getElementById(con[0]+"ddlpost").value==-1)
    {
        alert("Please Select the Post Name");
        document.getElementById(con[0]+"ddlpost").focus();
        return false;
    }
}


// ]]>
</script>
    <div style="text-align: center">
        <asp:HiddenField ID="hiddn" runat="server" />
        <br />
        <div style="text-align: center">
            <div style="text-align: center">
                <table border="1" style="width: 55%; position: relative; left: 0px; top: 0px;">
                    <tr>
                        <td style="width: 45%">
                            Post Name</td>
                        <td colspan="2" style="width: 618px; text-align: left;">
                            <asp:DropDownList ID="ddlpost" runat="server" Style="position: relative" Width="95%" onchange="ddlOnchange()">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Button ID="btnconfirm" runat="server" Style="position: relative" Text="CONFIRM" OnClientClick ="return OnconfClick()"/>
                            <input id="btnExit" style="width: 88px; position: relative; height: 24px" type="button"
                                value="EXIT" onclick ="return btnExit_onclick()" /></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 23px">
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div style="text-align: left">
        &nbsp;</div>
</asp:Content>


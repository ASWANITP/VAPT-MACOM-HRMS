<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="area_staffnorm.aspx.vb" Inherits="WebAppHRMS.staff_noms_area_staffnorm_7f3078b02971" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() {
window.open('home.aspx','_self');
}

// ]]>
</script>
</head>
<body text="#e0">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <br />
        <br />
        <br />
        <br />
        <div style="text-align: center">
            <table border="1">
                <tr>
                    <td style="width: 100px; text-align: left">
                        <asp:RadioButton ID="rdb_zonal" runat="server" GroupName="g" Text="Zonal" /></td>
                    <td style="width: 100px; text-align: left">
                        <asp:DropDownList ID="cmb_zonal" runat="server" AutoPostBack="True" Width="186px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 100px; text-align: left">
                        <asp:RadioButton ID="rdb_state" runat="server" GroupName="g" Text="State" Width="95px" /></td>
                    <td style="width: 100px; text-align: left">
                        <asp:DropDownList ID="cmb_state" runat="server" Width="186px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 100px; text-align: left">
                        <asp:RadioButton ID="rdb_region" runat="server" GroupName="g" Text="Region" /></td>
                    <td style="width: 100px; text-align: left">
                        <asp:DropDownList ID="cmb_region" runat="server" Width="186px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 24px; text-align: left">
                        <asp:RadioButton ID="rdb_division" runat="server" GroupName="g" Text="Division" /></td>
                    <td style="width: 100px; height: 24px; text-align: left">
                        <asp:DropDownList ID="cmb_division" runat="server" AutoPostBack="True" Width="184px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 100px; text-align: left;">
                        <asp:RadioButton ID="rdb_area" runat="server" GroupName="g" Text="Area" Width="92px" /></td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="cmb_area" runat="server" AutoPostBack="True" Width="186px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 100px; height: 24px; text-align: left;">
                        <asp:RadioButton ID="rdb_all" runat="server" Checked="True" GroupName="g" Text="All"
                            Width="91px" /></td>
                    <td style="width: 100px; height: 24px;">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        &nbsp;&nbsp;<input id="cmd_exit" type="button" value="EXIT" onclick="return Button1_onclick()" style="width: 88px" />
                    </td>
                    <td style="width: 100px">
                        <asp:Button ID="cmd_confirm" runat="server" Text="CONFIRM" /></td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>

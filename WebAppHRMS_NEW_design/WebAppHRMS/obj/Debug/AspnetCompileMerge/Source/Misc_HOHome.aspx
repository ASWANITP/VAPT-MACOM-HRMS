<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/edp.Master" CodeBehind="Misc_HOHome.aspx.vb" Inherits="WebAppHRMS.Misc_HOHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" Runat="Server">
    &nbsp;<div style="text-align: center">
        <asp:Menu ID="mnu_main" runat="server" BackColor="Red" BorderColor="AntiqueWhite"
            BorderStyle="None" DisappearAfter="-1" Font-Bold="True" ForeColor="White" MaximumDynamicDisplayLevels="6"
            Width="20%">
            <StaticSelectedStyle BackColor="#404040" />
            <StaticMenuItemStyle BackColor="Red" BorderColor="AntiqueWhite" BorderStyle="Solid"
                BorderWidth="1px" Font-Bold="True" Font-Italic="False" Font-Names="Times New Roman"
                Font-Overline="False" Font-Strikeout="False" ForeColor="White" Width="100%" />
            <DynamicHoverStyle BackColor="Red" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
            <DynamicMenuStyle BackColor="AntiqueWhite" BorderColor="Black" BorderStyle="None"
                BorderWidth="1px" />
            <DynamicSelectedStyle BackColor="#C04000" BorderStyle="None" />
            <DynamicMenuItemStyle BackColor="AntiqueWhite" BorderColor="Black" BorderStyle="Solid"
                BorderWidth="1px" Font-Bold="False" Font-Italic="False" Font-Names="Times New Roman"
                Font-Overline="False" ForeColor="Black" VerticalPadding="1px" Width="150px" />
            <StaticHoverStyle BackColor="Red" BorderStyle="None" Font-Bold="True" Font-Strikeout="False" />
            <Items>
                <asp:MenuItem Text="Accounts" Value="10"></asp:MenuItem>
                <asp:MenuItem Text="HRM" Value="50"></asp:MenuItem>
                <asp:MenuItem Text="Others" Value="60"></asp:MenuItem>
            </Items>
        </asp:Menu>
        &nbsp;
    </div>
</asp:Content>



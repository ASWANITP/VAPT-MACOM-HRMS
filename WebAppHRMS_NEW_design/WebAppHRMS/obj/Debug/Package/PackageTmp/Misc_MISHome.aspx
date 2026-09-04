<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/edp.Master" CodeBehind="Misc_MISHome.aspx.vb" Inherits="WebAppHRMS.Misc_MISHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_edp" runat="Server">

    <style type="text/css">
        #cph_edp_mnu_main ul {
            width: 100% !important;
        }

        .center-menu {
            display: flex;
            justify-content: center;
            text-align: center;
        }
    </style>
    &nbsp;<div class="center-menu">
        <asp:Menu ID="mnu_main" runat="server" BackColor="midnightblue" BorderColor="AntiqueWhite"
            BorderStyle="None" DisappearAfter="-1" Font-Bold="True" ForeColor="White" MaximumDynamicDisplayLevels="6"
            Width="20%">
            <StaticSelectedStyle BackColor="#404040" />
            <StaticMenuItemStyle BackColor="midnightblue" BorderColor="AntiqueWhite" BorderStyle="Solid"
                BorderWidth="1px" Font-Bold="True" Font-Italic="False" Font-Names="Times New Roman"
                Font-Overline="False" Font-Strikeout="False" ForeColor="White" />
            <DynamicHoverStyle BackColor="midnightblue" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
            <DynamicMenuStyle BackColor="AntiqueWhite" BorderColor="Black" BorderStyle="None"
                BorderWidth="1px" />
            <DynamicSelectedStyle BackColor="#C04000" BorderStyle="None" />
            <DynamicMenuItemStyle BackColor="AntiqueWhite" BorderColor="Black" BorderStyle="Solid"
                BorderWidth="1px" Font-Bold="False" Font-Italic="False" Font-Names="Times New Roman"
                Font-Overline="False" ForeColor="Black" VerticalPadding="1px" Width="150px" />
            <StaticHoverStyle BackColor="midnightblue" BorderStyle="None" Font-Bold="True" Font-Strikeout="False" />
            <Items>
                <asp:MenuItem Text="HRM" Value="50"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </div>
</asp:Content>

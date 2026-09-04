<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="ServiceRecord Cover.aspx.vb" Inherits="WebAppHRMS.ServiceRecord_Cover_9ca1569b4877" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-family: @MS Mincho"><strong>
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="577px" Style="z-index: 100;
                left: 40px; position: absolute; top: 68px" Width="1016px">
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" BorderStyle="Solid" Height="619px" Style="z-index: 100;
                left: 16px; position: absolute; top: 48px" Width="1064px">
                </asp:Panel>
            &nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/payroll/Posting/Service_Record_Form.aspx"
                Style="z-index: 101; left: 608px; position: absolute; top: 613px" Width="118px" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium">View Report</asp:HyperLink>
            <br />
            <br />
            <br /><div style=" font-family:Verdana; font-size:medium; font-style:normal; text-align:center">
                        "FORM BB"</div><br />
            <br /><div style=" font-family:Verdana; font-size:medium; font-style:normal ; text-align:center">
            [See Rule 101A]</div><br />
            <br />
            <br />
            <br />
            <br />
            <span style="font-size: 24pt"><div style=" font-family:Verdana; font-size:xlarge; font-style:normal ; text-align:center">
            SERVICE RECORD</div></span><br />
            <br />
            <br />
            <br />
            <br />
             <asp:Label ID="firm" runat="server" Style="z-index: 103; left: 296px; position: absolute;
                top: 360px" Text="Label" Width="464px" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Large" Height="24px"></asp:Label>
            <asp:Label ID="branch_lbl" runat="server" Style="z-index: 103; left: 160px; position: absolute;
                top: 432px" Text="Labe2" Width="600px" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Large" Height="24px"></asp:Label>
            <asp:Label ID="District" runat="server" Text="Labe3" Style="z-index: 103; left: 168px; position: absolute;
                top: 512px"  Width="576px" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Large" Height="24px"></asp:Label>
            <br /><div style=" font-family:Verdana; font-size:medium; font-style:normal;text-align:left">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Name of Establishment ................................................................</div>
            <br />
            <br />
            <br /><div style=" font-family:Verdana; font-size:medium; font-style:normal;text-align:left">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Place ...........................................................................................</div><br />
            <br />
            <br />
            <br /><div style=" font-family:Verdana; font-size:medium; font-style:normal ;text-align:left">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;District&nbsp; .......................................................................................</div><br />
          
            <br />
            <br />
            <br />
            <br />
            </strong></span>
    
    </div>
    </form>
</body>
</html>

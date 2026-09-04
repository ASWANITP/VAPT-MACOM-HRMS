<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Comparison_report.aspx.vb" Inherits="WebAppHRMS.Comparison_report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <script type="text/javascript">

        function Button1_onclick() {
            window.open("../home.aspx", '_self');
        }
        function demo() {
            document.getElementById('Button1').style.display = 'none'
            document.getElementById('submit').style.display = 'none'
            window.print();
            document.getElementById('Button1').style.display = 'inline'
            document.getElementById('submit').style.display = 'inline'
        }

        function exportToExcel() {
            var gvEarnings = document.getElementById('<%= gvEarnings.ClientID %>');
            var gvContrib = document.getElementById('<%= gvContrib.ClientID %>');
            var gvGrossal  = document.getElementById('<%= gvGrossal.ClientID %>');
            var gvAllin = document.getElementById('<%= gvAllin.ClientID %>');
            var gvEmpcount = document.getElementById('<%= gvEmpcount.ClientID %>');

            var html = "";

            // Add headings manually before each table
            html += "<h3 style='font-weight:bold;'>1. Earnings Comparison</h3>";
            html += gvEarnings.outerHTML + "<br/><br/>";

            html += "<h3 style='font-weight:bold;'>2. Deductions Comparison</h3>";
            html += gvContrib.outerHTML + "<br/><br/>";

            html += "<h3 style='font-weight:bold;'>3. GROSS SALARY COMPONENT BREAKDOWN</h3>";
            html += gvGrossal.outerHTML + "<br/><br/>";

            html += "<h3 style='font-weight:bold;'>4. ALLOWANCE AND INCENTIVE BREAKDOWN</h3>";
            html += gvAllin.outerHTML + "<br/><br/>";

            html += "<h3 style='font-weight:bold;'>5. EMPLOYEE HEADCOUNT SUMMARY</h3>";
            html += gvEmpcount.outerHTML + "<br/><br/>";


            // Apply styling replacements
            html = html.replace(/<table/g, '<table style="border-collapse:collapse; width:100%;"');
            html = html.replace(/<th/g, '<th style="padding:10px; border:1px solid #ccc; background-color:#f2f2f2;"');
            html = html.replace(/<td/g, '<td style="padding:10px; border:1px solid #ccc;"');

            // Create Excel file
            var url = 'data:application/vnd.ms-excel,' + encodeURIComponent(html);
            var link = document.createElement('a');
            link.href = url;
            link.download = 'Comparisonreport.xls';
            link.click();
        }

    </script>
    <title>SALARY COMPARISON REPORT</title>

         <style type="text/css">
         
         .section-title-box {
    background-color: #eaf2ff;
    border-left: 5px solid #1e3c72;
    padding: 15px 20px;
    margin: 20px auto;
    width: 80%;
    border-radius: 8px;
    box-shadow: 0 2px 6px rgba(0,0,0,0.1);
    text-align: center;
}

.section-title-box h2 {
    font-size: 1.4em; 
    color: #1e3c72;
    margin: 0;
}



       .report-header {
    background-color: #eaf2ff;
    padding: 20px;
    border-radius: 8px;
    box-shadow: 0 2px 6px rgba(0,0,0,0.1);
    margin-bottom: 30px;
    border-left: 5px solid #1e3c72;
    width: 80%;
    margin: 0 auto 30px auto;
}


            .report-header h2 {
                margin: 0;
                font-size: 1.8em;
                color: #2c3e50;
                text-align:center
            }

            .report-header .subheader {
                display: flex;
                flex-wrap: wrap;
                gap: 15px;
                margin-top: 10px;
                font-size: 0.9em;
                color: #7f8c8d;
                text-align:center;
                justify-content: center;
            }

                .report-header .subheader span {
                    display: block;
                }

            .report-header h3 {
                margin: 15px 0 0;
                font-size: 1.3em;
                color: #34495e;
            }


         .button-container
         {
    text-align: center;
    margin: 20px 0;
}

.big-button {
    font-size: 13px;
    padding: 6px 18px;
    margin: 6px;
    border: none;
    background-color: #1e3c72;
    color: white;
    border-radius: 4px;
    cursor: pointer;
    transition: background-color 0.3s ease;
    min-width: 100px;
}

.big-button:hover {
    background-color: #1450a3;
}

    body {
        font-family: 'Segoe UI', sans-serif;
        background-color: #f9f9f9;
        margin: 40px;
    }

    h2 {
        color: #1e3c72;
        margin-bottom: 20px;
    }

    /*.grid {
        margin-top: 20px;
        border-collapse: collapse;
        width: 100%;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }*/
    .grid {
    table-layout: fixed;   
    width: 100%;           
    font-size: 12px;  
    margin: 20px auto;
     }

    .grid th {
        background-color: #1e3c72;
        color: #ffffff;
        padding: 12px;
        text-align: left;
        font-weight: bold;
        border-bottom: 2px solid #ccc;
    }

    .grid td {
        padding: 10px;
        background-color: #ffffff;
        border-bottom: 1px solid #eee;
    }

    .grid tr:hover td {
        background-color: #f1f9ff;
    }

    .grid th:first-child,
    .grid td:first-child {
        border-left: 3px solid #007acc;
    }

    .grid td {
        transition: background-color 0.3s ease;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Page Header -->
        <div class="report-header" style="width: 100%;">
            <h2><%: Session("firm_name") %></h2>
            <div class="subheader">
                <span>Branch: <%: Session("branch_name") %></span>
                <span>Date: <%: Now.ToString("dd/MMM/yyyy") %></span>
                <span>Time: <%: Now.ToString("hh:mm:ss") %></span>
            </div>
            <div>
                <div class="section-title-box">
                    <h2 style="text-align: center; font-size: 1.4em;">SALARY COMPARISON REPORT </h2>
                </div>
                <div class="button-container">
                    <input type="button" class="big-button" value="Print" id="submit" onclick="return demo()" />
                    <input type="button" class="big-button" value="Exit" id="Button1" onclick="return Button1_onclick()" />
                    <input type="button" class="big-button" value="Export to Excel" onclick="exportToExcel()" />
                </div>
                <hr />
                <h3></h3>
            </div>

            <h3>1. Earnings Comparison</h3>
<asp:GridView ID="gvEarnings" runat="server" AutoGenerateColumns="False" CssClass="grid" OnRowDataBound="gvEarnings_RowDataBound">
    <Columns>
        <asp:BoundField DataField="element" HeaderText="ELEMENTS" />
        <asp:BoundField DataField="month1_total" HeaderText="AUGUST'2025" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="month2_total" HeaderText="SEPTEMBER'2025" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="difference" HeaderText="DIFF" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="diff_percent" HeaderText="DIFF IN %" DataFormatString="{0:N2}%" />
    </Columns>
</asp:GridView>

<h3>2. Deductions Comparison</h3>
<asp:GridView ID="gvContrib" runat="server" AutoGenerateColumns="False" CssClass="grid">
    <Columns>
        <asp:BoundField DataField="element" HeaderText="EMPLOYER CONTRIBUTION" />
        <asp:BoundField DataField="month1_total" HeaderText="AUGUST'2025" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="month2_total" HeaderText="SEPTEMBER'2025" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="difference" HeaderText="DIFF" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="diff_percent" HeaderText="DIFF IN %" DataFormatString="{0:N2}%" />
    </Columns>
</asp:GridView>

<h3>3. GROSS SALARY COMPONENT BREAKDOWN</h3>
<asp:GridView ID="gvGrossal" runat="server" AutoGenerateColumns="False" CssClass="grid">
    <Columns>
        <asp:BoundField DataField="element" HeaderText="EMPLOYER CONTRIBUTION" />
        <asp:BoundField DataField="month1_total" HeaderText="AUGUST'2025" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="month2_total" HeaderText="SEPTEMBER'2025" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="difference" HeaderText="DIFF" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="diff_percent" HeaderText="DIFF IN %" DataFormatString="{0:N2}%" />
    </Columns>
</asp:GridView>

<h3>4. ALLOWANCE AND INCENTIVE BREAKDOWN</h3>
<asp:GridView ID="gvAllin" runat="server" AutoGenerateColumns="False" CssClass="grid">
    <Columns>
        <asp:BoundField DataField="element" HeaderText="EMPLOYER CONTRIBUTION" />
        <asp:BoundField DataField="month1_total" HeaderText="AUGUST'2025" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="month2_total" HeaderText="SEPTEMBER'2025" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="difference" HeaderText="DIFF" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="diff_percent" HeaderText="DIFF IN %" DataFormatString="{0:N2}%" />
    </Columns>
</asp:GridView>

            <h3>5. EMPLOYEE HEADCOUNT SUMMARY</h3>
<asp:GridView ID="gvEmpcount" runat="server" AutoGenerateColumns="False" CssClass="grid">
    <Columns>
        <asp:BoundField DataField="element" HeaderText="EMPLOYER CONTRIBUTION" />
        <asp:BoundField DataField="month1_total" HeaderText="AUGUST'2025" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="month2_total" HeaderText="SEPTEMBER'2025" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="difference" HeaderText="DIFF" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="diff_percent" HeaderText="DIFF IN %" DataFormatString="{0:N2}%" />
    </Columns>
</asp:GridView>

      <asp:Button ID="BtnLoadReport" runat="server" Text="Load Report" CssClass="big-button" OnClick="btnLoadReport_Click" />
        </div>
    </form>
</body>
</html>


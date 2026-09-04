<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="punching_module_report.aspx.vb" Inherits="WebAppHRMS.punching_module_report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Attendance Report</title>
    <style type="text/css">
        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f9f9f9;
            margin: 40px;
        }

        h2 {
            color: #1e3c72;
            margin-bottom: 20px;
        }

        .grid {
            margin-top: 20px;
            border-collapse: collapse;
            width: 100%;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
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
        <div>
            <h2>MODULE WISE ATTENDANCE REPORT</h2>
            
            <asp:GridView ID="gvNorms" runat="server" AutoGenerateColumns="false" CssClass="grid" GridLines="None" Width="90%">
               <%-- <Columns>
                    <asp:BoundField DataField="emp_code" HeaderText="EMPLOYEE CODE" />
                    <asp:BoundField DataField="emp_name" HeaderText="EMPLOYEE NAME" />
                    <asp:BoundField DataField="curr_date" HeaderText="ATTENDANCE DATE" />
                    <asp:BoundField DataField="m_time" HeaderText="PUNCH-IN TIME" />
                    <asp:BoundField DataField="" HeaderText="PUNCH-IN MODULE" />
                    <asp:BoundField DataField="e_time" HeaderText="PUNCH-OUT TIME" />
                    <asp:BoundField DataField="" HeaderText="PUNCH-OUT MODULE" />

                </Columns>--%>

                   <Columns>
        <asp:BoundField DataField="emp_code" HeaderText="EMPLOYEE CODE" />
        <asp:BoundField DataField="emp_name" HeaderText="EMPLOYEE NAME" />
        <asp:BoundField DataField="curr_date" HeaderText="ATTENDANCE DATE" />
        <asp:BoundField DataField="m_time" HeaderText="PUNCH-IN TIME" />
        <asp:BoundField DataField="IN_MODULE" HeaderText="PUNCH-IN MODULE" />
        <asp:BoundField DataField="e_time" HeaderText="PUNCH-OUT TIME" />
        <asp:BoundField DataField="OUT_MODULE" HeaderText="PUNCH-OUT MODULE" />
                 </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
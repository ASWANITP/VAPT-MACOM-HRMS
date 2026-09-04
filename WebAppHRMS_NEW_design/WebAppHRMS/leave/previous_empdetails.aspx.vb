Public Class previous_empdetails
    Inherits System.Web.UI.Page
    Dim dt1, dt2 As New DataTable
    Dim sql, sql1 As String
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Session("user_id") = "" Then
            Dim cl_script1 As New StringBuilder
            cl_script1.Append(" alert('Please Login Again and Retry....!! ');")
            cl_script1.Append("    window.open('../home.aspx','_self');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "inv", cl_script1.ToString, True)
            Exit Sub
        End If

        Dim fr As Integer = Me.Session("firm_id")
        Dim User() As String
        User = Session("user_id").ToString.Split("!")
        Dim empcode As String = Request.QueryString("code")
        sql1 = "select t.emp_name from mactech.employee_master t where t.emp_code=" & empcode & " "
        dt2 = oh.ExecuteDataSet(sql1).Tables(0)
        lblTitle.Text = "<div  color:#000000; font-size:10px; font-weight:bold; font-family:Verdana; solid #99ccff;'>
🧾 Leave Balance & Availed Report
</div>"


        Dim summaryTable As New Table
        summaryTable.Width = Unit.Percentage(100)
        summaryTable.BorderWidth = 0
        summaryTable.CellPadding = 4
        summaryTable.CellSpacing = 0
        'summaryTable.GridLines = GridLines.Both
        summaryTable.Font.Name = "Verdana"
        summaryTable.Font.Size = FontUnit.Point(9)


        Dim titleRow As New TableRow()
        Dim titleCell As New TableCell()
        titleCell.ColumnSpan = 4
        titleCell.Text = "<b><font size='2'>Leave Summary for: " & dt2.Rows(0)(0) & "</font></b>"
        titleCell.BackColor = Drawing.ColorTranslator.FromHtml("#cce5ff")
        titleCell.HorizontalAlign = HorizontalAlign.Center
        titleRow.Cells.Add(titleCell)
        summaryTable.Rows.AddAt(0, titleRow)

        ' Header Row
        Dim headerRow As New TableRow()
        headerRow.BackColor = Drawing.ColorTranslator.FromHtml("#99ccff")
        Dim headers() As String = {"Leave Type", "Total Entitlement", "Availed", "Balance"}
        For Each headerText As String In headers
            Dim cell As New TableCell()
            cell.Text = "<b><font size=2>" & headerText & "</font></b>"
            cell.HorizontalAlign = HorizontalAlign.Center
            cell.Font.Bold = True
            headerRow.Cells.Add(cell)
        Next
        summaryTable.Rows.Add(headerRow)
        sql = "SELECT DECODE(em.leave_id, 1, 'Casual Leave (C/L)', 2, 'Sick Leave (S/L)', 3, 'Earned Leave (E/L)', TO_CHAR(em.leave_id)) AS leave_type, TO_CHAR(em.eligible_leave) AS eligible_leave, TO_CHAR(em.eligible_leave - em.leave_days) AS used_leave, TO_CHAR(em.leave_days) AS leave_days FROM mactech.employ_leave_master em WHERE em.emp_code = " & empcode & "UNION ALL SELECT 'Loss of Pay (LOP)' AS leave_type, '---' AS eligible_leave, TO_CHAR(COUNT(*)) AS used_leave, '---' AS leave_days FROM MACTECH.employ_leave_dtl t WHERE t.emp_code = " & empcode & " AND t.status = 1 AND t.leave_id = 4 AND t.leave_process_id IN (1, 2) AND t.leave_apply_date BETWEEN TO_DATE(CASE WHEN EXTRACT(MONTH FROM SYSDATE) < 4 THEN EXTRACT(YEAR FROM SYSDATE) - 1 || '-04-01' ELSE EXTRACT(YEAR FROM SYSDATE) || '-04-01' END, 'YYYY-MM-DD') AND TO_DATE(CASE WHEN EXTRACT(MONTH FROM SYSDATE) < 4 THEN EXTRACT(YEAR FROM SYSDATE) || '-03-31' ELSE EXTRACT(YEAR FROM SYSDATE) + 1 || '-03-31' END, 'YYYY-MM-DD')"
        dt1 = oh.ExecuteDataSet(sql).Tables(0)


        For i As Integer = 0 To dt1.Rows.Count - 1
            Dim row As New TableRow()
            row.BackColor = If(i Mod 2 = 0, Drawing.ColorTranslator.FromHtml("#e6f2ff"), Drawing.Color.White)

            For j As Integer = 0 To dt1.Columns.Count - 1
                Dim cell As New TableCell()
                cell.Text = "<font size=2>" & dt1.Rows(i)(j).ToString() & "</font>"
                cell.HorizontalAlign = HorizontalAlign.Center
                row.Cells.Add(cell)
            Next
            summaryTable.Rows.Add(row)
        Next

        Dim centerPanel As New Panel()
        centerPanel.HorizontalAlign = HorizontalAlign.Center
        centerPanel.Controls.Add(summaryTable)
        PanelHoNSS.Controls.Add(summaryTable)
        PanelHoNSS.Controls.Add(New LiteralControl("<br/><br/>"))
        '-------------------------------------------------------------------------------------------
        Dim historyTable As New Table
        historyTable.Width = Unit.Percentage(100)
        historyTable.BorderWidth = 0
        historyTable.CellPadding = 6
        historyTable.CellSpacing = 0
        'historyTable.GridLines = GridLines.Both
        historyTable.Font.Name = "Verdana"
        historyTable.Font.Size = FontUnit.Point(9)

        Dim titleRow1 As New TableRow()
        Dim titleCell1 As New TableCell()
        titleCell1.ColumnSpan = 6

        Dim fdate As String = New DateTime(DateTime.Now.Year, 4, 1).ToString("dd-MMM-yyyy")
        Dim tdate As String = DateTime.Now.ToString("dd-MMM-yyyy")
        titleCell1.Text = "<b><font size='2'>Leave History (" & fdate & " to " & tdate & ")</font></b>"

        titleCell1.BackColor = Drawing.ColorTranslator.FromHtml("#cce5ff")
        titleCell1.HorizontalAlign = HorizontalAlign.Center
        titleRow1.Cells.Add(titleCell1)
        historyTable.Rows.AddAt(0, titleRow1)

        ' Header Row
        Dim headerRow1 As New TableRow()
        headerRow1.BackColor = Drawing.ColorTranslator.FromHtml("#99ccff")
        Dim headers1() As String = {"SlNo", "From Date", "To Date", "Leave Days", "Leave Type", "Reason"}
        For Each headerText As String In headers1
            Dim cell As New TableCell()
            cell.Text = "<b><font size=2>" & headerText & "</font></b>"
            cell.HorizontalAlign = HorizontalAlign.Center
            cell.Font.Bold = True
            headerRow1.Cells.Add(cell)
        Next
        historyTable.Rows.Add(headerRow1)

        'sql = "SELECT ROW_NUMBER() OVER (ORDER BY leave_frdate) AS sl_no, TO_CHAR(leave_frdate, 'DD-MON-YYYY') AS leave_frdate, TO_CHAR(leave_todate, 'DD-MON-YYYY') AS leave_todate, leave_days, DECODE(leave_id, 1, 'C/L', 2, 'S/L', 3, 'E/L', 4, 'L.O.P') AS leave_type, reason_name FROM ( SELECT t.leave_frdate, t.leave_todate, t.leave_days, t.leave_id, d.reason_name FROM mactech.hrm_leave_apply_sanction t, mactech.hrm_category_master ca, mactech.hrm_category_dtl d WHERE t.emp_code = " & empcode & " AND t.category_id = d.category_id AND d.category_id = ca.category_id AND t.reason_id = d.reason_id AND t.status_id = 1 AND t.leave_frdate BETWEEN ADD_MONTHS(TRUNC(SYSDATE, 'YYYY'), 3) AND SYSDATE UNION ALL SELECT t.leave_frdate, t.leave_todate, t.leave_days, t.leave_id, 'NON-MARKING' AS reason_name FROM mactech.employ_leave_dtl t WHERE t.emp_code = " & empcode & " AND t.leave_id = 4 AND t.leave_process_id = 2 AND t.leave_frdate BETWEEN ADD_MONTHS(TRUNC(SYSDATE, 'YYYY'), 3) AND SYSDATE ) combined"
        sql = "select ROW_NUMBER() OVER(ORDER BY leave_frdate) AS sl_no, to_char(a.leave_frdate),to_char( a.leave_todate), case when a.leave_form in (11, 12) then to_number(0.5) else a.leave_days end leave_days, b.leave_abbr, decode(a.leave_reason, Null, '----', a.leave_reason) from mactech.employ_leave_dtl a, mactech.leave_master b where a.leave_id = b.leave_id and a.leave_process_id not in (0, 3) and a.status = 1 and a.emp_code in " & empcode & " and to_date(leave_frdate) >= ADD_MONTHS(TRUNC(SYSDATE, 'YYYY'), 3) and to_date(leave_todate) <= SYSDATE order by to_date(leave_frdate)"
        dt1 = oh.ExecuteDataSet(sql).Tables(0)


        For i As Integer = 0 To dt1.Rows.Count - 1
            Dim row As New TableRow()
            row.BackColor = If(i Mod 2 = 0, Drawing.ColorTranslator.FromHtml("#e6f2ff"), Drawing.Color.White)

            For j As Integer = 0 To dt1.Columns.Count - 1
                Dim cell As New TableCell()
                cell.Text = "<font size=2>" & dt1.Rows(i)(j).ToString() & "</font>"
                cell.HorizontalAlign = HorizontalAlign.Center
                row.Cells.Add(cell)
            Next
            historyTable.Rows.Add(row)
        Next

        Dim centerPanel1 As New Panel()
        centerPanel1.HorizontalAlign = HorizontalAlign.Center
        centerPanel1.Controls.Add(historyTable)
        PanelHoNSS.Controls.Add(historyTable)
    End Sub

End Class
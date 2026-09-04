Imports System.Data
Imports System.Data.OracleClient
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Web.UI.WebControls


Public Class Display_punchblock_report
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GenerateReport()
        End If
    End Sub

    Private Sub GenerateReport()
        Dim empId As Integer = Request.QueryString.Get("Ecode")
        Dim fdate As String = Request.QueryString.Get("fdt")
        Dim tdate As String = Request.QueryString.Get("tdt")


        'Dim sql As String = "SELECT da.emp_code, em.emp_name, da.curr_date, NVL(mr.max_morning_attempt_time, '-----') AS mrng_attempt_time, mr.morning_photo, NVL(ev.max_evening_attempt_time, '-----') AS eve_attempt_time, ev.evening_photo, 'PUNCHING-BLOCK' as Remark FROM mactech.daily_attend da JOIN employee_master em ON da.emp_code = em.emp_code LEFT JOIN (SELECT emp_code, TRUNC(TO_DATE(processing_time, 'DD-MM-YYYY:HH24:MI:SS')) AS punch_date, (morning_attempt_time) AS max_morning_attempt_time, M_PHOTO as morning_photo FROM tbl_punch_block_dtl blk WHERE emp_code = " & empId & " and blk.morning_attempt_time in (select max(bb.morning_attempt_time) from tbl_punch_block_dtl bb where bb.emp_code = blk.emp_code and TRUNC(TO_DATE(blk.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(bb.processing_time, 'DD-MM-YYYY:HH24:MI:SS')))) mr ON da.emp_code = mr.emp_code AND TRUNC(da.curr_date) = mr.punch_date LEFT JOIN (SELECT emp_code, TRUNC(TO_DATE(processing_time, 'DD-MM-YYYY:HH24:MI:SS')) AS punch_date, (evening_attempt_time) AS max_evening_attempt_time, E_PHOTO as evening_photo FROM tbl_punch_block_dtl blk WHERE emp_code = " & empId & " and blk.evening_attempt_time in (select max(bb.evening_attempt_time) from tbl_punch_block_dtl bb where bb.emp_code = blk.emp_code and TRUNC(TO_DATE(blk.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(bb.processing_time, 'DD-MM-YYYY:HH24:MI:SS')))) ev ON da.emp_code = ev.emp_code AND TRUNC(da.curr_date) = ev.punch_date WHERE da.emp_code = " & empId & " AND TO_DATE(da.curr_date) BETWEEN TO_DATE('" & fdate & "') AND TO_DATE('" & tdate & "') AND EXISTS (SELECT 1 FROM employee_block_dtl dt WHERE dt.emp_code = " & empId & " AND TO_DATE(dt.block_date) = TRUNC(da.curr_date) AND TO_DATE(dt.block_date) BETWEEN TO_DATE('" & fdate & "') AND TO_DATE('" & tdate & "')) union all SELECT da.emp_code, em.emp_name, da.curr_date, NVL(mr.max_morning_attempt_time, '-----') AS mrng_attempt_time, mr.morning_photo, NVL(ev.max_evening_attempt_time, '-----') AS eve_attempt_time, ev.evening_photo, 'PUNCHING-BLOCK' as Remark FROM mactech.attend da JOIN employee_master em ON da.emp_code = em.emp_code LEFT JOIN (SELECT emp_code, TRUNC(TO_DATE(processing_time, 'DD-MM-YYYY:HH24:MI:SS')) AS punch_date, (morning_attempt_time) AS max_morning_attempt_time, M_PHOTO as morning_photo FROM tbl_punch_block_dtl blk WHERE emp_code = " & empId & " and blk.morning_attempt_time in (select max(bb.morning_attempt_time) from tbl_punch_block_dtl bb where bb.emp_code = blk.emp_code and TRUNC(TO_DATE(blk.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(bb.processing_time, 'DD-MM-YYYY:HH24:MI:SS')))) mr ON da.emp_code = mr.emp_code AND TRUNC(da.curr_date) = mr.punch_date LEFT JOIN (SELECT emp_code, TRUNC(TO_DATE(processing_time, 'DD-MM-YYYY:HH24:MI:SS')) AS punch_date, (evening_attempt_time) AS max_evening_attempt_time, E_PHOTO as evening_photo FROM tbl_punch_block_dtl blk WHERE emp_code = " & empId & " and blk.evening_attempt_time in (select max(bb.evening_attempt_time) from tbl_punch_block_dtl bb where bb.emp_code = blk.emp_code and TRUNC(TO_DATE(blk.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(bb.processing_time, 'DD-MM-YYYY:HH24:MI:SS')))) ev ON da.emp_code = ev.emp_code AND TRUNC(da.curr_date) = ev.punch_date WHERE da.emp_code = " & empId & " AND TO_DATE(da.curr_date) BETWEEN TO_DATE('" & fdate & "') AND TO_DATE('" & tdate & "') AND EXISTS (SELECT 1 FROM employee_block_dtl_his h WHERE h.emp_code = " & empId & " AND TO_DATE(h.block_date) = TRUNC(da.curr_date) AND TO_DATE(h.block_date) BETWEEN TO_DATE('" & fdate & "') AND TO_DATE('" & tdate & "')) union all SELECT da.emp_code, em.emp_name, da.curr_date, NVL(mr.max_morning_attempt_time, '-----') AS mrng_attempt_time, mr.morning_photo, NVL(ev.max_evening_attempt_time, '-----') AS eve_attempt_time, ev.evening_photo, 'PUNCHING-BLOCK' as Remark FROM mactech.daily_attend da JOIN employee_master em ON da.emp_code = em.emp_code LEFT JOIN (SELECT emp_code, TRUNC(TO_DATE(processing_time, 'DD-MM-YYYY:HH24:MI:SS')) AS punch_date, (morning_attempt_time) AS max_morning_attempt_time, M_PHOTO as morning_photo FROM tbl_punch_block_dtl blk WHERE emp_code = " & empId & " and blk.morning_attempt_time in (select max(bb.morning_attempt_time) from tbl_punch_block_dtl bb where bb.emp_code = blk.emp_code and blk.shift_id in (7,12,67,16,17,29,64,63) and TRUNC(TO_DATE(blk.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(bb.processing_time, 'DD-MM-YYYY:HH24:MI:SS')))) mr ON da.emp_code = mr.emp_code AND TRUNC(da.curr_date + 1) =mr.punch_date LEFT JOIN (SELECT emp_code, TRUNC(TO_DATE(processing_time, 'DD-MM-YYYY:HH24:MI:SS')) AS punch_date, (evening_attempt_time) AS max_evening_attempt_time, E_PHOTO as evening_photo FROM tbl_punch_block_dtl blk WHERE emp_code = " & empId & " and blk.evening_attempt_time in (select max(bb.evening_attempt_time) from tbl_punch_block_dtl bb where bb.emp_code = blk.emp_code and blk.shift_id in (7,12,67,16,17,29,64,63) and TRUNC(TO_DATE(blk.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(bb.processing_time, 'DD-MM-YYYY:HH24:MI:SS')))) ev ON da.emp_code = ev.emp_code AND TRUNC(da.curr_date + 1) =ev.punch_date WHERE da.emp_code = " & empId & " AND TO_DATE(da.curr_date) BETWEEN TO_DATE('" & fdate & "') AND TO_DATE('" & tdate & "') AND EXISTS (SELECT 1 FROM employee_block_dtl dt WHERE dt.emp_code = " & empId & " and da.shift_id in (7,12,67,16,17,29,64,63) AND TO_DATE(dt.block_date) = TRUNC(da.curr_date+1) AND TO_DATE(dt.block_date) BETWEEN TO_DATE('" & fdate & "') AND TO_DATE('" & tdate & "'))"
        'Dim sql As String = "select t.emp_code, em.emp_name, tt.shift, TRUNC(TO_DATE(t.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) as CURR_DATE, nvl((select max(blk.morning_attempt_time) from tbl_punch_block_dtl blk where blk.emp_code = " & empId & " and t.emp_code = blk.emp_code and TRUNC(TO_DATE(blk.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(t.processing_time, 'DD-MM-YYYY:HH24:MI:SS'))),'-----') as morning_attempt_punch, (select tm.m_photo from tbl_punch_block_dtl tm where tm.emp_code =t.emp_code and tm.morning_attempt_time = ((select max(blk.morning_attempt_time) from tbl_punch_block_dtl blk where blk.emp_code = " & empId & " and t.emp_code = blk.emp_code and TRUNC(TO_DATE(blk.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(t.processing_time, 'DD-MM-YYYY:HH24:MI:SS'))))) as Morning_Photo, nvl((select max(blk.evening_attempt_time) from tbl_punch_block_dtl blk where blk.emp_code = " & empId & " and t.emp_code = blk.emp_code and TRUNC(TO_DATE(blk.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(t.processing_time, 'DD-MM-YYYY:HH24:MI:SS'))),'-----') as evening_attempt_punch, (select tm.e_photo from tbl_punch_block_dtl tm where tm.emp_code =t.emp_code and tm.evening_attempt_time = ((select max(blk.evening_attempt_time) from tbl_punch_block_dtl blk where blk.emp_code = " & empId & " and t.emp_code = blk.emp_code and TRUNC(TO_DATE(blk.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(t.processing_time, 'DD-MM-YYYY:HH24:MI:SS'))))) as Evening_Photo, t.block_reason from tbl_punch_block_dtl t, employee_master em, time_tab tt where t.emp_code = em.emp_code and t.shift_id = tt.shift_id and t.emp_code = " & empId & " and t.processing_time = (select max(tp.processing_time) from tbl_punch_block_dtl tp where TRUNC(TO_DATE(tp.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(t.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) and tp.emp_code = t.emp_code) and TRUNC(TO_DATE(t.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) BETWEEN TO_DATE('" & fdate & "') AND TO_DATE('" & tdate & "') union all select t.emp_code, em.emp_name, ttt.shift, trunc(t.block_date) as curr_Date, '-----' as morning_attempt_punch,NUll as Morning_Photo, '-----' as evening_attempt_punch, NUll as Evening_Photo, b.block_reason from employee_block_dtl_his t left join employee_master em on t.emp_code = em.emp_code left join time_tab ttt on ttt.shift_id = em.shift_id left join block_master_1 b on b.block_id = t.block_id where (t.emp_code, trunc(t.block_date)) not in (select bl.emp_code, TRUNC(TO_DATE(bl.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) from tbl_punch_block_dtl bl where TRUNC(TO_DATE(bl.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = trunc(t.block_date) and bl.emp_code = t.emp_code) and t.emp_code = " & empId & " and TRUNC(TO_DATE(t.block_date, 'DD-MM-YYYY:HH24:MI:SS')) BETWEEN TO_DATE('" & fdate & "') AND TO_DATE('" & tdate & "') union all select t.emp_code, em.emp_name, ttt.shift, trunc(t.block_date) as curr_Date, '-----' as morning_attempt_punch, NUll as Morning_Photo, '-----' as evening_attempt_punch, NUll as Evening_Photo, b.block_reason from employee_block_dtl t left join employee_master em on t.emp_code = em.emp_code left join time_tab ttt on ttt.shift_id = em.shift_id left join block_master_1 b on b.block_id = t.block_id where (t.emp_code, trunc(t.block_date)) not in (select bl.emp_code, TRUNC(TO_DATE(bl.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) from tbl_punch_block_dtl bl where TRUNC(TO_DATE(bl.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = trunc(t.block_date) and bl.emp_code = t.emp_code) and t.emp_code = " & empId & " and TRUNC(TO_DATE(t.block_date, 'DD-MM-YYYY:HH24:MI:SS')) BETWEEN TO_DATE('" & fdate & "') AND TO_DATE('" & tdate & "')"
        Dim sql As String = "select * from(select t.emp_code, em.emp_name, tt.in_time as InTime, tt.out_time as OutTime, TRUNC(TO_DATE(t.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) as CURR_DATE, nvl((select max(blk.morning_attempt_time) from tbl_punch_block_dtl blk where blk.emp_code = " & empId & " and t.emp_code = blk.emp_code and TRUNC(TO_DATE(blk.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(t.processing_time, 'DD-MM-YYYY:HH24:MI:SS'))), '-----') as morning_attempt_punch, (select tm.m_photo from tbl_punch_block_dtl tm where tm.emp_code = t.emp_code and tm.morning_attempt_time = ((select max(blk.morning_attempt_time) from tbl_punch_block_dtl blk where blk.emp_code = " & empId & " and t.emp_code = blk.emp_code and TRUNC(TO_DATE(blk.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(t.processing_time, 'DD-MM-YYYY:HH24:MI:SS'))))) as Morning_Photo, nvl((select max(blk.evening_attempt_time) from tbl_punch_block_dtl blk where blk.emp_code = " & empId & " and t.emp_code = blk.emp_code and TRUNC(TO_DATE(blk.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(t.processing_time, 'DD-MM-YYYY:HH24:MI:SS'))), '-----') as evening_attempt_punch, (select tm.e_photo from tbl_punch_block_dtl tm where tm.emp_code = t.emp_code and tm.evening_attempt_time = ((select max(blk.evening_attempt_time) from tbl_punch_block_dtl blk where blk.emp_code = " & empId & " and t.emp_code = blk.emp_code and TRUNC(TO_DATE(blk.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(t.processing_time, 'DD-MM-YYYY:HH24:MI:SS'))))) as Evening_Photo, t.block_reason from tbl_punch_block_dtl t, employee_master em, time_tab tt where t.emp_code = em.emp_code and t.shift_id = tt.shift_id and t.emp_code = " & empId & " and t.processing_time = (select max(tp.processing_time) from tbl_punch_block_dtl tp where TRUNC(TO_DATE(tp.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = TRUNC(TO_DATE(t.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) and tp.emp_code = t.emp_code) and TRUNC(TO_DATE(t.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) BETWEEN TO_DATE('" & fdate & "') AND TO_DATE('" & tdate & "') union all select t.emp_code, em.emp_name, ttt.in_time as InTime, ttt.out_time as OutTime, trunc(t.block_date) as curr_Date, '-----' as morning_attempt_punch, NUll as Morning_Photo, '-----' as evening_attempt_punch, NUll as Evening_Photo, b.block_reason from employee_block_dtl_his t left join employee_master em on t.emp_code = em.emp_code left join time_tab ttt on ttt.shift_id = em.shift_id left join block_master_1 b on b.block_id = t.block_id where (t.emp_code, trunc(t.block_date)) not in (select bl.emp_code, TRUNC(TO_DATE(bl.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) from tbl_punch_block_dtl bl where TRUNC(TO_DATE(bl.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = trunc(t.block_date) and bl.emp_code = t.emp_code) and (t.emp_code, trunc(t.block_date)) not in (select a.emp_code, a.curr_date from attend a where a.m_time is null and a.e_time is null and a.emp_code=t.emp_code and a.curr_date=t.block_date) and t.emp_code = " & empId & " and TRUNC(TO_DATE(t.block_date, 'DD-MM-YYYY:HH24:MI:SS')) BETWEEN TO_DATE('" & fdate & "') AND TO_DATE('" & tdate & "') union all select t.emp_code, em.emp_name, ttt.in_time as InTime, ttt.out_time as OutTime, trunc(t.block_date) as curr_Date, '-----' as morning_attempt_punch, NUll as Morning_Photo, '-----' as evening_attempt_punch, NUll as Evening_Photo, b.block_reason from employee_block_dtl t left join employee_master em on t.emp_code = em.emp_code left join time_tab ttt on ttt.shift_id = em.shift_id left join block_master_1 b on b.block_id = t.block_id where (t.emp_code, trunc(t.block_date)) not in (select bl.emp_code, TRUNC(TO_DATE(bl.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) from tbl_punch_block_dtl bl where TRUNC(TO_DATE(bl.processing_time, 'DD-MM-YYYY:HH24:MI:SS')) = trunc(t.block_date) and bl.emp_code = t.emp_code) and t.emp_code = " & empId & " and TRUNC(TO_DATE(t.block_date, 'DD-MM-YYYY:HH24:MI:SS')) BETWEEN TO_DATE('" & fdate & "') AND TO_DATE('" & tdate & "')) order by curr_date"
        Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)
        If dt.Rows.Count = 0 Then
            Dim cl_script1 As New System.Text.StringBuilder
            cl_script1.Append("         alert('No data available for the specified date range');")
            Page.ClientScript.RegisterClientScriptBlock(Me.GetType, "client script", cl_script1.ToString, True)
            Exit Sub
        End If

        Dim tb As New Table With {.CssClass = "report-table", .Width = Unit.Percentage(100)}

        ' Header row
        Dim headerRow As New TableRow()
        Dim headers As String() = {"Emp Code", "Name", "In  Time", "Out Time", "Date", "Morning Attempt Time", "Morning Photo", "Evening Attempt Time", "Evening Photo", "Block Reason"}
        For Each header As String In headers
            Dim th As New TableHeaderCell()
            th.Text = header
            th.Font.Bold = True
            th.BackColor = System.Drawing.ColorTranslator.FromHtml("#17508A")
            th.ForeColor = System.Drawing.Color.White

            headerRow.Cells.Add(th)
        Next
        tb.Rows.Add(headerRow)

        ' Data rows
        For Each row As DataRow In dt.Rows
            Dim tr As New TableRow()

            tr.Cells.Add(New TableCell With {.Text = row("emp_code").ToString()})
            tr.Cells.Add(New TableCell With {.Text = row("emp_name").ToString()})
            tr.Cells.Add(New TableCell With {.Text = row("InTime").ToString()})
            tr.Cells.Add(New TableCell With {.Text = row("OutTime").ToString()})
            tr.Cells.Add(New TableCell With {.Text = Format(CDate(row("curr_date")), "dd-MMM-yyyy")})
            tr.Cells.Add(New TableCell With {.Text = row("morning_attempt_punch").ToString()})

            ' Morning Photo
            Dim tdMorningPhoto As New TableCell()
            If Not IsDBNull(row("morning_photo")) Then
                Dim img As New Image()
                img.ImageUrl = "data:image/jpeg;base64," & Convert.ToBase64String(CType(row("morning_photo"), Byte()))
                img.Width = 70
                img.Height = 70
                tdMorningPhoto.Controls.Add(img)
            End If
            tr.Cells.Add(tdMorningPhoto)

            tr.Cells.Add(New TableCell With {.Text = row("evening_attempt_punch").ToString()})

            ' Evening Photo
            Dim tdEveningPhoto As New TableCell()
            If Not IsDBNull(row("evening_photo")) Then
                Dim img As New Image()
                img.ImageUrl = "data:image/jpeg;base64," & Convert.ToBase64String(CType(row("evening_photo"), Byte()))
                img.Width = 70
                img.Height = 70
                tdEveningPhoto.Controls.Add(img)
            End If
            tr.Cells.Add(tdEveningPhoto)
            tr.Cells.Add(New TableCell With {.Text = row("block_reason").ToString()})

            tb.Rows.Add(tr)
        Next

        Panel_report.Controls.Add(tb)
    End Sub
End Class

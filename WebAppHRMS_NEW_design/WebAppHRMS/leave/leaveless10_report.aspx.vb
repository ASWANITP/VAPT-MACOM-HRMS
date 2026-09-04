Imports System.Data
Imports System.Data.OracleClient
Partial Class leave_leavegreater10_report_899101409419
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql, sql1 As String
    Dim dt, dt1 As New DataTable
    Dim count, lv_old, lv_new, tot_lv, emp, type As Integer
    Dim dr As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        emp = Request.QueryString.Get("emp")
        type = Request.QueryString.Get("type")

        Dim colors As String
        colors = "#fff7ff"
        Dim tab As New Table
        tab.Attributes.Add("width", "95%")
        tab.Attributes.Add("align", "left")
        Dim row1 As New TableRow
        Dim c11 As New TableCell
        c11.ColumnSpan = 4
        c11.Text = "<font size=4><b> " & Session("firm_name") & " </font></b>"
        c11.HorizontalAlign = HorizontalAlign.Center
        row1.Controls.Add(c11)
        tab.Controls.Add(row1)
        Dim row2 As New TableRow
        Dim c21 As New TableCell
        Dim c22 As New TableCell
        c21.ColumnSpan = 2
        c22.ColumnSpan = 2
        c21.Attributes.Add("width", "50%")
        c22.Attributes.Add("width", "50%")
        c21.Text = "<font size=2><b> Branch_name:" & Session("branch_name") & ", </font></b>"
        c21.HorizontalAlign = HorizontalAlign.Right
        c22.Text = "<font size=2><b> Branch_id:" & Session("branch_id") & " </font></b>"
        c22.HorizontalAlign = HorizontalAlign.Left
        row2.Controls.Add(c21)
        row2.Controls.Add(c22)
        tab.Controls.Add(row2)
        Dim row3 As New TableRow
        Dim c31 As New TableCell
        c31.ColumnSpan = 4
        c31.Text = "&nbsp;"
        row3.Controls.Add(c31)
        tab.Controls.Add(row3)
        Dim row4 As New TableRow
        row4.Attributes.Add("bgcolor", colors)
        Dim c41 As New TableCell
        Dim c42 As New TableCell
        Dim c43 As New TableCell
        c41.ColumnSpan = 1
        c42.ColumnSpan = 2
        c43.ColumnSpan = 1
        'c43.Attributes.Add("width", "")
        c41.Text = "<font size=2><b> Date :" & Format(Date.Now, "dd/MM/yyyy") & "</font></b>"
        c41.HorizontalAlign = HorizontalAlign.Left
        c42.Text = "<font size=2><b>LEAVE LEASS THAN 10</font></b>"
        c42.HorizontalAlign = HorizontalAlign.Center
        c43.Text = "<font size=2><b><div id=txt align=right></div></font></b>"
        c43.HorizontalAlign = HorizontalAlign.Right
        row4.Controls.Add(c41)
        row4.Controls.Add(c42)
        row4.Controls.Add(c43)
        tab.Controls.Add(row4)
        Dim row5 As New TableRow
        Dim c51 As New TableCell
        c51.ColumnSpan = 4
        c51.Text = "<hr align=center width=100%>"
        row5.Controls.Add(c51)
        tab.Controls.Add(row5)
        Dim row6 As New TableRow
        Dim c61, c62, c63, c64, c65, c66, c67, c68, c69 As New TableCell
        c61.ColumnSpan = 1
        c61.Text = "<b>Branch&nbspName"
        c61.HorizontalAlign = HorizontalAlign.Left
        c62.ColumnSpan = 1
        c62.Text = "<b>Emp.&nbspCode"
        c62.HorizontalAlign = HorizontalAlign.Left
        c63.ColumnSpan = 1
        c63.Text = "<b>Employee&nbspName"
        c63.HorizontalAlign = HorizontalAlign.Left
        c64.ColumnSpan = 1
        c64.Text = "<b>Leave&nbspDays"
        c64.HorizontalAlign = HorizontalAlign.Left
        'c64.ColumnSpan = 2
        'c64.Text = "<b>To&nbspDate"
        'c64.HorizontalAlign = HorizontalAlign.Left
        'c65.ColumnSpan = 2
        'c65.Text = "<b>Batta&nbspDays"
        'c65.HorizontalAlign = HorizontalAlign.Right
        'c67.ColumnSpan = 2
        'c67.Text = "<b>Batta&nbspAmount"
        'c67.HorizontalAlign = HorizontalAlign.Left
        'c68.ColumnSpan = 2
        'c68.Text = "<b>TA&nbspAmount"
        'c68.HorizontalAlign = HorizontalAlign.Left
        'c69.ColumnSpan = 2
        'c69.Text = "<b>Total"
        'c69.HorizontalAlign = HorizontalAlign.Right

        row6.Controls.Add(c61)
        row6.Controls.Add(c62)
        row6.Controls.Add(c63)
        row6.Controls.Add(c64)
        'row6.Controls.Add(c65)
        'row6.Controls.Add(c66)
        'row6.Controls.Add(c67)
        'row6.Controls.Add(c68)
        'row6.Controls.Add(c69)
        tab.Controls.Add(row6)
        Dim row8 As New TableRow
        Dim c81 As New TableCell
        c81.ColumnSpan = 4
        c81.Text = "<hr align=center width=100%>"
        row8.Controls.Add(c81)
        tab.Controls.Add(row8)
        count = 0


        'Regularised
        '--------------
        If emp = 0 Or emp = 2 Then


            If type = 0 Then
                sql = "select em1.emp_code,ed1.new_empcode,em1.emp_name,b.branch_name from employee_master em1,employee_master_dtl ed1,branch b,employ_firm f where em1.branch_id=b.BRANCH_ID and em1.emp_code=ed1.emp_code  and em1.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em1.status_id=5 and to_date(em1.join_dt)<to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and to_date(ed1.discont_dt) between to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and to_date('31-dec'||'-'||(to_char(sysdate,'yyyy')-1)) and ed1.new_empcode is not null"
            Else
                If type = 1 Then
                    sql = "select em1.emp_code,ed1.new_empcode,em1.emp_name,b.branch_name from employee_master em1,employee_master_dtl ed1,branch b,employee_master em2,employ_firm f where em1.branch_id=b.BRANCH_ID and em1.emp_code=ed1.emp_code  and em1.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em1.status_id=5 and to_date(em1.join_dt)<to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and to_date(ed1.discont_dt) between to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and to_date('31-dec'||'-'||(to_char(sysdate,'yyyy')-1)) and ed1.new_empcode is not null and em2.emp_code=ed1.new_empcode and em2.status_id=1"
                Else
                    If type = 2 Then
                        sql = "select em1.emp_code,ed1.new_empcode,em1.emp_name,b.branch_name from employee_master em1,employee_master_dtl ed1,branch b,employee_master em2,employ_firm f where em1.branch_id=b.BRANCH_ID and em1.emp_code=ed1.emp_code  and em1.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em1.status_id=5 and to_date(em1.join_dt)<to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and to_date(ed1.discont_dt) between to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and to_date('31-dec'||'-'||(to_char(sysdate,'yyyy')-1)) and ed1.new_empcode is not null and em2.emp_code=ed1.new_empcode and em2.status_id<>1"
                    End If
                End If
            End If

            dt = oh.ExecuteDataSet(sql).Tables(0)
            lv_old = 0
            lv_new = 0
            tot_lv = 0
            For Each dr In dt.Rows
                lv_old = 0
                lv_new = 0
                tot_lv = 0
                sql = "select nvl(sum(ed.leave_days),0) from employ_leave_dtl ed where to_date(ed.leave_frdate)>=to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and to_date(ed.leave_todate)<to_date('1-jan'||'-'||to_char(sysdate,'yyyy')) and ed.leave_process_id not in(0,3) and ed.status=1 and ed.emp_code=" & dr(0) & ""
                dt1 = oh.ExecuteDataSet(sql).Tables(0)
                'If dt1.Rows.Count > 0 Then
                lv_old = dt1.Rows(0)(0)
                'End If
                sql = "select count(*) from employee_master_dtl emd where (to_date(emd.discont_dt)>to_date('31-dec'||'-'||(to_char(sysdate,'yyyy')-1)) or to_date(emd.discont_dt) is null) and emd.new_empcode is null and emd.emp_code=" & dr(1) & ""
                dt1 = oh.ExecuteDataSet(sql).Tables(0)
                If dt1.Rows(0)(0) <> 0 Then
                    sql = "select nvl(sum(ed.leave_days),0) from employ_leave_dtl ed where to_date(ed.leave_frdate)>=to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and to_date(ed.leave_todate)<to_date('1-jan'||'-'||to_char(sysdate,'yyyy')) and ed.leave_process_id not in(0,3) and ed.status=1 and ed.emp_code=" & dr(1) & " "
                    dt1 = oh.ExecuteDataSet(sql).Tables(0)

                    lv_new = dt1.Rows(0)(0)
                    tot_lv = lv_old + lv_new
                    If colors.Equals("#fff7ff") = True Then
                        colors = "#eef9ff"
                    Else
                        colors = "#fff7ff"
                    End If
                    If tot_lv <= 10 Then

                        'sql = "insert into leave10_vimal values(" & dr(1) & "," & tot_lv & ")"
                        'oh.ExecuteNonQuery(sql)
                        Dim row7 As New TableRow
                        row7.Attributes.Add("bgcolor", colors)
                        Dim c71, c72, c73, c74, c75, c76, c77, c78, c79 As New TableCell
                        c71.ColumnSpan = 1
                        c71.Text = "<font size=2>" & dr(3) & "</font>"
                        c71.HorizontalAlign = HorizontalAlign.Left
                        row7.Controls.Add(c71)
                        tab.Controls.Add(row7)
                        c72.ColumnSpan = 1
                        c72.Text = "<font size=2>" & dr(1) & "(" & dr(0) & ")</font>"
                        c72.HorizontalAlign = HorizontalAlign.Center
                        row7.Controls.Add(c72)
                        tab.Controls.Add(row7)
                        c73.ColumnSpan = 1
                        c73.Text = "<font size=2><B>" & dr(2) & "</B></font>"
                        c73.HorizontalAlign = HorizontalAlign.Left
                        row7.Controls.Add(c73)
                        tab.Controls.Add(row7)
                        c74.ColumnSpan = 1
                        c74.Text = "<font size=2>" & tot_lv & "</font>"
                        c74.HorizontalAlign = HorizontalAlign.Right
                        row7.Controls.Add(c74)
                        tab.Controls.Add(row7)
                        'c75.ColumnSpan = 2
                        'If IsDBNull(dr(4)) Then
                        '    c75.Text = "<font size=2> NIL </font>"
                        'Else
                        '    c75.Text = "<font size=2>" & Format(dr(4), "dd/MMM/yyyy") & "</font>"

                        'End If
                        'c75.HorizontalAlign = HorizontalAlign.Left
                        'row7.Controls.Add(c75)
                        'tab.Controls.Add(row7)

                        'c76.ColumnSpan = 2
                        'c76.Text = "<font size=2>" & dr(5) & "</font>"
                        'c76.HorizontalAlign = HorizontalAlign.Center
                        'row7.Controls.Add(c76)
                        'tab.Controls.Add(row7)
                        'c77.ColumnSpan = 2
                        'c77.Text = "<font size=2>" & FormatNumber(dr(6), 2) & "</font>"
                        'c77.HorizontalAlign = HorizontalAlign.Right
                        'row7.Controls.Add(c77)
                        'tab.Controls.Add(row7)
                        'c78.ColumnSpan = 2
                        'c78.Text = "<font size=2>" & FormatNumber(dr(7), 2) & "</font>"
                        'c78.HorizontalAlign = HorizontalAlign.Right
                        'row7.Controls.Add(c78)
                        'tab.Controls.Add(row7)
                        'c79.ColumnSpan = 2
                        'c79.Text = "<font size=2>" & FormatNumber(dr(8), 2) & "</font>"
                        'c79.HorizontalAlign = HorizontalAlign.Right
                        'row7.Controls.Add(c79)
                        'tab.Controls.Add(row7)

                        count = count + 1
                    End If
                End If

            Next
        End If

        'Regular
        '--------------
        If emp = 0 Or emp = 1 Then

            If type = 0 Then
                sql = "select b.BRANCH_NAME,em.emp_code,em.emp_name,nvl(sum(ed.leave_days),0) from employee_master em left outer join employ_leave_dtl ed on(em.emp_code=ed.emp_code and to_date(ed.leave_frdate)>=to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and to_date(ed.leave_todate)<to_date('1-jan'||'-'||to_char(sysdate,'yyyy')) and ed.leave_process_id not in(0,3) and ed.status=1 ),employee_master_dtl emd,branch b,employ_firm f where em.branch_id=b.BRANCH_ID and em.emp_code=emd.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_type=1 and to_date(em.join_dt)<to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and (to_date(emd.discont_dt)>to_date('31-dec'||'-'||(to_char(sysdate,'yyyy')-1)) or to_date(emd.discont_dt) is null) and emd.new_empcode is null having nvl(sum(ed.leave_days),0)<=10 group by em.emp_code,em.emp_name,BRANCH_NAME order by BRANCH_NAME"
            Else
                If type = 1 Then
                    sql = "select b.BRANCH_NAME,em.emp_code,em.emp_name,nvl(sum(ed.leave_days),0) from employee_master em left outer join employ_leave_dtl ed on(em.emp_code=ed.emp_code and to_date(ed.leave_frdate)>=to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and to_date(ed.leave_todate)<to_date('1-jan'||'-'||to_char(sysdate,'yyyy')) and ed.leave_process_id not in(0,3) and ed.status=1 ),employee_master_dtl emd,branch b,employ_firm f where em.branch_id=b.BRANCH_ID and em.emp_code=emd.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_type=1 and to_date(em.join_dt)<to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and (to_date(emd.discont_dt)>to_date('31-dec'||'-'||(to_char(sysdate,'yyyy')-1)) or to_date(emd.discont_dt) is null) and emd.new_empcode is null and em.status_id=1 having nvl(sum(ed.leave_days),0)<=10 group by em.emp_code,em.emp_name,BRANCH_NAME order by BRANCH_NAME"
                Else
                    If type = 2 Then
                        sql = "select b.BRANCH_NAME,em.emp_code,em.emp_name,nvl(sum(ed.leave_days),0) from employee_master em left outer join employ_leave_dtl ed on(em.emp_code=ed.emp_code and to_date(ed.leave_frdate)>=to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and to_date(ed.leave_todate)<to_date('1-jan'||'-'||to_char(sysdate,'yyyy')) and ed.leave_process_id not in(0,3) and ed.status=1 ),employee_master_dtl emd,branch b,employ_firm f where em.branch_id=b.BRANCH_ID and em.emp_code=emd.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_type=1 and to_date(em.join_dt)<to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and (to_date(emd.discont_dt)>to_date('31-dec'||'-'||(to_char(sysdate,'yyyy')-1)) or to_date(emd.discont_dt) is null) and emd.new_empcode is null and em.status_id<>1 having nvl(sum(ed.leave_days),0)<=10 group by em.emp_code,em.emp_name,BRANCH_NAME order by BRANCH_NAME"
                    End If
                End If
            End If
            dt = oh.ExecuteDataSet(sql).Tables(0)

            For Each dr In dt.Rows
                If colors.Equals("#fff7ff") = True Then
                    colors = "#eef9ff"
                Else
                    colors = "#fff7ff"
                End If
                Dim row7 As New TableRow
                row7.Attributes.Add("bgcolor", colors)
                Dim c71, c72, c73, c74, c75, c76, c77, c78, c79 As New TableCell
                c71.ColumnSpan = 1
                c71.Text = "<font size=2>" & dr(0) & "</font>"
                c71.HorizontalAlign = HorizontalAlign.Left
                row7.Controls.Add(c71)
                tab.Controls.Add(row7)
                c72.ColumnSpan = 1
                c72.Text = "<font size=2>" & dr(1) & "</font>"
                c72.HorizontalAlign = HorizontalAlign.Center
                row7.Controls.Add(c72)
                tab.Controls.Add(row7)
                c73.ColumnSpan = 1
                c73.Text = "<font size=2><B>" & dr(2) & "</B></font>"
                c73.HorizontalAlign = HorizontalAlign.Left
                row7.Controls.Add(c73)
                tab.Controls.Add(row7)
                c74.ColumnSpan = 1
                c74.Text = "<font size=2>" & dr(3) & "</font>"
                c74.HorizontalAlign = HorizontalAlign.Right
                row7.Controls.Add(c74)
                tab.Controls.Add(row7)
                'c75.ColumnSpan = 2
                'If IsDBNull(dr(4)) Then
                '    c75.Text = "<font size=2> NIL </font>"
                'Else
                '    c75.Text = "<font size=2>" & Format(dr(4), "dd/MMM/yyyy") & "</font>"

                'End If
                'c75.HorizontalAlign = HorizontalAlign.Left
                'row7.Controls.Add(c75)
                'tab.Controls.Add(row7)

                'c76.ColumnSpan = 2
                'c76.Text = "<font size=2>" & dr(5) & "</font>"
                'c76.HorizontalAlign = HorizontalAlign.Center
                'row7.Controls.Add(c76)
                'tab.Controls.Add(row7)
                'c77.ColumnSpan = 2
                'c77.Text = "<font size=2>" & FormatNumber(dr(6), 2) & "</font>"
                'c77.HorizontalAlign = HorizontalAlign.Right
                'row7.Controls.Add(c77)
                'tab.Controls.Add(row7)
                'c78.ColumnSpan = 2
                'c78.Text = "<font size=2>" & FormatNumber(dr(7), 2) & "</font>"
                'c78.HorizontalAlign = HorizontalAlign.Right
                'row7.Controls.Add(c78)
                'tab.Controls.Add(row7)
                'c79.ColumnSpan = 2
                'c79.Text = "<font size=2>" & FormatNumber(dr(8), 2) & "</font>"
                'c79.HorizontalAlign = HorizontalAlign.Right
                'row7.Controls.Add(c79)
                'tab.Controls.Add(row7)

                count = count + 1
            Next
        End If

        'Outsource
        '--------------
        If emp = 0 Or emp = 3 Then

            If type = 0 Then
                sql = "select b.BRANCH_NAME,em.emp_code,em.emp_name,nvl(sum(ed.leave_days),0) from employee_master em left outer join employ_leave_dtl ed on(em.emp_code=ed.emp_code and to_date(ed.leave_frdate)>=to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and to_date(ed.leave_todate)<to_date('1-jan'||'-'||to_char(sysdate,'yyyy'))  and ed.leave_process_id not in(0,3) and ed.status=1),employee_master_dtl emd,branch b,employ_firm f where em.branch_id=b.BRANCH_ID and em.emp_code=emd.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_type=2 and to_date(em.join_dt)<to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and (to_date(emd.discont_dt)>to_date('31-dec'||'-'||(to_char(sysdate,'yyyy')-1)) or to_date(emd.discont_dt) is null) and emd.new_empcode is null having nvl(sum(ed.leave_days),0)<=10 group by b.BRANCH_NAME,em.emp_code,em.emp_name order by BRANCH_NAME"
            Else
                If type = 1 Then
                    sql = "select b.BRANCH_NAME,em.emp_code,em.emp_name,nvl(sum(ed.leave_days),0) from employee_master em left outer join employ_leave_dtl ed on(em.emp_code=ed.emp_code and to_date(ed.leave_frdate)>=to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and to_date(ed.leave_todate)<to_date('1-jan'||'-'||to_char(sysdate,'yyyy'))  and ed.leave_process_id not in(0,3) and ed.status=1),employee_master_dtl emd,branch b,employ_firm f  where em.branch_id=b.BRANCH_ID and em.emp_code=emd.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_type=2 and to_date(em.join_dt)<to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and (to_date(emd.discont_dt)>to_date('31-dec'||'-'||(to_char(sysdate,'yyyy')-1)) or to_date(emd.discont_dt) is null) and emd.new_empcode is null and em.status_id=1 having nvl(sum(ed.leave_days),0)<=10 group by b.BRANCH_NAME,em.emp_code,em.emp_name order by BRANCH_NAME"
                Else
                    If type = 2 Then
                        sql = "select b.BRANCH_NAME,em.emp_code,em.emp_name,nvl(sum(ed.leave_days),0) from employee_master em left outer join employ_leave_dtl ed on(em.emp_code=ed.emp_code and to_date(ed.leave_frdate)>=to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and to_date(ed.leave_todate)<to_date('1-jan'||'-'||to_char(sysdate,'yyyy'))  and ed.leave_process_id not in(0,3) and ed.status=1),employee_master_dtl emd,branch b,employ_firm f  where em.branch_id=b.BRANCH_ID and em.emp_code=emd.emp_code and em.emp_code=f.emp_code and f.firm_id=" & Session("firm_id") & " and em.emp_type=2 and to_date(em.join_dt)<to_date('1-jan'||'-'||(to_char(sysdate,'yyyy')-1)) and (to_date(emd.discont_dt)>to_date('31-dec'||'-'||(to_char(sysdate,'yyyy')-1)) or to_date(emd.discont_dt) is null) and emd.new_empcode is null and em.status_id<>1 having nvl(sum(ed.leave_days),0)<=10 group by b.BRANCH_NAME,em.emp_code,em.emp_name order by BRANCH_NAME"
                    End If
                End If
            End If

            dt = oh.ExecuteDataSet(sql).Tables(0)
            For Each dr In dt.Rows
                If colors.Equals("#fff7ff") = True Then
                    colors = "#eef9ff"
                Else
                    colors = "#fff7ff"
                End If
                'sql = "insert into leave10_vimal values(" & dr(1) & "," & tot_lv & ")"
                'oh.ExecuteNonQuery(sql)
                Dim row7 As New TableRow
                row7.Attributes.Add("bgcolor", colors)
                Dim c71, c72, c73, c74, c75, c76, c77, c78, c79 As New TableCell
                c71.ColumnSpan = 1
                c71.Text = "<font size=2>" & dr(0) & "</font>"
                c71.HorizontalAlign = HorizontalAlign.Left
                row7.Controls.Add(c71)
                tab.Controls.Add(row7)
                c72.ColumnSpan = 1
                c72.Text = "<font size=2>" & dr(1) & "</font>"
                c72.HorizontalAlign = HorizontalAlign.Center
                row7.Controls.Add(c72)
                tab.Controls.Add(row7)
                c73.ColumnSpan = 1
                c73.Text = "<font size=2><B>" & dr(2) & "</B></font>"
                c73.HorizontalAlign = HorizontalAlign.Left
                row7.Controls.Add(c73)
                tab.Controls.Add(row7)
                c74.ColumnSpan = 1
                c74.Text = "<font size=2>" & dr(3) & "</font>"
                c74.HorizontalAlign = HorizontalAlign.Right
                row7.Controls.Add(c74)
                tab.Controls.Add(row7)
                'c75.ColumnSpan = 2
                'If IsDBNull(dr(4)) Then
                '    c75.Text = "<font size=2> NIL </font>"
                'Else
                '    c75.Text = "<font size=2>" & Format(dr(4), "dd/MMM/yyyy") & "</font>"

                'End If
                'c75.HorizontalAlign = HorizontalAlign.Left
                'row7.Controls.Add(c75)
                'tab.Controls.Add(row7)

                'c76.ColumnSpan = 2
                'c76.Text = "<font size=2>" & dr(5) & "</font>"
                'c76.HorizontalAlign = HorizontalAlign.Center
                'row7.Controls.Add(c76)
                'tab.Controls.Add(row7)
                'c77.ColumnSpan = 2
                'c77.Text = "<font size=2>" & FormatNumber(dr(6), 2) & "</font>"
                'c77.HorizontalAlign = HorizontalAlign.Right
                'row7.Controls.Add(c77)
                'tab.Controls.Add(row7)
                'c78.ColumnSpan = 2
                'c78.Text = "<font size=2>" & FormatNumber(dr(7), 2) & "</font>"
                'c78.HorizontalAlign = HorizontalAlign.Right
                'row7.Controls.Add(c78)
                'tab.Controls.Add(row7)
                'c79.ColumnSpan = 2
                'c79.Text = "<font size=2>" & FormatNumber(dr(8), 2) & "</font>"
                'c79.HorizontalAlign = HorizontalAlign.Right
                'row7.Controls.Add(c79)
                'tab.Controls.Add(row7)

                count = count + 1
            Next
        End If

        Dim row9 As New TableRow
        Dim c91 As New TableCell
        c91.ColumnSpan = 4
        c91.Text = "<hr align=center width=100%>"
        row9.Controls.Add(c91)
        tab.Controls.Add(row9)


        Dim row10 As New TableRow
        Dim c101, c102 As New TableCell
        c101.ColumnSpan = 2
        c101.Text = "<font size=2><B>TOTAL:</B></font>"
        c101.HorizontalAlign = HorizontalAlign.Center
        row10.Controls.Add(c101)
        c102.ColumnSpan = 2
        c102.Text = "<font size=2><B>" & count & "</B></font>"
        c102.HorizontalAlign = HorizontalAlign.Right
        row10.Controls.Add(c102)
        tab.Controls.Add(row10)
        Panel1.Controls.Add(tab)
    End Sub


End Class

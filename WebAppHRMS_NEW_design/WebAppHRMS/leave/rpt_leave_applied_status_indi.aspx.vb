Imports System.Data
Imports System.Data.OracleClient
Partial Class Leave_Module_rpt_leave_applied_status_indi_e923e6014528
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strp As String = "select el.emp_code from employee_master_dtl el where el.new_empcode=" & Me.Request.QueryString("empcode")
        Dim pdt As DataTable = oh.ExecuteDataSet(strp).Tables(0)
        Dim str As String
        If pdt.Rows.Count = 0 Then
            str = "select e.leave_frdate, e.leave_todate, e.leave_apply_date, case when e.leave_form in (11, 12) then to_number(0.5) else e.leave_days end leave_days, lm.leave_abbr, m.category_name, d.reason_name, decode(e.status_id, 1, 'SANCTIONED', 0, 'APPLIED', 2, 'REJECTED', 3, 'CANCELLED', 4, 'RECOMMENDED', 5, 'SUB DEP HEAD RECOMMENDED') as status, case when e.recom_person is not null then (select emp_code || ' - ' || emp_name from employee_master where emp_code = e.recom_person) end as rec_person, e.recom_date, e.reject_reason, case when e.sanc_person is not null then (select emp_code || ' - ' || emp_name from employee_master where emp_code = e.sanc_person) end as sanc_person, e.sanc_date from hrm_leave_apply_sanction e, hrm_category_master m, hrm_category_dtl d, leave_master lm where e.emp_code = " & Me.Request.QueryString("empcode") & " and e.leave_apply_date between ('" & Request.QueryString("fromdt") & "') and ('" & Request.QueryString("todt") & "') and e.category_id = m.category_id and m.category_id = d.category_id and e.leave_id = lm.leave_id and e.reason_id = d.reason_id union select e.leave_frdate, e.leave_todate, e.leave_apply_date, case when e.leave_form in (11, 12) then to_number(0.5) else e.leave_days end leave_days, lm.leave_abbr, '---', e.leave_reason, decode(e.status_id, 1, 'SANCTIONED', 0, 'APPLIED', 2, 'REJECTED', 3, 'CANCELLED', 4, 'RECOMMENDED', 5, 'SUB DEP HEAD RECOMMENDED') as status, case when e.recom_person is not null then (select emp_code || ' - ' || emp_name from employee_master where emp_code = e.recom_person) end as rec_person, e.recom_date, e.reject_reason, case when e.sanc_person is not null then (select emp_code || ' - ' || emp_name from employee_master where emp_code = e.sanc_person) end as sanc_person, e.sanc_date from hrm_leave_apply_sanction e, /* hrm_category_master m, hrm_category_dtl d,*/ leave_master lm where e.emp_code = " & Me.Request.QueryString("empcode") & " and e.leave_apply_date between ('" & Request.QueryString("fromdt") & "') and ('" & Request.QueryString("todt") & "') and e.category_id =0 and e.leave_id = lm.leave_id and e.reason_id = 0 order by leave_frdate"
        Else
            str = "select e.leave_frdate, e.leave_todate, e.leave_apply_date, case when e.leave_form in (11, 12) then to_number(0.5) else e.leave_days end leave_days, lm.leave_abbr, m.category_name, d.reason_name, decode(e.status_id, 1, 'SANCTIONED', 0, 'APPLIED', 2, 'REJECTED', 3, 'CANCELLED', 4, 'RECOMMENDED', 5, 'SUB DEP HEAD RECOMMENDED') as status, case when e.recom_person is not null then (select emp_code || ' - ' || emp_name from employee_master where emp_code = e.recom_person) end as rec_person, e.recom_date, e.reject_reason, case when e.sanc_person is not null then (select emp_code || ' - ' || emp_name from employee_master where emp_code = e.sanc_person) end as sanc_person, e.sanc_date from hrm_leave_apply_sanction e, hrm_category_master m, hrm_category_dtl d, leave_master lm where (e.emp_code = " & Me.Request.QueryString("empcode") & " or e.emp_code = " & pdt.Rows(0)(0) & ") and e.leave_apply_date between ('" & Request.QueryString("fromdt") & "') and ('" & Request.QueryString("todt") & "') and e.category_id = m.category_id and m.category_id = d.category_id and e.leave_id = lm.leave_id and e.reason_id = d.reason_id order by e.leave_frdate union select e.leave_frdate, e.leave_todate, e.leave_apply_date, case when e.leave_form in (11, 12) then to_number(0.5) else e.leave_days end leave_days, lm.leave_abbr, '---', e.leave_reason, decode(e.status_id, 1, 'SANCTIONED', 0, 'APPLIED', 2, 'REJECTED', 3, 'CANCELLED', 4, 'RECOMMENDED', 5, 'SUB DEP HEAD RECOMMENDED') as status, case when e.recom_person is not null then (select emp_code || ' - ' || emp_name from employee_master where emp_code = e.recom_person) end as rec_person, e.recom_date, e.reject_reason, case when e.sanc_person is not null then (select emp_code || ' - ' || emp_name from employee_master where emp_code = e.sanc_person) end as sanc_person, e.sanc_date from hrm_leave_apply_sanction e, /* hrm_category_master m, hrm_category_dtl d,*/ leave_master lm where (e.emp_code = " & Me.Request.QueryString("empcode") & " or e.emp_code = " & pdt.Rows(0)(0) & ") and e.leave_apply_date between ('" & Request.QueryString("fromdt") & "') and ('" & Request.QueryString("todt") & "') /* and e.leave_apply_date between ('1/JAN/2010') and ('30/SEP/2024')*/ and e.category_id = 0 and e.leave_id = lm.leave_id and e.reason_id = 0 order by e.leave_frdate"

        End If
        Dim dt As DataTable = oh.ExecuteDataSet(str).Tables(0)
        'table declaration
        Dim tab1 As New Table
        tab1.BorderWidth = 1
        tab1.Attributes.Add("width", "100%")
        '1st row declaration
        Dim tabr1 As New TableRow
        tabr1.Width = 17
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        'cell declaration
        Dim tabc1 As New TableCell
        tabc1.Attributes.Add("forecolor", "blue")
        tabc1.Attributes.Add("align", "center")
        tabc1.ColumnSpan = 17
        ' tabc1.Text = "<body align=center ><b><font size=4>MANAPPURAM GROUP OF COMPANIES</font></b></body>"
        tabc1.Text = "<body align=center ><b><font size=4>" & Session("firm_name") & "</font></b></body>"

        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 17
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 17
        tabc2.Attributes.Add("align", "center")
        Dim kt As DataTable = oh.ExecuteDataSet("select emp_code || ' - ' || emp_name from employee_master e where e.emp_code =" & Me.Request.QueryString("empcode")).Tables(0)

        tabc2.Text = "<body align=center color=red><b><font size=3> LEAVE STATUS REPORT - " & kt.Rows(0)(0) & " </font></b></body>"

        tabc2.ForeColor = Drawing.Color.Maroon
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)
        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.ColumnSpan = 5
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=3>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)

        Dim tabcct As New TableCell
        tabcct.ColumnSpan = 7
        tabcct.Attributes.Add("align", "center")
        'Dim kt As DataTable = oh.ExecuteDataSet("select emp_code || ' - ' || emp_name from employee_master e where e.emp_code =" & Me.Request.QueryString("empcode")).Tables(0)

        tabcct.Text = " "
        tabcct.ForeColor = Drawing.Color.Blue
        tabrr3.Controls.Add(tabcct)
        tab1.Controls.Add(tabrr3)


        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ColumnSpan = 5
        tabcc4.Attributes.Add("align", "right")
        Dim dat As String
        Dim hr As Integer = Date.Now.Hour
        If hr > 12 Then
            dat = "PM"
        Else
            dat = "AM"
        End If
        If (hr = 0) Then
            hr = 12
        End If

        If (hr > 12) Then
            hr = hr - 12
        End If

        tabcc4.Text = "<b><font size=3>TIME: " & hr.ToString & ":" & Date.Now.Minute & ":" & Date.Now.Second & " " & dat & "</font></b>"
        tabcc4.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabline As New TableRow
        tabline.Width = 17
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 17
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)
        ''''''''''''''''''''''''''''''''''''''''
        Dim tabr5 As New TableRow
        tabr5.Width = 17
        tabr5.ForeColor = Drawing.Color.DarkRed
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8, tabr5c9, tabr5c10, tabr5c11, tabr5c12, tabr5c13 As New TableCell

        tabr5c1.ColumnSpan = "1"
        tabr5c2.ColumnSpan = "1"
        tabr5c3.ColumnSpan = "1"
        tabr5c4.ColumnSpan = "1"
        tabr5c5.ColumnSpan = "1"
        tabr5c6.ColumnSpan = "1"
        tabr5c7.ColumnSpan = "2"
        tabr5c8.ColumnSpan = "1"
        tabr5c9.ColumnSpan = "2"
        tabr5c10.ColumnSpan = "1"
        tabr5c11.ColumnSpan = "2"
        tabr5c12.ColumnSpan = "2"
        tabr5c13.ColumnSpan = "1"

        tabr5c1.HorizontalAlign = HorizontalAlign.Left
        tabr5c2.HorizontalAlign = HorizontalAlign.Left
        tabr5c5.HorizontalAlign = HorizontalAlign.Left
        tabr5c6.HorizontalAlign = HorizontalAlign.Center
        tabr5c3.HorizontalAlign = HorizontalAlign.Left
        tabr5c4.HorizontalAlign = HorizontalAlign.Left
        tabr5c7.HorizontalAlign = HorizontalAlign.Left
        tabr5c8.HorizontalAlign = HorizontalAlign.Left
        tabr5c9.HorizontalAlign = HorizontalAlign.Left
        tabr5c10.HorizontalAlign = HorizontalAlign.Left
        tabr5c11.HorizontalAlign = HorizontalAlign.Left
        tabr5c13.HorizontalAlign = HorizontalAlign.Left
        tabr5c12.HorizontalAlign = HorizontalAlign.Left

        tabr5c1.Text = "<b><font size=2.5>FROM DT.</font></b>"
        tabr5c2.Text = "<b><font size=2.5>TO DT.</font></b>"
        tabr5c3.Text = "<b><font size=2.5>APPLY DT.</font></b>"
        tabr5c4.Text = "<b><font size=2.5>LEAVE DAYS</font></b>"
        tabr5c5.Text = "<b><font size=2.5>LEAVE TYPE</font></b>"
        tabr5c6.Text = "<b><font size=2.5>CATEGORY</font></b>"
        tabr5c7.Text = "<b><font size=2.5>REASON</font></b>"
        tabr5c8.Text = "<b><font size=2.5>STATUS</font></b>"
        tabr5c9.Text = "<b><font size=2.5>RECOMMENTED BY</font></b>"
        tabr5c10.Text = "<b><font size=2.5>RECOMMENTED DATE</font></b>"
        tabr5c11.Text = "<b><font size=2.5>REJECT REASON</font></b>"
        tabr5c12.Text = "<b><font size=2.5>SANCTIONED/ REJECTED BY</font></b>"
        tabr5c13.Text = "<b><font size=2.5>SANCTIONED/REJECTED DATE</font></b>"


        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        tabr5.Controls.Add(tabr5c6)
        tabr5.Controls.Add(tabr5c7)
        tabr5.Controls.Add(tabr5c8)
        tabr5.Controls.Add(tabr5c9)
        tabr5.Controls.Add(tabr5c10)
        tabr5.Controls.Add(tabr5c11)
        tabr5.Controls.Add(tabr5c12)
        tabr5.Controls.Add(tabr5c13)
        tab1.Controls.Add(tabr5)

        '''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 17
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 17
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)
        '''''''''''''''''''''''''''''''''
        Dim colors As String
        colors = "#fff7ff"
        Dim dr As DataRow
        For Each dr In dt.Rows
            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If
            Dim tabr6 As New TableRow
            tabr6.Width = 17
            tabr6.Attributes.Add("bgcolor", colors)
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8, tabr6c9, tabr6c10, tabr6c11, tabr6c12, tabr6c13 As New TableCell
            tabr6c1.ColumnSpan = "1"
            tabr6c2.ColumnSpan = "1"
            tabr6c3.ColumnSpan = "1"
            tabr6c4.ColumnSpan = "1"
            tabr6c5.ColumnSpan = "1"
            tabr6c6.ColumnSpan = "1"
            tabr6c7.ColumnSpan = "2"
            tabr6c8.ColumnSpan = "1"
            tabr6c9.ColumnSpan = "2"
            tabr6c10.ColumnSpan = "1"
            tabr6c11.ColumnSpan = "2"
            tabr6c12.ColumnSpan = "2"
            tabr6c13.ColumnSpan = "1"

            tabr6c1.HorizontalAlign = HorizontalAlign.Left
            tabr6c2.HorizontalAlign = HorizontalAlign.Left
            tabr6c5.HorizontalAlign = HorizontalAlign.Left
            tabr6c6.HorizontalAlign = HorizontalAlign.Center
            tabr6c3.HorizontalAlign = HorizontalAlign.Left
            tabr6c4.HorizontalAlign = HorizontalAlign.Left
            tabr6c7.HorizontalAlign = HorizontalAlign.Left
            tabr6c8.HorizontalAlign = HorizontalAlign.Left
            tabr6c9.HorizontalAlign = HorizontalAlign.Left
            tabr6c10.HorizontalAlign = HorizontalAlign.Left
            tabr6c11.HorizontalAlign = HorizontalAlign.Left
            tabr6c13.HorizontalAlign = HorizontalAlign.Left
            tabr6c12.HorizontalAlign = HorizontalAlign.Left


            tabr6c1.Text = "<font size=2>" & Format(dr(0), "dd/MMM/yyyy") & "&nbsp;</font>"
            tabr6c2.Text = "<font size=2>" & Format(dr(1), "dd/MMM/yyyy") & "&nbsp;</font>"
            tabr6c3.Text = "<font size=2>" & Format(dr(2), "dd/MMM/yyyy") & "&nbsp;</font>"
            tabr6c4.Text = "<font size=2>" & dr(3) & "&nbsp;</font>"
            tabr6c5.Text = "<font size=2>" & dr(4) & "&nbsp;</font>"
            tabr6c6.Text = "<font size=2>" & dr(5) & "&nbsp;</font>"
            tabr6c7.Text = "<font size=2>" & dr(6) & "&nbsp;</font>"
            tabr6c8.Text = "<font size=2>" & dr(7) & "</font>"
            tabr6c9.Text = "<font size=2>" & dr(8) & "&nbsp;</font>"
            If IsDBNull(dr(9)) Then
                tabr6c10.Text = "<font size=2>&nbsp;</font>"
            Else
                tabr6c10.Text = "<font size=2>" & Format(dr(9), "dd/MMM/yyyy") & "&nbsp;</font>"
            End If
            tabr6c11.Text = "<font size=2>" & dr(10) & "&nbsp;</font>"
            tabr6c12.Text = "<font size=2>" & dr(11) & "&nbsp;</font>"
            If IsDBNull(dr(12)) Then
                tabr6c13.Text = "<font size=2>&nbsp;</font>"
            Else
                tabr6c13.Text = "<font size=2>" & Format(dr(12), "dd/MMM/yyyy") & "&nbsp;</font>"
            End If

            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)
            tabr6.Controls.Add(tabr6c6)
            tabr6.Controls.Add(tabr6c7)
            tabr6.Controls.Add(tabr6c8)
            tabr6.Controls.Add(tabr6c9)
            tabr6.Controls.Add(tabr6c10)
            tabr6.Controls.Add(tabr6c11)
            tabr6.Controls.Add(tabr6c12)
            tabr6.Controls.Add(tabr6c13)
            tab1.Controls.Add(tabr6)
        Next

        Me.Panel1.Controls.Add(tab1)

    End Sub
End Class

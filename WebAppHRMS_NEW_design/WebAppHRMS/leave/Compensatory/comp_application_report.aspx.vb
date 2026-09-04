Imports System.Data
Imports System.Data.OracleClient
Partial Class Compensatory_comp_application_report_a2f936366431
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.OracleHelper
    Dim sql As String
    Dim dt, dt1 As New DataTable
    Dim dr As DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------VAPT - improper parameter validation---------------------------------------
        'Dim paramCount As Integer = Request.QueryString.Count
        'If Request.QueryString.Count > 0 Then
        '    Response.StatusCode = 400
        '    Response.StatusDescription = "Bad Request"
        '    Response.End()
        'End If
        Dim usr() As String
        usr = Session("user_id").ToString().Split("!")
        Dim colors As String
        colors = "#fff7ff"
        Dim tab As New Table
        tab.Attributes.Add("width", "95%")
        tab.Attributes.Add("align", "left")
        Dim row1 As New TableRow
        Dim c11 As New TableCell
        c11.ColumnSpan = 10
        c11.Text = "<font size=4><b> " & Session("firm_name") & " </font></b>"
        c11.HorizontalAlign = HorizontalAlign.Center
        row1.Controls.Add(c11)
        tab.Controls.Add(row1)
        Dim row2 As New TableRow
        Dim c21 As New TableCell
        Dim c22 As New TableCell
        c21.ColumnSpan = 5
        c22.ColumnSpan = 5
        c21.Attributes.Add("width", "50%")
        c22.Attributes.Add("width", "50%")
        c21.Text = "<font size=1.5><b> Branch_name:" & Session("branch_name") & ", </font></b>"
        c21.HorizontalAlign = HorizontalAlign.Right
        c22.Text = "<font size=1.5><b> Branch_id:" & Session("branch_id") & " </font></b>"
        c22.HorizontalAlign = HorizontalAlign.Left
        row2.Controls.Add(c21)
        row2.Controls.Add(c22)
        tab.Controls.Add(row2)
        Dim row3 As New TableRow
        Dim c31 As New TableCell
        c31.ColumnSpan = 10
        c31.Text = "&nbsp;"
        row3.Controls.Add(c31)
        tab.Controls.Add(row3)
        Dim row4 As New TableRow
        row4.Attributes.Add("bgcolor", colors)
        Dim c41 As New TableCell
        Dim c42 As New TableCell
        Dim c43 As New TableCell
        c41.ColumnSpan = 3
        c42.ColumnSpan = 4
        c43.ColumnSpan = 3
        'c43.Attributes.Add("width", "")
        c41.Text = "<font size=1.5><b> Date :" & Format(Date.Now, "dd/MM/yyyy") & "</font></b>"
        c41.HorizontalAlign = HorizontalAlign.Left
        c42.Text = "<font size=1.5><b>COMPENSATORY REPORT</font></b>"
        c42.HorizontalAlign = HorizontalAlign.Center
        c43.Text = "<font size=1.5><b><div id=txt align=right></div></font></b>"
        c43.HorizontalAlign = HorizontalAlign.Right
        row4.Controls.Add(c41)
        row4.Controls.Add(c42)
        row4.Controls.Add(c43)
        tab.Controls.Add(row4)
        Dim row5 As New TableRow
        Dim c51 As New TableCell
        c51.ColumnSpan = 10
        c51.Text = "<hr align=center width=100%>"
        row5.Controls.Add(c51)
        tab.Controls.Add(row5)
        Dim row6 As New TableRow
        Dim c61, c62, c63, c64, c65, c66, c67, c68, c69, c611 As New TableCell
        c61.ColumnSpan = 1
        c61.Text = "Employee Name"
        c61.HorizontalAlign = HorizontalAlign.Left
        c62.ColumnSpan = 1
        c62.Text = "Leave Date"
        c62.HorizontalAlign = HorizontalAlign.Left
        c63.ColumnSpan = 1
        c63.Text = "Reason"
        c63.HorizontalAlign = HorizontalAlign.Left
        c64.ColumnSpan = 1
        c64.Text = "Enter Date"
        c64.HorizontalAlign = HorizontalAlign.Left
        c65.ColumnSpan = 1
        c65.Text = "Status"
        c65.HorizontalAlign = HorizontalAlign.Left
        c66.ColumnSpan = 1
        c66.Text = "Recom.&nbspBy"
        c66.HorizontalAlign = HorizontalAlign.Right
        c67.ColumnSpan = 1
        c67.Text = "Sanct.&nbspBy"
        c67.HorizontalAlign = HorizontalAlign.Left
        c68.ColumnSpan = 1
        c68.Text = "Cancel&nbspBy"
        c68.HorizontalAlign = HorizontalAlign.Left
        c69.ColumnSpan = 1
        c69.Text = "Reject&nbspBy"
        c69.HorizontalAlign = HorizontalAlign.Right

        c611.ColumnSpan = 1
        c611.Text = "Reason"
        c611.HorizontalAlign = HorizontalAlign.Right

        row6.Controls.Add(c61)
        row6.Controls.Add(c62)
        row6.Controls.Add(c63)
        row6.Controls.Add(c64)
        row6.Controls.Add(c65)
        row6.Controls.Add(c66)
        row6.Controls.Add(c67)
        row6.Controls.Add(c68)
        row6.Controls.Add(c69)
        row6.Controls.Add(c611)
        tab.Controls.Add(row6)
        Dim row8 As New TableRow
        Dim c81 As New TableCell
        c81.ColumnSpan = 10
        c81.Text = "<hr align=center width=100%>"
        row8.Controls.Add(c81)
        tab.Controls.Add(row8)


        'Regularised
        '--------------

        sql = "select e.emp_name,t.leave_dt,t.reason,t.apply_dt,t.status_id,nvl(t.reject_reason,0) from hrm_comp_appl t,branch_master b,employee_master e where t.emp_code=e.emp_code and e.branch_id=b.branch_id and t.emp_code=" & usr(0) & " and t.leave_dt>=to_date('" & Request.QueryString.Get("fdt") & "') and t.leave_dt<=to_date('" & Request.QueryString.Get("tdt") & "') order by t.apply_dt"

        dt = oh.ExecuteDataSet(sql).Tables(0)
        For Each dr In dt.Rows
            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If
            Dim row7 As New TableRow
            row7.Attributes.Add("bgcolor", colors)
            Dim c71, c72, c73, c74, c75, c76, c77, c78, c79, c711 As New TableCell
            c71.ColumnSpan = 1
            c71.Text = "<font size=1.5>" & dr(0) & "</font>"
            c71.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c71)
            tab.Controls.Add(row7)
            c72.ColumnSpan = 1
            c72.Text = "<font size=1.5>" & Format(dr(1), "dd/MMM/yyyy") & "</font>"
            c72.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c72)
            tab.Controls.Add(row7)
            c73.ColumnSpan = 1
            c73.Text = "<font size=1.5>" & dr(2) & "</font>"
            c73.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c73)
            tab.Controls.Add(row7)
            c74.ColumnSpan = 1
            c74.Text = "<font size=1.5>" & Format(dr(3), "dd/MMM/yyyy") & "</font>"
            c74.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c74)
            tab.Controls.Add(row7)




            c75.ColumnSpan = 1
            If CInt(dr(4)) = 0 Then
                c75.Text = "<font size=1.5> Applied </font>"
                c76.Text = "<font size=1.5> ----- </font>"
                c77.Text = "<font size=1.5> ----- </font>"
                c78.Text = "<font size=1.5> ----- </font>"
                c79.Text = "<font size=1.5> ----- </font>"
            Else
                If CInt(dr(4)) = 1 Then
                    c75.Text = "<font size=1.5>Sanctioned</font>"
                Else
                    If CInt(dr(4)) = 2 Then
                        c75.Text = "<font size=1.5>Rejected</font>"
                    Else
                        If CInt(dr(4)) = 3 Then
                            c75.Text = "<font size=1.5>Canceled</font>"
                        Else
                            If CInt(dr(4)) = 4 Then
                                c75.Text = "<font size=1.5>Recommended</font>"
                            Else
                                If CInt(dr(4)) = 5 Then
                                    c75.Text = "<font size=1.5>Canceled By HRM</font>"
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            c75.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c75)
            tab.Controls.Add(row7)

            If CInt(dr(4)) = 4 Then
                sql = "select em.emp_name from hrm_comp_appl t,employee_master em where em.emp_code=t.recom_person and t.emp_code=" & usr(0) & " and to_date(t.leave_dt)=to_date('" & Format(dr(1), "dd/MMM/yyyy") & "')"
                dt1 = oh.ExecuteDataSet(sql).Tables(0)
                c76.Text = "<font size=1.5> " & dt1.Rows(0)(0) & " </font>"
                c77.Text = "<font size=1.5> ----- </font>"
                c78.Text = "<font size=1.5> ----- </font>"
                c79.Text = "<font size=1.5> ----- </font>"
            End If

            If CInt(dr(4)) = 1 Then
                sql = "select em.emp_name from hrm_comp_appl t,employee_master em where em.emp_code=t.sanc_person and t.emp_code=" & usr(0) & " and to_date(t.leave_dt)=to_date('" & Format(dr(1), "dd/MMM/yyyy") & "')"
                dt1 = oh.ExecuteDataSet(sql).Tables(0)
                c77.Text = "<font size=1.5> " & dt1.Rows(0)(0) & " </font>"
                sql = "select em.emp_name from hrm_comp_appl t,employee_master em where em.emp_code=t.recom_person and t.emp_code=" & usr(0) & " and to_date(t.leave_dt)=to_date('" & Format(dr(1), "dd/MMM/yyyy") & "')"
                dt1 = oh.ExecuteDataSet(sql).Tables(0)
                If dt1.Rows.Count > 0 Then
                    c76.Text = "<font size=1.5> " & dt1.Rows(0)(0) & " </font>"
                Else
                    c76.Text = "<font size=1.5> ----- </font>"
                End If
                c78.Text = "<font size=1.5> ----- </font>"
                c79.Text = "<font size=1.5> ----- </font>"
            End If


            If CInt(dr(4)) = 2 Then

                sql = "select em.emp_name from hrm_comp_appl t,employee_master em where em.emp_code=t.sanc_person and t.emp_code=" & usr(0) & " and to_date(t.leave_dt)=to_date('" & Format(dr(1), "dd/MMM/yyyy") & "')"
                dt1 = oh.ExecuteDataSet(sql).Tables(0)
                If dt1.Rows.Count > 0 Then
                    c79.Text = "<font size=1.5> " & dt1.Rows(0)(0) & " </font>"
                    sql = "select em.emp_name from hrm_comp_appl t,employee_master em where em.emp_code=t.recom_person and t.emp_code=" & usr(0) & " and to_date(t.leave_dt)=to_date('" & Format(dr(1), "dd/MMM/yyyy") & "')"
                    dt1 = oh.ExecuteDataSet(sql).Tables(0)
                    If dt1.Rows.Count > 0 Then
                        c76.Text = "<font size=1.5> " & dt1.Rows(0)(0) & " </font>"
                    Else
                        c76.Text = "<font size=1.5> ----- </font>"
                    End If
                Else
                    sql = "select em.emp_name from hrm_comp_appl t,employee_master em where em.emp_code=t.recom_person and t.emp_code=" & usr(0) & " and to_date(t.leave_dt)=to_date('" & Format(dr(1), "dd/MMM/yyyy") & "')"
                    dt1 = oh.ExecuteDataSet(sql).Tables(0)
                    If dt1.Rows.Count > 0 Then
                        c79.Text = "<font size=1.5> " & dt1.Rows(0)(0) & " </font>"
                        c76.Text = "<font size=1.5> ----- </font>"
                    End If
                End If
                c77.Text = "<font size=1.5> ----- </font>"
                c78.Text = "<font size=1.5> ----- </font>"
            End If



            If CInt(dr(4)) = 3 Or CInt(dr(4)) = 5 Then
                sql = "select em.emp_name from hrm_comp_appl t,employee_master em where em.emp_code=t.canc_person and t.emp_code=" & usr(0) & " and to_date(t.leave_dt)=to_date('" & Format(dr(1), "dd/MMM/yyyy") & "')"
                dt1 = oh.ExecuteDataSet(sql).Tables(0)
                c78.Text = "<font size=1.5> " & dt1.Rows(0)(0) & " </font>"
                sql = "select em.emp_name from hrm_comp_appl t,employee_master em where em.emp_code=t.sanc_person and t.emp_code=" & usr(0) & " and to_date(t.leave_dt)=to_date('" & Format(dr(1), "dd/MMM/yyyy") & "')"
                dt1 = oh.ExecuteDataSet(sql).Tables(0)
                If dt1.Rows.Count > 0 Then
                    c77.Text = "<font size=1.5> " & dt1.Rows(0)(0) & " </font>"
                    sql = "select em.emp_name from hrm_comp_appl t,employee_master em where em.emp_code=t.recom_person and t.emp_code=" & usr(0) & " and to_date(t.leave_dt)=to_date('" & Format(dr(1), "dd/MMM/yyyy") & "')"
                    dt1 = oh.ExecuteDataSet(sql).Tables(0)
                    If dt1.Rows.Count > 0 Then
                        c76.Text = "<font size=1.5> " & dt1.Rows(0)(0) & " </font>"
                    Else
                        c76.Text = "<font size=1.5> ----- </font>"
                    End If
                Else
                    sql = "select em.emp_name from hrm_comp_appl t,employee_master em where em.emp_code=t.recom_person and t.emp_code=" & usr(0) & " and to_date(t.leave_dt)=to_date('" & Format(dr(1), "dd/MMM/yyyy") & "')"
                    dt1 = oh.ExecuteDataSet(sql).Tables(0)
                    If dt1.Rows.Count > 0 Then
                        c76.Text = "<font size=1.5> " & dt1.Rows(0)(0) & " </font>"
                        c77.Text = "<font size=1.5> ----- </font>"
                    Else
                        c76.Text = "<font size=1.5> ----- </font>"
                        c79.Text = "<font size=1.5> ----- </font>"
                        c77.Text = "<font size=1.5> ----- </font>"
                    End If
                End If
                c79.Text = "<font size=1.5> ----- </font>"
            End If

            c76.ColumnSpan = 1
            c76.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c76)
            tab.Controls.Add(row7)

            c77.ColumnSpan = 1
            c77.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c77)
            tab.Controls.Add(row7)

            c78.ColumnSpan = 1
            c78.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c78)
            tab.Controls.Add(row7)

            c79.ColumnSpan = 1
            c79.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c79)
            tab.Controls.Add(row7)

            c711.ColumnSpan = 1
            If CInt(dr(4)) = 2 Then
                c711.Text = "<font size=1.5>" & dr(5) & "</font>"
            Else
                c711.Text = "<font size=1.5>-------</font>"
            End If

            c711.HorizontalAlign = HorizontalAlign.Left
            row7.Controls.Add(c711)
            tab.Controls.Add(row7)
        Next


        Panel1.Controls.Add(tab)
    End Sub
End Class

    

Imports System.data
Imports System.Data.OracleClient
Partial Class PROMOTION_prom_rev_report_f6cc97c59897
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Dim sql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim emp_code, totsal As Integer
        emp_code = Request.QueryString("from_date")
        Dim frID = Session("firm_ID").ToString
        '------------------------------------------------------------------------------------------
        Dim dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7 As New DataTable
        Dim saldiff As New Integer

        Dim tb As New Table
        tb.Attributes.Add("width", "90%")
        tb.Attributes.Add("align", "center")
        tb.Attributes.Add("border", "1")
        'header---------------------------------------------------------------------------------
        sql = "select a.firm_name from firm_master a,employ_firm b where a.firm_id=b.firm_id and b.emp_code=" & emp_code
        dt = oh.ExecuteDataSet(sql).Tables(0)

        sql = "select emp_name from employee_master where emp_code=" & emp_code
        dt1 = oh.ExecuteDataSet(sql).Tables(0)


        Dim tr As New TableRow
        Dim tc As New TableCell
        tc.Attributes.Add("width", "100%")
        tc.ColumnSpan = 10
        tc.HorizontalAlign = HorizontalAlign.Center
        tc.Text = "<font size=4 color=darkblue><b>" & dt.Rows(0)(0) & "</b></font>"   'firm_name
        tr.Controls.Add(tc)
        tb.Controls.Add(tr)

        Dim tr1 As New TableRow
        Dim tc1 As New TableCell
        tc1.Attributes.Add("width", "100%")
        tc1.ColumnSpan = 10
        tc1.HorizontalAlign = HorizontalAlign.Center
        tc1.Text = "<font size=3 color=darkblue>Regd.Office&nbsp;&nbsp;&nbsp;Manappuram&nbsp;House,&nbsp;&nbsp;&nbsp;V/104,&nbsp;&nbsp;&nbsp;Valappad-680576</font>"
        tr1.Controls.Add(tc1)
        tb.Controls.Add(tr1)

        Dim tr2 As New TableRow
        Dim tc2 As New TableCell
        tc2.Attributes.Add("width", "100%")
        tc2.ColumnSpan = 10
        tc2.HorizontalAlign = HorizontalAlign.Center
        tc2.Text = "<font size=2 color=darkblue>DEPARTMENT OF HUMAN RESOURCE MANAGEMENT</font>"
        tr2.Controls.Add(tc2)
        tb.Controls.Add(tr2)

        Dim tr3 As New TableRow
        Dim tc31 As New TableCell
        tc31.Attributes.Add("width", "50%")
        tc31.ColumnSpan = 5
        tc31.HorizontalAlign = HorizontalAlign.Left
        tc31.Text = "<font size=3 color=darkblue>Time&nbsp:" & Format(Date.Now, "hh:mm:ss") & "</font>"
        tr3.Controls.Add(tc31)

        Dim tc32 As New TableCell
        tc32.Attributes.Add("width", "50%")
        tc32.ColumnSpan = 5
        tc32.HorizontalAlign = HorizontalAlign.Right
        tc32.Text = "<font size=3 color=darkblue>Date&nbsp:" & Format(Date.Now, "dd/MMM/yyyy") & "</font>"
        tr3.Controls.Add(tc32)
        tb.Controls.Add(tr3)

        Dim tr4 As New TableRow
        Dim tc4 As New TableCell
        tc4.Attributes.Add("width", "100%")
        tc4.ColumnSpan = 10
        tc4.HorizontalAlign = HorizontalAlign.Center
        tc4.Text = "<font size=3 color=darkblue><b>PROMOTION&nbsp;&nbsp;/&nbsp;REVERITNG&nbsp;DETAILS</b></font>"
        tr4.Controls.Add(tc4)
        tb.Controls.Add(tr4)


        Dim tr5a As New TableRow
        Dim td5a As New TableCell
        td5a.ColumnSpan = 12
        td5a.HorizontalAlign = HorizontalAlign.Center
        td5a.Text = "<hr>"
        tr5a.Controls.Add(td5a)
        tb.Controls.Add(tr5a)


        Dim tr5 As New TableRow
        Dim tc51 As New TableCell
        tc51.Attributes.Add("width", "50%")
        tc51.Attributes.Add("align", "center")
        tc51.ColumnSpan = 3
        tc51.HorizontalAlign = HorizontalAlign.Left
        tc51.Text = "" + "<font size=3 color=darkblue>Employee&nbsp;Name&nbsp;&nbsp;</font>"
        tr5.Controls.Add(tc51)


        Dim tc52a As New TableCell
        tc52a.Attributes.Add("width", "50%")
        tc52a.Attributes.Add("align", "center")
        tc52a.ColumnSpan = 1.5
        tc52a.HorizontalAlign = HorizontalAlign.Center
        tc52a.Text = "<font size=3 color=darkblue>-</font>"
        tr5.Controls.Add(tc52a)

        Dim tc52 As New TableCell
        tc52.Attributes.Add("width", "50%")
        tc52.Attributes.Add("align", "center")
        tc52.ColumnSpan = 5
        tc52.HorizontalAlign = HorizontalAlign.Left
        tc52.Text = "<font size=3 color=darkblue>" & dt1.Rows(0)(0) & "</font>"
        tr5.Controls.Add(tc52)
        tb.Controls.Add(tr5)

        Dim tr6 As New TableRow
        Dim tc61 As New TableCell
        tc61.Attributes.Add("width", "50%")
        tc61.Attributes.Add("align", "center")
        tc61.ColumnSpan = 3
        tc61.HorizontalAlign = HorizontalAlign.Left
        tc61.Text = "" + "<font size=3 color=darkblue>Employee&nbsp;Code&nbsp;&nbsp;</font>"
        tr6.Controls.Add(tc61)


        Dim tc62a As New TableCell
        tc62a.Attributes.Add("width", "50%")
        tc62a.Attributes.Add("align", "center")
        tc62a.ColumnSpan = 1.5
        tc62a.HorizontalAlign = HorizontalAlign.Center
        tc62a.Text = "<font size=3 color=darkblue>-</font>"
        tr6.Controls.Add(tc62a)


        Dim tc62 As New TableCell
        tc62.Attributes.Add("width", "50%")
        tc62.Attributes.Add("align", "center")
        tc62.ColumnSpan = 5
        tc62.HorizontalAlign = HorizontalAlign.Left
        tc62.Text = "<font size=3 color=darkblue>" & emp_code & "</font>"
        tr6.Controls.Add(tc62)
        tb.Controls.Add(tr6)

        'header------------------------------------------------------------------------------------------------
        sql = "select a.from_dt,a.basic_pay ,b.designation,a.da_flag,a.approve_remarks from employ_promotion_dtl a ,designation_master b where a.to_dt is null and a.from_dt in (select max(from_dt) from employ_promotion_dtl where status_id in (1,7,8,11) and emp_code=" & emp_code & ") and a.designation_id=b.designation_id and a.status_id in (1,7,8,11) and a.emp_code=" & emp_code
        dt2 = oh.ExecuteDataSet(sql).Tables(0)
        If dt2.Rows.Count > 0 Then
            sql = "select a.basic_pay ,b.designation from employ_promotion_dtl a,designation_master b where a.to_dt in (select max(to_dt) from employ_promotion_dtl where status_id in (1,7,8,11) and emp_code=" & emp_code & ") and a.designation_id=b.designation_id and a.status_id in (1,7,8,11) and a.emp_code=" & emp_code
            dt3 = oh.ExecuteDataSet(sql).Tables(0)

            If dt3.Rows.Count > 0 Then

                Dim tr7 As New TableRow
                Dim tc71 As New TableCell
                tc71.Attributes.Add("width", "50%")
                tc71.Attributes.Add("align", "center")
                tc71.ColumnSpan = 3
                tc71.HorizontalAlign = HorizontalAlign.Left
                tc71.Text = "" + "<font size=3 color=darkblue>Designation&nbsp;Before&nbsp;&nbsp;</font>"
                tr7.Controls.Add(tc71)

                Dim tc71d As New TableCell
                tc71d.Attributes.Add("width", "50%")
                tc71d.Attributes.Add("align", "center")
                tc71d.ColumnSpan = 1.5
                tc71d.HorizontalAlign = HorizontalAlign.Center
                tc71d.Text = "<font size=3 color=darkblue>-</font>"
                tr7.Controls.Add(tc71d)


                Dim tc71a As New TableCell
                tc71a.Attributes.Add("width", "50%")
                tc71a.Attributes.Add("align", "center")
                tc71a.ColumnSpan = 5
                tc71a.HorizontalAlign = HorizontalAlign.Left
                tc71a.Text = "<font size=3 color=darkblue>" & dt3.Rows(0)(1) & "</font>"
                tr7.Controls.Add(tc71a)
                tb.Controls.Add(tr7)

                Dim tr8 As New TableRow
                Dim tc81 As New TableCell
                tc81.Attributes.Add("width", "50%")
                tc81.Attributes.Add("align", "center")
                tc81.ColumnSpan = 3
                tc81.HorizontalAlign = HorizontalAlign.Left
                tc81.Text = "" + "<font size=3 color=darkblue>Designation&nbsp;After&nbsp;&nbsp;</font>"
                tr8.Controls.Add(tc81)

                Dim tc81d As New TableCell
                tc81d.Attributes.Add("width", "50%")
                tc81d.Attributes.Add("align", "center")
                tc81d.ColumnSpan = 1.5
                tc81d.HorizontalAlign = HorizontalAlign.Center
                tc81d.Text = "<font size=3 color=darkblue>-</font>"
                tr8.Controls.Add(tc81d)


                Dim tc81a As New TableCell
                tc81a.Attributes.Add("width", "50%")
                tc81a.Attributes.Add("align", "center")
                tc81a.ColumnSpan = 5
                tc81a.HorizontalAlign = HorizontalAlign.Left
                tc81a.Text = "<font size=3 color=darkblue>" & dt2.Rows(0)(2) & "&nbsp;</font >"
                tr8.Controls.Add(tc81a)
                tb.Controls.Add(tr8)

                Dim tr9 As New TableRow
                Dim tc91 As New TableCell
                tc91.Attributes.Add("width", "50%")
                tc91.Attributes.Add("align", "center")
                tc91.ColumnSpan = 3
                tc91.HorizontalAlign = HorizontalAlign.Left
                tc91.Text = "" + "<font size=3 color=darkblue>Basicpay&nbsp;Before&nbsp;&nbsp;</font>"
                tr9.Controls.Add(tc91)

                Dim tc91d As New TableCell
                tc91d.Attributes.Add("width", "50%")
                tc91d.Attributes.Add("align", "center")
                tc91d.ColumnSpan = 1.5
                tc91d.HorizontalAlign = HorizontalAlign.Center
                tc91d.Text = "<font size=3 color=darkblue>-</font>"
                tr9.Controls.Add(tc91d)


                Dim tc91a As New TableCell
                tc91a.Attributes.Add("width", "50%")
                tc91a.Attributes.Add("align", "center")
                tc91a.ColumnSpan = 5
                tc91a.HorizontalAlign = HorizontalAlign.Left
                tc91a.Text = "<font size=3 color=darkblue>" & dt3.Rows(0)(0) & "</font>"
                tr9.Controls.Add(tc91a)
                tb.Controls.Add(tr9)

                Dim tr10 As New TableRow
                Dim tc101 As New TableCell
                tc101.Attributes.Add("width", "50%")
                tc101.Attributes.Add("align", "center")
                tc101.ColumnSpan = 3
                tc101.HorizontalAlign = HorizontalAlign.Left
                tc101.Text = "" + "<font size=3 color=darkblue>Basicpay&nbsp;After&nbsp;&nbsp;</font>"
                tr10.Controls.Add(tc101)

                Dim tc101d As New TableCell
                tc101d.Attributes.Add("width", "50%")
                tc101d.Attributes.Add("align", "center")
                tc101d.ColumnSpan = 1.5
                tc101d.HorizontalAlign = HorizontalAlign.Center
                tc101d.Text = "<font size=3 color=darkblue>-</font>"
                tr10.Controls.Add(tc101d)


                Dim tc101a As New TableCell
                tc101a.Attributes.Add("width", "50%")
                tc101a.Attributes.Add("align", "center")
                tc101a.ColumnSpan = 5
                tc101a.HorizontalAlign = HorizontalAlign.Left
                tc101a.Text = "<font size=3 color=darkblue>" & dt2.Rows(0)(1) & "</font>"
                tr10.Controls.Add(tc101a)
                tb.Controls.Add(tr10)


                'If (dt2.Rows(0)(1) >= dt3.Rows(0)(0)) Then
                '    saldiff = dt2.Rows(0)(1) - dt3.Rows(0)(0)
                'Else
                '    saldiff = dt2.Rows(0)(1) - dt3.Rows(0)(0)
                'End If

                If dt3.Rows.Count = 0 Then
                    saldiff = dt2.Rows(0)(1)
                Else
                    saldiff = dt2.Rows(0)(1) - dt3.Rows(0)(0)
                End If


                Dim tr11 As New TableRow
                Dim tc111 As New TableCell
                tc111.Attributes.Add("width", "50%")
                tc111.Attributes.Add("align", "center")
                tc111.ColumnSpan = 3
                tc111.HorizontalAlign = HorizontalAlign.Left
                tc111.Text = "" + "<font size=3 color=darkblue>Salary&nbsp;Difference&nbsp;&nbsp;</font>"
                tr11.Controls.Add(tc111)


                Dim tc111d As New TableCell
                tc111d.Attributes.Add("width", "50%")
                tc111d.Attributes.Add("align", "center")
                tc111d.ColumnSpan = 1.5
                tc111d.HorizontalAlign = HorizontalAlign.Center
                tc111d.Text = "<font size=3 color=darkblue>-</font>"
                tr11.Controls.Add(tc111d)


                Dim tc111a As New TableCell
                tc111a.Attributes.Add("width", "50%")
                tc111a.Attributes.Add("align", "center")
                tc111a.ColumnSpan = 5
                tc111a.HorizontalAlign = HorizontalAlign.Left
                If saldiff < 0 Then
                    saldiff = Math.Abs(saldiff)
                    tc111a.Text = "<font size=3 color=darkblue>" & saldiff & "(DECRI) </font>"
                Else
                    saldiff = saldiff
                    tc111a.Text = "<font size=3 color=darkblue>" & saldiff & "(INCRI)</font>"
                End If
                tr11.Controls.Add(tc111a)
                tb.Controls.Add(tr11)


                Dim tr12 As New TableRow
                Dim tc112 As New TableCell
                tc112.Attributes.Add("width", "50%")
                tc112.Attributes.Add("align", "center")
                tc112.ColumnSpan = 3
                tc112.HorizontalAlign = HorizontalAlign.Left
                tc112.Text = "" + "<font size=3 color=darkblue>Total&nbsp;Salary&nbsp;&nbsp;</font>"
                tr12.Controls.Add(tc112)


                Dim tc112d As New TableCell
                tc112d.Attributes.Add("width", "50%")
                tc112d.Attributes.Add("align", "center")
                tc112d.ColumnSpan = 1.5
                tc112d.HorizontalAlign = HorizontalAlign.Center
                tc112d.Text = "<font size=3 color=darkblue>-</font>"
                tr12.Controls.Add(tc112d)


                Dim tr13 As New TableRow
                Dim tc113 As New TableCell
                tc113.Attributes.Add("width", "50%")
                tc113.Attributes.Add("align", "center")
                tc113.ColumnSpan = 3
                tc113.HorizontalAlign = HorizontalAlign.Left
                tc113.Text = "" + "<font size=3 color=darkblue>Remarks&nbsp;&nbsp;</font>"
                tr13.Controls.Add(tc113)


                Dim tc131d As New TableCell
                tc131d.Attributes.Add("width", "50%")
                tc131d.Attributes.Add("align", "center")
                tc131d.ColumnSpan = 1.5
                tc131d.HorizontalAlign = HorizontalAlign.Center
                tc101d.Text = "<font size=3 color=darkblue>-</font>"
                tr13.Controls.Add(tc101d)


                Dim tc131a As New TableCell
                tc131a.Attributes.Add("width", "50%")
                tc131a.Attributes.Add("align", "center")
                tc131a.ColumnSpan = 5
                tc131a.HorizontalAlign = HorizontalAlign.Left
                tc131a.Text = "<font size=3 color=darkblue>" & dt2.Rows(0)(4) & "</font>"
                tr13.Controls.Add(tc131a)
                tb.Controls.Add(tr13)


                sql = "select value,from_dt,to_dt from da_index where to_dt is null and firm_id=" & frID & " "
                dt5 = oh.ExecuteDataSet(sql).Tables(0)
                If dt2.Rows(0)(3) = "TRUE" Then
                    totsal = dt2.Rows(0)(1) + dt5.Rows(0)(0)
                Else
                    totsal = dt2.Rows(0)(1)
                End If


                Dim tc112a As New TableCell
                tc112a.Attributes.Add("width", "50%")
                tc112a.Attributes.Add("align", "center")
                tc112a.ColumnSpan = 5
                tc112a.HorizontalAlign = HorizontalAlign.Left
                tc112a.Text = "<font size=3 color=darkblue>" & totsal & "</font>"
                tr12.Controls.Add(tc112a)
                tb.Controls.Add(tr12)



            End If
        End If
        Me.Panel1.Controls.Add(tb)
    End Sub


End Class

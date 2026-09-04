Imports System.Data
Imports System.Data.OracleClient
Partial Class incentive_allowance_rpt_incentive_allowance_dtl_all_78212b187532
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql As String = ""
        If Me.Request.QueryString("allid") = 9999 Then
            sql = "select al.emp_code,em.emp_name,am.all_name,al.all_amount,al.enter_date,case when al.branch_id is null then ' ' else case when al.branch_id in(select branch_id from branch_master ) then (select branch_name from branch_master br where al.branch_id=br.branch_id) else case when al.branch_id in(select branch_id from before_completion ) then (select branch_name from before_completion bc where bc.old_id=al.branch_id and bc.old_id<>0) end end end as branchname from incentives_allowances_dtl al,employee_master em,incentives_allowances_master am where al.emp_code=em.emp_code and al.all_id=am.all_id order by al.emp_code"
        Else
            sql = "select al.emp_code,em.emp_name,am.all_name,al.all_amount,al.enter_date,case when al.branch_id is null then ' ' else case when al.branch_id in(select branch_id from branch_master ) then (select branch_name from branch_master br where al.branch_id=br.branch_id) else case when al.branch_id in(select branch_id from before_completion ) then (select branch_name from before_completion bc where bc.old_id=al.branch_id and bc.old_id<>0) end end end as branchname from incentives_allowances_dtl al,employee_master em,incentives_allowances_master am where al.emp_code=em.emp_code and al.all_id=am.all_id and al.all_id=" & Me.Request.QueryString("allid") & " order by al.emp_code"
        End If


        Dim dt As DataTable = oh.ExecuteDataSet(sql).Tables(0)
        Dim tab As New Table
        tab.Attributes.Add("width", "100%")
        Dim tabr1 As New TableRow
        tabr1.Width = 10
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.BorderStyle = BorderStyle.Solid
        tabr1.BorderColor = Drawing.Color.Red
        Dim tabc1 As New TableCell
        tabc1.ColumnSpan = 10
        tabc1.Text = "<body align=center color=red><b><font size=4> " & Session("firm_name") & "</font></b></body>"
        tabc1.ForeColor = Drawing.Color.Red
        tabc1.Attributes.Add("align", "center")
        tabr1.Controls.Add(tabc1)
        tab.Controls.Add(tabr1)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabr2 As New TableRow
        'tabr2.Attributes.Add("bgcolor", "bisque")
        tabr2.ForeColor = Drawing.Color.Maroon
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 10
        tabc2.HorizontalAlign = HorizontalAlign.Center
        tabc2.ForeColor = Drawing.Color.Brown
        Dim s As String = oh.ExecuteDataSet("select distinct to_char(to_date(max(pr_date)),'MONTH') from incentives_allowances_dtl").Tables(0).Rows(0)(0)

        tabc2.Text = "<body align=center color=red><b><font size=3.5> INCENTIVE ALLOWANCE DETAILS -" & s & " " & Now.Year & " </font></b></body>"
        tabr2.Controls.Add(tabc2)
        tab.Controls.Add(tabr2)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabr3 As New TableRow
        tabr3.Width = 10
        tabr3.Attributes.Add("bgcolor", "#ffcca3")
        Dim tabc3 As New TableCell
        tabc3.ColumnSpan = 5
        tabc3.HorizontalAlign = HorizontalAlign.Left
        tabc3.ForeColor = Drawing.Color.Maroon
        tabc3.Text = "<b><font size=3.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabr3.Controls.Add(tabc3)
        tab.Controls.Add(tabr3)

        Dim tabc4 As New TableCell
        tabc4.Attributes.Add("width", "50%")
        tabc4.HorizontalAlign = HorizontalAlign.Right
        tabc4.ColumnSpan = 5
        tabc4.ForeColor = Drawing.Color.Maroon
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

        tabc4.Text = "<b><font size=3.5>TIME: " & hr.ToString & ":" & Date.Now.Minute & ":" & Date.Now.Second & " " & dat & "</font></b>"
        tabr3.Controls.Add(tabc4)
        tab.Controls.Add(tabr3)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabline As New TableRow
        tabline.Width = 10
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 10
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab.Controls.Add(tabline)
        Dim count As Integer = 0
        Dim tot As Integer = 0
        Try
            Dim h1 As New TableRow
            h1.Width = 10
            Dim h11, h12, h13, h14, h15, h16, h17 As New TableCell
            h11.ColumnSpan = 1
            h12.ColumnSpan = 1
            h13.ColumnSpan = 2
            h14.ColumnSpan = 2
            h15.ColumnSpan = 1
            h16.ColumnSpan = 1
            h16.ColumnSpan = 2

            h11.Text = "<font size=2><b>SI.NO&nbsp;&nbsp;&nbsp;&nbsp;</b></font>"
            h12.Text = "<font size=2><b>EMP CODE&nbsp;&nbsp;&nbsp;&nbsp;</b></font>"
            h13.Text = "<font size=2><b>EMP NAME&nbsp;&nbsp;&nbsp;&nbsp;</b></font>"
            h14.Text = "<font size=2><b>ALLOWANCE NAME&nbsp;&nbsp;&nbsp;&nbsp;</b></font>"
            h15.Text = "<font size=2><b>AMOUNT&nbsp;&nbsp;&nbsp;&nbsp;</b></font>"
            h16.Text = "<font size=2><b>ENTER_DT&nbsp;&nbsp;&nbsp;&nbsp;</b></font>"
            h17.Text = "<font size=2><b>BRANCH NAME</b></font>"
            h11.HorizontalAlign = HorizontalAlign.Left
            h12.HorizontalAlign = HorizontalAlign.Center
            h13.HorizontalAlign = HorizontalAlign.Center
            h14.HorizontalAlign = HorizontalAlign.Left
            h15.HorizontalAlign = HorizontalAlign.Right
            h16.HorizontalAlign = HorizontalAlign.Center
            h16.HorizontalAlign = HorizontalAlign.Center

            h1.Controls.Add(h11)
            h1.Controls.Add(h12)
            h1.Controls.Add(h13)
            h1.Controls.Add(h14)
            h1.Controls.Add(h15)
            h1.Controls.Add(h16)
            h1.Controls.Add(h17)
            tab.Controls.Add(h1)

            Dim tablinefb As New TableRow
            tablinefb.Width = 10
            Dim tabcelllinefb As New TableCell
            tabcelllinefb.ColumnSpan = 10
            tabcelllinefb.Text = "<hr>"
            tablinefb.Controls.Add(tabcelllinefb)
            tab.Controls.Add(tablinefb)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow
                For Each dr In dt.Rows
                    count += 1
                    Dim t1 As New TableRow
                    t1.Width = 10
                    Dim t11, t12, t13, t14, t15, t16, T17 As New TableCell
                    t11.HorizontalAlign = HorizontalAlign.Center
                    t12.HorizontalAlign = HorizontalAlign.Left
                    t13.HorizontalAlign = HorizontalAlign.Left
                    t14.HorizontalAlign = HorizontalAlign.Left
                    t15.HorizontalAlign = HorizontalAlign.Right
                    t16.HorizontalAlign = HorizontalAlign.Left
                    T17.HorizontalAlign = HorizontalAlign.Left

                    t11.ColumnSpan = 1
                    t12.ColumnSpan = 1
                    t13.ColumnSpan = 2
                    t14.ColumnSpan = 2
                    t15.ColumnSpan = 1
                    t16.ColumnSpan = 1
                    T17.ColumnSpan = 2
                    t11.Text = "<font size=2>" & count & "</font>"
                    t12.Text = "<font size=2>&nbsp;&nbsp;&nbsp;&nbsp;" & dr(0) & "</font>"
                    t13.Text = "<font size=2>&nbsp;&nbsp;&nbsp;&nbsp;" & dr(1) & "&nbsp;&nbsp;&nbsp;&nbsp;</font>"
                    t14.Text = "<font size=2>" & dr(2) & "</font>"
                    If IsDBNull(dr(3)) Then
                        t15.Text = ""
                    Else
                        t15.Text = "<font size=2>" & FormatNumber(dr(3), 2) & "</font>"
                        tot += dr(3)
                    End If
                    t16.Text = "<font size=2>&nbsp;&nbsp;&nbsp;&nbsp;" & Format(dr(4), "dd/MMM/yyyy") & "</font>"
                    T17.Text = "<font size=2>&nbsp;&nbsp;&nbsp;&nbsp;" & dr(5) & "</font>"

                    t1.Controls.Add(t11)
                    t1.Controls.Add(t12)
                    t1.Controls.Add(t13)
                    t1.Controls.Add(t14)
                    t1.Controls.Add(t15)
                    t1.Controls.Add(t16)
                    t1.Controls.Add(T17)
                    tab.Controls.Add(t1)
                Next
                Dim tablinef As New TableRow
                tablinef.Width = 10
                Dim tabcelllinef As New TableCell
                tabcelllinef.ColumnSpan = 10
                tabcelllinef.Text = "<hr>"
                tablinef.Controls.Add(tabcelllinef)
                tab.Controls.Add(tablinef)

                Dim tabr51 As New TableRow
                tabr51.Attributes.Add("bgcolor", "#fffcff")
                Dim tabr5c11, tabr5c21 As New TableCell
                tabr5c11.Attributes.Add("align", "left")
                tabr5c21.Attributes.Add("align", "left")
                tabr5c11.ColumnSpan = 5
                tabr5c21.ColumnSpan = 5
                tabr5c11.Text = "<FONT SIZE=2><b>TOTAL  -</b></FONT>"
                tabr5c21.Text = "<FONT SIZE=2><b> " & FormatNumber(tot, 2) & "</b></FONT>"
                tabr51.Controls.Add(tabr5c11)
                tabr51.Controls.Add(tabr5c21)
                tab.Controls.Add(tabr51)
            Else
                Dim t1 As New TableRow
                t1.Width = 10
                Dim t11 As New TableCell
                t11.ColumnSpan = 10
                t11.Text = "No Details Found "
                t1.Controls.Add(t11)
                tab.Controls.Add(t1)
            End If
        Catch ex As Exception
            dt.Dispose()
            oh.dispose()
        End Try
        Me.Panel1.Controls.Add(tab)
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        oh.dispose()
    End Sub
End Class

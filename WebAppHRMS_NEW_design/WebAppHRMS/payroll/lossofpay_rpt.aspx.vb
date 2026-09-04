Imports System.Data
Imports System.Data.OracleClient
Partial Class salary_report_lossofpay_rpt_7f324e3d8050
    Inherits System.Web.UI.Page

    Dim oh As New helper.oracle.oraclehelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_name from employee_master where emp_code=" & Request.QueryString("empid")).Tables(0)
        'Added on 09-03-2017 for RqstId - 12730
        Dim user() As String
        user = Session("user_id").ToString.Split("!")
        Dim dt1 As DataTable = oh.ExecuteDataSet("select emp_name from employee_master where emp_code=" & user(0) & "").Tables(0)

        Dim dt As DataTable
        'dt = oh.ExecuteDataSet("select s.leave_frdate,s.leave_todate,s.leave_days,s.leave_process_id as type,s.leave_apply_date,s.leave_enter_date,s.leave_reason from salary_leave s where s.emp_code=" & Request.QueryString("empid") & " order by s.leave_process_id,s.leave_frdate").Tables(0)
        dt = oh.ExecuteDataSet("select s.leave_frdate,s.leave_todate,s.leave_days,s.leave_process_id as type,s.leave_apply_date,s.leave_enter_date,s.leave_reason from salary_leave s where s.emp_code=" & user(0) & " order by s.leave_process_id,s.leave_frdate").Tables(0)
        If dt.Rows.Count = 0 Then
            Exit Sub
        End If
        'table declaration
        Dim tab1 As New Table
        tab1.Attributes.Add("width", "100%")
        '1st row declaration
        Dim tabr1 As New TableRow
        tabr1.Width = 7
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "Maroon")
        'cell declaration
        Dim tabc1 As New TableCell
        'tabc1.Attributes.Add("forecolor", "Maroon")
        tabc1.ForeColor = Drawing.Color.Maroon
        tabc1.Attributes.Add("align", "center")
        tabc1.ColumnSpan = "7"
        tabc1.Text = "<body align=center ><b><font size=4> " & Session("firm_name") & "</font></b></body>"
        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Attributes.Add("bgcolor", "bisque")
        tabr2.Width = 7
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 7
        tabc2.Attributes.Add("align", "center")
        '  Dim s As String = oh.ExecuteDataSet("select month_name from month where month_id=" & Now.Month - 1).Tables(0).Rows(0)(0)

        tabc2.Text = "<body align=center color=red><b><u><font size=4> LOP/ARREAR REPORT  </font></u></b></body>"
        tabc2.ForeColor = Drawing.Color.Maroon
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)
        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Width = 7
        tabrr3.Attributes.Add("bgcolor", "bisque")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.ColumnSpan = 3
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=2.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)
        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ColumnSpan = 4
        tabcc4.Attributes.Add("align", "right")
        tabcc4.Font.Bold = True
        tabcc4.Text = "<div id='txt'></div>"
        tabcc4.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        ''''''''''''''''''''''''''''''
        Dim tabrw2 As New TableRow
        '   tabrw2.Attributes.Add("bgcolor", "#ffcca3")
        tabrw2.Width = 7
        'cell declaration
        Dim tabcw2 As New TableCell
        tabcw2.ColumnSpan = 7
        tabcw2.Attributes.Add("align", "center")
        'Added on 09-03-2017 for RqstId - 12730
        ' tabcw2.Text = "<body align=center color=red><b><font size=2> EMP.CODE=" & Request.QueryString("empid") & " &nbsp;&nbsp;EMP.NAME=" & dt1.Rows(0)(0) & " </font></b></body>"
        tabcw2.Text = "<body align=center color=red><b><font size=2> EMP.CODE=" & user(0) & " &nbsp;&nbsp;EMP.NAME=" & dt1.Rows(0)(0) & " </font></b></body>"
        tabcw2.ForeColor = Drawing.Color.Maroon
        tabrw2.Controls.Add(tabcw2)
        tab1.Controls.Add(tabrw2)
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabline As New TableRow
        tabline.Width = 7
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 7
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)
        ''''''''''''''''''''''''''''''''''''''''
        Dim tabr5 As New TableRow
        tabr5.Width = 7
        ' tabr5.Attributes.Add("bgcolor", "#ffcca3")
        tabr5.ForeColor = Drawing.Color.Maroon
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6 As New TableCell

        tabr5c1.ColumnSpan = 1
        tabr5c2.ColumnSpan = 1
        tabr5c3.ColumnSpan = 1
        tabr5c4.ColumnSpan = 1
        tabr5c5.ColumnSpan = 1
        tabr5c6.ColumnSpan = 2
        tabr5c1.HorizontalAlign = HorizontalAlign.Left
        tabr5c2.HorizontalAlign = HorizontalAlign.Left
        tabr5c3.HorizontalAlign = HorizontalAlign.Left
        tabr5c4.HorizontalAlign = HorizontalAlign.Left
        tabr5c5.HorizontalAlign = HorizontalAlign.Left
        tabr5c6.HorizontalAlign = HorizontalAlign.Left

        tabr5c1.Text = "<b><font size=2.5>FROM DATE</font></b>"
        tabr5c2.Text = "<b><font size=2.5>TO DATE</font></b>"
        tabr5c3.Text = "<b><font size=2.5>LEAVE DAYS</font></b>"
        tabr5c4.Text = "<b><font size=2.5>APPLY DATE</font></b>"
        tabr5c5.Text = "<b><font size=2.5>ENTER DATE</font></b>"
        tabr5c6.Text = "<b><font size=2.5>REASON</font></b>"

        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        tabr5.Controls.Add(tabr5c6)
        tab1.Controls.Add(tabr5)
        '''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 7
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 7
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)

        Dim tablinelop As New TableRow
        tablinelop.Width = 7

        '''''''''''''''''''''''''''''''''
        Dim colors As String
        colors = "#fffcff"
        Dim dr As DataRow
        Dim lid As Integer = 0
        For Each dr In dt.Rows

            If lid <> dr(3) Then
                lid = dr(3)
                Dim tablinelop1 As New TableRow
                tablinelop1.Width = 7
                Dim tabcelllinelop As New TableCell
                tabcelllinelop.ColumnSpan = 7
                If lid = 1 Then
                    tabcelllinelop.Text = "<b><U>LOP</u><b>"
                Else
                    tabcelllinelop.Text = "<b><u>ARREAR</u><b>"
                End If
                tabcelllinelop.ForeColor = Drawing.Color.Maroon
                ' tabcelllinelop.BackColor = Drawing.Color.Wheat
                tablinelop1.Controls.Add(tabcelllinelop)
                tab1.Controls.Add(tablinelop1)
            End If
            If colors.Equals("#fffcff") = True Then
                colors = "#f8f8f8"
            Else
                colors = "#fffcff"
            End If
            Dim tabr6 As New TableRow
            tabr6.Width = 10
            tabr6.Attributes.Add("bgcolor", colors)
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6 As New TableCell

            tabr6c1.ColumnSpan = 1
            tabr6c2.ColumnSpan = 1
            tabr6c3.ColumnSpan = 1
            tabr6c4.ColumnSpan = 1
            tabr6c5.ColumnSpan = 1
            tabr6c6.ColumnSpan = 2

            tabr6c1.Attributes.Add("align", "left")
            tabr6c2.Attributes.Add("align", "left")
            tabr6c3.Attributes.Add("align", "left")
            tabr6c4.Attributes.Add("align", "left")
            tabr6c5.Attributes.Add("align", "left")
            tabr6c6.Attributes.Add("align", "left")

            tabr6c1.Text = Format(dr(0), "dd/MMM/yyyy")
            tabr6c2.Text = Format(dr(1), "dd/MMM/yyyy")
            tabr6c3.Text = dr(2)
            tabr6c4.Text = Format(dr(4), "dd/MMM/yyyy")
            tabr6c5.Text = Format(dr(5), "dd/MMM/yyyy")
            tabr6c6.Text = dr(6)

            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)
            tabr6.Controls.Add(tabr6c6)
            tab1.Controls.Add(tabr6)
        Next
        Me.Panel1.Controls.Add(tab1)

    End Sub
End Class

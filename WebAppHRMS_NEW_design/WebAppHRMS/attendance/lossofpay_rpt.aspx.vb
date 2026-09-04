Imports System.Data
Imports System.Data.OracleClient
Partial Class salary_report_lossofpay_rpt_6689eecd6965
    Inherits System.Web.UI.Page

    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable
        dt = oh.ExecuteDataSet("select s.ded_Date,s.amount,s.reason,e.emp_name from sal_ded S,employee_master e where e.emp_code=s.emp_code and s.emp_code=" & Request.QueryString("empid")).Tables(0)


        'table declaration
        Dim tab1 As New Table
        tab1.Attributes.Add("width", "100%")
        '1st row declaration
        Dim tabr1 As New TableRow
        tabr1.Width = 10
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        'cell declaration
        Dim tabc1 As New TableCell
        tabc1.Attributes.Add("forecolor", "blue")
        tabc1.Attributes.Add("align", "center")
        tabc1.ColumnSpan = "10"
        tabc1.Text = "<body align=center ><b><font size=4> " & Session("firm_name") & "</font></b></body>"
        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Attributes.Add("bgcolor", "bisque")
        tabr2.Width = 10
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 10
        tabc2.Attributes.Add("align", "center")
        Dim s As String = oh.ExecuteDataSet("select month_name from month where month_id=" & Now.Month - 1).Tables(0).Rows(0)(0)

        tabc2.Text = "<body align=center color=red><b><font size=3.5> DETAILED SALARY(OTHER DEDUCTIONS) STATEMENT -" & s & " " & Now.Year & " </font></b></body>"
        tabc2.ForeColor = Drawing.Color.Maroon
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)
        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Width = 10
        tabrr3.Attributes.Add("bgcolor", "bisque")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.ColumnSpan = 5
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=3.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc3)
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

        tabcc4.Text = "<b><font size=3.5>TIME: " & hr.ToString & ":" & Date.Now.Minute & ":" & Date.Now.Second & " " & dat & "</font></b>"
        tabcc4.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        ''''''''''''''''''''''''''''''
        Dim tabrw2 As New TableRow
        tabrw2.Attributes.Add("bgcolor", "#ffcca3")
        tabrw2.Width = 10
        'cell declaration
        Dim tabcw2 As New TableCell
        tabcw2.ColumnSpan = 10
        tabcw2.Attributes.Add("align", "center")
        tabcw2.Text = "<body align=center color=red><b><font size=3> EMP.CODE=" & Request.QueryString("empid") & " &nbsp;&nbsp;EMP.NAME=" & dt.Rows(0)(3) & " </font></b></body>"
        tabcw2.ForeColor = Drawing.Color.Maroon
        tabrw2.Controls.Add(tabcw2)
        tab1.Controls.Add(tabrw2)
        ''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabline As New TableRow
        tabline.Width = 20
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 20
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)
        ''''''''''''''''''''''''''''''''''''''''
        Dim tabr5 As New TableRow
        tabr5.Width = 10
        ' tabr5.Attributes.Add("bgcolor", "#ffcca3")
        tabr5.ForeColor = Drawing.Color.DarkRed
        Dim tabr5c1, tabr5c2, tabr5c3 As New TableCell

        tabr5c1.ColumnSpan = "2"
        tabr5c2.ColumnSpan = "4"
        tabr5c3.ColumnSpan = "4"

        tabr5c1.Text = "<b><font size=2.5>DATE</font></b>"
        tabr5c2.Text = "<b><font size=2.5>AMOUNT</font></b>"
        tabr5c3.Text = "<b><font size=2.5>REASON</font></b>"

        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tab1.Controls.Add(tabr5)
        '''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 20
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 20
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)
        '''''''''''''''''''''''''''''''''
        Dim colors As String
        colors = "#fffcff"
        Dim dr As DataRow
        Dim i As Integer = 0
        For Each dr In dt.Rows
            i = i + 1
            If colors.Equals("#fffcff") = True Then
                colors = "#f8f8f8"
            Else
                colors = "#fffcff"
            End If
            Dim tabr6 As New TableRow
            tabr6.Width = 10
            tabr6.Attributes.Add("bgcolor", colors)
            Dim tabr6c1, tabr6c2, tabr6c3 As New TableCell

            tabr6c1.ColumnSpan = "2"
            tabr6c2.ColumnSpan = "4"
            tabr6c3.ColumnSpan = "4"

            tabr6c1.Attributes.Add("align", "left")
            tabr6c2.Attributes.Add("align", "right")
            tabr6c3.Attributes.Add("align", "left")
            If IsDBNull(dr(0)) Then
                tabr6c1.Text = ""
            Else
                tabr6c1.Text = Format(dr(0), "dd/MMM/yyyy") & "<&nbsp;>"
            End If

            tabr6c2.Text = " &nbsp;&nbsp;&nbsp;&nbsp;" & DBNull(dr(1))
            tabr6c3.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & dr(2)

            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tab1.Controls.Add(tabr6)
        Next
        Me.Panel1.Controls.Add(tab1)

    End Sub
    Private Function dbnull(ByVal a) As String
        Dim a1 As Double

        If IsDBNull(a) Then
            Return 0
        Else
            a1 = FormatNumber(a, 2)
            Return FormatNumber(a, 2)
        End If
    End Function

End Class

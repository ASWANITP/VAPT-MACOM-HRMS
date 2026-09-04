Imports System.Data
Imports System.Data.OracleClient
Partial Class employee_report_rep_emprep_6000ff275247
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable = oh.ExecuteDataSet(Request.QueryString("sql")).Tables(0)
        'table declaration
        Dim tab1 As New Table
        tab1.Attributes.Add("width", "100%")
        '1st row declaration
        Dim tabr1 As New TableRow
        tabr1.Width = 12
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        'cell declaration
        Dim tabc1 As New TableCell
        tabc1.Attributes.Add("forecolor", "blue")
        tabc1.Attributes.Add("align", "center")
        tabc1.ColumnSpan = "12"
        ' tabc1.Text = "<body align=center ><b><font size=4>MANAPPURAM GROUP OF COMPANIES</font></b></body>"
        tabc1.Text = "<body align=center ><b><font size=4>" & Session("firm_name") & "</font></b></body>"

        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 12
        'cell declaration
        Dim tabc2 As New TableCell
        tabc2.ColumnSpan = 12
        tabc2.Attributes.Add("align", "center")
        tabc2.Text = "<body align=center color=red><b><font size=3.5> EMPLOYEE REPORT </font></b></body>"

        tabc2.ForeColor = Drawing.Color.Maroon
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)
        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.ColumnSpan = 6
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=3.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)
        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ColumnSpan = 6
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

        ''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim tabline As New TableRow
        tabline.Width = 12
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 12
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)
        ''''''''''''''''''''''''''''''''''''''''
        Dim tabr5 As New TableRow
        tabr5.Width = 12
        tabr5.ForeColor = Drawing.Color.DarkRed
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7 As New TableCell

        tabr5c1.ColumnSpan = "3"
        tabr5c2.ColumnSpan = "2"
        tabr5c3.ColumnSpan = "2"
        tabr5c4.ColumnSpan = "2"
        tabr5c5.ColumnSpan = "1"
        tabr5c6.ColumnSpan = "1"
        tabr5c7.ColumnSpan = "1"
        tabr5c1.HorizontalAlign = HorizontalAlign.Left
        tabr5c2.HorizontalAlign = HorizontalAlign.Left
        tabr5c5.HorizontalAlign = HorizontalAlign.Left
        tabr5c6.HorizontalAlign = HorizontalAlign.Left
        tabr5c3.HorizontalAlign = HorizontalAlign.Left
        tabr5c4.HorizontalAlign = HorizontalAlign.Left
        tabr5c7.HorizontalAlign = HorizontalAlign.Left
        tabr5c1.Text = "<b><font size=2.5>EMP NAME&nbsp;&nbsp;</font></b>"
        tabr5c2.Text = "<b><font size=2.5>BRANCH&nbsp;&nbsp;</font></b>"
        tabr5c3.Text = "<b><font size=2.5>QUALIFICATION&nbsp;&nbsp;</font></b>"
        tabr5c4.Text = "<b><font size=2.5>POST&nbsp;&nbsp;</font></b>"
        tabr5c5.Text = "<b><font size=2.5>GENDER&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        tabr5c6.Text = "<b><font size=2.5>AGE&nbsp;&nbsp;&nbsp;&nbsp;</font></b>"
        tabr5c7.Text = "<b><font size=2.5>JOIN DT</font></b>"

        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        tabr5.Controls.Add(tabr5c6)
        tabr5.Controls.Add(tabr5c7)


        tab1.Controls.Add(tabr5)

        '''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 12
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 12
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)
        '''''''''''''''''''''''''''''''''
        Dim colors As String
        colors = "#fff7ff"
        Dim dr As DataRow
        Dim tot As Integer = 0
        Dim totmale As Integer = 0
        Dim totfemale As Integer = 0

        Dim i As Integer = 0
        For Each dr In dt.Rows
            tot += 1
            i = i + 1
            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If
            Dim tabr6 As New TableRow
            tabr6.Width = 12
            tabr6.Attributes.Add("bgcolor", colors)
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7 As New TableCell

            tabr6c1.ColumnSpan = "3"
            tabr6c2.ColumnSpan = "2"
            tabr6c3.ColumnSpan = "2"
            tabr6c4.ColumnSpan = "2"
            tabr6c5.ColumnSpan = "1"
            tabr6c6.ColumnSpan = "1"
            tabr6c7.ColumnSpan = "1"

            tabr6c1.Attributes.Add("align", "left")
            tabr6c2.Attributes.Add("align", "left")
            tabr6c3.Attributes.Add("align", "left")
            tabr6c4.Attributes.Add("align", "left")
            tabr6c5.Attributes.Add("align", "left")
            tabr6c6.Attributes.Add("align", "left")
            tabr6c7.Attributes.Add("align", "left")

            tabr6c1.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;</font>"
            tabr6c2.Text = "<font size=2>" & dr(1) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c3.Text = "<font size=2>" & dr(2) & "&nbsp;&nbsp;&nbsp;</font>"
            tabr6c4.Text = "<font size=2>" & dr(3) & "&nbsp;&nbsp;&nbsp;</font>"
            If dr(4) = 0 Then
                tabr6c5.Text = "<font size=2>FEMALE &nbsp;&nbsp;&nbsp;</font>"
                totfemale += 1
            Else
                tabr6c5.Text = "<font size=2>MALE &nbsp;&nbsp;&nbsp;</font>"
                totmale += 1
            End If
            tabr6c6.Text = "<font size=2>" & dr(5) & "&nbsp;&nbsp;&nbsp;</font>"

            tabr6c7.Text = "<font size=2>" & dr(6) & "&nbsp;&nbsp;&nbsp;</font>"


            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)
            tabr6.Controls.Add(tabr6c6)
            tabr6.Controls.Add(tabr6c7)

            tab1.Controls.Add(tabr6)
        Next
        Dim tabline5 As New TableRow
        tabline5.Width = 12
        Dim tabcellline5 As New TableCell
        tabcellline5.ColumnSpan = 12
        tabcellline5.Text = "<hr>"
        tabline5.Controls.Add(tabcellline5)
        tab1.Controls.Add(tabline5)
        Dim totr As New TableRow
        totr.Width = 12
        totr.ForeColor = Drawing.Color.Red
        Dim tot1, tot2, tot3, tot4, tot5, tot6, tot7 As New TableCell
        tot1.ColumnSpan = 2
        tot2.ColumnSpan = 1
        tot3.ColumnSpan = 2
        tot4.ColumnSpan = 1
        tot5.ColumnSpan = 3
        tot6.ColumnSpan = 3

        tot1.Text = "<font size=3>TOTAL :  " & tot & "<font>"
        tot2.Text = ""
        tot3.Text = "<font size=3>MALE : " & totmale & "<font>"
        tot4.Text = ""
        tot5.Text = "<font size=3>FEMALE : " & totfemale & "<font>"
        tot6.Text = ""

        totr.Controls.Add(tot1)
        totr.Controls.Add(tot2)
        totr.Controls.Add(tot3)
        totr.Controls.Add(tot4)
        totr.Controls.Add(tot5)
        totr.Controls.Add(tot6)

        tab1.Controls.Add(totr)
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

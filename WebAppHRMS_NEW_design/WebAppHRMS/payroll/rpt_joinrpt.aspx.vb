Imports System.Data
Imports System.Data.OracleClient

Partial Class joinig_report_rpt_joinrpt_9890d8984246
    Inherits System.Web.UI.Page
    Dim oh As New Helper.Oracle.OracleHelper
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable = oh.ExecuteDataSet(Request.QueryString.Get("sql")).Tables(0)

        Dim tab1 As New Table
        'tab1.Attributes.Add("border", "1")
        tab1.Attributes.Add("width", "100%")
        Dim tabr1 As New TableRow
        tabr1.Width = 9
        tabr1.Attributes.Add("bgcolor", "gold")
        tabr1.Attributes.Add("bordercolor", "red")
        Dim tabc1 As New TableCell

        tabc1.Text = "<body align=center color=red><b><font size=4>" & Session("firm_name") & " </font></b></body>"
        tabc1.ColumnSpan = 9
        tabc1.ForeColor = Drawing.Color.Red
        tabr1.Controls.Add(tabc1)
        tab1.Controls.Add(tabr1)

        '2nd row
        Dim tabr2 As New TableRow
        tabr2.Width = 9
        tabr2.ForeColor = Drawing.Color.Maroon
        'cell declaration
        Dim tabc2 As New TableCell

        tabc2.Text = "<body align=center><b> EMPLOYEE JOINING REPORT </b></body>"
        tabc2.ColumnSpan = 9
        tabr2.Controls.Add(tabc2)
        tab1.Controls.Add(tabr2)


        '3RD ROW
        Dim tabrr3 As New TableRow
        tabrr3.Width = 9
        tabrr3.Attributes.Add("bgcolor", "#ffcca3")

        'cell declaration
        Dim tabcc3 As New TableCell
        tabcc3.ForeColor = Drawing.Color.Maroon
        tabcc3.Attributes.Add("align", "left")
        tabcc3.Text = "<b><font size=2.5>DATE: " & Format(Now.Date, "dd/MMM/yyyy") & " </font></b>"
        tabcc3.ColumnSpan = 5
        tabrr3.Controls.Add(tabcc3)
        tab1.Controls.Add(tabrr3)
        'cell declaration
        Dim tabcc4 As New TableCell
        tabcc4.ForeColor = Drawing.Color.Maroon

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

        tabcc4.Text = "<b><font size=2.5>TIME: " & hr.ToString & ":" & Date.Now.Minute & ":" & Date.Now.Second & " " & dat & "</font></b>"
        tabcc4.ColumnSpan = 4
        tabrr3.Controls.Add(tabcc4)
        tab1.Controls.Add(tabrr3)

        Dim tabline As New TableRow
        tabline.Width = 9
        Dim tabcellline As New TableCell
        tabcellline.ColumnSpan = 9
        tabcellline.Text = "<hr>"
        tabline.Controls.Add(tabcellline)
        tab1.Controls.Add(tabline)

        '5th row

        Dim tabr5 As New TableRow
        tabr5.Width = 9
        tabr5.ForeColor = Drawing.Color.DarkSlateGray
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, fempc, fnstate As New TableCell
        tabr5c1.ColumnSpan = 1
        fempc.ColumnSpan = 1
        tabr5c2.ColumnSpan = 1
        tabr5c3.ColumnSpan = 1
        tabr5c4.ColumnSpan = 1
        tabr5c5.ColumnSpan = 1
        tabr5c6.ColumnSpan = 1
        tabr5c7.ColumnSpan = 1
        fnstate.ColumnSpan = 1

        tabr5c1.HorizontalAlign = HorizontalAlign.Center
        fempc.HorizontalAlign = HorizontalAlign.Left
        tabr5c7.HorizontalAlign = HorizontalAlign.Right
        fnstate.HorizontalAlign = HorizontalAlign.Left

        tabr5c1.Text = "<font size=2><b>SI NO&nbsp;</b></font>"
        fempc.Text = "<font size=2><b>Emp&nbsp;Code&nbsp;</b></font>"
        tabr5c2.Text = "<font size=2><b>Emp&nbsp;Name&nbsp;</b></font>"
        tabr5c3.Text = "<font size=2><b>Desig.n&nbsp;</b></font>"
        tabr5c4.Text = "<font size=2><b>Branch&nbsp;</b></font>"
        tabr5c5.Text = "<font size=2><b>D.O.J&nbsp;</b></font>"
        tabr5c6.Text = "<font size=2><b>Department&nbsp;</b></font>"
        fnstate.Text = "<font size=2><b>Native&nbsp;State&nbsp;</b></font>"
        tabr5c7.Text = "<font size=2><b>Basic&nbsp;Pay&nbsp;</b></font>"

        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(fempc)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        tabr5.Controls.Add(tabr5c6)
        tabr5.Controls.Add(fnstate)
        tabr5.Controls.Add(tabr5c7)

        tab1.Controls.Add(tabr5)

        '''''''''''''''''''''''''''''''''''''''
        Dim tabline1 As New TableRow
        tabline1.Width = 9
        Dim tabcellline1 As New TableCell
        tabcellline1.ColumnSpan = 9
        tabcellline1.Text = "<hr>"
        tabline1.Controls.Add(tabcellline1)
        tab1.Controls.Add(tabline1)

        Dim COLORS As String
        Dim i As Integer = 0
        '''''''''''''''''''''''''''''''''''''''''''
        'data
        COLORS = "#fff3ff"
        Dim firm As String = ""

        Dim dr As DataRow
        For Each dr In dt.Rows

            If COLORS.Equals("#fff3ff") = True Then
                COLORS = "#eef9ff"
            Else
                COLORS = "#fff3ff"
            End If
            If firm <> dr(6) Then
                Dim firmrow As New TableRow
                firmrow.Width = 9
                Dim firmcell As New TableCell
                firmcell.ColumnSpan = 9
                firmcell.HorizontalAlign = HorizontalAlign.Center
                firmcell.BackColor = Drawing.Color.Lavender
                firmcell.ForeColor = Drawing.Color.Red
                firmcell.Text = "<b><u>" & dr(6) & "</u></b>"
                firmrow.Controls.Add(firmcell)
                tab1.Controls.Add(firmrow)
                Dim tabline29 As New TableRow
                tabline29.Width = 9
                Dim tabcellline239 As New TableCell
                tabcellline239.ColumnSpan = 9
                tabcellline239.Text = "<hr>"
                tabline29.Controls.Add(tabcellline239)
                tab1.Controls.Add(tabline29)
                firm = dr(6)

            End If
            i = i + 1
            Dim tabr6 As New TableRow
            tabr6.Width = 9
            tabr6.Attributes.Add("bgcolor", COLORS)
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, cempc, cnatst As New TableCell
            tabr6c1.ColumnSpan = 1
            tabr6c2.ColumnSpan = 1
            tabr6c3.ColumnSpan = 1
            tabr6c4.ColumnSpan = 1
            tabr6c5.ColumnSpan = 1
            tabr6c6.ColumnSpan = 1
            tabr6c7.ColumnSpan = 1
            cempc.ColumnSpan = 1
            cnatst.ColumnSpan = 1

            tabr6c1.Attributes.Add("align", "center")
            tabr6c2.Attributes.Add("align", "left")
            tabr6c3.Attributes.Add("align", "left")
            tabr6c4.Attributes.Add("align", "left")
            tabr6c5.Attributes.Add("align", "center")
            tabr6c6.Attributes.Add("align", "left")
            tabr6c7.Attributes.Add("align", "right")
            cempc.HorizontalAlign = HorizontalAlign.Left
            cnatst.HorizontalAlign = HorizontalAlign.Left

            tabr6c1.Text = "<font size=2>" & i & "&nbsp;&nbsp;</font>"
            cempc.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;</font>"
            tabr6c2.Text = "<font size=2>" & dr(1) & "&nbsp;&nbsp;</font>"
            tabr6c3.Text = "<font size=2>" & dr(2) & "&nbsp;&nbsp;</font>" 'edesign
            tabr6c4.Text = "<font size=2>" & dr(3) & "&nbsp;&nbsp;</font>"  'branch
            tabr6c5.Text = "<font size=2>" & Format(dr(4), "dd/MMM/yyyy") & "&nbsp;&nbsp;</font>"  'join datre
            tabr6c6.Text = "<font size=2>" & dr(5) & "&nbsp;&nbsp;</font>"
            tabr6c7.Text = "<font size=2>" & dr(7) & "&nbsp;&nbsp;</font>"
            cnatst.Text = "<font size=2>" & dr(8) & "&nbsp;&nbsp;</font>"



            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(cempc)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)
            tabr6.Controls.Add(tabr6c6)
            tabr6.Controls.Add(cnatst)
            tabr6.Controls.Add(tabr6c7)


            tab1.Controls.Add(tabr6)

            'Dim tabline23 As New TableRow
            'tabline23.Width = 10
            'Dim tabcellline233 As New TableCell
            'tabcellline233.ColumnSpan = 10
            'tabcellline233.Text = "<hr>"
            'tabline23.Controls.Add(tabcellline233)
            'tab1.Controls.Add(tabline23)
        Next

        Me.Panel1.Controls.Add(tab1)
    End Sub
End Class

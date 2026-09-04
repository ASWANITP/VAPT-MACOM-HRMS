Imports System.Data
Imports System.Data.OracleClient
Partial Class report_appln_received_and_shortlisted_rpt_applnreceived_565df5794454
    Inherits System.Web.UI.Page
    Dim oh As New helper.oracle.oraclehelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt As DataTable = oh.ExecuteDataSet(Request.QueryString("sql")).Tables(0)
        If Request.QueryString("check") = 1 Then
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'table declaration
        Dim tab1 As New Table
        tab1.Attributes.Add("width", "100%")
        'tab1.BorderStyle = BorderStyle.Solid
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
        If Request.QueryString("check") = 1 Then
            tabc2.Text = "<body align=center color=red><b><font size=3.5> APPLICATION RECEIVED REPORT </font></b></body>"
        Else
            tabc2.Text = "<body align=center color=red><b><font size=3.5> SHORT LIST REPORT </font></b></body>"
        End If

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
        tabcc4.Font.Bold = True
        tabcc4.Text = "<div id='txt'></div>"
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
        Dim tabr5c1, tabr5c2, tabr5c3, tabr5c4, tabr5c5, tabr5c6, tabr5c7, tabr5c8 As New TableCell

        If Request.QueryString("check") = 1 Then
            tabr5c1.ColumnSpan = "1"
            tabr5c2.ColumnSpan = "1"
            tabr5c3.ColumnSpan = "2"
            tabr5c4.ColumnSpan = "2"
            tabr5c5.ColumnSpan = "1"
            tabr5c6.ColumnSpan = "1"
            tabr5c7.ColumnSpan = "2"
            tabr5c8.ColumnSpan = "2"
            tabr5c1.HorizontalAlign = HorizontalAlign.Center
            tabr5c2.HorizontalAlign = HorizontalAlign.Center
            tabr5c5.HorizontalAlign = HorizontalAlign.Center
            tabr5c6.HorizontalAlign = HorizontalAlign.Center
            tabr5c3.HorizontalAlign = HorizontalAlign.Left
            tabr5c4.HorizontalAlign = HorizontalAlign.Left
            tabr5c7.HorizontalAlign = HorizontalAlign.Left
            tabr5c8.HorizontalAlign = HorizontalAlign.Left
            tabr5c1.Text = "<b><font size=2.5>SI.NO</font></b>"
            tabr5c2.Text = "<b><font size=2.5>APP.NO</font></b>"
            tabr5c3.Text = "<b><font size=2.5>NAME</font></b>"
            tabr5c4.Text = "<b><font size=2.5>QUALIFICATION</font></b>"
            tabr5c5.Text = "<b><font size=2.5>AGE</font></b>"
            tabr5c6.Text = "<b><font size=2.5>GENDER</font></b>"
            tabr5c7.Text = "<b><font size=2.5>DISTRICT</font></b>"
            tabr5c8.Text = "<b><font size=2.5>STATE</font></b>"

        ElseIf Request.QueryString("check") = 2 Then

            tabr5c1.HorizontalAlign = HorizontalAlign.Center
            tabr5c2.HorizontalAlign = HorizontalAlign.Center
            tabr5c5.HorizontalAlign = HorizontalAlign.Left
            tabr5c6.HorizontalAlign = HorizontalAlign.Left
            tabr5c1.Text = "<b><font size=2.5>SI.NO</font></b>"
            tabr5c2.Text = "<b><font size=2.5>APP.NO</font></b>"
            tabr5c3.Text = "<b><font size=2.5>NAME</font></b>"
            tabr5c4.Text = "<b><font size=2.5>QUALIFICATION</font></b>"
            tabr5c5.Text = "<b><font size=2.5>POST</font></b>"
            tabr5c6.Text = "<b><font size=2.5>INTERVIEW AT</font></b>"
            tabr5c7.Text = "<b><font size=2.5>DISTRICT</font></b>"
            tabr5c8.Text = "<b><font size=2.5>STATE</font></b>"

        End If

        tabr5.Controls.Add(tabr5c1)
        tabr5.Controls.Add(tabr5c2)
        tabr5.Controls.Add(tabr5c3)
        tabr5.Controls.Add(tabr5c4)
        tabr5.Controls.Add(tabr5c5)
        tabr5.Controls.Add(tabr5c6)
        tabr5.Controls.Add(tabr5c7)
        tabr5.Controls.Add(tabr5c8)


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
        Dim i As Integer = 0
        For Each dr In dt.Rows
            i = i + 1
            If colors.Equals("#fff7ff") = True Then
                colors = "#eef9ff"
            Else
                colors = "#fff7ff"
            End If
            Dim tabr6 As New TableRow
            tabr6.Width = 12
            tabr6.Attributes.Add("bgcolor", colors)
            Dim tabr6c1, tabr6c2, tabr6c3, tabr6c4, tabr6c5, tabr6c6, tabr6c7, tabr6c8 As New TableCell

            If Request.QueryString("check") = 1 Then
                tabr6c1.ColumnSpan = "1"
                tabr6c2.ColumnSpan = "1"
                tabr6c3.ColumnSpan = "2"
                tabr6c4.ColumnSpan = "2"
                tabr6c5.ColumnSpan = "1"
                tabr6c6.ColumnSpan = "1"
                tabr6c7.ColumnSpan = "2"
                tabr6c8.ColumnSpan = "2"

                tabr6c1.Attributes.Add("align", "center")
                tabr6c2.Attributes.Add("align", "center")
                tabr6c3.Attributes.Add("align", "left")
                tabr6c4.Attributes.Add("align", "left")
                tabr6c5.Attributes.Add("align", "center")
                tabr6c6.Attributes.Add("align", "center")
                tabr6c7.Attributes.Add("align", "left")
                tabr6c8.Attributes.Add("align", "left")

                tabr6c1.Text = "<font size=2>" & i & "</font>"
                tabr6c2.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c3.Text = "<font size=2>" & dr(1) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c4.Text = "<font size=2>" & dr(2) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c5.Text = dr(6)
                If dr(3) = 0 Then
                    tabr6c6.Text = "<font size=2>MALE &nbsp;&nbsp;&nbsp;</font>"
                Else
                    tabr6c6.Text = "<font size=2>FEMALE &nbsp;&nbsp;&nbsp;</font>"

                End If

                tabr6c7.Text = "<font size=2>" & dr(4) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c8.Text = "<font size=2>" & dr(5) & "&nbsp;&nbsp;&nbsp;</font>"

            ElseIf Request.QueryString("check") = 2 Then

                tabr6c1.Attributes.Add("align", "center")
                tabr6c2.Attributes.Add("align", "center")
                tabr6c3.Attributes.Add("align", "left")
                tabr6c4.Attributes.Add("align", "left")
                tabr6c5.Attributes.Add("align", "left")
                tabr6c6.Attributes.Add("align", "left")
                tabr6c7.Attributes.Add("align", "left")
                tabr6c8.Attributes.Add("align", "left")

                tabr6c1.Text = "<font size=2>" & i & "</font>"
                tabr6c2.Text = "<font size=2>" & dr(0) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c3.Text = "<font size=2>" & dr(1) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c4.Text = "<font size=2>" & dr(2) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c5.Text = "<font size=2>" & dr(3) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c6.Text = "<font size=2>" & dr(4) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c7.Text = "<font size=2>" & dr(5) & "&nbsp;&nbsp;&nbsp;</font>"
                tabr6c8.Text = "<font size=2>" & dr(6) & "&nbsp;&nbsp;&nbsp;</font>"
            End If

            tabr6.Controls.Add(tabr6c1)
            tabr6.Controls.Add(tabr6c2)
            tabr6.Controls.Add(tabr6c3)
            tabr6.Controls.Add(tabr6c4)
            tabr6.Controls.Add(tabr6c5)
            tabr6.Controls.Add(tabr6c6)
            tabr6.Controls.Add(tabr6c7)
            tabr6.Controls.Add(tabr6c8)

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
